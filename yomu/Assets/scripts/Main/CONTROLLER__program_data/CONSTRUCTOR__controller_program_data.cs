


public static class CONSTRUCTOR__controller_program_data {


        public static CONTROLLER__program_data Construct(){


                #if UNITY_EDITOR

                    return Construct_EDITOR();

                #else

                    return Construct_BUILD();

                #endif

        }


        public static CONTROLLER__program_data Construct_EDITOR(){


                CONTROLLER__program_data controller = new CONTROLLER__program_data_EDITOR();

                
                return controller;

        }

        public static CONTROLLER__program_data Construct_BUILD(){


                CONTROLLER__program_data controller = new CONTROLLER__program_data_BUILD();

                
                return controller;

        }




}