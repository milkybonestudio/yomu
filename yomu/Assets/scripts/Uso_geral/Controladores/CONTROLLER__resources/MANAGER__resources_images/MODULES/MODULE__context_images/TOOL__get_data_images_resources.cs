using System;
using System.IO;
using UnityEngine;

public static class TOOL__get_data_images_resources {


            // ** somente editor
            public static byte[] webp_generico;

            // ** single
            public static byte[] Get_single_low_quality( RESOURCE__image _image ){ 

                if( Application.isEditor )
                    {

                        byte[] image = Get_single_generico_EDITOR( _image, "png" );
                    
                        if( webp_generico == null ){

                            // ** carregar

                            string path = System.IO.Path.Combine( Application.dataPath, "Resources", "Development", "Webp_default.webp" );
                            webp_generico = System.IO.File.ReadAllBytes( path );
                            CONTROLLER__errors.Verify( ( webp_generico == null ), "nao achou" );

                        }

                        Dimensions dimensions = PNG.Get_dimensions( image );
                        _image.width = dimensions.width;
                        _image.height = dimensions.height;
                        _image.data_size = image.Length;
                        _image.pointer_container = -1; // ** nao tem
                        _image.number_images = 1;

                        return webp_generico; 

                    }
                    else
                    { return Get_single_generico( _image, "webp" );   }

                

            }
            public static byte[] Get_single( RESOURCE__image _image ){ 


                byte[] png = Get_single_generico( _image, "png" );

                if( Application.isEditor )
                    {
                        Dimensions dimensions = PNG.Get_dimensions( png );
                        _image.width = dimensions.width;
                        _image.height = dimensions.height;
                        _image.data_size = png.Length;
                        _image.pointer_container = -1; // ** nao tem
                        _image.number_images = 1;

                        return webp_generico; 

                    }
                
                

                return png; 

            }



            private static byte[] Get_single_generico(  RESOURCE__image _image, string _extensao ){

                    // **   pensar da  seguinte forma: ( path sistema(C:\\users\\user...) ) || ( container( Devices, Characters, ...  ) ) || ( chave ( "\\Lily\\normal_clothes\\arms_1.png" ) )
                    // **   no editor path systema vai dado por Application.DataPath + "\\Resources"
                    // **   na build vai ser Application.DataPath + "\\Static_data"


                    if( Application.isEditor )
                        { return Get_single_generico_EDITOR( _image, _extensao ); }
                        else
                        { return Get_single_generico_BUILD( _image, _extensao ); }

            }




        
            private static byte[] Get_single_generico_EDITOR( RESOURCE__image _image, string _extensao ){

                    string path_arquivo = System.IO.Path.Combine( Application.dataPath, "Resources", _image.image_context.ToString(), _image.main_folder, ( _image.path_locator + "." + _extensao  ) ) ;

                    try{ return File.ReadAllBytes( path_arquivo ); } catch( System.Exception e ){ Console.LogError( $"Dont find the image { path_arquivo }" ); throw e; }
                    
                    return null;

            }


            private static byte[] Get_single_generico_BUILD( RESOURCE__image _image, string _extensao ){

                    CONTROLLER__game_current_state.Get_instance().Verify_plataform();
                    return null;
                                                  
            }


            public static byte[][] Get_multiples_data( string _main_folder, string _path, int _number_images ){

                    return null;

            }


            // ** multiples

            public static byte[] Get_multiples_low_quality(  RESOURCE__image _image ){ return Get_single_generico( _image, "webp" );  }
            public static byte[] Get_multiples( RESOURCE__image _image ){ return Get_single_generico( _image, "png" ); }

            public static byte[] Get_multiples_low_quality_EDITOR( RESOURCE__image _image ){ return Get_single_generico( _image, "png" ); }
            public static byte[] Get_multiples_EDITOR( RESOURCE__image _image ){ return Get_single_generico( _image, "png" ); }





}