using System;
using UnityEngine;





public class Controlador_dados_sistema {

        public static Controlador_dados_sistema instancia;
        public static Controlador_dados_sistema Pegar_instancia(){ return instancia; }

        public static Controlador_dados_sistema Construir(  Dados_sistema_estado_atual _dados_sistema_estado_atual , int _save  ){

            Controlador_dados_sistema controlador  = new Controlador_dados_sistema();

                Paths_sistema.path_save = Paths_gerais.Pegar_path_folder_dados_save( _save );
                string path_save = Paths_sistema.path_save;
                
                Paths_sistema.path_folder_dados_personagens_morte = path_save + "/Morte" ;

                Paths_sistema.path_dados_sistema = path_save + "/Dados_programa/dados_programa.dat";
                Paths_sistema.path_dados_personagens =  path_save + "/Personagens" ;
                Paths_sistema.path_dados_cidades =  path_save + "/Cidades" ;
                Paths_sistema.path_dados_plots =  path_save + "/Plots" ;
                Paths_sistema.path_dados_gerais_usuario = Application.persistentDataPath;


            instancia = controlador; 
            return controlador;

        }


        public Dados_sistema_estado_atual Compilar_dados(){

            Dados_sistema_estado_atual retorno = new Dados_sistema_estado_atual();

                retorno.personagens_pentendes_para_adicionar = Controlador_personagens.Pegar_instancia().personagens_pentendes_para_adicionar;
                retorno.personagens_pentendes_para_adicionar_local = Controlador_personagens.Pegar_instancia().personagens_pentendes_para_adicionar_local;
                retorno.personagens_pentendes_para_adicionar_tempo = Controlador_personagens.Pegar_instancia().personagens_pentendes_para_adicionar_tempo;

            return retorno;



        }
		





}