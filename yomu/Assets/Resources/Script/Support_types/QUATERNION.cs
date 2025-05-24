

using System.Runtime.CompilerServices;
using UnityEngine;

public static class QUATERNION {

    [MethodImpl( MethodImplOptions.AggressiveInlining )]
    public static Quaternion Guarantee_value( Quaternion _q ){

        if( ( _q.x == 0 ) && ( _q.y == 0 ) && ( _q.z == 0 ) && ( _q.w == 0 ) )
            { _q = Quaternion.identity; }
            
        return _q;

    }

    [MethodImpl( MethodImplOptions.AggressiveInlining )]
    public static void Guarantee_value( ref Quaternion _q ){

        if( ( _q.x == 0 ) && ( _q.y == 0 ) && ( _q.z == 0 ) && ( _q.w == 0 ) )
            { _q = Quaternion.identity; }

    }



}