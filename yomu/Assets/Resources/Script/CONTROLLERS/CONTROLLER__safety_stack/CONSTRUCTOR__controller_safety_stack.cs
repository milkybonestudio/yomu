

using System.IO;
using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_safety_stack{

    public static void Construct( ref CONTROLLER__safety_stack ret ){


        ret.state = SAFETY_STACK__state.waiting_to_save_stack;

        ret.safety_file_size = 1_000_000;
        ret.minimun_time_to_save_ms = 200f;

        ret.message_max_size = 9_000_000;
        ret.message_heap_key = Controllers.heap.Get_unique( ret.message_max_size );
        ret.pointer_with_message = ret.message_heap_key.Get_pointer();

        if( Paths_program.saving_run_time_folder == null )
            { CONTROLLER__errors.Throw( $"Tried to create the safety_stack controller but the saving_run_time folder was not found " ); }

        
        System.IO.Directory.CreateDirectory( Paths_program.saving_run_time_folder );
            System.IO.Directory.CreateDirectory( Paths_program.safety_stack_folder );

            
        if( System.IO.File.Exists( Paths_program.safety_stack_file ) )
            { CONTROLLER__errors.Throw( $"The stack_safety_file is in the path <Color=lightBlue>{ Paths_program.safety_stack_file }</Color> and shouldn't in the normal flow of the code" ); }


        File.WriteAllBytes( Paths_program.safety_stack_file, ARRAY.Get_array<byte>( _length: ret.safety_file_size, _value: 45 ) );



        ret.packet_storage = MANAGER__safety_stack_packet_storage.Construct( ret.pointer_with_message );
        ret.files = MANAGER__safety_stack_files.Construct( ret.pointer_with_message );

        ret.saver = MANAGER__safety_stack_saver.Construct( ref ret );
        ret.buffer = MANAGER__safety_stack_buffer.Construct( ref ret );


        return;

    }


    public static  void Verify_start_program(){

        // ** verifica se a ultima cessão foi encerrada corretamente
    }


}