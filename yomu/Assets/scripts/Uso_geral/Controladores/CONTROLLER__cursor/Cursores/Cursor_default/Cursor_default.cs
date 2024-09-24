
using UnityEngine;


public class Cursor_default : INTERFACE__cursor {

        public Cursor_default(){ controlador_contexto = CONTROLLER__game_current_state.Get_instance(); }


        // ** imagem
        // ** audio
        // ** funcao

        public CONTROLLER__game_current_state controlador_contexto;

        


        // animacao?
        public Texture2D[] static_textures; // no animation
        public Texture2D[,] animation_textures; // animation, not now

        public AudioClip[] audios; // ** default?

        public void Atualizar_action(){


        }
        

        public void Update(){

            // ** parte especifica se tiver
            switch( controlador_contexto.current_block ){

                case Bloco.interacao: Cursor_default_interacao_update.Ativar( controlador_contexto.modo_atual ); return;
                default: Update_generico(); return;

            }

        }

        public void Update_generico(){


        }


}