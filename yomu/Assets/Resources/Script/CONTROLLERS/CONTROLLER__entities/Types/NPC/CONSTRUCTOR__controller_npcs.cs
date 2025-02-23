using System;

public unsafe static class CONSTRUCTOR__controller_npcs {


        public static CONTROLLER__npcs Construct( Game_current_state* _game_current_state ){

                CONTROLLER__npcs construtor = new CONTROLLER__npcs();
                CONTROLLER__npcs.instance = construtor;

                return construtor;


        }


}