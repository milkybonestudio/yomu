using  System;
using  UnityEngine;



public static class Scripts_visual_novel_end {


    public static void Ativar_script( Nome_script_visual_novel_end _script , Screen_play _screen_play ){


        switch( _script ){

            case Nome_script_visual_novel_end.nada : return; 

            case Nome_script_visual_novel_end.NARA_INTRODUCAO_liberar_mesa :  Script_end_1.NARA_INTRODUCAO_liberar_mesa( _screen_play ) ; break;
            case Nome_script_visual_novel_end.NARA_INTRODUCAO_liberar_buraco :  Script_end_1.NARA_INTRODUCAO_liberar_buraco( _screen_play ) ; break;
            case Nome_script_visual_novel_end.NARA_INTRODUCAO_liberar_cama_E_corredor :  Script_end_1.NARA_INTRODUCAO_liberar_cama_E_corredor( _screen_play ) ;break;
            case Nome_script_visual_novel_end.NARA_INTRODUCAO_alkatroz  :  Script_end_1.NARA_INTRODUCAO_alkatroz ( _screen_play ) ;break;
            case Nome_script_visual_novel_end.NARA_INTRODUCAO_finalizar  :  Script_end_1.NARA_INTRODUCAO_finalizar  ( _screen_play ) ;break;
            

            


            default : Debug.LogError("nao foi achado"); throw new ArgumentException("");
            
        }


    }



}