using System;
using System.IO;
using UnityEngine;




public static class TOOL__get_data_images_resources {


            public static byte[][] webps;

            // ** single
            public static byte[] Get_single_low_quality( RESOURCE__image _image ){ 

                if( Application.isEditor )
                    { return Get_single_low_quality_EDITOR( _image ); }
                    else
                    { return Get_single_low_quality_BUILD( _image ); }

            }

            // ** somente editor


            public static string path_default = System.IO.Path.Combine( Application.dataPath, "Resources", "Development", "Webps_default\\" );

            private static byte[] Get_single_low_quality_EDITOR( RESOURCE__image _image ){

                    byte[] png = Get_single_generico_EDITOR( _image );
                
                    if( webps == null )
                        { Start_webps(); }


                    Dimensions dimensions = PNG.Get_dimensions( png );
                    _image.width = dimensions.width;
                    _image.height = dimensions.height;
                    _image.data_size = png.Length;
                    _image.pointer_container = -1; // ** nao tem
                    _image.number_images = 1;

                    CONTROLLER__errors.Verify( ( dimensions.width > 2_000 || dimensions.height > 2_000 ), $"Tried to get the low quality for the image{ _image.name }" );

                    byte[] webp = Get_web_EDITOR( dimensions );
                    Console.Log( $"webp of the image { _image.name }: png length: { png.Length } and webp length: { webp.Length }" );

                    return webp; 

            }

            private static void Start_webps(){

                Webp_size[] sizes = ( Webp_size[] ) Enum.GetValues( typeof( Webp_size ) );

                webps = new byte[ sizes.Length ][];

            } 


            private static int i;

            private static byte[] Get_webp( Webp_size _size ){

                Console.Log( "vai pegar webp: " + _size );

                // --- TIME SIMULATION 

                    for( int n = 0 ; n < 200_000 ; n++ ){

                        i += 5;
                        if( ( i % 4570 ) == 3500 )
                            { i = 27; }

                    }

                    

                if( webps[ ( int ) _size ] != null )
                    { return webps[ ( int ) _size ]; }

                string path = ( path_default + _size.ToString() + ".webp" ) ;
                byte[] webp = null;

                try { webp = System.IO.File.ReadAllBytes( path ); } catch( Exception ){ CONTROLLER__errors.Throw( $"Could not get the webp_default in the path { path }" ); }

                webps[ ( int ) _size ] = webp;
                return webp;

            }





