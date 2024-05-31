using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Build.Content;
using UnityEngine;




class Controlador_compilacao_post:IPostprocessBuildWithReport {


        // aqui vai estar 

        // public static BuildFile abc;


        //         why?
        public int callbackOrder { get { return 0; } }


        public void OnPostprocessBuild(BuildReport _a ){

        //   string path_assets =  Application.dataPath;
        //   string pre_path_game =  System.IO.Directory.GetParent(System.IO.Directory.GetParent( path_assets ).ToString()).ToString();
        //   string path_para_salvar =  Application.dataPath  + "/Editor/imagens_para_deletar_na_build";
        //   string path_para_pegar_arquivos = pre_path_game + "/folder_para_colocar_de_novo";

        //   if( System.IO.Directory.Exists( path_para_salvar ) ){

        //         Debug.Log( "vai deletar para a volta folder vazio no path: " + path_para_salvar );
        //         System.IO.Directory.Delete( path_para_salvar );

        //   } 


        // System.IO.Directory.Move(  path_para_pegar_arquivos,  path_para_salvar );



        // Debug.Log(  BuildPipeline.isBuildingPlayer  );

        //BuildPlayerContext PELO_AMOR = new BuildPlayerContext();

        // BuildPlayerProcessor abc = new BuildPlayerProcessor();

        // Debug.Log(  UnityEditor.EditorBuildSettingsScene.path  );



            
        /*

        criar folder 

        */








        //Debug.Log(Controlador_compilacao_post.abc.path );
        //Debug.Log( "pos: " + path );



                // BuildTarget tipo = BuildTarget.StandaloneWindows64;
                
                //     // EH TETRA CARALHOOOOOOO
                
                // string path = EditorUserBuildSettings.GetBuildLocation(tipo);

                // string[] str_arr = path.Split( "\\" );
                
                // Debug.Log("path :" + path);
                // Debug.Log(str_arr[0]  );



        // System.IO.Directory.CreateDirectory(   str_arr[0]  + "/arquivos_mutaveis"   );

        // System.IO.Directory.CreateDirectory(   str_arr[0]  +   "/arquivos_mutaveis/saves"   );

            



        // }
        



}


}






