using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Diagnostics;







public class Controlador_timer {


        public static Controlador_timer instancia;
        public static Controlador_timer Pegar_instancia(){ return instancia; }
        public static Controlador_timer Construir(){ instancia = new Controlador_timer(); return instancia;}





    


    

    //public Controlador controlador;

    public Stopwatch stop_watch = new Stopwatch();

    public int[] scripts_em_espera = new int[10];

    public double[] scripts_em_espera_tempo = new double[10];

    public bool have_scripts = false; 

    public int tempo_jogo;

    public Coroutine global_timer;

    public DateTime ponto_inicio_jogo;


    /*

       0 : manha 
       1 : dia
       2 : tarde
       3 : noite 
       4 : madrugada 

    */
  

    public Periodo_tempo periodo_atual = Periodo_tempo.noite;


    public void Iniciar(){

        ponto_inicio_jogo = DateTime.Now;
        Iniciar_global_timer();
        
    }



    public void Update(){



    }




    public Dia_semana dia_semana = Dia_semana.segunda;

    /*

       0 : segunda 
       1 : terca
       2 : quarta
       3 : quinta
       4 : sexta
       5 : sabado
       6 : domingo

    */



    public void Zerar_dados(){


            
            scripts_em_espera = new int[10];
            scripts_em_espera_tempo = new double[10];

            have_scripts = false; 

            return;


    }



    public void Iniciar_cronometro(){

        stop_watch.Reset();
        stop_watch.Start();
        return;


    }

    public int Pegar_tempo_cronometro(){

         TimeSpan ts = stop_watch.Elapsed;
         int milisegundos = ts.Milliseconds;
         UnityEngine.Debug.Log(milisegundos);
         return milisegundos;

    }

    public void  Parar_cronometro(){

        stop_watch.Stop();
        stop_watch.Reset();
        return;

    }


    public double Pegar_tempo(){

         TimeSpan a =  DateTime.Now -  ponto_inicio_jogo;
         double b = a.TotalMilliseconds;
         return b;


    }




    public void Iniciar_global_timer(){

       // global_timer = controlador.StartCoroutine(Timer());
        return;
    }

    public void Parar_global_timer(){

      //  controlador.StopCoroutine(global_timer);
        return;
    }


    public void Adicionar_script(int _script_id, double _time){
        int i;
    
        for( i = 0 ;  i<10  ; i++){
             
             if(scripts_em_espera[i] != 0) continue;

             scripts_em_espera[i] = _script_id;
             scripts_em_espera_tempo[i] = _time;
             have_scripts = true;
             
             break;


        }

        if(i == 10 )throw new ArgumentException("numero maximo de script em timer excedido");

        return ;

    }


    public void Tirar_script(int _script_id){
         
        for(int i = 0 ;  i<10  ; i++){
             
            if(scripts_em_espera[i] == _script_id) {

                scripts_em_espera[i] = 0;
                scripts_em_espera_tempo[i] = 0;

             }
        
        }

        return ;


    }


    /// fazer sem coroutine, atualizar no update

    // public IEnumerator Timer(){


    //     while (true){


    //         if(have_scripts){

    //             int k = 0;
                      
    //             for( int i = 0 ;  i<10  ;i++  ){

    //                 if (scripts_em_espera[i] == 0) continue;

    //                 k = 1;
 
    //                 scripts_em_espera_tempo[i] = scripts_em_espera_tempo[i] - 200;
                      
    //                 if( scripts_em_espera_tempo[i] <= 0) {
                      
                    
    //                    controlador.controlador_scripts.Ativar_script(scripts_em_espera[i]);
    //                    scripts_em_espera[i] = 0;
    //                    scripts_em_espera_tempo[i] = 0;
    //                    break;

    //                }

    //             }

    //             if(k ==0) have_scripts = false;
                 

    //         }

              

           
    //         yield return  new WaitForSeconds(0.2f);

    //     }

      

        

    // }
    

     






}