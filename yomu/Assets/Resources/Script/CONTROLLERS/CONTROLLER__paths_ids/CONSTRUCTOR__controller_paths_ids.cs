

using System.Collections.Generic;

public static class CONSTRUCTOR__controller_paths_ids {

    public static CONTROLLER__paths_ids Construct(){
        CONTROLLER__paths_ids ret = default;
            ret.path_TO_id = new Dictionary<string, int>( 100 );
            ret.id_TO_path = new Dictionary<int, string>( 100 );
            ret.path_TO_id[ "INVALID" ] = 0;
            ret.id_TO_path[ 0 ] = "INVALID";
        return ret;
    }


}