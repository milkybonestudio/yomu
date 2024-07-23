using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Personagens_menu {


        public GameObject personagens_container;

        public Menu_objects_generico menu_personagens_botao_proximo;
        public Menu_objects_generico menu_personagens_botao_anterior;
        public Menu_objects_generico[] menu_personagens_arr = new Menu_objects_generico[8];
        



        public void Update(){
        
                float mouse_x = Controlador_dados.Pegar_instancia().posicao_mouse[ 0 ]  -  960f;
                float mouse_y = Controlador_dados.Pegar_instancia().posicao_mouse[ 1 ]  -  540f;

                Color cor = Cores.Pegar_cor( Nome_cor.dark_2 );

                for ( int menu_object_index = 0  ; menu_object_index < menu_personagens_arr.Length  ; menu_object_index++ ){

                        menu_personagens_arr[ menu_object_index ].image.color = cor;

                        Menu_objects_generico menu_object_generico = menu_personagens_arr[ menu_object_index ];

                        float x_min  = ( menu_object_generico.rect.localPosition[ 0 ] - ( menu_object_generico.rect.rect.width  / 2f ) );
                        float x_max  = ( menu_object_generico.rect.localPosition[ 0 ] + ( menu_object_generico.rect.rect.width  / 2f ) );
                        
                        float y_min  = ( menu_object_generico.rect.localPosition[ 1 ] - ( menu_object_generico.rect.rect.height / 2f ) );
                        float y_max  = ( menu_object_generico.rect.localPosition[ 1 ] + ( menu_object_generico.rect.rect.height / 2f ) );


                        if(  Mat.Verificar_ponto_dentro_retangulo(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   ) )
                                {

                                    menu_object_generico.image.color = Color.white;

                                    if( Controlador_input.Get_down( Key_code.mouse_left ) ) 
                                        { menu_object_generico.On_click(); }
                                    
                                    Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.red );

                                    return ;
                                    
                                }

                        continue;

                }

            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

            return;

        }



}