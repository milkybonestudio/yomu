

// ** CONTENT
using UnityEngine;

public abstract partial class FIGURE_MODE {


        public Figure_mode_content current_content;
        public Figure_mode_content minimum_content;
        public Figure_mode_content final_content;

        public Content_level current_content_level;


        public void Change_minimum_content_level( Figure_mode_content _new_minimum_level ){

            minimum_content = _new_minimum_level;
            
            if( current_content_level == Content_level.minimum )
                { final_content = _new_minimum_level; }

        }




        public void Change_content_level( Content_level _content ){

            current_content_level = _content;

            switch( _content ){

                case Content_level.nothing: final_content = Figure_mode_content.nothing; break;
                case Content_level.minimum: final_content = minimum_content; break;
                case Content_level.full: final_content = Figure_mode_content.finished; break;

            }


        }



        public bool Got_content_level( Content_level _content ){

            Figure_mode_content content_need_to_be = Figure_mode_content.not_give;
            switch( _content ){

                case Content_level.nothing: content_need_to_be = Figure_mode_content.nothing; break;
                case Content_level.minimum: content_need_to_be = minimum_content; break;
                case Content_level.full: content_need_to_be = Figure_mode_content.finished; break;

            }

            return ( content_need_to_be <= current_content );

        }


        private int Update_content( Control_flow _flow ){

            Console.Log( Figure.teste, $"------------Update content:" );
            Console.Log( Figure.teste, $"----------------Current_content: <Color=lightBlue>{ current_content }</Color>" );
            Console.Log( Figure.teste, $"----------------Final_contet: <Color=lightBlue>{ final_content }</Color>" );

            int weight = 0;

            switch( current_content ){

                case Figure_mode_content.nothing: Check_nothing( _flow ); break;
                    case Figure_mode_content.link_data: Check_link_data( _flow ); break;
                        case Figure_mode_content.getting_directions_structures: Check_getting_directions_structures( _flow ); break;
                            case Figure_mode_content.structures: Check_structures( _flow ); break;    
                                case Figure_mode_content.link_data_to_directions: Check_link_data_to_directions( _flow ); break;    
                                    case Figure_mode_content.resources_minimum: Check_resources_minimum( _flow ); break;    
                                        case Figure_mode_content.combined_image: Check_combined_image( _flow ); break;
                                            case Figure_mode_content.resources_full: Check_resources_full( _flow ); break;  
                                                case Figure_mode_content.finished: break;
                                                    default : CONTROLLER__errors.Throw( "State not accept: " + current_content ); return -1;

            }

            return weight;

        }

        private void Create_base_direction(){

            for( Figure_mode_direction direction_type = Figure_mode_direction.left ; direction_type < Figure_mode_direction.END ; direction_type++ )
                { directions[ ( int ) direction_type ] = Figure_mode__DIRECTION.Construct( this, direction_type ); }

        }

        private void Check_nothing( Control_flow _flow ){

            if( current_content < final_content )
                { 

                    Create_base_direction();
                    current_content = Figure_mode_content.link_data; 
                }

        }


        protected virtual void Link_left(){}
        protected virtual void Link_right(){}
        protected virtual void Link_front(){}
        protected virtual void Link_back(){}
        protected virtual void Link_left_back(){}
        protected virtual void Link_right_back(){}

        private void Link_data_intern(){
            
            // ** DEFINE DIRECTIONS
            for( Figure_mode_direction direction_type = Figure_mode_direction.left ; direction_type < Figure_mode_direction.END ; direction_type++ )
                { directions[ ( int ) direction_type ].direction = direction_type; }

            current_direction_being_linked = Figure_mode_direction.left;
            Link_left();
            current_direction_being_linked = Figure_mode_direction.right;
            Link_right();
            current_direction_being_linked = Figure_mode_direction.front;
            Link_front();
            current_direction_being_linked = Figure_mode_direction.back;
            Link_back();
            current_direction_being_linked = Figure_mode_direction.left_back;
            Link_left_back();
            current_direction_being_linked = Figure_mode_direction.right_back;
            Link_right_back();


        }


