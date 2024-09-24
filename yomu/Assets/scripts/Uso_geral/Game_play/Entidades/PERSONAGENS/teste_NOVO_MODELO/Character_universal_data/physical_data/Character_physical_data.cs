

unsafe public struct Character_physical_data {


        // ** physical vai ser relacionado com tudo aparente do personagem



        // ** expressions

        public uint expression;

    
        public ushort hair_color;
        public ushort skin_color;
        public int height; 
        public Eye eye; 

        
        // -- body parts

            public fixed byte organs_changed[ DIC__character_physical_data.organs_changed ]; // 0=> nada

            public byte number_left_arms; 
            public byte number_right_arms; 

            public byte number_left_legs; 
            public byte number_right_legs;

            public byte number_eyes;
            public byte type_eyes;

            public byte number_tails;
            public byte type_tail;

            public byte number_wings;
            public byte type_wings;

        // 


        public fixed ushort character_physical_attributes[ DIC__character_physical_data.physical_specific_attributes ];  // more worth with enums 


}


