

using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Build.Content;
using UnityEngine;




//public  delegate BuildPlayerOptions  Handler( BuildPlayerOptions  _BuildPlayerOptions );


/*

  Eu vou ter que dar um pouco mais de atenção para os arquivos de compilacão 

*/



class Controlador_compilacao_pre:IPreprocessBuildWithReport {


    

     //         why?
        public int callbackOrder { get { return 0; } }

       

        // public BuildPlayerOptions Handler( BuildPlayerOptions _args ){

        //     Controlador_compilacao_pre.path =  _args.locationPathName;

        //     return _args;


        // }


        

        public void OnPreprocessBuild(BuildReport _a){



          // tem que excluir aquela imagem

          // string path_assets =  Application.dataPath;
          // string pre_path_game =  System.IO.Directory.GetParent(System.IO.Directory.GetParent( path_assets ).ToString()).ToString() ;


          // string path_para_pegar_arquivos = Application.dataPath + "/Editor/imagens_para_deletar_na_build";
          // string path_para_salvar = pre_path_game + "/folder_para_colocar_de_novo";


          // if( System.IO.Directory.Exists( path_para_salvar ) ){

          //       Debug.Log( "vai deletar path vazio: " + path_para_salvar );
          //       System.IO.Directory.Delete( path_para_salvar );

          // } 


          // System.IO.Directory.Move( path_para_pegar_arquivos , path_para_salvar );











          // string path = Application.dataPath + "/Editor/imagens_para_deletar_na_build" + "/arquivo_teste.png";
          // Debug.Log("apth: " + path);

          // if( System.IO.File.Exists( path ) ){

          //   Debug.Log("vai excluir");

          //     System.IO.File.Delete( path );


          // }








          //  Func< BuildPlayerOptions,BuildPlayerOptions >  _handler = Handler;



        //    BuildTarget tipo = BuildTarget.StandaloneWindows64;
         
        //        // EH TETRA CARALHOOOOOOO
          
        //   string path = EditorUserBuildSettings.GetBuildLocation(tipo);

        //   string[] str_arr = path.Split( "\\" );
          
        //    Debug.Log("path :" + path);
        //    Debug.Log(str_arr[0] + );


    //    BuildPlayerWindow.RegisterGetBuildPlayerOptionsHandler(_handler);


        
       
      // Debug.Log( "Current path: " + path);



      //  Debug.Log( BuildPlayerWindow.DefaultBuildMethods.GetCurrentBuildOptions() );
                 
        //           BuildPlayerOptions buildPlayerOptions = BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(new BuildPlayerOptions());
        //  Debug.Log(buildPlayerOptions.locationPathName);
        // //         /*

        //         mudar save com chaves => sem chaves
            
        //          */

        //         Debug.Log("comecou");


        }






}

