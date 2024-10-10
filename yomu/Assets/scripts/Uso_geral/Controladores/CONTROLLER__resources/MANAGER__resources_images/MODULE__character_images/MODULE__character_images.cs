using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MODULE__character_images {



        public string path_containers;

        // ** tem de todos
        public Dictionary<string,Image_localizers> dic;

        public byte[] Get_image( Personagem_nome _personagem, string image_path ){

            #if UNITY_EDITOR 

                return System.IO.File.ReadAllBytes( Path.Combine( Application.dataPath, "Resources" )   );

            #endif



        }



}