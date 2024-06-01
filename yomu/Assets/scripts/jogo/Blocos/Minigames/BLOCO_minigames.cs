using System;
using UnityEngine;



public class BLOCO_minigames {


        public static BLOCO_minigames instancia;
        public static BLOCO_minigames Pegar_instancia(){ return instancia; }
        public static BLOCO_minigames Construir(){ 
                
                instancia = new BLOCO_minigames(); 


                        instancia.container_minigame = new GameObject( "Minigame" );
                        instancia.container_minigame.transform.SetParent( GameObject.Find( "Tela/Canvas/Jogo" ).transform , false);


                return instancia;
                
        }

        public GameObject container_minigame;


        public void Iniciar(){}
        public void Finalizar(){}

        public void Lidar_retorno(){}
        public void Lidar_saida(){}

}
