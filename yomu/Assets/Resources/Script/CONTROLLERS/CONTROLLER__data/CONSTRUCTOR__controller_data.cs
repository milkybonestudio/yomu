using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_data {


    public static CONTROLLER__data Construct(){

        CONTROLLER__data controller = new CONTROLLER__data();
        CONTROLLER__data.instancia = controller;

            // ** se precisar extender depois vai ir extendendo
            controller.pointer_general_data = Marshal.AllocHGlobal( controller.number_bytes );

        return controller;

    }

}