


public static class CONSTRUCTOR__controller_program_transition {


        public static CONTROLLER__program_transition Construct(){

                CONTROLLER__program_transition controller = new CONTROLLER__program_transition();
                CONTROLLER__program_transition.instance = controller;

                        controller.watch = System.Diagnostics.Stopwatch.StartNew();
                        //mark
                        // ** ver se eh esse mesmo
                        controller.watch.Reset();
                        controller.max_time_to_transition_ms = new long[ 100 ];

                            controller.max_time_to_transition_ms[ ( int ) Program_mode.nothing ] = 5_000l;
                            controller.max_time_to_transition_ms[ ( int ) Program_mode.login ] = 5_000l;
                            controller.max_time_to_transition_ms[ ( int ) Program_mode.menu ] = 5_000l;
                            controller.max_time_to_transition_ms[ ( int ) Program_mode.game ] = 15_000l;
                            controller.max_time_to_transition_ms[ ( int ) Program_mode.rebuild_save ] = ( 5l * 60l * 1_000l );

                        controller.state = Swithcing_program_transition_state.nothing;

                return controller;

        }


}