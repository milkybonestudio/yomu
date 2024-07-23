using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System;

/*
        blocos podem fazer 2 coisas: OUT ou START.     out sempre exclui o atual e vai para o bloco anterior        
                                                       start preserva o bloco atual e cria um proximo bloco
        movimento é o unico que nao pode dar out.
        dados_blocos vao ter 2 objetos por bloco, START e RETURN
*/


 public class Controlador_transicao_jogo {

        
        public static Controlador_transicao_jogo instancia;
        public static Controlador_transicao_jogo Pegar_instancia(){ return instancia; }


        public Jogo jogo;

        public Transform[] blocos_transform;

        
        public GameObject canvas_jogo; // 
        public GameObject  coberta_canvas; // nao pega ui
        public Image  coberta_canvas_imagem; 

        public Coroutine coroutine_tela;
        public Action start_transition_rise;
        public Action end_transition_rise;


        public Action start_transition_down;
        public Action end_transition_down;

          
        public bool em_transicao = false ;
        public Bloco modo_tela_em_transicao = Bloco.nada;



        public void Mudar_bloco(){

                Req_transicao req = Dados_blocos.req_transicao;
                if( req == null )
                        { throw new Exception("req em mudar bloco veio null"); }
                

                em_transicao = true;
                jogo.bloco_atual =  Bloco.transicao;

                if( coroutine_tela != null )
                        {
                                Mono_instancia.Stop_coroutine( coroutine_tela );
                                coroutine_tela = null;
                        }


                switch( req.tipo_transicao ){
                
                        case Tipo_transicao.cor: coroutine_tela =  Mono_instancia.Start_coroutine(  Transicao_jogo_cor.Ativar( req  ) );  break; 
                        case Tipo_transicao.instantaneo:  Transicao_jogo_instantania.Ativar( req ) ;  break;

                }

                return;

        }


        public void Trocar_blocos ( Bloco _bloco , Tipo_troca_bloco _tipo){

                // **quem pediu a req fica responsavel de criar os dados_START ou dados_RETURN

                
                // em blocos conectados tem que esconder 
                Deixar_visivel_somente_bloco_atual( _bloco ) ;
                

                em_transicao = false;
                Dados_blocos.req_transicao = null; 
                jogo.bloco_atual = _bloco;

                if( _tipo == Tipo_troca_bloco.START )
                        {

                                Bloco bloco_para_ir = _bloco;

                                Player_estado_atual.Pegar_instancia().Adicionar_modo_tela( bloco_para_ir ); 

                                switch( bloco_para_ir ){

                                        case Bloco.conector: jogo.bloco_conector = Construtor_bloco_CONECTOR.Construir();  break;
                                        case Bloco.minigames: jogo.bloco_minigames = Construtor_bloco_MINIGAMES.Construir();  break;
                                        

                                        case Bloco.visual_novel: jogo.bloco_visual_novel = Construtor_bloco_VISUAL_NOVEL.Construir();  break;
                                        case Bloco.conversas: jogo.bloco_conversas = Construtor_bloco_CONVERSAS.Construir();  break;
                                        case Bloco.cartas: jogo.bloco_cartas = Construtor_bloco_CARTAS.Construir();  break;
                                        case Bloco.utilidades: jogo.bloco_utilidades = Construtor_bloco_UTILIDADES.Construir();  break;
                                        default: throw new Exception( $"bloco { bloco_para_ir } nao aceito em para Construir" );

                                        
                                }


                        }

    
                if( _tipo == Tipo_troca_bloco.OUT )
                        {

                                Bloco bloco_para_voltar = Player_estado_atual.Pegar_instancia().Pegar_bloco_anterior();
                                Bloco bloco_para_excluir = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual();

                                Player_estado_atual.Pegar_instancia().Voltar_modo_tela(); 

                                // --- FINALIZAR

                                switch( bloco_para_excluir ) {

                                        case Bloco.visual_novel: jogo.bloco_visual_novel = null; Finalizador_VISUAL_NOVEL.Finalizar(); break;
                                        case Bloco.conector: jogo.bloco_conector = null; Finalizador_CONECTOR.Finalizar(); break;
                                        case Bloco.conversas: jogo.bloco_conversas = null; Finalizador_CONVERSAS.Finalizar(); break;
                                        case Bloco.cartas: jogo.bloco_cartas = null; Finalizador_CARTAS.Finalizar(); break;
                                        case Bloco.minigames: jogo.bloco_minigames = null; Finalizador_MINIGAMES.Finalizar(); break;
                                        case Bloco.utilidades: jogo.bloco_utilidades = null; Finalizador_UTILIDADES.Finalizar(); break;
                                        default: throw new Exception( $"bloco { bloco_para_excluir } nao aceito em para Destruir" );
                                        
                                }

                                

                                // --- DELETAR GAME OVJECTS

                                Deletar_game_objects_bloco(  bloco_para_excluir );



                                // --- LIDAR RETORNO
                                // ** nao existe mais

                                // switch( bloco_para_voltar ) {

                                //         case Bloco.visual_novel: jogo.bloco_visual_novel.Lidar_retorno() ; return ;
                                //         case Bloco.conector: jogo.bloco_conector.Lidar_retorno() ; return ;
                                //         case Bloco.conversas: jogo.bloco_conversas.Lidar_retorno() ; return ;
                                //         case Bloco.cartas: jogo.bloco_cartas.Lidar_retorno() ; return ;
                                //         case Bloco.minigames: jogo.bloco_minigames.Lidar_retorno() ; return ;
                                //         case Bloco.utilidades: jogo.bloco_utilidades.Lidar_retorno();  break;

                                // }
                                

                        }

                    
                return;  


        }


        public void Deixar_visivel_somente_bloco_atual ( Bloco _bloco_atual ){

                
                        //    transicao nunca entra
                for(int bloco_index = 1 ;  bloco_index < blocos_transform.Length ; bloco_index++){

                        if( bloco_index == ( int ) _bloco_atual )
                                { 
                                        blocos_transform[ bloco_index ].gameObject.SetActive( true );
                                        continue;
                                }

                        blocos_transform[ bloco_index ].gameObject.SetActive( false );
                        continue;

                }

                return;

        }



  
        public void Deletar_game_objects_bloco( Bloco _bloco_para_excluir ){

                Console.Log( "veio em Deletar_game_objects_bloco. Se funcionar remover essa mensagem" );


                Transform transform_bloco_para_excluir = blocos_transform[ ( int ) _bloco_para_excluir ];

                for( int game_object_index = 0 ; game_object_index < transform_bloco_para_excluir.childCount ; game_object_index++ ){

                        GameObject obj_para_destruir = transform_bloco_para_excluir.GetChild( game_object_index ).gameObject;
                        GameObject.Destroy( obj_para_destruir );
                        continue;

                }

                return;

        }






        public IEnumerator Salvar_animation(){

          
                int max_time = 60 * 10;
                int i = 0;
                while (true){
                    
                        i++;
                        if( i > max_time) throw new ArgumentException("em salvando_animation passou o tempo maximo de " + (max_time/60) + " segundos");
                   //     if( controlador.controlador_save.is_saving == false ) break;
                        yield return null;

                }

                yield break;

        }






}






