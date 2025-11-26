using System;

public static class CONSTRUCTOR__controller_saving {


        public static CONTROLLER__saving Construct(){


                CONTROLLER__saving controlador = new CONTROLLER__saving(); 
                CONTROLLER__saving.instancia = controlador;

                    // --- USO GERAL 

                    controlador.saver = MANAGER__controller_saving_saver.Construct();
                    controlador.state = Saving_state.waiting_to_save_files;

                    if( System_run.show_mid_cpu_performance_impact_LONGER )
                        { Console.Log( "link files use strings[] and [ n ] is the file id { n }. if n grows a lot will be bad. Could be like file_id??path" ); }

                return controlador;


        }
}