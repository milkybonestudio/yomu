using  System;
using  UnityEngine;





public static class  Script_visual_novel_run {



    public static string Ativar_script( Nome_script_visual_novel_run _script ){

        
        switch( _script ){

            case Nome_script_visual_novel_run.nada:  return "nada" ;
            default: Debug.LogError("Nome_script_visual_novel_run nao foi encontrado. veio: " + _script); throw new ArgumentException("");
            
        }


    }



}