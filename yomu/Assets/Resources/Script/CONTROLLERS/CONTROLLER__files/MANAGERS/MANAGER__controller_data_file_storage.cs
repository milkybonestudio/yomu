

using System;
using System.Collections.Generic;
using System.Linq;



public enum File_IO_operation {

    _not_give,

        _add,
        _delete,

}



unsafe public struct MANAGER__controller_data_file_storage {

    public static MANAGER__controller_data_file_storage Construct(){

        MANAGER__controller_data_file_storage manager = default;
            
            manager.path_TO_id = new Dictionary<string, int>( 50 );
            manager.id_TO_path = new Dictionary<int, string>( 50 );
            manager.current_files = new Dictionary<int, Data_file_link>( 50 );

            manager.cached_data_files = new Dictionary<string, Data_file_link>();
            manager.deleted_files = new Dictionary<string, Data_file_link>();

        return manager;

    }


    public Dictionary<string,int> path_TO_id;
    public Dictionary<int,string> id_TO_path;

    public Dictionary<int,Data_file_link> current_files;

    // ** files that would be in disk when saved, also count as files
    public Dictionary<string,Data_file_link> cached_data_files;
    public Dictionary<string,Data_file_link> deleted_files;


    public void Sinalize_saved_files(){

        // free memory 

        foreach( Data_file_link data in cached_data_files.Values )
            { Controllers.heap.Return_key( data.heap_key ); }

        foreach( Data_file_link data in deleted_files.Values )
            { Controllers.heap.Return_key( data.heap_key ); }

        cached_data_files.Clear();
        deleted_files.Clear();

        return;

    }

    public int[] Get_current_files_ids(){

        int[] ids = current_files.Keys.ToArray<int>();
        Array.Sort( ids );
        return ids;

    }



    public void Force_syncronize_to_disk_PROGRAM_CONSTRUCTOR(){

        
        foreach( Data_file_link data in current_files.Values ){

            string path = id_TO_path[ data.id ];
            Files.Save_critical_file( path, data.Get_pointer(), data.Get_length() );

        }

        foreach( var kv in cached_data_files ){ 

            string path = kv.Key;
            Data_file_link data = kv.Value;

            Files.Save_critical_file( path, data.Get_pointer(), data.Get_length() );

        }

        foreach( var kv in deleted_files ){ 
            
            string path = kv.Key;
            Data_file_link data = kv.Value;

            if( System.IO.File.Exists( path ) )
                { System.IO.File.Delete( path ); }
            
        }

    }

    public bool Have_files_any_kind(){

        return ( ( current_files.Count + cached_data_files.Count + deleted_files.Count ) > 0 );

    }

    public void Reset(){

        foreach( Data_file_link data in current_files.Values )
            { Controllers.heap.Return_key( data.heap_key ); }

        foreach( Data_file_link data in cached_data_files.Values )
            { Controllers.heap.Return_key( data.heap_key ); }

        foreach( Data_file_link data in deleted_files.Values )
            { Controllers.heap.Return_key( data.heap_key ); }

        cached_data_files.Clear();
        deleted_files.Clear();

        current_files.Clear();
        path_TO_id.Clear();
        id_TO_path.Clear();

        return;

    }


    // public string[] Get_current_links_lines(){

    //     if( Controllers.files.storage.id_TO_path.Count == 0 )
    //         { return new string[]{ "0??NULL" }; }

    //     int[] sorted_ids = Controllers.files.storage.id_TO_path.Keys.ToArray();
    //     Array.Sort( sorted_ids );

    //     string[] result = new string[ sorted_ids.Length ];

    //     for( int index = 0 ; index < result.Length ; index++ ){

    //         int id = sorted_ids[ index ];
    //         string path = Controllers.files.storage.id_TO_path[ id ];
    //             result[ index ] = $"{ id.ToString() }??{ path }";
    //     }

    //     return result;

    // }


    // public string[] _Get_current_links_lines(){

    //     if( Controllers.files.storage.id_TO_path.Count == 0 )
    //         { return new string[]{ "0??NULL" }; }

    //     int max_key = Controllers.files.storage.id_TO_path.Keys.Max();

    //     string[] result = new string[ ( max_key + 1 ) ];

    //     foreach (var kv in Controllers.files.storage.id_TO_path ) 
    //         { result[ kv.Key ] = kv.Value; }

    //     return result;

    // }


 

    public bool Have_data_in_cache( string _path ){

        return cached_data_files.ContainsKey( _path );
    }


    public Data_file_link Get_via_cached_data( string _path ){

        Data_file_link cached_data = cached_data_files[ _path ];
        Data_file_link new_data = Lock_slot_recicle( _path, cached_data_files[ _path ] );

        // ** technically it will save the data as "0".data or something
        // ** but if it saves in disk means that the new data also will be saved 
        // ** so even if id 20 "erased" the data the new id 30 will switch for the right version

        cached_data.heap_key = Controllers.heap.Get_empty();
        cached_data_files[ _path ] = cached_data;

        //mark
        // ** tirar daqui!!!
        Controllers.stack.files.Save_data_got_file_from_disk( new_data.id, _path );
        
        Add_current( new_data, _path );

        return new_data;

    }





