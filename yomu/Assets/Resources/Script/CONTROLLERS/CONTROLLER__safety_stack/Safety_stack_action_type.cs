


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

            delete_file,
            remove_file, // ** makes id invalid

        FILES_END,

    // PACKET STORAGE

        STORAGE_START,

            // ** allocation
            alloc_packet,
            dealloc_packet,

            // ** files 
            applied_new_storage_data,
            resize_size_packet_storage, 

            // ** ownership
            add_storage,
            remove_storage,


        STORAGE_END,

}
