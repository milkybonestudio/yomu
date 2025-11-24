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


    public bool is_reconstructing_stack_from_CRASH;
    public void Activate__is_reconstructing_stack_from_CRASH(){

        is_reconstructing_stack_from_CRASH = true;
    }

    public void Deactivate__is_reconstructing_stack_from_CRASH(){

        is_reconstructing_stack_from_CRASH = false;
    }



}



