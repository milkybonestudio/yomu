


using System;
using System.IO;

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


    private static byte[] stack_file;

    private static string[] paths;

    private static byte[][] files;





    public static void Deal_crash(){

        if( System_run.show_program_messages )
            { Console.Log( "CALLED <Color=lightBlue>DEAL CRASH</Color>" ); }


        if( Verify_if_crash_at_final_OR_start() )
            { return; }

        // ** all the files are here 

        // ** GET DATA


        stack_file = System.IO.File.ReadAllBytes( Paths_program.safety_stack_file );
        paths = System.IO.File.ReadAllLines( Paths_program.saving_link_file_to_path );

        files = new byte[ paths.Length ][];

        if( Verify_if_important_files_make_sense() )
            { return; }

        // ** GET FILES

        for( int file_index = 0 ; file_index < paths.Length ; file_index++ ){

            if( !!! ( System.IO.File.Exists( paths[ file_index ] ) ) )
                { 
                    Console.Log_player_need_to_read( $"Try to get the file in the path <Color=lightBlue>{ paths[ file_index ] }</Color> but it dosent exist" ); 
                    Delete_all();
                    return;
                }

            files[ file_index ] = System.IO.File.ReadAllBytes( paths[ file_index ] );
            current_bytes += files[ file_index ].Length;

            if( current_bytes > MAX_LENGTH_FILES )
                { CONTROLLER__errors.Throw( "file size explode BUUUUUm" ); }

        }

        // ** get all the files

        if( Is_stack_empety() )
            {
                // ** já passou os dados
                Delete_all();
                return;
            }

        bool were_saving_files_in_disk = ( System.IO.File.Exists( Paths_program.saving_files_folder ) );

        if( were_saving_files_in_disk )
            { Handle_were_saving_files_in_disk(); }
            else
            { Handle_all_the_data_is_in_the_stack(); }


        Delete_all();
        return;

    }

    private struct Key_path_TO_real_path {

        public string path_in_disk;
        public string real_path;

    }

    private static void Handle_were_saving_files_in_disk(){

        // stack pode nao ser usada


        if( Is_stack_empety() )
            {
                // mesmo se saving_files_security_file exite, se a a stack esta vazia os dados já foram passados
                // edge case que teve o crash na instrução de deletar o arquivo
                // todos os dados já foram passados
    
                Delete_all();
                return;
            }

        if( !!!( System.IO.File.Exists( Paths_program.saving_files_security_file ) ) )
            {
                // ** cenario 2: crashou enquanto estava passando os arquivos
                // ** se tem dados na stack mas não tem o arquivo, quer dizer que os arquivos da pasta não estao completos
                // ** mas também quer dizer que os arquivos em disco não foram modificados
                Handle_all_the_data_is_in_the_stack();
                return;
            }

        
        string[] files_paths_in_directory = System.IO.Directory.GetFiles( Paths_program.saving_files_folder );

        // ** cenario 1: todos os arquivos foram passados para o disco, mas falta só mover eles/alguns deles
        
        // ** todos os arquivos já estao ali

        int length_without_security = ( files_paths_in_directory.Length - 1 );
        Key_path_TO_real_path[] keys = new Key_path_TO_real_path[ length_without_security ];

        int current_index = 0;

        // ** check if 
        for( int index = 0 ; index < files_paths_in_directory.Length ; index++ ){

            string file_path = files_paths_in_directory[ index ];
            string file_name = Path.GetFileName( file_path );


            if( file_name == Paths_program.saving_files_security_file_NAME )
                { continue; }

            if( current_index == length_without_security )
                {
                    Console.LogError( $"the <Color=lightBlue>saving_files_security_file</Color> was not in the <Color=lightBlue>saving_files_folder</Color>" );
                    Console.LogError( "path: " + Paths_program.saving_files_folder );
                    CONTROLLER__errors.Throw( $"System save <Color=lightBlue>saving_files_folder</Color> in the wrong path" );
                }

            
            bool name_is_a_number = int.TryParse( file_name, out int slot );

            
            // --- VERIFICATIONS

            if(  slot < paths.Length )
                {
                    Console.LogError( $"There is a file with slot <Color=lightBlue>{ slot }</Color>, but the max slot based on <Color=lightBlue>saving_link_file_to_path</Color> is <Color=lightBlue>{ paths.Length }</Color>" );
                    File_worst_corruption();
                    return;
                }

            if( !!!( name_is_a_number ) )
                {
                    Console.LogError( $"There is a file with the name <Color=lightBlue>{ file_name }</Color> and is invalid" );
                    File_worst_corruption();
                    return;
                }

            string path_to_move = paths[ slot ];

            if( ( path_to_move == null ) || ( path_to_move.Length < 10 ) )
                {
                    Console.LogError( $"The path <Color=lightBlue>{ file_path }</Color> is not valid " );
                    File_worst_corruption();
                    return;
                }


            if( ( Is_sub_path( file_path, Paths_program.program_path ) ) )
                {
                    Console.LogError( $"The path <Color=lightBlue>{ file_path }</Color> is not part of <Color=lightBlue>{ Paths_program.program_path }</Color>" );
                    File_worst_corruption();
                    return;
                }

            if( ( Is_sub_path( path_to_move, Paths_program.program_path ) ) )
                {
                    Console.LogError( $"The path <Color=lightBlue>{ path_to_move }</Color> is not part of <Color=lightBlue>{ Paths_program.program_path }</Color>" );
                    File_worst_corruption();
                    return;
                }


            keys[ current_index ].path_in_disk = file_path;
            keys[ current_index ].real_path = path_to_move;
            
            current_index++;

            continue;


        }
        // ** MOVE THE FILES

        foreach( Key_path_TO_real_path key in keys )
            { System.IO.File.Move( key.path_in_disk, key.real_path ); }

        // ** all files are write


        return;             

    }


    private static void Handle_all_the_data_is_in_the_stack(){

        // cuidar que saving_link_file_to_path pode estar desatualizado
        

        

    }


    private static bool Verify_file( string _path, string _name ){

        Console.Log( "vai ver path: " + _path );
        
        if( !!!( System.IO.File.Exists( _path ) ) )
            { 
                // rare case, but possible
                if( System_run.show_program_messages )
                    { Console.Log( $"<Color=lightBlue>{ _name }</Color> didn't exist" ); }

                return true;
            }

        return false;


    }


    private static bool Verify_folder( string _path, string _name ){

        Console.Log( "vai ver path: " + _path );
        
        if( !!!( System.IO.Directory.Exists( _path ) ) )
            { 
                // rare case, but possible
                if( System_run.show_program_messages )
                    { Console.Log( $"<Color=lightBlue>{ _name }</Color> didn't exist" ); }

                return true;
            }

        return false;


    }



    private static bool Verify_if_crash_at_final_OR_start(){

        bool all_files_are_the_right_state = false;

        // ** if a important file is not there -> it was going to end -> can just delete all the data 
            
            all_files_are_the_right_state |= Verify_folder( Paths_program.safety_stack_folder, "safety_stack_folder" );
                all_files_are_the_right_state |= Verify_file( Paths_program.safety_stack_file, "safety_stack_file" );
                all_files_are_the_right_state |= Verify_file( Paths_program.saving_link_file_to_path, "saving_link_file_to_path" );


        if( all_files_are_the_right_state )
            {
                if( System_run.show_program_messages )
                    { 
                        Console.Log( "Some important files are missing, what means the system already saved the files with the right data, but crashed when deleting the run time ones " ); 
                    }

                Delete_all();
                
            }
            else
            {
                if( System_run.show_program_messages )
                    { Console.Log( "The system have all the files, so it crashed in the middle of the game, will reconstruct state" ); }
            }


        return all_files_are_the_right_state;

    }

    private static void Delete_all(){

        if( System_run.show_program_messages )
            { Console.Log( "Will just delete the folder and go with the flow normally" ); }
        

        System.IO.Directory.Delete( Paths_program.saving_run_time_folder, true );


        stack_file = null;
        paths = null;

        files = null;

        current_bytes = 0;


    }

    private static void File_worst_corruption(){

        Console.Log( "It should NEVER came here. The files where currupted, so it will just use the death folder" );
        CONTROLLER__errors.Throw( "tem que fazer" );

    }

    private static bool Verify_if_important_files_make_sense(){

        // ** FILES

        if( paths.Length == 0 )
            {
                if( System_run.show_program_messages )
                    { Console.Log( "Files don't have data" ); }
                Delete_all();
                return true;
            }
        
        return false;

    }


    private static bool Is_sub_path( string full_path, string sub_part ){

        // Normalize trailing slashes
        full_path = full_path.TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar ) + Path.DirectorySeparatorChar;
        sub_part = sub_part.TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar ) + Path.DirectorySeparatorChar;

        return full_path.StartsWith( sub_part, StringComparison.OrdinalIgnoreCase );
    }

    private static bool Is_stack_empety(){

        return ( stack_file[ 3 ] == 0 );

    }



}
