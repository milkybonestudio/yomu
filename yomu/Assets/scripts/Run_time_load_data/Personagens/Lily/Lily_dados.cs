using UnityEngine;
using System;


// passar para o geral depois



/*
    ** todos tem somente 1 byte
    formato :   [     run_time , periodo , dia , semana ,  mes  ]

*/



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

public class Lily_construtor_update_run_time {

    public Action Pegar( Lily_update_tun_time _nome_update ){

            switch( _nome_update ){
                            // null => personagem nao ativo
                            // DEFAULT => normal personagem 
                            // os 2 podem ser null

                case Lily_update_tun_time.NULL : return null;
                case Lily_update_tun_time.DEFAULT : return new Run_time_DEFAULT().fn;
                default : throw new Exception( "tipo update nao foi encontrado, veio:" + update_run_time );
                    
            }

        
    }
    
    
}





