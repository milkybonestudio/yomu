using UnityEngine;


public class Controlador_movimento {



        public static Controlador_movimento instancia;
        public static Controlador_movimento Pegar_instancia(){ return instancia; }

        public BLOCO_conector bloco_conector;

        public static Controlador_movimento Construir(){ 

                Controlador_movimento controlador = new Controlador_movimento(); 
                
                    controlador.bloco_conector = BLOCO_conector.Pegar_instancia();

                instancia = controlador;
                return instancia;
                
        }

            


}