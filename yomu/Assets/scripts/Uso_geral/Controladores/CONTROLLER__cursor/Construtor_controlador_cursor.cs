using UnityEngine;

public static class Construtor_controlador_cursor {


        public static Controlador_cursor Construir(){

            Controlador_cursor controlador = new Controlador_cursor();
            Controlador_cursor.instancia = controlador;

                    
                Cursor.lockState = CursorLockMode.Locked; // nao sei se vai funcionar
                Cursor.visible = false;





            return controlador;

        }


}