using System;
using UnityEngine;





public class Controlador_dados_sistema {

        public static Controlador_dados_sistema instancia;
        public static Controlador_dados_sistema Pegar_instancia(){ return instancia; }

        public Gerenciador_dados_sistema_estado_atual gerenciador_dados_sistema_estado_atual;
        public Gerenciador_player gerenciador_player;

        public Gerenciador_save_dados_sistema gerenciador_save;

        public static Controlador_dados_sistema Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){

            Controlador_dados_sistema controlador  = new Controlador_dados_sistema();

                    controlador.gerenciador_dados_sistema_estado_atual = new Gerenciador_dados_sistema_estado_atual( controlador );
                    controlador.gerenciador_player = new Gerenciador_player( _dados_sistema_estado_atual );
                    controlador.gerenciador_save = new Gerenciador_save_dados_sistema( controlador );


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


        public Dados_para_salvar Pegar_dados_para_salvar( Modo_save _modo ){

                // ** fazer 
                return null;

        }
		





}