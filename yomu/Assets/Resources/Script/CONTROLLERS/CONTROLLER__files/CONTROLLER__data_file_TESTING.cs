

using System.Linq;

unsafe public struct CONTROLLER__data_file_TESTING {

    public void Save_link_paths_sync(){

        
        int max_key = Controllers.files.storage.id_TO_path.Keys.Max();

        string[] result = new string[ ( max_key + 1) ];

        foreach (var kv in Controllers.files.storage.id_TO_path ) 
            { result[ kv.Key ] = kv.Value; }

        Files.Save_critical_file( Paths_program.stack_start_files, result );

        return;

    }


}