using UnityEngine;
using UnityEngine.UI;

public static class FIGURE {


        public static Figure_image_component Get_figure_image_component( GameObject _mode, string _name_component, RESOURCE__image_ref _image_ref ){


                CONTROLLER__errors.Verify( ( _image_ref.ref_state == RESOURCE__image_ref_state.deleted ), $"Tried to get the figure image in the component { _name_component } but the image was null" );

                if( _image_ref.level_pre_allocation == Resource_image_content.nothing )
                    { _image_ref.level_pre_allocation = Resource_image_content.compress_data; }

                Figure_image_component image_component = new Figure_image_component();

                        Transform transform = _mode.transform.Find( _name_component );
                        if( transform == null )
                            { CONTROLLER__errors.Throw( $"Was not found the gameobject in the path <Color=lightBlue>{ _name_component }</Color>" ); }
                        image_component.game_object = transform.gameObject;
                        CONTROLLER__errors.Verify( ( image_component.game_object == null ) , $"Tried to get the component { _name_component } in the game object { _mode.name } but was not find" );
                        image_component.image = image_component.game_object.GetComponent<Image>();
                        image_component.image_ref = _image_ref;

                return image_component;
            
        }



        public static void Prepare_to_use_resources( Figure _figure, string _form ){

                Figure_resources_data _figure_data = _figure.figure_interface.Get_resources_data( _figure, _form );
                _figure_data.Instanciate( _figure );

                // --- IMAGES

                Figure_image_component[] images = _figure_data.images;

                foreach( Figure_image_component figure_image in images ){ 

                        if( figure_image.game_object == null )
                            { break; }

                        figure_image.image_ref.Change_level_pre_allocation( Resource_image_content.texture ); 
                        continue;
                }

                // ** audio
                // *** 

                return;

        }



        public static void Change_form( Figure _figure, string _form ){


                Figure_resources_data _figure_data = _figure.figure_interface.Get_resources_data( _figure, _form );

                CONTROLLER__errors.Verify( ( _figure_data.form_game_object == null ), $"Tried to change form of the figure { _figure.figure_interface.Get_figure_name() } but the gameObject was null. Probably was not Pre_loaded" );
                

                // --- IMAGES
                Figure_image_component[] images = _figure_data.images;

                if( images != null )
                    {

                        foreach( Figure_image_component figure_image in images ){ 

                                if( figure_image.game_object == null )
                                    { break; }

                                figure_image.Put_image(); 
                                continue;
                        }

                    }

                _figure.figure_interface.Change_form( _figure, _figure_data.form_game_object );

                

                return;

        }





}
