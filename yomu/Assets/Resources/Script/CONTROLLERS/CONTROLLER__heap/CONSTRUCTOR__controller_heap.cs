
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_heap{

    public static CONTROLLER__heap Construct(){

        CONTROLLER__heap controller = new CONTROLLER__heap();
        CONTROLLER__heap.instance = controller;

                // controller.fix_space_length = 10_000_000;
                // controller.fix_pointer = Marshal.AllocHGlobal( controller.fix_space_length );
                // controller.current_pointer = controller.fix_pointer.ToPointer();

                controller.unique_keys = new Dictionary<int, Heap_key>( 100 );
                // controller.fast_pointer = Marshal.AllocHGlobal( 200_000 );

                controller.fast_pointers = new Dictionary<int, Fast_pointer>( 2 );

        return controller;

    }

}