        private void Check_link_data( Control_flow _flow ){

            if( current_content < final_content )
                {
                    Link_data_intern();
                    current_content = Figure_mode_content.getting_directions_structures;
                }

        }

        private void Get_directions_structures(){

            MANAGER__resources_structures manager = Controllers.resources.structures;
            Figure_data_getter data = figure_interface.figure_getter_object;


            data_construction.special_name ??=  ( data_construction.visual_figure.ToString().ToUpper() );
            Resource_context context = data.context;
            string main_folder = data.main_folder;
            string path = ( data.root + "/" + data_construction.special_name );

            
            for( Figure_mode_direction direction = Figure_mode_direction.left ; direction < Figure_mode_direction.END ; direction++ ){

                if( directions[ ( int ) direction ].activated )
                    { directions[ ( int ) direction ].structure = manager.Get_structure_copy( context, main_folder, ( path + "__" + direction.ToString().ToUpper() ), Resource_structure_content.game_object ); }

            }

        }
        private void Check_getting_directions_structures( Control_flow _flow ){


            if( current_content < final_content )
                {
                    Get_directions_structures();
                    current_content = Figure_mode_content.structures;
                }


        }



        private void Check_structures( Control_flow _flow ){

            if( current_content < final_content )
                {

                    for( Figure_mode_direction direction_type = Figure_mode_direction.left ; direction_type < Figure_mode_direction.END ; direction_type++ ){

                        ref Figure_mode__DIRECTION direction = ref directions[ ( int ) direction_type ];
                        if( !!!( direction.activated ) )
                            { continue; }

                        direction.structure.Go_to_content_level( Content_level.full );    

                        // ** remover depois que arrumar o Got_content_level
                        direction.structure.Instanciate(); 
                        if( !!!( direction.structure.Got_content_level( Content_level.full ) ) && false ) // ** TIRAR DEPOIS
                            { return; }

                    }

                    current_content = Figure_mode_content.link_data_to_directions; 

                    
                }

        }


            // CHAMADO NO CONTENT n vezes

            private void Link_all_data_direction( ref Figure_mode__DIRECTION direction ){

                int final = ( direction.main.final_pointer_data + 1 );
                for( int pointer_data = direction.main.start_pointer_data; pointer_data < final ; pointer_data++ )
                    { Link_data_to_structure( ref direction, links_data[ pointer_data ] ); }

                if( direction.eyes_animation.pointer_data != 0 )
                    { Link_array_data_to_structure( ref direction, ref direction.eyes_animation, direction.eyes_animation.pointer_data ); }

                if( direction.mouth_animation.pointer_data != 0 )
                    { Link_array_data_to_structure( ref direction, ref direction.mouth_animation, direction.mouth_animation.pointer_data ); }


            }


        private void Link_data_to_directions_intern(){

                
            for( Figure_mode_direction direction_type = Figure_mode_direction.left ; direction_type < Figure_mode_direction.END ; direction_type++ ){

                ref Figure_mode__DIRECTION direction = ref directions[ ( int ) direction_type ];
                if( !!!( direction.activated ) )
                    { continue; }

                Link_all_data_direction( ref direction );
            } 

        }
        private void Check_link_data_to_directions( Control_flow _flow ){

            if( current_content < final_content )
                {   
                    Link_data_to_directions_intern();
                    current_content = Figure_mode_content.resources_minimum;
                }

        }





        private void Check_resources_minimum( Control_flow _flow ){


            if( current_content < final_content )
                {
                    resources_container.Go_to_content_level_all_resources( Content_level.minimum );

                    //mark
                    // ** nao esta funcionando, remover o **true** depois
                    if( resources_container.Got_to_content_level_all_resources( Content_level.minimum ) || true )
                        { current_content = Figure_mode_content.combined_image; }
                }

        }
        




