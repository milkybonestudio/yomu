



/*
        login

        read general_file -> get login_type -> use login data to create login on type -> login
        get login_type -> Create_program_mode
        create login data -> Create state
        use login data -> normal

        iniciar o modo -> aplicar os dados

        [ arquivo ] 

        op 1 : nao usar o arquivo -> forçar com logica
        op 2 : mudar o arquivo e deixar a logica normal

*/





unsafe public abstract class Test_development {

    
    public virtual void Set_program_environment(){
                             

        Console.Log( "----Set_program_environment is set as the <Color=lightBlue>default</Color>" );


              if( Development_tests.program_mode == Program_mode.login )
                {
                    PROGRAM_DATA__login* data = &( Controllers_program.data.pointer->login );

                        STRING.Transfer_string_to_char_pointer( data->image_path, PROGRAM_DATA__login.image_path_limit, "image_login_1" );
                        
                    Program_data.Get_lock( Program_mode.login )->put_data = true;
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.login, new Transition_data() ); 

                }
        else if(  Development_tests.program_mode == Program_mode.menu )
                {

                    PROGRAM_DATA__menu* menu_data = &Controllers_program.data.pointer->menu;
                    Program_data.Get_lock( Program_mode.menu )->put_data = true;
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.menu, new Transition_data() ); 


                }
        else if(  Development_tests.program_mode == Program_mode.jogo )
                {

                    // ** VAI PARA O MINIMO QUE O GAME PRECISA
                    PROGRAM_DATA__game* game_data = &Controllers_program.data.pointer->game;

                        game_data->save = 0;

                    Program_data.Get_lock( Program_mode.jogo )->put_data = true;
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.jogo, new Transition_data() ); 
                    
                }                

    }

    public abstract void Create_state();
    public virtual void Start(){ Console.Log( "----Start is set as the <Color=lightBlue>default</Color>" ); }
    public virtual void Update( Control_flow _flow ){}
    public virtual void End(){ Console.Log( "----End is set as the <Color=lightBlue>default</Color>" ); }

}
