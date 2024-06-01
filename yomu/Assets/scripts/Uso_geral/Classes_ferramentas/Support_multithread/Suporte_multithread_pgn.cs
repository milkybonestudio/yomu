using System;
using UnityEngine;
using Png_decoder;








public class Suporte_multithread_PNG {





                // Dados_para_pegar_png dados = new Dados_para_pegar_png( _nome : "cleber"  );
                // dados.tipo_pegar_png = Tipo_pegar_png.poiter;
                // dados.pointr_1 = 15_000L;
                // dados.pointr_1 = 15_000L + 50_000L;

                // Supporte_multithread.png.Pegar_fn_iniciar_imagem_pequena( dados );






        public Action<Task_req> Pegar_fn_iniciar_imagem_pequena (   Dados_para_pegar_png _dados  ){

                
                
                return ( Task_req _req ) => { 



                        	// eu acho que vou usar multi thread somente na build, entao eu sempre vou usar pegar parte  

                        byte[] png_byte_array =  Leitor_arquivo.Pegar_parte_de_arquivo(  _dados.path , _dados.pointr_1, _dados.pointr_2  );  
                        
                        // switch( _dados.tipo ){
                        //     //     path tem que vir com a extencao se for tipo path
                        //     case Tipo_pegar_png.path : png_byte_array = Leitor_arquivo.Pegar_arquivo( _path ); break;
                        //     case Tipo_pegar_png.compactado: png_byte_array = Leitor_arquivo.Pegar_parte_de_arquivo(  _path , _dados.pointr_1, _dados.pointr_2  ); break;

                        // }

                        // if( _dados.tipo_pegar_png == Tipo_pegar_png.path ){
                            
                        //     png_byte_array = System.IO.File.ReadAllBytes( path );

                        // } else {



                        // }


                        Png image = Png.Open( png_byte_array );

                        int width = ( int )image.Width;
                        int height = ( int )image.Height;

                        int total_bytes =  width *  height * 4;

                        Color32[] cores = new Color32[  ( width *  height )  ];

                        for( int h = 0 ; h < height ; h++ ){
                            for(  int w = 0 ; w < width ; w++ ){

                                Pixel pixel = image.GetPixel( w, ( height - 1 -  h ) );

                                int p = ( w  ) + (h  * width );

                                cores[ p ].r =  pixel.R;
                                cores[ p ].g =  pixel.G; 
                                cores[ p ].b =  pixel.B; 
                                cores[ p ].a =  pixel.A; 

                            }
                        }


                        _req.dados = ( System.Object ) cores;
                        return;
                    

                };

        }


        public Action<Task_req> Pegar_fn_finalizar_imagem_pequena ( int _width , int _height ) {


                return ( Task_req _req ) => {

                        Color32[] cores =  ( Color32[] ) _req.dados;

                        Texture2D tex = new Texture2D(  _width  , _height , TextureFormat.RGBA32,  false ); 
                        tex.SetPixelData( cores , 0);
                        tex.Apply( false, false );


                        Sprite sprite_retorno  =   Sprite.Create(  
                            tex , 
                            new Rect(0.0f, 0.0f, tex.width, tex.height), 
                            new Vector2(0.5f, 0.5f),
                            100.0f ,
                            0,
                            SpriteMeshType.FullRect

                            );

                        Sprite_em_cache retorno_cache = new Sprite_em_cache();

                        retorno_cache.sprites = new Sprite[ 1 ] ;
                        retorno_cache.sprites[ 0 ] = sprite_retorno;
                        
                        _req.dados =  ( System.Object ) retorno_cache;

                        return;


                };


        }



        


