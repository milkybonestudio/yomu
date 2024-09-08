using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Novo_jogo_menu {

        public Novo_jogo_menu(){

            int numero_de_interativos = 0;
            
            numero_de_interativos += 1; // quadro
            
            novo_jogo_arr = new Interativo_menu[ numero_de_interativos ];

            return;

        }


        public GameObject novo_jogo_container;
        public Interativo_menu[] novo_jogo_arr;
        public Interativo_menu novo_jogo;


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
                if(  Input.GetMouseButtonDown( 0 ) )
                    { Ativador_novo_jogo_menu.Ativar_novo_jogo(); }
                    
            }

            
            return;

        }







}