using System;

public static class Requests_verifier {


    public static void Verify_transition_request( Transition_request _req ){

            if( _req.task_to_execute_on_hide == null )
                { CONTROLLER__errors.Throw( "Não foi colocado a task no transition request"  ); }
            return;

    }


}
