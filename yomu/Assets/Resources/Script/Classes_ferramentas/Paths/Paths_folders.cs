using System.IO;

public static class Paths_folders {


        // public static string current_persistent_path = Path.Combine( Paths_system.persistent_data_path, "current" );
            public static string saves = Path.Combine( Paths_system.persistent_data_path, "saves" );
            public static string program = Path.Combine( Paths_system.persistent_data_path, "program" );




        public static string Get_heap_save( int _save ){ return System.IO.Path.Combine( Get_save( _save ), "data_heap" ); }


        public static string Get_save( int _save ){

                if( _save > 7 )
                    { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }

                return System.IO.Path.Combine( Paths_folders.saves, ( "save_" + _save.ToString() ) );

        }


        public static string Get_saves_death( int _save ){ return System.IO.Path.Combine( Get_save( _save ) , "death"  ); }
        public static string Get_specific_save_death( int _save,  int _slot ){ return System.IO.Path.Combine( Get_saves_death( _save ) , ( "death_" + _slot.ToString() ) ); }




}
