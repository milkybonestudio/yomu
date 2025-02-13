using UnityEngine;


// ** criado no declare
public struct MANAGER__UI_button_resources_COMPLETE {



        public UI_button_COMPLETE button;
        public Resources_minimun_levels minimun;




        // ** carrega minimo em todos os recursos

        public void Load(){ Generic_action( Resource_action.load ); } // ** prepara
        public void Activate(){ Generic_action( Resource_action.activate ); } // ** prepara
        

        public void Unload(){ Generic_action( Resource_action.unload ); } // volta para o nada
        public void Deactivate(){ Generic_action( Resource_action.deactivate ); } // ** volta para o minimo
        public void Deinstanciate(){ Generic_action( Resource_action.deinstanciate ); } // ** volta para o minimo
        



        public void Delete(){

            ref DATA__UI_button_COMPLETE data = ref button.data;

            // ** AUDIO
            data.audio_click?.Delete();
            data.audio_click = null;
            
            data.audio_houver?.Delete();
            data.audio_houver = null;

            
            // ** IMAGES

            throw new System.Exception( "tem que fazer" );

            // data.button_OFF_frame.image_ref?.Delete( ref data.button_OFF_frame.image_ref );
            // data.button_ON_frame.image_ref?.Delete( ref data.button_ON_frame.image_ref );
            

        }


        public void Generic_action( Resource_action _action ){

            ref DATA__UI_button_COMPLETE data = ref button.data;

            // ** AUDIO

            data.audio_click?.Activate_resource_action( _action );
            data.audio_houver?.Activate_resource_action( _action );

            // ** IMAGES

            throw new System.Exception( "tem que fazer" );
            
            // data.button_OFF_frame.image_ref?.Activate_resource_action( _action );
            // data.button_ON_frame.image_ref?.Activate_resource_action( _action );
        
        } 

    
}