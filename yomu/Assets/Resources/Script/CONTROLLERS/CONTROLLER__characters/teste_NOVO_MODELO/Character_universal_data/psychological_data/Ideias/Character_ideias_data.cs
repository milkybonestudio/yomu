

unsafe public struct Character_ideas_data {


        // ** vai ter coisas como "elfos nao sao seres de direitos?"

        public Character_ideas_about_race ideas_about_race_;

        public fixed byte ideas_about_race[ ( int ) Race.END ];

        // ** coisas como depressao, passivo_agressivo, fala baixo, fala alto
        public fixed ushort character_psychological_attributes[ DIC__character_psychological_data.psychological_specific_attributes ];  // more worth with enums 

}



unsafe public struct Character_ideas_about_race {

            public byte humans;


}


public class BIT_KEY__character_ideas_about_race {


        public const byte extreme_hate   = 0b_0000_0000;
        public const byte hate           = 0b_0000_0000;
        public const byte slightly_hate  = 0b_0000_0000;

        public const byte neutral        = 0b_0000_0000;

        public const byte slightly_like  = 0b_0000_0000;
        public const byte like           = 0b_0000_0000;
        public const byte extreme_like   = 0b_0000_0000;

}


