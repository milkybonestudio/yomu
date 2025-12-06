

using System;
using System.Linq;

public static class Program_context_operations {


    public static string Create_program_context_file( int[] _current_files_ids, int[] _current_packets_storages ){

        string[] files_ids_strings = _current_files_ids.Select( x => x.ToString() ).ToArray<string>();
        string[] packets_strings = _current_files_ids.Select( x => x.ToString() ).ToArray<string>();

        string file_ids = string.Join( ',', files_ids_strings );
        string packets = string.Join( ',', packets_strings );

        string[] file_lines = new string[]{
            file_ids,
            "||",
            packets
        };

        return string.Concat( file_lines );

    }

    public static Program_context Get_context( string _context_file ){

        Program_context context = new();

            string[] lines = _context_file.Split( "||" );

            string[] files_ids_string = lines[ 0 ].Split( "," );
            string[] packets_ids_string = lines[ 1 ].Split( "," );

            context.current_files_ids = files_ids_string.Select( x => Convert.ToInt32( x ) ).ToArray<int>()  ;
            context.current_packets_storages = packets_ids_string.Select( x => Convert.ToInt32( x ) ).ToArray<int>();
            Array.Sort( context.current_files_ids );
            Array.Sort( context.current_packets_storages );

        return context;

    }


}


public class Program_context {

    public int[] current_files_ids;
    public int[] current_packets_storages;

}
