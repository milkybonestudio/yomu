
using UnityEngine;


public class Cursor_mouse_default : INTERFACE__cursor {

    public Cursor_mouse_default(){

        controlador_contexto = Controlador_contexto.Pegar_instancia();

    }


    // ** imagem
    // ** audio
    // ** funcao

    public Controlador_contexto controlador_contexto;

    public Texture2D[] imagens;
    public AudioClip[] audios; // ** default?

    public void Atualizar_action(){



    }

    public void Update(){

        // ** parte especifica se tiver
        switch( controlador_contexto.bloco_atual ){

            case Bloco.interacao: Cursor_default_interacao_update.Ativar( controlador_contexto.modo_atual ); return;
            default: Update_generico(); return;

        }

    }

    public void Update_generico(){


    }


}