


public static class Construtor_controlador_pedidos_sistema {


        public static Controlador_pedidos_sistema Construir(){

            Controlador_pedidos_sistema controlador = new Controlador_pedidos_sistema();
            Controlador_pedidos_sistema.instancia = controlador;


            return controlador;

        }


}