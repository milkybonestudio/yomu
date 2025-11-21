


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public enum Crash_handle_situation {

    not_activaed,

    all_files_already_got_saved,
    all_temp_files_were_already_there_just_move,
    need_to_recosntruct_with_the_stack, 

    corrupted,


}


unsafe public static class Crash_handler{


    /*

        flow:

            --> normal / salvando stack
            --> stack full 
            --> vai salvar os arquivos no disco

            order de salvar:

                --> salva stack em disco e assume que essa é a stack final
                --> atualizar arquivo especial saving_link_file_to_path
                --> cria saving_files_folder
                --> salva todos os arquivos como "slot_number.dat"
                    // ** tem que pegar novamente da stack ↑
                --> salva saving_files_security_file ( assume que todos os arquivos estao no foler )
                    // ** garante que tem todos ↓
                --> move todo os arquivos como .temp
                --> faz o switch dos arquivos
                --> reseta stack( se estiver resetada os dados em disco estão corretos )
                    // ** irrerevante ↓
                --> deleta saving_files_security_file
                --> deleta o folder saving_files_folder

            salvando arquivos:

            --> salvar arquivo com a lista dos arquivos por id que salvou
                    "1,2,3,7,21" -> 

    
        scenariou: 
            --> crashed whem the game was being created/finished
            ->

        order to delete normal: 

            --> delete file 
            --> delete folder "saving_files_folder"


    */


    public const int MAX_LENGTH_FILES = 100_000_000;

    public static int current_bytes;


    public static byte[] stack_file;

    public static string[] _paths;
    // public static byte[][] files;
    public static Crash_file[] files;

    public static Crash_handle_ephemeral_files files_OS;


    public static void Change_variables_for_reconstruct(){

        // ** all the import constructors that need acces are structs

        Controllers.stack.buffer.Activate__is_reconstructing_stack();
        Controllers.files.Activate__is_reconstructing_stack();

    }

    public static void End_stack_variables(){

        Controllers.stack.buffer.Deactivate__is_reconstructing_stack();
        Controllers.files.Deactivate__is_reconstructing_stack();

    }



    private static  Crash_handle_situation Handle_corrupt_make_sense(){

        Delete_all();
        Console.Log( "<Color=red>CORRUPTED: will ignore stack and use only the files ( lose data )</Color>" );
        return Crash_handle_situation.corrupted;

    }


    public static Crash_handle_situation Deal_crash(){


        if ( System_run.show_program_construction_messages )
            { Console.Log("----------------------- CALLED <Color=lightBlue>DEAL CRASH</Color> -----------------------"); }


        if ( Verify_if_crash_at_final_OR_start() )
            { return Crash_handle_situation.all_files_already_got_saved; }

        // ** all the files are here 

        // ** GET DATA 

        
        /*
            path[ n ] -> null
            data[ n ] -> null    ==> empty

            path[ n ] -> "path"
            data[ n ] -> byte[]    ==> active data

            path[ n ] -> "path"
            data[ n ] ->  null   ==> deleted the file
        
        */

        stack_file = System.IO.File.ReadAllBytes(Paths_program.safety_stack_file);

        // ** only the files to save
        _paths = System.IO.File.ReadAllLines(Paths_program.saving_link_file_to_path);


        files = new Crash_file[ _paths.Length ];

        for( int index = 0 ; index < _paths.Length ; index++ )
            { files[ index ].path = _paths[ index ]; }

        // files = new byte[ _paths.Length ][];


        // ** always the files that should be in disk at that point
        files_OS = new Crash_handle_ephemeral_files();


        if ( !!!( Verify_if_important_files_make_sense() ) )
            { return Crash_handle_situation.corrupted; }

        if ( Is_stack_empety() )
            {
                // ** já passou os dados
                Delete_all();
                return Crash_handle_situation.all_files_already_got_saved;
            }

        // ** GET FILES

        for (int file_index = 1; file_index < files.Length; file_index++){

            string path = _paths[ file_index ];

            if ( path == "" )
                { continue; }

            if ( !!!( Directories.Is_sub_path( path, Paths_program.program_path ) ) )
                {
                    Console.Log_player_need_to_read($"The path <Color=lightBlue>{ path }</Color> is not part of the program path <Color=lightBlue>{ Paths_program.program_path }</Color>");
                    Delete_all();
                    return Crash_handle_situation.corrupted;
                }

            if( !!!( System.IO.File.Exists( path ) ) )
                {
                    Console.Log_player_need_to_read($"Try to get the file in the path <Color=lightBlue>{ path }</Color> but it dosent exist");
                    Delete_all();
                    return Crash_handle_situation.corrupted;
                }

            files[ file_index ].data =  System.IO.File.ReadAllBytes( path );
            current_bytes += files[ file_index ].data.Length;

            if ( current_bytes > MAX_LENGTH_FILES )
                { CONTROLLER__errors.Throw("file size explode BUUUUUm"); }

        }



        bool were_saving_files_in_disk = ( System.IO.Directory.Exists( Paths_program.saving_files_folder ) );

        Console.Log( "were_saving_files_in_disk: " + were_saving_files_in_disk );

        if ( were_saving_files_in_disk )
            { return Handle_were_saving_files_in_disk(); }
            else
            { return Handle_all_the_data_is_in_the_stack(); }


    }
    
    
    
