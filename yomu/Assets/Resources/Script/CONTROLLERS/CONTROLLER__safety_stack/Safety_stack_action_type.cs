


public enum Safety_stack_action_type {

    //mark
    // ** need to add: 
    //    delete file

    not_give,

    // FILES 
        FILES_START,

            change_data_in_file,

            create_new_file, // ** sinalize creation of empty file. If the file have data will be ( create_new_file ) + ( change_data_in_file )
            got_file_from_disk, // ** load the data and gives it an id

            change_length_file,

        FILES_END,

    // PACKET STORAGE

        STORAGE_START,

            alloc_packet,
            dealloc_packet,

        STORAGE_END,

}
