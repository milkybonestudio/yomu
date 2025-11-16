using UnityEngine;
using System.IO;

public static class Paths_development {

        static Paths_development(){ 

            
                // --- SIMULACOES 
                folder_for_simulations = Path.Combine( Application.dataPath, "Editor", "FOLDER_PARA_SIMULAR" );

                    folder_for_simulations_DINAMIC_DATA = Path.Combine( folder_for_simulations, "DINAMIC_DATA");
                    folder_for_simulations_STATIC_CONTAINERS_CACHE = Path.Combine( folder_for_simulations, "STATIC_CONTAINERS_CACHE");
                    folder_for_simulations_STATIC_DATA = Path.Combine( folder_for_simulations, "STATIC_DATA");



                // ** isso vai fora dos arquivos da unity
                data = System.IO.Directory.GetParent( System.IO.Directory.GetCurrentDirectory() ).FullName;

                    // --- IMAGENS 
                    path_folder__imagens_DEVELOPMENT = Path.Combine( data, "Imagens" );

                            path_folder__images_characters_DEVELOPMENT = Path.Combine( path_folder__imagens_DEVELOPMENT, "Imagens" );
                            path_folder_imagens_pontos_DEVELOPMENT = Path.Combine( path_folder__imagens_DEVELOPMENT, "Pontos" );

                return;
                
        }
         

        // ** simulations
        public static string folder_for_simulations;
            
            public static string folder_for_simulations_STATIC_DATA;
            public static string folder_for_simulations_DINAMIC_DATA;

            public static string folder_for_simulations_STATIC_CONTAINERS_CACHE;


        // --- DEVELOPMENT

            public static string data; // ** folder raiz

                // ** imagens
                public static string path_folder__imagens_DEVELOPMENT; // ** raiz
                        public static string path_folder__images_characters_DEVELOPMENT;


                public static string path_folder_imagens_pontos_DEVELOPMENT;
                






        public static string Pegar_path_folder_dados_producao(){

            return ( System.IO.Path.Combine( Application.dataPath, "Editor/Dados_producao" ) );

        }

}