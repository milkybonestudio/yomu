
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


//mark
// ** ver depois
public struct Crash_handle_return {

    public static Crash_handle_return Construct( string _message, Crash_handle_result _result, Crash_handle_route _route ){
        Crash_handler.Delete_all();
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
    // logic_files_moved, 

    // ** cleaned the stack and delete things 
    saving_finished,

}

unsafe public static class Crash_handler{


    public const int MAX_LENGTH_FILES = 100_000_000;
    public static int current_bytes;

    public static byte[] stack_file;
    public static string context_path;
    
    public static Crash_handle_route route;

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
            !!!( File.Exists( Paths_run_time.path_to_file_with_context_path ) ) 
        );
        

        if( was_creating_or_deleting_stack )
            { 
                Console.Log( System_run.show_program_construction_messages, "was_creating_or_deleting_stack" );
                return  Crash_handle_return.Construct( "final or start", Crash_handle_result.sucess, Crash_handle_route.all_files_already_got_saved ); 
            }


        stack_file = File.ReadAllBytes( Paths_run_time.safety_stack_file );
        context_path = File.ReadAllText( Paths_run_time.path_to_file_with_context_path );

        if( Is_stack_empty() )
            { 
                Console.Log( System_run.show_program_construction_messages, "was_creating_or_deleting_stack" );
                return Crash_handle_return.Construct( "stack empty", Crash_handle_result.sucess, Crash_handle_route.all_files_already_got_saved ); 
            }


        Saving_files_stages stage = Saving_files_stages.waiting_to_start;
        
            if( File.Exists( Paths_run_time.logic_data_saved ) )
                { stage = Saving_files_stages.logic_data_saved; }

            if( File.Exists( Paths_run_time.data_files_saved_in_folder ) )
                { stage = Saving_files_stages.data_files_saved_in_folder; }

            if( File.Exists( Paths_run_time.data_files_actions_applied ) )
                { stage = Saving_files_stages.data_files_actions_applied; }

            if( File.Exists( Paths_run_time.saving_finished ) )
                { stage = Saving_files_stages.saving_finished; }

