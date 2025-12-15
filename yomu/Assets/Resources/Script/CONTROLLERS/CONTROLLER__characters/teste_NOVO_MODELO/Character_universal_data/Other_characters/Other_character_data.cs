

// => eu nao sei como conversa vai funcionar 


// => a estruturacao do objeto ( pergunta : resposta )



 // pergunta generica 
 // pergunta especifica


 // { pergunta : resposta } => conhecimento


 // conhecimento => #id na struct + struct


 // 




// ** struct grande 
unsafe public struct Other_character_data {

        // ** oque o personagem é
        public int character_id;
        public byte character_tier;
        public byte sexual_attraction_level;
        

        public Base_emotions emotion_modifier; // normal covnersation
        public Base_emotions emotion_modifier_sexual_context; // sexual 



        public Other_character_conversation_data conversation_data;
            


}


unsafe public struct Other_character_conversation_data {

        // ** se for o mesmo do atual nao aplica nenhum modificador
        public int time_last_covnersation;
        public int time_last_covnersation_flirt;

        // ** normal conversation

                // ** questions

                    // ** todo personagem que TIVER alguma resposta viagem vai ter um texto especifico para explicar a resposta
                    // ** se perguntar para lily quem é o gevernador do reino dos elfos ela vai falar algo como "obviamente é o shablau abdull jabab"
                    // ** mas para saber qual default usar a pergunta precisa ter algum indentificador 

                    
                    public Other_character_question question_0;
                    public Other_character_question question_1;
                    public Other_character_question question_2;
                    public Other_character_question question_3;
                    public Other_character_question question_4;
                    public Other_character_question question_5;
                    public Other_character_question question_6;
                    public Other_character_question question_7;
                
            // ** small talk data

                // ** sempre ativado quando 2 personagens conversarem

                // ** é ativado o do personagem que iniciou a conversa. Se for null vai com o default, sempre vai ser algo como "Oh? look whos here" ou algo que nao precise ser muito especifico.
                // ** esse texto nem vai aparecer a nao ser que o player nao estiver vendo
                public Locator_conversation_script conversation_script;


            



        // ** flirt


}


unsafe public struct Locator_conversation_script {
    

}


unsafe public struct Other_character_question{


    // ** pode ser por carta ou por conversa

        // ** todas as perguntas sao publicas
        // ** se um personagem nao saber a resposta ele so nao responde nada ou fala que nao sabe 
        public int id;
        public byte importance;

        // ** verifica se ainda quer/precisa fazer a pergunta
        public int filter_internal_flag; // ** iria setar uma informacao interna, como "manter_pergunta_X", se essa flag fosse deletada essa pergutna tamém seria 
        public int filter_time; // ** faria sentido se a pergunta fosse relacionada com algo temporal. resposta com valor 0 semrpe seria "nao perguntou"

        // ** todos os filter tem que passar para a pergutna ser feita
        public int filter_location; // 
        public int filter_emotions; // 
        public byte filter_timeframe; //

}


unsafe public struct Other_character_sexual_data {

        // ** se for o mesmo do atual nao aplica nenhum modificador
        public int time_last_sex;
        
        

}
