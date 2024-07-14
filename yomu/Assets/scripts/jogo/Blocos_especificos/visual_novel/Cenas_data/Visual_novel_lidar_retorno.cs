using System;
using UnityEngine;



public static class Visual_novel_lidar_retorno {


        public static void Default(){

                Debug.Log ("veio lidar_retorno visual_novel");

                Action Mudar_ui = BLOCO_visual_novel.Pegar_instancia().Mudar_UI;
                Action Mudar_input = BLOCO_visual_novel.Pegar_instancia().Mudar_input;
                if( Mudar_ui != null  ){ Mudar_ui(); }
                if( Mudar_input != null  ){ Mudar_input(); }
                
                return;
                
        }
    


}