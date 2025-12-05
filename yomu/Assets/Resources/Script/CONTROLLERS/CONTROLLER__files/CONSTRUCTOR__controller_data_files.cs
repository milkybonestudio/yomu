


using System;
using System.Collections.Generic;

public static class CONSTRUCTOR__controller_data_files {

    public static CONTROLLER__data_files Construct(){


        if( System_run.show_program_construction_messages )
            { Console.Log( "Constructed saving_link_file_to_path" ); }

        CONTROLLER__data_files ret = default;

            ret.state = Controller_data_files_state.waiting_to_save_files;

            ret.operations = MANAGER__controller_data_file_operations.Construct();
            ret.storage = MANAGER__controller_data_file_storage.Construct();

            string[] lines =  System.IO.File.ReadAllLines( Paths_version.data_link_current_files );

            int max_slot = 0;

            foreach( string line in lines ){

                string[] id_AND_path = line.Split( "??" );

                if( id_AND_path.Length != 2 )
                    { CONTROLLER__errors.Throw( $"could not split text { line } of data_links_current_files" ); }

                int id = Convert.ToInt32( id_AND_path[ 0 ] );
                string path = id_AND_path[ 1 ];

                if( id > max_slot )
                    { max_slot = id; }

                // ** will be with correct id
                ret.operations.Get_file_start_program( path, id );

            }

            ret.storage.current_file_id = max_slot;
            
        
        return ret;

    }


}