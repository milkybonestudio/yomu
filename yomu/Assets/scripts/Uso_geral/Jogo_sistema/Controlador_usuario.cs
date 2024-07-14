

public class Controlador_usuario {

        public static Controlador_usuario instancia;
        public static Controlador_usuario Pegar_instancia(){ return instancia; }


        public static Controlador_usuario Construir(){ 
                

                Controlador_usuario controlador = new Controlador_usuario(); 

                instancia = controlador;
                return controlador;
                
        }


        




}
