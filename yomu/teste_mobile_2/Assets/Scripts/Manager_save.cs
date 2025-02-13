using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public unsafe class Manager_save {


    string path_save; 


    //mark
    // ** como onApppause so vai chamar uma vez nao precisa ter mais controle, qunado der pause vai salvar
    // public int save_version_in_disk = 0;
    // public int save_version_here = 1;

    public Save* save_pointer;

    // ** will free if the game quit by the os
    public IntPtr save_key;


    public void Reset_save( bool _b ){ if( !!!( _b ) ){ return; } System.IO.File.Delete( path_save ); }

    public Manager_save(){

        path_save = ( Application.persistentDataPath + "/save.dat" );

        // --- DEVELOPMENT
            Reset_save( true );

        save_key = Marshal.AllocHGlobal( sizeof( Save ) );

        save_pointer = ( Save* ) save_key.ToPointer();

        byte* save_pointer_byte = ( byte* ) save_pointer;
        int b = 0;

        if( System.IO.File.Exists( path_save ) )
            {

                Debug.Log( "Vai pegar save" );
                byte[] save_data = System.IO.File.ReadAllBytes( path_save );

                Debug.Log( "data length: " + save_data.Length );
                Debug.Log( sizeof( Save ) );
                while( b < sizeof( Save ) )
                    { *save_pointer_byte++ = save_data[ b++ ]; }

            }
            else
            {

                Debug.Log( "Vai pegar criar novo save" );

                Save new_save =  Save.Construct();

                Save* new_save_pointer_const = &new_save;

                byte* new_save_pointer_byte = ( byte* ) new_save_pointer_const;

                while( b++ < sizeof( Save ) )
                    { *save_pointer_byte++ = *new_save_pointer_byte++; } 

            }



    }


    public void Update(){}


    
    public void Save_data(){


        byte[] new_save = new byte[ sizeof( Save ) ];

        byte* save_pointer_byte = ( byte* ) save_pointer;

        fixed( byte* new_save_pointer_const = new_save ){

            byte* new_save_pointer = new_save_pointer_const;
                
            int b = 0;
            while( b++ < sizeof( Save ) )
                { *new_save_pointer++ = *save_pointer_byte++;}

        }

        

        System.IO.File.WriteAllBytes( path_save, new_save );

    }



}



