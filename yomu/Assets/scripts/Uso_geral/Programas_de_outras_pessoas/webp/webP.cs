using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using UnityEngine;



public sealed class WebP : IDisposable{


    private const int WEBP_MAX_DIMENSION = 16383;



    public Sprite Pegar_sprite( byte[] rawWebP ){
        

        GetInfo( rawWebP, out int imgWidth, out int imgHeight, out bool hasAlpha, out bool hasAnimation, out string format );



        int n_bytes = -1;
        if (hasAlpha)
                { n_bytes = 4;}
            else
                { n_bytes = 3;}



        byte[] bytes = new byte[ imgHeight * imgWidth * n_bytes ];

        GCHandle pinnedWebP = GCHandle.Alloc( rawWebP, GCHandleType.Pinned );
        GCHandle handle = GCHandle.Alloc( bytes, GCHandleType.Pinned);

            
        IntPtr ptrData = pinnedWebP.AddrOfPinnedObject();
        IntPtr pointer_dados =  handle.AddrOfPinnedObject();
        
        int outputSize = ( imgWidth * n_bytes ) * imgHeight;
        

        try
            {

                
                Color32[] colors = new Color32[ ( bytes.Length / n_bytes ) ];

                if ( n_bytes == 3 )
                        { 
                            UnsafeNativeMethods.WebPDecodeBGRInto( ptrData, rawWebP.Length, pointer_dados, outputSize, ( imgWidth * n_bytes ) );

                            //UnsafeNativeMethods.WebPDecodeARGBInto( ptrData, rawWebP.Length, pointer_dados, outputSize, ( imgWidth * n_bytes ) );

                            for( int c= 0 ;  c < colors.Length; c++ ){

                                    Color32 color = new Color32();
                                    color[ 0 ] = bytes[ ( c * 3 ) + 2 ];
                                    color[ 1 ] = bytes[ ( c * 3 ) + 1 ];
                                    color[ 2 ] = bytes[ ( c * 3 ) + 0 ];
                                    color[ 3 ] = ( byte ) 255;

                                    
                                    colors[ (  ( imgWidth - 1  ) - ( c % imgWidth )  ) + (  ( imgWidth  * ( imgHeight - 1 )  ) - ( ( c / imgWidth ) * imgWidth )  ) ] = color;

                                    //colors[ colors.Length - c - 1 ] = color;
                                    continue;

                            }
                        }
                    else
                        { 
                            UnsafeNativeMethods.WebPDecodeBGRAInto( ptrData, rawWebP.Length, pointer_dados, outputSize, ( imgWidth * n_bytes ) );

                            for( int c= 0 ;  c < colors.Length; c++ ){

                                    Color32 color = new Color32();
                                    color[ 0 ] = bytes[ ( c * 4 ) + 2 ];
                                    color[ 1 ] = bytes[ ( c * 4 ) + 1 ];
                                    color[ 2 ] = bytes[ ( c * 4 ) + 0 ];
                                    color[ 3 ] = bytes[ ( c * 4 ) + 3 ];



                                    colors[ colors.Length - c - 1 ] = color;


                                    continue;

                            }

                            
                        }

                        //Geral.Salvar_byte_array( bytes );



            

                Sprite sprite = SPRITE.Transformar_colors_container_TO_sprite( colors, imgHeight, imgWidth );


                return sprite;
            }

        catch (Exception) 
        { throw; }


        finally
        {
            
            //Free memory
            if (pinnedWebP.IsAllocated)
                pinnedWebP.Free();
            if (handle.IsAllocated)
                handle.Free();                
        }






    }




    public void GetInfo( byte[] rawWebP, out int width, out int height, out bool has_alpha, out bool has_animation, out string format ){


        VP8StatusCode result;
        GCHandle pinnedWebP = GCHandle.Alloc(rawWebP, GCHandleType.Pinned);

        try
        {
            IntPtr ptrRawWebP = pinnedWebP.AddrOfPinnedObject();

            WebPBitstreamFeatures features = new WebPBitstreamFeatures();
            result = UnsafeNativeMethods.WebPGetFeatures(ptrRawWebP, rawWebP.Length, ref features);

            if (result != 0)
                throw new Exception(result.ToString());

            width = features.Width;
            height = features.Height;
            if (features.Has_alpha == 1) has_alpha = true; else has_alpha = false;
            if (features.Has_animation == 1) has_animation = true; else has_animation = false;
            switch (features.Format)
            {
                case 1:
                    format = "lossy";
                    break;
                case 2:
                    format = "lossless";
                    break;
                default:
                    format = "undefined";
                    break;
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message + "\r\nIn WebP.GetInfo"); }
        finally
        {
            //Free memory
            if (pinnedWebP.IsAllocated)
                pinnedWebP.Free();
        }
    }