            Console.Log( "stage: " + stage );

            
            switch( stage ){

                case Saving_files_stages.waiting_to_start: return Handle_waiting_to_start();
                case Saving_files_stages.logic_data_saved: return Handle_logic_data_saved();
                case Saving_files_stages.data_files_saved_in_folder: return Handle_data_files_saved_in_folder();
                case Saving_files_stages.data_files_actions_applied: return Handle_data_files_actions_applied();
                // case Saving_files_stages.logic_files_moved: return Handle_logic_files_moved();
                case Saving_files_stages.saving_finished: return Handle_saving_finished();
                default: CONTROLLER__errors.Throw( "can not handle type:" + stage ); return default;
            }


    }




    private static Crash_handle_return Handle_waiting_to_start(){

        Change_route( Crash_handle_route.need_to_recosntruct_with_the_stack );
        return Reconstruct_with_stack();
    }

    private static Crash_handle_return Handle_logic_data_saved(){

        Change_route( Crash_handle_route.need_to_recosntruct_with_the_stack );
        return Reconstruct_with_stack();

    }

    private static Crash_handle_return Reconstruct_with_stack(){

        Change_route( Crash_handle_route.need_to_recosntruct_with_the_stack );

        Files.Try_delete( Paths_run_time.context_new );
        Files.Try_delete( Paths_run_time.new_paths_ids );

        if( System.IO.Directory.Exists( Paths_run_time.saving_files_folder ) )
            { System.IO.Directory.Delete( Paths_run_time.saving_files_folder, true ); }
        
        Stack_reconstruction_result_message message_reconstruct_stack = TOOL__reconstruct_from_stack.Reconstruct();
                
        if( message_reconstruct_stack.result == Stack_reconstruction_result.fail )
            { return File_worst_corruption( message_reconstruct_stack.message ); }

        Files.Save_critical_file( Paths_run_time.logic_data_saved, new byte[ 100 ] );
        Files.Save_critical_file( Paths_run_time.data_files_saved_in_folder, new byte[ 100 ] );

        return Handle_data_files_saved_in_folder(); // ** jump logic

    }


    private static Crash_handle_return Handle_data_files_saved_in_folder(){

        Change_route( Crash_handle_route.all_temp_files_were_already_there_just_move );
        string[] link_paths_updated = System.IO.File.ReadAllLines( Paths_run_time.new_paths_ids );
        string[] files_paths_in_saving_files_folder = System.IO.Directory.GetFiles( Paths_run_time.saving_files_folder );

        EDGE_CASE__interrupt_on_switching_files( link_paths_updated );

        foreach( string file in files_paths_in_saving_files_folder ){

            string extension = Path.GetExtension( file );
            string saving_file_name = Path.GetFileNameWithoutExtension( file );

            if( extension == ".meta"  )
                { continue; }

            if( ( extension != ".add" ) && ( extension != ".delete" ) )
                { return File_worst_corruption( $"The file_id <Color=lightBlue>{ saving_file_name }</Color> have the extension<Color=lightBlue>{ extension }</Color> that is invalid" ); }

            bool name_is_a_number = int.TryParse( saving_file_name, out int file_id );

            if( !!!( name_is_a_number ) )
                { return File_worst_corruption( $"There is a file with the name <Color=lightBlue>{ saving_file_name }</Color> and is invalid" ); }
            
            if( file_id == 0 )
                { return File_worst_corruption( $"The file_id is 0 in the file <Color=lightBlue>{ saving_file_name }</Color> and is invalid" ); }

            if( file_id > link_paths_updated.Length )
                { return File_worst_corruption( $"The file_id is <Color=lightBlue>{ file_id }</Color> but the max id is <Color=lightBlue>{ ( link_paths_updated.Length - 1 ) }</Color>" ); }

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

        Change_route( Crash_handle_route.all_data_files_already_got_saved );

        // ** CONTEXT 

            string path_temp_context = File_run_time_saving_operations.Get_run_time_path_TEMP( context_path );

            if( File.Exists( Paths_run_time.context_new ) )
                { 
                    if( File.Exists( path_temp_context ) )
                        { return File_worst_corruption( $"Should move the new context to the temp path, but there is a file there" ); }

                    File.Move( Paths_run_time.context_new, path_temp_context ); 
                }

            if( File.Exists( path_temp_context ) )
                { 
                    if( File.Exists( context_path ) )
                        { File.Delete( context_path ); }

                    File.Move( path_temp_context, context_path );
                }

            if( !!! ( File.Exists( context_path ) ) )
                { return File_worst_corruption( $"The file context dont exist in the final path" ); }


        // ** PATHS IDS

            
        
            string path_paths_ids_TEMP = File_run_time_saving_operations.Get_run_time_path_TEMP( Paths_version.paths_ids );

            if( File.Exists( Paths_run_time.new_paths_ids ) )
                { 
                    if( File.Exists( path_temp_context ) )
                        { return File_worst_corruption( $"Should move the new context to the temp path, but there is a file there" ); }

                    File.Move( Paths_run_time.new_paths_ids, path_paths_ids_TEMP ); 
                }

            if( File.Exists( path_paths_ids_TEMP ) )
                { 
                    if( File.Exists( Paths_version.paths_ids ) )
                        { File.Delete( Paths_version.paths_ids ); }

                    File.Move( path_paths_ids_TEMP, Paths_version.paths_ids );
                }

            if( !!! ( File.Exists( Paths_version.paths_ids ) ) )
                { return File_worst_corruption( $"The file context dont exist in the final path" ); }



        Files.Save_critical_file( Paths_run_time.saving_finished, new byte[ 100 ] );
        return Handle_saving_finished();
    }

    private static Crash_handle_return Handle_saving_finished(){

        Change_route( Crash_handle_route.all_files_already_got_saved );
        // ** will not start even if crash here
        Files.Try_delete( Paths_run_time.safety_stack_file );

        return Crash_handle_return.Construct( null, Crash_handle_result.sucess, route );

    }


    


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


    public static void Delete_all(){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will just delete the folder and go with the flow normally" ); }
        
        System.IO.Directory.Delete( Paths_run_time.saving_run_time_folder, true );

        stack_file = null;
        current_bytes = 0;
        route = Crash_handle_route.not_give;
        context_path = null;


        return;

    }

    private static void Change_route( Crash_handle_route _route ){

        if( route == Crash_handle_route.not_give )
            { route = _route; }
    }

    private static Crash_handle_return File_worst_corruption( string _reason ){

        Console.LogError( "<Color=red>GET CORRUPTED</Color>" );
        Console.Log_player_need_to_read( "Reason: " + _reason );

        // ** will use the files in disk 
        // ** but later it should use the death files
        
        return Crash_handle_return.Construct( _reason, Crash_handle_result.fail, route );

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
