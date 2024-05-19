using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;





public class Jogo {


        public static Jogo instancia;
        public static Jogo Pegar_instancia(){ return instancia; }
        public static Jogo Construir( int _save, bool _novo_jogo ){ instancia = new Jogo( _save, _novo_jogo ); return instancia;}


        public Jogo( int _save, bool _novo_jogo  ){

                /*
                        oque pode ser complicado? 
                        criar os arquivos 

                        // tela preta
                        while( anim ){

                        oque pode demorar? 

                        - load dlls : max : 100mb => +- 1 seg
                        - verificar arquivos .tmp 
                        - carregar_personagens
                        - descomprimir imagens necessarias UI
                

                        }

                
                */



                Mono_instancia.Start_coroutine( Iniciar_jogo_c() );

                IEnumerator Iniciar_jogo_c(){






                        Task_req req_iniciar_jogo = new Task_req(

                                new Chave_cache(),
                                "Iniciar_jogo"

                        );

                        req_iniciar_jogo.fn_iniciar = ( Task_req req ) => { 


                                Controlador_save.Construir( _save, _novo_jogo );


                        };

                        Controlador_multithread.Pegar_instancia().Adicionar_task( req_iniciar_jogo );


                        // ESPERA OS DADOS FICAREM PRONTOS 
                
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

                        GameObject tela_transicao_do_menu = GameObject.Find( "Tela/Canvas/Transicao_inicio_jogo" );   
                        
                        if( tela_transicao_do_menu != null ){

                                Image imagem_transicao = tela_transicao_do_menu.GetComponent<Image>();

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

                        bloco_atual = Bloco.movimento;

                        GameObject.Destroy( tela_transicao_do_menu );




                        yield break;



                }
                


                
                // System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();
                // long tempo = ( timePerParse.ElapsedMilliseconds)  ;
                // timePerParse.Stop();
                // Debug.Log( "TEMPO PARA CRIAR OS CONTROALDORES: " + tempo  );




                // pegar o save se tiver
                
                // logica: Carregar_save vai ser async com o jogo e vai iniciar a tela de carregamento. 
                // quando os dados forem carregados o controlador_save vai mudar o tipo de update diretamente para movimento e iniciar qualquer coisa que precise ser iniciado 
                //Controlador_save.Pegar_instancia().Carregar_save( _save );




        }

        public void Iniciar_primeiro_jogo(){}



        public Bloco bloco_atual = Bloco.nada;



        public BLOCO_visual_novel bloco_visual_novel;
        public BLOCO_conversas bloco_conversas;
        public BLOCO_movimento bloco_movimento;
        public BLOCO_cartas bloco_cartas;
        public BLOCO_minigames bloco_minigames;
        

        





        public void Update(){


            
                // if(  Controlador_UI.Pegar_instancia().Update() ) { return; }

                // if( Controlador_transicao.Pegar_instancia().em_transicao ) { return; }

                // Controlador_audio.Pegar_instancia().Update();

                

                switch (  Player_estado_atual.Pegar_instancia().bloco_atual ) {
                    
                        // case Bloco.visual_novel :  bloco_visual_novel.Update() ;  break;
                        // case Bloco.jogo :  bloco_jogo.Update(); break;
                        // case Bloco.login :  bloco_login.Update() ; break;
                        // case Bloco.menu : bloco_menu.Update() ; break;
                        //case Bloco.teste: teste.Update();break;
                        //case Bloco.NADA: console.log("esta no modo_tela NADA"); break;

                }





        }






}