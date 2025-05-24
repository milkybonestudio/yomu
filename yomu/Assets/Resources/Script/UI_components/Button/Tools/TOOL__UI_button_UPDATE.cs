using UnityEngine;

public static class TOOL__UI_button_UPDATE {


        public static void Update_logica( UI_button _button ){

                
                if( _button.bloquear_update_logico )
                    { return; } // --- CAN NOT UPDATE


                // --- VERIFICAR HOUVER
                if( _button.esta_houver )
                    {
                        // --- VERIFICA SE MOUSE CONTINUA NO BOTAO
                        _button.esta_houver = Polygon.Check_point_inside( _button.ON_collider.points, ( Vector2 ) _button.body.body_container.transform.position , CONTROLLER__input.Pegar_instancia().pointer_position );
                    
                        if( !!!( _button.esta_houver ) )
                            { _button.esta_down = false; return; } // --- SAIU
                    }
                    else
                    { 
                        // --- VERIFICA SE ENTROU
                        _button.esta_houver = Polygon.Check_point_inside( _button.OFF_collider.points, ( Vector2 ) _button.body.body_container.transform.position , CONTROLLER__input.Pegar_instancia().pointer_position ); 
                        
                        
                        if( !!!( _button.esta_houver ) )
                            { return; } // --- NAO ENTROU
                            
                        // --- VERIFICA SE EH TIPO ENTRADA
                        if( _button.activation_type == UI_button_activation_type.entrar_no_botao )
                            { _button.Activate(); return; } // --- ATIVAR BOTAO
            
                    } 


                // --- VERIFICAR DOWN

                if( Input.GetMouseButtonDown( 0 ) )
                    { 
                        _button.esta_down = true; 
                        if( _button.activation_type == UI_button_activation_type.clicar )
                            { _button.Activate(); } // --- ATIVAR BOTAO
                        
                    }


                if( Input.GetMouseButtonUp( 0 ) && _button.esta_down )
                    { 
                        // --- ATIVA SOMENTE QUANDO DEU DOWN ANTERIORMENTE
                        if( _button.activation_type == UI_button_activation_type.clicar_e_soltar && _button.esta_down )
                            { _button.Activate(); } // --- ATIVAR BOTAO

                    }


                if( !!!( Input.GetMouseButton( 0 ) ) )
                    { _button.esta_down = false; }


        }



        

}