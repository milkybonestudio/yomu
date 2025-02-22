



using System;
using System.Runtime.CompilerServices;



unsafe public struct LOGIN_DATA__standart {


        public LOGIN_DATA__global* global;
        public LOGIN_DATA_STANDART__persistent* persistent;
        public LOGIN_DATA_STANDART__creation* creation;
        public LOGIN_DATA_STANDART__temporary* temporary;
    

}

public unsafe struct Program_data {


        public static void Construct( Program_data* _data_pointer ){

            // ** vai ser chamado somente na primeira vez que o player iniciar o jogo

            //mark
            // ** nao faz sentido, vale mais a pena deixar como antes e ter uma classe "Constructor_new_game" ou algo

            PROGRAM_DATA__login.Construct( &(_data_pointer->login) );
            PROGRAM_DATA__menu.Construct( &(_data_pointer->menu) );
            PROGRAM_DATA__game.Construct( &(_data_pointer->game) );

        }

        public PROGRAM_DATA__login login;
        public PROGRAM_DATA__menu menu;
        public PROGRAM_DATA__game game;


        public Program_mode program_mode_lock;


        public const int valid_blocks_data = ( int )( Program_mode.login | Program_mode.menu | Program_mode.game );

        public static Program_data* pointer;


        public static PROGRAM_DATA__login* Get_data__LOGIN(){ return ( PROGRAM_DATA__login* ) Get_data( Program_mode.login ); }
        public static PROGRAM_DATA__game* Get_data__GAME(){ return ( PROGRAM_DATA__game* ) Get_data( Program_mode.game ); }
        public static PROGRAM_DATA__menu* Get_data__MENU(){ return ( PROGRAM_DATA__menu* ) Get_data( Program_mode.menu ); }

        public static PROGRAM_DATA__login* Lock_data__LOGIN(){ Lock( Program_mode.login ); return ( PROGRAM_DATA__login* ) Get_data( Program_mode.login ); }
        public static PROGRAM_DATA__game* Lock_data__GAME(){   Lock( Program_mode.game );  return ( PROGRAM_DATA__game* ) Get_data( Program_mode.game );   }
        public static PROGRAM_DATA__menu* Lock_data__MENU(){   Lock( Program_mode.menu );  return ( PROGRAM_DATA__menu* ) Get_data( Program_mode.menu );   }



        public static void Unlock_data(){

                if( pointer->program_mode_lock == Program_mode.not_give )
                    { CONTROLLER__errors.Throw( $"Tried to unlock the program_mode_lock but is not_give" ); return; }

                pointer->program_mode_lock = Program_mode.not_give;

        }


        public static void Verify_lock_data( Program_mode _mode ){

                
                if( _mode != pointer->program_mode_lock )
                    { CONTROLLER__errors.Throw( $"Tryed to move to <Color=lightBlue>{ _mode }</Color> but the data lock is <Color=lightBlue>PROGRAM_DATA__{ pointer->program_mode_lock }</Color>" ); }

                if( pointer->program_mode_lock == Program_mode.not_give )
                    { CONTROLLER__errors.Throw( $"Tryed to move to <Color=lightBlue>{ _mode }</Color> but do not get the <Color=lightBlue>PROGRAM_DATA__{ _mode }</Color> before the switch" ); }


        }



    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Lock( Program_mode _program_mode ){

                if( pointer->program_mode_lock != Program_mode.not_give )
                    { CONTROLLER__errors.Throw( $"Tried to go to the mode <Color=lightBlue>{ _program_mode }</Color> but is in <Color=lightBlue>{ _program_mode }</Color>" ); return; }

                pointer->program_mode_lock = _program_mode;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void* Get_data( Program_mode _program_mode ){


                switch( _program_mode ){

                    case Program_mode.login: return ( void* ) &( pointer->login );
                    case Program_mode.menu: return ( void* ) &( pointer->menu ); 
                    case Program_mode.game: return ( void* ) &( pointer->game ); 
                    default: return ( void* ) &( pointer->game );

                }

        }



}