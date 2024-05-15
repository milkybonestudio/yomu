using System;
using UnityEngine;




public class Controlador_input_visual_novel {


        public Tipo_iniciar_UI tipo_iniciar_UI = Tipo_iniciar_UI.DEFAULT;

    	// vai ser salvo no save 
        public byte[] dados_ui;

        public void Mudar_input(){


                switch( this.tipo_iniciar_UI ){

                        case Tipo_iniciar_UI.DEFAULT : break;
                        default: throw new Exception( "" );

                }

        }


        public void Mudar_ui_default(){


                BLOCO_visual_novel bloco = BLOCO_visual_novel.Pegar_instancia();

                /*

                    fazer coisas aqui 
                
                */

                return; 

            
        
        }


        /* cada bloco vai ter a responsabilidade de escolher como vai esconder */

        public void Esconder_pergaminho(){

        }


}




