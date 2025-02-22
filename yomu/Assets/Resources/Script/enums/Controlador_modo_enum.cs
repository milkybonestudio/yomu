

public enum Program_mode {


        not_give = 0b__0000_0000__0000_0000__0000_0000__0000_0000,

            nothing = 0b__0000_0000__0000_0000__0000_0000__0000_0001, // ** somente virtual
            rebuild_save = 0b__0000_0000__0000_0000__0000_0000__0000_0010, // ** somente quando o jogo iniciar 
            login = 0b__0000_0000__0000_0000__0000_0000__0000_0100,
            menu = 0b__0000_0000__0000_0000__0000_0000__0000_1000,
            game = 0b__0000_0000__0000_0000__0000_0000__0001_0000,
            test = 0b__0000_0000__0000_0000__0000_0000__0010_0000,

        END = 0b__0000_0000__0000_0000__0000_0000__0100_0000,



        //transicao,

}


public struct _Program_state {

    public byte mode;
    public bool is_changing_block;
    public bool is_changing_block_mode;
    

}
