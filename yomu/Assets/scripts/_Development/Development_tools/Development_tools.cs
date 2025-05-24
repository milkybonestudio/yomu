using UnityEngine;

public class Development_tools {


    	public Development_tools(){

            tools_game_object = GameObject.Find( "Screen/System_UI/Tools" ).transform.gameObject;

        }

        public GameObject tools_game_object;

        public void Atualizar_ferramentas_desenvolvimento(){
            // aqui pode criar as ferramentas 
            // vai ser criadas com as F teclas. F1, F2 ... 

        }


}