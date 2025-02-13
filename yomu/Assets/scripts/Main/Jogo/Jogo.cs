using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;





unsafe public struct PROGRAM_DATA__game { 

    public Lock_program_data lock_data;

    // ** START
    public int save;

    public Game_type type;

    public static void Construct( PROGRAM_DATA__game* _data ){}



}

public enum Game_type {

    _default,
    END,


}


unsafe public class Game : PROGRAM_MODE {

        public Game(){  type = Program_mode.jogo; }

        public PROGRAM_MODE __interface__;

        public override void Construct(){

                PROGRAM_DATA__game* data = &(Controllers_program.data.pointer->game);
                Game_type type = data->type;

                    switch( type ){

                        case Game_type._default: __interface__ = new Game__DEFAULT(); break;
                        default: CONTROLLER__errors.Throw( $" Can not handle { type } in game" ); break;
                        
                    }

                    
                __interface__.Construct();
            
        }

        public override void Destroy(){

            __interface__?.Destroy();
            __interface__ = null;

        }

        public override void Update( Control_flow _control_flow ){ __interface__.Update( _control_flow ); }
        public override Transition Construct_transition( Transition_data _data ){ return __interface__.Construct_transition( _data ); }
        public override void Clean_resources(){ __interface__.Clean_resources(); }


}




