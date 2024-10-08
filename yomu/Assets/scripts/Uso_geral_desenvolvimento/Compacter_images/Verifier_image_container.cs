using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Verifier_image_container {

        //mark
        // ** talvez de algum problema depois. O tempo de criacao tem algum problemas e pode ser que ele nao verifique imagens que mudaram


        public static bool Verify( string folder, string[] _locator ){


                Dictionary<string, string> dic = new Dictionary<string, string>();

                for( int index_locator = 0; index_locator < _locator.Length ; index_locator++ ){

                        string[] valores = _locator[ index_locator ].Split( "," );

                        string path = valores[ 0 ];
                        string time_creation = valores[ 1 ];
                        
                        dic.Add( path, time_creation );
                        continue;
  
                }

                FileInfo[] files_info = new FileInfo[ 10_000 ];
                int number_files_in_folder = Images_container_creator.Get_info_images( folder, files_info, 0 );

                // --- VERIFY IF THERE IS MORE OR LESS FILES
                if( number_files_in_folder != _locator.Length )
                    { 
                        Debug.Log( $"Tinha { _locator.Length } arquivos no locator e { number_files_in_folder } no folder" );
                        return true; 
                    }


                for( int files_info_index = 0 ; files_info_index < number_files_in_folder ; files_info_index++ ){


                        string path = files_info[ files_info_index ].FullName.Substring( folder.Length + 1 );
                        string time_creation = null;

                        // --- VERIFY IS TEH FILE IS NEW 
                        if( !!! ( dic.TryGetValue( path, out time_creation ) ) )
                            { 
                                Debug.Log( $"Tem arquivo novo: { path }" );
                                return true; 
                            }

                        // --- VERIFY IF THE FILE IS CHANGED
                        if( time_creation != files_info[ files_info_index ].CreationTime.ToString() )
                            { 
                                Debug.Log( $"arquivo { path } mudou" );
                                return true; 
                            }

                        continue;
                }

                Debug.Log("todos iguais");

                return false;


        }

}