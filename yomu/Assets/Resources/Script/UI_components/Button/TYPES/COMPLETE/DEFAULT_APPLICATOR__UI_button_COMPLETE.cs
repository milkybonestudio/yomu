

public class DEFAULT_APPLICATOR__UI_button_COMPLETE {

        public static void Apply_default( UI_button_COMPLETE _button ){

                    // --- TIMEs

                    _button.creation_data.tempo_transicao = 75f;
                    _button.Activate = VOID.Metodo_nao_colocado;


                    // --- RESOURCES

                    _button.data.context = Resource_context.Devices; 
                    

                    _button.manager_resources.minimun.image = ( _button.data.image_resource_pre_allocation == Resource_image_content.not_give ) ? ( Resource_image_content.compress_data ) : ( _button.data.image_resource_pre_allocation );
                    _button.manager_resources.minimun.audio = ( _button.data.audio_resource_pre_allocation == Resource_audio_content.not_give ) ? ( Resource_audio_content.audio_clip ) : ( _button.data.audio_resource_pre_allocation );

                    _button.manager_resources.button = _button;


        }

}
