using UnityEngine;
using UnityEngine.UI;




        public struct Speak_data { 

            public int loops;

        }


public abstract class Figure_mode {



        // ** vai ser chamado no dicionario
        public void Set_figure_mode_structure( string _path_to_structs, Resource_structure_content _level_re_allocation ){ figure_mode = figure_interface.figure_getter_object.Get_structure_copy( ( _path_to_structs + "/" + visual_figure.ToString() ), _level_re_allocation );}

    
        public bool activated;
        

        protected Figure figure_interface;
        public Figure_mode_type visual_figure;
        

        public Resource_structure_content level_re_allocation;
        public RESOURCE__structure_copy figure_mode;
        public Figure_visual_emotion_state state;

        public RESOURCE__combined_image combined_images;


        private State_link state_link;


        public Resource_state current_stae_resources;


        public Figure_mode_animation_SIMPLE mouth_animation;
        public Figure_mode_animation_SIMPLE eyes_animation;
        public Figure_mode_animation_MULTIPLES body_animation;

        public Figure_mode_main main;

        public Resources_container resources_container = Resources_container.Get();

        public int index_link_atual = -1;

        

        // ** so pode ser chamado quando a struct estiver carregada
        public abstract void Link_resources_main();
        

        // ** animations
        public virtual void Link_resources_mouth_animation(){ /*nao tem*/ }
        public virtual void Link_resources_eyes_animation(){  /*nao tem*/ }
        public virtual void Link_resources_body_animation(){  /*nao tem*/ }

        
        private void Guaranty_links(){


            if( index_link_atual > -1 )
                { return; } // --- ja pegou os links

            figure_mode.Instanciate( _container: figure_interface.container, _set: false );
            Link_resources_main();
            state_link = State_link.done;

        }

        public void Update_material(){ main.Update_material( figure_interface.material ); }


        // ** logic
        public virtual void Instanciate(){

                activated = true;
                Guaranty_links();
                figure_mode.Set( true );
                main.Put_sprites();

                combined_images = CONTROLLER__resources.Get_instance().resources_combined_images.Get_combined_image( figure_mode.structure_game_object, main.images_links  );
                

        }



        public virtual void Prepare(){ 

                Guaranty_links();
                resources_container.Activate();
                
        }



        public virtual void Deactivate(){

                activated = false;

        }

        

        public virtual void Update(){

                
                // --- VERIFY

                int update = 0;
                update += mouth_animation.Check_resources();
                update += main.Check_resources();


                if( Input.GetKeyDown( KeyCode.N ) )
                    { Speak( new Speak_data(){ loops = 10 } ); }


                if( !!!( activated ) )
                    { return; }

                if( ( state_link == State_link.waiting_for_struct ) && ( figure_mode.structure.actual_content >= Resource_structure_content.structure_data ) )
                    { Guaranty_links(); }


                update += mouth_animation.Update();

                if( update > 0 )
                    {  combined_images.Change(); }


        }


        public virtual void Speak( Speak_data _data ){

            if( mouth_animation.resources_images == null )
                { return; } // --- DONT HAVE

            // ** depois vai dar problemas, tem que fazer a transicao entre um e outro
            if( mouth_animation.number_loops != mouth_animation.current_loop )
                { return; } // --- ja esta em um loop

            
            mouth_animation.current_loop = 0;
            mouth_animation.number_loops = _data.loops;

        }

        

        public virtual void Blick(){

            if( eyes_animation.resources_images == null )
                { return; } // --- DONT HAVE

            if( eyes_animation.number_loops != eyes_animation.current_loop )
                { return; } // --- ja esta em um loop
            
            eyes_animation.current_loop = 0;

        }

        

        public virtual void Stand(){ 
            // ** se tiver algo vai ficar dentro da classe em especifico
         }


        

        protected void Link( string _component, RESOURCE__image_ref _resource_image ){


                Unity_main_components unity_components = figure_mode.Get_components( _component );

                index_link_atual++;

                main.images_links[ index_link_atual ] = new Image_link {
                                                                                sprite_render = unity_components.sprite_render, 
                                                                                game_object = unity_components.game_object,
                                                                                resource_ref = _resource_image
                                                                            };

                

                main.images_links[ index_link_atual  ].resource_ref.image.name = "FIGURE_IMAGE";
                main.images_links[ index_link_atual  ].sprite_render.material = figure_interface.material;

                resources_container.Add( _resource_image );


        }
        

        protected void Link_mouth( string _component, RESOURCE__image_ref[] _refs ){


                Link( _component, _refs[ 0 ] );

                mouth_animation.sprite_render = main.images_links[ index_link_atual ].sprite_render;
                mouth_animation.resources_images = _refs;

                resources_container.Add_multiples( _refs, 1 );


            

        }

        private enum State_link {

            waiting_for_struct,
            done,

        }



}


