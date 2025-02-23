using System;

public unsafe static class CONSTRUCTOR__controller_mobs {


        public static CONTROLLER__mobs Construct( Game_current_state* _game_current_state ){

                CONTROLLER__mobs construtor = new CONTROLLER__mobs();
                CONTROLLER__mobs.instance = construtor;

                return construtor;


        }

}