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


        public Jogo(){

                

                // jogo vai criar o canvas do jogo e os objetos necessarios
                canvas = GameObject.Find( "Tela/Canvas" );
                GameObject jogo_canvas = new GameObject( "Jogo" );
                jogo_canvas.transform.SetParent( canvas.transform, false );

                bloco_visual_novel = BLOCO_visual_novel.Construir();
                bloco_movimento =  BLOCO_movimento.Construir();
                bloco_conversas = BLOCO_conversas.Construir();
                bloco_cartas = BLOCO_cartas.Construir();
                bloco_minigames = BLOCO_minigames.Construir();
                

                Controlador_transicao.Construir();

                // Para iniciar um bloco precisa pedrie em controlador_transicao.Mudar_bloco()


        }



        public static Jogo Construir_teste(){ 


                
                instancia = new Jogo(); 

                // os dados nao vao ser colocado no save
                // vao ser colocados no bloco de teste. 
                // esse bloco vai ter a cadeia tste => jogo        


                Controlador_save.Construir_teste(); 



                Controlador_AI.Construir_teste(); 
                instancia.bloco_atual = Bloco.nada;



                
                
                return instancia;

                
        }



        
        public static Jogo Construir( int _save, bool _novo_jogo  ){

                Debug.LogError( "tentou contruir jogo normal. Por hora somente forma de teste" );

                return Construir_teste();


                instancia = new Jogo( ); 

                Mono_instancia.Start_coroutine( Iniciar_jogo_c() );

                return instancia;


                IEnumerator Iniciar_jogo_c(){


                        // em teste isso nao vai demorar porque nao vai copiar arquivos ou carregar muitos personagens 


                        Task_req req_iniciar_jogo = new Task_req(

                                new Chave_cache(),
                                "Iniciar_jogo"

                        );

                        req_iniciar_jogo.fn_iniciar = ( Task_req req ) => { 


                                Jogo.Pegar_instancia().controlador_save = Controlador_save.Construir( _save, _novo_jogo );
                                Jogo.Pegar_instancia().controlador_AI = Controlador_AI.Construir();


                        };

                        Controlador_multithread.Pegar_instancia().Adicionar_task( req_iniciar_jogo );

                        // chacar se a animacao do menu acabou
                        GameObject tela_transicao_do_menu = GameObject.Find( "Tela/Canvas/Transicao_inicio_jogo" );                           

                        Image imagem_transicao = null;

                        if( tela_transicao_do_menu != null ){

                                imagem_transicao = tela_transicao_do_menu.GetComponent<Image>();
                                
                                // tranca até a animacao acabar 
                                while( imagem_transicao.color[ 3 ] < 1f ){ yield return null; }

                        }



                        // ESPERA OS DADOS FICAREM PRONTOS 
                        // ** provavelmente já vao estar prontos pelo tempo da animacao do menu
                
                        float tempo_maximo = 20f;
                        float tempo_entre_checks = 0.5f;
                        float tempo_atual = 0f ; 
                        
                        while( true ){
                        
                                if(  tempo_atual > tempo_maximo ){ throw new Exception( "tempo maximo para iniciar o jogo foi atingido" ); } 
                                if( req_iniciar_jogo.finalizado == true ){ break; }

                                tempo_atual += tempo_entre_checks; 

                                yield return new WaitForSeconds( tempo_entre_checks );
                                
                        }


                        // ENCERRA TRANSICAO

                        
                        if( tela_transicao_do_menu != null ){

                                float alp = imagem_transicao.color[ 3 ];
                                
                                while( alp > 0.05f  ){

                                        alp -= Time.deltaTime;
                                        Color nova_cor = imagem_transicao.color;
                                        nova_cor[ 3 ] = alp;
                                        imagem_transicao.color = nova_cor;

                                        yield return  null;

                                }

                        }
                        

                        /*
                        
                                o tipo de bloco vai estar no save. 
                        
                        */


                        instancia.bloco_atual = Bloco.nada;

                        GameObject.Destroy( tela_transicao_do_menu );


                        yield break;

                }


        }




        public Bloco bloco_atual = Bloco.nada;



        public BLOCO_visual_novel bloco_visual_novel;


        public BLOCO_conversas bloco_conversas;
        public BLOCO_movimento bloco_movimento;
        public BLOCO_cartas bloco_cartas;
        public BLOCO_minigames bloco_minigames;

        public Controlador_save controlador_save;
        public Controlador_AI controlador_AI;

        public GameObject canvas;
        

        





        public void Update(){



                // if( controlador_save.esta_salvando )
                //         {
                //                 controlador_save.Update_salvando();
                //                 return;

                //         }

            
                // if(  Controlador_UI.Pegar_instancia().Update() ) { return; }

                //if( Controlador_transicao.Pegar_instancia().em_transicao ) { return; }

                


                switch (  bloco_atual ) {
                    
                        case Bloco.visual_novel :  bloco_visual_novel.Update() ;  break;
                        case Bloco.movimento: bloco_movimento.Update(); break;

                        // case Bloco.jogo :  bloco_jogo.Update(); break;
                        // case Bloco.NADA: console.log("esta no modo_tela NADA"); break;

                        case Bloco.transicao :    return;
                }





        }






}