


unsafe public abstract class In_game_test {

    
    public virtual void Set_program_environment(){
                             

        Console.Log( "----Set_program_environment is set as the <Color=lightBlue>default</Color>" );


              if( Editor_run.program_mode == Program_mode.login )
                {
                    PROGRAM_DATA__login* data = Controllers_program.data.modes.Get_data__LOGIN();

                        LOGIN_DATA__global* global = &( data->global );
                
                        STRING.Transfer_string_to_char_pointer( global->image_path, LOGIN_DATA__global.image_path_limit, "image_login_1" );
                        
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.login, new Transition_program_data() ); 

                }
        else if(  Editor_run.program_mode == Program_mode.menu )
                {

                    PROGRAM_DATA__menu* menu_data = Controllers_program.data.modes.Get_data__MENU();
                    
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.menu, new Transition_program_data() ); 

                }
        else if(  Editor_run.program_mode == Program_mode.game )
                {

                    // ** VAI PARA O MINIMO QUE O GAME PRECISA
                    PROGRAM_DATA__game* game_data = Controllers_program.data.modes.Get_data__GAME();

                        game_data->global.save = 0;

                    Controllers_program.program_transition.Switch_program_mode( Program_mode.game, new Transition_program_data() ); 
                    
                }                

    }

    public abstract void Create_state();
    public virtual void Start(){ Console.Log( "----Start is set as the <Color=lightBlue>default</Color>" ); }
    public virtual void End(){ Console.Log( "----End is set as the <Color=lightBlue>default</Color>" ); }
    public virtual void Update( Control_flow _flow ){}

}
