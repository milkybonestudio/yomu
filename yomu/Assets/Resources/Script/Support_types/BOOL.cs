
using System.Runtime.CompilerServices;


unsafe public static class BOOL {
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool In_range( int _min, int _value, int _max ){

        return ( _min < _value ) && ( _value < _max );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Not_in_range( int _min, int _value, int _max ){

        return ( _value < _min ) && ( _max < _value );
    }


}