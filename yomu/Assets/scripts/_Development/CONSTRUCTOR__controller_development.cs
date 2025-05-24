using UnityEngine;



public static class CONSTRUCTOR__controller_development {

        public static CONTROLLER__development Construct( CONTROLLER__development controller ){

                CONTROLLER__development.instancia = controller;

                    controller.program = Program.instance;
                                
                    // --- ferramentas
                    controller.development_tools = new Development_tools();
                    controller.test = new Test();


                    controller.development_modes = new Development_mode[ ( int ) Type_testing.END ];

                    controller.development_modes[ ( int ) Type_testing.program_mode ] = new Development__PROGRAM_MODE();
                    controller.development_modes[ ( int ) Type_testing.test ] = new Development__TEST();
                    
                    

                return controller;

            
        }

}
