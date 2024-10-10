using System.IO;

public static class New_game_constructor {


        public static void Construct( int _save ){

                throw new System.Exception( "tem que testar" );
                
                string path_folder_save = Path.Combine( Paths_system.path_folder__saves, $"Save_{ _save.ToString() }" );
                string path_folder_save_DEATH = Path.Combine( path_folder_save, "Death" );

                if( Directory.GetFiles( path_folder_save ).Length != 0 || Directory.GetDirectories( path_folder_save ).Length != 0 )
                    { CONTROLLER__errors.Throw( $"Tentou colocar criou um save no slot { _save.ToString() } mas tinha arquivos dentro" ); }
                                
                string path_folder_save_default = Paths_system.path_folder__save_default;
                

                // --- COPIA OS DADOS
                Files.Copiar_pasta_inteira( _local_para_salvar: path_folder_save, _local_para_copiar : path_folder_save_default );
                Files.Copiar_pasta_inteira( _local_para_salvar: path_folder_save_DEATH, _local_para_copiar : path_folder_save_default );

                return;


        }




}