

unsafe public class Program_start_messages : PROGRAM_MODE {

        public Program_start_messages(){ type = Program_mode.program_start_messages; }

        public PROGRAM_MODE__INTERFACE __interface__;

        public override void Construct(){


                PROGRAM_DATA__program_start_messages* data = Controllers_program.data.modes.Lock_data__PROGRAM_START_MESSAGES();
                Program_start_messages_type type = data->global.persistent.type;

                switch( type ){

                    case Program_start_messages_type.standart: __interface__ = new Program_start_messages__standart(); break;
                    default: CONTROLLER__errors.Throw( $" Can not handle <Color=lightBlue>{ type }</Color> in login" ); break;
                    
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




