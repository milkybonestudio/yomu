


unsafe public struct Character_desire {


        public byte type;

    

}


unsafe public struct Character_desire_SEXUAL {

    
        public fixed uint characters[ DIC__characters_desires_data.number_sexual_character ];
        public Character_desire_modifiers modifiers;
        
        public ushort kink;

        
}



public class BIT_KEY__sexual_attraction_level {


        public const byte extreme_not_attractive    =  0b_0000_0000;
        public const byte not_attractive            =  0b_0000_0000;
        public const byte slightly_not_attractive   =  0b_0000_0000;

        public const byte neutral                   =  0b_0000_0000;

        public const byte slightly_attractive       =  0b_0000_0000;
        public const byte attractive                =  0b_0000_0000;
        public const byte extreme_attractive        =  0b_0000_0000;


}

public class BIT_KEY__character_tier {


        public const byte partner           =  0b_0000_0000;
        public const byte best_friends      =  0b_0000_0000;
        public const byte friend            =  0b_0000_0000;

        public const byte acquaint          =  0b_0000_0000;

        public const byte unlike            =  0b_0000_0000;
        public const byte enemy             =  0b_0000_0000;
        public const byte worst_enemies     =  0b_0000_0000;
        

}



unsafe public struct Character_desire_modifiers {


        // max 4 bytes 
        public Internal_changing_pointer specific_character_change_data_pointer;

        // ** mudar varias coisas
        // ** esse pointer vai ser entregue para um interpretador, nao vale a pena fazer agora 
        public Internal_pointer specific_character_change_data_complex_pointer;

        // ** nao é obrigatorio
        // ** script pode ser usado por hora no lugar do complex pointer
        // ** é mais facil escrever per.data = x do que pensar em todo o formato agora. 
        // ** esperar o heap ficar pronto 
        public Locator_character_script script;


        // ** transforma depois byte para float 
        // ** somente add
        public int emotions_to_modify_day;
        public int emotions_to_modify_week;
        public int emotions_to_modify_month;
        public int emotions_to_modify_base;


}


unsafe public struct Locator_character_script {



}




public class BIT_KEY__character_desire_origin {


        public const byte sexual           =  0b_0000_0000; //
        public const byte combat           =  0b_0000_0000; // 
        public const byte impress_someone  =  0b_0000_0000; // 
        public const byte material         =  0b_0000_0000; // 

        public const byte moral            =  0b_0000_0000; // 
        public const byte self_joy         =  0b_0000_0000; // 


}