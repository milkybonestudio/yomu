using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;




public struct Figure_mode_visual {

    // usado no material

    public Color main_color;
    public Color actual_color_material;
    



}



/*

    perguntas: quem controla o material?
        como figure vai dar Update em todos os modos talvez valha mais a pena deixar a logica aqui?

*/


public abstract class Figure_mode {


        // ** vai ser chamado no dicionario
        public void Set_figure_mode_structure( string _path_to_structs, Resource_structure_content _level_re_allocation ){ structure = figure_interface.figure_getter_object.Get_structure_copy( ( _path_to_structs + "/" + visual_figure.ToString() ), _level_re_allocation );}

        
        public bool activated;
        public string name;
        

        protected Figure figure_interface;
        public Figure_mode_type visual_figure;
        

        public Resource_structure_content level_re_allocation;
        public RESOURCE__structure_copy structure;

        
        public RESOURCE__combined_image combined_images;
        public Material material;


        private State_link state_link;
        public int index_link_atual = -1;


        public Resources_container resources_container = Resources_container.Get();

        public Figure_mode_main main;
        public Figure_mode_animation_SIMPLE mouth_animation;
        public Figure_mode_animation_SIMPLE eyes_animation;
        
        public Figure_emojis emojis = Figure_emojis.Get(); // ** talvez nao precise sempre


        public abstract void Link_resources_main(); // ** so pode ser chamado quando a struct estiver carregada
        
        
        private int update = 0;
        public virtual void Update(){

            
                // --- VERIFY

                update += eyes_animation.Check_resources();
                update += mouth_animation.Check_resources();
                update += main.Check_resources();
                update += emojis.Update();



                if( !!!( activated ) )
                    { return; }

                //mark
                // ** guaranty_links aqui fica meio estranho, pode deixar para pegar somente quando precisar?
                // ** os recursos não precisam dos links para funcionar 
                // ** isso esta deixando muito confuso

                if( ( state_link == State_link.waiting_for_struct ) && ( structure.structure.actual_content >= Resource_structure_content.structure_data ) )
                    { Guaranty_links(); }


                update += mouth_animation.Update();
                update += eyes_animation.Update();

                if( update > 0 )
                    {  combined_images.Change(); }

                update = 0;


        }



        public virtual void Instanciate(){


                activated = true;

                if( !!!( figure_interface.have_place ) )
                    { CONTROLLER__errors.Throw( $"Do not set the figure <Color=lightBlue>{ figure_interface.figure_getter_object.path_root }</Color>" ); }
            

                Guaranty_links();

                structure.Set( true );

                Prepare_resources();

                main.Put_sprites();


                if( combined_images != null )
                    {
                        // --- JA PEGOU AS IMAGES COMBINED -> DEU FREE
                        combined_images.Retake_render();
                    }
                    else
                    {

                        material = new Material( Shaders.individual_components );
                        combined_images = CONTROLLER__resources.Get_instance().resources_combined_images.Get_combined_image( material, structure.structure_game_object, main.images_links  );

                        // ** ADD EMOJIS
                        emojis.container_emojis.transform.SetParent( combined_images.render.container_images.transform, false );
                        

                        combined_images.render.container_images.transform.SetParent( figure_interface.structure_container.transform, false );
                        combined_images.render.container_images.name = visual_figure.ToString();
                    }

                return;

        }


        public void Delete(){


                resources_container.Delete();
                combined_images.Delete();


        }



        public virtual void Hide(){

            activated = false;

        }


        // --- RESOURCES
            
            public virtual void Reduce(){

                    // ** libera os recursos
                    // ** tem que tomar cuidado qundo usar, nao vale a pena na maiorira dos cenarios, somente em vn longas

                    Free_resources();
                    combined_images.Free(); // ** 

                
            }


            public virtual void Prepare(){ 

                    //performance
                    // ** prepare não precisa fazer os links na hora, pois o sistema já esta falando os dados necessarios para as imagens 
                    // ** forçar os links faz sentido no editor pois consegue ver se algo existe ou não antes de precisar usar. 
                    // ** se em algum lugar fizer a instancia de 500 modos ele não vai finalizar sem antes ter verificado todos
                    // ** mas isso nao faz sentido 

                    Guaranty_links();
                    resources_container.Activate();

                    
            }



    // --- STATIC IMAGE

        protected void Link( string _component, RESOURCE__image_ref _resource_image ){


                Unity_main_components unity_components = structure.Get_components( _component );

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

                    return;

            }




        // --- EMOJIS 

            // ** coracaozinho, puto, depresso etc

            public virtual void Link_emoji(){

                    Unity_main_components unity_components = structure.Get_components( "Emoji" );
                    emojis.container_emojis = unity_components.game_object;
            }    


            public virtual void Activate_emoji( Figure_emoji _emoji ){


                    if( emojis.container_emojis == null )
                        { return; }

                    emojis.Add_emoji( _emoji );

                    update = 1;

                    return;
                    
            }


        // --- EFFECTS



        private enum State_link {

            waiting_for_struct,
            done,

        }




        private void Prepare_resources(){


                    resources_container.Activate(); // -> carregar tudo
                        main.resources_state = Figure_mode_resoruces_state.getting_resources;
                        mouth_animation.resources_state = Figure_mode_resoruces_state.getting_resources;
                        mouth_animation.resources_state = Figure_mode_resoruces_state.getting_resources;

        }
        private void Free_resources(){


                    resources_container.Deactivate(); // ** vai para o minimo das refs, se outro modo tiver as mesmas imagens ativas nao vai fazer nada, pois ainda vai ter pelo menos 1 ref como ac
                        main.resources_state = Figure_mode_resoruces_state.off;
                        mouth_animation.resources_state = Figure_mode_resoruces_state.off;
                        mouth_animation.resources_state = Figure_mode_resoruces_state.off;

        }


        


        private void Guaranty_links(){


            if( index_link_atual > -1 )
                { return; } // --- ja pegou os links

            structure.Instanciate( _container: null, _set: false );
            
            Link_resources_main();
            state_link = State_link.done;

        }




}

