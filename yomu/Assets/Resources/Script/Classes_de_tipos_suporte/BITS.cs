

unsafe public static class BITS {

        public static string Pegar_bits_txt( byte*  s_pointer, int n ){


                char[] c_array = new char[ ( 8 + 2 + 2 ) * n];
                for( int i = 0 ; i < n ; i++ ){

                    byte _byte = (*s_pointer);
                    s_pointer++;


                    c_array[ i + 0 ] = '|';
                    c_array[ i + 1 ] = ( char ) ((( _byte & 0b_0000_0001 ) >> 0) + 48 );
                    c_array[ i + 2 ] = ( char ) ((( _byte & 0b_0000_0010 ) >> 1) + 48 );
                    c_array[ i + 3 ] = ( char ) ((( _byte & 0b_0000_0100 ) >> 2) + 48 );
                    c_array[ i + 4 ] = ( char ) ((( _byte & 0b_0000_1000 ) >> 3) + 48 );
                    c_array[ i + 5 ] = ( char ) ((( _byte & 0b_0001_0000 ) >> 4) + 48 );
                    c_array[ i + 6 ] = ( char ) ((( _byte & 0b_0010_0000 ) >> 5) + 48 );
                    c_array[ i + 7 ] = ( char ) ((( _byte & 0b_0100_0000 ) >> 6) + 48 );
                    c_array[ i + 8 ] = ( char ) ((( _byte & 0b_1000_0000 ) >> 7) + 48 );
                    c_array[ i + 9 ] = '|';
                    c_array[ i + 10 ] = '\n';
                    c_array[ i + 11 ] = '\r';
                    

                }

                return new string( c_array );

        }




        public static void Printar_bits( byte*  s_pointer, int n ){


                char[] c_array = new char[ ( 8 + 2) ];

                c_array[ 0 ] = '|';
                c_array[ 9 ] = '|';
                
                for( int i = 0 ; i < n ; i++ ){

                    byte _byte = (*s_pointer);
                    s_pointer++;

                    c_array[ 1 ] = ( char ) ((( _byte & 0b_0000_0001 ) >> 0) + 48 );
                    c_array[ 2 ] = ( char ) ((( _byte & 0b_0000_0010 ) >> 1) + 48 );
                    c_array[ 3 ] = ( char ) ((( _byte & 0b_0000_0100 ) >> 2) + 48 );
                    c_array[ 4 ] = ( char ) ((( _byte & 0b_0000_1000 ) >> 3) + 48 );
                    c_array[ 5 ] = ( char ) ((( _byte & 0b_0001_0000 ) >> 4) + 48 );
                    c_array[ 6 ] = ( char ) ((( _byte & 0b_0010_0000 ) >> 5) + 48 );
                    c_array[ 7 ] = ( char ) ((( _byte & 0b_0100_0000 ) >> 6) + 48 );
                    c_array[ 8 ] = ( char ) ((( _byte & 0b_1000_0000 ) >> 7) + 48 );
                    

                    UnityEngine.Debug.Log( $"b{ i }: { new string( c_array ) }"  );


                }



        }
           










}

