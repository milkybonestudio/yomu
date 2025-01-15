using System;
using System.IO;
using UnityEngine;



public static class Paths_system {


        // ** ver depois:

        public static string path_resources_structures_container = "Containers/Structures";
        public static string path_resources_complex_structures_container = "Tela/Container_structures";
        

        
        // --- FOLDERS PRINCIPAIS

            public static string path_folder__static_data; // images container, scripts etc in the game folder in build
            public static string path_folder__dinamic_data; // saves and user data etc in the persistent data folder in build


        // --- DADOS ESTATICOS

            public static string path_folder__images_containers;
            public static string path_folder__dlls; // ** nao vale a pena ter 1 dll para cada coisa, isso so vai ser usado na build para mover as dlls. Se elas nao ficarem na pasta managed as dlls só vão carregar oque precisarem + metadados
            public static string path_folder__save_default;


            public static string path_folder__prefabs; // ** por hora vai ser usado para pegar os prefabs no resouces.Load



        // --- DADOS DINAMICOS
    
            // --- USER DATA
                public static string path_folder__user_data;

                    public static string path_arquivo_resumo_persona_usuario;
                    public static string path_arquivo_configuracoes;
                    public static string path_arquivo_dados_menu_E_login_dados;


            // --- SYSTEM DATA

                public static string path_folder__system;

                    public static string path_file__complete_use__system_data;
                    public static string path_file__complete_use__player_data;
                    public static string path_arquivo__stack;

            // --- SAVES DATA

                public static string path_folder__saves;

                    public static string path_file__saves_information; // ** cration time, version and stuff



            // --- QUANDO FOR INICIAR O JOGO

                public static string path_folder__save;
                public static string path_folder__save_DEATH;

                        // ** ir adicionando conforme for precisando

                        // --- POSITIONS

                        public static string path_file__points;
                        public static string path_file__points_locator;

    

        // --- DEVICES
        // ** talvez depois mudar para o formato compactado e usar strings para pegar as imagens no locator

        public static string path_folder__imagens_devices;
        public static string path_folder__imagens_dispositivos_reutilizaveis;

        
        

        public static void Colocar_save( int _save ){


                // --- PEGA FOLDERS PRINCIPAIS

                path_folder__save = System.IO.Path.Combine( path_folder__saves ,  $"save_{ _save.ToString() }" );
                path_folder__save_DEATH = System.IO.Path.Combine( path_folder__save,  "Death" );

                path_file__complete_use__system_data = System.IO.Path.Combine( path_folder__save,  "System_data.dat" ); 
                path_file__complete_use__player_data = System.IO.Path.Combine( path_folder__save,  "Player_data.dat" ); 
            
                return;

        }

        

        
        // public static string Get_path_folder__images_container_type( Images_container_type _type )
        //     { return Path.Combine( path_folder__images_containers, _type.ToString() ); }


        // public static string Get_path_folder__entities_type( Tipo_entidade _entidade )
        //     { return Path.Combine( path_folder__save, _entidade.ToString() ); }


        // public static string Get_file_path__entity( Tipo_entidade _entidade,  string _nome_entidade )
        //     { return Path.Combine( Get_path_folder__entities_type( _entidade ), _nome_entidade ); }


        public static string Pegar_path_imagem_save( int _numero_save ){

                if( _numero_save > 4 )
                        { throw new Exception( $"tentou carregar o save { _numero_save }" ); }

                return System.IO.Path.Combine( Application.persistentDataPath, $"save_{ _numero_save.ToString() }", "imagem_save_slot.png" );


        }


}