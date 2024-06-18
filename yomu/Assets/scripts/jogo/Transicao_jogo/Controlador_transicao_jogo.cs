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

        return tem os dados de retorno do bloco em um out
        start tem os dados para iniciar algum bloco

*/




 public class Controlador_transicao_jogo {

        
        public static Controlador_transicao_jogo instancia;
        public static Controlador_transicao_jogo Pegar_instancia(){ return instancia; }


        public Jogo jogo;

        public Dados_blocos dados_blocos ;

        
        public GameObject canvas_jogo; // 
        public GameObject  transicao_tela; // pega ui
        public GameObject  transicao_canvas; // nao pega ui
        public Image  transicao_tela_imagem;
        public Image  transicao_canvas_imagem; 

        public Coroutine coroutine_tela;
        public Action start_transition_rise;
        public Action end_transition_rise;


        public Action start_transition_down;
        public Action end_transition_down;

          
        public bool em_transicao = false ;
        public Bloco modo_tela_em_transicao = Bloco.nada;


        public static Controlador_transicao_jogo Construir( Jogo _jogo ){ 
                                
                Controlador_transicao_jogo controlador = new Controlador_transicao_jogo(); 

                        controlador.jogo = _jogo;
                        controlador.canvas_jogo =  GameObject.Find("Tela/Canvas/Jogo");
                        controlador.transicao_tela = GameObject.Find("Tela/UI/Transicao");
                        controlador.transicao_canvas = GameObject.Find("Tela/Canvas/Transicao");
                                
                        controlador.transicao_tela_imagem = controlador.transicao_tela.GetComponent<Image>();
                        controlador.transicao_canvas_imagem = controlador.transicao_canvas.GetComponent<Image>();

                        controlador.dados_blocos = Dados_blocos.Pegar_instancia();

                instancia = controlador;
                return instancia;
                
        }




        public void Mudar_bloco(){

                Req_transicao req = dados_blocos.req_transicao;
                if( req == null )
                        { throw new Exception("req em mudar bloco veio null"); }
                

                em_transicao = true;

                jogo.bloco_atual =  Bloco.transicao;

                modo_tela_em_transicao = req.novo_bloco;

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

                // em blocos conectados tem que esconder 
                Deixar_visivel_somente_bloco_atual( _bloco ) ;
                

                em_transicao = false;
                dados_blocos.req_transicao = null; 
                jogo.bloco_atual = _bloco;


                if( _tipo == Tipo_troca_bloco.START )
                        {

                                Bloco bloco_para_ir = _bloco;

                                Player_estado_atual.Pegar_instancia().Adicionar_modo_tela( bloco_para_ir ); 

                                switch( bloco_para_ir ){

                                        case Bloco.visual_novel: jogo.bloco_visual_novel.Iniciar_bloco_visual_novel(); break;
                                        case Bloco.movimento: jogo.bloco_movimento.Iniciar_bloco_movimento(); break;
                                        case Bloco.conversas: jogo.bloco_conversas.Iniciar_bloco_conversas(); break;
                                        case Bloco.minigames: jogo.bloco_minigames.Iniciar_bloco_minigames(); break;
                                        case Bloco.cartas: jogo.bloco_cartas.Iniciar_bloco_cartas(); break;
                                }

                                return;

                        }

    
                if( _tipo == Tipo_troca_bloco.OUT )
                        {

                                Bloco bloco_para_voltar = Player_estado_atual.Pegar_instancia().Pegar_bloco_anterior();
                                Bloco bloco_para_excluir = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual();

                                Player_estado_atual.Pegar_instancia().Voltar_modo_tela(); 

                                // --- FINALIZAR

                                switch( bloco_para_excluir ) {

                                        case Bloco.visual_novel: jogo.bloco_visual_novel.Finalizar() ; return ;
                                        case Bloco.movimento: jogo.bloco_movimento.Finalizar() ; return ;
                                        case Bloco.conversas: jogo.bloco_conversas.Finalizar() ; return ;
                                        case Bloco.cartas: jogo.bloco_cartas.Finalizar() ; return ;
                                        case Bloco.minigames: jogo.bloco_minigames.Finalizar() ; return ;

                                }

                                switch( bloco_para_voltar ) {

                                        case Bloco.visual_novel: jogo.bloco_visual_novel.Lidar_retorno() ; return ;
                                        case Bloco.movimento: jogo.bloco_movimento.Lidar_retorno() ; return ;
                                        case Bloco.conversas: jogo.bloco_conversas.Lidar_retorno() ; return ;
                                        case Bloco.cartas: jogo.bloco_cartas.Lidar_retorno() ; return ;
                                        case Bloco.minigames: jogo.bloco_minigames.Lidar_retorno() ; return ;

                                }

                                return;

                        }
                            

                return;  


        }


        public void Lidar_START( Bloco _novo_bloco ){
        


        }


        public void Lidar_OUT( Bloco _novo_bloco ){




        }




        public void Deixar_visivel_somente_bloco_atual ( Bloco _bloco_atual ){

                GameObject canvas = GameObject.Find("Tela/Canvas");
                int numero_blocos = canvas.transform.childCount;

                        //    transicao nunca entra
                for(int i = 0 ;  i < numero_blocos - 1 ; i++){

                        string name_1 = canvas.transform.GetChild( i ).name.ToLower();
                        string name_2 = Convert.ToString( _bloco_atual );

                        if(  name_1 == name_2  ) {

                                canvas.transform.GetChild( i ).gameObject.SetActive( true );        
                                continue;
                        }
                        
                        canvas.transform.GetChild( i ).gameObject.SetActive( false );

                }

        }









        public void Finalizar_bloco( Bloco _bloco_para_finalizar ){

                switch( _bloco_para_finalizar ){

                        case Bloco.visual_novel: jogo.bloco_visual_novel.Finalizar(); break;
                        
                }

                return;

        }
  
        public void Deletar_game_objects_bloco( Bloco _bloco_para_excluir ){

                
                int numero_blocos = canvas_jogo.transform.childCount;
                string modo_tela_nome = Convert.ToString( _bloco_para_excluir );
                
                for(int i = 0 ;  i < numero_blocos ; i++){


                        string modo_tela_para_comparar = canvas_jogo.transform.GetChild( i ).name.ToLower();
                        
                        if(  modo_tela_para_comparar != modo_tela_nome  ) 
                                { continue; }

                        // --- ACHOU BLOCO

                        Transform bloco_para_excluir_componentes_transform = canvas_jogo.transform.GetChild( i );

                        int numero_objs = bloco_para_excluir_componentes_transform.childCount;

                        for( int game_object_index = 0 ; game_object_index < numero_objs ; game_object_index++ ){

                                GameObject obj_para_destruir = bloco_para_excluir_componentes_transform.GetChild( game_object_index ).gameObject;
                                GameObject.Destroy( obj_para_destruir );

                        }

                        
                        return;

                }


                throw new ArgumentException("nao foi achado modo tela para excluir, veio: " + modo_tela_nome);
       
        }








        public void Mudar_UI_OUT(){

                Bloco bloco_que_vai_voltar = Player_estado_atual.Pegar_instancia().Pegar_bloco_anterior();
                Bloco bloco_atual = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual();


                // aqui vai ter algo especifico
                switch( bloco_atual ){


                        case Bloco.movimento: throw new Exception( "" );
                        case Bloco.visual_novel: {


                        } break;

                        

                }



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






