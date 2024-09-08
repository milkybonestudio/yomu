


#if UNITY_EDITOR

    public static class TESTE_controlador_sistema {

        public static Controlador_sistema Construir_controlador(){

            Controlador_sistema controlador = new Controlador_sistema();


            Controlador_sistema.instancia = controlador;
            return controlador;

        }

    }

#endif