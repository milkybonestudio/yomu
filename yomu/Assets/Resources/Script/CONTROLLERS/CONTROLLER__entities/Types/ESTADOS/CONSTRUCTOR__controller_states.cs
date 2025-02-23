using System;

public unsafe static class CONSTRUCTOR__controller_states {


        public static CONTROLLER__states Construct( Game_current_state* _game_current_state ){

                CONTROLLER__states construtor = new CONTROLLER__states();
                CONTROLLER__states.instance = construtor;

                return construtor;



        }


}