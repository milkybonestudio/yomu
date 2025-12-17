using System;
using UnityEngine;



public class BLOCO_cartas : BLOCK {

        public static BLOCO_cartas instancia;
        public static BLOCO_cartas Pegar_instancia(){ return instancia; }



        public static BLOCO_cartas Iniciar_bloco_cartas(){ 

                if( instancia != null )
                        { throw new Exception( "tentou iniciar o bloco: <color=red>CARTAS</color> mas a instancia nao estava null" ); }
                
                instancia = new BLOCO_cartas(); 
                instancia.Iniciar();
                return instancia;
                
        }



        public override void Destruir(){}

        public override Task_req Carregar_dados(){ return null; }


        // nao é UI, vai star no espaço 3d 
        // ** lembrar que Tela senpre vai estar na frente por ser canvas/UI
        

        public GameObject canvas;
        public GameObject canvas_3d;

        public Controlador_tela_cartas controlador_tela_cartas;


        public override void Iniciar(){

                controlador_tela_cartas = Controlador_tela_cartas.Construir();
        }

        public override void Finalizar(){

                instancia = null;

                Controlador_tela_cartas.instancia = null;

                return;

        }

        public override void Update( Control_flow _control_flow ){}

        public Action Lidar_saida;


}
