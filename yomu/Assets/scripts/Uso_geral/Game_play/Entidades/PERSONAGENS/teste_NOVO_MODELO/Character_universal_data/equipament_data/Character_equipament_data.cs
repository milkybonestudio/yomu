

unsafe public struct Character_equipament_data {


        // ** items combate 
        public int head_slot;
        public int cape_slot;
        public int torso_slot;
        public int legs_slot;
        public int boots_slot;
        public int gloves_slot;
        public int necklace_slot;

        public int item_slot_1;
        public int item_slot_2;
        public int item_slot_3;

        //** roupa

        public byte roupa; // ** muda visivel, tem espeficido para cada personagem

    
        public fixed ushort character_social_attributes[ DIC__character_equipament_data.equipament_specific_attributes ];  // more worth with enums 

}




