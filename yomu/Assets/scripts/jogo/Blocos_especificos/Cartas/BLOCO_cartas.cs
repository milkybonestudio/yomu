using System;
using UnityEngine;



public class BLOCO_cartas {

        public static BLOCO_cartas instancia;
        public static BLOCO_cartas Pegar_instancia(){ return instancia; }



        public static BLOCO_cartas Iniciar_bloco_cartas(){ 

                if( instancia != null )
                        { throw new Exception( "tentou iniciar o bloco: <color=red>CARTAS</color> mas a instancia nao estava null" ); }
                
                instancia = new BLOCO_cartas(); 
                instancia.Iniciar();
                return instancia;
                
        }

        // nao é UI, vai star no espaço 3d 
        // ** lembrar que Tela senpre vai estar na frente por ser canvas/UI

        public GameObject canvas;
        public GameObject canvas_3d;

        public Controlador_tela_cartas controlador_tela_cartas;


        public void Iniciar(){

                controlador_tela_cartas = Controlador_tela_cartas.Construir();
        }

        public static void Finalizar(){

                instancia = null;

                Controlador_tela_cartas.instancia = null;

                return;

        }

        public void Update(){}

        public Action Lidar_retorno;
        public Action Lidar_saida;


}
