using UnityEngine;
using System;




public class BLOCO_conector {

        // --- INSTANCIA
        public static BLOCO_conector instancia;
        public static BLOCO_conector Pegar_instancia(){ return instancia; }


        // --- CONTROLADORES
        public Controlador_cursor controlador_cursor;
        public Controlador_tela_conector controlador_tela_conector;
        public Controlador_interativos controlador_interativos;
        public Controlador_dados controlador_dados;



        ///public Controlador_movimento controlador_movimento;
        public Controlador_utilidades controlador_utilidades;

        //public Controlador_conversas controlador_conversas;


        // --- DADOS
        
        public GameObject container_conector; // ** talvez mudar o nome 
        public Player_estado_atual player_estado_atual;
        public float[] posicao_mouse;
        public Jogo_update_tipo update_tipo_atual = Jogo_update_tipo.movimento;
        public string audio_path = "audio/geral_sfx/botoes/click_4"; // ** mudar





        public Action Lidar_retorno;
        public Action Colocar_UI_atual; 
        public Action Colocar_input_atual; 





        public static BLOCO_conector Iniciar_bloco_conector(){

                if( instancia != null )
                        { throw new Exception( "tentou iniciar o bloco: <color=red>CONECTOR</color> mas a instancia nao estava null" ); }

                instancia = new BLOCO_conector();
                instancia.Iniciar();
                return instancia;

        }

        public void Iniciar(){

                // --- TELA

                container_conector = GameObject.Find( "Tela/Canvas/Jogo/Conector" );


                // -- CONTROLADORES

                controlador_interativos = Controlador_interativos.Construir();
                controlador_tela_conector = Controlador_tela_conector.Construir();
                controlador_utilidades = Controlador_utilidades.Pegar_instancia();
                controlador_cursor = Controlador_cursor.Pegar_instancia();
                controlador_dados = Controlador_dados.Pegar_instancia();


                // --- COISAS
                posicao_mouse = controlador_dados.posicao_mouse;
                player_estado_atual = Player_estado_atual.Pegar_instancia();


                // --- UI / INPUT / RETORNO

                Colocar_UI_atual = Colocar_UI_bloco_conector.Default ;
                Colocar_input_atual  = Colocar_input_bloco_conector.Default ;
                Lidar_retorno = Lidar_retorno_bloco_conector.Default;
                // ** talves colocar na req
                Colocar_UI_atual();
                Colocar_input_atual();

                // INICIAR 

                Conector_START dados = Dados_blocos.conector_START;

                if( dados == null )
                        { throw new Exception( "nao veio os dados para iniciar conector" ); }

                // ver depois
                // controlador_tela_conector.Trocar_tela( player_estado_atual.Pegar_path_imagem_background() ); 

                
                // ** trocar depois
                controlador_interativos.Criar_interativos( new Ponto() );
                //controlador_interativos.Criar_interativos( player_estado_atual.ponto_atual );


                return;

        }

  

        public static void Finalizar(){

                instancia = null;

                Controlador_interativos.instancia = null;
                Controlador_tela_conector.instancia = null;
                Controlador_utilidades.instancia = null;
                Controlador_cursor.instancia = null;
                Controlador_dados.instancia = null;
                
                return;

        }



        public void Update(){ 

                //Debug.Log("veio update movimento");


                if(Input.GetKeyDown(KeyCode.Escape))
                        {
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

        public Interativo[] Criar_interativos( Ponto _p ){ return null; } // deletar



        public void Verificar_mouse(bool _is_click){


                Interativo[] interativos_arr =  new Interativo[ 0 ] ; //controlador_interativos.interativos_arr;
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

        public void Mover_player( Posicao _ponto , bool _reset = false , bool _instantaneo = false ){



                // int _ponto_id  = (int) _ponto_nome;
                
                // Ponto ponto = Controlador_jogo_data.Criar_ponto( _ponto_nome );


                // controlador_interativos.Criar_interativos(  ponto );
                // controlador_interativos.Limpar_sprite_interativos( player_estado_atual.interativos );
                // player_estado_atual.Acrecentar_posicao( ponto , _reset );

                
                // // ** TEM QUE SER DENTO DO BLOCO MOVIMENTO 
                // // Script_jogo_nome script_entrada = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.lista_scripts_por_entrar_ponto[_ponto_id];
                // // Scripts_jogo.Ativar_script( script_entrada );


                // controlador_interativos.interativo_atual_hover = -1;
                // Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

                
                // //  usa player_estado_atual
                // controlador_tela_conector.Trocar_tela( player_estado_atual.Pegar_path_imagem_background() , _instantaneo);

                // return;

        }




        public void Voltar_player(){


                // Debug.Log( "veio voltar" );

                // Debug.Log("===============");

                // for( int i = 0 ; i < player_estado_atual.posicao_arr.Length ; i++  ){

                //         Debug.Log( "indice " + i + " com valor: " + player_estado_atual.posicao_arr[ i ]);

                // }




                // Ponto_nome novo_ponto_id =  player_estado_atual.Pegar_posicao_anterior();
                // Ponto_nome ponto_atual_id = player_estado_atual.Pegar_posicao_atual();

                // // Debug.Log("posicao atual: " + ponto_atual_id);

                // if( novo_ponto_id == ponto_atual_id ) { return;}


                // Ponto novo_ponto = Controlador_jogo_data.Criar_ponto( (Ponto_nome) novo_ponto_id);
                
                
                // player_estado_atual.Acrecentar_posicao( novo_ponto );
                

                // Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);
                // controlador_tela_conector.Trocar_tela(player_estado_atual.Pegar_path_imagem_background());
                // controlador_interativos.Criar_interativos(novo_ponto);

                
                // Debug.Log("===============");

                // for( int i = 0 ; i < player_estado_atual.posicao_arr.Length ; i++  ){

                //         Debug.Log( "indice " + i + " com valor: " + player_estado_atual.posicao_arr[ i ]);

                // }



        }



}