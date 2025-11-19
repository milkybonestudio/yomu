


public enum Safety_stack_action_type {

    not_give,

    // FILES 
        FILES_START,

            change_data_in_file,
            create_new_file,

        FILES_END,

    // PACKET STORAGE

        STORAGE_START,

            alloc_packet,
            dealloc_packet,

        STORAGE_END,

}
