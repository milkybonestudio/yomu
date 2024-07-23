using UnityEngine;

public static class Paths_development {

        public static string Pegar_path_folder_dados_producao(){

                return ( System.IO.Path.Combine( Application.dataPath, "Editor/Dados_producao" ) );

        }

}