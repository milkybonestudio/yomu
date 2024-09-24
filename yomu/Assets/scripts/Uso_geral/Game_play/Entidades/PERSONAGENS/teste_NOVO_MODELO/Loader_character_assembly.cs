using System;
using System.Reflection;



public static class Loader_character_assembly {


        public static INTERFACE__character_dll Get_dll ( string _character_name, string _dll ){

                Assembly asm = Assembly.Load( $"{ _character_name }__{ _dll }" );

                if( asm == null )
                    { throw new Exception("nao achou dll"); }

                Type type = asm.GetType( $"Constructor" );

                if( type == null )
                    { throw new Exception("nao achou classe");  }

                MethodInfo m_info = type.GetMethod( "Construct" );

            
                if( m_info == null )
                    { throw new Exception( $"dont find method {_character_name}.dll::Constructor::Construct");}

                return ( INTERFACE__character_dll ) m_info.Invoke( null, null );

        }


}
