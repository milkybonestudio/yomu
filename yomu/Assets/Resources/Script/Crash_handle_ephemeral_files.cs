



using System;
using System.Collections.Generic;
using System.IO;

unsafe public class Crash_handle_ephemeral_files {


    public Crash_handle_ephemeral_files(){

        files = new Dictionary<string, byte[]>( 1_000 );
        Load_recursive( Paths_version.path_to_version, files );

    }


    public void Switch_file( string _path, byte[] _data ){

        files[ _path ] = _data;

    }

    public byte[] Get_file( string _path ){

        return  files[ _path ];

    }


    public byte[] Create_new_file( string _path, int _length ){

        files[ _path ] = new byte[ _length ];

        return files[ _path ];
    }

    public void Delete_file( string _path ){

            files[ _path ] = null;

    }

    public bool Have_file( string _path ){

        return files.ContainsKey( _path );

    }

    public byte[] Change_length_file( string _path, int _new_length ){

        byte[] old_file = files[ _path ];

            Array.Resize( ref old_file, _new_length );

            files[ _path ] = old_file;

        return old_file;

    }


    public Dictionary<string, byte[]> files;

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