    public enum File_operation {

        _not_give,
            _switch, 
            _delete,

    }

    private struct Key_path_TO_real_path {

        public string path_in_disk;
        public string real_path;
        public string name_in_saving_file;

        public File_operation operation; 
        
    }

    private static Crash_handle_situation Handle_were_saving_files_in_disk(){

        // stack pode nao ser usada

        Console.Log( "CALLED <Color=lightBlue>Handle_were_saving_files_in_disk()</Color>" );


        if( Is_stack_empety() )
            {
                // mesmo se saving_files_security_file exite, se a a stack esta vazia os dados já foram passados
                // edge case que teve o crash na instrução de deletar o arquivo
                // todos os dados já foram passados
    
                Delete_all();
                return Crash_handle_situation.all_files_already_got_saved;

            }

        if( !!!( System.IO.File.Exists( Paths_program.saving_files_security_file ) ) )
            {

                Console.Log( "There is no security file" );
                Console.Log( "NO SECURITY FILE + DATA STILL IN STACK -> all the temp files are in the saving files folder(if any) and will be discarted to use only the stack" );
                System.IO.Directory.Delete( Paths_program.saving_files_folder, true );
                Console.Log( "Delete saving files folder" );

                // ** EMPTY + DATA STILL IN STACK -> all the temp files are in the folder(if any) and will be discarted
                // ** cenario 2: crashou enquanto estava passando os arquivos
                // ** se tem dados na stack mas não tem o arquivo, quer dizer que os arquivos da pasta não estao completos
                // ** mas também quer dizer que os arquivos em disco não foram modificados
                Console.Log( "Will redirect to <Color=lightBlue>Handle_all_the_data_is_in_the_stack()</Color>" );
                return Handle_all_the_data_is_in_the_stack();
            }

        Console.Log( "security_file exists. So all the right files are in a temp form or already swithed" );

        
        string[] files_paths_in_directory = System.IO.Directory.GetFiles( Paths_program.saving_files_folder );



        Console.Log( "Will transform files in the saving files folder in a array of keys to save" );

        // ** cenario 1: todos os arquivos foram passados para o disco, mas falta só mover eles/alguns deles
        
        // ** todos os arquivos já estao ali

        int files_without_meta = 0;

        foreach( string s in files_paths_in_directory ){ if( Path.GetExtension( s ) != ".meta" ) { files_without_meta++; } }

        int length_without_security = ( ( files_without_meta ) - 1 );


        Key_path_TO_real_path[] keys = new Key_path_TO_real_path[ length_without_security ];

        int current_index = 0;

        // ** check if 
        for( int index = 0 ; index < files_paths_in_directory.Length ; index++ ){

            string file_path = files_paths_in_directory[ index ];
            string file_name = Path.GetFileName( file_path );


            if( file_name == Paths_program.saving_files_security_file_NAME )
                { continue; }

            #if UNITY_EDITOR 

                if( Path.GetExtension( file_name ) == ".meta" )
                    { continue; }

            #endif

            if( current_index == length_without_security )
                {
                    Console.Log( "index: " + current_index );
                    Console.Log( "length_without_security: " + length_without_security );
                    Console.LogError( $"the <Color=lightBlue>saving_files_security_file</Color> was not in the <Color=lightBlue>saving_files_folder</Color>" );
                    Console.LogError( "path: " + Paths_program.saving_files_folder );
                    CONTROLLER__errors.Throw( $"System save <Color=lightBlue>saving_files_folder</Color> in the wrong path" );
                }

            
            bool name_is_a_number = int.TryParse( Path.GetFileNameWithoutExtension( file_name ), out int slot_sign );

            int slot = Math.Abs( slot_sign );

            // --- VERIFICATIONS

            Console.Log( "slot: " + file_name );

            if( slot == 0 )
                { return File_worst_corruption( $"The slot is 0 in the file <Color=lightBlue>{ file_name }</Color> and is invalid" ); }

            if( !!!( name_is_a_number ) )
                { return File_worst_corruption( $"There is a file with the name <Color=lightBlue>{ file_name }</Color> and is invalid" ); }

            if(  slot > files.Length )
                { return File_worst_corruption( $"There is a file with slot <Color=lightBlue>{ slot }</Color>, but the max slot based on <Color=lightBlue>saving_link_file_to_path</Color> is <Color=lightBlue>{ files.Length }</Color>" ); }

            string path_to_move = files[ slot ].path;

            if( ( path_to_move == null ) || ( path_to_move.Length < 10 ) )
                { return File_worst_corruption( $"The path <Color=lightBlue>{ file_path }</Color> is not valid " ); }

            if( !!!( System.IO.File.Exists( path_to_move ) ) )
                { return File_worst_corruption( $"The file <Color=lightBlue>{ path_to_move }</Color> don't exist BUT the temp file is already in the saving_files_folder as <Color=lightBlue>{ file_name }</Color>. it god deleted in the wrong order" ); }

            string temp_path = ( path_to_move + ".temp" );

            if( System.IO.File.Exists( temp_path ) )
                { return File_worst_corruption( $"There is a file in the temp path <Color=lightBlue>{ temp_path }</Color> but the file also exist in the saving_files_folder as <Color=lightBlue>{ file_name }</Color>" ); }


            if( !!!( Directories.Is_sub_path( file_path, Paths_version.path_to_version ) ) )
                { return File_worst_corruption( $" The path <Color=lightBlue>{ file_path }</Color> is not part of The path <Color=lightBlue>{ Paths_version.path_to_version }</Color>" ); }

            if( !!!( Directories.Is_sub_path( path_to_move, Paths_version.path_to_version ) ) )
                { return File_worst_corruption( $"The path <Color=lightBlue>{ path_to_move }</Color> is not part of <Color=lightBlue>{ Paths_version.path_to_version }</Color>" ); }


            keys[ current_index ].path_in_disk = file_path;
            keys[ current_index ].real_path = path_to_move;
            keys[ current_index ].name_in_saving_file = file_path;

            if( slot_sign > 0 )
                { keys[ current_index ].operation = File_operation._switch; }
                else
                { keys[ current_index ].operation = File_operation._delete; }
            
            current_index++;

            continue;


        }

        Console.Log( "Get all the keys" );


        // ** FORCE ANY TEMP FILE ALREADY IN THE "RIGHT" LOCATION TO FINISH SWITCH

        Console.Log( "Will verify if there is any temp switch interrupted" );

        foreach( string path_file_saving in Get_paths() ){

            if( path_file_saving == null || path_file_saving.Length < 14 )
                { continue; }

            string temp_file =  CONTROLLER__data_files.Get_run_time_path_TEMP( path_file_saving );

            if( System.IO.File.Exists( temp_file ) )
                {
                    // ** ONLY CAMES HERE IF IS FOR SWITCH
                    // ** finding the one switching
                    Console.Log( $"Crash when switching file <Color=lightBlue>{ path_file_saving }</Color> " );
                    
                    // guarantee that is deleted
                    if( System.IO.File.Exists( path_file_saving ) )
                        { 
                            Console.Log( "The old file was not deleted" );
                            System.IO.File.Delete( path_file_saving ); 
                        } 

                    System.IO.File.Move( temp_file, path_file_saving );
                }

        }

        Console.Log( "all the files are in the right places or in the saving_files folder" );


        // ** MOVE THE FILES

        foreach( Key_path_TO_real_path key in keys ){ 

            if( key.operation == File_operation._switch )
                {
                    string path_temp = CONTROLLER__data_files.Get_run_time_path_TEMP( key.real_path );

                    UnityEngine.Debug.Log( path_temp );
                    UnityEngine.Debug.Log( key.path_in_disk );
                    
                    System.IO.File.Move( key.path_in_disk, path_temp );
                    System.IO.File.Delete( key.real_path );
                    System.IO.File.Move( path_temp, key.real_path );

                }

            if( key.operation == File_operation._delete )
                {
                    if( System.IO.File.Exists( key.real_path ) )
                        { System.IO.File.Delete( key.real_path ); }

                    System.IO.File.Delete( key.path_in_disk );
                }


        }

        // ** all files are write

        Delete_all();


        return Crash_handle_situation.all_temp_files_were_already_there_just_move;

    }


