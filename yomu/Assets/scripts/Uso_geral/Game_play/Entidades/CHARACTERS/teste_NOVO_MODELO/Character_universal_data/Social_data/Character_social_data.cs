

unsafe public struct Character_social_data {
    

    
        // ** esses dados nao vao ter as informacoes completas, os dados completos vão provavelmente passar desse ponto, eles vao precisa ser dinamicamente criados dependendo da quantidade
        public fixed int friends[ DIC__social_data.friend_numbers ];   
        public fixed float friends_values[ DIC__social_data.friend_numbers ]; // friendship_level
        public byte best_friend; // can be 0


        public fixed int enimies[ DIC__social_data.friend_numbers ];   
        public fixed float enemies_values[ DIC__social_data.friend_numbers ]; // friendship_level
        public byte worst_enemy; // can be 0

        
    

}




