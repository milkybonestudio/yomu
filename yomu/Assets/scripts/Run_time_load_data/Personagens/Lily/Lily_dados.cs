using UnityEngine;
using System;


// passar para o geral depois






/*

    o formato seria: 

     Lily_dados => Construtor_update_tipo_1 => Update_1 
                                            => Update_2
                                            => ....
                => ...
     Seria melhor usar classes estaticas com cada metodo mas talvez seja muito arriscado pelo que eu testei antes. 
     Fazer outro teste ( ;-; ) Fazer com +- 50mb dll. se der certo fazer com static => nao precisa construir objetos  
     Na realidade se os metodos forem objetos eu vou usar ainda menos espaço?

     os updates nao vao ser descartados com facilidade. pegar outro => tem tempo => pode criar instancia

     talvez eu só seja retardado e tem algum loop no meio?
*/


public class Lily_dados {

        public Lily_construtor_update_run_time construtor_update_run_time = new Lily_construtor_update_run_time();
        public Lily_construtor_update_periodo construtor_update_run_periodo = new Lily_construtor_update_periodo();
        public Lily_construtor_update_dia construtor_update_dia = new Lily_construtor_update_dia();
        public Construtor_update_semana construtor_update_semana = new Lily_construtor_update_semana();
        public Construtor_update_mes construtor_update_mes = new Lily_construtor_update_mes();

        

        public void Pegar_dados(){

                 // esse metodo vai ser 
        
                Personagem lily = Controlador_personagens.Pegar_instancia().Pegar_personagem( Personagem_nome.Lily );
                  
                byte[] dados_para _iniciar = Lily.dados_updates;

               /*
                     ** todos tem somente 1 byte
                     formato :   [     run_time , periodo , dia , semana ,  mes  ]
         
               */

                Lily_update_run_time update_run_time = ( Lily_update_run_time ) dados_para_iniciar[ Index_updates.run_time ];
                Lily.Update_run_time = Construtor_update_run_time( update_run_time );
                
                
                return;

        }

}







