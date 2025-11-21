using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.IO;

/*
    Constrains:
        => por hora não vai descarregar um arquivo, se ele pega um, vai ficar até o final 

*/


unsafe public struct CONTROLLER__data_files {


    public Controller_data_files_state state;
    public Task_req task_files;

    public CONTROLLER__data_file_TESTING test;

    public MANAGER__controller_data_file_operations operations;

    public void Update(){

        switch( state ){

            case Controller_data_files_state.saving_files: Handle_saving_files(); break;
            case Controller_data_files_state.waiting_to_save_files: Handle_waiting_to_save_files(); break;

        }

    }

    private void Handle_saving_files(){

        if( task_files.Is_finalized() )
            {
                Controllers.stack.Sinalize_saved_all_files();
                state = Controller_data_files_state.waiting_to_save_files;
            }

    }

    private void Handle_waiting_to_save_files(){

        if( Controllers.stack.saver.Stack_file_is_close_to_end() && ( Controllers.stack.state == SAFETY_STACK__state.waiting_to_save_stack ) )
            { 
                state = Controller_data_files_state.saving_files;
                Controllers.stack.Sinalize_will_save_files();
            }

        return;
        
    }




    public Object lock_obj;

    // ** call only when the file already exists
    public Data_file_link Get_file( string _path ){

        // no need to use stack

        lock( lock_obj ){

            if( System_run.max_security )   
                {
                    if( _path == null  )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but teh path is <Color=lightBlue>NULL</Color>" ); }

                    if( Directories.Is_sub_path( _path, Paths_system.persistent_data )  )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but teh path is <Color=lightBlue>NULL</Color>" ); }

                    if( !!!( Is_file_already_taken( _path )) )
                        { CONTROLLER__errors.Throw( $"Tried to get the file in the path <Color=lightBlue>{ _path }</Color>, but it dosent exist" ); }
                    
                }

            int id = path_TO_id[ _path ];
            return current_files[ id ];

        }
        
    }


    // ** 
    public Data_file_link Get_file_from_disk( string _path ){

        // add slot

        lock( lock_obj ){

            if( System_run.max_security )
                {
                    if( _path == null  )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but teh path is <Color=lightBlue>NULL</Color>" ); }

                    if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but teh path <Color=lightBlue>{ _path }</Color> is not part of <Color=lightBlue>{ Paths_system.persistent_data }</Color>" ); }

                    if( Is_file_already_taken( _path ) )
                        { CONTROLLER__errors.Throw( $"Tried to get the file <Color=lightBlue>{ _path }</Color> from disk, but the system already heve it in with the index <Color=lightBlue>{ path_TO_id[ _path ] }</Color>" ); }
                }

            
            byte[] data = System.IO.File.ReadAllBytes( _path );

            Data_file_link data_link = Lock_slot( _path, data.Length );

            Files.Transfer_data( data, data_link.heap_key.Get_pointer() );

            Controllers.stack.files.Save_data_got_file_from_disk( data_link.id, _path );

            return data_link;

        }

    }





    public Data_file_link Create_new_file( void* _file_pointer, int _file_length, string _path ){

        // ** call only when create run time files

        if( System_run.max_security )
            { 
                if( _file_pointer == null )
                    { CONTROLLER__errors.Throw( $"null pointer in Create_new_file" ); }

                if( _file_length == 0 )
                    { CONTROLLER__errors.Throw( $"Came in Create_new_file() but the file_length is <Color=lightBlue>0</Color>" ); }

                if( _file_length == 0 )
                    { CONTROLLER__errors.Throw( $"Came in Create_new_file() but the file_length is negative: <Color=lightBlue>{ _file_length }</Color>" ); }

                if( _path == null )
                    { CONTROLLER__errors.Throw( $"null path in Create_new_file" ); }

                if( Directories.Is_sub_path( _path, Paths_system.persistent_data )  )
                    { CONTROLLER__errors.Throw( $"Tried to get a file but teh path is <Color=lightBlue>NULL</Color>" ); }

                if( System.IO.File.Exists( _path ) )
                    { CONTROLLER__errors.Throw( $"Tried to create a file in the path <Color=lightBlue>{ _path }</Color> but the file already exists" );  }

                if( Is_file_already_taken( _path ) )
                    { CONTROLLER__errors.Throw( $"Tried to create a file in the path <Color=lightBlue>{ _path }</Color> but the file was already in the dictionary" ); }
            }


        Data_file_link data_file = Lock_slot( _path, _file_length );

            Controllers.stack.files.Save_data_create_new_file( data_file.id, _file_length, _path );
            Controllers.stack.files.Save_data_change_data_in_file( 
                _file_id                : data_file.id,
                _file_point_to_change   : 0,
                _data_pointer           : _file_pointer, 
                _length                 : _file_length

            );

        VOID.Transfer_data( _file_pointer, data_file.Get_pointer(), _file_length );

        return data_file;

    }




