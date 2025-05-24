


public class Development__TEST : Development_mode {



    public void Apply_development_modifications_start( CONTROLLER__development _controller ){}
    public void Apply_development_modifications_end( CONTROLLER__development _controller ){

        _controller.test.Construct();

    }


    public void Update( Control_flow _flow, CONTROLLER__development _controller ){

            _controller.test.Update( _flow );

    }




}