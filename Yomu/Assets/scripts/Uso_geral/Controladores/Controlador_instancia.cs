using UnityEngine;
using System.Collections;
using System;



public class Mono_instancia : MonoBehaviour {

    [ExecuteInEditMode] public static Mono_instancia instancia;




    public static Coroutine Start_coroutine(IEnumerator _IEnumerator){

     
       return instancia.StartCoroutine( _IEnumerator);

    }

   
    public static void Stop_coroutine(Coroutine _coroutine){



        instancia.StopCoroutine(_coroutine);

        return ;
       
    }

    

    void Awake(){

        instancia = this;
        
        
    }

 
}