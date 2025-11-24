


using System.Collections.Generic;

public static class CONSTRUCTOR__controller_data_files {

    public static void Construct( ref CONTROLLER__data_files controller ){


        System.IO.File.WriteAllLines( Paths_program.stack_start_files, new string[]{ null } );

        if( System_run.show_program_construction_messages )
            { Console.Log( "Constructed saving_link_file_to_path" ); }

        controller.state = Controller_data_files_state.waiting_to_save_files;

            controller.operations = MANAGER__controller_data_file_operations.Construct();
            controller.storage = MANAGER__controller_data_file_storage.Construct();
        
        
        return;

    }

}