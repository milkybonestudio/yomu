using System;
using UnityEngine;



public class BLOCO_cartas {

        public static BLOCO_cartas instancia;
        public static BLOCO_cartas Pegar_instancia(){ return instancia; }
        public static BLOCO_cartas Construir(){ instancia = new BLOCO_cartas(); return instancia;}


        public void Iniciar(){}

        public void Lidar_retorno(){}
        public void Lidar_saida(){}

}
