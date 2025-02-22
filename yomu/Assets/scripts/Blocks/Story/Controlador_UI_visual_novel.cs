using System;
using UnityEngine;




/*

        o bloque 

*/



public class Controlador_UI_visual_novel {

        public static Controlador_UI_visual_novel instancia;
        public static Controlador_UI_visual_novel Pegar_instancia(){ if( instancia == null){ throw new Exception( "instancia do bloco Controlador_UI_visual_novel nao foi instanciado" );} return instancia;}
        public static void Construir(){ instancia = new Controlador_UI_visual_novel();} 


        public void Esconder( string _tipo ){

                switch( _tipo ){

                    case "esconder_pergaminho": Esconder_pergaminho(); return;
                    default: throw new ArgumentException( $"nao foi achado tipo { _tipo } Controlador_UI_visual_novel" );

                }



                return;

                void Esconder_pergaminho(){

                    // esconder 



                }


        }


        public void Mosatrar( string _tipo ){



                return;

        }




        public void Mudar_ui_default(){


                BLOCO_story bloco = BLOCO_story.Pegar_instancia();

                /*

                    fazer coisas aqui 
                
                */

                return; 

            
        
        }


}









