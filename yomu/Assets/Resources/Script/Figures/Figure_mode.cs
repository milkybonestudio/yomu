using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;






public abstract class Figure_mode {



        // ** vai ser chamado no dicionario
        public void Set_figure_mode_structure( string _path_to_structs, Resource_structure_content _level_re_allocation ){ figure_mode = figure_interface.figure_getter_object.Get_structure_copy( ( _path_to_structs + "/" + visual_figure.ToString() ), _level_re_allocation );}

        
        
        public Figure_mode Set( GameObject _game_object ){ figure_interface.Set( _game_object ); return this; }
    
        public bool activated;

        public string name;
        

        protected Figure figure_interface;
        public Figure_mode_type visual_figure;
        

        public Resource_structure_content level_re_allocation;
        public RESOURCE__structure_copy figure_mode;
        public Figure_visual_emotion_state state;

        
        public RESOURCE__combined_image combined_images;

        public GameObject container_emoji;


        private State_link state_link;


        public Resource_state current_stae_resources;


        public Figure_mode_animation_SIMPLE mouth_animation;
        public Figure_mode_animation_SIMPLE eyes_animation;
        public Figure_mode_animation_MULTIPLES body_animation;

        public Figure_mode_main main;

        public Figure_emojis emojis = Figure_emojis.Get(); // ** talvez nao precise sempre

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

            figure_mode.Instanciate( _container: null, _set: false );
            
            Link_resources_main();
            state_link = State_link.done;

        }

        public void Update_material(){ main.Update_material( figure_interface.material ); }


        // ** logic
        public virtual void Instanciate( GameObject _place = null ){

                if( _place != null )
                    { Set( _place ); }

                if( !!!( figure_interface.have_place ) )
                    { CONTROLLER__errors.Throw( $"Do not set the figure <Color=lightBlue>{ figure_interface.figure_getter_object.path_root }</Color>" ); }
            

                activated = true;
                Guaranty_links();
                figure_mode.Set( true );
                main.Put_sprites();


                combined_images = CONTROLLER__resources.Get_instance().resources_combined_images.Get_combined_image( figure_mode.structure_game_object, main.images_links  );

                // ** ADD EMOJIS
                emojis.container_emojis.transform.SetParent( combined_images.render.container_images.transform, false );
                

                combined_images.render.container_images.transform.SetParent( figure_interface.container.transform, false );
                combined_images.render.container_images.name = visual_figure.ToString();

                // *** flag resources

                    main.resources_state = Figure_mode_resoruces_state.getting_resources;
                    mouth_animation.Load_resources();
                    eyes_animation.Load_resources();
                    body_animation.Load_resources();

                

        }



        public virtual void Prepare(){ 

                Guaranty_links();
                resources_container.Activate();

                
        }



        public virtual void Deactivate(){

                activated = false;

        }

        
        private int update = 0;
        public virtual void Update(){

                
                // --- VERIFY

                
                update += eyes_animation.Check_resources();
                update += mouth_animation.Check_resources();
                update += main.Check_resources();
                update += emojis.Update();


                if( Input.GetKeyDown( KeyCode.N ) )
                    { Speak( new Speak_data(){ loops = 10 } ); }


                if( !!!( activated ) )
                    { return; }

                if( ( state_link == State_link.waiting_for_struct ) && ( figure_mode.structure.actual_content >= Resource_structure_content.structure_data ) )
                    { Guaranty_links(); }


                update += mouth_animation.Update();
                update += eyes_animation.Update();

                if( update > 0 )
                    {  combined_images.Change(); }

                update = 0;


        }


    // --- STATIC IMAGE



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
        

        

    // --- ANIMATIONS


        // --- SPEAK

            protected void Link_mouth( string _component, RESOURCE__image_ref[] _refs, Frame_rate _frame_rate ){


                    if( _frame_rate == Frame_rate.not_give )
                        { CONTROLLER__errors.Throw( "was not give the frame rate" ); }

                    mouth_animation.active = true;

                    Link( _component, _refs[ 0 ] );

                    mouth_animation.sprite_render = main.images_links[ index_link_atual ].sprite_render;
                    mouth_animation.resources_images = _refs;

                    mouth_animation.frames_per_second = ( int ) _frame_rate;

                    resources_container.Add_multiples( _refs, 1 );

            }

            public virtual void Speak( Speak_data _data ){


                    if( mouth_animation.resources_images == null )
                        { return; } // --- DONT HAVE
                        
                    mouth_animation.Reset();

                    // // ** depois vai dar problemas, tem que fazer a transicao entre um e outro
                    // if( mouth_animation.number_loops != mouth_animation.current_loop )
                    //     { return; } // --- ja esta em um loop


                    mouth_animation.number_loops = _data.loops;

            }

            

        // --- EYES

        
            protected void Link_eye( string _component, RESOURCE__image_ref[] _refs ){

                    eyes_animation.active = true;
                    
                    Link( _component, _refs[ 0 ] );

                    mouth_animation.sprite_render = main.images_links[ index_link_atual ].sprite_render;
                    mouth_animation.resources_images = _refs;

                    resources_container.Add_multiples( _refs, 1 );


            }


            public virtual void Blick( Blink_data _data ){

                Console.Log( "veio blink" );

                if( eyes_animation.resources_images == null )
                    { return; } // --- DONT HAVE

                if( eyes_animation.number_loops != eyes_animation.current_loop )
                    { return; } // --- ja esta em um loop
                
                eyes_animation.current_loop = _data.loops;

            }




        // --- EMOJIS 

            // ** coracaozinho, puto, depresso etc

            public virtual void Link_emoji(){


                    // ** 
                    Unity_main_components unity_components = figure_mode.Get_components( "Emoji" );

                    emojis.container_emojis = unity_components.game_object;

                    
            }    


            public virtual void Activate_emoji( Figure_emoji _emoji ){

                ///mark
                // ** depois talvez puxar das configs, isso pode ser bom como um parametro de dificuldade

                if( emojis.container_emojis == null )
                    { return; }

                emojis.Add_emoji( _emoji );

                update = 1;


            }


        // --- EFFECTS



        private enum State_link {

            waiting_for_struct,
            done,

        }



}

public enum Figure_emoji {

        heart,
        mad, 

}


