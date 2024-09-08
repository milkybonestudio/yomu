

public static class Construtor_controlador_usuario {


        public static Controlador_usuario Construir(){

            Controlador_usuario controlador = new Controlador_usuario();
            Controlador_usuario.instancia = controlador;


            return controlador;

        }


}