using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Build.Content;
using UnityEngine;




class Controlador_compilacao_post:IPostprocessBuildWithReport {



        /*


                aqui depois vai ser usado para criar o container.dat que tem as imagens 


        
        */

        

        public static BuildFile abc;


        //         why?
        public int callbackOrder { get { return 0; } }


        public void OnPostprocessBuild(BuildReport _a ){



            //       Debug.Log( Controlador_compilacao_pre.path);




        // Debug.Log(  BuildPipeline.isBuildingPlayer  );

        //BuildPlayerContext PELO_AMOR = new BuildPlayerContext();

        // BuildPlayerProcessor abc = new BuildPlayerProcessor();

        // Debug.Log(  UnityEditor.EditorBuildSettingsScene.path  );



            
        /*

        criar folder 

        */








        //Debug.Log(Controlador_compilacao_post.abc.path );
        //Debug.Log( "pos: " + path );



                BuildTarget tipo = BuildTarget.StandaloneWindows64;
                
                    // EH TETRA CARALHOOOOOOO
                
                string path = EditorUserBuildSettings.GetBuildLocation(tipo);

                string[] str_arr = path.Split( "\\" );
                
                Debug.Log("path :" + path);
                Debug.Log(str_arr[0]  );



        // System.IO.Directory.CreateDirectory(   str_arr[0]  + "/arquivos_mutaveis"   );

        // System.IO.Directory.CreateDirectory(   str_arr[0]  +   "/arquivos_mutaveis/saves"   );

            



        }
        



}









