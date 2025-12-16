using System;
using System.IO;



unsafe public static class Paths_data {


    // ** DATA

    public static string Get_resources_container( Resource_context _context ){  Garanty_build(); return Path.Combine( Paths_system.data, $"resources_container{ _context.ToString() }.dat" ); }

    public static string Get_resources_container_linker( Resource_context _context ){ Garanty_build(); return Path.Combine( Paths_system.data, $"resources_container{ _context.ToString() }_linker.txt" ); }



    private static void Garanty_build(){

        #if UNITY_EDITOR
            CONTROLLER__errors.Throw( "Can not call in editor" );
        #endif
    }

        
    
}
