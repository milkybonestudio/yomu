using UnityEngine;
using System;






public class Controlador_cursor {


        public static Controlador_cursor instancia;
        public static Controlador_cursor Pegar_instancia(){ return instancia; }
        public static Controlador_cursor Construir(){ instancia = new Controlador_cursor(); return instancia;}


    public Controlador_cursor(){


         cursor_blue = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_blue");
         cursor_red= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_red");
         cursor_green= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_green");
         cursor_yellow= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_yellow");
         cursor_pink= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_pink");
         cursor_default= Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_default");

         cursor_hotspot = Vector2.zero;


    }

    public bool  pode_invisivel = true ;

    
    public     Texture2D                      cursor_blue;
    public     Texture2D                      cursor_red;
    public     Texture2D                      cursor_green;
    public     Texture2D                      cursor_yellow;
    public     Texture2D                      cursor_pink;
    public     Texture2D                      cursor_default;
    
    public     Vector2                        cursor_hotspot;

    public     Cor_cursor                     cursor_atual   = Cor_cursor.off;



     public void Mudar_cursor(Cor_cursor _tipo){


        if(_tipo == cursor_atual){
            return;    
        } 

         Cursor.visible = true;
         

        switch(_tipo){


            case Cor_cursor.invisivel:  if( pode_invisivel ) { Cursor.visible = false ; } break;
            case Cor_cursor.off: Cursor.SetCursor( cursor_default, cursor_hotspot, CursorMode.Auto );break;
            case Cor_cursor.blue:  Cursor.SetCursor( cursor_blue, cursor_hotspot, CursorMode.Auto );break;
            case Cor_cursor.green:  Cursor.SetCursor( cursor_green, cursor_hotspot, CursorMode.Auto );break;
            case Cor_cursor.red: Cursor.SetCursor( cursor_red , cursor_hotspot, CursorMode.Auto );break;
            case Cor_cursor.pink:  Cursor.SetCursor( cursor_pink, cursor_hotspot, CursorMode.Auto );break;
            case Cor_cursor.yellow:  Cursor.SetCursor( cursor_yellow, cursor_hotspot, CursorMode.Auto );break;

            default:   throw new ArgumentException("nao foi achado cursor");

        }

        cursor_atual = _tipo;

    }


}