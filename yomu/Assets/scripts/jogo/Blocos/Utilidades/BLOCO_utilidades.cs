using System;
using UnityEngine;



public class BLOCO_utilidades {

        public static BLOCO_utilidades instancia;
        public static BLOCO_utilidades Pegar_instancia(){ return instancia; }


        public GameObject canvas;
        public GameObject canvas_3d;

        public Controlador_tela_utilidades controlador_tela_utilidades;


        public static BLOCO_utilidades Iniciar_bloco_utilidades(){ 

                if( instancia != null )
                        { throw new Exception( "tentou iniciar o bloco: <color=red>CARTAS</color> mas a instancia nao estava null" ); }
                
                instancia = new BLOCO_utilidades(); 
                instancia.Iniciar();
                return instancia;
                
        }



        public void Iniciar(){

                controlador_tela_utilidades = Controlador_tela_utilidades.Construir();
        }

        public static void Finalizar(){

                instancia = null;
                Controlador_tela_utilidades.instancia = null;

                return;

        }

        public void Update(){}

        public Action Lidar_retorno;
        public Action Lidar_saida;


}
