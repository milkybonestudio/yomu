
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

public enum Saving_files_stages{


    waiting_to_start,

    // ** context, new paths_ids
    logic_data_saved,

    // ** all the id.action saved in the saving_folder
    data_files_saved_in_folder,

    // ** all the files are updated 
    data_files_actions_applied,

    // ** move the context and new_paths_ids
    logic_files_moved, 

    // ** cleaned the stack and delete things 
    saving_finished,




}

unsafe public static class Crash_handler{


    public const int MAX_LENGTH_FILES = 100_000_000;
    public static int current_bytes;

    public static byte[] stack_file;
    public static string context_path;
    
    

    public static Crash_handle_result Reconstruct_state(){

        Change_variables_for_reconstruct(); 
        
            Crash_handle_result result = Deal_crash().result;

        End_stack_variables();

        return result;

    }


    public static Crash_handle_return Deal_crash(){

        Console.Log( System_run.show_program_construction_messages, "----------------------- CALLED <Color=lightBlue>DEAL CRASH</Color> -----------------------");

        bool was_creating_or_deleting_stack = (
            !!!( File.Exists( Paths_run_time.safety_stack_file ) ) ||
            !!!( Directory.Exists( Paths_run_time.safety_stack_folder ) ) ||
            !!!( File.Exists( Paths_run_time.context_path ) ) 
        );
        

        if( was_creating_or_deleting_stack )
            { return  Crash_handle_return.Construct( "final or start", Crash_handle_result.sucess, Crash_handle_route.all_files_already_got_saved ); }


        stack_file = File.ReadAllBytes( Paths_run_time.safety_stack_file );
        context_path = File.ReadAllText( Paths_run_time.context_path );

        if( Is_stack_empty() )
            { return Crash_handle_return.Construct( "stack empty", Crash_handle_result.sucess, Crash_handle_route.all_files_already_got_saved ); }


        Saving_files_stages stage = Saving_files_stages.waiting_to_start;
        
            if( File.Exists( Paths_run_time.logic_data_saved ) )
                { stage = Saving_files_stages.logic_data_saved; }

            if( File.Exists( Paths_run_time.data_files_saved_in_folder ) )
                { stage = Saving_files_stages.data_files_saved_in_folder; }

            if( File.Exists( Paths_run_time.data_files_actions_applied ) )
                { stage = Saving_files_stages.data_files_actions_applied; }

            if( File.Exists( Paths_run_time.logic_files_moved ) )
                { stage = Saving_files_stages.logic_files_moved; }

            if( File.Exists( Paths_run_time.saving_finished ) )
                { stage = Saving_files_stages.saving_finished; }

            
            switch( stage ){

                case Saving_files_stages.waiting_to_start: return Handle_waiting_to_start();
                case Saving_files_stages.logic_data_saved: return Handle_logic_data_saved();
                case Saving_files_stages.data_files_saved_in_folder: return Handle_data_files_saved_in_folder();
                case Saving_files_stages.data_files_actions_applied: return Handle_data_files_actions_applied();
                case Saving_files_stages.logic_files_moved: return Handle_logic_files_moved();
                case Saving_files_stages.saving_finished: return Handle_saving_finished();
                default: CONTROLLER__errors.Throw( "can not handle type:" + stage ); return default;
            }


    }




    private static Crash_handle_return Handle_waiting_to_start(){

        return Reconstruct_with_stack();
    }

    private static Crash_handle_return Handle_logic_data_saved(){

        return Reconstruct_with_stack();

    }

    private static Crash_handle_return Reconstruct_with_stack(){

        Files.Try_delete( Paths_run_time.context_new );
        Files.Try_delete( Paths_run_time.new_paths_ids );

        if( System.IO.Directory.Exists( Paths_run_time.saving_files_folder ) )
            { System.IO.Directory.Delete( Paths_run_time.saving_files_folder, true ); }
        
        Stack_reconstruction_result_message message_reconstruct_stack = TOOL__reconstruct_from_stack.Reconstruct();
                
        if( message_reconstruct_stack.result == Stack_reconstruction_result.fail )
            { return File_worst_corruption( message_reconstruct_stack.message, Crash_handle_route.need_to_recosntruct_with_the_stack ); }

        Files.Save_critical_file( Paths_run_time.logic_data_saved, new byte[ 100 ] );
        Files.Save_critical_file( Paths_run_time.data_files_saved_in_folder, new byte[ 100 ] );

        return Handle_data_files_saved_in_folder(); // ** jump logic

    }


