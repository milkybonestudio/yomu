

using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_entities {

    public static CONTROLLER__entities Construct(){

            CONTROLLER__entities controller = new CONTROLLER__entities();
            CONTROLLER__entities.instance = controller;

                    // ** cada enum vai ter o numero final de entidades no Enum.end

                    int number_characters = 1_000;
                    int number_plots = 1_000;

                    int number_cities = 1_000;
                    int number_states = 1_000;
                    int number_kingdoms = 1_000;

                    int number_bytes  = (
                                            ( number_characters * sizeof( Character ) )
                                            +
                                            ( number_plots * sizeof( Plot ) )
                                            + 
                                            ( number_cities * sizeof( City ) )
                                        
                                        );
                    
                    controller.pointer_data_fundamental_data = Marshal.AllocHGlobal( number_bytes );

                    int index = 0;
                    long pointer_value = ( long ) controller.pointer_data_fundamental_data.ToPointer();

                    // // --- entidades
                    // controller.characters = ( Character* )pointer_value;
                    // pointer_value += ( number_characters * sizeof( Character ) );
                    
                    // controller.plots = ( Plot* ) pointer_value;
                    // pointer_value += ( number_plots * sizeof( Plot ) );

                    // controller.cities = ( City* ) pointer_value;
                    // pointer_value += ( number_cities * sizeof( City ) );



            return controller;

    }

}