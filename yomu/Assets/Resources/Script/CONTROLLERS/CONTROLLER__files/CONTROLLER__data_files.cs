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


    public void Update(){}

    public void Reset_files(){

        if( System_run.files_show_messages )
            { Console.Log( "Called reset_files()" ); }

        storage.Reset();
        
        return;

    }



    public void Give_context( Program_context _context ){

        operations.Set_context( _context );

    }




}



