using System;
using UnityEngine;



public class BLOCO_minigames {


        public static BLOCO_minigames instancia;
        public static BLOCO_minigames Pegar_instancia(){ return instancia; }
        public static BLOCO_minigames Construir(){ instancia = new BLOCO_minigames(); return instancia;}

        public void Iniciar(){}

        public void Lidar_retorno(){}
        public void Lidar_saida(){}

}
