
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


//mark
// ** ver depois
public struct Crash_handle_return {

    public static Crash_handle_return Construct( string _message, Crash_handle_result _result, Crash_handle_route _route ){
        return new Crash_handle_return(){ message = _message, result = _result, route = _route };
    }

    public Crash_handle_result result;
    public Crash_handle_route route;
    public string message;


}

unsafe public static class Crash_handler{


    public const int MAX_LENGTH_FILES = 100_000_000;
    public static int current_bytes;

    public static byte[] stack_file;
    

    public static Crash_handle_return Deal_crash(){

        Console.Log( System_run.show_program_construction_messages, "----------------------- CALLED <Color=lightBlue>DEAL CRASH</Color> -----------------------");

        if ( Verify_if_crash_at_final_OR_start() )
            { return  Crash_handle_return.Construct( "final or start", Crash_handle_result.sucess, Crash_handle_route.all_files_already_got_saved ); }

        stack_file = System.IO.File.ReadAllBytes( Paths_run_time.safety_stack_file );

        bool already_pass_the_data = Is_stack_empty();

        if ( already_pass_the_data )
            { 
                Delete_all(); 
                return  Crash_handle_return.Construct( "already pass all the data", Crash_handle_result.sucess, Crash_handle_route.all_files_already_got_saved ); 
            }

        
        if( Need_to_reconstruct_from_stack() )
            { 
                Stack_reconstruction_result_message message_reconstruct_stack = TOOL__reconstruct_from_stack.Reconstruct();
                
                if( message_reconstruct_stack.result == Stack_reconstruction_result.fail )
                    { return File_worst_corruption( message_reconstruct_stack.message, Crash_handle_route.need_to_recosntruct_with_the_stack ); }

                return Pass_data_to_disk( Crash_handle_route.need_to_recosntruct_with_the_stack );
            }

        return Pass_data_to_disk( Crash_handle_route.all_temp_files_were_already_there_just_move );

    }


    

    private struct Crash_operation_key {


        public int file_id;
        public string file_extension;

        public string path_in_disk;
        public string final_path;
        
        public File_IO_operation operation; 
        
    }



