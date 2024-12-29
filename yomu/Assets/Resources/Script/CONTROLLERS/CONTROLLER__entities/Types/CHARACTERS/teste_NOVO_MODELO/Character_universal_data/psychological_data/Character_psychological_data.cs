

unsafe public struct Character_psychological_data {

        // aqui vai ficar coisas como niveis de felicidade, niveis defaults de felicidade e etc

        public Character_memory_data character_memory_data;


        // ** coisas como depressao, passivo_agressivo, fala baixo, fala alto
        public fixed ushort character_psychological_attributes[ DIC__character_psychological_data.psychological_specific_attributes ];  // more worth with enums 

}


