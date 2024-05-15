using UnityEngine;
using System;




public class BLOCO_movimento {


      
    public static BLOCO_movimento instancia;
    public static BLOCO_movimento Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("BLOCO_movimento")) { instancia = new BLOCO_movimento();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new BLOCO_movimento(); instancia.Iniciar(); }
            return instancia;

    }


    public Controlador_dados_dinamicos dados;

    public Controlador_cursor controlador_cursor;

    public Controlador_tela_movimento controlador_tela_movimento;

    public Controlador_interativos controlador_interativos;

    ///public Controlador_movimento controlador_movimento;

    public Controlador_utilidades controlador_utilidades;

    //public Controlador_conversas controlador_conversas;

    public GameObject canvas_jogo; 


    public Player_estado_atual player_estado_atual;


    public Dados_blocos dados_blocos;
    
    public float[] posicao_mouse;
    public Controlador_data controlador_data;
    


   
    public Jogo_update_tipo update_tipo_atual = Jogo_update_tipo.movimento;

    public Action Lidar_retorno;
    public Action Colocar_UI_atual; 
    public Action Colocar_input_atual; 







    public void Zerar_dados(){

    }

    




        public void Iniciar(){


     

                controlador_interativos = Controlador_interativos.Pegar_instancia(true);
                controlador_tela_movimento = Controlador_tela_movimento.Pegar_instancia(true);


                ///controlador_movimento = Controlador_movimento.Pegar_instancia(true);
                controlador_utilidades = Controlador_utilidades.Pegar_instancia(true);
                //controlador_conversas = Controlador_conversas.Pegar_instancia(true);

                controlador_cursor = Controlador_cursor.Pegar_instancia( true );

                Controlador_jogo_data.Pegar_instancia( true );
                controlador_data = Controlador_data.Pegar_instancia( true );
                posicao_mouse = controlador_data.posicao_mouse;



                player_estado_atual = Player_estado_atual.Pegar_instancia(true);
                dados_blocos = Dados_blocos.Pegar_instancia(true);

                Colocar_UI_atual = Colocar_UI_bloco_movimento.Default ;
                Colocar_input_atual  = Colocar_input_bloco_movimento.Default ;


                canvas_jogo = GameObject.Find("Tela/Canvas/Jogo");

                Lidar_retorno = Lidar_retorno_bloco_movimento.Default;

                //canvas_jogo.SetActive(true);



        }


        public void Iniciar_jogo(){

             //  jogo sempre so inicia 1 vez 


                Jogo_START dados = dados_blocos.jogo_START;

                    
                controlador_tela_movimento.Trocar_tela(player_estado_atual.Pegar_path_imagem_background());
                controlador_interativos.Criar_interativos(player_estado_atual.ponto_atual);

                bool eh_novo_jogo = dados.eh_novo_jogo;



                // isso nao faz sentido ficar aqui


                // if ( eh_novo_jogo ){  

                //     Iniciar_primeiro_jogo() ; 
                //     dados.eh_novo_jogo = false;
                // }

                Colocar_UI_atual();
                Colocar_input_atual();

                return;
    
        }




        public string audio_path = "audio/geral_sfx/botoes/click_4";



        public void Update(){ 


            if(Input.GetKeyDown(KeyCode.Escape)){
                
                    Voltar_player();
                    return;

            } 


            Verificar_mouse( Input.GetMouseButtonDown(0) );







            if(  Controlador_input.Get_down(Key_code.mouse_left)  )  Controlador_audio.Pegar_instancia().Acrecentar_sfx( audio_path );




            switch( update_tipo_atual ){
               
                ///case Jogo_update_tipo.movimento : controlador_movimento.Update() ; break;
                case Jogo_update_tipo.utilidades : controlador_utilidades.Update() ; break;
                //case Jogo_update_tipo.conversas : controlador_conversas.Update() ; break;

            }


        }



    public void Verificar_mouse(bool _is_click){


            Interativo[] interativos_arr = controlador_interativos.interativos_arr;
            int numero_interativos = interativos_arr.Length;

            
            for(  int i = 0;  i < numero_interativos ;  i++  ){

                bool verificacao =  Mat.Verificar_ponto_dentro_poligono( posicao_mouse , interativos_arr[i].area );
                

                if(verificacao) {

                  

                        if(_is_click) {

                                controlador_interativos.Tirar_hover_interativo( i ) ;  
                                controlador_interativos.Ativar_interativo( i );
                                controlador_interativos.interativo_atual_hover = -1;

                                return;
                        }

                        if(i == controlador_interativos.interativo_atual_hover) return;

                        if(controlador_interativos.interativo_atual_hover != -1   ) {  controlador_interativos.Tirar_hover_interativo(controlador_interativos.interativo_atual_hover ) ;  }

                        controlador_interativos.interativo_atual_hover = i;

                        controlador_cursor.Mudar_cursor( interativos_arr[i].cor_cursor ) ; 

                        controlador_interativos.Ativar_hover_interativo(i);

                        return;

                } else  if( interativos_arr[i].hover_esta_ativo == true )  { 
                        
                        controlador_interativos.Tirar_hover_interativo( controlador_interativos.interativo_atual_hover ) ; 

                }

    
            }

                if(controlador_interativos.interativo_atual_hover != -1) {  


                        
                        controlador_interativos.Tirar_hover_interativo( controlador_interativos.interativo_atual_hover ); 
                        controlador_interativos.interativo_atual_hover = -1;
                        controlador_cursor.Mudar_cursor(Cor_cursor.off);
                        return; 

                }


                return;







    }





                             //   trocar para ponto_nome

     public void Mover_player( Ponto_nome _ponto_nome , bool _reset = false , bool _instantaneo = false ){




            int _ponto_id  = (int) _ponto_nome;
           
            Ponto ponto = Controlador_jogo_data.Criar_ponto( _ponto_nome );


            controlador_interativos.Criar_interativos(  ponto );

            controlador_interativos.Limpar_sprite_interativos( player_estado_atual.interativos );

            player_estado_atual.Acrecentar_posicao( ponto , _reset );

           

           
            Script_jogo_nome script_entrada = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.lista_scripts_por_entrar_ponto[_ponto_id];

            Scripts_jogo.Ativar_script( script_entrada );

            controlador_interativos.interativo_atual_hover = -1;
            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

            
            //  usa player_estado_atual

            controlador_tela_movimento.Trocar_tela( player_estado_atual.Pegar_path_imagem_background() , _instantaneo);

            return;

      }




    public void Voltar_player(){


                // Debug.Log( "veio voltar" );

                // Debug.Log("===============");

                // for( int i = 0 ; i < player_estado_atual.posicao_arr.Length ; i++  ){

                //         Debug.Log( "indice " + i + " com valor: " + player_estado_atual.posicao_arr[ i ]);

                // }




                Ponto_nome novo_ponto_id =  player_estado_atual.Pegar_posicao_anterior();
                Ponto_nome ponto_atual_id = player_estado_atual.Pegar_posicao_atual();

                // Debug.Log("posicao atual: " + ponto_atual_id);

                if( novo_ponto_id == ponto_atual_id ) { return;}

        
                Ponto novo_ponto = Controlador_jogo_data.Criar_ponto( (Ponto_nome) novo_ponto_id);
                
                
                player_estado_atual.Acrecentar_posicao( novo_ponto );
                

                Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);
                controlador_tela_movimento.Trocar_tela(player_estado_atual.Pegar_path_imagem_background());
                controlador_interativos.Criar_interativos(novo_ponto);

                
                // Debug.Log("===============");

                // for( int i = 0 ; i < player_estado_atual.posicao_arr.Length ; i++  ){

                //         Debug.Log( "indice " + i + " com valor: " + player_estado_atual.posicao_arr[ i ]);

                // }



      }








}