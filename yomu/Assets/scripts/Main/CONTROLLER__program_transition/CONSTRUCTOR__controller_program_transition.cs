


public static class CONSTRUCTOR__controller_program_transition {


        public static CONTROLLER__program_transition Construct(){

                CONTROLLER__program_transition controller = new CONTROLLER__program_transition();
                CONTROLLER__program_transition.instance = controller;

                        controller.watch = System.Diagnostics.Stopwatch.StartNew();
                        //mark
                        // ** ver se eh esse mesmo
                        controller.watch.Reset();
                        controller.max_time_to_transition_ms = new long[ ( int ) Program_mode.END ];

                            controller.max_time_to_transition_ms[ ( int ) Program_mode.login ] = 5_000l;
                            controller.max_time_to_transition_ms[ ( int ) Program_mode.menu ] = 5_000l;
                            controller.max_time_to_transition_ms[ ( int ) Program_mode.jogo ] = 15_000l;
                            controller.max_time_to_transition_ms[ ( int ) Program_mode.test ] = 1_000l;

                        controller.state = Swithcing_program_transition_state.nothing;

                return controller;

        }


}