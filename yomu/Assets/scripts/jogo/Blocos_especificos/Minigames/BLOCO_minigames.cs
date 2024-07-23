using System;
using UnityEngine;



public class BLOCO_minigames {

        // --- INSTANCIA

        public static BLOCO_minigames instancia;
        public static BLOCO_minigames Pegar_instancia(){ return instancia; }

        // --- DEFAULT BLOCO


        public Action Lidar_retorno;
        public Action Finalizar;
        public Action Colocar_UI;
        public Action Colocar_input;
        

        // --- DADOS

        public GameObject container_minigame;



        public void Update(){}

        

}
