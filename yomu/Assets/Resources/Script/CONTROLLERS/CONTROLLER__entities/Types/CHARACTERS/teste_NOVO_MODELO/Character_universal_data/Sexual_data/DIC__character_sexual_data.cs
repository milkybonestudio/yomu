
public class DIC__character_sexual_data {
        

        // -- preferences

            // ** kinks 

            public const int number_kinks = 100;

        public const int physical_specific_attributes_attractive = 20;
        public const int physical_specific_attributes_unattractive = 20;

        public const int psychological_specific_attributes_attractive = 20;
        public const int psychological_specific_attributes_unattractive = 20;


}





public class BIT_KEYS__kink_value {


        public const byte really_like       = 0b_0000_0001;
        public const byte like              = 0b_0000_0010;
        public const byte slightly_like     = 0b_0000_0100;

        public const byte neutral           = 0b_0000_1000;
        
        public const byte slightly_dislike  = 0b_0001_0000;
        public const byte dislike           = 0b_0010_0000;
        public const byte really_dislike    = 0b_0100_0000;

        public const byte dont_know_about   = 0b_1000_0000;

}


public enum Kinks_types {

        // ** vai juntar muita coisa, pode ser das coisas mais normais até coisas mais perturbadoras
        // ** quando algum personagem fizer alguma acao  

        moral,
        different,
        immoral,
        illegal,
        objectvly_wrong,


}

public enum KINK__moral {

        start_pointer = ( ( Kinks_types.moral << 8 ) - 1 ),


        



}




