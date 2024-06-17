using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System;


/*


        blocos podem fazer 2 coisas: OUT ou START.     out sempre exclui o atual e vai para o bloco anterior        
                                                       start preserva o bloco atual e cria um proximo bloco


        jogo é o unico que nao pode dar out.

        dados_blocos vao ter 2 objetos por bloco, START e RETURN

        return tem os dados de retorno do bloco em um out
        start tem os dados para iniciar algum bloco



        **  transicao nao vai usar os dados dos blocos. ela só sabe sobre a req_transicao


*/




 public class Controlador_transicao {

        
        public static Controlador_transicao instancia;
        public static Controlador_transicao Pegar_instancia(){ return instancia; }




        public static Controlador_transicao Construir(){ 
                
                instancia = new Controlador_transicao(); 

                instancia.jogo = Jogo.Pegar_instancia();


                instancia.transicao_tela = GameObject.Find("Tela/UI/Transicao");
                instancia.transicao_canvas = GameObject.Find("Tela/Canvas/Transicao");
                
                
                
                instancia.transicao_tela_imagem = instancia.transicao_tela.GetComponent<Image>();
                instancia.transicao_canvas_imagem = instancia.transicao_canvas.GetComponent<Image>();

                instancia.dados_blocos = Dados_blocos.Pegar_instancia();
        

                
                return instancia;
                
        }





        public Jogo jogo;

        public Dados_blocos dados_blocos ;

        
   
        public GameObject  transicao_tela; // pega ui
        public GameObject  transicao_canvas; // nao pega ui
        public Image  transicao_tela_imagem;
        public Image  transicao_canvas_imagem; 

        public Coroutine coroutine_tela;
        public Action start_transition_rise;
        public Action end_transition_rise;


        public Action start_transition_down;
        public Action end_transition_down;



        // public Bloco[] blocos_sequencia = new Bloco[10];


          
        public bool em_transicao = false ;
        public Bloco modo_tela_em_transicao = Bloco.nada;





        
        public void Verificar_req( Req_transicao _req ){ if(_req == null ){throw new ArgumentException("req em controlador_transicao.Mudar_bloco veio null");}}






        public void Mudar_bloco(){


                Req_transicao req = dados_blocos.req_transicao;

                em_transicao = true;

                modo_tela_em_transicao = req.novo_bloco;

                if( coroutine_tela != null ){

                        Mono_instancia.Stop_coroutine( coroutine_tela );
                        coroutine_tela = null;
                }




                switch( req.tipo_transicao ){

                
                        case Tipo_transicao.cor: coroutine_tela =  Mono_instancia.Start_coroutine(  Transicao_cor( req ) );  break; 
                        case Tipo_transicao.instantaneo:  Transicao_instantaneo( req ) ;  break;

                }

                return;

        }

        /*


                os blocos sempre vao ter containers que nunca vão ser apagados 
        
        */


        
        public void Deletar_bloco( Bloco _bloco_para_excluir ){

                
                GameObject canvas = GameObject.Find("Tela/Canvas");
                int numero_blocos = canvas.transform.childCount;
                int numero_blocos_sem_a_transicao = numero_blocos - 1;
                string modo_tela_nome = Convert.ToString(_bloco_para_excluir);

                bool foi_achado = false;

                for(int i = 0 ;  i < numero_blocos_sem_a_transicao ; i++){


                        string modo_tela_para_comparar = canvas.transform.GetChild( i ).name.ToLower();
                        
                        if(  modo_tela_para_comparar != modo_tela_nome  ) { continue; }

                        Transform bloco_para_excluir_componentes_transform = canvas.transform.GetChild( i );

                        int numero_objs = bloco_para_excluir_componentes_transform.childCount;

                        for( int game_object_index = 0 ; game_object_index < numero_objs ; game_object_index++ ){

                                GameObject obj_para_destruir = bloco_para_excluir_componentes_transform.GetChild( game_object_index ).gameObject;
                                GameObject.Destroy( obj_para_destruir );

                        }

                        foi_achado = true;
                        break;

                }


                if ( !foi_achado ) throw new ArgumentException("nao foi achado modo tela para excluir, veio: " + modo_tela_nome);


                switch( _bloco_para_excluir ){

                        case Bloco.visual_novel: jogo.bloco_visual_novel.Finalizar(); break;
                        
                }


                
        }



        
        // public void Finalizar_transicao_novo_bloco(){

                

        
        //         Action lidar_retorno = null;
                
        //         switch( novo_bloco ){

        //                 case Bloco.visual_novel: lidar_retorno = controlador.bloco_visual_novel.Lidar_retorno ;  break;
        //                 case Bloco.plataforma: lidar_retorno = controlador.bloco_plataforma.Lidar_retorno ; break;
        //                 case Bloco.jogo: lidar_retorno = controlador.bloco_jogo.Lidar_retorno ;break;

        //         }

        //         if(lidar_retorno != null) lidar_retorno();
    



        //         return;

        // }


        /*

        iniciar => 
        deletar => 
        
        */








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




        public void Iniciar_bloco ( Bloco _novo_bloco , Tipo_troca_bloco _tipo){

                

                /*  

                        O iniciar_bloco ou Lidar_retorno vai mudar a Req_UI. E vai ativar no final 
                 
                */



//                Mudar_UI( _novo_bloco , _tipo );

                Criar_tela( _novo_bloco );
                Esconder_telas_nao_utilizadas( _novo_bloco ) ;


                //bool[] partes = Controlador_data.Pegar_instancia().Pegar_UI_partes_default( _novo_bloco );

                
                em_transicao = false;
                dados_blocos.req_transicao = null; 




                if(   _tipo == Tipo_troca_bloco.OUT   )
                
                        {


                                Player_estado_atual.Pegar_instancia().Voltar_modo_tela(); 

                                Action lidar_retorno = null;

                                switch( _novo_bloco ) {

                                        case Bloco.visual_novel: lidar_retorno = jogo.bloco_visual_novel.Lidar_retorno ; break ;
                                        

                                }



                                lidar_retorno() ;

                        
                        } 
                        else
                        {

                                if(   _tipo == Tipo_troca_bloco.SWAP   )
                                        {Player_estado_atual.Pegar_instancia().Voltar_modo_tela(); }


                                Bloco novo_bloco = modo_tela_em_transicao;
                                Player_estado_atual.Pegar_instancia().Adicionar_modo_tela( novo_bloco ); 


                                

                                switch( _novo_bloco ){

                                        
                                        case Bloco.visual_novel: jogo.bloco_visual_novel.Iniciar_bloco_visual_novel(); break;

                                }

                        

                        }

                
                
                // Req_mudar_UI req_ui = dados_blocos.req_mudar_UI;
                // Controlador_UI.Pegar_instancia().Mudar_UI();


                // Req_mudar_input req_input = dados_blocos.req_mudar_input;
                // Controlador_input.Mudar_input();





                

                modo_tela_em_transicao = Bloco.nada;


                return;  


        }


        public void Esconder_telas_nao_utilizadas(Bloco _modo_tela){

                GameObject canvas = GameObject.Find("Tela/Canvas");
                int numero_blocos = canvas.transform.childCount;

                        //    transicao nunca entra
                for(int i = 0 ;  i < numero_blocos - 1 ; i++){

                        string name_1 = canvas.transform.GetChild(i).name.ToLower();
                        string name_2 = Convert.ToString(_modo_tela);

                        if(  name_1 == name_2  ) {

                                canvas.transform.GetChild(i).gameObject.SetActive(true);        
                                continue;
                        }
                        
                        canvas.transform.GetChild(i).gameObject.SetActive(false);

                }

        }



        public void Criar_tela(Bloco _novo_bloco){


                string nome_bloco =  Convert.ToString(_novo_bloco );

                char[] nome_char = nome_bloco.ToCharArray();
                nome_char[0] = char.ToUpper(nome_char[0]);
                nome_bloco = new string(  nome_char  );
                GameObject canvas = GameObject.Find("Tela/Canvas");
                



                if(GameObject.Find("Tela/Canvas/" + nome_bloco) != null) return;
                GameObject novo_bloco = new GameObject(nome_bloco);
                novo_bloco.transform.SetParent(canvas.transform, false);
                int numero_blocos = canvas.transform.childCount;

                novo_bloco.transform.SetSiblingIndex(numero_blocos - 2);

        }

        public bool Verificar_se_tela_existe(string _nome_tela){

                return false;
            //    bool tela_exste = Verificar_se_tela_existe("Cenas");

        }




        public void Transicao_instantaneo ( Req_transicao _req ){


                GameObject game_object = this.transicao_canvas;
                Image game_object_imagem = this.transicao_canvas_imagem;
                
                game_object_imagem.color = new Color(0f,0f,0f,1f);
                game_object.SetActive(false);


                _req.start_transition_rise();
                _req.end_transition_rise();



                if( _req.bloco_para_excluir  !=  Bloco.nada ){ Deletar_bloco ( _req.bloco_para_excluir ) ; }
                Iniciar_bloco( _req.novo_bloco , _req.tipo_troca_bloco  ) ;



                _req.start_transition_down() ;
                _req.end_transition_down() ;

                return;

        }


        public IEnumerator Transicao_cor ( Req_transicao _req){

                bool vai_esconder_ui  =  _req.pega_ui;

                GameObject game_object = this.transicao_canvas;
                Image game_object_imagem = this.transicao_canvas_imagem;

                if( vai_esconder_ui ) { 

                        game_object = this.transicao_tela; 
                        game_object_imagem = this.transicao_tela_imagem;
                }

                _req.start_transition_rise();
                
                game_object.SetActive(true);

                game_object_imagem.color = Color.clear;

                float a_dif = 0.01f;

                while(game_object_imagem.color.a <  0.98f){

               
                        game_object_imagem.color = new Color(0f,0f,0f,  game_object_imagem.color.a + a_dif );
                        yield return null;

                }


                game_object_imagem.color = new Color(0f,0f,0f,1f);

                
                yield return null;

               // yield return new WaitForSeconds(0.25f);

                _req.end_transition_rise(); 

                

                if( _req.bloco_para_excluir  !=  Bloco.nada ){ Deletar_bloco ( _req.bloco_para_excluir ) ; }

                Iniciar_bloco( _req.novo_bloco  , _req.tipo_troca_bloco  ) ;



                
                _req.start_transition_down();               

                a_dif = -0.01f;

                while(game_object_imagem.color.a > 0.5f){

                
                        game_object_imagem.color = new Color(0f,0f,0f,  game_object_imagem.color.a + a_dif );
                        yield return null;

                }                

                a_dif = -0.1f;
                while(game_object_imagem.color.a > 0.05f){

                        game_object_imagem.color = new Color(0f,0f,0f,  game_object_imagem.color.a + a_dif );
                        yield return null;

                }


                game_object_imagem.color = new Color(0f,0f,0f,0f);
                game_object.SetActive(false);
             
                coroutine_tela = null;
                _req.end_transition_down() ;

                yield break;

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






