using System;



public static class Files {



        // pastas só são criadas no save 
        // testei e já funciona corretamente
        // talvez possar ter o argumento para ver se pode ser com cache ou nao
        public static void Copiar_pasta_inteira(  string _local_para_salvar,  string _local_para_copiar ){

                                
                // Sempre assume que o folder nao foi criado
                System.IO.Directory.CreateDirectory( _local_para_salvar );

                // vem como path completo
                string[] folders = System.IO.Directory.GetDirectories( _local_para_copiar );

                for( int folder_id = 0 ; folder_id < folders.Length ; folder_id++ ){
                                                                        //   ta certo, vai pegar somente o nome do diretory
                    string folder_path_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( folders[ folder_id ] );
                    string folder_path_para_copiar = folders[ folder_id ] ;
                    Copiar_pasta_inteira( folder_path_para_salvar , folder_path_para_copiar );

                }
                // vem com o path completo
                string[] nomes_arquivos = System.IO.Directory.GetFiles( _local_para_copiar );

                for( int arquivo_id = 0 ; arquivo_id < nomes_arquivos.Length ; arquivo_id++ ){

                    
                    string path_arquivo_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( nomes_arquivos[ arquivo_id ] );
                    string path_arquivo_para_copiar =  nomes_arquivos[ arquivo_id ];
                    System.IO.File.Copy(  path_arquivo_para_copiar,  path_arquivo_para_salvar  );

                }

                return;

        }

        public static void Guarantee_exists_editor( string _path ){

                #if UNITY_EDITOR

                    if( !!!( System.IO.File.Exists( _path ) ) )
                        { throw new Exception( $"Nao tinha o arquivo { _path }" ); }

                #endif



        }



        public static void Change_files_extension_in_folder( string _folder_para_mudar_as_extensoes, string _nova_extensao ){

                throw new System.Exception( "ainda tem que testar" );

                if( System.IO.Directory.Exists( _folder_para_mudar_as_extensoes ) )
                        { throw new Exception($"O folder { _folder_para_mudar_as_extensoes } nao foi achado"); }


                // --- DADOS
                string[] folders = System.IO.Directory.GetDirectories( _folder_para_mudar_as_extensoes );
                string[] arquivos = System.IO.Directory.GetFiles( _folder_para_mudar_as_extensoes );


                // --- MUDA CADA ARQUIVO
                for( int arquivo_id = 0 ; arquivo_id < arquivos.Length ; arquivo_id++ ){

                        string path_arquivo_com_ext_antiga = arquivos[ arquivo_id ];
                        string path_arquivo_com_nova_extensao = System.IO.Path.ChangeExtension(  path_arquivo_com_ext_antiga,  _nova_extensao  );

                        if( path_arquivo_com_ext_antiga == path_arquivo_com_nova_extensao )
                            { continue; }
                        
                        System.IO.File.Move( path_arquivo_com_ext_antiga, path_arquivo_com_nova_extensao );

                        continue;

                }


                // --- VAI EM CADA FOLDER E APLICA A FUNCAO DENOVO
                for( int folder_id = 0 ; folder_id < folders.Length ; folder_id++ ){

                        //   ta certo, vai pegar somente o nome do diretory
                        string folder_path_para_mudar_as_extensoes = folders[ folder_id ];
                        Change_files_extension_in_folder( folder_path_para_mudar_as_extensoes , _nova_extensao );

                }

                
                return;

        }




}