using UnityEngine;

public static class Construtor_controlador_cursor {


        public static Controlador_cursor Construir(){

            Controlador_cursor controlador = new Controlador_cursor();
            Controlador_cursor.instancia = controlador;

                    
                //mark
                //** nao testei
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                controlador.cursor_blue = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_blue");
                controlador.cursor_red= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_red");
                controlador.cursor_green= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_green");
                controlador.cursor_yellow= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_yellow");
                controlador.cursor_pink= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_pink");
                controlador.cursor_default= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_default");

                controlador.cursor_hotspot = Vector2.zero;




            return controlador;

        }


}