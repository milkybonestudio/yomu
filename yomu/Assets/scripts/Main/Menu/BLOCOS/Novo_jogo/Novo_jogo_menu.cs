using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Novo_jogo_menu {



        public GameObject novo_jogo_container;
        public Menu_objects_generico[] novo_jogo_arr = new Menu_objects_generico[ 1 ];
        public Menu_objects_generico novo_jogo;


        public void Update(){


            float mouse_x = ( Controlador_dados.Pegar_instancia().posicao_mouse[ 0 ] - 960f );
            float mouse_y = ( Controlador_dados.Pegar_instancia().posicao_mouse[ 1 ] - 540f );


            novo_jogo.image.color = Cores.Pegar_cor( Nome_cor.dark_2 );

            float x_min  =  novo_jogo.rect.localPosition[ 0 ] - ( novo_jogo.rect.rect.width / 2 ) ;
            float x_max  =  novo_jogo.rect.localPosition[ 0 ] + ( novo_jogo.rect.rect.width / 2 ) ;
                
            float y_min  =  novo_jogo.rect.localPosition[ 1 ] - ( novo_jogo.rect.rect.height / 2 ) ;
            float y_max  =  novo_jogo.rect.localPosition[ 1 ] + ( novo_jogo.rect.rect.height / 2 ) ;



            if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   )   ){

                novo_jogo.image.color = Color.white;
                if( Controlador_input.Get_down(Key_code.mouse_left))
                    { Ativador_novo_jogo_menu.Ativar_novo_jogo(); }
                    
            }

            
            return;

        }







}