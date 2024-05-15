using System;
using UnityEngine;



public class BLOCO_minigames {


        public static BLOCO_minigames instancia;
        public static BLOCO_minigames Pegar_instancia( bool _forcar = false  ){

                if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("BLOCO_minigames")) { instancia = new BLOCO_minigames();instancia.Iniciar();} return instancia;}
                if(  instancia == null) { instancia = new BLOCO_minigames(); instancia.Iniciar(); }
                return instancia;

        }

        public void Iniciar(){}

        public void Lidar_retorno(){}
        public void Lidar_saida(){}

}
