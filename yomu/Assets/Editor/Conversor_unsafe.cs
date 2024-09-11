using UnityEditor;
using UnityEngine;

public class Construtor_unsafe : AssetPostprocessor{

        protected void OnPreprocessAsset(){

        
            if ( assetPath.EndsWith(".cs" ) || assetPath.EndsWith(".dll"))
                {

                    Debug.Log( assetPath );
                    Debug.Log( context.mainObject );
                    

                }



        }

}