using System;
using UnityEditor;
using UnityEngine;


#if UNITY_EDITOR


public class Controlador_editor : Editor {




    public override void OnInspectorGUI(){


        base.OnInspectorGUI();

        if(  GUILayout.Button( "teste_funcao" , GUILayout.Width( 90f ) )  ){


            // coisas 


        }


    }





}




#endif 