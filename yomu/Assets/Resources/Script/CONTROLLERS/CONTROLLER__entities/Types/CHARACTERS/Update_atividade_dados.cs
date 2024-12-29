


// ** update movimento deveria ser 
unsafe public struct Update_atividade_dados {


        // --- INTENCOES        
        public sbyte atividade_que_ganhou; //    0 => nada sign => dever (-) / desejo (+). 5 => index 4

        // --- ATIVIDADES DEVER

                public fixed int local_dever[ 10 ];
                public fixed short atividade_dever[ 10 ];
                public fixed short necessidade_dever[ 10 ];
                public fixed byte tipo_atividade_dever[ 10 ];

                public fixed int personagens_no_local_negativo_dever[ 10 * 5 ]; // --- tira desejo da atividade
                public fixed int personagens_no_local_positivo_dever[ 10 * 5 ]; // --- auemnta o desejo da atividade

    
        // --- ATIVIDADE DESEJOS

                public fixed int local_desejo[ 10 ];
                public fixed short atividade_desejo[ 10 ];
                public fixed short vontade[ 10 ];
                public fixed byte tipo_atividade_desejo[ 10 ];

                public fixed int personagens_no_local_negativo_desejo[ 10 * 5 ]; // --- tira desejo da atividade
                public fixed int personagens_no_local_positivo_desejo[ 10 * 5 ]; // --- auemnta o desejo da atividade


        // --- DADOS
        public int update_atividade_id;
        public int update_atividade_sub_id; // ** especifico
        
        // ** se ativo ignora o update normal
        public int update_id_sistema; // 0 => nao tem;

        
        // --- TRACK
        // ** se mover mais de 20 comeca a deletar 
        public fixed int localizadores[ 20 ];
        public fixed byte localizadores_periodos[ 5 ];
        public byte pointer_atual;


}


unsafe public struct Desejo_atividade {

        // ** 

        // ** atividade que nao entra no default
        public short atividade; // 15 
        public sbyte nivel_desejo;    // 97 => alto +, -97 => alto -
        public byte expressao_do_desejo;  // como o personagem se comporta sobre o desejo
    
}


public enum Expressao_desejo {


        express_for_itself = 0b00000001,
        express_to_everyone = 0b00000010,

        express_friends = 0b00000100,
        express_for_good_friends = 0b00001000,
        express_for_friend_with_benefits = 0b00010000,
        express_for_best_friends = 0b00100000,

        express_for_lover = 0b01000000,
        express_for_enemies = 0b10000000,

        
}



// ** isso teria 500b / personagem
unsafe public struct Routine {

        // ** vai ser somente os deveres normais 

        // 0 => nao definido 
        public fixed int atividade_dia[ 5 * 7 * 4 ]; // periodo, dia semana, semana mes
        public int periodos_dever_feito; // quando nao tem nada definido nao conta


}

public struct Dever_atividade {

    public Dever_localizador dever_localizador;
    
    public byte giver;      // 0 => nada
                            // 1 => yourself
                            // 2 => other character
                            // 3 => quest
                            // 4 => routine 

    public byte aceita_falha;

}





public struct Dever_localizador {

    // ** nao é parte do dever em si
    public byte who_give;   // 0 => nada
                            // 1 => yourself
                            // 2 => 


    public byte type;       // 0=> nada
                            // 1 => generico # ir para a aula #
                            // 2 => generico mas especifico local/tempo  # ir para a aula de pesca cathedral #
                            // 3 => especifico personagem # falar com lala sobre tapete#

    public byte category;


    public int dever_id; // 0 => nada      dever < 0 => generico      => ir_para_aula
                                        // dever > 0 => especifico

}



public struct Personagem_desejos {


        public byte geral; // define qual o padrao dos itens    

        //public int atividades[  ]

        public int item;


}


