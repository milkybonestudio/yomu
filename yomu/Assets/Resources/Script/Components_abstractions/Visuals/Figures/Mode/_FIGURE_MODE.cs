using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


public struct Figure_mode_visual {

    // usado no material
    public Color main_color;
    public Color actual_color_material;
    
}




public enum Figure_mode_direction {


    not_give, 
        
        left, 
        right, 
        front, 
        back, 
        left_back, 
        right_back,

    END,



}



public abstract partial class FIGURE_MODE {


        public FIGURE_MODE(){

            current_content = Figure_mode_content.nothing;
            minimum_content = Figure_mode_content.resources_minimum;
            final_content = Figure_mode_content.nothing;

        }



        public Figure_mode__DIRECTION[] directions = new Figure_mode__DIRECTION[ ( int ) Figure_mode_direction.END ];


        public Figure_mode_state state;
        public string name;
        

        public Figure figure_interface;
        public Figure_mode visual_figure;
        public Figure_type_construct_data data_construction;
        

        // public Resource_structure_content level_re_allocation;
        // public RESOURCE__structure_copy structure;

        
        protected abstract Figure_mode_direction Get_default_direction();

        public RESOURCE__combined_image combined_images;
        public Figure_mode_direction current_direction;

        public RESOURCE__combined_image combined_images_transition;
        public Figure_mode_direction transition_direction;

        public Material material;

        public MANAGER__resources resources_container = new MANAGER__resources();

        public Figure_emojis emojis = Figure_emojis.Get(); // ** talvez nao precise sempre

        
        public virtual void Update(){


            Console.Log( Figure.teste, $"--------Update mode <Color=lightBlue>{ name }</Color> " );
        
            if( state != Figure_mode_state.activated )
                { Update_content(); return; }

            Instanciate_content();

            Get_direction( current_direction ).Update();
            combined_images.Render_update();

            if( transition_direction != current_direction )
                {
                    Get_direction( transition_direction ).Update();
                    combined_images_transition?.Render_update();
                }

        

        }



        public GameObject Get_quad_container(){

            if( state != Figure_mode_state.activated )
                { Activate( new() ); }

            combined_images.camera_output.container_quad.transform.localPosition = new Vector3( 0f,0f,0f );
            return combined_images.camera_output.container_quad;

        }

        public void Return_quad_container(){

            combined_images.Return_quad_container();

        }


        // --- EMOJIS 



            public virtual void Activate_emoji( Figure_mode_emoji _emoji ){


                if( emojis.container_emojis == null )
                    { return; }

                emojis.Add_emoji( _emoji );

                // update = 1;

                return;
                    
            }



}

