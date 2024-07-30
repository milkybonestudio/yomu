using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/*
        Contruir() => cria o objeto

        Iniciar() => junto com os dados de Dados_blocos inicia o bloco sempre na transicao 
        Finalizar() => destroi os objetos que precisam ser destruido no BLOCO 
*/


public class Jogo {


        public static Jogo instancia;
        public static Jogo Pegar_instancia(){ if( instancia == null ){ throw new Exception("tentou pegar Jogo mas estava null"); } return instancia; }



        // --- BLOCOS 

        public BLOCO_conector bloco_conector;
        public BLOCO_visual_novel bloco_visual_novel;
        
        public BLOCO_conversas bloco_conversas;
        public BLOCO_cartas bloco_cartas;
        public BLOCO_minigames bloco_minigames;
        public BLOCO_utilidades bloco_utilidades;

        // --- CONTROLADORES
        public Controlador_save controlador_save;
        public Controlador_AI controlador_AI;

        // TELA 
        public GameObject canvas;
        public GameObject canvas_3d;
        

        // --- DADOS

        public Bloco bloco_atual = Bloco.nada;



        public void Update(){

            
                // if(  Controlador_UI.Pegar_instancia().Update() ) { return; }

                // if( Controlador_transicao.Pegar_instancia().em_transicao ) { return; }


                switch (  bloco_atual ) {
                    

                        case Bloco.conector: bloco_conector.Update(); break;

                        case Bloco.passando_dia: Controlador_sistema.Pegar_instancia().Verificar_passar_dia();break;

                        case Bloco.visual_novel : bloco_visual_novel.Update(); break;
                        case Bloco.minigames: bloco_minigames.Update(); break;
                        case Bloco.conversas: bloco_conversas.Update(); break;
                        case Bloco.cartas: bloco_cartas.Update(); break;

                        case Bloco.salvando: console.log( "esta em modo jogo salvando" ); break;
                        case Bloco.nada: console.log( "esta em modo jogo nada" ); break;
                        case Bloco.transicao :    return;
                }


        }


        public static void Zerar_dados(){


                instancia = null;

                // --- ZERAR BLOCOS

                Finalizador_CONVERSAS.Finalizar();
                Finalizador_MINIGAMES.Finalizar();
                Finalizador_VISUAL_NOVEL.Finalizar();
                Finalizador_CONECTOR.Finalizar();
                Finalizador_CARTAS.Finalizar();


        }


}