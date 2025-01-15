

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

        [MethodImpl(MethodImplOptions.AggressiveInlining )]
        public static float Set_max( float _value, float _max ){

                if( _value > _max )
                    { return _max; }
                    
                return _value;

        }



}