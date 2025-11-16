


using System.Runtime.CompilerServices;
using UnityEngine;

public struct Position {

        public float x;
        public float y;
        public float z;
        public float set;


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public bool Is_default(){ return ( set == 0f ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public bool Is_not_default(){ return ( set != 0f ); }
        
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public Vector3 Convert_to_vector(){ return new Vector3( x, y, z ); }

        public Position( float _x, float _y, float _z ){

            x = _x;
            y = _y;
            z = _z;
            set = 1;

        }


        //performance
        // ** provavelmente fazer a multiplicacao no set tambem faria muito mais sentido
        // ** ele provavelmente poderia fazer as 4 com um ciclo mas se for somente 3 vai ter que fazer 1 de cada vez
        // ** testar depois
        // ** set viraria um float tipo 20k 
        // ** poderia ser dividido/multiplicado sem problemas 

        public static Position operator * ( Position _s, float _f  ){

            _s.x *= _f;
            _s.y *= _f;
            _s.z *= _f;

            return _s;

        }


}
