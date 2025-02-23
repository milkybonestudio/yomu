


using System;

public static class ARRAY {


    public static void Print_length<T>( string _message, T[] _array ){

        Console.Log( $"{ _message } : { _array.Length.ToString("#,0").Replace( ".", "_" ) }" );

    }


    public static void Guaranty_size<T>(  ref T[] _array, int _insertion_point, int _length, int _increase_size ){

        if( _array.Length <= ( _insertion_point + _length ) )
            { Array.Resize( ref _array, ( ( ( _insertion_point + _length ) - _array.Length ) + _increase_size ) ); }

    }


}