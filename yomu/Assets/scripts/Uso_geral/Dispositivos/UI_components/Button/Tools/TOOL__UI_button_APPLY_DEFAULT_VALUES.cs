


public static class TOOL__UI_button_APPLY_DEFAULT_VALUES {

    public static Botao_dispositivo Apply( Botao_dispositivo _button  ){

            // --- TIMEs

            _button.data.tempo_transicao = 75f;

            _button.data.Ativar = VOID.Metodo_nao_colocado;


            // --- RESOURCES

            if( _button.data.context == Resource_context.not_given )
                { _button.data.context = Resource_context.Devices; }

            _button.manager_resources.minimun.image = ( _button.data.image_resource_pre_allocation == Resource_image_content.not_give ) ? ( Resource_image_content.compress_data ) : ( _button.data.image_resource_pre_allocation );
            _button.manager_resources.minimun.audio = ( _button.data.audio_resource_pre_allocation == Resource_audio_content.not_give ) ? ( Resource_audio_content.audio_clip ) : ( _button.data.audio_resource_pre_allocation );

            _button.manager_resources.button = _button;


            return _button;

    }

}