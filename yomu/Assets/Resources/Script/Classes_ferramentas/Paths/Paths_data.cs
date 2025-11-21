using System;
using System.IO;



unsafe public struct Pointer{

    public void* pointer;
    public int length;

}

public static class Sinal{


    private static byte[] dados_para_gravar = new byte[ 10_000 ];
    private static int pointer = 0;
    public static void Sinalizar( byte[] _dados, int _length ){

        // ** gravar no 

        // for() { passar }

        pointer += _length;

    }


    public static byte[] dados;


    public static int Add_slot( string _path_to_file ){

        // ** things

        return 0;

    }

    public static bool tem_que_alterar;

    
    public static void Save(){

        Save_linker();
        Save_stack();

    }

    public static void Save_stack(){

        // ** salva os dados em si
        // ** dados.salvar(  )


    }
    public static void Save_linker(){

        if( !!!( tem_que_alterar ) )
            { return; } // ** vai salvar somente os dados


    }

}

unsafe public class CONTROLLER__linked_files {



}



unsafe public struct Tipo_2 {

    public int age;
    public Data_manipulator edit;


}

unsafe public struct Tipo {
 

    public int age;

    // ** static 
    public Data_manipulator edit;

    public static Tipo* pointer;

    public static int slot;

    public static class Paths_save{

        public static string characters;

    }

    public Tipo_2 tipo_2;

    public static void Change( void* pointer, int _value ){

        
        // int pointer_final = ( int )( (int*)pointer - pointer_zero );

        // *(int*)pointer  = _value;

        // byte[] arr = new byte[]{

        //     ( byte ) ( pointer_final << 0 ),
        //     ( byte ) ( pointer_final << 8 ),
        //     ( byte ) ( pointer_final << 16 ),
        //     ( byte ) ( pointer_final << 24 ),

        //     ( byte ) ( _value << 0 ),
        //     ( byte ) ( _value << 8 ),
        //     ( byte ) ( _value << 16 ),
        //     ( byte ) ( _value << 24 ),
            
        // };

        // Sinal.Sinalizar( arr, 8 );

    }



}



unsafe public struct Type_packet_controller{

    public Packet_storage* pointer;

    public Packet_key Alloc( int _size ){

        return pointer->Alloc_packet( _size );

    }

}



unsafe public static class Paths_data {

    public static void _A(){

        int size = sizeof( Tipo );
        string path = "path";
        int slot = Sinal.Add_slot( path );

        
        //mark 
        // ** porque nao so o Data_file_link? 
        // ** ele parece que tem tudo, slot não é mais pego ali e sim no controller_files

        
        // Data_file_link info = Controllers.files.Get_file( _path: path, _safety_length_type: sizeof( Tipo ) );
        // Tipo.pointer = ( Tipo* ) info.heap_key.Get_pointer();
        // Tipo.pointer->edit.Start(  _ptr: Tipo.pointer, _size: size, _slot: slot );

    }

    public static void A(){

        Tipo t = default;
        Tipo* t_p = &t;

        int slot = Sinal.Add_slot( "path" );

        Data_file_link data;

        // &Tipo.pointer->edit;
        Tipo** p;
        // fixed( Tipo** _t = &Tipo.pointer )
        //     { data = TOOL__create_Data_file_link.Create( (void**) _t, sizeof( Tipo ), "path" ); }

        // data = TOOL__create_Data_file_link.Create( (void**) &_Data.p.tipo, sizeof( Tipo ), "path" );


        // Tipo.pointer->edit.Start_full_file( data );



        Task_req task = Controllers.tasks.Get_task_request( "task" );


        task.fn_multithread = ( Task_req _req )=>{

            // ** get_file

        };

        task.fn_single = ( Task_req _req )=>{

            // ** use file

        };
        

        
        // Tipo.pointer = ( Tipo* ) Controller_heap.Get_fix_space( sizeof( Tipo ) );
        // Tipo.pointer->edit.Start_full_file( sizeof( Tipo ), Tipo.pointer, slot );
        // Tipo.pointer->tipo_2.edit.Start_partial_file( sizeof( Tipo_2 ), Tipo.pointer, &Tipo.pointer->tipo_2 );


        // t.age = 18;
        // Tipo.Change( &t_p->age  , 18 );
        // Tipo.edit.Change( &t_p->age, 18 );
        // t_p->edit.Change( &t_p->age, 18 );

        
        

    }

    public static void B( Tipo* t_p ){

        t_p->age = 18;
        t_p->edit.Change( &t_p->age, 18 );
        
        t_p->edit.Change( &Tipo.pointer->age, 18 );
        t_p->edit.Change( &t_p->age, 18 );

    }


    public static void C( Tipo* b_p, Tipo_2* sp_p  ){

        
        b_p->edit.Change( &sp_p->age, 18 );
        b_p->edit.Change( &Tipo.pointer->tipo_2.age, 18 );

    }



    // ** DATA

        public static string Get_resources_container( Resource_context _context ){  Garanty_build(); return Path.Combine( Paths_system.data, $"resources_container{ _context.ToString() }.dat" ); }


    /*
        o linker vai ter pointers para pegar o recurso, tem que ser no formato " "chave", pointer_1, pointer_2, dados[...]"
        o linker sempre vai ser usado para criar um dic<stirng, type_info>

        os recursos normais não vão ter dados, talvez tipo?

    */

    public static string Get_resources_container_linker( Resource_context _context ){ Garanty_build(); return Path.Combine( Paths_system.data, $"resources_container{ _context.ToString() }_linker.txt" ); }



    private static void Garanty_build(){

            #if UNITY_EDITOR
                CONTROLLER__errors.Throw( "Can not call in editor" );
            #endif
    }

        
    
}
