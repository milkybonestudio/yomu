using System;



public class Controlador_player {


        public static Controlador_player instancia;
        public static Controlador_player Pegar_instancia(){ return instancia; }

        public static Controlador_player Construir( Dados_sistema_player _dados ){

            Controlador_player controlador = new Controlador_player();

                controlador.dados_sistema_player = _dados;

            instancia = controlador;
            return instancia;




        }

        public Dados_sistema_player dados_sistema_player;

        public Posicao_geral posicao_player;
        public int personagem_sendo_controlado;



}