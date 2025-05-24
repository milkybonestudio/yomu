


public static class Formater {

    public static string Format_number( int _number ){

        return _number.ToString( "#,0" ).Replace( ".", "_" );

    }

    public static string Format_number( long _number ){

        return _number.ToString( "#,0" ).Replace( ".", "_" );

    }

    public static string Format_number( float _number ){

        return _number.ToString( "#,0" ).Replace( ".", "_" );

    }


    public static string Get_times_per_second( long _time_ms, int _times ){

        return  Format_number( ( ( ( float ) _times) * 1000f / ( float ) ( _time_ms + 1 ) ) ) ;

    }


}