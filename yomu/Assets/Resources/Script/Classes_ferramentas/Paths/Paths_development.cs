using UnityEngine;
using System.IO;

public static class Paths_development {

        static Paths_development(){ 

            
                // --- SIMULACOES 
                Paths_development.path_folder__development_folder_for_simulations = Path.Combine( Application.dataPath, "Editor", "FOLDER_PARA_SIMULAR" );

                    Paths_development.path_folder__development_folder_for_simulations_DINAMIC_DATA = Path.Combine( Paths_development.path_folder__development_folder_for_simulations, "DINAMIC_DATA");
                    Paths_development.path_folder__development_folder_for_simulations_STATIC_CONTAINERS_CACHE = Path.Combine( Paths_development.path_folder__development_folder_for_simulations, "STATIC_CONTAINERS_CACHE");
                    Paths_development.path_folder__development_folder_for_simulations_STATIC_DATA = Path.Combine( Paths_development.path_folder__development_folder_for_simulations, "STATIC_DATA");



                // ** isso vai fora dos arquivos da unity
                Paths_development.path_folder__development_data = System.IO.Directory.GetParent( System.IO.Directory.GetCurrentDirectory() ).FullName;

                    // --- IMAGENS 
                    Paths_development.path_folder__imagens_DEVELOPMENT = Path.Combine( Paths_development.path_folder__development_data, "Imagens" );

                            Paths_development.path_folder__images_characters_DEVELOPMENT = Path.Combine( Paths_development.path_folder__imagens_DEVELOPMENT, "Imagens" );
                            Paths_development.path_folder_imagens_pontos_DEVELOPMENT = Path.Combine( Paths_development.path_folder__imagens_DEVELOPMENT, "Pontos" );

                return;
                
        }
         

        // ** simulations
        public static string path_folder__development_folder_for_simulations;
            
            public static string path_folder__development_folder_for_simulations_STATIC_DATA;
            public static string path_folder__development_folder_for_simulations_DINAMIC_DATA; // 

            public static string path_folder__development_folder_for_simulations_STATIC_CONTAINERS_CACHE;


        // --- DEVELOPMENT

            public static string path_folder__development_data; // ** folder raiz

                // ** imagens
                public static string path_folder__imagens_DEVELOPMENT; // ** raiz
                        public static string path_folder__images_characters_DEVELOPMENT;


                public static string path_folder_imagens_pontos_DEVELOPMENT;
                






        public static string Pegar_path_folder_dados_producao(){

                return ( System.IO.Path.Combine( Application.dataPath, "Editor/Dados_producao" ) );

        }

}