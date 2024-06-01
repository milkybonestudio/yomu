using System.Collections;
using UnityEngine;
using System;





public class Coroutine_objeto {

     public Coroutine[] coroutine_arr = null;




     public void Iniciar_coroutine(  int slot ,  IEnumerator IEn ){

            if( coroutine_arr [ slot ]  != null ) {throw new ArgumentException("tentou coolocar 2 coroutines no mesmo slot. Slot: " + slot);}
            coroutine_arr [ slot ]  =  Mono_instancia.Start_coroutine(  IEn  );
            return;

     }



     public Coroutine_objeto( int _numero_de_coroutines ){

          coroutine_arr = new Coroutine[ _numero_de_coroutines ];


     }

    //  talvez precise de algo para quando a coroutine ja tiver encerrado

     public void Stop(){

          for( int  i = 0 ;  i < coroutine_arr.Length ; i++ ){

                if( coroutine_arr[ i ]  != null  ) {

                        Mono_instancia.Stop_coroutine( coroutine_arr[ i ]  ); 
                        coroutine_arr[ i ] = null;
                
                }  

          }

     }



}


