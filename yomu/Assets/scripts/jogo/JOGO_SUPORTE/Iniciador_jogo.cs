using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public static class Iniciador_jogo {

    public static IEnumerator Iniciar( Jogo _jogo , int _save, bool _novo_jogo ){

            // em teste isso nao vai demorar porque nao vai copiar arquivos ou carregar muitos personagens 

            Task_req req_iniciar_jogo = new Task_req (

                    new Chave_cache(),
                    "Iniciar_jogo"

            );

            req_iniciar_jogo.fn_iniciar = ( Task_req _req ) => { 

                    _jogo.controlador_save = Controlador_save.Construir( _save, _novo_jogo );
                    _jogo.controlador_AI = Controlador_AI.Construir();

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
            

            // ** o tipo de bloco vai estar no save. 
            
            _jogo.bloco_atual = Bloco.nada;

            GameObject.Destroy( tela_transicao_do_menu );
            yield break;

    }

}