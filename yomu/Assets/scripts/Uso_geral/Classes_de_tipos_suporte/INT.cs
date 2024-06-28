


public static class INT {
        

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


        public static int[] Aumentar_length_array( int[] _array , int quantidade_para_adicionar = 5 ){


                int length_atual = _array.Length;
                int novo_length = ( length_atual + quantidade_para_adicionar ) ;

                int[] novo_array = new int[ novo_length ];

                for( int i = 0; i < _array.Length ; i++ ){

                        novo_array[ i ] = _array[ i ];

                }

                return novo_array;

                

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