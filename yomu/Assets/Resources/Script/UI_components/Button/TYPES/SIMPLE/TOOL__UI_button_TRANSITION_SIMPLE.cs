using UnityEngine;

public static class TOOL__UI_button_TRANSITION_SIMPLE {



        private const float time_seed = 2f;
    
        public static void Handle_transition_animation_OFF_to_ON_color( UI_button_SIMPLE botao ){

                
                if( !!!( botao.esta_houver ) ) 
                    { botao.animacao_atual_tempo_ms -= ( time_seed * ( Time.deltaTime * 1000f ) ); }
                    
                botao.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; 


                if( botao.animacao_atual_tempo_ms < 0.5f )
                    { TOOL__UI_button_SET_SIMPLE.SET_ON_static( botao ); return; } // --- FINALIZAR


                float rate = (  1f -  ( botao.animacao_atual_tempo_ms  / botao.data.time_transition_OFF_to_ON ) );

                // Debug.Log( $"rate: { rate }" );
                
                Change_colors( botao, botao.data.button_OFF_frame.color, botao.data.button_OFF_text_color, botao.data.button_ON_frame.color, botao.data.button_ON_text_color, rate );
                return;


        }



        public static void Handle_transition_animation_ON_to_OFF_color( UI_button_SIMPLE botao ){

                if( ( botao.esta_houver ) ) 
                    {  botao.animacao_atual_tempo_ms -= ( time_seed * ( Time.deltaTime * 1000f ) ); }
                    
                botao.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; 


                if( botao.animacao_atual_tempo_ms < 0.5f )
                    { TOOL__UI_button_SET_SIMPLE.SET_OFF_static( botao ); return; } // --- FINALIZAR


                float rate = (  1f -  ( botao.animacao_atual_tempo_ms  / botao.data.time_transition_ON_to_OFF ) );

                
                Change_colors( botao, botao.data.button_ON_frame.color, botao.data.button_ON_text_color, botao.data.button_OFF_frame.color, botao.data.button_OFF_text_color, rate );
                return;

        }


        private static void Change_colors( UI_button_SIMPLE botao,  Color _color_image, Color _color_image_text, Color _color_transition, Color _color_transition_text, float rate ){



                // ** COR FRAME ATUAL
                Color sprite_color   =  COLOR.Blend_color_with_rate(   _color_image, _color_transition, rate );
                Color text_color   =  COLOR.Blend_color_with_rate(   _color_image_text, _color_transition_text, rate );

                sprite_color.a *= rate;
                text_color.a *= rate;


                // ** MUDA TRANSICAO
                botao.TRANSITION_body.image.color = sprite_color;
                botao.TRANSITION_text.tmp_text.color = text_color;


                float novo_valor = 1f;

                if( rate > 0.95f )
                    { novo_valor = ( 1.2f - rate ); } // --- QUASE NO FINAL => tem que alterar alpha 

                
                sprite_color.a  = novo_valor ;
                text_color.a  = novo_valor ;


                // ** MUDA IMAGEM ATRAS 
                botao.IMAGE_body.image.color = sprite_color;
                botao.IMAGE_text.tmp_text.color = text_color;


                return;


        }
                

}