using UnityEngine;


// ** criado no declare
public struct MANAGER__UI_button_resources_SIMPLE {


        // ** this is really bad
        // ** prefere RESOURCE__ref to make this operations


        public UI_button_SIMPLE button;
        public Resources_minimun_levels minimun;




        // ** carrega minimo em todos os recursos

        public void Load(){ Generic_action( Resource_action.load ); } // ** prepara
        public void Activate(){ Generic_action( Resource_action.activate ); } // ** prepara
        public void Instanciate(){ Generic_action( Resource_action.instanciate ); } // ** prepara
        

        public void Unload(){ Generic_action( Resource_action.unload ); } // volta para o nada
        public void Deactivate(){ Generic_action( Resource_action.deactivate ); } // ** volta para o minimo
        public void Deinstanciate(){ Generic_action( Resource_action.deinstanciate ); } // ** volta para o minimo
        



        public void Delete(){

            ref DATA__UI_button_SIMPLE data = ref button.data;

            // ** AUDIO
            
            data.audio_click?.Delete();
            data.audio_click = null;

            data.audio_houver?.Delete();
            data.audio_houver = null;

            // ** IMAGES
            data.button_OFF_frame.image_ref?.Delete();
            data.button_OFF_frame.image_ref = null;
            
            data.button_ON_frame.image_ref?.Delete();
            data.button_ON_frame.image_ref = null;
            

        }


        public void Generic_action( Resource_action _action ){

            ref DATA__UI_button_SIMPLE data = ref button.data;

            // ** AUDIO

            data.audio_click?.Activate_resource_action( _action );
            data.audio_houver?.Activate_resource_action( _action );

            // ** IMAGES
            
            data.button_OFF_frame.image_ref?.Activate_resource_action( _action );
            data.button_ON_frame.image_ref?.Activate_resource_action( _action );
        
        } 

    
}