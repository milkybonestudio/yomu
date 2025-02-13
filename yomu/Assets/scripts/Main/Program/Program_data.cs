


public unsafe struct Program_data {

    // ** only use internally
    public Lock_program_data test_lock;

    public PROGRAM_DATA__login login;
    public PROGRAM_DATA__menu menu;
    public PROGRAM_DATA__game game;


    public static Lock_program_data* Get_lock(  Program_mode _mode ){

            Program_data* _data = Controllers_program.data.pointer;

            
            if( ( _mode == Program_mode.test ) || ( _mode == Program_mode.nothing ) )
                {
                    _data->test_lock.put_data = true;
                    
                    return &( _data->test_lock );
                }


            switch( _mode ){

                case Program_mode.login: return &( _data->login.lock_data ); 
                case Program_mode.menu: return &( _data->menu.lock_data ); 
                case Program_mode.jogo: return &( _data->game.lock_data ); 

            }
            
            return default;

    }


    public static void Construct( Program_data* _data_pointer ){

        // ** vai ser chamado somente na primeira vez que o player iniciar o jogo

        PROGRAM_DATA__login.Construct( &(_data_pointer->login) );
        PROGRAM_DATA__menu.Construct( &(_data_pointer->menu) );
        PROGRAM_DATA__game.Construct( &(_data_pointer->game) );


    }


}