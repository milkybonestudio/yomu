
using System;
using System.Runtime.InteropServices;



// ** file x type?

unsafe public struct CONTROLLER__packets_storage {

    public MANAGER__packet_storage_sizes sizes;
    public MANAGER__packet_storage_creation creation;
    public MANAGER__packet_storage_defaults defaults;


    public Packet_storage* Get_packet_storage( string _path_to_file ){
        
        Data_file_link file_data_link = Controllers.files.operations.Get_file( _path: _path_to_file );
        
        return Packet_storage.Start( file_data_link );
        
    }



    public void Create( string _path_to_file, Packet_storage_start_data _start_data ){
        
        //mark
        // ** assume que sempre vai ter o arquivo para rodar o programa normalmente
        // ** vai chamar aqui por hora somente quando for iniciar ou para teste

        int file_length = _start_data.Get_file_length();

        Console.Log( "antes era Controllers.files mas mudei porque a funcao nao existe mais" );
        Data_file_link file_data_link = Controllers.files.operations.Create_new_file_EMPTY( _path_to_file, file_length );
        creation.Create( file_data_link, _start_data );


    }



    // SIMPLE 

    // ** vai ser muito simplificado, vai ser somente 1 arquivo grande
    // ** sempre vai vir da struct certa, nunca vai chamar diretamente
    // ** essa structure protege a logica

    public Packet_storage* packet_storage_SIMPLE;
    public Heap_key heap_key_SIMPLE;


    public void Delete( Packet_storage** _field, Heap_key_UNIQUE _key ){

        Delete_pointer( _field );

    }

    private void Delete_pointer( Packet_storage** _field ){

        Packet_storage* pointer = *_field;
        *_field = null;

        pointer->End();
        return;

    }

    public void Destroy(){

        sizes.Destroy();

        creation.Destroy();
        defaults.Destroy();
        

    }

    

}

