using System;



public class CONTROLLER__system_information {


        public static CONTROLLER__system_information instancia;
        public static CONTROLLER__system_information Pegar_instancia(){ return instancia; }

        // *** pedidos
        public bool pediu_para_encerrar_jogo = false; // ** vai iniciar 


        public int graphic_memory;
        public int ram_memory;

        public int processor_frequency;
        public int processor_cores;
        
        
}
