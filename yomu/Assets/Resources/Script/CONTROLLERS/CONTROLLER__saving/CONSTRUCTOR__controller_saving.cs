using System;

public static class CONSTRUCTOR__controller_saving {


        public static CONTROLLER__saving Construct(){


                CONTROLLER__saving controlador = new CONTROLLER__saving(); 
                CONTROLLER__saving.instancia = controlador;

                    // --- USO GERAL 

                    // --- VERIFICACOES DE SEGURANCA

                    
                    
                    // --- USAO EXCLUSIVO SAVE
                    controlador.data_tracker = new MANAGER__data_tracker();

                return controlador;


        }
}