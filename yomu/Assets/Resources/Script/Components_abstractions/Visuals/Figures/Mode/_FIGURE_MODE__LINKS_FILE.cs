using UnityEngine;


public abstract partial class FIGURE_MODE {


        private struct Link_data {

            public string component;
            public Resource_image_find_data find_data;

        }

        private struct Link_array_data {

            public string component;
            public Resource_image_find_data_array find_data;
            public Frame_rate frame_rate;

        }


        private Link_data[] links_data = new Link_data[ 100 ];
        private Link_array_data[] links_array_data = new Link_array_data[ 5 ];

        public int current_pointer_data = 1;
        public int current_pointer_array_data = 1;

    // --- STATIC IMAGE

        private Figure_mode_direction current_direction_being_linked;
        protected void Link( string _component, Resource_image_find_data _find_data ){

                //mark
                // ** testar mais depois

                ref Figure_mode__DIRECTION direction =   ref Get_direction( current_direction_being_linked );
                direction.activated = true;
                
                if( direction.main.start_pointer_data == 0 )
                    { 
                        direction.main.start_pointer_data = ++current_pointer_data; 
                        direction.main.final_pointer_data = current_pointer_data; 
                    }
                    else
                    { direction.main.final_pointer_data = ++current_pointer_data; }

                links_data[ current_pointer_data ] = new(){

                    component = _component,
                    find_data = _find_data,

                };
            
                return;

        }



        protected void Link_eye( string _component, Resource_image_find_data_array _find_data, Frame_rate _frame_rate ){ Link_generic( Figure_mode_animation_type.eyes, _component, _find_data, _frame_rate ); }
        protected void Link_mouth( string _component, Resource_image_find_data_array _find_data, Frame_rate _frame_rate ){ Link_generic( Figure_mode_animation_type.mouth, _component, _find_data, _frame_rate ); }


        private void Link_generic( Figure_mode_animation_type _type, string _component, Resource_image_find_data_array _find_data, Frame_rate _frame_rate ){


            if( _frame_rate == Frame_rate.not_give )
                { CONTROLLER__errors.Throw( "was not give the frame rate" ); }

            ref Figure_mode__DIRECTION direction =  ref Get_direction( current_direction_being_linked );
            
            ref Figure_mode_animation_SIMPLE animation = ref Figure_mode_animation_SIMPLE.def;

            switch( _type ){

                case Figure_mode_animation_type.eyes: animation = ref direction.eyes_animation; break;
                case Figure_mode_animation_type.mouth: animation = ref direction.mouth_animation; break;
                default: CONTROLLER__errors.Throw( $"Can no thandle type: <Color=lightBlue>{ _type }</Color> in the figure <Color=lightBlue>{ figure_interface.name }</Color> in the direction <Color=lightBlue>{ direction }</Color>"  ); break;

            }



            if( animation.active || animation.pointer_data < 0 )
                { CONTROLLER__errors.Throw( $"Tried to add a mouth animation in the figure <Color=lightBlue>{ figure_interface.name }</Color> in the direction <Color=lightBlue>{ direction }</Color>. But the mouth was already defined. <Color=lightBlue>Probably was give Link_mouth() 2 times</Color>" ); }

            direction.activated = true;
            animation.pointer_data = ++current_pointer_array_data;

            links_array_data[ current_pointer_array_data ] = new(){

                    component = _component,
                    find_data = _find_data,
                    frame_rate = _frame_rate,
            };


        }





        private void Link_array_data_to_structure( ref Figure_mode__DIRECTION  _direction,  ref Figure_mode_animation_SIMPLE _animation, int _pointer_data_array  ){

            Link_array_data link_array = links_array_data[ _pointer_data_array ];

            Resource_image_basic resources_data = Get_resource_image_basic( link_array.find_data.main, link_array.find_data.path, link_array.find_data.path_root );

            RESOURCE__image_ref[] _refs = Controllers.resources.images.Get_images_reference( resources_data.context, resources_data.main_folder, resources_data.path, Resource_image_content.nothing, link_array.find_data.number_images );

            Unity_main_components unity_components = _direction.structure.Get_components( link_array.component );
            
            _direction.Link_image( ref unity_components, _refs[ 0 ] );
            _animation = Figure_mode_animation_SIMPLE.Construct( _refs, _direction.main.images_links[ _direction.index_link_atual ].sprite_render, ( int ) link_array.frame_rate );
            
            resources_container.Add_multiples( _refs, 0 );

        }



        private void Link_data_to_structure( ref Figure_mode__DIRECTION direction, Link_data _link_data ){

            // ** LINKA IMAGEM DENTRO DO DIRECTION

            Resource_image_basic resources_data = Get_resource_image_basic( _link_data.find_data.main, _link_data.find_data.path, _link_data.find_data.path_root );
        
            RESOURCE__image_ref _resource_image = Controllers.resources.images.Get_image_reference( resources_data.context, resources_data.main_folder, resources_data.path, Resource_image_content.nothing );

            resources_container.Add( _resource_image );

            Unity_main_components unity_components = direction.structure.Get_components( _link_data.component );

            direction.Link_image( ref unity_components, _resource_image );


        }

        private struct Resource_image_basic {

            public Resource_context context;
            public string main_folder;
            public string path;

        }

        private Resource_image_basic Get_resource_image_basic( string _main_path, string _path, string _path_with_root ){

            Resource_context context = figure_interface.figure_getter_object.context;
            string main_folder = figure_interface.figure_getter_object.main_folder;
            string root = figure_interface.figure_getter_object.root;
            string final_path;

            
            if( _main_path != null )
                { main_folder = _main_path; }


            if( _path_with_root != null )
                { final_path = _path_with_root; }
                else
                { final_path = ( root + "/" + _path ); }

            return new(){ context = context, main_folder = main_folder, path = final_path };

        }



}