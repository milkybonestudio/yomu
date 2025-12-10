using System.Collections.Generic;
using System.Linq;


unsafe public struct CONTROLLER__paths_ids {



    public void Destroy(){

        current_file_id = 0;

    }

    public bool Have_path( string _path ){

        return path_TO_id.ContainsKey( _path );

    }

    // ** never 0. 0 is for development
    private int current_file_id;
    public CONTROLLER__paths_ids_TEST test;

    public void Save_current_paths_in_disk(){

        string[] paths_ids = Controllers.paths_ids.Get_current_paths_ids();
        Files.Save_critical_file( Paths_version.paths_ids, paths_ids );

        return;
    }


    public int Get_id_from_path( string _path ){

        if( id_TO_path == null )
            { CONTROLLER__errors.Throw( $"Tried to define a new path with ids in the current program, but the Paths_manager dont have <Color=lightBlue>dic</Color>" ); }

        if( path_TO_id.ContainsKey( _path ) )
            { return path_TO_id[ _path ]; }

        int new_id = ++current_file_id;

            id_TO_path[ new_id ] = _path;
            path_TO_id[ _path ] = new_id;

        return new_id;

    }

    public void Print_ids(){

        foreach( int id in id_TO_path.Keys )
            { Console.Log( $"id { id } path { id_TO_path[ id ] }" ); }

    }

    
    // public string Get_path( int _id ){

    //     return id_TO_path[ _id ];

    // }

    public string Get_path_from_id( int _id ){

        if( id_TO_path == null )
            { CONTROLLER__errors.Throw( $"Tried to define a new path with ids in the current program, but the Paths_manager dont have <Color=lightBlue>dic</Color>" ); }

        if( !!!( id_TO_path.ContainsKey( _id ) ) )
            { Print_ids(); CONTROLLER__errors.Throw( $"Tried to get a path from an id path with ids in the current program, but the id <Color=lightBlue>{ _id }</Color>is not in the system" ); }

        return id_TO_path[ _id ];

    }

    

    // public void Set_id( int _id ){
    //     current_file_id = _id;
    // }

    public Dictionary<string, int> path_TO_id;
    public Dictionary<int, string> id_TO_path;

    public void Define_paths_ids(){

        Console.Log( "<Color=lightBlue>CAME DEFINE IDS PATHS</Color>" );

        string[] _lines = System.IO.File.ReadAllLines( Paths_version.paths_ids );

        path_TO_id = new Dictionary<string, int>( _lines.Length + 50 );
        id_TO_path = new Dictionary<int, string>( _lines.Length + 50 );

        for( int index = 0 ; index < _lines.Length ; index++ ){ 
            path_TO_id[ _lines[ index ] ] = index; 
            id_TO_path[ index ] = _lines[ index ];
        }

        //mark
        // ** testar
        current_file_id = ( _lines.Length - 1  );

        return;

    }

    public void Define_paths_ids( string _path ){

        Console.Log( "<Color=lightBlue>CAME DEFINE IDS PATHS</Color>" );

        string[] _lines = System.IO.File.ReadAllLines( _path );

        // for( int i = 0 ; i < _lines.Length ; i++ ){ Console.Log( $" id { i } path { _lines[ i ] }" ); }

        path_TO_id = new Dictionary<string, int>( _lines.Length + 50 );
        id_TO_path = new Dictionary<int, string>( _lines.Length + 50 );

        for( int index = 0 ; index < _lines.Length ; index++ ){ 
            path_TO_id[ _lines[ index ] ] = index; 
            id_TO_path[ index ] = _lines[ index ];
        }

        return;

    }


    public string[] Get_current_paths_ids(){

        if( id_TO_path == null )
            { CONTROLLER__errors.Throw( $"Tried to get the paths with ids in the current program, but the Paths_manager dont have <Color=lightBlue>dic</Color>" ); }

        string[] paths = new string[ path_TO_id.Count ];

        Console.Log( "lenght: " + paths.Length );
        Console.Log( "values: " );
        Console.Log( string.Join(   ',',  path_TO_id.Values.Select( s => s.ToString()).ToArray() ));

        Console.Update();

        for( int index = 0 ; index < paths.Length ; index++ )
            { 
                paths[ index ] = id_TO_path[ index ]; 
            }
        
        return paths;

    }



}