        public Sprite Decode_2( byte[] rawWebP ){


            VP8StatusCode result;

            GetInfo( rawWebP, out int imgWidth, out int imgHeight, out bool hasAlpha, out bool hasAnimation, out string format );


            WebPDecoderOptions options = new WebPDecoderOptions();
            WebPDecoderConfig config = new WebPDecoderConfig();


            byte[] bytes = new byte[ imgHeight * imgWidth * 4 ];

            GCHandle pinnedWebP = GCHandle.Alloc(rawWebP, GCHandleType.Pinned);
            GCHandle handle = GCHandle.Alloc( bytes, GCHandleType.Pinned);




            IntPtr ptrRawWebP = pinnedWebP.AddrOfPinnedObject();
            IntPtr pointer_dados =  handle.AddrOfPinnedObject();
            


            if (UnsafeNativeMethods.WebPInitDecoderConfig(ref config) == 0)
            {  throw new Exception("WebPInitDecoderConfig failed. Wrong version?");}
            // Read the .webp input file information

            config.options.bypass_filtering = options.bypass_filtering;
            config.options.no_fancy_upsampling = options.no_fancy_upsampling;
            config.options.use_cropping = options.use_cropping;
            config.options.crop_left = options.crop_left;
            config.options.crop_top = options.crop_top;
            config.options.crop_width = options.crop_width;
            config.options.crop_height = options.crop_height;
            config.options.use_scaling = options.use_scaling;
            config.options.scaled_width = options.scaled_width;
            config.options.scaled_height = options.scaled_height;
            config.options.use_threads = options.use_threads;
            config.options.dithering_strength = options.dithering_strength;
            config.options.flip = 1;
            config.options.alpha_dithering_strength = options.alpha_dithering_strength;


            //Create a BitmapData and Lock all pixels to be written
            if ( config.input.Has_alpha == 1)
                { config.output.colorspace = WEBP_CSP_MODE.MODE_RGBA; }
                else
                { config.output.colorspace = WEBP_CSP_MODE.MODE_RGBA; }




            // Specify the output format
            config.output.u.RGBA.rgba = pointer_dados;
            config.output.u.RGBA.stride = ( imgWidth * 4 );
            config.output.u.RGBA.size = (UIntPtr)( imgHeight * ( imgWidth * 4 ) );
            config.output.height = imgHeight;
            config.output.width = imgWidth;
            config.output.is_external_memory = 1;



            // Decode
            result = UnsafeNativeMethods.WebPDecode(  ptrRawWebP, rawWebP.Length, ref config);


            if (result != VP8StatusCode.VP8_STATUS_OK)
            { throw new Exception("Failed WebPDecode with error " + result); }

            UnsafeNativeMethods.WebPFreeDecBuffer(ref config.output);


            //Geral.Salvar_byte_array( bytes );
            Debug.Log( bytes.Length );



            // pode multithread
            if( ( imgHeight * imgWidth * 4 ) != bytes.Length )
                    { throw new Exception( $"" ); }

            Texture2D tex = new Texture2D(  imgWidth  , imgHeight , TextureFormat.RGBA32,  false ); 

            tex.SetPixelData( bytes , 0 );
            tex.Apply( false, false );
            tex.filterMode = UnityEngine.FilterMode.Point;

            Sprite sprite_retorno  =   Sprite.Create(tex  ,     new Rect( 0.0f, 0.0f, tex.width, tex.height ), new Vector2( 0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );



            if (handle.IsAllocated)
                handle.Free();

            if (pinnedWebP.IsAllocated)
                pinnedWebP.Free();
            



            return sprite_retorno;



    


        }
































    private int MyWriter([InAttribute()] IntPtr data, UIntPtr data_size, ref WebPPicture picture)
    {
        UnsafeNativeMethods.CopyMemory(picture.custom_ptr, data, (uint)data_size);
        //picture.custom_ptr = IntPtr.Add(picture.custom_ptr, (int)data_size);   //Only in .NET > 4.0
        picture.custom_ptr = new IntPtr(picture.custom_ptr.ToInt64() + (int)data_size);
        return 1;
    }

    private delegate int MyWriterDelegate([InAttribute()] IntPtr data, UIntPtr data_size, ref WebPPicture picture);
    

    
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    
}


[SuppressUnmanagedCodeSecurityAttribute]
internal sealed partial class UnsafeNativeMethods
{

    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    internal static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

