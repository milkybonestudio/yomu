


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
            
        
        return ret;

    }




}