            private static byte[] Get_web_EDITOR( Dimensions _dimensions ){


                    if( _dimensions.width <= 25 )
                        {
                            if( _dimensions.height <= 25 )
                                { return Get_webp( Webp_size.webp_25_25 ) ; }

                            if( _dimensions.height <= 50 )
                                { return Get_webp( Webp_size.webp_25_50 ) ; }
                        }


                    if( _dimensions.width <= 50 )
                        {
                            if( _dimensions.height <= 25 )
                                { return Get_webp( Webp_size.webp_50_25 ) ; }

                            if( _dimensions.height <= 50 )
                                { return Get_webp( Webp_size.webp_50_50 ) ; }

                            if( _dimensions.height <= 75 )
                                { return Get_webp( Webp_size.webp_50_75 ) ; }
                        }


                    if( _dimensions.width <= 75 )
                        {
                            if( _dimensions.height <= 50 )
                                { return Get_webp( Webp_size.webp_75_50 ) ; }

                            if( _dimensions.height <= 75 )
                                { return Get_webp( Webp_size.webp_75_75 ) ; }

                            if( _dimensions.height <= 100 )
                                { return Get_webp( Webp_size.webp_75_100 ) ; }

                            if( _dimensions.height <= 150 )
                                { return Get_webp( Webp_size.webp_75_150 ) ; }
                        }
                    


                    if( _dimensions.width <= 100 )
                        {
                            if( _dimensions.height <= 100 )
                                { return Get_webp( Webp_size.webp_100_100 ) ; }
                        }
                    

                    if( _dimensions.width <= 150 )
                        {
                            if( _dimensions.height <= 150 )
                                { return Get_webp( Webp_size.webp_150_150 ) ; }
                        }
                    

                    if( _dimensions.width <= 250 )
                        {
                            if( _dimensions.height <= 250 )
                                { return Get_webp( Webp_size.webp_250_250 ) ; }
                            if( _dimensions.height <= 500 )
                                { return Get_webp( Webp_size.webp_250_350 ) ; }
                            if( _dimensions.height <= 500 )
                                { return Get_webp( Webp_size.webp_250_500 ) ; }
                            if( _dimensions.height <= 600 )
                                { return Get_webp( Webp_size.webp_250_600 ) ; }
                        }


                    if( _dimensions.width <= 300 )
                        {
                            if( _dimensions.height <= 500 )
                                { return Get_webp( Webp_size.webp_300_500 ) ; }
                            if( _dimensions.height <= 600 )
                                { return Get_webp( Webp_size.webp_300_600 ) ; }
                            if( _dimensions.height <= 700 )
                                { return Get_webp( Webp_size.webp_300_700 ) ; }

                        }


                    if( _dimensions.width <= 400 )
                        {
                            if( _dimensions.height <= 750 )
                                { return Get_webp( Webp_size.webp_400_750 ); }

                        }

                    if( _dimensions.width <= 500 )
                        {
                            if( _dimensions.height <= 250 )
                                { return Get_webp( Webp_size.webp_500_250 ); }

                            if( _dimensions.height <= 500 )
                                { return Get_webp( Webp_size.webp_500_500 ); }

                            if( _dimensions.height <= 750 )
                                { return Get_webp( Webp_size.webp_500_750 ); }

                        }
                    

                    if( _dimensions.width <= 750 )
                        {
                            if( _dimensions.height <= 500 )
                                { return Get_webp( Webp_size.webp_750_500 ); }

                            if( _dimensions.height <= 750 )
                                { return Get_webp( Webp_size.webp_750_750 ); }

                            if( _dimensions.height <= 1000 )
                                { return Get_webp( Webp_size.webp_750_1000 ); }

                        }

                    if( _dimensions.width <= 1000 )
                        {
                            if( _dimensions.height <= 500 )
                                { return Get_webp( Webp_size.webp_1000_500 ); }

                            if( _dimensions.height <= 750 )
                                { return Get_webp( Webp_size.webp_1000_750 ); }

                            if( _dimensions.height <= 1000 )
                                { return Get_webp( Webp_size.webp_1000_1000 ); }

                        }


                    if( _dimensions.width <= 2_000 )
                        {
                            if( _dimensions.height <= 1000 )
                                { return Get_webp( Webp_size.webp_2000_1000 ); }
                            if( _dimensions.height <= 2000 )
                                { return Get_webp( Webp_size.webp_2000_2000 ); }
                        }

                    
                    CONTROLLER__errors.Throw( $"Tamanho naoa aceito: width { _dimensions.width } and height { _dimensions.height }" );
                    return null;

                    

            }


            private static byte[] Get_single_low_quality_BUILD( RESOURCE__image _image ){

                    //mark 
                    // ** fazer
                    return null;

            }




            public static byte[] Get_single( RESOURCE__image _image ){ 

                Console.Log( "veio aqui" );

                    // ** nao existe webp no editor além do default, nao tem o porque 

                    // **   no editor path systema vai dado por Application.DataPath + "\\Resources"
                    // **   na build vai ser Application.DataPath + "\\Static_data"

                    if( Application.isEditor )
                        { return Get_single_generico_EDITOR( _image ); }
                        else
                        { return Get_single_generico_BUILD( _image ); }
                
            }

        
            private static byte[] Get_single_generico_EDITOR( RESOURCE__image _image ){

                    string path_arquivo = System.IO.Path.Combine( Application.dataPath, "Resources", _image.image_context.ToString(), _image.image_key + ".png" );

                    Console.Log( "Veio Get_single_generico_EDITOR()" );
                    Console.Log( "path: " + path_arquivo );
                    byte[] png = null;

                    try { png = File.ReadAllBytes( path_arquivo ); } catch( System.Exception e ){ CONTROLLER__errors.Throw( $"Image in the path { path_arquivo } was not found" ); }

                
                    CONTROLLER__errors.Verify( !!!( PNG.Verify_is_png( png ) ), "Nao era png UOU" );

                    
                    return png;

            }


            private static byte[] Get_single_generico_BUILD( RESOURCE__image _image ){

                    CONTROLLER__game_current_state.Get_instance().Verify_plataform();
                    return null;
                                                  
            }


            public static byte[][] Get_multiples_data( string _main_folder, string _path, int _number_images ){

                    return null;

            }


            // ** multiples

            public static byte[] Get_multiples_low_quality(  RESOURCE__image _image ){ return null;  }
            public static byte[] Get_multiples( RESOURCE__image _image ){ return null; }

            public static byte[] Get_multiples_low_quality_EDITOR( RESOURCE__image _image ){ return null; }
            public static byte[] Get_multiples_EDITOR( RESOURCE__image _image ){ return null; }





}