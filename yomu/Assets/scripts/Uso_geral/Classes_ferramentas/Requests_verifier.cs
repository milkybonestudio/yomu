using System;

public static class Requests_verifier {


    public static void Verify_transition_request( Transition_request _req ){

            CONTROLLER__errors.Verify( ( _req.task_to_execute_on_hide == null ), "Não foi colocado a task no transition request"  );
            return;

    }


}
