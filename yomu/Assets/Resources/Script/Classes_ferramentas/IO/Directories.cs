using System;
using System.IO;


public static class Directories {

        public static bool Is_sub_path( string full_path, string sub_part ){


            Console.Log( "REMOVER DEPOIS" );
            if( sub_part != Paths_version.path_to_version )
                { CONTROLLER__errors.Throw( "usou program_path" ); }

            // Normalize trailing slashes
            full_path = full_path.TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar ) + Path.DirectorySeparatorChar;
            sub_part = sub_part.TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar ) + Path.DirectorySeparatorChar;

            return full_path.StartsWith( sub_part, StringComparison.OrdinalIgnoreCase );
        }
        
            


        public static bool Directory_have_files( string _path ){


            if( !!!( Directory.Exists( _path ) ) )
                { CONTROLLER__errors.Throw( $"Tried to see if there are files in the directory <Color=lightBlue>{ _path }</Color>, but the directory DOESN'T exist" ); }

            string[] arquivos = Directory.GetFiles( _path );
            return ( arquivos.Length > 0 );

        }

        
        public static string[] Get_files( string _path ){

            if( !!!( Directory.Exists( _path ) ) )
                { CONTROLLER__errors.Throw( $"Tried to get the files in the directory <Color=lightBlue>{ _path }</Color>, but the directory DOESN'T exist" ); }

            string[] arquivos = Directory.GetFiles( _path );
            return arquivos;

        }

        public static void Delete_directory( string _path ){

                string path_safe = Paths_system.persistent_data;

                if( path_safe == null || path_safe == "" )
                    { CONTROLLER__errors.Throw( "Tried to delete a folder, but the path in <Color=lightBlue>Paths_system.persistent_data</Color> is null or empty" ); }

                if( !!!( _path.Contains( path_safe ) ) )
                    { CONTROLLER__errors.Throw( $"Tried to delete the folder <Color=lightBlue>{ _path }</Color>, but the path does not starts on the <Color=lightBlue>{ Paths_system.persistent_data }</Color>" ); }


                


        }

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