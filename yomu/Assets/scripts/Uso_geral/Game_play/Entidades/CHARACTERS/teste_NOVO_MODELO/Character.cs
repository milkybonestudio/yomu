using System.Runtime.InteropServices;


unsafe public struct Heap_data {

        public int pointer;
        public short heap_size; // kb?
        public byte heap_number;

}


public enum Heap_size {

    // ** used in the 
    nothing, 
    slot_500b,
    slot_1kb,
    slot_5kb, 
    slot_10kb,
    slot_25kb,
    slot_50kb,
    slot_100kb,

}


unsafe public struct Character {


        public int character_id;

        // ** sempre tem
        public Character_fundamental_data* fundamental_data;

        // ** carrega quando a entidade estiver ativa 
        public Character_universal_data* universal_data; // ** tem que ser entregue um pointer com o espaco, como o tamanho sempre vai ser fixo nao vai dar muitos problemas
        public Character_specific_data* specific_data;
        public Character_system_data* system_data;
        public void* heap_pointer;



}

unsafe public struct Entity_fundamental_data {

        public byte state;

}


public enum Entity_state {


    unload, 
    unloading,
    load,
    loading,

}

public struct Character_fundamental_data {


        public Entity_fundamental_data entity_data;

        public int specific_data_length; 

        // ** dados que sempre vao estar na ram
        public int character_unique_id; // ** vai ser armazenado com sort


            // projecoes 
        //  entre 0 e 100.  
        // se o personagem ainda nao foi apresentado vira projecao
        public byte interesse_player;
        public byte afetividade;

        public short periodo_ultimo_update;

        public int atividade_atual_id;


        public bool personagem_bloqueado;
        public bool personagem_ja_foi_apresentado_ao_player;

}




