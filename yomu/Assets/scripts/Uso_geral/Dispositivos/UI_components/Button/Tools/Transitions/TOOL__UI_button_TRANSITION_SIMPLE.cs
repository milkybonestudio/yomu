using UnityEngine;

public static class TOOL__UI_button_TRANSITION_SIMPLE {



        private const float time_seed = 2f;
    
        public static void Handle_transition_animation_OFF_to_ON_color( Botao_dispositivo botao ){

                
                if( !!!( botao.esta_houver ) ) 
                    { Console.Log( "NAO esta houver" ); botao.animacao_atual_tempo_ms -= ( time_seed * ( Time.deltaTime * 1000f ) ); }
                    
                botao.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; 

                Console.Log( $"tempo restante: { botao.animacao_atual_tempo_ms }" );

                if( botao.animacao_atual_tempo_ms < 0.5f )
                    { TOOL__UI_button_SET_SIMPLE.SET_ON_static( botao ); return; } // --- FINALIZAR


                float rate = (  1f -  ( botao.animacao_atual_tempo_ms  / botao.data.time_transition_OFF_to_ON_SIMPLE ) );

                Debug.Log( $"rate: { rate }" );
                
                Change_colors( botao, botao.data.simple_button_OFF_frame.color, botao.data.simple_button_OFF_text_color, botao.data.simple_button_ON_frame.color, botao.data.simple_button_ON_text_color, rate );
                return;


        }



        public static void Handle_transition_animation_ON_to_OFF_color( Botao_dispositivo botao ){

                if( ( botao.esta_houver ) ) 
                    {  Console.Log( "ESTA houver" ); botao.animacao_atual_tempo_ms -= ( time_seed * ( Time.deltaTime * 1000f ) ); }
                    
                botao.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; 

                Console.Log( $"tempo restante: { botao.animacao_atual_tempo_ms }" );


                if( botao.animacao_atual_tempo_ms < 0.5f )
                    { TOOL__UI_button_SET_SIMPLE.SET_OFF_static( botao ); return; } // --- FINALIZAR


                float rate = (  1f -  ( botao.animacao_atual_tempo_ms  / botao.data.time_transition_ON_to_OFF_SIMPLE ) );

                Debug.Log( $"rate: { rate }" );
                
                Change_colors( botao, botao.data.simple_button_ON_frame.color, botao.data.simple_button_ON_text_color, botao.data.simple_button_OFF_frame.color, botao.data.simple_button_OFF_text_color, rate );
                return;


                return;

        }




        private static void Change_colors( Botao_dispositivo botao,  Color _color_image, Color _color_image_text, Color _color_transition, Color _color_transition_text, float rate ){



                // ** COR FRAME ATUAL
                Color sprite_color   =  COLOR.Blend_color_with_rate(   _color_image, _color_transition, rate );
                Color text_color   =  COLOR.Blend_color_with_rate(   _color_image_text, _color_transition_text, rate );

                sprite_color.a *= rate;
                text_color.a *= rate;

                Console.Log( $"alpha { sprite_color.a }" );


                // ** MUDA TRANSICAO
                botao.TRANSITION_simple_body.image.color = sprite_color;
                botao.TRANSITION_simple_text.tmp_text.color = text_color;



                float novo_valor = -1;

                if( rate > 0.95f )
                    { novo_valor = ( 1.2f - rate ); } // --- QUASE NO FINAL => tem que alterar alpha 
                    else
                    { novo_valor =      1f;         } // --- AINDA NO INICIO

                
                sprite_color.a  = novo_valor ;
                text_color.a  = novo_valor ;


                // ** MUDA IMAGEM ATRAS 
                botao.IMAGE_simple_body.image.color = sprite_color;
                botao.IMAGE_simple_text.tmp_text.color = text_color;


                return;


        }
                

}