

public enum Controlador_modo : byte {


        nada,

        login,
        menu,
        jogo,


        reconstruindo_save,

        desenvolvimento,

        //transicao,

}


public struct Program_state {

    public byte mode;
    public bool is_changing_block;
    public bool is_changing_block_mode;
    

}
