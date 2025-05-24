using UnityEngine;


// ** STATE
public abstract partial class Figure {


        public void Change_content_level( Content_level _new_content ){

            switch( _new_content ){

                case Content_level.nothing: final_content = Figure_content.nothing; break;
                case Content_level.minimum: final_content = minimun_content; break;
                case Content_level.full: final_content = Figure_content.finished; break;

            }

        }

        public void Change_minimum_content_level( Figure_content _content ){

            minimun_content = _content;

            if( current_content_level == Content_level.minimum )
                { final_content = _content; }

        }


        public void Delete(){

            if( deleted )
                { CONTROLLER__errors.Throw( $"Tried to delete the figure <Color=lightBlue>{ name }</Color> but was already deleted" ); }
            modes.Delete_all();
            deleted = true;

        }

        // --- LOGIC
        public void Activate( Figure_activate_data _data ){ 

                // ** STATE 
                    if( state == Figure_state.active )
                        { Deactivate(); } 
                    
                    state = Figure_state.active;


                // ** CONTENT
                    Instanciate_content();

                
                // ** BODY
                    _data.set_body_data.parent ??= _data.parent;
                    body.Set_parent( _data.set_body_data );


                // ** START MODE
                    if( _data.start_mode != Figure_mode.not_give )
                        { data.start_mode = _data.start_mode; } // ** seria melhor não ser diferente, pois se carregou no fluxo normal vai ter outro

                    current_mode = modes.Get( data.start_mode );
                    current_mode.Activate( _data.data_start_mode );


                // ** LINK GAME OBJECT
                    body.Add_game_object( current_mode.Get_quad_container() );


        }

        public void Deactivate(){

                // ** desativa o Body e volta para o final_content

                if( state != Figure_state.active )
                    { 
                        // CONTROLLER__errors.Throw( $"Tried to Deactivate figure <Color=lightBlue>{ name }</Color>, but the state was not active" ); 
                        return;
                    }

                // ** do not destroy, just return to the container to wait 
                
                state = Figure_state.inactive;

                Force_finish_transition_MODE_to_MODE();

                if( transition_mode != null ) // force sempre finaliza -> tem que ser null
                    { CONTROLLER__errors.Throw( $"Tried to Deactivate <Color=lightBlue>{ name }</Color> but the <Color=lightBlue>transition_mode</Color> is not null after force_finish" ); }

                // ** return the quad_container to the cameras container
                current_mode.Deactivate(); 

                modes.Guarantee_all_state( Figure_mode_state.inactivate );

        }


        public void Change_content_level_MODE( Figure_mode _mode, Content_level _level ){

            // ** ONLY IF STILL CONSTRUCTING

            content_levels_modes[ ( int ) _mode ] = _level; 

            if( current_content > Figure_content.construct_modes )
                { modes.Get( _mode ).Change_content_level( _level ); }

        }


        public void Change_content_level_MODES( Content_level _level, Figure_mode[] _modes ){

            int array_index;
            // ** ONLY IF STILL CONSTRUCTING
            for( array_index = 0 ; array_index < _modes.Length ; array_index++  ){
                content_levels_modes[ ( int ) _modes[ array_index ] ] = _level;
            }

            if( current_content > Figure_content.construct_modes )
                {
                    for( array_index = 0 ; array_index < _modes.Length ; array_index++  ){
                        modes.Get( _modes[ array_index ] ).Change_content_level( _level );
                    }

                }


        }

        public enum Content_level_override_type {

            complete_override, 
            min, 
            max, 

        }

        public void Change_content_level_MODES( Content_level _new_content_level, Content_level_override_type _type = Content_level_override_type.complete_override ){

            int array_index;
            // ** ONLY IF STILL CONSTRUCTING

            if( _type == Content_level_override_type.complete_override )
                {
                    for( int index_complete_list = 0 ; index_complete_list < content_levels_modes.Length ; index_complete_list++  ){
                        content_levels_modes[ index_complete_list ] = _new_content_level;
                    }
                }

            if( _type == Content_level_override_type.max )
                {
                    for( int index_complete_list = 0 ; index_complete_list < content_levels_modes.Length ; index_complete_list++  ){
                        if( content_levels_modes[ index_complete_list ] < _new_content_level )
                            { content_levels_modes[ index_complete_list ] = _new_content_level; }
                    }
                }


            if( _type == Content_level_override_type.min )
                {
                    for( int index_complete_list = 0 ; index_complete_list < content_levels_modes.Length ; index_complete_list++  ){
                        if( content_levels_modes[ index_complete_list ] > _new_content_level )
                            { content_levels_modes[ index_complete_list ] = _new_content_level; }
                    }
                }


            if( current_content > Figure_content.construct_modes )
                { modes.Change_content_levels( content_levels_modes );}


        }




        private void Force_finish_transition_MODE_to_MODE(){

            // ** garante que a transicao mode -> mode termine

        }

        





}
