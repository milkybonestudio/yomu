using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


unsafe public class Game : PROGRAM_MODE {

        public Game(){  type = Program_mode.game; }

        public PROGRAM_MODE__INTERFACE __interface__;

        public override void Construct(){

                PROGRAM_DATA__game* data = Controllers_program.data.modes.Lock_data__GAME();
                Game_type type = data->type;

                    switch( type ){

                        case Game_type.standart: __interface__ = new Game__STANDART(); break;
                        default: CONTROLLER__errors.Throw( $" Can not handle { type } in game" ); break;
                        
                    }

                    
                __interface__.Construct();
            
        }

        public override void Destroy(){

            __interface__?.Destroy();
            __interface__ = null;

        }

        public override void Update( Control_flow _control_flow ){ __interface__.Update( _control_flow ); }
        public override Transition_program Construct_transition( Transition_program_data _data ){ return __interface__.Construct_transition( _data ); }
        public override void Clean_resources(){ __interface__.Clean_resources(); }


}