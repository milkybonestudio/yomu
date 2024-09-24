using UnityEngine;

public static class CONSTRUCTOR__cursor_default {

        public static INTERFACE__cursor Construct(){

                Cursor_default cursor = new Cursor_default();

                    cursor.static_textures = new Texture2D[ System.Enum.GetValues( typeof( Cursor_default_static_mode ) ).Length ];

                    cursor.static_textures[ ( int ) Cursor_default_static_mode.blue ]   = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_blue");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.red ]    = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_red");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.green ]  = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_green");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.yellow ] = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_yellow");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.off ]    = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_off");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.pink ]   = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_pink");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.purple ] = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_purple");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.orange ] = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_orange");
                    cursor.static_textures[ ( int ) Cursor_default_static_mode.cyan ]   = Resources.Load<Texture2D>("images/utilidade_geral/cursores/cursor_cyan");
    
                    
                return cursor;

        }

}