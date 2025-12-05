

using System.IO;
using System.Runtime.CompilerServices;


/*

    program
        program_data.dat
        program.heap

        saving_run_time
                -> safety_stack
                    -> safety_stack.dat
                    -> safety_stack.switch
                -> saving_files
                    -> files ... 
*/



public static class Paths_program {

    //mark
    // ** por hora vai ser MUITO simples
    // ** vai ter somente 2 arquivos grandes, Program.dat + Program.heap e Save.dat e Save.heap
    // ** vai ser praticamente impossivel eu sozinho conseguir produzir tanto ao ponto que importe
    // ** ** isso só seria importante se precisasse carregar os dados somente quando o necessario
    // ** ** mas uma simplificacao que eu vou fazer é que dados e funcoes sempre vão estar disponiveis 
    // ** ** mesmo quando começar a ficar grande vai ser mais importante fracionar as funcoes do que os dados. Para cada byte de info vão ter muitos bytes de funcoes 


    public static void Define_program_folder( string _path_to_program_folder ){

        program_path = _path_to_program_folder;

        program_data = Get_program_data();
        program_storage_SIMPLE = Get_program_storage_SIMPLE();

        current_packets_storages = Get_current_packets_storages();
                

        return;
        
    }

        
    public static string program_path;



    public const string program_data_NAME = "program_data.dat";
    public static string program_data;
    public static string Get_program_data(){ return Combine( program_path, program_data_NAME ); }
    public static string Get_program_data( string _path ){ return Combine( _path, program_data_NAME ); }


    public const string program_storage_SIMPLE_NAME = "program_storage_SIMPLE.storage";
    public static string program_storage_SIMPLE;
    public static string Get_program_storage_SIMPLE(){ return Combine( program_path, program_storage_SIMPLE_NAME ); }
    public static string Get_program_storage_SIMPLE( string _path ){ return Combine( _path, program_storage_SIMPLE_NAME ); }


    public const string current_packets_storages_NAME = "current_packets_storages.txt";
    public static string current_packets_storages;
    public static string Get_current_packets_storages(){ return Combine( program_path, current_packets_storages_NAME ); }
    public static string Get_current_packets_storages( string _path ){ return Combine( _path, current_packets_storages_NAME ); }




    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string Combine( string _str_1, string _str_2 ){

        if( _str_1 == null )
            { return null; }

        return Path.Combine( _str_1, _str_2 );

    }



}