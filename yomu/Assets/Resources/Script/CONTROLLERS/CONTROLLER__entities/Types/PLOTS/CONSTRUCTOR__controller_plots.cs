using System;

public unsafe static class CONSTRUCTOR__controller_plots {


        public static CONTROLLER__plots Construct( Game_current_state* _game_current_state ){

                CONTROLLER__plots construtor = new CONTROLLER__plots();
                CONTROLLER__plots.instance = construtor;

                return construtor;


        }


}