    private static Crash_handle_return Handle_data_files_saved_in_folder(){

        string[] link_paths_updated = System.IO.File.ReadAllLines( Paths_run_time.new_paths_ids );
        string[] files_paths_in_saving_files_folder = System.IO.Directory.GetFiles( Paths_run_time.saving_files_folder );

        EDGE_CASE__interrupt_on_switching_files( link_paths_updated );

        foreach( string file in files_paths_in_saving_files_folder ){

            string extension = Path.GetExtension( file );
            string saving_file_name = Path.GetFileNameWithoutExtension( file );

            if( extension == ".meta"  )
                { continue; }

            if( ( extension != ".add" ) && ( extension != ".delete" ) )
                { return File_worst_corruption( $"The file_id <Color=lightBlue>{ saving_file_name }</Color> have the extension<Color=lightBlue>{ extension }</Color> that is invalid", Crash_handle_route.not_give ); }

            bool name_is_a_number = int.TryParse( saving_file_name, out int file_id );

            if( !!!( name_is_a_number ) )
                { return File_worst_corruption( $"There is a file with the name <Color=lightBlue>{ saving_file_name }</Color> and is invalid", Crash_handle_route.not_give ); }
            
            if( file_id == 0 )
                { return File_worst_corruption( $"The file_id is 0 in the file <Color=lightBlue>{ saving_file_name }</Color> and is invalid", Crash_handle_route.not_give ); }

            if( file_id > link_paths_updated.Length )
                { return File_worst_corruption( $"The file_id is <Color=lightBlue>{ file_id }</Color> but the max id is <Color=lightBlue>{ ( link_paths_updated.Length - 1 ) }</Color>", Crash_handle_route.not_give ); }

            string final_path = link_paths_updated[ file_id ];

            switch( extension ){
                case ".add":  Files.Try_override( file, final_path ); break;
                case ".delete" : Files.Try_delete( final_path ); File.Delete( file ); break;
            }

            continue;

        }

        Files.Save_critical_file( Paths_run_time.data_files_actions_applied, new byte[ 100 ] );
        return Handle_data_files_actions_applied();
    }




    private static Crash_handle_return Handle_data_files_actions_applied(){

        // ** CONTEXT 
            string new_context = File.ReadAllText( Paths_run_time.context_new );
            Files.Try_override( new_context, context_path );

        // ** PATHS IDS

            string paths_ids = File.ReadAllText( Paths_run_time.new_paths_ids );
            Files.Try_override( paths_ids, Paths_version.paths_ids );

        Files.Save_critical_file( Paths_run_time.logic_files_moved, new byte[ 100 ] );
        return Handle_logic_files_moved();
    }

    private static Crash_handle_return Handle_logic_files_moved(){

        Files.Save_critical_file( Paths_run_time.saving_finished, new byte[ 100 ] );
        return Handle_saving_finished();
    }
    
    private static Crash_handle_return Handle_saving_finished(){

        // ** will not start even if crash here
        Files.Try_delete( Paths_run_time.safety_stack_file );

        return Crash_handle_return.Construct( null, Crash_handle_result.sucess, Crash_handle_route.not_give );

    }


    









    // private struct Crash_operation_key {


    //     public int file_id;
    //     public string file_extension;

    //     public string path_in_disk;
    //     public string final_path;
        
    //     public File_IO_operation operation; 
        
    // }




    // private static Crash_handle_return Pass_data_to_disk( Crash_handle_route _route ){

    //     // ** se veio aqui todos os arquivos estão ou no folder ou na pasta final, ou já foram trocados/eliminados

    //     Console.Log( System_run.show_program_construction_messages, "CALLED <Color=lightBlue>Pass_data_to_disk()</Color>" );
    //     Console.Log( System_run.show_program_construction_messages, "Will transform files in the saving files folder in a array of keys to save" );

