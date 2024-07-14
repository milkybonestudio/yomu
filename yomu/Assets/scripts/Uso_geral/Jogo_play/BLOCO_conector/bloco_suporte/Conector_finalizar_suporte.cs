

public static class Conector_finalizar_suporte {

    public static void Finalizar(){

                BLOCO_conector.instancia = null;

                Controlador_interativos.instancia = null;
                Controlador_tela_conector.instancia = null;
                Controlador_cursor.instancia = null;
                Controlador_dados.instancia = null;
                
                return;

    }

}