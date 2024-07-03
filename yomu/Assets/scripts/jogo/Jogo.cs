using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/*
        Contruir() => cria o objeto
        Iniciar() => junto com os dados de Dados_blocos inicia o bloco sempre na transicao 
        Finalizar() => destroi os objetos que precisam ser destruido no BLOCO 
*/

/*
        


        - reinos podem ser destruidos, expandidos ou reduzidos. um reino sempre esta dependendo da capital. Se a capital for derrotada todo o reino se rende.

        - estados nao podem ser trocados ou excluidos 
        
        e cidades nunca sao divididos mas podem ter os dados trocados ou EVOLUIDAS.
             ** cada cidade tem que ocupar sempre o mesmo espaço. 
             talvez usar um enum para Espacos.espaco_1, Espacos.espaco_2 ... 
             principalmente para um jogo que vai se passar em varios anos faria sentido


        [ reinos ] 

        [ estados ]

        [ cidades ]


        posicao => cidade => 
                 
                      


                


        


        interativos: o funcionamento sempre esta nos proprios dados, nao tem scripts 
        
        de onde vem os dados? => 

                build : os dados vao ser amazenados em um byte_arr e o programa reconstroi os dados quando precisar do interativo
                desenvolvimento : os dados vao ser armazenados em classes estaticas no modelo "Interativos_lista_N" que vão ser acessados por reflection. 

        os scripts tinham o proposito de ser um jeito para eu poder mudar dados do jogo, de encapsular logica. Se nao tem como é feito?

        essa parte quem vai ficar responsavel é a AI, ela consegue criar scripts. Antes de algum interativo ser iniciado ele primeiro precisa verificar se tem algum scrip rolando. 
        provavelmente vai ser na mesma ideia, de na build ser um formato e no desenvolvimento ser outro. 

        controlador interativos nao vai saber oque cada script faz, ele so sabe 2 coisas e só são importantes no processo de ATIVAR o intrativo: 
        1 - esse interativo esta bloqueado? => obvio
        1 - esse interativo tem algum Hook? => vai falar "olha so, o player clicou nesse. Faz as tuas paradas ai AI"

        Mas controlador_interativos vai poder 1 - ver quais interativos tem scripts 
                                              2 - ativar os scripts?? nao 




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
        public BLOCO_utilidades bloco_utilidades;

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

        



        public void Update(){

            
                // if(  Controlador_UI.Pegar_instancia().Update() ) { return; }

                //if( Controlador_transicao.Pegar_instancia().em_transicao ) { return; }


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