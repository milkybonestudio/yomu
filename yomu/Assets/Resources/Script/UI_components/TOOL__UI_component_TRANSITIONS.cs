using System;


unsafe public static class TOOL__UI_component_TRANSITIONS  {


    public static void Update_nothing( UI_component _UI, Action _force_nothing ){

        if( ( _UI.final_state == UI_component_state.active ) || ( _UI.final_state == UI_component_state.inactive ) )
            {
                _force_nothing();
                _UI.transitions.nothing__TO__inactive.Prepare();
                _UI.current_state = UI_component_state.transition_nothing_TO_inactive;
                // Console.Log( "Vai para  <Color=lightBlue>transition_nothing_TO_inactive</Color>" );
            }


    }
    public static bool Update_transition_nothing_TO_inactive( UI_component _UI ){

        bool finished_transition = _UI.transitions.nothing__TO__inactive.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _UI.transitions.nothing__TO__inactive.Finish();
                _UI.current_state = UI_component_state.inactive;
                // Console.Log( "Finalizou <Color=lightBlue>nothing_TO_inactive</Color>" );

                if( _UI.final_state == UI_component_state.inactive )
                    {}

                if( _UI.final_state == UI_component_state.active )
                    {
                        _UI.transitions.inactive__TO__active.Prepare();
                        _UI.current_state = UI_component_state.transition_inactive_TO_active;
                    }

                if( _UI.final_state == UI_component_state.nothing )
                    {
                        _UI.transitions.inactive__TO__nothing.Prepare();
                        _UI.current_state = UI_component_state.transition_inactive_TO_active;
                    }

            }

        return finished_transition;

    }


    public static bool Update_transition_inactive_TO_active( UI_component _UI ){

        bool finished_transition = _UI.transitions.inactive__TO__active.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _UI.transitions.inactive__TO__active.Finish();
                _UI.current_state = UI_component_state.active;
                // Console.Log( "Finalizou <Color=lightBlue>Update_transition_inactive_TO_active</Color>" );

                if( _UI.final_state == UI_component_state.active )
                    {}

                if( ( _UI.final_state == UI_component_state.inactive ) || ( _UI.final_state == UI_component_state.nothing ) )
                    {
                        _UI.transitions.active__TO__inactive.Prepare();
                        _UI.current_state = UI_component_state.transition_active_TO_inactive;
                    }

            }

        return finished_transition;

    }


    public static bool Update_transition_active_TO_inactive( UI_component _UI ){

        bool finished_transition = _UI.transitions.active__TO__inactive.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _UI.transitions.active__TO__inactive.Finish();
                _UI.current_state = UI_component_state.active;
                // Console.Log( "Finalizou <Color=lightBlue>Update_transition_inactive_TO_active</Color>" );

                if( _UI.final_state == UI_component_state.active )
                    {}

                if( ( _UI.final_state == UI_component_state.inactive ) || ( _UI.final_state == UI_component_state.nothing ) )
                    {
                        _UI.transitions.active__TO__inactive.Prepare();
                        _UI.current_state = UI_component_state.transition_active_TO_inactive;
                    }

            }

        return finished_transition;

    }



    public static bool Update_transition_inactive_TO_nothing( UI_component _UI ){

        bool finished_transition = _UI.transitions.inactive__TO__nothing.Update();

        if( finished_transition )
            {
                // ** VAI PARA O INACTIVE
                _UI.transitions.inactive__TO__nothing.Finish();
                _UI.current_state = UI_component_state.active;
                // Console.Log( "Finalizou <Color=lightBlue>Update_transition_inactive_TO_active</Color>" );
            }

        return finished_transition;

    }











}