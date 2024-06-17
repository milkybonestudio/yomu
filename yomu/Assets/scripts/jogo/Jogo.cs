using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/*
        Contruir() => cria o objeto
        Destruir() => ?
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
        public BLOCO_movimento bloco_movimento;
        public BLOCO_cartas bloco_cartas;
        public BLOCO_minigames bloco_minigames;

        // --- CONTROLADORES
        public Controlador_save controlador_save;
        public Controlador_AI controlador_AI;

        public GameObject canvas;
        

        public Jogo(){

                // ** coisas que interagem com o canvas nao podem ser usados na multitrhead 
                //    entao tem que ser criados aqui
                
                // jogo vai criar o canvas do jogo e os objetos necessarios
                canvas = GameObject.Find( "Tela/Canvas" );
                GameObject jogo_canvas = new GameObject( "Jogo" );
                jogo_canvas.transform.SetParent( canvas.transform, false );

                Controlador_transicao.Construir();
                Dados_blocos.Construir();
                Controlador_UI.Construir();
                

                bloco_visual_novel = BLOCO_visual_novel.Construir();
                bloco_movimento =  BLOCO_movimento.Construir();
                bloco_conversas = BLOCO_conversas.Construir();
                bloco_cartas = BLOCO_cartas.Construir();
                bloco_minigames = BLOCO_minigames.Construir();
        

        }


        public static Jogo Construir_teste(){ 

                Jogo jogo = new Jogo(); 

                        Controlador_save.Construir_teste(); 
                        Controlador_AI.Construir_teste(); 
                        jogo.bloco_atual = Bloco.nada;

                instancia = jogo;
                return jogo;
                
        }

        
        public static Jogo Construir( int _save, bool _novo_jogo  ){

                throw new Exception( "tentou contruir jogo normal. Por hora somente forma de teste" );

                Jogo jogo = new Jogo() ; 

                        // Iniciar nao muda 
                        Mono_instancia.Start_coroutine( Iniciador_jogo.Iniciar( jogo, _save , _novo_jogo ) );

                instancia = jogo;
                return jogo;

        }



        public void Update(){

            
                // if(  Controlador_UI.Pegar_instancia().Update() ) { return; }

                //if( Controlador_transicao.Pegar_instancia().em_transicao ) { return; }


                console.log( "bloco atual jogo: " + bloco_atual );

                switch (  bloco_atual ) {
                    

                        case Bloco.visual_novel :  bloco_visual_novel.Update() ;  break;
                        case Bloco.movimento: bloco_movimento.Update(); break;
                        case Bloco.minigame: bloco_minigames.Update(); break;
                        case Bloco.conversa: bloco_conversas.Update(); break;
                        case Bloco.cartas: bloco_conversas.Update(); break;

                        case Bloco.salvando: console.log( "esta em modo jogo salvando" ); break;
                        case Bloco.nada: console.log( "esta em modo jogo nada" ); break;
                        case Bloco.transicao :    return;
                }


        }


}