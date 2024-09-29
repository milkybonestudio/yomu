

unsafe public struct Character_political_data {


        // tem 2 tipos de social score : nacional e regional

        public fixed ushort social_score[ DIC__character_political_data.social_scores_kingdoms ]; // depende do reino
        public ushort social_score_region; // dados ficam somente nas regios, quando um personagem mudar de regiao vai ser mudado

        

        // ** 
        public fixed ushort character_social_attributes[ DIC__character_political_data.social_specific_attributes ];  // more worth with enums 

}


