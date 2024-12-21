using System;
using UnityEngine;



public class BLOCO_minigames : Block {

        // --- INSTANCIA

        public static BLOCO_minigames instancia;
        public static BLOCO_minigames Pegar_instancia(){ return instancia; }

        // --- DEFAULT BLOCO


        public Action Lidar_retorno;
        public Action Colocar_UI;
        public Action Colocar_input;


        public override void Update(){}
        public override void Finalizar(){}
        public override void Iniciar(){}
        public override void Destruir(){}
        public override Task_req Carregar_dados(){ return null; }
        

        // --- DADOS

        public GameObject container_minigame;


        

}
