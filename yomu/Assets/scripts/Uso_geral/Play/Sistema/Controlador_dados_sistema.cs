using System;
using UnityEngine;





public class Controlador_dados_sistema {

        public static Controlador_dados_sistema instancia;
        public static Controlador_dados_sistema Pegar_instancia(){ return instancia; }

        public static Controlador_dados_sistema Construir( int _save ){

            Controlador_dados_sistema controlador  = new Controlador_dados_sistema();

                path_save = Paths_gerais.Pegar_path_folder_dados_save( _save );
                path_folder_dados_personagens_morte = path_save + "/Morte" ;

                path_dados_sistema = path_save + "/Dados_programa/dados_programa.dat";
                path_dados_personagens =  path_save + "/Personagens" ;
                path_dados_cidades =  path_save + "/Cidades" ;
                path_dados_plots =  path_save + "/Plots" ;


            instancia = controlador; 
            return controlador;

        }


        public string path_save;
        public string path_dados_personagens;
        public string path_dados_cidades;
        public string path_dados_plots;
        public string path_dados_sistema;
        public string path_dados_player;
        public string path_folder_dados_personagens_morte;



}