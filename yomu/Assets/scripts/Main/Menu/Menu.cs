using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;



public class Menu { 


        public static Menu instancia;
        public static Menu Pegar_instancia(){ return instancia; }
        public static Menu Construir(){ instancia = new Menu(); return instancia;}
        


        // todas vao ser deletadas quando o meu for destruido;
        public Chave_cache[] chaves_imagens;


        // --- CONTROLADORES

        public Controlador_tela_menu controlador_tela_menu;

        public Tipo_menu_background menu_background;
            
        // --- BLOCOS

        public Galeria_menu galeria_menu;
        public Personagens_menu personagens_menu;
        public Configuracoes_menu configuracoes_menu;
        public Novo_jogo_menu novo_jogo_menu;
        public Saves_menu saves_menu;



        public Action[] updates;




        // --- OPCOES

        public GameObject opcoes_container;
        public Menu_objects_generico[] menu_opcoes_arr = new Menu_objects_generico[5];
        public Botao[] botoes = new Botao[ 5 ];



        public Menu_bloco estado_atual = Menu_bloco.novo_jogo;        
        public Controlador_dados controlador_dados;

            


        public void Update(){

            bool esta_nos_botoes = Update_botoes();

            if( esta_nos_botoes )
                { return; }
            
            switch(estado_atual){


                    case Menu_bloco.transicao: break;
                    case Menu_bloco.novo_jogo: novo_jogo_menu.Update(); break;
                    case Menu_bloco.configuracoes: configuracoes_menu.Update(); break;

                    case Menu_bloco.galeria:  galeria_menu.Update(); break;
                    case Menu_bloco.personagens:  personagens_menu.Update(); break;
                    case Menu_bloco.saves: saves_menu.Update(); ; break;
                    
            }

            return;

        }



        public bool Update_botoes(){

            
                bool is_click = Controlador_input.Get_up(Key_code.mouse_left);
                
                for(int i = 0 ;    i <  botoes.Length ;   i++){

                        Botao botao = botoes[i];                    
                        if( botao.Update(  is_click, controlador_dados.posicao_mouse )) { return true; }

                }

                return false ;

        }




    public void Update_generico( Menu_objects_generico[] _arr ){
     
            float mouse_x = controlador_dados.posicao_mouse[0] - 960f;
            float mouse_y = controlador_dados.posicao_mouse[1] - 540f;

            Color cor = Cores.Pegar_cor( Nome_cor.dark_2 );

            for ( int menu_object_index = 0  ; menu_object_index < _arr.Length  ; menu_object_index++ ){

                _arr[ menu_object_index ].image.color = cor;

                float x_min  = ( _arr[ menu_object_index ].rect.localPosition[ 0 ] - ( _arr[ menu_object_index ].rect.rect.width  / 2f ) );
                float x_max  = ( _arr[ menu_object_index ].rect.localPosition[ 0 ] + ( _arr[ menu_object_index ].rect.rect.width  / 2f ) );
                
                float y_min  = ( _arr[ menu_object_index ].rect.localPosition[ 1 ] - ( _arr[ menu_object_index ].rect.rect.height / 2f ) );
                float y_max  = ( _arr[ menu_object_index ].rect.localPosition[ 1 ] + ( _arr[ menu_object_index ].rect.rect.height / 2f ) );


                if(  Mat.Verificar_ponto_dentro_retangulo(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   ) )
                        {

                            _arr[ menu_object_index ].image.color = Color.white;

                            if( Controlador_input.Get_down( Key_code.mouse_left ) ) 
                                { _arr[ menu_object_index ].On_click(); }
                            
                            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.red );

                            return ;
                            
                        }

            }

          Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

        return;

    }




        //mark
        // ** tem que mover para outro lugar
        public static class Sistema_mensagens {

                public static void Alertar_player( string _mensagem ){

                        Debug.Log( "fazer mensagem depois" );
                        Debug.Log( _mensagem );
                        return;

                }

        }







        
        // vai destruir tudo quando iniciar o jogo
        
        public void Zerar_dados(){

                // Mono_instancia.DestroyImmediate(canvas);
                // canvas = null;
                // canvas_menu = null;
                // canvas_menu_movel = null;
                // canvas_menu_image  = null;
                // canvas_menu_rect  = null;
            
        }







     
    
}