    // --- API

    public void Add_file( Data_file_link _data, string _path ){

        
        if( id_TO_path.ContainsKey( _data.id ) )
            { CONTROLLER__errors.Throw( $"try to add the file id <Color=lightBlue>{ _data.id }</Color> but it already exists" ); }

        Add_current( _data, _path );
        return;

    }

    public void Remove_file( Data_file_link _data ){


        if( !!!( id_TO_path.ContainsKey( _data.id ) ) )
            { CONTROLLER__errors.Throw( $"Dont have key to remove file for the id <Color=lightBlue>{ _data.id }</Color>" ); }

        string path = id_TO_path[ _data.id ];

        Removed_current( path );
        cached_data_files[ path ] = _data;

        return;

    }


    public Data_file_link Delete_file( string _path ){
        
        Data_file_link data = default;

            if( path_TO_id.ContainsKey( _path ) )
                {
                    int id = path_TO_id[ _path ];
                    data = current_files[ id ];
                    Removed_current( _path );
                }
        else if( cached_data_files.ContainsKey( _path ) )
                { 
                    data = cached_data_files[ _path ];
                    cached_data_files.Remove( _path );
                }
        else if( true )
                {
                    // ** is delete a file that the system don't own
                    data = Lock_slot_delete( _path );
                }

        if( System_run.files_show_messages )
            { Console.Log( $"Move file to deleted files. path: <Color=lightBlue>{ _path }</Color>" ); }

        deleted_files[ _path ] = data;
        return data;

    }



    public Data_file_link Lock_slot( string _path, int _size ){

        
        Heap_key heap_key = Controllers.heap.Get_unique( _size );

        int id = Controllers.paths_ids.Get_id_from_path( _path );

        Data_file_link data = new(){
            heap_key = heap_key,
            size = _size,
            id = id
        };

        Add_file( data, _path );

        
        return data;

    }

    public Data_file_link Lock_slot_delete( string _path ){

        
        Heap_key heap_key = Controllers.heap.Get_empty();;

        int id = Controllers.paths_ids.Get_id_from_path( _path );
        
        Data_file_link data = new(){
            heap_key = heap_key,
            size = 0,
            id = id
        };
        
        return data;

    }



    public Data_file_link Lock_slot_recicle( string _path, Data_file_link _cached_data ){

        CONTROLLER__errors.Throw( "asd" );
        // current_file_id += 1;
        // _cached_data.id = current_file_id;
        return _cached_data;
        
    }

    

    public bool Is_file_already_taken( int _id ){

        return id_TO_path.ContainsKey( _id );

    }

    public bool Is_file_already_taken( string _path ){

        return path_TO_id.ContainsKey( _path );

    }


    public bool Is_file_in_cache( string _path ){

        return cached_data_files.ContainsKey( _path );

    }


    public bool Is_file_in_delete_cache( string _path ){

        return deleted_files.ContainsKey( _path );

    }


    public bool File_exist_in_final_disk( string _path ){

        return !!!( deleted_files.ContainsKey( _path ) ) && ( System.IO.File.Exists( _path ) || cached_data_files.ContainsKey( _path ) || path_TO_id.ContainsKey( _path ) );

    }




    public bool Is_id_valid( int _id ){

        return id_TO_path.ContainsKey( _id );

    }



    public Data_file_link Get_data( string _path ){

        return current_files[ path_TO_id[ _path ] ];

    }


    public Data_file_link Get_data( int _file_id ){

        return current_files[ _file_id ];

    }



    public string Get_path_for_file( Data_file_link _data ){

        if( System_run.max_security )
            {
                if( _data.id == 0 )
                    { CONTROLLER__errors.Throw( "The data id is 0, so the data_link is with default values" ); }

                if( _data.id < 0 )
                    { CONTROLLER__errors.Throw( $"The data id is <Color=lightBlue>{ _data.id }</Color>, is invalid" ); }

                if( !!!( id_TO_path.ContainsKey( _data.id ) ) )
                    { CONTROLLER__errors.Throw( $"Tried to use the Id <Color=lightBlue>{ _data.id }</Color> but it is not valid" ); }

            }

        return id_TO_path[ _data.id ];
    }



    private void Add_current( Data_file_link _data, string _path ){
        
        deleted_files.Remove( _path );

        id_TO_path[ _data.id ] = _path;
        path_TO_id[ _path ] = _data.id;
        current_files[ _data.id ] = _data;


    }

    private void Removed_current( string _path ){


        int id = path_TO_id[ _path ];
        Console.Log( "came to remove id: " + id );
        id_TO_path.Remove( id );
        path_TO_id.Remove( _path );
        current_files.Remove( id );

    }



}