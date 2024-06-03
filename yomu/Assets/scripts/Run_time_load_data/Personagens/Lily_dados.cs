using UnityEngine;
using System;

// passar para o geral depois

public enum Lily_update_periodo {

        NULL = 0,
    
}

public enum Lily_update_run_time {

        NULL = 0,
    
}

/*
    ** todos tem somente 1 byte
    formato :   [     run_time , periodo , dia , semana ,  mes  ]

*/

public enum Index_updates{

    run_time, 
    periodo, 
    dia,
    semana, 
    mes,
    
}

/*

    o formato seria: 

     Lily_dados => Construtor_update_tipo_1 => Update_1 
                                            => Update_2
                                            => ....
                => ...
     Seria melhor usar classes estaticas com cada metodo mas talvez seja muito arriscado pelo que eu testei antes. 
     Fazer outro teste ( ;-; ) Fazer com +- 50mb dll. se der certo fazer com static => nao precisa construir objetos  
     Na realidade se os metodos forem objetos eu vou usar ainda menos espaço?

     talvez eu só seja retardado e tem algum loop no meio?
*/

public class Construtor_update_run_time {

    
    public Action Pegar( Lily_update_tun_time _nome_update ){

            switch( _nome_update ){

                case Lily_update_tun_time.NULL : return new Run_time_DEFAULT().fn;
                case Lily_update_tun_time.DEFAULT : return new Run_time_DEFAULT().fn;
                    
            }

        
    }
    
    
}

public class  Run_time_DEFAULT {

    public void fn() {

            // aqui 

        

        
    }
        
}
    


public class Lily_dados {

    public 

    public void Pegar_dados( Personagem _lily ){

            byte[] dados_para _iniciar = _lily.dados_updates;

            Lily_update_run_time update_run_time = ( Lily_update_run_time ) dados_para_iniciar[ Index_updates.run_time ];
            _lily.Update_run_time = Lily_construtor_update_run_time();
            

            switch( update_run_time ) {
                    // colocar updates 
                case Lily_update_run_time.NULL : _lily.Update_run_time = null;  break;
                default : throw new Exception( "tipo update nao foi encontrado, veio:" + update_run_time );
                    
            }

        
        
            return;
        
    }

}
