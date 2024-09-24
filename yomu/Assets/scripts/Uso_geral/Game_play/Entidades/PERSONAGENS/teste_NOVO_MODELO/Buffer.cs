using System;

unsafe public class Buffer {


        public int pointer;
        public byte[] data;

        public int default_add = 500;

        public Buffer( int _initial_size ){ data = new byte[ _initial_size ];}

        public void Add_data( byte[] _array, int _length ){

                if( _length + pointer >= data.Length )
                    { Array.Resize( ref data , ( data.Length + default_add) ); }
                if( _array.Length > _length )
                    { throw new Exception(""); }

                for( int index = 0 ; index < _length  ; index++ ){

                        data[ ( pointer + index ) ] = _array[ index ];

                }

                pointer += _length;

        }

        
        public void Add_data_pointer( byte* byte_pointer, int _length ){


            if( _length + pointer >= data.Length )
                { Array.Resize( ref data , ( data.Length + default_add) ); }


            for( int index = 0 ; index < _length  ; index++ ){

                    data[ ( pointer + index ) ] = *byte_pointer ;
                    byte_pointer++;

            }

            pointer += _length;

        }

        public void Reset_pointer(){

                pointer = 0;
                return;

        }


        public void Extend_size( int _number_to_add ){

            byte[] new_data = new byte[ ( data.Length + _number_to_add ) ];
            data = new_data;

        }



}

