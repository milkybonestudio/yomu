using UnityEngine;
using System;





public static class SPRITE {





        public static void Copiar_sprites_array_para_matrix_com_pointers( Sprite[,] _array_receptor,  int _coluna, int _index_inicial, int _length, int _pointer_inicial_array_com_dados, Sprite[] _array_com_dados, string _indentificador = "NAO FOI COLOCADO" ){


                // --- VERIFICA SE OS ARRAYS EXISTEM

                if( _coluna < 0 )
                    { throw new Exception( $"Tentou copiar sprites de um array para uma matrix mas a coluna id era menor q  ue 0. indentificador: { _indentificador }" );  }

                if( _length < 0 )
                    { throw new Exception( $"Tentou copiar sprites de um array para uma matrix mas a length era menor q  ue 0. indentificador: { _indentificador }" );  }


                if( _array_receptor == null )
                    { throw new Exception( $"Tentou copiar sprites de um array para uma matrix mas o array receptor estava null. indentificador: { _indentificador }" ); }

                if( _array_com_dados == null )
                    { throw new Exception( $"Tentou copiar sprites de um array para uma matrix mas o array com os dados estava null. indentificador: { _indentificador }" ); }


                for( int index = 0 ; index < _length ; index++ ){

                        int id = ( _pointer_inicial_array_com_dados + index );

                        if( id >= _array_com_dados.Length )
                            { throw new Exception( $"Tentou copiar sprites de um array para uma matrix mas o id { id } era maior que a length do com os dados:{ _array_com_dados.Length}. Indentificador : { _indentificador }" ); }

                        // --- FAZ A TROCA
                        _array_receptor[ _coluna,  ( _index_inicial + index ) ] = _array_com_dados[ id ];

                        continue;

                }

                return;

        }



        public static void Copiar_sprites_array_para_matrix_com_ids( Sprite[,] _array_receptor, int _coluna, Sprite[] _array_com_dados, int[] _ids, string _indentificador = "NAO FOI COLOCADO" ){


                // --- VERIFICA SE OS ARRAYS EXISTEM

                if( _array_receptor == null )
                    { throw new Exception( $"Tentou Copiar_sprites_array_para_matrix_com_ids para o outro mas o array receptor estava null. indentificador: { _indentificador }" ); }

                if( _array_com_dados == null )
                    { throw new Exception( $"Tentou Copiar_sprites_array_para_matrix_com_ids para o outro mas o array com os dados estava null. indentificador: { _indentificador }" ); }


                for( int index = 0 ; index < _ids.Length ; index++ ){

                        int id = _ids[ index ];

                        // --- VERIFICA SE É UM ID VALIDO
                        if( id < 0 )
                            {  throw new Exception( $"Tentou Copiar_sprites_array_para_matrix_com_ids para o outro mas o id { id } é menor que 0. Indentificador : { _indentificador }" ); }
                
                        if( id >= _array_com_dados.Length )
                            { throw new Exception( $"Tentou Copiar_sprites_array_para_matrix_com_ids para o outro mas o id { id } era maior que a length do com os dados:{ _array_com_dados.Length}. Indentificador : { _indentificador }" ); }

                        // --- FAZ A TROCA
                        _array_receptor[ _coluna, index ] = _array_com_dados[ id ];

                        continue;

                }

                return;

        }






        public static void Copiar_sprites_array_para_array( Sprite[] _array_receptor, Sprite[] _array_com_dados, int[] _ids, string _indentificador = "NAO FOI COLOCADO" ){


                // --- VERIFICA SE OS ARRAYS EXISTEM

                if( _array_receptor == null )
                    { throw new Exception( $"Tentou copiar sprites de um array para o outro mas o array receptor estava null. indentificador: { _indentificador }" ); }

                if( _array_com_dados == null )
                    { throw new Exception( $"Tentou copiar sprites de um array para o outro mas o array com os dados estava null. indentificador: { _indentificador }" ); }


                for( int index = 0 ; index < _ids.Length ; index++ ){

                        int id = _ids[ index ];

                        // --- VERIFICA SE É UM ID VALIDO

                        if( id < 0 )
                            {  throw new Exception( $"Tentou copiar sprites de um array para o outro mas o id { id } é menor que 0. Indentificador : { _indentificador }" ); }
                
                        // if( id >= _array_receptor.Length )
                        //     { throw new Exception( $"Tentou copiar sprites de um array para o outro mas o id { id } era maior que a length do receptor: { _array_receptor.Length }. Indentificador : { _indentificador }" ); }

                        if( id >= _array_com_dados.Length )
                            { throw new Exception( $"Tentou copiar sprites de um array para o outro mas o id { id } era maior que a length do com os dados:{ _array_com_dados.Length}. Indentificador : { _indentificador }" ); }

                        // --- FAZ A TROCA
                        _array_receptor[ index ] = _array_com_dados[ id ];

                        continue;

                }

                return;

        }



        public static Sprite Transformar_png_TO_sprite(  byte[] _png  ){


                Texture2D tex = new Texture2D(  1  , 1 , TextureFormat.RGBA32,  false ); 
                tex.LoadImage( _png  );          
                Sprite sprite_retorno =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );



                return sprite_retorno;


        }




        public static Sprite Transformar_colors_container_TO_sprite(  Color32[] _container, int _height, int _width  ){

                // pode multithread
                if( ( _height * _width  ) != _container.Length )
                        { throw new Exception( $"dimensoes em Transformar_colors_container_TO_sprite nao vieram corretas, veio {_width}x e { _height }y. O container veio com { _container.Length }px" ); }

                Texture2D tex = new Texture2D(  _width  , _height , TextureFormat.RGBA32,  false ); 

                tex.SetPixelData( _container , 0 );
                tex.Apply( false, false );
                tex.filterMode = UnityEngine.FilterMode.Point;

                //--- acho que em cima pode fazer na multi?? 

                Sprite sprite_retorno  =   Sprite.Create(tex  ,     new Rect( 0.0f, 0.0f, tex.width, tex.height ), new Vector2( 0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );

                return sprite_retorno;


        }





        public static int Pegar_index_null ( Sprite[] _arr ){


                for( int index =0 ; index < _arr.Length; index++ ){

                        if( _arr[ index ] == null ) { return index; }

                }

                return -1;

        }


        public static Sprite[] Aumentar_length_array( Sprite[] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                Sprite[] novo_array = new Sprite[ novo_numero ];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                return novo_array;


        }



}


