


using System.Collections.Generic;

public static class CONSTRUCTOR__controller_data_files {

    public static CONTROLLER__data_files Construct(){

        CONTROLLER__data_files controller = new CONTROLLER__data_files();

            System.IO.File.WriteAllLines( Paths_program.saving_link_file_to_path, new string[]{ "CAN NOT USE" } );

            if( System_run.show_program_construction_messages )
                { Console.Log( "Constructed saving_link_file_to_path" ); }



        return controller;

    }

}