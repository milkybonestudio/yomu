using System;

public unsafe static class CONSTRUCTOR__controller_cities {


    public static CONTROLLER__cities Construct( Game_current_state* _game_current_state ) {

            #if UNITY_EDITOR
                return Construct_EDITOR( _game_current_state );
            #endif
            
	}

    public static CONTROLLER__cities Construct_EDITOR( Game_current_state* _game_current_state ){

            if( CONTROLLER__cities.instance != null )
                { return CONTROLLER__cities.instance; }


            CONTROLLER__cities controller = new CONTROLLER__cities();
            CONTROLLER__cities.instance = controller;

                controller.Put_information  (
                                                _fundamental_length: sizeof( City_fundamental_data ),
                                                _generic_length:  sizeof( City_generic_data )    
                                            );

            return controller;

    }


}