using System;



public class Linear_dictionary<E, T> where T:class where E: Enum {

        public Linear_dictionary( int _initial_value = -1 ){

            if( _initial_value < 0 )
                {
                    E[] enum_values = ( E[] ) Enum.GetValues( typeof( E ) );
                    _initial_value = Convert.ToInt32( enum_values[ ^1 ] ) ;
                }

            values = new T[ _initial_value ];

        }

        public T[] values;


        public void Add( E _enum_id,  T _value ){ values[ (int)(object)_enum_id ] = _value; }
        public void Add( int _id,  T? _value ){ values[ _id ] = _value; }


        public T this[ int index ]{

                get { return values[ index ]; }
                set { values[ index ] = value; }

        }


        public T[] Seal(){

                int number = 0;

                // --- GET NUMBER OF NONNULL
                for( int i = 0 ; i < values.Length ; i++ )
                    { if ( values[ i ] != null ) { number++; } }

                T[] ret = new T[ number ];

                // --- TRANSFER TO ARRAY
                int index = 0;
                for( int k = 0 ; k < values.Length ; k++ )
                    { if ( values[ k ] != null ) { ret[ index++ ] = values[ k ]; } }

                return ret;

        } 


}
