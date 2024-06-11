using System;
using UnityEngine;





public class Controlador_dados_sistema {

        public static Controlador_dados_sistema instancia;
        public static Controlador_dados_sistema Pegar_instancia(){ return instancia; }

        public static Controlador_dados_sistema Construir(){

            Controlador_dados_sistema controlador  = new Controlador_dados_sistema();

                        // *** 

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