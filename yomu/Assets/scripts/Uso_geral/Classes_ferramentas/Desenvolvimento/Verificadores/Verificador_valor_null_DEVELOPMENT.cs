

public static class Verificador_valor_null_DEVELOPMENT{


    public static void Verifica_valor<T>( T _valor, string _nome ){

        if( _valor == null )
            { throw new System.Exception( $"{ _nome } estava null" ); }

    }



}