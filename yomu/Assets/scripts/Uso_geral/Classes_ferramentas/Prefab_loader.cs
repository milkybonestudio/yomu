using System;
using UnityEngine;


public static class Prefab_loader {

    public static GameObject Pegar_prefab( string _path ){


            // ** por hora vai seomente chamar normalmente com resources. mas quando eu puder optimizar os arquivos .prefab vao ser transformados em um outro tipo para poder fazer object pooling 
            GameObject prefab = Resources.Load<GameObject>( _path );

            CONTROLLER__errors.Verify( ( prefab == null ), $"nao achou o prefab no path { _path }" );
        
            return prefab;


    }

}