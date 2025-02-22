



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
                    PROGRAM_DATA__login* data = Program_data.Lock_data__LOGIN();

                        LOGIN_DATA_GLOBAL_persistent* global_persistent = &( data->global.persistent );
                
                        STRING.Transfer_string_to_char_pointer( global_persistent->image_path, LOGIN_DATA_GLOBAL_persistent.image_path_limit, "image_login_1" );
                        
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.login, new Transition_program_data() ); 

                }
        else if(  Development_tests.program_mode == Program_mode.menu )
                {

                    PROGRAM_DATA__menu* menu_data = Program_data.Lock_data__MENU();
                    
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.menu, new Transition_program_data() ); 


                }
        else if(  Development_tests.program_mode == Program_mode.game )
                {

                    // ** VAI PARA O MINIMO QUE O GAME PRECISA
                    PROGRAM_DATA__game* game_data = Program_data.Lock_data__GAME();

                        game_data->save = 0;

                    Controllers_program.program_transition.Switch_program_mode( Program_mode.game, new Transition_program_data() ); 
                    
                }                

    }

    public abstract void Create_state();
    public virtual void Start(){ Console.Log( "----Start is set as the <Color=lightBlue>default</Color>" ); }
    public virtual void Update( Control_flow _flow ){}
    public virtual void End(){ Console.Log( "----End is set as the <Color=lightBlue>default</Color>" ); }

}
