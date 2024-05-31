using System;



public static class Tradutor_save {

        public static Dados_sistema_personagem[] Descompactar_dados_sistema_personagens( byte[] _dados_sistema ){

                // converte para dados
                return null;

        }

        public static byte[] Compactar_dados_sistema_personagens( Dados_sistema_personagem[] _dados_sistema ){

                // converte para dados
                return null;

        }


        public static Personagem[] Descompactar_dados_personagens( Dados_sistema_personagem[] _dados_sistema ){

                return null;

        }

        public static byte[] Descompactar_dados_personagens( Personagem[] _dados_sistema ){
                
                return null;

        }


            /*

                  Precisa sempre cirar primeiro o inverso, 
                                                    quebrado 
                  // [ F-1 ] [ F ] [ F-1 ] [ F ] [ F-1 ] [ F 

                  se o 

            */



            // vai continuar 
        public static  byte[] Compactar_pedido_para_salvar_em_byte_arr( string[] _paths_arquivo , int[][] _indexes_arr , byte[][][] _bytes_conteudo_arr ){


                //     ---FORMATO FINAL:
                //         estado   numero containers  index container 1     index container 2 .... n containers 
                //     [   1 byte      1 byte             4 bytes              4 bytes                              ];


                int numero_de_paths = _paths_arquivo.Length;
                int index_necessario = 0;

                // colocar os resultados de cada loop aqui
                byte[][] containers = new byte[ numero_de_paths ][];

                // vai ser usado para criar o byte_arr final
                int[] paths_lengths = new int[ numero_de_paths ];

                int total_de_bytes_acumulados_containers = 0;

                int path_index = 0;

                string path_save_folder = Controlador_save.Pegar_instancia().path_save_folder;

                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding( true );


                for(  path_index = 0 ; path_index < numero_de_paths ; path_index++  ){

                        // --- FORMATO CONTAINER:
                        // cada byte[] criado vai ter os dados completos 
                        //   length path    path      index container     numero dados     dados  ... k times
                        // [   2 bytes     n bytes        4 bytes           2 bytes      n dados  ...     ]


                        string path_arquivo = _paths_arquivo[ path_index ];
                        int[] indexes = _indexes_arr[ path_index ] ;
                        byte[][] bytes_conteudos = _bytes_conteudo_arr[ path_index ] ;

                        int numero_de_indexes = indexes.Length;


                        string path_arquivo_completo =  path_save_folder  +  path_arquivo;
                        if( ! ( System.IO.File.Exists( path_arquivo_completo ) ) ){ throw new Exception( $"nao foi achado arquivo no path { path_arquivo_completo}" ); }
                        
                        // lembrar que tem que referter depois
                        byte[] path_versao_bytes_arr = encoder.GetBytes( path_arquivo_completo ) ;
                        int total_bytes_path =  path_versao_bytes_arr.Length;
                        

                        //                
                        int total_bytes_dados = 0 ;
                        int index_dados = 0 ;

                        for(  index_dados = 0 ; index_dados < numero_de_indexes   ; index_dados++ ){

                                int length_buffer = bytes_conteudos[ index_dados ].Length ;
                                total_bytes_dados += 4 + 2 + length_buffer;

                        }

                        int total_bytes_container = 2 +  total_bytes_path + total_bytes_dados;

                        // vai ser usado para criar o byte array final
                        total_de_bytes_acumulados_containers += total_bytes_container;

                        byte[] container = new byte[ total_bytes_container ];

                        container[ 0 ] = ( byte ) ( total_bytes_path >> 8 );
                        container[ 1 ] = ( byte ) ( total_bytes_path >> 0 );


                        for( int path_byte = 0 ; path_byte < total_bytes_path ; path_byte++ ){

                                container[ 2 + path_byte  ] = path_versao_bytes_arr[ path_byte ];

                        }

                        int index_start = 2 +  total_bytes_path;


                        for(  index_dados = 0 ; index_dados < numero_de_indexes   ; index_dados++ ){

                                int index_container = indexes[ index_dados ];


                                byte[] buffer = bytes_conteudos[ index_dados ];
                                int length_buffer = buffer.Length;

                                // tem que usar unsafechecked?
                                container[  index_start  +  0  ] = ( byte ) ( index_container >> 24 );
                                container[  index_start  +  1  ] = ( byte ) ( index_container >> 16 );
                                container[  index_start  +  2  ] = ( byte ) ( index_container >>  8 );
                                container[  index_start  +  3  ] = ( byte ) ( index_container >>  0 );

                                for( int buffer_id = 0 ; buffer_id < length_buffer ; buffer_id++ ){

                                            container[  index_start  +  4 + buffer_id ] = buffer[ buffer_id ];

                                }

                                index_start += 4 + 2 + length_buffer;

                        }

                        containers[ path_index ] = container;

                        

                }


                byte[] byte_array_final = new byte[ total_de_bytes_acumulados_containers ];
                
                //  1 => salvando
                byte_array_final[ 0 ] = ( byte ) 1;
                byte_array_final[ 1 ] = ( byte ) numero_de_paths;

                

                //                             4 bytes / path
                int acumulador = 2 + ( numero_de_paths * 4 ) ;
                
                // coloca os paths pointers 
                for(  int container_index = 0 ; container_index < numero_de_paths ; container_index++  ){


                        byte[] container = containers[ container_index ];
                        int container_length = container.Length;


                        for( int container_byte = 0 ;  container_byte < container_length  ; container_byte++  ){

                                byte_array_final[ acumulador + container_byte ] = container[ container_byte ];

                        }


                        byte_array_final[  2 + ( 4 * container_index ) + 0 ] = ( byte ) (acumulador >> 24 );
                        byte_array_final[  2 + ( 4 * container_index ) + 1 ] = ( byte ) (acumulador >> 16 );
                        byte_array_final[  2 + ( 4 * container_index ) + 2 ] = ( byte ) (acumulador >>  8 );
                        byte_array_final[  2 + ( 4 * container_index ) + 3 ] = ( byte ) (acumulador >>  0 );

                        acumulador += container_index;

                }


                return byte_array_final;


        }



}