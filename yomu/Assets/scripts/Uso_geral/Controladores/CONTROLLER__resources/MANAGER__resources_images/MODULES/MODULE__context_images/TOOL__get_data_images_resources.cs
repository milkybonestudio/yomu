using System;
using System.IO;
using UnityEngine;

public static class TOOL__get_data_images_resources {



            // ** single
            public static byte[] Get_single_low_quality( RESOURCE__image _image ){ 

                if( Application.isEditor )
                    { return Get_single_low_quality_EDITOR( _image ); }
                    else
                    { return Get_single_low_quality_BUILD( _image ); }

            }

            // ** somente editor
            public static bool webp_start;



            private static byte[] Get_single_low_quality_EDITOR( RESOURCE__image _image ){

                    byte[] png = Get_single_generico_EDITOR( _image );
                
                    if( !!!( webp_start ) )
                        {
                            // ** carregar
                            try
                                {
                                    string path_default = System.IO.Path.Combine( Application.dataPath, "Resources", "Development", "Webps_default\\" );


                                    Console.Log( path_default );
                                    Console.Log( path_default + "2000_2000.webp" );
                                    Console.Log( System.IO.File.Exists( path_default + "2000_2000.webp" ) );

                                    // ** ainda tem que pegar mais 
                                    // ** lily tinha 225 x 580
                                    // ** isso jogou ela para o 1k x 1k
                                    webp_generico_2000_2000 = System.IO.File.ReadAllBytes( path_default + "2000_2000.webp" );
                                    webp_generico_2000_1000 = System.IO.File.ReadAllBytes( path_default + "2000_1000.webp" );
                                    webp_generico_1000_1000 = System.IO.File.ReadAllBytes( path_default + "1000_1000.webp" );
                                    webp_generico_1000_500 = System.IO.File.ReadAllBytes( path_default + "1000_500.webp" );
                                    webp_generico_500_500 = System.IO.File.ReadAllBytes( path_default + "500_500.webp" );
                                    webp_generico_500_250 = System.IO.File.ReadAllBytes( path_default + "500_250.webp" );
                                    webp_generico_250_250 = System.IO.File.ReadAllBytes( path_default + "250_250.webp" );
                                    webp_generico_150_150 = System.IO.File.ReadAllBytes( path_default + "150_150.webp" );
                                    webp_generico_100_100 = System.IO.File.ReadAllBytes( path_default + "100_100.webp" );
                                    
                                }
                                catch( Exception )
                                {
                                    CONTROLLER__errors.Throw( "Could not get the images webps defaults" );
                                }
                            
                        }

                    

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

            // ** width_height
            public static byte[] webp_generico_2000_2000;
            public static byte[] webp_generico_2000_1000;
            public static byte[] webp_generico_1000_1000;
            public static byte[] webp_generico_1000_500;

            public static byte[] webp_generico_500_500;
            public static byte[] webp_generico_500_250;
            public static byte[] webp_generico_250_250;
            public static byte[] webp_generico_150_150;
            public static byte[] webp_generico_100_100;



            private static byte[] Get_web_EDITOR( Dimensions _dimensions ){


                    if( _dimensions.height <= 100 )
                        {
                            if( _dimensions.height <= 100 )
                                { return webp_generico_100_100; }
                        }
                    

                    if( _dimensions.height <= 150 )
                        {
                            if( _dimensions.height <= 150 )
                                { return webp_generico_150_150; }
                        }
                    
                    if( _dimensions.height <= 250 )
                        {
                            if( _dimensions.height <= 250 )
                                { return webp_generico_250_250; }
                            if( _dimensions.height <= 500 )
                                { return webp_generico_500_250; }
                        }

                    if( _dimensions.height <= 500 )
                        {
                            if( _dimensions.height <= 500 )
                                { return webp_generico_500_500; }
                            if( _dimensions.height <= 1_000 )
                                { return webp_generico_1000_500; }
                        }

                    if( _dimensions.height <= 1_000 )
                        {
                            if( _dimensions.height <= 1_000 )
                                { return webp_generico_1000_1000; }
                            if( _dimensions.height <= 2_000 )
                                { return webp_generico_2000_1000; }
                        }
                    

                    if( _dimensions.height <= 2_000 )
                        {
                            if( _dimensions.height <= 2_000 )
                                { return webp_generico_2000_2000; }
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