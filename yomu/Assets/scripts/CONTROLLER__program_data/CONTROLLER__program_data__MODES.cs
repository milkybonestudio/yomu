


using System.Runtime.CompilerServices;

unsafe public class CONTROLLER__program_data__MODES {


        public CONTROLLER__program_data__MODES( Program_modes_data* _data ){ program_data = _data ; }

        
        public Program_modes_data* program_data;

        public Program_mode program_mode_lock;
    
        public const int valid_blocks_data = ( int )( Program_mode.login | Program_mode.menu | Program_mode.game );
        

        public static void Construct( Program_modes_data* _data_pointer ){}
        

        public void Lock_data__NOTHING(){ Lock( Program_mode.nothing ); }


        public PROGRAM_DATA__login* Get_data__LOGIN(){ return &( program_data->login ); }
        public PROGRAM_DATA__game* Get_data__GAME(){ return &( program_data->game ); }
        public PROGRAM_DATA__menu* Get_data__MENU(){ return &( program_data->menu ); }
        public PROGRAM_DATA__new_game* Get_data__NEW_GAME(){ return &( program_data->new_game ); }
        public PROGRAM_DATA__program_start_messages* Get_data__PROGRAM_START_MESSAGES(){ return &( program_data->program_start_messages ); }


        public PROGRAM_DATA__login* Lock_data__LOGIN(){ Lock( Program_mode.login ); return Get_data__LOGIN(); }
        public PROGRAM_DATA__game* Lock_data__GAME(){   Lock( Program_mode.game );  return Get_data__GAME();   }
        public PROGRAM_DATA__menu* Lock_data__MENU(){   Lock( Program_mode.menu );  return Get_data__MENU();  }
        public PROGRAM_DATA__new_game* Lock_data__NEW_GAME(){   Lock( Program_mode.new_game );  return Get_data__NEW_GAME();  }
        public PROGRAM_DATA__program_start_messages* Lock_data__PROGRAM_START_MESSAGES(){   Lock( Program_mode.program_start_messages );  return Get_data__PROGRAM_START_MESSAGES();  }
        



        public void Unlock_data(){

                if( program_mode_lock == Program_mode.not_give )
                    { CONTROLLER__errors.Throw( $"Tried to unlock the program_mode_lock but is not_give" ); return; }

                program_mode_lock = Program_mode.not_give;

        }


        public void Verify_lock_data( Program_mode _mode ){

                
                if( _mode != program_mode_lock )
                    { CONTROLLER__errors.Throw( $"Tryed to move to <Color=lightBlue>{ _mode }</Color> but the data lock is <Color=lightBlue>PROGRAM_DATA__{ program_mode_lock }</Color>" ); }

                if( program_mode_lock == Program_mode.not_give )
                    { CONTROLLER__errors.Throw( $"Tryed to move to <Color=lightBlue>{ _mode }</Color> but do not get the <Color=lightBlue>PROGRAM_DATA__{ _mode }</Color> before the switch" ); }


        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Lock( Program_mode _program_mode ){



                if( program_mode_lock != Program_mode.not_give )
                    { CONTROLLER__errors.Throw( $"Tried to go to the mode <Color=lightBlue>{ _program_mode }</Color> but is in <Color=lightBlue>{ _program_mode }</Color>" ); return; }

                Console.Log( "vai dar lock: " + _program_mode );

                program_mode_lock = _program_mode;

        }




}