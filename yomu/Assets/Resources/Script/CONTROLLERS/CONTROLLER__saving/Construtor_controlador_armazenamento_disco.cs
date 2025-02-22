using System;

public static class CONSTRUCTOR__controller_saving {


        public static CONTROLLER__saving Construct(){


                CONTROLLER__saving controlador = new CONTROLLER__saving(); 
                CONTROLLER__saving.instancia = controlador;

                    // --- USO GERAL 

                    // --- VERIFICACOES DE SEGURANCA
                
                    
                    // --- USAO EXCLUSIVO SAVE
                    controlador.modulo_gerenciador_instrucoes_de_seguranca = new MODULO__gerenciador_instrucoes_de_seguranca();
                                        

                return controlador;


        }
}