        private void Create_combined_image(){

            material = new Material( Shaders.individual_components );

            MANAGER__resources_combined_images manager  = Controllers.resources.resources_combined_images;


            Dimensions combined_image_dimensions = default;

            int number_active_directions = 0;
            for( Figure_mode_direction direction_type = Figure_mode_direction.left ; direction_type < Figure_mode_direction.END ; direction_type++ ){

                ref Figure_mode__DIRECTION direction = ref Get_direction( direction_type );
                if( !!!( direction.activated ) )
                    { continue; }

                number_active_directions++;

                direction.structure.Instanciate(); 
                direction.image_dimension = manager.manager_render_rextures.Calculate_dimensions( direction.structure.Get_game_object(), direction.main.images_links );

                if( combined_image_dimensions.height < direction.image_dimension.height )
                    { combined_image_dimensions.height = direction.image_dimension.height; }

                if( combined_image_dimensions.width < direction.image_dimension.width )
                    { combined_image_dimensions.width = direction.image_dimension.width; }

            }


            combined_images = manager.Get_combined_image( material,  combined_image_dimensions );

            if( number_active_directions > 1 )
                { combined_images_transition = manager.Get_combined_image( material,  combined_image_dimensions ); }
            
        }




        private void Check_combined_image( Control_flow _flow ){


            if( current_content < final_content )
                {   
                    Create_combined_image();
                    current_content = Figure_mode_content.resources_full;
                }

        }
        
        



        private void Check_resources_full( Control_flow _flow ){


            if( current_content < final_content )
                {
                    resources_container.Go_to_content_level_all_resources( Content_level.full );

                    //mark
                    // ** nao esta funcionando, remover o **true** depois
                    if( resources_container.Got_to_content_level_all_resources( Content_level.full ) || true )
                        { current_content = Figure_mode_content.finished; }
                }

        }
        





        private void Instanciate_content(){


            current_content_level = Content_level.full;

            if( current_content == Figure_mode_content.finished )
                { return; }

            // *** TEM QUE FORCAR

            if( current_content == Figure_mode_content.nothing )
                {
                    Create_base_direction();
                    current_content = Figure_mode_content.link_data;
                }

            if( current_content == Figure_mode_content.link_data )
                {
                    Link_data_intern();
                    current_content = Figure_mode_content.getting_directions_structures;
                }


            if( current_content == Figure_mode_content.getting_directions_structures )
                {
                    Get_directions_structures();
                    current_content = Figure_mode_content.structures;
                }
            
            
            if( current_content == Figure_mode_content.structures )
                {

                    // structure.Instanciate();
                    
                    for( Figure_mode_direction direction_type = Figure_mode_direction.left ; direction_type < Figure_mode_direction.END ; direction_type++ ){

                        ref Figure_mode__DIRECTION direction = ref directions[ ( int ) direction_type ];
                        if( !!!( direction.activated ) )
                            { continue; }

                        direction.structure.Instanciate(); 
                        
                    }

                    current_content = Figure_mode_content.link_data_to_directions;
                }


            if( current_content == Figure_mode_content.link_data_to_directions  )
                {
                    Link_data_to_directions_intern();
                    current_content = Figure_mode_content.resources_minimum;
                }        
            
            if( current_content == Figure_mode_content.resources_minimum  )
                {
                    resources_container.Go_to_content_level_all_resources( Content_level.minimum );
                    current_content = Figure_mode_content.combined_image;
                }

            if( current_content == Figure_mode_content.combined_image )
                {
                    // ** ??
                    Create_combined_image();
                    current_content = Figure_mode_content.resources_full ;
                }
            
            if( current_content == Figure_mode_content.resources_full  )
                {
                    resources_container.Go_to_content_level_all_resources( Content_level.full );
                    current_content = Figure_mode_content.finished;
                }




        }



}

