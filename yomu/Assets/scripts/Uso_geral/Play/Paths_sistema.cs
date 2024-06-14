using UnityEngine;


public static class Paths_sistema {


        public static void Colocar_save( int _save ){

                path_save = Paths_gerais.Pegar_path_folder_dados_save( _save );
                path_folder_dados_personagens_morte = path_save + "/Morte" ;

                path_dados_sistema = path_save + "/Dados_programa/dados_programa.dat";
                path_dados_personagens =  path_save + "/Personagens" ;
                path_dados_cidades =  path_save + "/Cidades" ;
                path_dados_plots =  path_save + "/Plots" ;
                path_dados_gerais_usuario = Application.persistentDataPath;
                path_stack_1 = Application.persistentDataPath + "/stack_1.dat";
                path_stack_2 = Application.persistentDataPath + "/stack_2.dat";

                return;

        }

        public static string path_save;
        public static string path_dados_personagens;
        public static string path_dados_cidades;
        public static string path_dados_plots;
        public static string path_dados_sistema;
        public static string path_dados_player;
        public static string path_folder_dados_personagens_morte;

        public static string path_stack_1;
        public static string path_stack_2;

        public static string path_dados_gerais_usuario; // perdatapath

}