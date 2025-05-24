

unsafe public class Login : PROGRAM_MODE {

        public Login(){ type = Program_mode.login; }

        public PROGRAM_MODE__INTERFACE __interface__;

        public override void Construct(){


                PROGRAM_DATA__login* data = Controllers_program.data.modes.Lock_data__LOGIN();
        
                Login_type login_type = data->type;

                switch( login_type ){

                    case Login_type.standart: __interface__ = new Login_standart(); break;
                    default: CONTROLLER__errors.Throw( $" Can not handle <Color=lightBlue>{ login_type }</Color> in login" ); break;
                    
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




