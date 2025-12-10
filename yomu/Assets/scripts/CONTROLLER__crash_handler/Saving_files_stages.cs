

public enum Saving_files_stages{


    waiting_to_start,

    // ** context, new paths_ids
    logic_data_saved,

    // ** all the id.action saved in the saving_folder
    data_files_saved_in_folder,

    // ** all the files are updated 
    data_files_actions_applied,

    // ** move the context and new_paths_ids
    // logic_files_moved, 

    // ** cleaned the stack and delete things 
    saving_finished,

}