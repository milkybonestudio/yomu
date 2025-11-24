using System;

public static class CONSTRUCTOR__controller_saving {


        public static CONTROLLER__saving Construct(){


                CONTROLLER__saving controlador = new CONTROLLER__saving(); 
                CONTROLLER__saving.instancia = controlador;

                    // --- USO GERAL 

                    controlador.saver = MANAGER__controller_saving_saver.Construct();
                    controlador.state = Saving_state.waiting_to_save_files;

                return controlador;


        }
}