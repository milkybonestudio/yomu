



unsafe public class Menu : PROGRAM_MODE {


        public Menu(){ type = Program_mode.menu; }
        private PROGRAM_MODE __interface__ ;
        public override void Construct(){


                PROGRAM_DATA__menu* data = Program_data.Get_data__MENU();
                                
                switch( data->type ){

                    case Menu_type.south_cathedral: __interface__ = new Menu__SOUTH_CATHEDRAL(); break;
                    default: CONTROLLER__errors.Throw( $" Can not handle { type } in menu" ); break;

                }
                
                
                // ** use data

                __interface__.Construct();

                return;

        }
        public override void Destroy(){

                // if( __interface__ == null )
                //     { CONTROLLER__errors.Throw( "Tried to destroy menu, but there is no interface" ); }
                    
                __interface__?.Destroy();
                __interface__ = null;


        }

        public override void Update( Control_flow _control_flow ){ __interface__.Update( _control_flow ); }
        public override Transition_program Construct_transition( Transition_program_data _data ){ return __interface__.Construct_transition( _data ); }
        public override void Clean_resources(){ __interface__.Clean_resources(); }
        



}