        public static  Action<Task_req> Pegar_fn_iniciar_imagem_grande( Dados_para_pegar_png _dados , int _altura ){




                     return  ( Task_req _req ) => {

                        
                                byte[] png_byte_array =  Leitor_arquivo.Pegar_parte_de_arquivo(  _dados.path , _dados.pointr_1, _dados.pointr_2  ); 
                                
                                // switch( _dados.tipo ){
                                //     //     path tem que vir com a extencao se for tipo path
                                //     case Tipo_pegar_png.path : png_byte_array = Leitor_arquivo.Pegar_arquivo( _path ); break;
                                //     case Tipo_pegar_png.compactado: png_byte_array = Leitor_arquivo.Pegar_parte_de_arquivo(  _path , _dados.pointr_1, _dados.pointr_2  ) ;break;

                                // }

                                // if( _dados.tipo_pegar_png == Tipo_pegar_png.path ){
                                    
                                //     png_byte_array = System.IO.File.ReadAllBytes( path );

                                // } else {



                                // }




                                // *** de baixo eu tirei para compilar


                                // Png_decoder.Png image = Png_decoder.Png.Open( _png_array );

                                // int width = ( int )image.Width;
                                // int height = ( int )image.Height;

                                // int total_bytes =  width *  height * 4;


                                // // tem que separar em arrays

                                // int total_pixels =  ( width *  height ) ;

                                // Color32[][] cores_2d_arr = new Color32[ quantidade_de_interacoes_necessarias ][];

                                // int heights_ja_usadas = 0;

                                // for( int slot_cores = 0 ; slot_cores < quantidade_de_interacoes_necessarias ; slot_cores++ ){

                                //     int heights = quantidade_de_height_por_bloco;
                                //     if( slot_cores == ( quantidade_de_interacoes_necessarias - 1 ) ) { heights = ( heigth - heights_ja_usadas ); }
                                //     heights_ja_usadas += heights; 

                                //     cores_2d_arr[ slot_cores ] = new Color32[ heights * width ];

                                //     // como unica variavel é heigth o width continua igual
                                //     for( int h = 0 ; h < heights ; h++ ){
                                //         for(  int w = 0 ; w < width ; w++ ){

                                //             Pixel pixel = image.GetPixel( w, ( heights - 1 -  h ) );

                                //             int p = ( w  ) + (h  * width );

                                //             cores[ p ].r =  pixel.R;
                                //             cores[ p ].g =  pixel.G; 
                                //             cores[ p ].b =  pixel.B; 
                                //             cores[ p ].a =  pixel.A; 

                                //         }
                                //     }
                                // }

                                // _req.dados = ( System.Object ) cores;

                                return;

                        
                    };







        }




       public static Action< Task_req >[] Pegar_parcial_imagem_grande(  int _quantidade_de_interacoes_necessarias , int quantidade_de_height_por_bloco, int height , int width  ){


        // arrumar depois 
        return null;


                        // Action<Task_req>[] retorno_actions = new Action<Task_req>[ _quantidade_de_interacoes_necessarias ] ;

                        // float pixels_ja_contabilizados = 0f;


                        // for( int index_interacao = 0 ; index_interacao < _quantidade_de_interacoes_necessarias ; index_interacao++ ) {


                        //         retorno_actions[ index_interacao ] = ( Task_req _req) => {


                        //                 if( _req.dados == null ){

                        //                         Sprite_em_cache novo_retorno_cache = new Sprite_em_cache();
                        //                         novo_retorno_cache.sprites = new Sprite[ _quantidade_de_interacoes_necessarias ];
                        //                         novo_retorno_cache.posicoes = new float[ _quantidade_de_interacoes_necessarias ][];
                        //                         novo_retorno_cache.tipo = Tipo_sprite_cache.imagem_complexa;


                        //                 }

                        //                 Color32[][] color_2d = ( Color32[][] )  _req.dados_suporte_1 ;
                        //                 Color32[] color = color_2d[ index_interacao ];

                        //                 Texture2D tex = new Texture2D(  width  , height , TextureFormat.RGBA32,  false ); 
                        //                 tex.SetPixelData( cores , 0);
                        //                 tex.Apply( false, false );
                        //                 Sprite sprite_retorno  =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );



                        //                 Sprite_em_cache sprite_cache =  ( Sprite_em_cache ) _req.dados;
                        //                 sprite_cache.sprites[ index_interacao ] = sprite_retorno;
                        //                 float[] nova_posicao = Pegar_posicao( quantidade_de_height_por_bloco , pixels_ja_contabilizados , height  );
                        //                 sprite_cache.posicoes[ index_interacao ] = nova_posicao;
                        //                 _req.dados =  ( System.Object ) retorno_cache;

                        //                 pixels_ja_contabilizados += nova_posicao[ 1 ];

                                
                        //                 return;

                        //         };




                        // }



                        // float[] Pegar_posicao( int _pixels_bloco , int _pixels_ja_contabilizados  , int _height_imagem ){

                        //     // *** quando eu conseguir testar ver como as linahs vao se comportar 

                        //             float pixels_bloco = ( float ) _pixels_bloco;
                        //             float pixels_ja_contabilizados = ( float ) _pixels_ja_contabilizados;
                        //             float height_imagem = ( float ) _height_imagem ;



                        //             float quanto_para_cima =   ( height_imagem / 2f ) - ( pixels_ja_contabilizados * 2f) - pixels_bloco / 2f;

                        //             return new float[ 2 ] { 0 , quanto_para_cima };

                        //             // // talvez nao precisa 
                        //             // bool eh_impar = ( height_imagem % 2 == 1 );
                        //             // if( eh_impar ) { quanto_para_cima++ ; }


                        // }



                            

                    }


        public static  Action<Task_req> Pegar_fn__finalizar( Task_req _req ){

            return ( Task_req _req ) => {};

        }






       }



        


