


using UnityEngine;

public struct Figure_mode_activate_data{

    public bool force;
    public Figure_mode_direction start_direction;
    public Combined_images_type_render type_render;
    
}



// ** STATE
public abstract partial class FIGURE_MODE {


        public void Delete(){

                resources_container.Delete_all_resources();
                combined_images?.Delete();
                combined_images_transition?.Delete();

        }

        public void Destroy(){}



        //mark
        // ** mudar de lugar depois


        private ref Figure_mode__DIRECTION Get_direction( Figure_mode_direction _direction ){ return ref directions[ ( int ) _direction ];}


            private void Force_finish_transition_DIRECTION_to_DIRECTION(){

                // ** garante que a transicao mode -> mode termine

            }



        public void Activate( Figure_mode_activate_data _data ){

            
            // ** STATE
            if( state == Figure_mode_state.activated )
                { 
                    // ** talvez faça a troca para o start_direction
                    return; 
                }

            state = Figure_mode_state.activated;

            // ** CONTENT
            Instanciate_content();


            // ** GENERIC DATA

            if( _data.type_render != Combined_images_type_render.not_give )
                { combined_images.Set_type( _data.type_render ); }
            
            

            // ** FIRST DIRECTION
            
            if( _data.start_direction != Figure_mode_direction.not_give )
                { _data.start_direction = _data.start_direction; }
                else
                { _data.start_direction = Get_default_direction(); } // ** O DAFAULT NAO É PARA SER USADO, ALÉM DE TESTE / CARREGAR

                current_direction = _data.start_direction;
                transition_direction = _data.start_direction;


            ref Figure_mode__DIRECTION direction = ref Get_direction( current_direction );
            
            direction.main.Put_sprites();

            combined_images.Set_structure( direction.structure, direction.image_dimension );
            combined_images.Print();
        
            return;

        }


        public void Deactivate(){

            state = Figure_mode_state.inactivate;
            combined_images.Return_quad_container();
            combined_images.Turn_camera( Switch.OFF );

        }


    
}

