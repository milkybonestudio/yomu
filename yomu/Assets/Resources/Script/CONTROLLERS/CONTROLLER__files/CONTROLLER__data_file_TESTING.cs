

using System.Linq;

unsafe public struct CONTROLLER__data_file_TESTING {

    public void Save_link_paths_sync(){

        
        string[] result = Controllers.files.storage.Get_current_links_lines();
        Files.Save_critical_file( Paths_run_time.saving_link_file_to_path, result );

        return;

    }


}