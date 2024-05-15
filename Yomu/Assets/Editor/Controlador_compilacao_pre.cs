

using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Build.Content;
using UnityEngine;




//public  delegate BuildPlayerOptions  Handler( BuildPlayerOptions  _BuildPlayerOptions );



class Controlador_compilacao_pre:IPreprocessBuildWithReport {


     

    

     //         why?
        public int callbackOrder { get { return 0; } }

       

        // public BuildPlayerOptions Handler( BuildPlayerOptions _args ){

        //     Controlador_compilacao_pre.path =  _args.locationPathName;

        //     return _args;


        // }


        

        public void OnPreprocessBuild(BuildReport _a){

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

