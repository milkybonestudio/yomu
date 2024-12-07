using UnityEngine;


// ** criado no declare
public struct MANAGER__UI_button_resources {



        public UI_button button;
        public Resources_minimun_levels minimun;




        // ** carrega minimo em todos os recursos

        public void Load(){ Generic_action( Resource_action.load ); } // ** prepara
        public void Activate(){ Generic_action( Resource_action.activate ); } // ** prepara
        

        public void Unload(){ Generic_action( Resource_action.unload ); } // volta para o nada
        public void Deactivate(){ Generic_action( Resource_action.deactivate ); } // ** volta para o minimo
        public void Deinstanciate(){ Generic_action( Resource_action.deinstanciate ); } // ** volta para o minimo
        



        public void Delete(){

            ref DATA__UI_button data = ref button.data;

            // ** AUDIO
            data.audio_click?.Delete( ref data.audio_click );
            data.audio_houver?.Delete( ref data.audio_houver );

            // ** IMAGES
            
                 if( button.type == UI_button_type.simple )
                    {
                        data.simple_button_OFF_frame.image_ref?.Delete( ref data.simple_button_OFF_frame.image_ref );
                        data.simple_button_ON_frame.image_ref?.Delete( ref data.simple_button_ON_frame.image_ref );
                    }
            else if( button.type == UI_button_type.complete )
                    {
                        for( int ui_part = 0 ; ui_part < ( int ) Device_button_animation_part.animation_decoration ; ui_part++ ){
                                
                            if( ui_part == ( int ) Device_button_animation_part.animation_text )
                                { continue; }

                            data.complete_button_OFF_frames[ ui_part ].image_ref?.Delete( ref data.complete_button_OFF_frames[ ui_part ].image_ref );
                            data.complete_button_ON_frames[ ui_part ].image_ref?.Delete( ref data.complete_button_ON_frames[ ui_part ].image_ref );


                        }
                    }
            else if( button.type == UI_button_type.complete )
                    {
                        CONTROLLER__errors.Throw( "Ainda tem que fazer" );
                    }

        }


        public void Generic_action( Resource_action _action ){

            ref DATA__UI_button data = ref button.data;

            // ** AUDIO

            data.audio_click?.Activate_resource_action( _action );
            data.audio_houver?.Activate_resource_action( _action );

            // ** IMAGES
            
                 if( button.type == UI_button_type.simple )
                    {
                        data.simple_button_OFF_frame.image_ref?.Activate_resource_action( _action );
                        data.simple_button_ON_frame.image_ref?.Activate_resource_action( _action );
                    }
            else if( button.type == UI_button_type.complete )
                    {
                        for( int ui_part = 0 ; ui_part < ( int ) Device_button_animation_part.animation_front_text ; ui_part++ ){
                                
                            if( ui_part == ( int ) Device_button_animation_part.animation_text )
                                { continue; }

                            data.complete_button_OFF_frames[ ui_part ].image_ref?.Activate_resource_action( _action );
                            data.complete_button_ON_frames[ ui_part ].image_ref?.Activate_resource_action( _action );


                        }
                    }
            else if( button.type == UI_button_type.complete )
                    {
                        CONTROLLER__errors.Throw( "Ainda tem que fazer" );
                    }


        } 

    
}