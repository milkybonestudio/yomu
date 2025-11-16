
using System.Runtime.CompilerServices;
using UnityEngine;

public static class POSITION {

    [MethodImpl( MethodImplOptions.AggressiveInlining )]
    public static Vector3 Guarantee_value( Position _position, Vector3 _default ){

        if( _position.set == 0 )
            { return _default; }

        return new Vector3( _position.x, _position.y, _position.z  );

    }


}