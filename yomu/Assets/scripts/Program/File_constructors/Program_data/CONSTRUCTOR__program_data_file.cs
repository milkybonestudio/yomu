


unsafe public static class CONSTRUCTOR__program_data_file {


        public static void Construct_new_program_file( Program_data* _data ){

            *(int*)& ( _data->program_modes) = 55;
            FILE_CREATOR__program_modes.Construct( &( _data->program_modes ) );

        }


}



unsafe public static class FILE_CREATOR__program_modes {


        public static void Construct( Program_modes_data* _data ){

                Construct__LOGIN( &( _data->login ) );
                Construct__MENU( &( _data->menu ) );
                Construct__GAME( &( _data->game ) );
                Construct__NEW_GAME( &( _data->new_game ) );


        }

        private static void Construct__LOGIN( PROGRAM_DATA__login* _login_data ){

            _login_data->type = Login_type.standart;

        }

        private static void Construct__MENU( PROGRAM_DATA__menu* _menu_data ){

            _menu_data->type = Menu_type.standart;
            
        }


        private static void Construct__GAME( PROGRAM_DATA__game* _game_data ){

            _game_data->type = Game_type.standart;
            
        }

        private static void Construct__NEW_GAME( PROGRAM_DATA__new_game* _new_game_data ){

            _new_game_data->type = New_game_type.standart;

        }





}
