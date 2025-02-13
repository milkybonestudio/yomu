

unsafe public class Login : PROGRAM_MODE {

        public Login(){  type = Program_mode.login; }

        public PROGRAM_MODE __interface__;

        public override void Construct(){

                PROGRAM_DATA__login* data = &(Controllers_program.data.pointer->login);
                Login_type type = data->type;

                    switch( type ){

                        case Login_type._default: __interface__ = new Login_default(); break;
                        default: CONTROLLER__errors.Throw( $" Can not handle { type } in login" ); break;
                        
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




