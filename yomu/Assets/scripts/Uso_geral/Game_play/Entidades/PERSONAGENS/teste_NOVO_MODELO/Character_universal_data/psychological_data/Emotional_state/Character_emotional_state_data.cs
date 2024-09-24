

unsafe public struct Character_emotional_state_data {



        public uint actual_emotion;
        
        public Base_emotions current_emotions; 
        public Base_emotions emotions_daily; // muda a toda troca de periodo, é como se fisesse um ponto medio do atual e do daily 
        public Base_emotions emotions_week; // muda quando o persoangem dormir, faz uma media entrega a ultima daily e a week atual
        public Base_emotions emotions_month; // mesma dinamica
        public Base_emotions base_emotions; // dificil de mudar, certos personagens podem mudar mais facil para + do que para menos 




        
}

