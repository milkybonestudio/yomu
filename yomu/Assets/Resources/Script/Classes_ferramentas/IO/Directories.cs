using System;


public static class Directories {

        public static void Guarantee_exists_editor( string _path ){

                
                #if UNITY_EDITOR

                    if( !!!( System.IO.Directory.Exists( _path ) ) )
                        { throw new Exception( $"Nao tinha o folder { _path }" ); }

                #endif


        }



        public static void _Copiar_pasta_inteira(  string _local_para_salvar, bool _delete_destination_folder_original_content, bool _need_to_be_new_folder, string _local_para_copiar ){

                bool folder_already_exist = System.IO.Directory.Exists( _local_para_salvar );


                if( _need_to_be_new_folder && folder_already_exist )
                    { throw new System.Exception( $"Folder in the path { _local_para_salvar } already exists" ); }

                

                // --- DELETE IF NEED 
                if( _delete_destination_folder_original_content && folder_already_exist )
                    { 
                        System.IO.Directory.Delete( _local_para_salvar ); 
                        System.IO.Directory.CreateDirectory( _local_para_salvar );
                    }
                    
                                
                // --- so passar




                // vem como path completo
                string[] folders = System.IO.Directory.GetDirectories( _local_para_copiar );

                for( int folder_id = 0 ; folder_id < folders.Length ; folder_id++ ){
                                                                        //   ta certo, vai pegar somente o nome do diretory
                    string folder_path_para_salvar =  System.IO.Path.Combine( _local_para_salvar, System.IO.Path.GetFileName( folders[ folder_id ] ) );
                    string folder_path_para_copiar = folders[ folder_id ] ;
                    _Copiar_pasta_inteira( folder_path_para_salvar , _delete_destination_folder_original_content, _need_to_be_new_folder, folder_path_para_copiar );

                }
                /// vem com o path completo
                string[] nomes_arquivos = System.IO.Directory.GetFiles( _local_para_copiar );

                for( int arquivo_id = 0 ; arquivo_id < nomes_arquivos.Length ; arquivo_id++ ){

                    
                    string path_arquivo_para_salvar = System.IO.Path.Combine( _local_para_salvar, System.IO.Path.GetFileName( nomes_arquivos[ arquivo_id ] ) );
                    string path_arquivo_para_copiar =  nomes_arquivos[ arquivo_id ];
                    System.IO.File.Copy(  path_arquivo_para_copiar,  path_arquivo_para_salvar  );

                }

                return;

        }



}