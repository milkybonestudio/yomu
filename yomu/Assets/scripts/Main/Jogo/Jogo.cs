using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Jogo { 


        public static Jogo instancia;
        public static Jogo Pegar_instancia(){ if( instancia == null ){ throw new Exception("tentou pegar Jogo mas estava null"); } return instancia; }

        public INTERFACE__bloco[] interfaces_blocos;

        // --- CONTROLADORES
        public Controlador_armazenamento_disco controlador_armazenamento_disco;
        public Controlador_AI controlador_AI;

        // TELA 
        public GameObject canvas;
        public GameObject canvas_3d;
        
        public Bloco bloco_atual = Bloco.nada;

        public void Update(){

                // UPDATE
                interfaces_blocos[ ( int ) bloco_atual ].Update();

        }


        public static void Zerar_dados(){


                instancia = null;

                // --- ZERAR BLOCOS
                foreach( INTERFACE__bloco bloco_interface in Jogo.Pegar_instancia().interfaces_blocos )
                    { bloco_interface.Destruir(); }

                Finalizador_UI.Finalizar();

                return;


        }


}