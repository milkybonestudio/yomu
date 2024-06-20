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
        public static Jogo Pegar_instancia(){ return instancia; }

        public Bloco bloco_atual = Bloco.nada;


        // --- BLOCOS 

        public BLOCO_visual_novel bloco_visual_novel;
        public BLOCO_conversas bloco_conversas;
        public BLOCO_conector bloco_conector;
        public BLOCO_cartas bloco_cartas;
        public BLOCO_minigames bloco_minigames;

        // --- CONTROLADORES
        public Controlador_save controlador_save;
        public Controlador_AI controlador_AI;

        // TELA 
        public GameObject canvas;
        public GameObject canvas_3d;
        

        public static Jogo Construir(){

                // ** coisas que interagem com o canvas nao podem ser usados na multitrhead 
                //    entao tem que ser criados aqui
                
                // jogo vai criar o canvas do jogo e os objetos necessarios

                Jogo jogo = new Jogo(); 
                        
                        jogo.canvas = GameObject.Find( "Tela/Canvas" );
                        jogo.canvas_3d = GameObject.Find( "Canvas_3d" );
                        GameObject jogo_canvas = new GameObject( "Jogo" );
                        jogo_canvas.transform.SetParent( jogo.canvas.transform, false );

                        Controlador_UI.Construir();

                        // --- TRANSICAO TEM QUE FICAR NA FRENTE
                        Controlador_transicao_jogo.Construir( jogo );

                instancia = jogo;
                return jogo;
                

        }

        
        public Task_req Iniciar_jogo( int _save, bool _novo_jogo  ){



                Task_req req_iniciar_jogo = new Task_req ( new Chave_cache(), "Iniciar_jogo");

                req_iniciar_jogo.fn_iniciar = ( Task_req _req )  =>     { 
                                                                                controlador_save = Controlador_save.Construir( _save, _novo_jogo );
                                                                                controlador_AI = Controlador_AI.Construir();
                                                                        };

                Controlador_multithread.Pegar_instancia().Adicionar_task( req_iniciar_jogo );

                return req_iniciar_jogo;

        }



        public void Update(){

            
                // if(  Controlador_UI.Pegar_instancia().Update() ) { return; }

                //if( Controlador_transicao.Pegar_instancia().em_transicao ) { return; }


                console.log( "bloco atual jogo: " + bloco_atual );

                switch (  bloco_atual ) {
                    

                        case Bloco.visual_novel : bloco_visual_novel.Update(); break;
                        case Bloco.conector: bloco_conector.Update(); break;
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

                BLOCO_conector.Finalizar();
                BLOCO_visual_novel.Finalizar();
                BLOCO_conversas.Finalizar();
                BLOCO_cartas.Finalizar();
                BLOCO_minigames.Finalizar();


        }


}