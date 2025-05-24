
// ** ACTIONS
public abstract partial class FIGURE_MODE {


        public void Change_direction( Figure_mode_direction _new_direction ){

            if( current_direction == _new_direction )
                { return; }

            current_direction = _new_direction;

            ref Figure_mode__DIRECTION new_direction = ref Get_direction( _new_direction );
            ref Figure_mode__DIRECTION old_direction = ref Get_direction( current_direction );

            old_direction.structure.Return_to_container();
            
            new_direction.main.Put_sprites();
            combined_images.Set_structure( new_direction.structure, new_direction.image_dimension );


        }


        public virtual void Blink( Blink_data _data ){

                Get_direction( current_direction ).Blink( _data );
                
                if( current_direction != transition_direction )
                    { Get_direction( transition_direction ).Blink( _data ); }

        }

        public virtual void Speak( Speak_data _data ){

                Get_direction( current_direction ).Speak( _data );
                
                if( current_direction != transition_direction )
                    { Get_direction( transition_direction ).Speak( _data ); }

        }


}