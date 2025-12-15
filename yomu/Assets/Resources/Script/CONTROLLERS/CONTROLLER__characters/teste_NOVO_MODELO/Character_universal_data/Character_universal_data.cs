
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;



unsafe public struct Character_universal_data {

        // ** sempre que os dados forem acessados 

        // --- posicao 
        public Locator_local_position local_position;
        public Locator_global_position* locator_global_position_pointer_; // o global fica nos dados essenciais 


        //** self
        public Character_physical_data character_physical_data; 
        public Character_psychological_data character_psychological_data; 


        // ** game data 
        public Character_system_data character_system_data;
        public Character_skills_data character_skills_data;



        // ** parte relacionamentos
        public Character_sexual_data character_sexual_data;
        public Character_romantic_relationships_data character_romantic_relationships_data;
        public Character_social_data character_social_data;
        public Character_political_data character_political_data;

        
               
            
        // ** things
        public Character_equipament_data character_equipament_data;
        public Character_room_data character_room_data;
        public Character_bank_data character_bank_data;



        //**



}

