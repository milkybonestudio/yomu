using System;
using UnityEngine;
using UnityEngine.UI;






public class Teste_figure : Figure {


        public Teste_figure( Figure_use_context _context ){


                
                resources_context =  Resource_context.Characters;
                main_folder = "Lily";
                figure_name = "Clothes";

                
                structure = CONTROLLER__resources.Get_instance().resources_structures.Get_structure_copy( resources_context, main_folder, "Figures/Clothes", Resource_structure_content.game_object );



                Figure_data_getter f_getter = new Figure_data_getter();
                f_getter.Put_data( resources_context, main_folder, _context );
                

                body_1 = f_getter.Get_image_reference( "Clothes/lily_clothes_body_1" );
                body_2 = f_getter.Get_image_reference( "Clothes/body_2" );

                return;

        }



        public override void Update(){}

    

        // --- IMAGE LIST

        // ** sempre vao ter prealloc como compress_low_quality 
        // ** cada Figure_image_component vai ter outra copia que pode mudar o recurso de acordo com a necessidade

        public RESOURCE__image_ref body_1;
        public RESOURCE__image_ref body_2;

        public RESOURCE__image_ref head_1;


        public string figure_path;
        public GameObject current_prefab;


        // --- FIGURES MODES 

        // ** MAD

            public GameObject mad_prefab;
            public GameObject mad_container;


                public Figure_image_component[] mad_figure_images = new Figure_image_component[ 10 ];
                public Figure_audio_component[] mad_figure_audios = new Figure_audio_component[ 10 ];


                public void Instanciate_MAD( Figure _figure ){}

                

        // ** sad 
        public GameObject sad_prefab;
        public GameObject sad_container;



        public void Change_form( Figure _figure, GameObject _new_game_object ){


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

                    default: CONTROLLER__errors.Throw( $"form { _form } not found in the figure { figure_name }" ); return new Figure_resources_data();;

                }

                

        }
        


        public void Active_action( Figure _figure, string _action ){  }
        


}