using System;

public static class System_enums {

        public static Tipo_entidade[] tipo_entidade_arr = ( Tipo_entidade[] ) Enum.GetValues( typeof( Tipo_entidade ) );
        public static Bloco[] blocks_arr = ( Bloco[] ) Enum.GetValues( typeof( Bloco ) );
        public static Resource_context[] resource_context = ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );    
    
}