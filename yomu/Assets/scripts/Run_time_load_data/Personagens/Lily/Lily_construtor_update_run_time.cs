public class Lily_construtor_update_run_time {
    // todos as classes estao em Run_time_scripts

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
