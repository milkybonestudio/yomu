
using UnityEngine;
using System.Runtime.CompilerServices;

public static class SCALE {

    [MethodImpl( MethodImplOptions.AggressiveInlining )]
    public static Vector3 Guarantee_value( Scale _position, Vector3 _default ){

        if( _position.set == 0 )
            { return _default; }

        return new Vector3( _position.x, _position.y, _position.z  );

    }

}