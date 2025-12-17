using UnityEngine;

public static class Verificador_click_interativo_menu {

    public static int Verificar( Interativo_menu[] _arr ){
     
            float mouse_x = CONTROLLER__UI.Pegar_instancia().posicao_mouse[0] - 960f;
            float mouse_y = CONTROLLER__UI.Pegar_instancia().posicao_mouse[1] - 540f;

            Color cor = Cores.Pegar_cor( Nome_cor.dark_2 );

            for ( int menu_object_index = 0  ; menu_object_index < _arr.Length  ; menu_object_index++ ){

                _arr[ menu_object_index ].image.color = cor;

                float x_min  = ( _arr[ menu_object_index ].rect.localPosition[ 0 ] - ( _arr[ menu_object_index ].rect.rect.width  / 2f ) );
                float x_max  = ( _arr[ menu_object_index ].rect.localPosition[ 0 ] + ( _arr[ menu_object_index ].rect.rect.width  / 2f ) );
                
                float y_min  = ( _arr[ menu_object_index ].rect.localPosition[ 1 ] - ( _arr[ menu_object_index ].rect.rect.height / 2f ) );
                float y_max  = ( _arr[ menu_object_index ].rect.localPosition[ 1 ] + ( _arr[ menu_object_index ].rect.rect.height / 2f ) );


                if(  Rectangle.Check_point_inside(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   ) )
                        { 

                            _arr[ menu_object_index ].image.color = Color.white;

                            if( Input.GetMouseButtonDown( 0 )  ) 
                                { return menu_object_index; }
                            
                            CONTROLLER__input.Pegar_instancia().manager_cursor.Change_action( Cursor_action.choice ); //Mudar_cursor( Cor_cursor.red );
                             
                            
                        }

                            // return ;
                            
            }


            CONTROLLER__input.Pegar_instancia().manager_cursor.Change_action( Cursor_action.choice ); //Mudar_cursor( Cor_cursor.off );
            return -1;



    }







}