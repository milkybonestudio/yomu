using System;
using UnityEngine;


public class CONTROLLER__UI {

        
        public static CONTROLLER__UI instancia;
        public static CONTROLLER__UI Pegar_instancia(){ return instancia; }


        public Device[,][] UIs;
        public Device[,][] UIs_program; // ** only program can change


        public void Change_program_UIs( Device[] _new_UIs, Program_mode _mode ){

            // ** Program_UI do not have transitions

        }


        

        // testei e a velocidade para struc é basicamente a mesma. 
        public float[] posicao_mouse = new float[ 2 ];
        public float  screen_h = 0f;
        public float  screen_w = 0f;
        public float  alpha = 0f;

        public float  dif = 0f;



        public Vector2 Ajustar_posicao_vec2( Vector2 _vec ){ return _vec * (1080f / Screen.height); }


        public void Mudar_scale( Vector2 _vec ){ _vec *= 1080f / Screen.height; }



        public void Atualizar_mouse_atual( Control_flow _control_flow ){


                posicao_mouse[ 0 ] =   Input.mousePosition.x  * (  1920f / Screen.width ) ;
                posicao_mouse[ 1 ] =   Input.mousePosition.y  * (  1920f / Screen.width )  ;

        }




        public Localizador_UI[] localizadores;

        public GameObject container;


        public Action UI_objeto_update;

        public bool foi_ativado = false;

        public void Update(){


        }


}