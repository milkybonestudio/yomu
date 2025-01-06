

using System.Runtime.CompilerServices;

public static class FLOAT {

        [MethodImpl(MethodImplOptions.AggressiveInlining )]
        public static float Sign( float _value ){

                if( _value < 0f )
                    { return -1f; }
                return 1f;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining )]
        public static float Abs( float _value ){

                if( _value < 0f )
                    { return -_value; }
                return _value;

        }


}