



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

unsafe public class Crash_handle_ephemeral_files {


    public Crash_handle_ephemeral_files(){

        files = new Dictionary<string, byte[]>( 1_000 );
        Load_recursive( Paths_version.path_to_version, files );

        active_files = new Dictionary<string, bool>();

        // ** la arte de la gambiarra
        // ** vai dar 1 slot extra para ig
        // active_files[ _STRING_TO_IGNORE ] = true;

    }

    // public const string _STRING_TO_IGNORE = "?? used_to_ignor_zero_index ??";

    public Dictionary<string, byte[]> files;

    // ** if true will make an operation on the file in disk at the end
    public Dictionary<string, bool> active_files;


    public string[] Get_active_paths(){

        if( active_files.Count == 0 )
            { return new string[ 0 ]; }

        string[] paths = active_files.Keys.ToArray();

        // int index_to_change = Array.IndexOf( paths, _STRING_TO_IGNORE );

        // string valid_path = paths[ 0 ];
        // paths[ index_to_change ] = valid_path;

        return paths;

    }

    public void Switch_file( string _path, byte[] _data ){

        Set_active( _path );
        files[ _path ] = _data;

    }

    public byte[] Get_file( string _path ){

        Set_active( _path );
        return  files[ _path ];

    }


    public byte[] Create_new_file( string _path, int _length ){

        Set_active( _path );
        files[ _path ] = new byte[ _length ];
        return files[ _path ];
    }

    public void Delete_file( string _path ){

        Set_active( _path );
        files[ _path ] = null;
        return;

    }

    public bool Have_file( string _path ){

        return files.ContainsKey( _path );

    }



    private void Set_active( string _path ){

        Console.Log( "active path: " + _path );
        active_files[ _path ] = true;

    }



    public const int MAX_LENGTH_FILES = 500_000_000;

    private int current_bytes;
    private void Load_recursive( string path, Dictionary<string, byte[]> _files ){

        // pega todos os arquivos do folder atual
        foreach ( string file in Directory.GetFiles( path ) ){

            files[file] = File.ReadAllBytes( file );
            Console.Log( "will load the file in the path: " + file );
            current_bytes += files[file].Length;
        }

        if( current_bytes > MAX_LENGTH_FILES )
            { CONTROLLER__errors.Throw("file size explode BUUUUUm"); }

        foreach ( string dir in Directory.GetDirectories( path ) )
            { Load_recursive( dir, files ); }

        
    }


}

