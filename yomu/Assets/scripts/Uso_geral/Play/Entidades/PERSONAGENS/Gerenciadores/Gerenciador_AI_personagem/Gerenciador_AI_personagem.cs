using System;


public class Gerenciador_AI_personagem {

        public System.Object personagem_AI;
        // talvez fique melhor ter osmente gerenciador_AI


        public enum Dados_bool {


            lily_comeu_biscoito,


        }



        public Estado_mental estado_mental = new Estado_mental();


        public Action Update_run_time;
        public Action Update_periodo;
        public Action Update_dia;
        public Action Update_semana;
        public Action Update_mes;


        // MES   SEMANA  DIA   periodo   run_time
        public System.Action[] Updates_movimento = new System.Action[ 5 ];

        public Action[] updates;


}