    //     string[] link_paths_updated = System.IO.File.ReadAllLines( Paths_run_time.new_paths_ids );

    //     Deal_edge_cases( link_paths_updated );

    //     string[] files_paths_in_saving_files_folder = System.IO.Directory.GetFiles( Paths_run_time.saving_files_folder );
    //     Dictionary<int,Crash_operation_key> file_ids_TO_key_paths = new( 100 );


    //     // ** valida os arquivos no saving files
    //     foreach( string path_in_saving_folder in files_paths_in_saving_files_folder ){

    //             string saving_file_name = Path.GetFileName( path_in_saving_folder );
    //             string extension = Path.GetExtension( saving_file_name );

    //             if( ( saving_file_name == Paths_run_time.saving_files_security_file_NAME ) || ( extension == ".meta" ) )
    //                 { continue; }

    //             bool name_is_a_number = int.TryParse( Path.GetFileNameWithoutExtension( saving_file_name ), out int file_id );

    //             if( !!!( name_is_a_number ) )
    //                 { return File_worst_corruption( $"There is a file with the name <Color=lightBlue>{ saving_file_name }</Color> and is invalid", _route ); }
                
    //             if( file_id == 0 )
    //                 { return File_worst_corruption( $"The file_id is 0 in the file <Color=lightBlue>{ saving_file_name }</Color> and is invalid", _route ); }

    //             if( file_ids_TO_key_paths.ContainsKey( file_id ) )
    //                 { 
    //                     return File_worst_corruption( 
    //                         $"There is a file with file_id <Color=lightBlue>{ file_id }</Color> that was saved twice in the saving_files." +
    //                         $" path 1: <Color=lightBlue>{ Path.GetFileName( file_ids_TO_key_paths[ file_id ].path_in_disk )  }</Color> path 2: <Color=lightBlue>{ saving_file_name }</Color>", 
    //                         _route
    //                     );
    //                 }

    //             File_IO_operation operation = default;

    //             switch( extension ){

    //                 case ".delete": operation = File_IO_operation._delete; break;
    //                 case ".switch": operation = File_IO_operation._switch; break;
    //                 case ".create": operation = File_IO_operation._create; break;
    //                 case ".nothing": operation = File_IO_operation._nothing; break;

    //                 default: return File_worst_corruption( $"One file in saving have the extension <Color=lightBlue>{ extension }</Color> in the file <Color=lightBlue>{ saving_file_name }</Color>" , _route );

    //             }


    //             file_ids_TO_key_paths[ file_id ] = new(){
    //                 file_id = file_id,
    //                 file_extension = extension,
    //                 path_in_disk = path_in_saving_folder,
    //                 operation = operation
    //             };

    //     }


    //     int[] sorted_ids_for_dic = file_ids_TO_key_paths.Keys.ToArray();
    //     Array.Sort( sorted_ids_for_dic );

    //     for( int index_sorted = 0 ; index_sorted < sorted_ids_for_dic.Length ; index_sorted++ ){

    //         int file_id = sorted_ids_for_dic[ index_sorted ];

    //         if( file_id > link_paths_updated.Length )
    //             { return File_worst_corruption( $"There is a file with slot <Color=lightBlue>{ file_id }</Color>, but the max slot based on <Color=lightBlue>saving_link_file_to_path</Color> is <Color=lightBlue>{ link_paths_updated.Length }</Color>" , _route); }

    //         string real_path = link_paths_updated[ file_id ];
            
    //         if( ( real_path == null ) || ( real_path == "" ) )
    //             { return File_worst_corruption( $"The path for the id <Color=lightBlue>{ file_id }</Color> is not valid" , _route); }

    //         if( !!!( Directories.Is_sub_path( real_path, Paths_version.path_to_version ) ) )
    //             { return File_worst_corruption( $"The path <Color=lightBlue>{ real_path }</Color> is not part of <Color=lightBlue>{ Paths_version.path_to_version }</Color>" , _route); }
            

    //         Crash_operation_key key = file_ids_TO_key_paths[ file_id ];
    //             key.final_path = real_path;
    //         file_ids_TO_key_paths[ file_id ] = key;

    //         continue;
            
    //     }
        

