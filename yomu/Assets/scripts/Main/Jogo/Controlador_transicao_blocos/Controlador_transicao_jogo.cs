using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System;
using System.Collections.Generic;

/*
        blocos podem fazer 2 coisas: OUT ou START.     out sempre exclui o atual e vai para o bloco anterior        
                                                       start preserva o bloco atual e cria um proximo bloco
        conector é o unico que nao pode dar out.
        dados_blocos vao ter 2 objetos por bloco, START e RETURN
*/


public class Controlador_transicao_jogo {

        
        public static Controlador_transicao_jogo instancia;
        public static Controlador_transicao_jogo Pegar_instancia(){ return instancia; }


        public Jogo jogo;

        public Transform[] blocos_transform;
        public bool[] blocos_transform_ativados;

        
        public GameObject canvas_jogo; // 
        public GameObject  coberta_canvas; // nao pega ui
        public Image  coberta_canvas_imagem; 

        public Coroutine coroutine_tela;
          
        public bool em_transicao = false ;
        public Bloco modo_tela_em_transicao = Bloco.nada;
        public INTERFACE__transition_blocks[] interfaces_transitores;



        public void Mudar_bloco(){

                Req_transicao req = Controlador_pedidos_sistema.instancia.Take_transition_req( _need_exist : true );
                
                em_transicao = true;
                
                // ** nao faz sentido
                if( coroutine_tela != null )
                        { coroutine_tela = Mono_instancia.Stop_coroutine( coroutine_tela ); }


                IEnumerator IE = Get_transitioner( req.tipo_transicao ).Get_transition_IE( req );
                coroutine_tela =  Mono_instancia.Start_coroutine( IE );

                return;

        }


        




        public void Trocar_blocos (  Bloco _novo_bloco , Tipo_troca_bloco _tipo){


                // ** dados ja vao estar carregados
                // **quem pediu a req fica responsavel de criar os dados_START ou dados_RETURN
                
                if( _tipo == Tipo_troca_bloco.START )
                    {
                        // --- INICIAR NOVO BLOCO
                        Bloco bloco_para_ir = _novo_bloco;
                        Player_estado_atual.Pegar_instancia().Adicionar_modo_tela( bloco_para_ir ); 

                        INTERFACE__bloco _interface_bloco = jogo.interfaces_blocos[ ( int ) _novo_bloco ];
                        _interface_bloco.Iniciar();
                        
                    }

    
                if( _tipo == Tipo_troca_bloco.OUT )
                    {
                        // --- VOLTAR BLOCO

                        // --- PEGAR BLOCOS
                        Bloco bloco_para_voltar = Player_estado_atual.Pegar_instancia().Pegar_bloco_anterior();
                        Bloco bloco_para_excluir = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual();
                        Player_estado_atual.Pegar_instancia().Voltar_modo_tela(); 

                        // --- PEGAR BLOCO
                        INTERFACE__bloco interface_bloco_para_voltar = jogo.interfaces_blocos[ ( int ) bloco_para_voltar ];
                        INTERFACE__bloco interface_bloco_para_excluir = jogo.interfaces_blocos[ ( int ) bloco_para_voltar ];

                        // --- FINALIZAR
                        interface_bloco_para_voltar.Finalizar();
                        interface_bloco_para_excluir.Finalizar();

                        // --- DELETAR GAME OBJECTS
                        Deletar_game_objects_bloco(  bloco_para_excluir );

    
                    }


                // em blocos conectados tem que esconder 
                Deixar_visivel_somente_bloco_atual( _novo_bloco ) ;

                return;
        }




        public void Deixar_visivel_somente_bloco_atual( Bloco _bloco_atual ){

                
                //    transicao nunca entra
                for( int bloco_index = ( int ) Bloco.interacao;  bloco_index < blocos_transform.Length; bloco_index++ ){


                        // --- VERIFICA SE EH O BLOCO PARA IR
                        if( bloco_index == ( int ) _bloco_atual )
                            { blocos_transform[ bloco_index ].gameObject.SetActive( true ); continue; }  // --- VAI PARA O PROXIMO BLOCO     

                        // --- PRECISA ESCONDER  
                        if( !!!( blocos_transform_ativados[ bloco_index ] ) )
                            { continue; } // --- JA ESTA ESCONDIDO

                        blocos_transform[ bloco_index ].gameObject.SetActive( false );
                        
                        continue;

                }

                return;

        }

  
        public void Deletar_game_objects_bloco( Bloco _bloco_para_excluir ){

                Console.Log( "veio em Deletar_game_objects_bloco. Se funcionar remover essa mensagem" );

                // ** talvez possa optimizar usando BLOCO => container => dados[], acredito que quanto menos Destroy() melhor

                Transform transform_bloco_para_excluir = blocos_transform[ ( int ) _bloco_para_excluir ];

                for( int game_object_index = 0 ; game_object_index < transform_bloco_para_excluir.childCount ; game_object_index++ ){

                        GameObject obj_para_destruir = transform_bloco_para_excluir.GetChild( game_object_index ).gameObject;
                        GameObject.Destroy( obj_para_destruir );
                        continue;

                }

                return;

        }


        // --- INTERN

        private INTERFACE__transition_blocks Get_transitioner( Tipo_transicao _type ){ return interfaces_transitores[ ( int ) _type ]; }



}