    private static Crash_handle_situation Handle_all_the_data_is_in_the_stack(){

        // cuidar que saving_link_file_to_path pode estar desatualizado

        if( System_run.show_program_construction_messages )
            {
                
                Console.Log( "Came Handle_all_the_data_is_in_the_stack()" );
                Console.Log( "WIll delete_all the files in the saving_files_run_time with any other half file" );
            }

        if( System.IO.Directory.Exists( Paths_program.saving_files_folder ) )
            { System.IO.Directory.Delete( Paths_program.saving_files_folder, true ); }
        

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will create the folder again empty" ); }
            
        System.IO.Directory.CreateDirectory( Paths_program.saving_files_folder );

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will reconstruct the files in ram" ); }
            
        // ** ERRORS QUE PODE ACONTECER:
            // --> TEM ALGUM FILE ID QUE ESTA NA STACK MAS NAO ESTA NOS PATHS -> ERRO?


        // ** SPLIT STACK BLOCKS
        fixed( byte* pointer_stack = stack_file ){

            int max_length_stack = stack_file.Length;
            int index_in_file = 0;

            while( true ){

                byte* block_pointer = ( pointer_stack + index_in_file );

                int* int_pointer_start = (int*) block_pointer;

                    int block_id = int_pointer_start[ 0 ];
                    // ** data + signature + safety -> data + 16 bytes
                    int length_block = int_pointer_start[ 1 ];

                    index_in_file += length_block;

                if( System_run.show_program_construction_messages )
                    { Console.Log( $"--- receive block <Color=lightBlue>{ block_id }</Color> and length <Color=lightBlue>{ length_block }</Color> ----" ); }
                

                if( ( block_id == 0 ) || ( length_block == 0 ) )
                    { 
                        if( System_run.show_program_construction_messages )
                            { Console.Log( "Came to the end of blocks" ); }
                        break; 
                    }
                
                #if UNITY_EDITOR

                    // ** to not destroy my eyes I use "-" insted of 0-> "null"
                    if( block_id == INT.Return_int_4_bytes_asc2( '-' ) )
                        { return Crash_handle_situation.need_to_recosntruct_with_the_stack; }

                #endif

                if( !!!( MANAGER__safety_stack_saver.Security_values_are_OK( block_pointer, length_block ) ) )
                    { 
                        Console.Log( "block was saving when crash. Will discart it" );
                        break; 
                    } 

                // ** FILE IS OK

                Stack_reconstruction_result_message result_message = TOOL__handle_stack.Handle_stack_block( block_id, block_pointer, length_block );

                if( result_message.result == Stack_reconstruction_result.fail )
                    { return Handle_fail_reconstruct_stack( result_message.message ); }

                
                if( index_in_file < max_length_stack  )
                    { break; }

                continue;

            }

        }
        

        if( System_run.show_program_construction_messages )
            { 
                Console.Log( "All the files in the files[] should already be with the correct state. Will continue with the normal flow of saving the data in case crash when reconstructing" ); 
                Console.Log( "Will save the paths updated" );
            }

        Files.Save_critical_file( Paths_program.saving_link_file_to_path, Get_paths() );

        TOOL__crash_handler.Save_files_in_saving_files_folder();


        if( System_run.show_program_construction_messages )
            { Console.Log( "Will create the safety_file" ); }

        Files.Save_critical_file( Paths_program.saving_files_security_file, new byte[]{ 0,0 } );

        // ** poderia simplesmente chamar em cima de novo

        return Handle_were_saving_files_in_disk();


        // TOOL__crash_handler.Move_files_to_correct_place_as_temp();


        // TOOL__crash_handler.Switch_files_in_correct_place();

        
        // if( System_run.show_program_construction_messages )
        //     { Console.Log( "Will reset the stack" ); }

        // Files.Save_critical_file( Paths_program.safety_stack_file, new byte[ stack_file.Length ] );

        
        // if( System_run.show_program_construction_messages )
        //     { Console.Log( "Will delete everything. With the stack reseted will not come here again" ); }

        // Delete_all();

        
        // if( System_run.show_program_construction_messages )
        //     { Console.Log( "<Color=lime>System with correct state</Color>" ); }

        // return Crash_handle_situation.need_to_recosntruct_with_the_stack;

    }

