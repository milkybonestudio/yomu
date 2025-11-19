

public static class TOOL__run_time_folders_constructor {

    public static void Construct(){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will cosntruct run time folders" ); }


        // ---- saving_run_time_folder
        // -------- ( NOT CONSTRUCT< ONLY WHEN USED ) saving_files_folder 
        // -------- stack 

        System.IO.Directory.CreateDirectory( Paths_program.saving_run_time_folder );

        if( System_run.show_program_construction_messages )
            { Console.Log( "Constructed run_time_folder" ); }

            System.IO.Directory.CreateDirectory( Paths_program.safety_stack_folder );

            if( System_run.show_program_construction_messages )
                { Console.Log( "Constructed safety_stack_folder" ); }



        
        if( System_run.show_program_construction_messages )
            { Console.Log( "--- FINSH CONSTRUCT RUN TIME FOLDERS ---" ); }

    }

}