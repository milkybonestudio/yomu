using System.Runtime.InteropServices;



unsafe public struct Character {

        // ** criar quando ativo
        public Character_universal_data* universal_data_pointer; // ** tem que ser entregue um pointer com o espaco, como o tamanho sempre vai ser fixo nao vai dar muitos problemas 
        public Character_specific_data* specific_data;
        public Character_system_data* system_data;  


        // ** todos os personagens sempre vao estar na memoria. quando for ativar um personagem criar as structs
        public Character_fundamental_system_data character_fundamental_system_data;
        

}





