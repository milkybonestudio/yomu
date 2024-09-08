using System;
using UnityEngine;






public class Controlador_cursor {


        public static Controlador_cursor instancia;
        public static Controlador_cursor Pegar_instancia(){ return instancia; }
    

        public bool  pode_invisivel = true ;
    
        public     Texture2D                      cursor_blue;
        public     Texture2D                      cursor_red;
        public     Texture2D                      cursor_green;
        public     Texture2D                      cursor_yellow;
        public     Texture2D                      cursor_pink;
        public     Texture2D                      cursor_default;
        
        public     Vector2                        cursor_hotspot;

        public     Cor_cursor                     cursor_atual   =  Cor_cursor.off;



     public void Mudar_cursor( Cor_cursor _tipo ){


        if(_tipo == cursor_atual){
            return;    
        } 

        Cursor.visible = true;
         

        switch( _tipo ){


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


    public INTERFACE__cursor cursor;

    public Vector2 posicao_cursor;
    public GameObject cursor_game_object;



    public enum Cursor_contexto {

            //** contexto de onde o mouse esta posicionado

            nada,  // ** default
            area_expancao_de_opcoes,
            icone, 
            personagem_seguindo,
            interativo_item,
            interativo_personagem,
            interativo_movimento,
            informacao,
            combate_cartas,
        
    }

    public enum Action_cursor {




    }


    public void Ativar_action(){}



    public void Mover_cursor( float _adicional_x, float _adicional_y ){

            float nova_posicao_x = ( posicao_cursor.x + _adicional_x );
            float nova_posicao_y = ( posicao_cursor.y + _adicional_y );
            

    }

    public void Setar_posicao_cursor( float _posicao_x, float _posicao_y ){

    }


    public void Mudar_cursor( INTERFACE__cursor _novo_cursor ){}



}