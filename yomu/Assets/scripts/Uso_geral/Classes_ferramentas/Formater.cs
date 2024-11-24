


public static class Formater {

    public static string Format_number( int _number ){

        return _number.ToString( "#,0" ).Replace( ".", "_" );

    }

    public static string Format_number( long _number ){

        return _number.ToString( "#,0" ).Replace( ".", "_" );

    }

}