    private static readonly int WEBP_DECODER_ABI_VERSION = 0x0208;

    

    internal static int WebPConfigInit(ref WebPConfig config, WebPPreset preset, float quality)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPConfigInitInternal_x86(ref config, preset, quality, WEBP_DECODER_ABI_VERSION);
            case 8:
                return WebPConfigInitInternal_x64(ref config, preset, quality, WEBP_DECODER_ABI_VERSION);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPConfigInitInternal")]
    private static extern int WebPConfigInitInternal_x86(ref WebPConfig config, WebPPreset preset, float quality, int WEBP_DECODER_ABI_VERSION);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPConfigInitInternal")]
    private static extern int WebPConfigInitInternal_x64(ref WebPConfig config, WebPPreset preset, float quality, int WEBP_DECODER_ABI_VERSION);


    internal static VP8StatusCode WebPGetFeatures(IntPtr rawWebP, int data_size, ref WebPBitstreamFeatures features)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPGetFeaturesInternal_x86(rawWebP, (UIntPtr)data_size, ref features, WEBP_DECODER_ABI_VERSION);
            case 8:
                return WebPGetFeaturesInternal_x64(rawWebP, (UIntPtr)data_size, ref features, WEBP_DECODER_ABI_VERSION);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPGetFeaturesInternal")]
    private static extern VP8StatusCode WebPGetFeaturesInternal_x86([InAttribute()] IntPtr rawWebP, UIntPtr data_size, ref WebPBitstreamFeatures features, int WEBP_DECODER_ABI_VERSION);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPGetFeaturesInternal")]
    private static extern VP8StatusCode WebPGetFeaturesInternal_x64([InAttribute()] IntPtr rawWebP, UIntPtr data_size, ref WebPBitstreamFeatures features, int WEBP_DECODER_ABI_VERSION);


    internal static int WebPConfigLosslessPreset(ref WebPConfig config, int level)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPConfigLosslessPreset_x86(ref config, level);
            case 8:
                return WebPConfigLosslessPreset_x64(ref config, level);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPConfigLosslessPreset")]
    private static extern int WebPConfigLosslessPreset_x86(ref WebPConfig config, int level);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPConfigLosslessPreset")]
    private static extern int WebPConfigLosslessPreset_x64(ref WebPConfig config, int level);

    internal static int WebPValidateConfig(ref WebPConfig config)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPValidateConfig_x86(ref config);
            case 8:
                return WebPValidateConfig_x64(ref config);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPValidateConfig")]
    private static extern int WebPValidateConfig_x86(ref WebPConfig config);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPValidateConfig")]
    private static extern int WebPValidateConfig_x64(ref WebPConfig config);


    internal static int WebPPictureInitInternal(ref WebPPicture wpic)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPPictureInitInternal_x86(ref wpic, WEBP_DECODER_ABI_VERSION);
            case 8:
                return WebPPictureInitInternal_x64(ref wpic, WEBP_DECODER_ABI_VERSION);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureInitInternal")]
    private static extern int WebPPictureInitInternal_x86(ref WebPPicture wpic, int WEBP_DECODER_ABI_VERSION);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureInitInternal")]
    private static extern int WebPPictureInitInternal_x64(ref WebPPicture wpic, int WEBP_DECODER_ABI_VERSION);

    
    internal static int WebPPictureImportBGR(ref WebPPicture wpic, IntPtr bgr, int stride)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPPictureImportBGR_x86(ref wpic, bgr, stride);
            case 8:
                return WebPPictureImportBGR_x64(ref wpic, bgr, stride);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureImportBGR")]
    private static extern int WebPPictureImportBGR_x86(ref WebPPicture wpic, IntPtr bgr, int stride);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureImportBGR")]
    private static extern int WebPPictureImportBGR_x64(ref WebPPicture wpic, IntPtr bgr, int stride);

    internal static int WebPPictureImportBGRA(ref WebPPicture wpic, IntPtr bgra, int stride)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPPictureImportBGRA_x86(ref wpic, bgra, stride);
            case 8:
                return WebPPictureImportBGRA_x64(ref wpic, bgra, stride);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureImportBGRA")]
    private static extern int WebPPictureImportBGRA_x86(ref WebPPicture wpic, IntPtr bgra, int stride);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureImportBGRA")]
    private static extern int WebPPictureImportBGRA_x64(ref WebPPicture wpic, IntPtr bgra, int stride);

    
    internal static int WebPPictureImportBGRX(ref WebPPicture wpic, IntPtr bgr, int stride)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPPictureImportBGRX_x86(ref wpic, bgr, stride);
            case 8:
                return WebPPictureImportBGRX_x64(ref wpic, bgr, stride);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureImportBGRX")]
    private static extern int WebPPictureImportBGRX_x86(ref WebPPicture wpic, IntPtr bgr, int stride);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureImportBGRX")]
    private static extern int WebPPictureImportBGRX_x64(ref WebPPicture wpic, IntPtr bgr, int stride);

    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int WebPMemoryWrite([In()] IntPtr data, UIntPtr data_size, ref WebPPicture wpic);
    internal static WebPMemoryWrite OnCallback;

