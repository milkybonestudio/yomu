using System;
using UnityEngine;



public class BLOCO_cartas {

        public static BLOCO_cartas instancia;
        public static BLOCO_cartas Pegar_instancia( bool _forcar = false  ){

                if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("BLOCO_cartas")) { instancia = new BLOCO_cartas();instancia.Iniciar();} return instancia;}
                if(  instancia == null) { instancia = new BLOCO_cartas(); instancia.Iniciar(); }
                return instancia;

        }

        public void Iniciar(){}

        public void Lidar_retorno(){}
        public void Lidar_saida(){}

}
