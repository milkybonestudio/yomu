using UnityEngine;


public static class Chaves_ferramentas {

    public static KeyCode Pegar_chave ( Ferramenta_desenvolvimento _ferramenta  ){


        switch( _ferramenta ){


            case Ferramenta_desenvolvimento.nada : return KeyCode.Escape;
            case Ferramenta_desenvolvimento.localizador_personagens : return KeyCode.F1;
            default : throw new System.Exception();

        }

    }


}