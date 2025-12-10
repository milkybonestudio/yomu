


public struct CONTROLLER__paths_ids_TEST {

    public void Save_paths_sync(){

        System.IO.File.Delete( Paths_version.paths_ids );
        System.IO.File.WriteAllLines( Paths_version.paths_ids, Controllers.paths_ids.Get_current_paths_ids() );
        
    }

}