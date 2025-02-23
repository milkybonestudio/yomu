using System;

public unsafe static class CONSTRUCTOR__controller_traders {


        public static CONTROLLER__traders Construct( Game_current_state* _game_current_state ){

                CONTROLLER__traders construtor = new CONTROLLER__traders();
                CONTROLLER__traders.instance = construtor;

                return construtor;

        }


}