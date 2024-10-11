


public static class TOOL__get_data_images_resources {


            public static byte[] Get( MODULE__context_images _module, RESOURCE__image _image ){



                    //     // **   pensar da  seguinte forma: ( path sistema(C:\\users\\user...) ) || ( container( Devices, Characters, ...  ) ) || ( chave ( "\\Lily\\normal_clothes\\arms_1.png" ) )
                    // // **   no editor path systema vai dado por Application.DataPath + "\\Resources"
                    // // **   na build vai ser Application.DataPath + "\\Static_data"

                    // #if UNITY_EDITOR

                    //     string path_arquivo = Path.Combine( Application.dataPath, "Resources", _module.context_folder, ( _image.single_image.image_path + "." + _image.type.ToString()) ) ;

                    //     try{ return System.IO.File.ReadAllBytes( path_arquivo ); } catch( Exception e ){ Debug.LogError( $"Dont find the image { path_arquivo }" ); throw e; }

                    
                    // #elif !!!( UNITY_EDITOR ) && ( UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX)
                        
                        
                    //     thorw new Exception( "Ainda tem que fazer" );


                    //     // int _initial_pointer = _image.single_image.image_localizers.initial_pointer;
                    //     // int _length = _image.single_image.image_ocalizers.length;


                    //     FileStream file_stream = null;
                        
                    //     if( !!!( files_streams.TryGetValue( _path, out file_stream ) ) )
                    //         { files_streams.Add( _path, FILE_STREAM.Criar_stream( _path, buffer_cache )); }


                    //     file_stream.Seek( _initial_pointer, SeekOrigin.Begin );

                    //     byte[] image = new byte[ _length ];

                    //     file_stream.Read( image, 0, _length );
            
                    //     return image;

                    
                    // #endif


                    return null;

            }





}