    public Data_file_link Create_new_file_EMPTY( string _path, int _file_length ){

        // ** call only when create run time files

        if( System_run.max_security )
            { 
                if( System.IO.File.Exists( _path ) )
                    { CONTROLLER__errors.Throw( $"Tried to create a file in the path <Color=lightBlue>{ _path }</Color> but the file already exists" );  }

                if( path_TO_id.ContainsKey( _path ) )
                    { CONTROLLER__errors.Throw( $"Tried to create a file in the path <Color=lightBlue>{ _path }</Color> but the file was already in the dictionary" ); }
            }

        byte[] file = new byte[ _file_length ];

        // Controllers.stack.files.Save_data_create_new_file();

        fixed( byte* pointer = file )
            { Files.Save_file( _path, pointer, file.Length ); }

        return Get_file( _path );

    }


    private Data_file_link Lock_slot( string _path, int _size ){


            Heap_key heap_key = Controllers.heap.Get_unique( _size );

            current_file_id += 1;
            
            Data_file_link file_info = new(){
                heap_key = heap_key,
                size = _size,
                id = current_file_id
            };

            path_TO_id[ _path ] = current_file_id;
            id_TO_path[ current_file_id ] = _path;
            current_files[ current_file_id ] = file_info; 

            return file_info;


    }


    public bool Is_file_already_taken( string _path ){

        return path_TO_id.ContainsKey( _path );

    }


    public bool Is_id_valid( int _id ){

        return id_TO_path.ContainsKey( _id );

    }






    // ** never 0. 0 is for development
    public int current_file_id;

    public Dictionary<string,int> path_TO_id;
    public Dictionary<int,string> id_TO_path;
    public Dictionary<int,Data_file_link> current_files;
    
    
    public bool Got_file( string _path ){ return path_TO_id.ContainsKey( _path ); }















    // --- TEST

    


    public static string Get_run_time_path( int _slot, bool _is_delete = false ){

        if( _is_delete )
            { _slot *= -1;}

        return Path.Combine( Paths_program.saving_files_folder, ( INT.ToString( _slot ) + ".dat" ) );

    }


    public static string Get_run_time_path_TEMP( string _path_final ){

        return _path_final + ".temp";

    }


    private string Get_path_file( Data_file_link _data ){

        if( System_run.max_security )
            {
                if( _data.id == 0 )
                    { CONTROLLER__errors.Throw( "The data id is 0, is invalid" ); }

                if( !!!( id_TO_path.ContainsKey( _data.id ) ) )
                    { CONTROLLER__errors.Throw( $"Tried to use the Id <Color=lightBlue>{ _data.id }</Color> but it is not valid" ); }

            }

        return id_TO_path[ _data.id ];
    }

    public void Move_file( Data_file_link _data ){

        if( System_run.files_show_messages )
            { Console.Log( "Called Move_file()" ); }


        string path_run_time = Get_run_time_path( _data.id );
        string path_final = Get_path_file( _data );

        if( System_run.max_security )
            {
                if( !!!( System.IO.File.Exists( path_run_time ) ) )
                    { CONTROLLER__errors.Throw( $"Tried to move a file in the path <Color=lightBlue>{ path_run_time }</Color> but it dosent exist" ); }
            }


        if( System_run.files_show_messages )
            { Console.Log( "Will move the file" ); }

        System.IO.File.Move( path_run_time , ( path_final + ".temp" ) );

        
        if( System_run.files_show_messages )
            { Console.Log( "Moved the file" ); }

        return;

    }

    // Save_file_run_time[] -> move_file[] -> switch[]

    public void Switch_files( Data_file_link _data ){

        string path_final = Get_path_file( _data );
        string temp_file = ( path_final + ".temp" );

        if( System_run.max_security )
            {
                if( !!!( System.IO.File.Exists( path_final ) ) )
                    { CONTROLLER__errors.Throw( "In witch files the <Color=lightBlue>OLD</Color> file didn't exist" ); }

                if( !!!( System.IO.File.Exists( temp_file ) ) )
                    { CONTROLLER__errors.Throw( "In witch files the <Color=lightBlue>NEW</Color> file didn't exist" ); }

            }

        System.IO.File.Delete( path_final );
        System.IO.File.Move( temp_file, path_final );

    }

    public void Save_file_run_time( Data_file_link _data ){

        ReadOnlySpan<byte> data_span = new ReadOnlySpan<byte>( _data.Get_pointer(), _data.Get_length() );

        string path = Get_run_time_path( _data.id );

        FileStream stream = new FileStream(
            path,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            data_span.Length,
            FileOptions.WriteThrough
        );

        stream.Write( data_span );
        stream.Flush();
        stream.Close();

    }

    public bool is_reconstructing_stack;
    public void Activate__is_reconstructing_stack(){

        is_reconstructing_stack = true;
    }

    public void Deactivate__is_reconstructing_stack(){

        is_reconstructing_stack = false;
    }




}



