

unsafe public class New_game : PROGRAM_MODE {


        public New_game(){ type = Program_mode.new_game; }
        private PROGRAM_MODE__INTERFACE __interface__ ;
        public override void Construct(){


                PROGRAM_DATA__new_game* data = default;
                                
                switch( data->type ){

                    case New_game_type.standart: __interface__ = new New_game_standart(); break;
                    default: CONTROLLER__errors.Throw( $" Can not handle { type } in menu" ); break;

                }
                
                
                // ** use data

                __interface__.Construct();

                return;

        }
        public override void Destroy(){
                    
                __interface__?.Destroy();
                __interface__ = null;

        }

        public override void Update( Control_flow _control_flow ){ __interface__.Update( _control_flow ); }
        public override Transition_program Construct_transition( Transition_program_data _data ){ return __interface__.Construct_transition( _data ); }
        public override void Clean_resources(){ __interface__.Clean_resources(); }
        











}