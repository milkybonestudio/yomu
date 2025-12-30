

public struct Crash_handle_return {

    public static Crash_handle_return Construct( string _message, Crash_handle_result _result, Crash_handle_route _route ){

        Controllers.crash_handler.Delete_all();
        Crash_handle_return ret = new Crash_handle_return(){ message = _message, result = _result, route = _route };

        Console.Log( "vai setar ret" );
        Controllers.crash_handler.current_return = ret;

        return ret;
    }

    public Crash_handle_result result;
    public Crash_handle_route route;
    public string message;


}
