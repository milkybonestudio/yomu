public class Lily_dados {

        public Lily_construtor_update_run_time construtor_update_run_time = new Lily_construtor_update_run_time();
        public Lily_construtor_update_periodo construtor_update_run_periodo = new Lily_construtor_update_periodo();
        public Lily_construtor_update_dia construtor_update_dia = new Lily_construtor_update_dia();
        public Construtor_update_semana construtor_update_semana = new Lily_construtor_update_semana();
        public Construtor_update_mes construtor_update_mes = new Lily_construtor_update_mes();

        

        public void Pegar_dados(){
        
                Personagem lily = Controlador_personagens.Pegar_instancia().Pegar_personagem( Personagem_nome.Lily );
            
                byte[] dados_para _iniciar = Lily.dados_updates;
                
                Lily_update_run_time update_run_time = ( Lily_update_run_time ) dados_para_iniciar[ Index_updates.run_time ];
                Lily.Update_run_time = Construtor_update_run_time( update_run_time );
                
                
                return;

        }

}