    private static Crash_handle_return Pass_data_to_disk( Crash_handle_route _route ){

        // ** se veio aqui todos os arquivos estão ou no folder ou na pasta final, ou já foram trocados/eliminados

        Console.Log( System_run.show_program_construction_messages, "CALLED <Color=lightBlue>Pass_data_to_disk()</Color>" );
        

        Console.Log( System_run.show_program_construction_messages, "Will transform files in the saving files folder in a array of keys to save" );



        string[] link_paths_updated = System.IO.File.ReadAllLines( Paths_run_time.saving_link_file_to_path );


        Deal_edge_cases( link_paths_updated );

        string[] files_paths_in_saving_files_folder = System.IO.Directory.GetFiles( Paths_run_time.saving_files_folder );
        Dictionary<int,Crash_operation_key> file_ids_TO_key_paths = new( 100 );


        // ** valida os arquivos no saving files
        foreach( string path_in_saving_folder in files_paths_in_saving_files_folder ){

                string saving_file_name = Path.GetFileName( path_in_saving_folder );
                string extension = Path.GetExtension( saving_file_name );

                if( ( saving_file_name == Paths_run_time.saving_files_security_file_NAME ) || ( extension == ".meta" ) )
                    { continue; }

                bool name_is_a_number = int.TryParse( Path.GetFileNameWithoutExtension( saving_file_name ), out int file_id );

                if( !!!( name_is_a_number ) )
                    { return File_worst_corruption( $"There is a file with the name <Color=lightBlue>{ saving_file_name }</Color> and is invalid", _route ); }

                
                if( file_id == 0 )
                    { return File_worst_corruption( $"The file_id is 0 in the file <Color=lightBlue>{ saving_file_name }</Color> and is invalid", _route ); }

                if( file_ids_TO_key_paths.ContainsKey( file_id ) )
                    { 
                        return File_worst_corruption( 
                            $"There is a file with file_id <Color=lightBlue>{ file_id }</Color> that was saved twice in the saving_files." +
                            $" path 1: <Color=lightBlue>{ Path.GetFileName( file_ids_TO_key_paths[ file_id ].path_in_disk )  }</Color> path 2: <Color=lightBlue>{ saving_file_name }</Color>", 
                            _route
                        );
                    }

                File_IO_operation operation = default;

                switch( extension ){

                    case ".delete": operation = File_IO_operation._delete; break;
                    case ".switch": operation = File_IO_operation._switch; break;
                    case ".create": operation = File_IO_operation._create; break;
                    case ".nothing": operation = File_IO_operation._nothing; break;

                    default: return File_worst_corruption( $"One file in saving have the extension <Color=lightBlue>{ extension }</Color> in the file <Color=lightBlue>{ saving_file_name }</Color>" , _route );

                }


                file_ids_TO_key_paths[ file_id ] = new(){
                    file_id = file_id,
                    file_extension = extension,
                    path_in_disk = path_in_saving_folder,
                    operation = operation
                };

        }


        int[] sorted_ids_for_dic = file_ids_TO_key_paths.Keys.ToArray();
        Array.Sort( sorted_ids_for_dic );

        for( int index_sorted = 0 ; index_sorted < sorted_ids_for_dic.Length ; index_sorted++ ){

            int file_id = sorted_ids_for_dic[ index_sorted ];

            if( file_id > link_paths_updated.Length )
                { return File_worst_corruption( $"There is a file with slot <Color=lightBlue>{ file_id }</Color>, but the max slot based on <Color=lightBlue>saving_link_file_to_path</Color> is <Color=lightBlue>{ link_paths_updated.Length }</Color>" , _route); }

            string real_path = link_paths_updated[ file_id ];
            
            if( ( real_path == null ) || ( real_path == "" ) )
                { return File_worst_corruption( $"The path for the id <Color=lightBlue>{ file_id }</Color> is not valid" , _route); }

            if( !!!( Directories.Is_sub_path( real_path, Paths_version.path_to_version ) ) )
                { return File_worst_corruption( $"The path <Color=lightBlue>{ real_path }</Color> is not part of <Color=lightBlue>{ Paths_version.path_to_version }</Color>" , _route); }
            

            Crash_operation_key key = file_ids_TO_key_paths[ file_id ];
                key.final_path = real_path;
            file_ids_TO_key_paths[ file_id ] = key;

            continue;
            
        }
        

        Console.Log( "all the files are in the right places or in the saving_files folder" );
        for( int index_key = 0 ; index_key < sorted_ids_for_dic.Length ; index_key++ ){

            // ** if a file have changed 2 times+ in a stack treshold I know that the file id 20 cames before the 30
            // ** so if 20 creates the file and 30 switch the files it's fine
            // ** if 20 delete a file and 30 creates a new one is fine
            // ** if 20 switchs the file and 30 create a new one -> ERROR

            int lower_slot = sorted_ids_for_dic[ index_key ];
            Crash_operation_key key = file_ids_TO_key_paths[ lower_slot ];


            if( key.operation == File_IO_operation._switch )
                {
                    string path_temp = File_run_time_saving_operations.Get_run_time_path_TEMP( key.final_path, File_IO_operation._switch );

                    System.IO.File.Move( key.path_in_disk, path_temp );
                    System.IO.File.Delete( key.final_path );
                    System.IO.File.Move( path_temp, key.final_path );

                }

            if( key.operation == File_IO_operation._delete )
                {
                    if( !!!( System.IO.File.Exists( key.final_path ) ) )
                        { return File_worst_corruption( $"It tryes to DELETE a file in the path <Color=lightBlue>{ key.final_path }</Color>, but there is no file in the path", _route ); }

                    string path_temp = File_run_time_saving_operations.Get_run_time_path_TEMP( key.final_path, File_IO_operation._delete );
                    System.IO.File.Move( key.path_in_disk, path_temp );
                    System.IO.File.Delete( key.final_path );
                    System.IO.File.Delete( path_temp );
                }

            if( key.operation == File_IO_operation._create )
                {
                    if( System.IO.File.Exists( key.final_path ) )
                        { return File_worst_corruption( $"It tryes to CREATE a file in the path <Color=lightBlue>{ key.final_path }</Color>, but a file alreaady exist", _route ); }

                    System.IO.File.Move( key.path_in_disk, key.final_path );

                }

            if( key.operation == File_IO_operation._nothing )
                {
                    System.IO.File.Delete( key.path_in_disk );
                }



        }

        // ** all operations finished 

        // ** with this even if crash now will just know it saved all
        Files.Save_critical_file( Paths_run_time.safety_stack_file, new byte[ 1_000 ] );


        Delete_all();

        if( System_run.show_program_construction_messages )
            { Console.Log( "<Color=lime>ALL ARQUIVES OK</Color>" ); }

        return Crash_handle_return.Construct( "pass", Crash_handle_result.sucess, _route );

    }


