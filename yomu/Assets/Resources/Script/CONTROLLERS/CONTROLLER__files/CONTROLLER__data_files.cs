using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.IO;



public enum Controller_data_files_state {

    waiting_to_save_files,
    saving_files,

} 

unsafe public class CONTROLLER__data_files {

    //mark
    // ** por hora não vai descarregar um arquivo, se ele pega um, vai ficar até o final 


    public Controller_data_files_state state;


    public void Update(){

        switch( state ){

            case Controller_data_files_state.saving_files: Handle_saving_files(); break;
            case Controller_data_files_state.waiting_to_save_files: Handle_waiting_to_save_files(); break;

        }

    }

    public Task_req task_files;
    private void Handle_saving_files(){

        if( task_files.Is_finalized() )
            {
                Controllers.stack.Sinalize_saved_all_files();
                state = Controller_data_files_state.waiting_to_save_files;
            }

    }

    private void Handle_waiting_to_save_files(){

        if( Controllers.stack.saver.Stack_file_is_close_to_end() && Can_save_files() )
            { Save_files(); }

        return;
        
    }

    private void Save_files(){

        state = Controller_data_files_state.saving_files;
        Controllers.stack.Sinalize_will_save_files();

    }


    private bool Can_save_files(){

        if( Controllers.stack.state != SAFETY_STACK__state.waiting_to_save_stack )
            { return false; }

        return true;

    }


    public void Sinalize_change_length(  ref Data_file_link _data_link, int _new_length ){

        // ** NEED? 
        Controllers.stack.Need_to_add_stack_function();

        Heap_key heap_key = Controllers.heap.Change_length_key( _data_link.heap_key, _new_length );
        _data_link.heap_key = heap_key;

        current_files[ _data_link.id ] = _data_link;
        
        return ;

    }



    public Data_file_link Get_file( string _path, int _safety_length_type ){

        lock( this ){

            // ** GET FROM DISK

            if( path_TO_id.ContainsKey( _path ) )
                { return current_files[ path_TO_id[ _path ] ]; }

            byte[] data = System.IO.File.ReadAllBytes( _path );

            if( _safety_length_type < data.Length  )
                { CONTROLLER__errors.Throw( $"the size was <Color=lightBlue>{ _safety_length_type }</Color> but the data have <Color=lightBlue>{ data.Length }</Color>" ); }

            Heap_key heap_key = Controllers.heap.Get_unique( _safety_length_type );
            current_file_id += 1;

            Files.Transfer_data( data, heap_key.Get_pointer() );
            
            Data_file_link file_info = new(){
                heap_key = heap_key,
                size = _safety_length_type,
                id = current_file_id
            };

            // Controllers.stack.

            
            path_TO_id[ _path ] = current_file_id;
            id_TO_path[ current_file_id ] = _path;
            current_files[ current_file_id ] = file_info; 

            return file_info;

        }
        
    }

    // private Data_file_link Get_file_intern( byte[] _file,  )

    public Data_file_link Create_file( string _path, int _file_length ){

        // ** call only when create run time files

        if( System_run.max_security )
            { 
                if( System.IO.File.Exists( _path ) )
                    { CONTROLLER__errors.Throw( $"Tried to create a file in the path <Color=lightBlue>{ _path }</Color> but the file already exists" );  }

                if( path_TO_id.ContainsKey( _path ) )
                    { CONTROLLER__errors.Throw( $"Tried to create a file in the path <Color=lightBlue>{ _path }</Color> but the file was already in the dictionary" ); }
            }

        byte[] file = new byte[ _file_length ];

        // Controllers.stack.files.Save_data_change_data_in_file

        fixed( byte* pointer = file )
            { Files.Save_file( _path, pointer, file.Length ); }

        return Get_file( _path, _file_length );

    }

    // ** never 0. 0 is for development
    public int current_file_id;

    public Dictionary<string,int> path_TO_id = new Dictionary<string,int>( 100 );
    public Dictionary<int,string> id_TO_path = new Dictionary<int,string>( 100 );
    public Dictionary<int,Data_file_link> current_files = new Dictionary<int, Data_file_link>( 100 );
    
    
    public bool Got_file( string _path ){ return path_TO_id.ContainsKey( _path ); }






    // --- TEST

    public void Save_link_paths_sync(){

        
        int max_key = id_TO_path.Keys.Max();

        string[] result = new string[ ( max_key + 1) ];

        foreach (var kv in id_TO_path ) 
            { result[ kv.Key ] = kv.Value; }

        Files.Save_critical_file( Paths_program.saving_link_file_to_path, result );

        return;

    }

    private string Get_run_time_path( int _slot ){

        return Path.Combine( Paths_program.saving_files_folder, ( INT.ToString( _slot ) + ".dat" ) );

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



}



