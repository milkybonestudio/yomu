using UnityEngine;
using System;



// BLOCO_CONECTOR SEMPRE VAI EXISTIR 
// ele pode ter um pouco mais de responsabilidade
// todos os scripts relacionado ao jogo assumem que ele existe 

public class BLOCO_conector {


        // --- INSTANCIA

        public static BLOCO_conector instancia;
        public static BLOCO_conector Pegar_instancia(){ return instancia; }


        // --- DEFAULT BLOCOS

        public Action Lidar_retorno;
        public Action Finalizar;

        // *** Se nao vier UI ou Input usa sempre o default

        public Action Colocar_UI_atual; 
        public Action Colocar_input_atual; 


        // --- CONTROLADORES
        public Controlador_cursor controlador_cursor;
        public Controlador_tela_conector controlador_tela_conector;
        public Controlador_interativos controlador_interativos;
        public Controlador_dados controlador_dados;
        public Controlador_movimento controlador_movimento;

        public Controlador_personagens controlador_personagens;



        // --- DADOS
        
        public GameObject container_conector; // ** talvez mudar o nome 
        public Player_estado_atual player_estado_atual;
        public float[] posicao_mouse;

        public BLOCO_conector_update update_tipo_atual = BLOCO_conector_update.interacao;

        public string audio_path = "audio/geral_sfx/botoes/click_4"; // ** mudar



        public void Update(){ 


                // --- VERIFICA SE TEM QUE MUDAR TELA

                
                controlador_tela_conector.Verificar_movimento_player();


                switch( update_tipo_atual ){

                        case BLOCO_conector_update.nada: throw new Exception( "veio nada no update BLOCO_conector" );
                        case BLOCO_conector_update.interacao: Update_interacao(); break;
        
                }

                return;


        }





        public void Update_interacao(){


                if(Input.GetKeyDown(KeyCode.Escape))
                        {
                                //controlador_movimento.Voltar_player();
                                return;
                        }
                

                Verificar_mouse( Input.GetMouseButtonDown(0) );


                if(  Controlador_input.Get_down(Key_code.mouse_left)  )  Controlador_audio.Pegar_instancia().Acrecentar_sfx( audio_path );


        }



        public Interativo[] Criar_interativos( Ponto _p ){ return null; } // deletar



        public void Verificar_mouse( bool _is_click ){


                // Interativo[] interativos_arr =  new Interativo[ 0 ] ; //controlador_interativos.interativos_arr;
                // int numero_interativos = interativos_arr.Length;

                
                // for(  int i = 0;  i < numero_interativos ;  i++  ){

                // bool verificacao =  Mat.Verificar_ponto_dentro_poligono( posicao_mouse , interativos_arr[i].area );
                

                // if(verificacao) {

                        

                //         if(_is_click) {

                //                 controlador_interativos.Tirar_hover_interativo( i ) ;  
                //                 controlador_interativos.Ativar_interativo( i );
                //                 controlador_interativos.interativo_atual_hover = -1;

                //                 return;
                //         }

                //         if(i == controlador_interativos.interativo_atual_hover) return;

                //         if(controlador_interativos.interativo_atual_hover != -1   ) {  controlador_interativos.Tirar_hover_interativo(controlador_interativos.interativo_atual_hover ) ;  }

                //         controlador_interativos.interativo_atual_hover = i;

                //         controlador_cursor.Mudar_cursor( interativos_arr[i].cor_cursor ) ; 

                //         controlador_interativos.Ativar_hover_interativo(i);

                //         return;

                // } else  if( interativos_arr[i].hover_esta_ativo == true )  { 
                        
                //         controlador_interativos.Tirar_hover_interativo( controlador_interativos.interativo_atual_hover ) ; 

                // }


                // }

                // if(controlador_interativos.interativo_atual_hover != -1) {  


                        
                //         controlador_interativos.Tirar_hover_interativo( controlador_interativos.interativo_atual_hover ); 
                //         controlador_interativos.interativo_atual_hover = -1;
                //         controlador_cursor.Mudar_cursor(Cor_cursor.off);
                //         return; 

                // }


                // return;







        }





 


}