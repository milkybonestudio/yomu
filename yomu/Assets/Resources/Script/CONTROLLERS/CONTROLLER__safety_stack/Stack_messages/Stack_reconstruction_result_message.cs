
public struct Stack_reconstruction_result_message {

    public static Stack_reconstruction_result_message Construct( string _message, Stack_reconstruction_result _results ){

        Stack_reconstruction_result_message ret = default; 

            ret.result = _results;
            ret.message = _message;

        if( _results == Stack_reconstruction_result.fail )
            { 
                Console.Log( "<Color=red>FAILED</Color>" ); 
                Console.Log( _message );
            }

        return ret;
        
    }

    public Stack_reconstruction_result result;
    public string message;

}
