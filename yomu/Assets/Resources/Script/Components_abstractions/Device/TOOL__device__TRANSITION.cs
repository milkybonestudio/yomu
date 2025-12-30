


using System;

unsafe public static class TOOL__device__TRANSITION {



    public static bool Update_nothing( Device _device, Action _force_nothing ){

        if( ( _device.going_to_state == Device_state.active ) || ( _device.going_to_state == Device_state.inactive ) )
            {
                _force_nothing();
                _device.transitions.nothing__TO__inactive.Prepare();
                _device.state = Device_state.transition_nothing_TO_inactive;
                // Console.Log( "Vai para  <Color=lightBlue>transition_nothing_TO_inactive</Color>" );
                return true;
            }

        return false;



    }
    public static bool Update_transition_nothing_TO_inactive( Device _device ){

        bool finished_transition = _device.transitions.nothing__TO__inactive.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _device.transitions.nothing__TO__inactive.Finish();
                _device.state = Device_state.inactive;
                // Console.Log( "Finalizou <Color=lightBlue>nothing_TO_inactive</Color>" );

                switch( _device.going_to_state ){

                    case Device_state.inactive: break;
                    case Device_state.active: _device.transitions.inactive__TO__active.Prepare(); _device.state = Device_state.transition_inactive_TO_active; break;
                    case Device_state.nothing: _device.transitions.inactive__TO__nothing.Prepare(); _device.state = Device_state.transition_inactive_TO_active; break;

                }

            }

        return finished_transition;

    }


    public static bool Update_transition_inactive_TO_active( Device _device ){

        bool finished_transition = _device.transitions.inactive__TO__active.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _device.transitions.inactive__TO__active.Finish();
                _device.state = Device_state.active;
                // Console.Log( "Finalizou <Color=lightBlue>Update_transition_inactive_TO_active</Color>" );

                switch( _device.going_to_state ){

                    case Device_state.active: break;
                    // ** same
                    case Device_state.inactive: _device.transitions.active__TO__inactive.Prepare(); _device.state = Device_state.transition_active_TO_inactive; break;
                    case Device_state.nothing: _device.transitions.active__TO__inactive.Prepare(); _device.state = Device_state.transition_active_TO_inactive; break;

                }

            }

        return finished_transition;

    }


    public static bool Update_transition_active_TO_inactive( Device _device ){

        bool finished_transition = _device.transitions.active__TO__inactive.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _device.transitions.active__TO__inactive.Finish();
                _device.state = Device_state.active;
                // Console.Log( "Finalizou <Color=lightBlue>Update_transition_inactive_TO_active</Color>" );


                switch( _device.going_to_state ){

                    case Device_state.inactive: break;
                    case Device_state.active: _device.transitions.inactive__TO__active.Prepare(); _device.state = Device_state.transition_inactive_TO_active; break;
                    case Device_state.nothing: _device.transitions.inactive__TO__nothing.Prepare(); _device.state = Device_state.transition_inactive_TO_nothing; break;

                }

            }
        
        return finished_transition;

    }



    public static bool Update_transition_inactive_TO_nothing( Device _device ){

        bool finished_transition = _device.transitions.inactive__TO__nothing.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _device.transitions.inactive__TO__nothing.Finish();
                _device.state = Device_state.active;
                Console.Log( "Finalizou <Color=lightBlue>Update_transition_inactive_TO_active</Color>" );


            }
        
        return finished_transition;

    }


}