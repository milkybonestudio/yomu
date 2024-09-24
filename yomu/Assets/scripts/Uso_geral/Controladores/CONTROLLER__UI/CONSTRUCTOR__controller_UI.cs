using UnityEngine;


public static class CONSTRUCTOR__controller_UI {


        public static CONTROLLER__UI Construir(){ 

                if( CONTROLLER__UI.instancia != null )
                    { throw new System.Exception( "Tentou Construir o CONTROLLER__UI mas a instancia nao estava null" ); }

                CONTROLLER__UI controlador = new CONTROLLER__UI(); 

                    

                    controlador.container = GameObject.Find( "Tela/UI/UI_container" );
                    


                CONTROLLER__UI.instancia = controlador;

                return controlador;



        }


}