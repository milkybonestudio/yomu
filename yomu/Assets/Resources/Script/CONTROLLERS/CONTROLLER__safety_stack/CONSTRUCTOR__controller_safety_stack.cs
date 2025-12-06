

using System.IO;
using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_safety_stack{

    public static CONTROLLER__safety_stack Construct(){

        CONTROLLER__safety_stack ret = default;

            ret.state = SAFETY_STACK__state.waiting_to_save_stack;

            ret.safety_file_size = 1_000_000;
            ret.minimun_time_to_save_ms = 200f;

            ret.message_max_size = 9_000_000;
            ret.message_heap_key = Controllers.heap.Get_unique( ret.message_max_size );
            ret.pointer_with_message = ret.message_heap_key.Get_pointer();



            ret.packet_storage = MANAGER__safety_stack_packet_storage.Construct( ret.pointer_with_message );
            ret.files = MANAGER__safety_stack_files.Construct( ret.pointer_with_message );

            ret.saver  = MANAGER__safety_stack_saver.Construct();
            ret.buffer = MANAGER__safety_stack_buffer.Construct( ref ret );


        return ret;

    }


}