    //     Console.Log( "all the files are in the right places or in the saving_files folder" );
    //     for( int index_key = 0 ; index_key < sorted_ids_for_dic.Length ; index_key++ ){

    //         // ** if a file have changed 2 times+ in a stack treshold I know that the file id 20 cames before the 30
    //         // ** so if 20 creates the file and 30 switch the files it's fine
    //         // ** if 20 delete a file and 30 creates a new one is fine
    //         // ** if 20 switchs the file and 30 create a new one -> ERROR

    //         int lower_slot = sorted_ids_for_dic[ index_key ];
    //         Crash_operation_key key = file_ids_TO_key_paths[ lower_slot ];


    //         if( key.operation == File_IO_operation._switch )
    //             {
    //                 string path_temp = File_run_time_saving_operations.Get_run_time_path_TEMP( key.final_path, File_IO_operation._switch );

    //                 System.IO.File.Move( key.path_in_disk, path_temp );
    //                 System.IO.File.Delete( key.final_path );
    //                 System.IO.File.Move( path_temp, key.final_path );

    //             }

    //         if( key.operation == File_IO_operation._delete )
    //             {
    //                 if( !!!( System.IO.File.Exists( key.final_path ) ) )
    //                     { return File_worst_corruption( $"It tryes to DELETE a file in the path <Color=lightBlue>{ key.final_path }</Color>, but there is no file in the path", _route ); }

    //                 string path_temp = File_run_time_saving_operations.Get_run_time_path_TEMP( key.final_path, File_IO_operation._delete );
    //                 System.IO.File.Move( key.path_in_disk, path_temp );
    //                 System.IO.File.Delete( key.final_path );
    //                 System.IO.File.Delete( path_temp );
    //             }

    //         if( key.operation == File_IO_operation._create )
    //             {
    //                 if( System.IO.File.Exists( key.final_path ) )
    //                     { return File_worst_corruption( $"It tryes to CREATE a file in the path <Color=lightBlue>{ key.final_path }</Color>, but a file alreaady exist", _route ); }

    //                 System.IO.File.Move( key.path_in_disk, key.final_path );

    //             }

    //         if( key.operation == File_IO_operation._nothing )
    //             {
    //                 System.IO.File.Delete( key.path_in_disk );
    //             }



    //     }

    //     // ** all operations finished 

    //     // ** with this even if crash now will just know it saved all
    //     Files.Save_critical_file( Paths_run_time.safety_stack_file, new byte[ 1_000 ] );


    //     Delete_all();

    //     if( System_run.show_program_construction_messages )
    //         { Console.Log( "<Color=lime>ALL ARQUIVES OK</Color>" ); }

    //     return Crash_handle_return.Construct( "pass", Crash_handle_result.sucess, _route );

    // }














    private static void EDGE_CASE__interrupt_on_switching_files( string[] link_paths_updated ){

        // ** verifica todos os arquivos, mas não vai importar

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will verify if there is any temp switch interrupted" ); }
        
        foreach( string final_path in link_paths_updated ){

            if( ( final_path == null ) || ( final_path == "" ) )
                { continue; }

            string hypothetical_temp_file =  File_run_time_saving_operations.Get_run_time_path_TEMP( final_path );

            if( System.IO.File.Exists( hypothetical_temp_file ) )
                {   
                    // ** assume que era add e vai terminar 
                    Console.Log( $"Crash when switching file <Color=lightBlue>{ final_path }</Color> " );
                    
                    if( System.IO.File.Exists( final_path ) )
                        { System.IO.File.Delete( final_path ); }

                    System.IO.File.Move( hypothetical_temp_file, final_path );
                }

        }

    }



























    // private static void Deal_edge_cases( string[] link_paths_updated ){

    //     EDGE_CASE__interrupt_on_switch( link_paths_updated );
    //     EDGE_CASE__interrupt_on_delete( link_paths_updated );
    //     EDGE_CASE__interrupt_on_create( link_paths_updated );

    // }

    // private static void EDGE_CASE__interrupt_on_switch( string[] link_paths_updated ){

    //     if( System_run.show_program_construction_messages )
    //         { Console.Log( "Will verify if there is any temp switch interrupted" ); }
        
