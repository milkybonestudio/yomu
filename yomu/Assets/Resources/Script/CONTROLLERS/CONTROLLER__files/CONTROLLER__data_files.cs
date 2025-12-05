using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.IO;
using System.Threading;

/*
    Constrains:
        => por hora não vai descarregar um arquivo, se ele pega um, vai ficar até o final
        =. salvar os arquivos em disco vai bloquear o update tanto na multithread quanto na main thread

*/


unsafe public struct CONTROLLER__data_files {

    public Controller_data_files_state state;
    

    public CONTROLLER__data_file_TESTING test;

    public MANAGER__controller_data_file_operations operations;
    public MANAGER__controller_data_file_storage storage; // ** have the real files


    public void Update(){

    }




    public void Reset_files(){

        Console.Log( "Called reset_files()" );

        storage.Reset();

    }


    public void Get_links_with_disk_file(){

            if( storage.Have_files_any_kind() )
                { CONTROLLER__errors.Throw( "Called Get_links_with_file() but there are files in the Data_files" ); }

            string[] lines =  System.IO.File.ReadAllLines( Paths_version.data_link_current_files );

            int max_slot = 0;

            foreach( string line in lines ){

                Console.Log( "line: " + line );
                string[] id_AND_path = line.Split( "??" );

                if( id_AND_path.Length != 2 )
                    { CONTROLLER__errors.Throw( $"could not split text: { line } of data_links_current_files" ); }

                int id = Convert.ToInt32( id_AND_path[ 0 ] );
                string path = id_AND_path[ 1 ];

                if( id > max_slot )
                    { max_slot = id; }

                // ** will be with correct id
                operations.Get_file_start_program( path, id );

            }

            storage.current_file_id = max_slot;


    }


    // public bool is_reconstructing_stack_from_CRASH;
    // public void Activate__is_reconstructing_stack_from_CRASH(){

    //     is_reconstructing_stack_from_CRASH = true;
    // }

    // public void Deactivate__is_reconstructing_stack_from_CRASH(){

    //     is_reconstructing_stack_from_CRASH = false;
    // }



}



