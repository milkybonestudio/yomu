
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System;
using System.Collections.Generic;



public class __TOOLS__blocks_change {

        
        public static __TOOLS__blocks_change instancia;
        public static __TOOLS__blocks_change Pegar_instancia(){ return instancia; }



        public Transform[] blocos_transform;
        public bool[] blocos_transform_ativados;
          
        //public bool em_transicao = false ;
        //public Bloco modo_tela_em_transicao = Bloco.nada;
    

        
        public void Action_block_OUT(){

                CONTROLLER__game_data controlador = CONTROLLER__game_data.Pegar_instancia();

                // --- PEGAR BLOCOS
                Block_type bloco_para_voltar = Player_estado_atual.Pegar_instancia().Pegar_bloco_anterior();
                Block_type bloco_para_excluir = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual();
                Player_estado_atual.Pegar_instancia().Voltar_modo_tela(); 
                

                // --- PEGAR BLOCO
                Block interface_bloco_para_voltar = controlador.blocos[ ( int ) bloco_para_voltar ];
                Block interface_bloco_para_excluir = controlador.blocos[ ( int ) bloco_para_voltar ];

                // --- FINALIZAR
                interface_bloco_para_voltar.Finalizar();
                interface_bloco_para_excluir.Finalizar();

                // --- DELETAR GAME OBJECTS
                Deletar_game_objects_bloco(  bloco_para_excluir );
                return;

        }

        public void Action_block_START( Block_type _novo_bloco ){

                CONTROLLER__game_data controlador = CONTROLLER__game_data.Pegar_instancia();

                // --- INICIAR NOVO BLOCO
                Block_type bloco_para_ir = _novo_bloco;
                Player_estado_atual.Pegar_instancia().Adicionar_modo_tela( bloco_para_ir ); 

                Block _interface_bloco = controlador.blocos[ ( int ) _novo_bloco ];
                _interface_bloco.Iniciar();

                //mark
                //** nao faz sentido ficar aquui
                // em blocos conectados tem que esconder 
                Deixar_visivel_somente_bloco_atual( _novo_bloco ) ;

        }






        public void Deixar_visivel_somente_bloco_atual( Block_type _bloco_atual ){

                
                //    transicao nunca entra
                for( int bloco_index = ( int ) Block_type.interacao;  bloco_index < blocos_transform.Length; bloco_index++ ){


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

  
        public void Deletar_game_objects_bloco( Block_type _bloco_para_excluir ){

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


}






