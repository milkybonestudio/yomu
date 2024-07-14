

public class Controlador_tela_utilidades {


        public static Controlador_tela_utilidades instancia;
        public static Controlador_tela_utilidades Pegar_instancia(){ return instancia; }


        public static Controlador_tela_utilidades Construir(){ 

            instancia = new Controlador_tela_utilidades();

            return instancia;
        }



}