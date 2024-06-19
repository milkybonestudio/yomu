using System;
using UnityEngine;



public class BLOCO_cartas {

        public static BLOCO_cartas instancia;
        public static BLOCO_cartas Pegar_instancia(){ return instancia; }



        public static BLOCO_cartas Construir(){ 
                
                BLOCO_cartas bloco = new BLOCO_cartas(); 

                        bloco.controlador_tela_cartas = Controlador_tela_cartas.Construir( bloco );

                instancia = bloco;
                return bloco;
                
        }

        // nao é UI, vai star no espaço 3d 
        // ** lembrar que Tela senpre vai estar na frente por ser canvas/UI

        public GameObject canvas;
        public GameObject canvas_3d;

        public Controlador_tela_cartas controlador_tela_cartas;


        public void Iniciar_bloco_cartas(){}
        public void Finalizar(){

                controlador_tela_cartas.Finalizar();

        }

        public Action Lidar_retorno;
        public Action Lidar_saida;


}
