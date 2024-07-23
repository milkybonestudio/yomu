using System.Reflection;
using System;


public static class ASSEMBLY {

        public static void Ativar_metodo_classe_estatica( Assembly _asm, string _nome_classe, string _nome_metodo ){


                if( _asm == null )
                    { throw new Exception( "asm veio null em Ativar_metodo_classe_estatica" ); }
                
                
                Type tipo = _asm.GetType( _nome_classe );

                

                if( tipo == null )
                    { throw new Exception( $"nao foi achado a classe { _nome_classe} na dll { _asm.FullName }." ); }

                MethodInfo metodo_info = tipo.GetMethod( _nome_metodo );

                if( metodo_info == null )
                    { throw new Exception( $"nao foi achado o metodo { _nome_metodo } na classe { _nome_classe } na dll { _asm.FullName }." ); }

                
                metodo_info.Invoke( null, null );

                return;


        }

}