




public static class Verificador_tipos {


    public static bool Verificar_tipo( string _path , string _tipo ){

        string extensao = System.IO.Path.GetExtension( _path );
        return extensao == _tipo ;
        
    }

}