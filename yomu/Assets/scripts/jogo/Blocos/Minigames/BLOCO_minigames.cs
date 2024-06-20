using System;
using UnityEngine;



public class BLOCO_minigames {


        public static BLOCO_minigames instancia;
        public static BLOCO_minigames Pegar_instancia(){ return instancia; }


        public GameObject container_minigame;

        public static BLOCO_minigames Iniciar_bloco_minigames(){ 
                
                if( instancia != null )
                        { throw new Exception( "tentou iniciar o bloco: <color=red>CONECTOR</color> mas a instancia nao estava null" ); }
                
                instancia = new BLOCO_minigames(); 
                instancia.Iniciar();
                return instancia;
                
        }



        public void Iniciar(){

                Minigame_START dados = Dados_blocos.minigame_START;

                if( dados == null )
                        { throw new Exception( "nao veio dados para iniciar minigame" ); }

                // ** fazer

                return;


        }

        public static void Finalizar(){

                // ** deletar os controladores

                instancia = null;
                return;

        }


        public void Update(){}

        public Action Lidar_retorno;
        

}
