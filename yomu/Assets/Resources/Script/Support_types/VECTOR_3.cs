



using System.Runtime.CompilerServices;
using UnityEngine;

public static class VECTOR_3 {

    [MethodImpl( MethodImplOptions.AggressiveInlining )]
    public static Vector3 Guarantee_value( Vector3 _vector, Vector3 _default ){

        if( ( _vector.x == 0 ) && ( _vector.y == 0 ) && ( _vector.z == 0 ) )
            { _vector = _default; }
            
        return _vector;

    }
    
    [MethodImpl( MethodImplOptions.AggressiveInlining )]
    public static void Guarantee_value( ref Vector3 _vector, Vector3 _default ){

        if( ( _vector.x == 0 ) && ( _vector.y == 0 ) && ( _vector.z == 0 )  )
            { _vector = _default; }

    }



}