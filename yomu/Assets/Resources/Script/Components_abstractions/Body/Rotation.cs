

using System.Runtime.CompilerServices;
using UnityEngine;

public struct Rotation {

        public float x;
        public float y;
        public float z;
        public float w;


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public bool Is_default(){ return ( ( x == 0f ) && ( y == 0f ) && ( z == 0f ) && ( w == 0f ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public bool Is_not_default(){ return !!!( ( x == 0f ) && ( y == 0f ) && ( z == 0f ) && ( w == 0f ) );  }
        
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public Quaternion Convert_to_quaternion(){ return new Quaternion( x, y, z, w ); }

        public Rotation( float _x, float _y, float _z ){

            Quaternion quat = Quaternion.Euler( _x, _y, _z );
            
            x = quat.x;
            y = quat.y;
            z = quat.z;
            w = quat.w;

        }



}
