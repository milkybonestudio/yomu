using UnityEngine.UI;






public abstract class Emotion_figure {



        // ** vai ser chamado no dicionario
        public void Set_figure_emotion_structure( string _path_to_structs, Resource_structure_content _level_re_allocation ){

                UnityEngine.Debug.Log( "_path_to_structs: " + _path_to_structs );
                figure_emotion = figure_interface.figure_getter_object.Get_structure_copy( ( _path_to_structs + "/" + visual_figure.ToString() ), _level_re_allocation );

        }

    
        protected Figure figure_interface;

        public Visual_figure visual_figure;
        // protected string local_path;

        public bool activated = false;

        public Resource_structure_content level_re_allocation;
        public RESOURCE__structure_copy figure_emotion;
        public Figure_visual_emotion_state state;


        private State_link state_link;


        public Emotion_figure_animation_SIMPLE mouth_animation;
        public Emotion_figure_animation_SIMPLE eyes_animation;
        public Emotion_figure_animation_MULTIPLES body_animation;

        public Emotion_figure_resources resources;

        

        // ** so pode ser chamado quando a struct estiver carregada
        public abstract void Link_resources_main();
        

        // ** animations
        public virtual void Link_resources_mouth_animation(){ /*nao tem*/ }
        public virtual void Link_resources_eyes_animation(){  /*nao tem*/ }
        public virtual void Link_resources_body_animation(){  /*nao tem*/ }




        // ** logic
        public virtual void Activate(){
                activated = true;


        }

        public virtual void Deactivate(){
                activated = false;

        }


        public virtual void Update(){


                if( !!!( activated ) )
                    { return; }

                if( ( state_link == State_link.waiting_for_struct ) && ( figure_emotion.structure.actual_content >= Resource_structure_content.structure_data ) )
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


        public virtual void Link_images(){}
        public virtual void Change_blink(){}
        public virtual void Change_mouth(){}

        // ** vai da um active nos recursos
        public virtual void Prepare(){}



        // ** 

        public int link_index = 0;
        protected void Link( string _component, RESOURCE__image_ref _resource_image ){


                resources.images_links[ link_index++ ] = new Emotion_figure_image_link  {
                                                                                            image_component = figure_emotion.Get_component_image( _component ), 
                                                                                            resource_image = _resource_image
                                                                                        };


        }
        

        private enum State_link {

            waiting_for_struct,
            done,

        }



}

