using System;
using System.IO;
using UnityEngine;


public static class Paths_system {

    // ** MAIN ENTRY POINTS
    #if UNITY_EDITOR

        public static string persistent_data = Path.Combine( Application.dataPath, "Editor", "persistentDataPath" );
        public static string data = Path.Combine( Application.dataPath, "Editor", "dataPath" );
        
    #else 

        public static string persistent_data_path = Path.Combine( Application.persistentDataPath, "Current_version" ) ;
        public static string data_path = Path.Combine( Application.dataPath, "Data" );

    #endif


}