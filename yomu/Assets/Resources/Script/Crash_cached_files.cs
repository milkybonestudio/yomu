

using System;
using System.Collections.Generic;

public class Crash_cached_files{


    public Dictionary<int,byte[]> id_TO_data = new Dictionary<int, byte[]>( 1_000 );
    public Dictionary<string,int> path_TO_id = new Dictionary<string,int>( 1_000 );
    public Dictionary<int,string> id_TO_path = new Dictionary<int, string>( 1_000 );



    public string Get_path( int _id ){

        return id_TO_path[ _id ];
    }
    

    public void Reset(){

        id_TO_data = new Dictionary<int, byte[]>( 1_000 );
        path_TO_id = new Dictionary<string,int>( 1_000 );
        id_TO_path = new Dictionary<int, string>( 1_000 );
    }

    public void Remove_data( int _id ){

        id_TO_data.Remove( _id );
        path_TO_id.Remove( id_TO_path[ _id ] );
        id_TO_path.Remove( _id );

    }


    public void Add_data( string _path, int _id, byte[] _data ){

        id_TO_path[ _id ] = _path;
        path_TO_id[ _path ] = _id;
        id_TO_data[ _id ] = _data;

    }

    public void Change_length_data( int _id, int _new_length ){

        byte[] data = Get_data( _id );

            Array.Resize( ref data, _new_length );

        id_TO_data[ _id ] = data;

    }

    public byte[] Get_data( string _path ){ return id_TO_data[ path_TO_id[ _path ] ];}
    public byte[] Get_data( int _id ){ return id_TO_data[ _id ]; }


    public bool Have_file( int _id ){

        return id_TO_path.ContainsKey( _id );
    }

    
    public bool Have_data( string _path ){

        return path_TO_id.ContainsKey( _path );
    }

    public bool Have_data( int _id ){

        return id_TO_data.ContainsKey( _id );
    }


}