    private static string[] Get_paths(){

        return files.Select( s => s.path ).ToArray();

    }



    private static Crash_handle_situation Handle_fail_reconstruct_stack( string _message ){

        Console.Log_player_need_to_read( $"Was reconstructing the last session that ends wrong. Try to reconstruct with the stack safety but receive thsi error: <Color=lightBlue>{ _message }</Color>. Will ignore the last stack and go with files saved in disk. Sorry" );

        Delete_all();
        return Crash_handle_situation.corrupted;

    }




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
            
            some_file_is_missing |= Verify_folder( Paths_program.safety_stack_folder, "safety_stack_folder" );
                some_file_is_missing |= Verify_file( Paths_program.safety_stack_file, "safety_stack_file" );
                some_file_is_missing |= Verify_file( Paths_program.saving_link_file_to_path, "saving_link_file_to_path" );


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
        files = null;
        files_OS = null;

        current_bytes = 0;

        return;

    }

    private static Crash_handle_situation File_worst_corruption( string _reason ){

        Console.LogError( "<Color=red>GET CORRUPTED</Color>" );
        Console.Log_player_need_to_read( "Reason: " + _reason );
        
        
        Delete_all();
        return Crash_handle_situation.corrupted;

    }

    private static bool Verify_if_important_files_make_sense(){

        // ** FILES

        if( _paths.Length == 0 )
            {
                if( System_run.show_program_construction_messages )
                    { Console.Log( "Files don't have data" ); }
                Delete_all();
                return false;
            }
        
        return true;

    }


    private static bool Is_stack_empety(){

        return ( stack_file[ 0 ] == 0 );

    }



}