    private static void Deal_edge_cases( string[] link_paths_updated ){

        EDGE_CASE__interrupt_on_switch( link_paths_updated );
        EDGE_CASE__interrupt_on_delete( link_paths_updated );
        EDGE_CASE__interrupt_on_create( link_paths_updated );

    }

    private static void EDGE_CASE__interrupt_on_switch( string[] link_paths_updated ){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will verify if there is any temp switch interrupted" ); }
        
        foreach( string final_path in link_paths_updated ){

            if( ( final_path == null ) || ( final_path == "") )
                { continue; }

            string hypothetical_temp_file =  File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, File_IO_operation._switch );

            if( System.IO.File.Exists( hypothetical_temp_file ) )
                {
                    Console.Log( $"Crash when switching file <Color=lightBlue>{ final_path }</Color> " );
                    
                    if( System.IO.File.Exists( final_path ) )
                        { System.IO.File.Delete( final_path ); }

                    System.IO.File.Move( hypothetical_temp_file, final_path );
                }

        }

    }

    private static void EDGE_CASE__interrupt_on_delete( string[] link_paths_updated ){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will verify if there is any temp switch interrupted" ); }

        foreach( string final_path in link_paths_updated ){

            if( ( final_path == null ) || ( final_path == "") )
                { continue; }

            string hypothetical_temp_file =  File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, File_IO_operation._delete );

            if( System.IO.File.Exists( hypothetical_temp_file ) )
                {
                    Console.Log( $"Crash when deleting file <Color=lightBlue>{ final_path }</Color> " );
                    
                    if( System.IO.File.Exists( final_path ) )
                        { System.IO.File.Delete( final_path ); }

                    System.IO.File.Delete( hypothetical_temp_file );
                }

        }

    }

    private static void EDGE_CASE__interrupt_on_create( string[] link_paths_updated ){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will verify if there is any temp switch interrupted" ); }

        foreach( string final_path in link_paths_updated ){

            if( ( final_path == null ) || ( final_path == "") )
                { continue; }

            string hypothetical_temp_file =  File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, File_IO_operation._create );

            if( System.IO.File.Exists( hypothetical_temp_file ) )
                {

                    Console.Log( $"Crash when creating file <Color=lightBlue>{ final_path }</Color> " );
                    System.IO.File.Move( hypothetical_temp_file, final_path );
                }

        }

    }






    private static bool Need_to_reconstruct_from_stack(){


        bool crash_when_only_the_stack_was_saving = !!!( System.IO.Directory.Exists( Paths_run_time.saving_files_folder ) );

        if( crash_when_only_the_stack_was_saving )
            { return true; }


        if( System.IO.File.Exists( Paths_run_time.saving_files_security_file ) )
            { return false; }

        
        if( System_run.show_program_construction_messages )
            {
                Console.Log( "There is no security file" );
                Console.Log( "NO SECURITY FILE + DATA STILL IN STACK -> all the temp files are in the saving files folder ( if any ) and will be discarted to use only the stack" );
            }

        System.IO.Directory.Delete( Paths_run_time.saving_files_folder, true );

        if( System_run.show_program_construction_messages )
            { Console.Log( "Delete saving files folder" ); }
            

        // ** EMPTY + DATA STILL IN STACK -> all the temp files are in the folder(if any) and will be discarted
        // ** cenario 2: crashou enquanto estava passando os arquivos
        // ** se tem dados na stack mas não tem o arquivo, quer dizer que os arquivos da pasta não estao completos
        // ** mas também quer dizer que os arquivos em disco não foram modificados
        return true;

    }
    


    // private static Crash_handle_route Handle_fail_reconstruct_stack( string _message ){

    //     Console.Log_player_need_to_read( $"Was reconstructing the last session that ends wrong. Try to reconstruct with the stack safety but receive thsi error: <Color=lightBlue>{ _message }</Color>. Will ignore the last stack and go with files saved in disk. Sorry" );

    //     Delete_all();
    //     return Crash_handle_route.corrupted;

    // }




    private static bool Verify_if_crash_at_final_OR_start(){

        bool Verify_file( string _path, string _name ){

            if( !!!( System.IO.File.Exists( _path ) ) )
                { 
                    // rare case, but possible
                    if( System_run.show_program_construction_messages )
                        { Console.Log( $"<Color=lightBlue>{ _name }</Color> didn't exist" ); }

                    return true;
                }

            return false;


        }

        bool Verify_folder( string _path, string _name ){
            
            if( !!!( System.IO.Directory.Exists( _path ) ) )
                { 
                    // rare case, but possible
                    if( System_run.show_program_construction_messages )
                        { Console.Log( $"<Color=lightBlue>{ _name }</Color> didn't exist" ); }

                    return true;
                }

            return false;

        }


        if( System_run.show_program_construction_messages ) 
            { Console.Log( "will Verify_if_crash_at_final_OR_start()" ); }
        

        bool some_file_is_missing = false;

        // ** if a important file is not there -> it was going to end -> can just delete all the data 
            
            some_file_is_missing |= Verify_folder( Paths_run_time.safety_stack_folder, "safety_stack_folder" );
                some_file_is_missing |= Verify_file( Paths_run_time.safety_stack_file, "safety_stack_file" );
                some_file_is_missing |= Verify_file( Paths_run_time.stack_start_files, "stack_start_files" );


        if( some_file_is_missing )
            {
                if( System_run.show_program_construction_messages )
                    { Console.Log( "Some important <Color=lightBlue>files are missing</Color>, what means the system already saved the files with the right data, but crashed when deleting the run time ones " ); }

                Delete_all();
                
            }
            else
            {
                if( System_run.show_program_construction_messages )
                    { Console.Log( "The system have all the files, so it crashed in the middle of the game, will reconstruct state" ); }
            }


        return some_file_is_missing;


    }

    private static void Delete_all(){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will just delete the folder and go with the flow normally" ); }
        

        //mark
        Console.Log( "ATIVAR NOVAMENTE QUANDO PRONTO" );
        // System.IO.Directory.Delete( Paths_program.saving_run_time_folder, true );

        stack_file = null;
        current_bytes = 0;

        return;

    }

    private static Crash_handle_return File_worst_corruption( string _reason, Crash_handle_route _route ){

        Console.LogError( "<Color=red>GET CORRUPTED</Color>" );
        Console.Log_player_need_to_read( "Reason: " + _reason );

        // ** will use the files in disk 
        // ** but later it should use the death files
        
        Delete_all();
        return Crash_handle_return.Construct( _reason, Crash_handle_result.fail, _route );

    }


    private static bool Is_stack_empty(){

        return ( stack_file[ 0 ] == 0 );

    }

    public static void Change_variables_for_reconstruct(){

        // ** all the import constructors that need acces are structs
        Controllers.stack.buffer.Activate__is_reconstructing_stack();
        Controllers.files.Activate__is_reconstructing_stack_from_CRASH();

    }

    public static void End_stack_variables(){

        Controllers.stack.buffer.Deactivate__is_reconstructing_stack();
        Controllers.files.Deactivate__is_reconstructing_stack_from_CRASH();

    }

}
