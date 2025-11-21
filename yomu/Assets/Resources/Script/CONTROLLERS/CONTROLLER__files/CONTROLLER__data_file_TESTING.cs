

using System.Linq;

unsafe public struct CONTROLLER__data_file_TESTING {

    public void Save_link_paths_sync(){

        
        int max_key = Controllers.files.id_TO_path.Keys.Max();

        string[] result = new string[ ( max_key + 1) ];

        foreach (var kv in Controllers.files.id_TO_path ) 
            { result[ kv.Key ] = kv.Value; }

        Files.Save_critical_file( Paths_program.saving_link_file_to_path, result );

        return;

    }


}