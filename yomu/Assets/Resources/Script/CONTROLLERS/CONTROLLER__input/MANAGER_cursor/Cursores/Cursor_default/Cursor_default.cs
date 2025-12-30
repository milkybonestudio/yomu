
using UnityEngine;


public class Cursor_default : INTERFACE__cursor {


        // ** imagem
        // ** audio
        // ** funcao

        
        // animacao?
        public Texture2D[] static_textures; // no animation
        public Texture2D[,] animation_textures; // animation, not now

        public AudioClip[] audios; // ** default?

        public void Atualizar_action(){


        }
        

        // public void Update(){

        //     // ** parte especifica se tiver
        //     switch( controlador_contexto.current_block ){

        //         case Block_type.interacao: Cursor_default_interacao_update.Ativar( controlador_contexto.modo_atual ); return;
        //         default: Update_generico(); return;

        //     }

        // }

        // public void Update_generico(){


        // }


}