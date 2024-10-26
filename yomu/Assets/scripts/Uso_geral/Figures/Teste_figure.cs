using System;
using UnityEngine;
using UnityEngine.UI;






public class Teste_figure : INTERFACE__figure {

        // ** somente a parte visual

        public static Figure Construct(){ return CONSTRUCTOR__figure.Construct( new Teste_figure() ); }

        // ** todo path inicia no começo do contexto/main_folder
        // ** isso faz com que coisas que são muito reutilizavais possam ficar em pastas especificas



        public Resource_context Get_context(){ return Resource_context.Characters; }
        public string Get_main_folder(){ return "Lily"; }
        public string Get_figure_name(){ return "Clothes"; }




        // --- IMAGE LIST

        // ** sempre vao ter prealloc como nada 
        // ** cada Figure_image_component vai ter outra copia que pode mudar o recurso de acordo com a necessidade

        public bool resources_loaded;

        public RESOURCE__image_ref body_1;
        public RESOURCE__image_ref body_2;

        public RESOURCE__image_ref head_1;

    
        public void Load_resources( Figure _figure,  Figure_use_context _context_figure ){


                Figure_data_getter f_getter = new Figure_data_getter();
                f_getter.Put_data( Get_context(), Get_main_folder(), _context_figure );
                
    
                body_1 = f_getter.Get_image_reference( "Clothes/lily_clothes_body_1" );
                body_2 = f_getter.Get_image_reference( "Clothes/body_2" );

                resources_loaded = true;

                return;

        }


        public string figure_path;
        public GameObject current_prefab;


        // --- FIGURES MODES 

        // ** MAD

            public GameObject mad_prefab;
            public GameObject mad_container;


                public Figure_image_component[] mad_figure_images = new Figure_image_component[ 10 ];
                public Figure_audio_component[] mad_figure_audios = new Figure_audio_component[ 10 ];


                public void Instanciate_MAD( Figure _figure ){


                        CONTROLLER__errors.Verify( !!!( resources_loaded ), $"Tried to instanciate figure { Get_figure_name() } but it was not loaded" );

                        if( mad_prefab == null )
                            { 
                                //mark 
                                // ** prefabs precisam ser pegos de uma classe propria

                                string path = System.IO.Path.Combine( Get_context().ToString(), Get_main_folder(), Get_figure_name(), "Mad" );
                                mad_prefab = Resources.Load<GameObject>( path ); 
                                if( mad_prefab == null )
                                    { Console.LogError( $"Nao chou prefab no path { path }" ); }

                            }

                        if( mad_container != null )
                            { return; }

                        mad_container  = GameObject.Instantiate( mad_prefab );
                        mad_container.name = mad_prefab.name;
                        mad_container.transform.SetParent( _figure.figure_container.transform, false );

                        // *** INSTANCIATE

                        int index = 0;
                        mad_figure_images[ index++ ] = FIGURE.Get_figure_image_component( mad_container, "Body", body_1 );
                        //mad_figure_images[ index++ ] = FIGURE.Get_figure_image_component( mad_container, "Head", head_1 );
                        
                        return;

                }

                

        // ** sad 
        public GameObject sad_prefab;
        public GameObject sad_container;



        public void Change_form( Figure _figure, GameObject _new_game_object ){


                // ** coroutine? 
                // depois tem que ter uma pequena transicao

                if( current_prefab == null )
                    {
                        // ** sem transicao
                        _new_game_object.SetActive( true );
                        current_prefab = _new_game_object;
                        return;
                    }

                current_prefab.SetActive( false );
                _new_game_object.SetActive( true );
                current_prefab = _new_game_object;


        }



        public Figure_resources_data Get_resources_data( Figure _figure, string _form ){

                switch( _form ){

                    case "mad": return Figure_resources_data.Create( _game_object_form: mad_container, _instanciate: Instanciate_MAD, _images: mad_figure_images, _audios: null );

                    default: CONTROLLER__errors.Throw( $"form { _form } not found in the figure { Get_figure_name() }" ); return new Figure_resources_data();;

                }

                

        }
        



        public void Update( Figure _figure  ){  }
        public void Blink( Figure _figure ){  }
        public void Speak( Figure _figure ){  }


        

        public void Active_action( Figure _figure, string _action ){  }
        


}