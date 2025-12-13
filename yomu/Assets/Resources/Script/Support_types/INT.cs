
using System.Runtime.CompilerServices;


unsafe public static class INT {

    public static int[] array_0 = new int[ 0 ];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Add( long _value_1, long _value_2 ){

        unchecked{ return (int)(_value_1 + _value_2); }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Add( int _value_1, long _value_2 ){

        unchecked{ return (_value_1 + (int) _value_2); }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Add( long _value_1, int _value_2 ){

        unchecked{ return ((int)_value_1 + _value_2); }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sub( long _value_1, long _value_2 ){
        
        unchecked{ return (int)(_value_1 - _value_2); }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sub( int _value_1, long _value_2 ){

        unchecked{ return (_value_1 - (int) _value_2); }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sub( long _value_1, int _value_2 ){

        unchecked{ return ((int)_value_1 - _value_2); }
    }

    public static void Transfer_int_to_byte_arr( byte[] _array, int _off_set, int _value ){

        fixed( byte* b_p = _array )
            { * ( int* ) ( b_p + _off_set ) = _value; }

        _array[ ( _off_set + 0 ) ] = ( byte ) ( _value >> 24 );
        _array[ ( _off_set + 1 ) ] = ( byte ) ( _value >> 16 );
        _array[ ( _off_set + 2 ) ] = ( byte ) ( _value >> 8  );
        _array[ ( _off_set + 3 ) ] = ( byte ) ( _value >> 0  );


    }

            private const int number_string_length = 100;
            public static string[] numbers_string;

            public static string ToString( int _int ){


                    if( _int > number_string_length || _int < 0 )
                        { return _int.ToString(); }

                
                    if( numbers_string == null )
                        {
                            numbers_string = new string[ number_string_length ];
                            for( int i = 0; i < number_string_length; i++ )
                                { numbers_string[ i ] = i.ToString(); }
                        }


                    return numbers_string[ _int ];

            }




        public static bool Guarantee_range( int number, int _min, int _max ){

            return ( number > _max || number < _min );
            
        }



        public static string Transformar_int_array_em_string( int[] _array ){

                string[] numeros = new string[ _array.Length ];

                for(  int i = 0 ; i< _array.Length ; i++)
                    { numeros[ i ] = _array[ i ].ToString(); }

                return string.Join( ',', numeros );

        }


        //performance
        // ** da para melhorar depois
        public static string Transformar_int_array_2d_em_string( int[][] _array_2d ){

                string[] arrays_string = new string [ ( _array_2d.Length * 2 )];

                for( int array_index = 0 ; array_index < _array_2d.Length ; array_index++ ){
                    
                        int[] array = _array_2d[ array_index ];

                        if( array == null )
                                {
                                        arrays_string[ ( array_index * 2 ) + 0 ] = "NULL";
                                        arrays_string[ ( array_index * 2 ) + 1 ] = "\r\n" ;
                                }
                                else
                                {
                                        arrays_string[ ( array_index * 2 ) + 0 ] = Transformar_int_array_em_string( array );
                                        arrays_string[ ( array_index * 2 ) + 1 ] = "\r\n" ;
                                }

                }
                
                // --- REMOVE A ULTIMA QUEBRA DE LINHA DESNECESSARIA
                arrays_string[ ( arrays_string.Length - 1 ) ] = "";

                return string.Concat( arrays_string );



        }



        public static int[] Remover_valor( int[] _array, int _valor ){

                int numero_para_remover = 0;

                for( int index = 0 ; index < _array.Length ; index++ ){

                        if( _array[ index ] == _valor )
                                { numero_para_remover++; }
                        continue;
                }

                int[] retorno = new int[ ( _array.Length - numero_para_remover ) ];

                int index_array_final = 0;

                for( int index_final = 0 ; index_final < _array.Length ; index_final++ ){

                        if( _array[ index_final ] != _valor )
                                { 
                                        retorno[ index_array_final ] = _array[ index_final ];
                                        index_array_final++;
                                }
                        continue;
                }

                return retorno;

        }
        

        public static int Length_elementos_maiores_que_0 (  int[] _arr  ){

                        int length = 0 ;
                        for( int i = 0 ; i < _arr.Length ; i++ ){
                                if( _arr[ i ] > 0 )
                                        { length++; }
                                continue;
                        }

                        return length;
                        

        }


        public static bool Tem_valor_no_array( int[] _arr , int _valor ){

                for(  int i = 0 ;  i < _arr.Length ; i++ ){

                        if( _arr[ i ] == _valor ) return true;

                }

                return false;

        }


        public static int Pegar_index_valor( int[] _arr , int _valor ){

                for(  int i = 0 ;  i < _arr.Length ; i++ ){

                        if( _arr[ i ] == _valor ) 
                                {return i;}

                }

                return -1;

        }



        public static void Trocar_valor ( int[] _arr , int _valor_para_trocar , int _novo_valor ){

                for(  int i = 0 ;  i < _arr.Length ; i++ ){

                        if( _arr[ i ] == _valor_para_trocar ) { _arr[ i ] = _novo_valor ; return ;}

                }

                return;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] Aumentar_length_array( int[] _array , int quantidade_para_adicionar = 5 ){



                if( (_array.Length + quantidade_para_adicionar ) > 150 )
                        { 
                                System.Array.Resize( ref _array, ( _array.Length + quantidade_para_adicionar ) );
                                return  _array;
                        }

                
                int[] novo_array = new int[ ( _array.Length + quantidade_para_adicionar ) ];

                for( int i = 0; i < _array.Length ; i++ ){

                        novo_array[ i ] = _array[ i ];

                }

                return novo_array;
        
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] Diminuir_length_array( int[] _array , int quantidade_para_adicionar = 5 ){



                if( (_array.Length - quantidade_para_adicionar ) > 150 )
                        { 
                                System.Array.Resize( ref _array, ( _array.Length - quantidade_para_adicionar ) );
                                return  _array;
                        }


                int[] novo_array = new int[ ( _array.Length - quantidade_para_adicionar ) ];

                for( int i = 0; i < novo_array.Length ; i++ ){

                        novo_array[ i ] = _array[ i ];

                }

                return novo_array;

                

        }


        public static int Return_int_4_bytes_asc2( char _c ){

            int ret = 0;

            ret += (byte)_c << 0;
            ret += (byte)_c << 8;
            ret += (byte)_c << 16;
            ret += (byte)_c << 24;

            // BITS.Printar_bits( ret );

            return ret;

        }












        public static int Acrescentar_valor_COMPLETO_GARANTIDO( ref int[] arr , int _valor ){

                int[] novo_arr = new int[ arr.Length + 1 ];
                int index = 0;

                for( index = 0 ; index < arr.Length ; index++ ){

                        novo_arr[ index ] = arr[ index ];

                }

                novo_arr[ arr.Length ] = _valor;
                arr = novo_arr;

                return index;



        }

        public static void Tirar_valor_COMPLETO_GARANTIDO( ref int[] arr , int _valor ){

                int[] novo_arr = new int[ arr.Length - 1  ];

                for( int index = 0 ; index < arr.Length ; index++ ){

                        if( arr[ index ] == _valor)
                                { continue; }
                        novo_arr[ index ] = arr[ index ];

                }

                novo_arr[ arr.Length ] = _valor;
                arr = novo_arr;
                
                return;



        }


        public static void Trocar_valor_no_array( int[] _arr , int _valor_para_trocar, int _novo_valor ){

                for( int index = 0 ; index < _arr.Length ;index++){

                        if( _arr[ index ] != _valor_para_trocar )
                                { continue; } 

                        _arr[ index ] = _novo_valor;
                        return;
                        
                }

                return;

        }

     public static int[] Aplicar_subtrair_e_adicionar_array(int[] _default, int[] _subtrair , int[] _acrescentar){
            
            int default_length = _default != null?_default.Length:0;

            int subtrair_length = _subtrair != null ?   _subtrair.Length : 0;
            int acrescentar_length = _acrescentar != null ?   _acrescentar.Length : 0;

            int max_arr_length = default_length + acrescentar_length;

            int[] max_arr = new int[default_length + acrescentar_length];

            
            int j = 0; 
            int i , k ;


            for( i = 0; i< default_length ;i++ ){

                for( k = 0;  k<acrescentar_length ;k++){
                  
                  if(_acrescentar[k] == _default[i]){ max_arr[k] = -1; break;}
                  
                }

            }  
            for(i = 0, j = 0; i < acrescentar_length ;i++){if(max_arr[i] != -1)  {max_arr[j] = _acrescentar[i]; j++;}}

            for(i = 0  ; i< default_length ;i++, j++){ max_arr[j] = _default[i];}



            for(  i = 0; i < max_arr_length ;i++){
                for( j = 0; j<subtrair_length ;j++){

                  if(_subtrair[j] == max_arr[i])  max_arr[i] = 0;}

                }
            int t = 0;
            for(i = 0 ; i < max_arr.Length ; i++ ){
              if(max_arr[i] != 0 ) t++;
            }

            int[] retorno = new int[t];

            for(  i = 0 , k = 0  ;  i<max_arr_length ;  i++){ 
              
                  if(max_arr[i] != 0) {
              
                       retorno[k] = max_arr[i]; k++;
                       
                  }
              
              }

            return retorno;
      
  }





}
