using UnityEngine;
using System.Collections;
using System;



public class Mono_instancia : MonoBehaviour {


        [ExecuteInEditMode] 
        public static Mono_instancia instancia;

        void Awake(){

            instancia = this;
            
        }
            
        public static Coroutine Start_coroutine(IEnumerator _IEnumerator){

            return instancia.StartCoroutine( _IEnumerator);

        }

    
        public static Coroutine Stop_coroutine( Coroutine _coroutine ){

                Debug.Log( instancia );


                instancia.StopCoroutine( _coroutine );
                return null;
            
        }

 
}