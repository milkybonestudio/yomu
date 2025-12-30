


public class Development__PROGRAM_MODE : Development_mode {


    public void Apply_development_modifications_start( CONTROLLER__development _controller ){}
    public void Apply_development_modifications_end( CONTROLLER__development _controller ){

                if( Editor_run.use_generic )
                    {
                        Console.Log( "Vai usar <Color=lightBlue>Generic_test</Color>" );
                        _controller.current_test = new Generic_in_game_test();
                    }
                    else
                    {

                        // ** TESTS
                        switch( Editor_run.program_mode ){
                            
                            case Program_mode.game: _controller.current_test = Tests_development__GAME.Get_test( Editor_run.block_type, Editor_run.game_test_key ); break;
                            case Program_mode.menu: _controller.current_test = Tests_development__MENU.Get_test( Editor_run.login_test_key ); break;
                            default: CONTROLLER__errors.Throw( $"Can not handle Program_mode: <Color=lightBlue>{ Editor_run.program_mode }</Color>" ); break;
                            
                        }

                    }


                if( _controller.current_test == null )
                    { CONTROLLER__errors.Throw( $"Tried to get the test for { Editor_run.program_mode } but return null" ); }


                Console.Log( "<Color=lightBlue>--Will start development test</Color>" );
                _controller.current_test.Set_program_environment();
                _controller.current_test.Create_state();
                _controller.current_test.Start();
                Console.Log( "<Color=lightBlue>-----------------</Color>" );



    }


    public void Update( CONTROLLER__development _controller ){

            _controller.current_test?.Update(); 
            _controller.development_tools.Atualizar_ferramentas_desenvolvimento();

    }




}