using UnityEngine;
using System.Collections;

public static class COROUTINE {

    public static void Parar_coroutines_array( Coroutine[] _arr ){

        for( int  i = 0 ;  i < _arr.Length ; i++ ){

            if( _arr[ i ]  != null  )
                {
                    Mono_instancia.Stop_coroutine( _arr[ i ]  ); 
                    _arr[ i ] = null;
                }  

            continue;

        }

        return;

    }



    public static void Iniciar_coroutine_especifico_array(  Coroutine[] _coroutine_array, int _index ,  IEnumerator IEn ){

            if( _coroutine_array[ _index ]  != null )
                { throw new System.ArgumentException("tentou coolocar 2 coroutines no mesmo index. Index: " + _index); }
                
            _coroutine_array[ _index ]  =  Mono_instancia.Start_coroutine(  IEn  );
            return;

    }





}