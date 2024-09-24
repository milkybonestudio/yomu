// using UnityEditor;
// using UnityEngine;



// public class Construtor_unsafe : AssetPostprocessor{

//         protected void OnPreprocessAsset(){


//             // 1 => nao deixar ele importar 
//             // 2 => fazer ele importar outro
        
//             if ( assetPath.EndsWith(".cs" ) || assetPath.EndsWith(".dll"))
//                 {

//                     //assetImporter = new AssetImporter();

//                     Debug.Log( assetPath );
//                     Debug.Log( context.mainObject );
//                     Debug.Log( Application.dataPath );

//                     // string texto = System.IO.File.ReadAllBytes( assetPath );

//                     if( assetPath.Contains("AAA.cs") )
//                         { AssetDatabase.DeleteAsset( assetPath ); }

                
//                 }


//         }

    



//     static void OnPostprocessAllAssets( string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload ){

        
//         foreach (string str in importedAssets){


//                 // if( str.Contains( ".cs.TEMP.cs" ) )
//                 //     { AssetDatabase.DeleteAsset( str ); }


//                 // Debug.Log("Reimported Asset: " + str);

//         }

//         foreach (string str in deletedAssets)
//         {
//             Debug.Log("Deleted Asset: " + str);
//         }

//         for (int i = 0; i < movedAssets.Length; i++)
//         {
//             Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
//         }

        
//     }


// }