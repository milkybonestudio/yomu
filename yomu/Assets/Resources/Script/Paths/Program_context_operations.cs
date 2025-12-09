

using System;
using System.IO;
using System.Linq;


// ** trocar contexto 


public struct CONTROLLER__context{

    public static CONTROLLER__context Construct(){
        return default;
    }

    public void Destroy(){}

    // ** LOGICA AGRUPADA
    public string current_context_path;

    public void Force_change_context( string _path_to_context ){

        if( current_context_path == _path_to_context )
            { return; }

        if( !!!( System.IO.File.Exists( _path_to_context ) ) )
            { CONTROLLER__errors.Throw( "Tried to change context, but the is no file in " + _path_to_context ); }

        Program_context context = Controllers.context.Get_context_with_path( _path_to_context );

        if( current_context_path != null )
            {Controllers.saving.saver.Force_save_synchronous_safe();                 }


        Change_context_data( context );

        Controllers.stack.Restart_stack();
        Files.Save_critical_file( Paths_run_time.path_to_file_with_context_path, _path_to_context );
        current_context_path = _path_to_context;

        return;

    }

    
    public void Reset_context_data(){

        Controllers.files.Reset_files();
        Controllers.packets.Reset();
        Controllers.stack.Reset_stack();

        return;
    }

    public void Change_context_data( Program_context _context ){

        Controllers.files.Give_context( _context );
        Controllers.packets.Give_context( _context );

        return;
    }


    public void Save_current_data_as_context( string _path_to_context ){

        // ** CONTEXT
        string context = Create_program_context_file( 
            _current_files_ids: Controllers.files.storage.Get_current_files_ids(),
            _current_packets_storages: Controllers.packets.storage.Get_current_ids()
        );

        Files.Save_critical_file( _path_to_context, context );
        
    }


    public string Create_program_context_file( int[] _current_files_ids, int[] _current_packets_storages ){

        string[] files_ids_strings = _current_files_ids.Select( x => x.ToString() ).ToArray<string>();
        string[] packets_strings = _current_packets_storages.Select( x => x.ToString() ).ToArray<string>();

        string file_ids = string.Join( ',', files_ids_strings );
        string packets = string.Join( ',', packets_strings );

        string[] file_lines = new string[]{
            file_ids,
            "|",
            packets
        };

        return string.Concat( file_lines );

    }

    public Program_context Get_context_with_path( string _context_path ){

        string _context_file = System.IO.File.ReadAllText( _context_path );

        Program_context context = new();

            string[] lines = _context_file.Split( "|" );
            if( lines.Length != 2 )
                { CONTROLLER__errors.Throw( "Can not split: " + _context_file ); }

            string[] files_ids_string = lines[ 0 ].Split( "," );
            string[] packets_ids_string = lines[ 1 ].Split( "," );

            int[] current_files_ids = INT.array_0;
            int[] current_packets_storages = INT.array_0;

            if( files_ids_string[ 0 ] != "" )
                { current_files_ids = files_ids_string.Select( x => Convert.ToInt32( x ) ).ToArray<int>(); }

            if( packets_ids_string[ 0 ] != "" )
                { current_packets_storages = packets_ids_string.Select( x => Convert.ToInt32( x ) ).ToArray<int>(); }

            context.current_files_ids = current_files_ids;
            context.current_packets_storages = current_packets_storages;

            Array.Sort( context.current_files_ids );
            Array.Sort( context.current_packets_storages );

        return context;

    }


}


