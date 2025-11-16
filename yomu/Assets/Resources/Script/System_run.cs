

public static class System_run {


    #if UNITY_EDITOR

        public const bool WORK_IN_BUILD = false;
        public const bool NOT_IN_BUILD = true;

    #else

        public const bool WORK_IN_BUILD = true;
        public const bool NOT_IN_BUILD = false;

    #endif

    

    public static bool force_stop;



    // --- PROGRAM
    
        public const bool activate_crash_handler = true || WORK_IN_BUILD;

        public const bool show_program_messages = true && NOT_IN_BUILD;
            public const bool show_program_construction_messages = true && NOT_IN_BUILD;


    // --- CONTROLL OVER NORMAL CONTROLLERS

        // *** SAFETY_STACK

        public const bool activate_controller_safety_stack = WORK_IN_BUILD || true ;
            public const bool save_in_disk_controller_safety_stack = WORK_IN_BUILD || true;
            public const bool show_stack_messages = true && NOT_IN_BUILD;
            public const bool show_stack_messages_update = true && NOT_IN_BUILD;
            public const bool show_stack_messages_buffer = true && NOT_IN_BUILD;
            

        // --- TASKS

        public const bool tasks_show_messages = false && NOT_IN_BUILD;

        // --- MULTITHREAD

        public const bool multithread_show_messages = false && NOT_IN_BUILD;


        // --- PACKET STORE

        public const bool packet_storage_show_messages = true && NOT_IN_BUILD;
            public const bool packet_show_messages = true && NOT_IN_BUILD;

        // --- HEAP

        public const bool heap_show_messages = false && NOT_IN_BUILD;


        // --- FILES

        public const bool files_show_messages = false && NOT_IN_BUILD;



    // --- NORMAL CONSTRUCTION

    // --- SETTINGS

        public const bool max_security = true && NOT_IN_BUILD;
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


