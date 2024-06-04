using System;

public class Lily_construtor_update_dia {
    // todos as classes estao em Run_time_scripts

    public Action Pegar( Lily_update_dia _nome_update ){

            switch( _nome_update ){

                case  Lily_update_dia.NULL : return null;

                default : throw new Exception( "tipo update nao foi encontrado, veio:" + _nome_update );
                    
            }

        
    }
    
    
}
