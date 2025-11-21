


using System.Collections.Generic;

public static class CONSTRUCTOR__controller_data_files {

    public static void Construct( ref CONTROLLER__data_files controller ){


        System.IO.File.WriteAllLines( Paths_program.saving_link_file_to_path, new string[]{ "CAN NOT USE" } );

        if( System_run.show_program_construction_messages )
            { Console.Log( "Constructed saving_link_file_to_path" ); }

        controller.path_TO_id = new Dictionary<string,int>( 100 );
        controller.id_TO_path = new Dictionary<int,string>( 100 );
        controller.current_files = new Dictionary<int, Data_file_link>( 100 );
        controller.lock_obj = new System.Object();
            

        return;

    }

}