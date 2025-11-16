using System;
using System.Collections.Generic;


public class List<T> {

        public List( int _length ){

            values = new T[ _length ];
            length = _length;
            
        }

        public int used_length;
        public int length;

        public T[] values;

        public T Add( T _t ){

                if( length == used_length )
                    { 
                        int value_to_increase = ( length / 5 ) + 10;
                        Array.Resize( ref values, ( length + value_to_increase ) );
                        length += value_to_increase;

                    }

                values[ used_length++ ] = _t;
                
                return _t;

        }

        public bool Have_value( T _t ){

            for( int i = 0 ; i < used_length ; i++ )
                { if( EqualityComparer<T>.Default.Equals( values[ i ], _t ) ){ return true; } }

            return false;

        }

        public void Remove( T _t ){
            
            int off_set = 0;
            for( int i = 0 ; i < used_length ; i++ ){ 

                if( EqualityComparer<T>.Default.Equals( values[ i ], _t ) )
                    { off_set = 1; }

                values[ i ] = values[ ( i + off_set ) ];
                
            }
            used_length -= off_set;

        }

        public void Reset(){

            used_length = -1;

        }

}