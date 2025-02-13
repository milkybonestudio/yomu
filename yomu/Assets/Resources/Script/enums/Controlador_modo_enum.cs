

public enum Program_mode {


        not_give,

            test,
            nothing, // ** somente virtual
            reconstruindo_save, // ** somente quando o jogo iniciar 
            login,
            menu,
            jogo,

        END,

        //transicao,

}


public struct _Program_state {

    public byte mode;
    public bool is_changing_block;
    public bool is_changing_block_mode;
    

}
