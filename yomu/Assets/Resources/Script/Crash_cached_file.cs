


public struct Crash_cached_file {

    /*
        path[ n ] -> null + data[ n ] -> null ==> empty
        path[ n ] -> "path" + data[ n ] -> byte[]    ==> active data
        path[ n ] -> "path" + data[ n ] ->  null   ==> deleted the file
    */

    
    public string path;
    public byte[] data;


    // logica não vai funcionar 
    public bool Is_deleted(){

        return ( path != null ) && ( data == null );

    }

    public bool Have_content(){

        return ( data != null );

    }

}
