using System;


public class List<T> where T : class  {

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

}