

public class DEFAULT_APPLICATOR__UI_button_SIMPLE {

        public static void Apply_default( UI_button_SIMPLE _button ){

                    // --- TIMEs

                    _button.creation_data.tempo_transicao = 75f;
                    _button.creation_data.Activate = ()=>{};


                    // --- RESOURCES

                    if( _button.creation_data.context == Resource_context.not_given )
                        { _button.creation_data.context = Resource_context.Devices; }

    
                    _button.creation_data.image_resource_pre_allocation = Resource_image_content.compress_data;
                    _button.creation_data.audio_resource_pre_allocation = Resource_audio_content.audio_clip;
                    _button.manager_resources.minimun.audio = ( _button.data.audio_resource_pre_allocation == Resource_audio_content.not_give ) ? ( Resource_audio_content.audio_clip ) : ( _button.data.audio_resource_pre_allocation );


                    // _button.manager_resources.minimun.image = ( _button.data.image_resource_pre_allocation == Resource_image_content.not_give ) ? ( Resource_image_content.compress_data ) : ( _button.data.image_resource_pre_allocation );
                    // _button.manager_resources.minimun.audio = ( _button.data.audio_resource_pre_allocation == Resource_audio_content.not_give ) ? ( Resource_audio_content.audio_clip ) : ( _button.data.audio_resource_pre_allocation );

                    _button.manager_resources.button = _button;


        }

}
