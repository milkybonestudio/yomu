







public static class BYTE {





        


        
        public static byte[] Aumentar_length_array( byte[] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                byte[] novo_array = new byte[ novo_numero ];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                return novo_array;


        }

        public static byte[][] Aumentar_length_array_2d(  byte[][] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                byte[][] novo_array = new byte[ novo_numero ][];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                return novo_array;


        }



        public static byte[] Compactar_byte_array_2d_PARA_NULL(  byte[][] _dados  ){


                int dados_length = 0;
                int dados_arr_index = 0; 

                for( dados_arr_index = 0 ; dados_arr_index < _dados.Length ; dados_arr_index++ ){

                        if( _dados[ dados_arr_index] == null )
                                { break ; }

                        dados_length += _dados[ dados_arr_index].Length;
                        continue;
                        
                }


                byte[] dados_compactados = new byte[ dados_length ];

                int index_atual = 0 ;


                for(  dados_arr_index = 0 ; dados_arr_index < _dados.Length ; dados_arr_index++ ){

                        if( _dados[ dados_arr_index] == null ) 
                                { break; }

                        byte[] dados = _dados[ dados_arr_index ];  

                        for( int dados_index = 0 ; dados_index < dados.Length ; dados_index++ ){

                                dados_compactados[ index_atual ] = dados[ dados_index ] ;
                                index_atual++ ;
                                
                        }

                        continue;
                        
                }

                return dados_compactados;


        }



        public static byte[] Compactar_byte_array_3d_PARA_NULL(  byte[][][] _dados_3d  ){


                UnityEngine.Debug.Log( "ainda tem que testar" );


                int byte_arr_1d_retorno_length = 0;
                int slot_1d_index = 0; 
                int slot_2d_index = 0;

                for( slot_2d_index = 0 ; slot_2d_index < _dados_3d.Length ; slot_2d_index++   ){

                        byte[][] slot_2d = _dados_3d [ slot_2d_index ] ; 

                        if( slot_2d == null )
                                { break; }

                        for( slot_1d_index = 0 ; slot_1d_index < _dados_3d.Length ; slot_1d_index++ ){

                                if( slot_2d [ slot_1d_index ] == null )
                                        { break ; }

                                byte_arr_1d_retorno_length += slot_2d [ slot_1d_index ].Length;
                                continue;
                                
                        }


                }



                byte[] dados_compactados = new byte[ byte_arr_1d_retorno_length ];

                int index_atual = 0 ;


                for( slot_2d_index = 0 ; slot_2d_index < _dados_3d.Length ; slot_2d_index++   ){

                        byte[][] slot_2d = _dados_3d[ slot_2d_index ];
                        if( slot_2d == null  )
                                { break; }


                        for(  slot_1d_index = 0 ; slot_1d_index < _dados_3d.Length ; slot_1d_index++ ){

                                byte[] slot_1d = slot_2d[ slot_1d_index ];

                                if( slot_1d == null ) 
                                        { break; }

                                for( int dados_index = 0 ; dados_index < slot_1d.Length ; dados_index++ ){

                                        dados_compactados[ index_atual ] = slot_1d[ dados_index ] ;
                                        index_atual++ ;
                                        
                                }

                                continue;
                                
                        }


                }



                return dados_compactados;


        }







        public static void Zerar_array_2d( ref byte[][] _dados ){


                for( int index = 0 ; index < _dados.Length ;  index++ ){

                        _dados[ index] = null;
                        
                }

                return;

        }



        public static void Zerar_array_3d( ref byte[][][] _dados ){

                
                for( int slot_2d_index = 0 ; slot_2d_index < _dados.Length ; slot_2d_index++ ){
                        
                        
                        for( int slot_1d_index = 0 ; slot_1d_index < _dados.Length ; slot_1d_index++ ){
                                
                                
                                _dados[ slot_2d_index ][ slot_1d_index ] = null;
                                
                        }    

                        
                } 


        }

        public static int Pegar_quantidade_de_bytes_arr_3d( byte[][][] _arr_3d ){

                int retorno = 0 ;

                for( int slot_2d_index = 0 ; slot_2d_index < _arr_3d.Length ; slot_2d_index++ ){

                        byte[][] slot_2d = _arr_3d[ slot_2d_index ];
                        if( slot_2d == null )
                                { continue; }

                        for( int slot_1d_index = 0 ; slot_1d_index < slot_2d.Length ; slot_1d_index++  ){

                                byte[] slot_1d = slot_2d[ slot_1d_index ];
                                if( slot_1d == null )
                                        { continue; }

                                retorno += slot_1d.Length;
                                continue;
                        
                        }

                        continue;

                }

                return retorno;

        }










}