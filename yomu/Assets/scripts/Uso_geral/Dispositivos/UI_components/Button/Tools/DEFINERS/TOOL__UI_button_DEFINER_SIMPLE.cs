using System;
using UnityEngine;


public static class TOOL__UI_button_DEFINER_SIMPLE {


        private static Device_button_animation_part[] animation_parts = ( Device_button_animation_part[] ) Enum.GetValues( typeof( Device_button_animation_part ) );
        private static int numero_de_partes = Enum.GetNames( typeof( Device_button_animation_part ) ).Length;



        public static UI_button Define( UI_button botao ){


                ref DATA__UI_button _dados = ref botao.data;

                // --- VERIFICATIONS

                if( _dados.tipo_transicao == DEVICE_button_transition_type_OFF_ON.animacao_individual )
                    { CONTROLLER__errors.Throw( $"Button { botao.button_name } came in Define_button_SIMPLE but the type was animation" ); }

                if( _dados.simple_button_OFF_frame.path == null )
                    { CONTROLLER__errors.Throw( $"Image path was not put in the button { botao.button_name } no OFF" ); }

                if( ( _dados.simple_button_ON_frame.path != null ) && (  _dados.OFF_and_ON_equal ) )
                    { CONTROLLER__errors.Throw( $"button { botao.button_name } is set as <Color=lightBlue>OFF_and_ON_equal</Color> but in the OFF path is <Color=lightBlue>{ _dados.simple_button_ON_frame.path }</Color>" ); }

                if( ( _dados.simple_button_ON_frame.path == null ) && ( !!!( _dados.OFF_and_ON_equal ) ) )
                    { CONTROLLER__errors.Throw(  $"Image path was not put in the button <Color=lightBlue>{ botao.button_name }</Color> on <Color=lightBlue>ON</Color>" ); }


                _dados.animacao_ON_para_OFF_tempos.tempo_espera_para_ativar_ms = _dados.tempo_transicao;
                _dados.animacao_OFF_para_ON_tempos.tempo_espera_para_ativar_ms = _dados.tempo_transicao;

                
                if( _dados.time_transition_ON_to_OFF_SIMPLE == 0 )
                    { _dados.time_transition_ON_to_OFF_SIMPLE = _dados.tempo_transicao; }

                if( _dados.time_transition_OFF_to_ON_SIMPLE == 0 )
                    { _dados.time_transition_OFF_to_ON_SIMPLE = _dados.tempo_transicao; }

                if( _dados.OFF_and_ON_equal )
                    { _dados.simple_button_ON_frame = _dados.simple_button_OFF_frame; }

                
                MANAGER__resources_images resources_image = CONTROLLER__resources.Get_instance().resources_images;

                // OFF 
                    _dados.simple_button_OFF_frame.image_ref = resources_image.Get_image_reference( _dados.context, _dados.main_folder, _dados.simple_button_OFF_frame.path, botao.manager_resources.minimun.image );
                    _dados.simple_button_OFF_frame.color = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.simple_button_OFF_frame.color, Cores.grey_90 );
                    _dados.simple_button_OFF_text_color = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.simple_button_OFF_text_color, Cores.black );

                // ON
                    _dados.simple_button_ON_frame.image_ref = resources_image.Get_image_reference( _dados.context, _dados.main_folder, _dados.simple_button_ON_frame.path, botao.manager_resources.minimun.image  );
                    _dados.simple_button_ON_frame.color = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.simple_button_ON_frame.color, Cores.white );
                    _dados.simple_button_ON_text_color = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.simple_button_ON_text_color, Cores.black );


                return botao;


        }


}