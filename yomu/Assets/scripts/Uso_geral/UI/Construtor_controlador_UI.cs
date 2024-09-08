using UnityEngine;


public static class Construtor_controlador_UI {


        public static Controlador_UI Construir(){ 

                if( Controlador_UI.instancia != null )
                    { throw new System.Exception( "Tentou Construir o controlador_UI mas a instancia nao estava null" ); }

                Controlador_UI controlador = new Controlador_UI(); 

                    
                    controlador.game_object = GameObject.Find( "Tela/UI/UI_container" );
                    controlador.info = new UI_info();


                Controlador_UI.instancia = controlador;

                return controlador;




        }


}