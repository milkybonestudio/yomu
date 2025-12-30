

public static class System_run {



    // ** LOGIC
    
    public static int main_thread_id;
    public static bool game_on;
    public static bool acesso_internet;



    // ** FLAGS 

    #if UNITY_EDITOR

        public const bool WORK_IN_BUILD = false;
        public const bool NOT_IN_BUILD = true;

    #else

        public const bool WORK_IN_BUILD = true;
        public const bool NOT_IN_BUILD = false;

    #endif

    

    public static bool force_stop;



    // --- PROGRAM

        public const bool show_program_messages = true && NOT_IN_BUILD;

            // é do crash_handle, renomear depois
            public const bool show_program_construction_messages = false && NOT_IN_BUILD;
            public const bool show_program_construction_messages_messages_detail_in_block = false && NOT_IN_BUILD;
            public const bool show_program_construction_messages_messages_detail_in_messages = false && NOT_IN_BUILD;
            public const bool show_program_construction_messages_can_break_if_change_warns = false && NOT_IN_BUILD;


        // --- SUPPORT SYSTEMS
    
            public const bool activate_crash_handler = true || WORK_IN_BUILD;



    // --- CONTROLL OVER NORMAL CONTROLLERS

        // *** SAFETY_STACK

        public const bool activate_controller_safety_stack = false || WORK_IN_BUILD;
            public const bool save_in_disk_controller_safety_stack =  true || WORK_IN_BUILD;

            public const bool show_stack_messages = false && NOT_IN_BUILD;
            public const bool show_stack_messages_update =  true && show_stack_messages && NOT_IN_BUILD;
            public const bool show_stack_messages_buffer = false && show_stack_messages && NOT_IN_BUILD;
            public const bool show_stack_messages_saver = false && show_stack_messages && NOT_IN_BUILD;
            public const bool show_stack_messages_message_constructor = false && show_stack_messages && NOT_IN_BUILD;

            

        // --- TASKS

        public const bool tasks_show_messages = false && NOT_IN_BUILD;

        // --- MULTITHREAD

        public const bool multithread_show_messages = false && NOT_IN_BUILD;


        // --- PACKET STORE

        public const bool packet_storage_show_messages = false && NOT_IN_BUILD;
            public const bool packet_show_messages = true && NOT_IN_BUILD;
            public const bool packet_show_messages_full_detail = false && packet_show_messages && NOT_IN_BUILD;

        // --- HEAP

        public const bool heap_show_messages = false && NOT_IN_BUILD;

        // --- SAVIGN

        public const bool saving_show_messages = false && NOT_IN_BUILD;


        // --- FILES

        public const bool files_show_messages = false && NOT_IN_BUILD;




    // --- NORMAL CONSTRUCTION

    // --- SETTINGS

        public const bool max_security = true && NOT_IN_BUILD;
        public const bool ignore_path = true && NOT_IN_BUILD;
        
        public const bool warnings = true && NOT_IN_BUILD;












    // --- PERFORMANCE

        // SHORT PROBLEM

            public const bool show_big_cpu_performance_impact_SHORTER = false && NOT_IN_BUILD;
            public const bool show_mid_cpu_performance_impact_SHORTER = false && NOT_IN_BUILD;
            public const bool show_small_cpu_performance_impact_SHORTER = false && NOT_IN_BUILD;

            public const bool show_big_ram_performance_impact_SHORTER = false && NOT_IN_BUILD;
            public const bool show_mid_ram_performance_impact_SHORTER = false && NOT_IN_BUILD;
            public const bool show_small_ram_performance_impact_SHORTER = false && NOT_IN_BUILD;

        // LONGER PROBLEM

            public const bool show_big_cpu_performance_impact_LONGER = false && NOT_IN_BUILD;
            public const bool show_mid_cpu_performance_impact_LONGER = false && NOT_IN_BUILD;
            public const bool show_small_cpu_performance_impact_LONGER = false && NOT_IN_BUILD;

            public const bool show_big_ram_performance_impact_LONGER = false && NOT_IN_BUILD;
            public const bool show_mid_ram_performance_impact_LONGER = false && NOT_IN_BUILD;
            public const bool show_small_ram_performance_impact_LONGER = false && NOT_IN_BUILD;

   
}



