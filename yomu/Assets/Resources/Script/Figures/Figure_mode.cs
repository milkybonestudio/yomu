using UnityEngine.UI;




public abstract class Figure_mode {



        // ** vai ser chamado no dicionario
        public void Set_figure_mode_structure( string _path_to_structs, Resource_structure_content _level_re_allocation ){

                
                figure_mode = figure_interface.figure_getter_object.Get_structure_copy( ( _path_to_structs + "/" + visual_figure.ToString() ), _level_re_allocation );

        }

    
        protected Figure figure_interface;
        public Figure_mode_type visual_figure;
        
        public bool activated = false;

        public Resource_structure_content level_re_allocation;
        public RESOURCE__structure_copy figure_mode;
        public Figure_visual_emotion_state state;


        private State_link state_link;


        public Resource_state current_stae_resources;


        public Emotion_figure_animation_SIMPLE mouth_animation;
        public Emotion_figure_animation_SIMPLE eyes_animation;
        public Emotion_figure_animation_MULTIPLES body_animation;

        public Figure_mode_resources resources;

        public int link_index = 0;

        

        // ** so pode ser chamado quando a struct estiver carregada
        public abstract void Link_resources_main();
        

        // ** animations
        public virtual void Link_resources_mouth_animation(){ /*nao tem*/ }
        public virtual void Link_resources_eyes_animation(){  /*nao tem*/ }
        public virtual void Link_resources_body_animation(){  /*nao tem*/ }

        
        public void Guaranty_links(){

            if( link_index > 0 )
                { return; }

            Link_resources_main();

        }

        public void Update_material(){ resources.Update_material( figure_interface.material ); }


        // ** logic
        public virtual void Instanciate(){

                activated = true;
                figure_mode.Instanciate( figure_interface.container );
                Guaranty_links();

                resources.Put_sprites();

        }



        public virtual void Prepare(){ 

                figure_mode.Instanciate( _container: figure_interface.container, _set: false );
                Guaranty_links();
                resources.Prepare(); 

        }



        public virtual void Deactivate(){
                activated = false;

        }


        public virtual void Update(){


                if( !!!( activated ) )
                    { return; }

                if( ( state_link == State_link.waiting_for_struct ) && ( figure_mode.structure.actual_content >= Resource_structure_content.structure_data ) )
                    { Link_resources_main(); state_link = State_link.done; }

                // --- UPDATE BLINK
                // --- UPDATE MOUTH
                // --- UPDATE UNIQUE


        }



        public virtual void Blick(){

            if( eyes_animation.resources_images == null )
                { return; } // --- DONT HAVE

            if( eyes_animation.number_loops != eyes_animation.current_loop )
                { return; } // --- ja esta em um loop
            
            eyes_animation.current_loop = 0;

        }

        public virtual void Speak(){}

        public virtual void Stand(){ 
            // ** se tiver algo vai ficar dentro da classe em especifico
         }


        

        protected void Link( string _component, RESOURCE__image_ref _resource_image ){


                resources.images_links[ link_index ] = new Figure_mode_image_link   {
                                                                                        image_component = figure_mode.Get_component_image( _component ), 
                                                                                        resource_image = _resource_image
                                                                                    };

                

                resources.images_links[ link_index  ].resource_image.image.name = "FIGURE_IMAGE";
                resources.images_links[ link_index  ].image_component.material = figure_interface.material;

                link_index++;

        }
        

        private enum State_link {

            waiting_for_struct,
            done,

        }



}