    internal static int WebPEncode(ref WebPConfig config, ref WebPPicture picture)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPEncode_x86(ref config, ref picture);
            case 8:
                return WebPEncode_x64(ref config, ref picture);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncode")]
    private static extern int WebPEncode_x86(ref WebPConfig config, ref WebPPicture picture);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncode")]
    private static extern int WebPEncode_x64(ref WebPConfig config, ref WebPPicture picture);

    
    /// Note that this function does _not_ free the memory used by the 'picture' object itself.
    /// Besides memory (which is reclaimed) all other fields of 'picture' are preserved</summary>
    /// <param name="picture">Picture structure</param>
    internal static void WebPPictureFree(ref WebPPicture picture)
    {
        switch (IntPtr.Size)
        {
            case 4:
                WebPPictureFree_x86(ref picture);
                break;
            case 8:
                WebPPictureFree_x64(ref picture);
                break;
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureFree")]
    private static extern void WebPPictureFree_x86(ref WebPPicture wpic);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureFree")]
    private static extern void WebPPictureFree_x64(ref WebPPicture wpic);

    

    internal static int WebPGetInfo(IntPtr data, int data_size, out int width, out int height)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPGetInfo_x86(data, (UIntPtr)data_size, out width, out height);
            case 8:
                return WebPGetInfo_x64(data, (UIntPtr)data_size, out width, out height);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPGetInfo")]
    private static extern int WebPGetInfo_x86([InAttribute()] IntPtr data, UIntPtr data_size, out int width, out int height);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPGetInfo")]
    private static extern int WebPGetInfo_x64([InAttribute()] IntPtr data, UIntPtr data_size, out int width, out int height);


    internal static void WebPDecodeBGRInto(IntPtr data, int data_size, IntPtr output_buffer, int output_buffer_size, int output_stride)
    {
        switch (IntPtr.Size)
        {
            case 4:
                if (WebPDecodeBGRInto_x86(data, (UIntPtr)data_size, output_buffer, output_buffer_size, output_stride) == null)
                    throw new InvalidOperationException("Can not decode WebP");
                break;
            case 8:
                if (WebPDecodeBGRInto_x64(data, (UIntPtr)data_size, output_buffer, output_buffer_size, output_stride) == null)
                    throw new InvalidOperationException("Can not decode WebP");
                break;
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecodeBGRInto")]
    private static extern IntPtr WebPDecodeBGRInto_x86([InAttribute()] IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecodeBGRInto")]
    private static extern IntPtr WebPDecodeBGRInto_x64([InAttribute()] IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);










    internal static void WebPDecodeBGRAInto(IntPtr data, int data_size, IntPtr output_buffer, int output_buffer_size, int output_stride){


        switch (IntPtr.Size)
        {
            case 4:
                if (WebPDecodeBGRAInto_x86(data, (UIntPtr)data_size, output_buffer, output_buffer_size, output_stride) == null)
                    throw new InvalidOperationException("Can not decode WebP"); 
                break;
            case 8:
                if (WebPDecodeBGRAInto_x64(data, (UIntPtr)data_size, output_buffer, output_buffer_size, output_stride) == null)
                    throw new InvalidOperationException("Can not decode WebP");
                break;
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }

    }


    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecodeBGRAInto")]
    private static extern IntPtr WebPDecodeBGRAInto_x86([InAttribute()] IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecodeBGRAInto")]
    private static extern IntPtr WebPDecodeBGRAInto_x64([InAttribute()] IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);

    










    internal static void WebPDecodeARGBInto(IntPtr data, int data_size, IntPtr output_buffer, int output_buffer_size, int output_stride)
    {
        switch (IntPtr.Size)
        {
            case 4:
                if (WebPDecodeARGBInto_x86(data, (UIntPtr)data_size, output_buffer, output_buffer_size, output_stride) == null)
                    throw new InvalidOperationException("Can not decode WebP");
                break;
            case 8:
                if (WebPDecodeARGBInto_x64(data, (UIntPtr)data_size, output_buffer, output_buffer_size, output_stride) == null)
                    throw new InvalidOperationException("Can not decode WebP");
                break;
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecodeARGBInto")]
    private static extern IntPtr WebPDecodeARGBInto_x86([InAttribute()] IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecodeARGBInto")]
    private static extern IntPtr WebPDecodeARGBInto_x64([InAttribute()] IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);




    

    internal static int WebPInitDecoderConfig(ref WebPDecoderConfig webPDecoderConfig)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPInitDecoderConfigInternal_x86(ref webPDecoderConfig, WEBP_DECODER_ABI_VERSION);
            case 8:
                return WebPInitDecoderConfigInternal_x64(ref webPDecoderConfig, WEBP_DECODER_ABI_VERSION);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPInitDecoderConfigInternal")]
    private static extern int WebPInitDecoderConfigInternal_x86(ref WebPDecoderConfig webPDecoderConfig, int WEBP_DECODER_ABI_VERSION);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPInitDecoderConfigInternal")]
    private static extern int WebPInitDecoderConfigInternal_x64(ref WebPDecoderConfig webPDecoderConfig, int WEBP_DECODER_ABI_VERSION);

    
    internal static VP8StatusCode WebPDecode(IntPtr data, int data_size, ref WebPDecoderConfig webPDecoderConfig)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPDecode_x86(data, (UIntPtr)data_size, ref webPDecoderConfig);
            case 8:
                return WebPDecode_x64(data, (UIntPtr)data_size, ref webPDecoderConfig);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecode")]
    private static extern VP8StatusCode WebPDecode_x86(IntPtr data, UIntPtr data_size, ref WebPDecoderConfig config);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPDecode")]
    private static extern VP8StatusCode WebPDecode_x64(IntPtr data, UIntPtr data_size, ref WebPDecoderConfig config);

    

    internal static void WebPFreeDecBuffer(ref WebPDecBuffer buffer)
    {
        switch (IntPtr.Size)
        {
            case 4:
                WebPFreeDecBuffer_x86(ref buffer);
                break;
            case 8:
                WebPFreeDecBuffer_x64(ref buffer);
                break;
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPFreeDecBuffer")]
    private static extern void WebPFreeDecBuffer_x86(ref WebPDecBuffer buffer);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPFreeDecBuffer")]
    private static extern void WebPFreeDecBuffer_x64(ref WebPDecBuffer buffer);

    



    internal static int WebPEncodeBGR(IntPtr bgr, int width, int height, int stride, float quality_factor, out IntPtr output)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPEncodeBGR_x86(bgr, width, height, stride, quality_factor, out output);
            case 8:
                return WebPEncodeBGR_x64(bgr, width, height, stride, quality_factor, out output);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeBGR")]
    private static extern int WebPEncodeBGR_x86([InAttribute()] IntPtr bgr, int width, int height, int stride, float quality_factor, out IntPtr output);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeBGR")]
    private static extern int WebPEncodeBGR_x64([InAttribute()] IntPtr bgr, int width, int height, int stride, float quality_factor, out IntPtr output);

  
    internal static int WebPEncodeBGRA(IntPtr bgra, int width, int height, int stride, float quality_factor, out IntPtr output)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPEncodeBGRA_x86(bgra, width, height, stride, quality_factor, out output);
            case 8:
                return WebPEncodeBGRA_x64(bgra, width, height, stride, quality_factor, out output);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeBGRA")]
    private static extern int WebPEncodeBGRA_x86([InAttribute()] IntPtr bgra, int width, int height, int stride, float quality_factor, out IntPtr output);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeBGRA")]
    private static extern int WebPEncodeBGRA_x64([InAttribute()] IntPtr bgra, int width, int height, int stride, float quality_factor, out IntPtr output);

    
    /// <param name="bgr">Pointer to BGR image data</param>
    /// <param name="width">The range is limited currently from 1 to 16383</param>
    /// <param name="height">The range is limited currently from 1 to 16383</param>
    /// <param name="stride">Specifies the distance between scan lines</param>
    /// <param name="output">output_buffer with WebP image</param>
    /// <returns>Size of WebP Image or 0 if an error occurred</returns>
    internal static int WebPEncodeLosslessBGR(IntPtr bgr, int width, int height, int stride, out IntPtr output)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPEncodeLosslessBGR_x86(bgr, width, height, stride, out output);
            case 8:
                return WebPEncodeLosslessBGR_x64(bgr, width, height, stride, out output);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeLosslessBGR")]
    private static extern int WebPEncodeLosslessBGR_x86([InAttribute()] IntPtr bgr, int width, int height, int stride, out IntPtr output);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeLosslessBGR")]
    private static extern int WebPEncodeLosslessBGR_x64([InAttribute()] IntPtr bgr, int width, int height, int stride, out IntPtr output);

    
    /// <param name="bgra">Pointer to BGRA image data</param>
    /// <param name="width">The range is limited currently from 1 to 16383</param>
    /// <param name="height">The range is limited currently from 1 to 16383</param>
    /// <param name="stride">Specifies the distance between scan lines</param>
    /// <param name="output">output_buffer with WebP image</param>
    /// <returns>Size of WebP Image or 0 if an error occurred</returns>
    internal static int WebPEncodeLosslessBGRA(IntPtr bgra, int width, int height, int stride, out IntPtr output)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPEncodeLosslessBGRA_x86(bgra, width, height, stride, out output);
            case 8:
                return WebPEncodeLosslessBGRA_x64(bgra, width, height, stride, out output);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeLosslessBGRA")]
    private static extern int WebPEncodeLosslessBGRA_x86([InAttribute()] IntPtr bgra, int width, int height, int stride, out IntPtr output);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPEncodeLosslessBGRA")]
    private static extern int WebPEncodeLosslessBGRA_x64([InAttribute()] IntPtr bgra, int width, int height, int stride, out IntPtr output);

    
    /// <param name="p">Pointer to memory</param>
    internal static void WebPFree(IntPtr p)
    {
        switch (IntPtr.Size)
        {
            case 4:
                WebPFree_x86(p);
                break;
            case 8:
                WebPFree_x64(p);
                break;
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPFree")]
    private static extern void WebPFree_x86(IntPtr p);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPFree")]
    private static extern void WebPFree_x64(IntPtr p);

    
    /// <returns>8bits for each of major/minor/revision packet in integer. E.g: v2.5.7 is 0x020507</returns>
    internal static int WebPGetDecoderVersion()
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPGetDecoderVersion_x86();
            case 8:
                return WebPGetDecoderVersion_x64();
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPGetDecoderVersion")]
    private static extern int WebPGetDecoderVersion_x86();
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPGetDecoderVersion")]
    private static extern int WebPGetDecoderVersion_x64();

    
    /// <param name="srcPicture">Picture to measure</param>
    /// <param name="refPicture">Reference picture</param>
    /// <param name="metric_type">0 = PSNR, 1 = SSIM, 2 = LSIM</param>
    /// <param name="pResult">dB in the Y/U/V/Alpha/All order</param>
    /// <returns>False in case of error (the two pictures don't have same dimension, ...)</returns>
    internal static int WebPPictureDistortion(ref WebPPicture srcPicture, ref WebPPicture refPicture, int metric_type, IntPtr pResult)
    {
        switch (IntPtr.Size)
        {
            case 4:
                return WebPPictureDistortion_x86(ref srcPicture, ref refPicture, metric_type, pResult);
            case 8:
                return WebPPictureDistortion_x64(ref srcPicture, ref refPicture, metric_type, pResult);
            default:
                throw new InvalidOperationException("Invalid platform. Can not find proper function");
        }
    }
    [DllImport("libwebp_x86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureDistortion")]
    private static extern int WebPPictureDistortion_x86(ref WebPPicture srcPicture, ref WebPPicture refPicture, int metric_type, IntPtr pResult);
    [DllImport("libwebp_x64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WebPPictureDistortion")]
    private static extern int WebPPictureDistortion_x64(ref WebPPicture srcPicture, ref WebPPicture refPicture, int metric_type, IntPtr pResult);
}




internal enum WebPPreset
{
    
    WEBP_PRESET_DEFAULT = 0,
    
    WEBP_PRESET_PICTURE,
    
    WEBP_PRESET_PHOTO,
    
    WEBP_PRESET_DRAWING,
    
    WEBP_PRESET_ICON,
    
    WEBP_PRESET_TEXT
};


internal enum WebPEncodingError
{
    
    VP8_ENC_OK = 0,
    
    VP8_ENC_ERROR_OUT_OF_MEMORY,
    
    VP8_ENC_ERROR_BITSTREAM_OUT_OF_MEMORY,
    
    VP8_ENC_ERROR_NULL_PARAMETER,
    
    VP8_ENC_ERROR_INVALID_CONFIGURATION,
    
    VP8_ENC_ERROR_BAD_DIMENSION,
    
    VP8_ENC_ERROR_PARTITION0_OVERFLOW,
    
    VP8_ENC_ERROR_PARTITION_OVERFLOW,
    
    VP8_ENC_ERROR_BAD_WRITE,
    
    VP8_ENC_ERROR_FILE_TOO_BIG,
    
    VP8_ENC_ERROR_USER_ABORT,
    
    VP8_ENC_ERROR_LAST,
}


internal enum VP8StatusCode
{
    
    VP8_STATUS_OK = 0,
    
    VP8_STATUS_OUT_OF_MEMORY,
    
    VP8_STATUS_INVALID_PARAM,
    VP8_STATUS_BITSTREAM_ERROR,
    
    VP8_STATUS_UNSUPPORTED_FEATURE,
    VP8_STATUS_SUSPENDED,
    
    VP8_STATUS_USER_ABORT,
    VP8_STATUS_NOT_ENOUGH_DATA,
}


internal enum WebPImageHint
{
    
    WEBP_HINT_DEFAULT = 0,
    
    WEBP_HINT_PICTURE,
    
    WEBP_HINT_PHOTO,
    
    WEBP_HINT_GRAPH,
    
    WEBP_HINT_LAST
};


internal enum WEBP_CSP_MODE
{
    
    MODE_RGB = 0,
    
    MODE_RGBA = 1,
    
    MODE_BGR = 2,
    
    MODE_BGRA = 3,
    
    MODE_ARGB = 4,
    
    /// WEBP_SWAP_16BITS_CSP is defined, 
    /// Byte-order: RGB-565: [a4 a3 a2 a1 a0 b5 b4 b3], [b2 b1 b0 g4 g3 g2 g1 g0], ..</summary>
    MODE_RGBA_4444 = 5,
    
    /// WEBP_SWAP_16BITS_CSP is defined, 
    /// Byte-order: [b3 b2 b1 b0 a3 a2 a1 a0], [r3 r2 r1 r0 g3 g2 g1 g0], ..</summary>
    MODE_RGB_565 = 6,
    
    MODE_rgbA = 7,
    
    MODE_bgrA = 8,
    
    MODE_Argb = 9,
    
    MODE_rgbA_4444 = 10,
    
    MODE_YUV = 11,
    
    MODE_YUVA = 12,
    
    MODE_LAST = 13,
}


/// Decoding states. State normally flows as:
/// WEBP_HEADER->VP8_HEADER->VP8_PARTS0->VP8_DATA->DONE for a lossy image, and
/// WEBP_HEADER->VP8L_HEADER->VP8L_DATA->DONE for a lossless image.
/// If there is any error the decoder goes into state ERROR.
/// </summary>
internal enum DecState
{
    STATE_WEBP_HEADER,  // All the data before that of the VP8/VP8L chunk.
    STATE_VP8_HEADER,   // The VP8 Frame header (within the VP8 chunk).
    STATE_VP8_PARTS0,
    STATE_VP8_DATA,
    STATE_VP8L_HEADER,
    STATE_VP8L_DATA,
    STATE_DONE,
    STATE_ERROR
};




[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPBitstreamFeatures
{
    
    public int Width;
    
    public int Height;
    
    public int Has_alpha;
    
    public int Has_animation;
    
    public int Format;
    
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.U4)]
    private readonly uint[] pad;
};


[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPConfig
{
    
    public int lossless;
    
    public float quality;
    
    public int method;
    
    public WebPImageHint image_hint;
    
    public int target_size;
    
    public float target_PSNR;
    
    public int segments;
    
    public int sns_strength;
    
    public int filter_strength;
    
    public int filter_sharpness;
    
    public int filter_type;
    
    public int autofilter;
    
    public int alpha_compression;
    
    public int alpha_filtering;
    
    public int alpha_quality;
    
    public int pass;
    
    public int show_compressed;
    
    public int preprocessing;
    
    public int partitions;
    
    public int partition_limit;
    
    public int emulate_jpeg_size;
    
    public int thread_level;
    
    public int low_memory;
    
    public int near_lossless;
    
    public int exact;
    
    public int delta_palettization;
    
    public int use_sharp_yuv;
    
    private readonly int pad1;
    private readonly int pad2;
};


[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPPicture
{
    
    public int use_argb;
    
    public UInt32 colorspace;
    
    public int width;
    
    public int height;
    
    public IntPtr y;
    
    public IntPtr u;
    
    public IntPtr v;
    
    public int y_stride;
    
    public int uv_stride;
    
    public IntPtr a;
    
    public int a_stride;
    
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
    private readonly uint[] pad1;
    
    public IntPtr argb;
    
    public int argb_stride;
    
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
    private readonly uint[] pad2;
    
    public IntPtr writer;
    
    public IntPtr custom_ptr;
    // map for extra information (only for lossy compression mode)
    
    public int extra_info_type;
    
    public IntPtr extra_info;
    
    public IntPtr stats;
    
    public UInt32 error_code;
    
    public IntPtr progress_hook;
    
    public IntPtr user_data;
    
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 13, ArraySubType = UnmanagedType.U4)]
    private readonly uint[] pad3;
    
    private readonly IntPtr memory_;
    
    private readonly IntPtr memory_argb_;
    
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
    private readonly uint[] pad4;
};


[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPAuxStats
{
    
    public int coded_size;
    
    public float PSNRY;
    
    public float PSNRU;
    
    public float PSNRV;
    
    public float PSNRALL;
    
    public float PSNRAlpha;
    
    public int block_count_intra4;
    
    public int block_count_intra16;
    
    public int block_count_skipped;
    
    public int header_bytes;
    
    public int mode_partition_0;
    
    public int residual_bytes_DC_segments0;
    
    public int residual_bytes_AC_segments0;
    
    public int residual_bytes_uv_segments0;
    
    public int residual_bytes_DC_segments1;
    
    public int residual_bytes_AC_segments1;
    
    public int residual_bytes_uv_segments1;
    
    public int residual_bytes_DC_segments2;
    
    public int residual_bytes_AC_segments2;
    
    public int residual_bytes_uv_segments2;
    
    public int residual_bytes_DC_segments3;
    
    public int residual_bytes_AC_segments3;
    
    public int residual_bytes_uv_segments3;
    
    public int segment_size_segments0;
    
    public int segment_size_segments1;
    
    public int segment_size_segments2;
    
    public int segment_size_segments3;
    
    public int segment_quant_segments0;
    
    public int segment_quant_segments1;
    
    public int segment_quant_segments2;
    
    public int segment_quant_segments3;
    
    public int segment_level_segments0;
    
    public int segment_level_segments1;
    
    public int segment_level_segments2;
    
    public int segment_level_segments3;
    
    public int alpha_data_size;
    
    public int layer_data_size;

    // lossless encoder statistics
    
    public Int32 lossless_features;
    
    public int histogram_bits;
    
    public int transform_bits;
    
    public int cache_bits;
    
    public int palette_size;
    
    public int lossless_size;
    
    public int lossless_hdr_size;
    
    public int lossless_data_size;
    
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
    private readonly uint[] pad;
};

[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPDecoderConfig
{
    
    public WebPBitstreamFeatures input;
    
    public WebPDecBuffer output;
    
    public WebPDecoderOptions options;
}


[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPDecBuffer
{
    
    public WEBP_CSP_MODE colorspace;
    
    public int width;
    
    public int height;
    
    public int is_external_memory;
    
    public RGBA_YUVA_Buffer u;
    
    private readonly UInt32 pad1;
    
    private readonly UInt32 pad2;
    
    private readonly UInt32 pad3;
    
    private readonly UInt32 pad4;
    
    public IntPtr private_memory;
}


[StructLayoutAttribute(LayoutKind.Explicit)]
internal struct RGBA_YUVA_Buffer
{
    [FieldOffsetAttribute(0)]
    public WebPRGBABuffer RGBA;

    [FieldOffsetAttribute(0)]
    public WebPYUVABuffer YUVA;
}

[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPYUVABuffer
{
    
    public IntPtr y;
    
    public IntPtr u;
    
    public IntPtr v;
    
    public IntPtr a;
    
    public int y_stride;
    
    public int u_stride;
    
    public int v_stride;
    
    public int a_stride;
    
    public UIntPtr y_size;
    
    public UIntPtr u_size;
    
    public UIntPtr v_size;
    
    public UIntPtr a_size;
}


[StructLayoutAttribute(LayoutKind.Sequential)]
internal struct WebPRGBABuffer
{
    
    public IntPtr rgba;
    
    public int stride;
    
    public UIntPtr size;
}


[StructLayout(LayoutKind.Sequential)]
public struct WebPDecoderOptions
{
    
    public int bypass_filtering;
    
    public int no_fancy_upsampling;
    
    public int use_cropping;
    
    public int crop_left;
    
    public int crop_top;
    
    public int crop_width;
    
    public int crop_height;
    
    public int use_scaling;
    
    public int scaled_width;
    
    public int scaled_height;
    
    public int use_threads;
    
    public int dithering_strength;
    
    public int flip;
    
    public int alpha_dithering_strength;
    
    private readonly UInt32 pad1;
    
    private readonly UInt32 pad2;
    
    private readonly UInt32 pad3;
    
    private readonly UInt32 pad4;
    
    private readonly UInt32 pad5;
};

