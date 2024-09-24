using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_data {


    public static CONTROLLER__data Construct(){

        CONTROLLER__data controller = new CONTROLLER__data();
        CONTROLLER__data.instancia = controller;

            controller.modulo__leitor_dll_dados_blocos = new MODULO__leitor_dll( "Dados_blocos_RUN_TIME", 50 );
            // ** se precisar extender depois vai ir extendendo
            controller.pointer_general_data = Marshal.AllocHGlobal( controller.number_bytes );

        return controller;

    }

}