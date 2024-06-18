using System;
using UnityEngine;



public class BLOCO_cartas {

        public static BLOCO_cartas instancia;
        public static BLOCO_cartas Pegar_instancia(){ return instancia; }



        public static BLOCO_cartas Construir(){ 
                
                instancia = new BLOCO_cartas(); 


                instancia.container_cartas = new GameObject( "Cartas" );
                instancia.container_cartas.transform.SetParent( GameObject.Find( "Tela_3d" ).transform , false);
                
                return instancia;
                
        }

        // nao é UI, vai star no espaço 3d 
        // ** lembrar que Tela senpre vai estar na frente por ser canvas/UI
        public GameObject container_cartas;


        public void Iniciar_bloco_cartas(){}
        public void Finalizar(){}

        public void Lidar_retorno(){}
        public void Lidar_saida(){}

}
