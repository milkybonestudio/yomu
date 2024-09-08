using System;
using UnityEngine;

public class Molde_jogo {

    
    public Molde_jogo(){



        // molde vai pegar o GameObject da ui que vai estar sempre no controlador 
        Transform transform_para_colocar  = _Controlador_UI.Pegar_instancia().ui_container_game_object.transform;

        string path_prefab = "prefabs/ui/molde_jogo_1";
        molde_jogo_game_object = Resources.Load<GameObject>( path_prefab);
        // o prefab sempre assume que coloca no 0,0
        // tem que pegar a transform de onde vai colocar 
        GameObject.Instantiate( molde_jogo_game_object,  transform_para_colocar);



        
    }

    public GameObject molde_jogo_game_object;

    public void Colocar_icons( Bloco _bloco_para_colocar ){

        /*

            aqui pode pegar informacoes sobre oque vai ter no molde 
            fazer tipo Player_estado_atual.Pegar_instancia().dados_ui.movimento_molde_jogo
        
        */

        Molde_icone[] icones_ativos = null;

        switch( _bloco_para_colocar ){

            case Bloco.interacao: icones_ativos = Player_estado_atual.Pegar_instancia().icones_movimento; break;
            default : throw new Exception( "a" );

        }



    }


    

}




