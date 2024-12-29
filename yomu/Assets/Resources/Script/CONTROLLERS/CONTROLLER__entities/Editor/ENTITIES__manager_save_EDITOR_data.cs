

public unsafe class ENTITIES__manager_save_EDITOR_data : ENTITIES__manager_save_data {


        public readonly Game_current_state* ZERO = ( Game_current_state* ) null;

        public int Set( int _off_set, int value ){

            // save 

            return _off_set;

        }

        public override int Retake( Game_current_state* _game_current_state ){

            if( 10 > 5 )
                { return Set( ( int ) &( ZERO->block_interaction ), 10 ); }

            return -1;
            
        }

        public override void Force_save(){

                // ** nada

        }

}