    //     foreach( string final_path in link_paths_updated ){

    //         if( ( final_path == null ) || ( final_path == "") )
    //             { continue; }

    //         string hypothetical_temp_file =  File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, File_IO_operation._switch );

    //         if( System.IO.File.Exists( hypothetical_temp_file ) )
    //             {
    //                 Console.Log( $"Crash when switching file <Color=lightBlue>{ final_path }</Color> " );
                    
    //                 if( System.IO.File.Exists( final_path ) )
    //                     { System.IO.File.Delete( final_path ); }

    //                 System.IO.File.Move( hypothetical_temp_file, final_path );
    //             }

    //     }

    // }

    // private static void EDGE_CASE__interrupt_on_delete( string[] link_paths_updated ){

    //     if( System_run.show_program_construction_messages )
    //         { Console.Log( "Will verify if there is any temp switch interrupted" ); }

    //     foreach( string final_path in link_paths_updated ){

    //         if( ( final_path == null ) || ( final_path == "") )
    //             { continue; }

    //         string hypothetical_temp_file =  File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, File_IO_operation._delete );

    //         if( System.IO.File.Exists( hypothetical_temp_file ) )
    //             {
    //                 Console.Log( $"Crash when deleting file <Color=lightBlue>{ final_path }</Color> " );
                    
    //                 if( System.IO.File.Exists( final_path ) )
    //                     { System.IO.File.Delete( final_path ); }

    //                 System.IO.File.Delete( hypothetical_temp_file );
    //             }

    //     }

    // }

    // private static void EDGE_CASE__interrupt_on_create( string[] link_paths_updated ){

    //     if( System_run.show_program_construction_messages )
    //         { Console.Log( "Will verify if there is any temp switch interrupted" ); }

    //     foreach( string final_path in link_paths_updated ){

    //         if( ( final_path == null ) || ( final_path == "") )
    //             { continue; }

    //         string hypothetical_temp_file =  File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, File_IO_operation._create );

    //         if( System.IO.File.Exists( hypothetical_temp_file ) )
    //             {

    //                 Console.Log( $"Crash when creating file <Color=lightBlue>{ final_path }</Color> " );
    //                 System.IO.File.Move( hypothetical_temp_file, final_path );
    //             }

    //     }

    // }






    // private static bool Lost_data_while_saving(){


    //     // sbool lost_data = !!!( Is_stack_empty() ) &&  Directory.GetFiles( Paths_run_time.saving_files_folder );
    //     // !!!( Directory.Exists( Paths_run_time.saving_files_folder ) );

    //     bool crash_when_only_the_stack_was_saving = !!!( System.IO.Directory.Exists( Paths_run_time.saving_files_folder ) );

    //     if( crash_when_only_the_stack_was_saving )
    //         { return true; }


    //     if( System.IO.File.Exists( Paths_run_time.saving_files_security_file ) )
    //         { return false; }

        
    //     if( System_run.show_program_construction_messages )
    //         {
    //             Console.Log( "There is no security file" );
    //             Console.Log( "NO SECURITY FILE + DATA STILL IN STACK -> all the temp files are in the saving files folder ( if any ) and will be discarted to use only the stack" );
    //         }

    //     System.IO.Directory.Delete( Paths_run_time.saving_files_folder, true );

    //     if( System_run.show_program_construction_messages )
    //         { Console.Log( "Delete saving files folder" ); }
            

    //     // ** EMPTY + DATA STILL IN STACK -> all the temp files are in the folder(if any) and will be discarted
    //     // ** cenario 2: crashou enquanto estava passando os arquivos
    //     // ** se tem dados na stack mas não tem o arquivo, quer dizer que os arquivos da pasta não estao completos
    //     // ** mas também quer dizer que os arquivos em disco não foram modificados
    //     return true;

    // }
    

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
        // Controllers.stack.buffer.Activate__is_reconstructing_stack();
        // Controllers.files.Activate__is_reconstructing_stack_from_CRASH();

    }

    public static void End_stack_variables(){

        Controllers.stack.Reset_stack();
        Controllers.files.Reset_files();
        // Controllers.files.Deactivate__is_reconstructing_stack_from_CRASH();

    }

}
