using UnityEngine;
using UnityEditor;

public class Menu_items_proprios {




    [MenuItem("GameObject/UI PROPRIA/Botao", false, 0 )]
    static void Instanciar_botao(){ Menu_items_proprios.Instanciar_prefab_generico( "Assets/Resources/Prefabs/MONOS/UI/Botao.prefab" ); }
    


    static void Instanciar_prefab_generico( string _path ){

        GameObject[] game_objcts = Selection.gameObjects;
        if( game_objcts.Length != 1 )
            { Debug.Log( "Tem que selecionar somente 1" ); return; }


        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>( _path );

        if ( prefab == null )
            { throw new System.Exception( $"nao foi achado o prefab no path { _path } " ); }


            // Cria uma instância do prefab na posição (0,0,0) com rotação padrão
            GameObject ob = GameObject.Instantiate( prefab, Vector3.zero, Quaternion.identity );
            ob.name = prefab.name;


            ob.transform.SetParent( Selection.activeGameObject.transform, false );
            return;


        }
    

}

