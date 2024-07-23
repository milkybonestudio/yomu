using System;
using System.Runtime.CompilerServices;
using UnityEngine;


#if UNITY_EDITOR

    public static class Leitor_interativos_tela {

        // !!! DEVLOPMENT
        
        public static Interativo_tela[] Pegar_interativo( Posicao _posicao, byte _interativo_id ){


                Regiao_nome regiao =  ( Regiao_nome ) _posicao.regiao_id;

                Interativo_tela_DADOS_DESENVOLVIMENTO interativo_dados = null;
                
                switch( regiao ){

                    case Regiao_nome.regiao_1: interativo_dados = Leitor_interativos__REGIAO_1.Pegar( _posicao, _interativo_id ); break;
                    default: throw new Exception( $"nao foi achado o handler para a cidade { regiao } no Leitor_interativos_tela_DESENVOLVIMENTO" );

                }


                //Construtor_interativos_DEVELOPMENT.

                

                return null;

        }




    }

#else

public static class Leitor_interativos_tela {


            // --- INICIADO NO CONTROLADOR_DADOS_DINAMICOS
            public static Gerenciador_containers_dinamicos_parciais gerenciador_dados_parciais_interativos;
            public static int[] localizador;
            
            
            public static Interativo_tela Pegar_interativo( Posicao _posicao, byte _interativo_id ){

                    // para ler aqui o sistema tem que garantir que os valores funcionam 
                    // 

                    return null;
                
                    // int pointer = -1;
                    // pointer = localizador[ _posicao.regiao_id ];

                    // gerenciador_dados_parciais.Pegar_dados(  )

            }


            public static Interativo_tela[] Pegar_interativos_tela( Posicao _posicao, byte[] _ids ){


                    int ponto_inicial_ponto = 0;

                    //** _ids poder ser usado e modificado sem problemas 


                    // --- cidade 
                    ponto_inicial_ponto = localizador[ ponto_inicial_ponto ];

                    // --- zona
                    ponto_inicial_ponto = localizador[ ponto_inicial_ponto ];

                    // --- local 
                    ponto_inicial_ponto = localizador[ ponto_inicial_ponto ];

                    // --- area 
                    ponto_inicial_ponto = localizador[ ponto_inicial_ponto ];

                    // --- ponto
                    ponto_inicial_ponto = localizador[ ponto_inicial_ponto ];


                

                    // --- VERIFICA SE O PONTO TEM INTERATIVOS
                    if( ponto_inicial_ponto== -1 )
                        {
                            // --- PONTO NAO TEM INTERATIVOS

                            if( _ids.Length != 0 )
                                { throw new Exception( $"tentou pegar os interativos { BYTE.Transformar_em_string( _ids ) } mas no localizador nao tinha nenhum"); }
                        }


                    // --- POINTER INICIAL + FINAL POR INTERATIVO PARA PEGAR A LENGTH 

                    int[] pointers_dados_interativos = new int[ ( _ids.Length * 2 )];

                    byte[][] dados_interativos = new byte[ _ids.Length ][];

                    
                    ponto_inicial_ponto++; // avanca o numero de interativos
                    
                    for( int localizacao_index = 0 ;  localizacao_index < pointers_dados_interativos.Length ; localizacao_index++ ){

                        int id = _ids[ localizacao_index ]; 
                        pointers_dados_interativos[ ( localizacao_index * 2 + 0 ) ] = localizador[ ( ponto_inicial_ponto + id  + 0 ) ]; // inicio interativo ** pointer
                        pointers_dados_interativos[ ( localizacao_index * 2 + 1 ) ] = localizador[ ( ponto_inicial_ponto + id  + 1 ) ] ; // inicio interativo da sequencia
                        
                            }


                    // *** principio : verificar coisas na ram <<<< buscar qualquer coisa em disco 

                    // --- CONTAINER QUE VAI VAO SER COLOCADOS OS DADOS 
                    
                    int[] localizadores_ids_GERENCIADOR =  gerenciador_dados_parciais_interativos.localizadores_ids;
                    byte[][] set_dados_GERENCIADOR = gerenciador_dados_parciais_interativos.set_dados_parciais;
                    int numero_interativos_pegos = 0;








                    // dados_gerenciador => loop { dados_ids }




                    // --- VERIFICAR QUAIS DADOS ESTAO NO GERENCIADOR
                    for( int localizador_id_GERENCIADOR = 0 ; localizador_id_GERENCIADOR < localizadores_ids_GERENCIADOR.Length ; localizador_id_GERENCIADOR++ ){


                            // --- PEGAR SET DADOS PARA VERIFICAR
                            int pointer_gerenciador = localizadores_ids_GERENCIADOR[ localizador_id_GERENCIADOR ];
                            byte[] dados_set_gerenciador = set_dados_GERENCIADOR[ localizador_id_GERENCIADOR ];

                            // --- VERIFICA SE O SLOT ESTA SENDO USADO
                            if( pointer_gerenciador == 0 )
                                { continue; } // --- SLOT NAO ESTA SENDO USADO 


                            // --- VERIFICA SE O SET TEM DADOS DE ALGUM INTERATIVO
                            for( int interativo_index_verificacao = 0 ; interativo_index_verificacao < _ids.Length ; interativo_index_verificacao++ ){

                                    /*  para caber:  ---500                 510--- |   x > 500  y < 510
                                                            x-------y              |                      */

                                    // --- VERIFICACOES 


                                    // --- VERIFICA SE JA FOI PEGO EM OUTRO SET
                                    if( dados_interativos[ interativo_index_verificacao ] != null )
                                        { continue; }  // --- JA FOI PEGO EM OUTRO SET

                                    // --- VERIFICAR PRIMEIRO POINTER 
                                    if( ! ( pointers_dados_interativos[ ( 2 * interativo_index_verificacao ) ] > pointer_gerenciador) )
                                        {  continue;  } // --- PRIMEIRO POINTER FALHOU

                                    // --- VERIFICAR PRIMEIRO SEGUNDO
                                    if( !( pointers_dados_interativos[ ( 2 * interativo_index_verificacao + 1 ) ] < ( pointer_gerenciador + dados_set_gerenciador.Length ) ) )
                                        {  continue;  } // --- SEGUNDO POINTER FALHOU



                                    // --- PODE PEGAR OS DADOS NESSE SET
                                    numero_interativos_pegos++;


                                    // --- CRIAR CONTAINER DADOS INTERATIVO
                                    byte[] dados_interativo = new byte[  (  pointers_dados_interativos[ ( interativo_index_verificacao * 2 + 1 ) ] -  pointers_dados_interativos[ ( interativo_index_verificacao * 2 + 0 ) ] )  ] ;


                                    // --- PASSA A REFERENCIA DO CONTAINER
                                    dados_interativos[ interativo_index_verificacao ] = dados_interativo;


                                    // --- PEGA OS DADOS
                                    int ponto_inicial = ( pointers_dados_interativos[ ( 2 * interativo_index_verificacao ) ] - pointer_gerenciador ); 

                                    for( int b = 0 ; b < dados_interativo.Length ; b++ )
                                        { dados_interativo[ b ] = dados_set_gerenciador[ ponto_inicial + b ]; }


                                    // --- VAI VERIFICAR O PROXIMO INTERATIVO
                                    continue;


                            }


                    }





                    // --- TODOS OS DADOS QUE JA ESTAVAM NA RAM JA FORAM COLOCADOS


                    // --- VERIFICAR SE AINDA TEM DADOS PARA PEGAR
                    if(  _ids.Length > numero_interativos_pegos  )
                        { 

                            // --- TEM QUE CARREGAR DADOS, VERIFICAR QUAL A MELHOR FORMA DE PEGAR PEDIDOS
                            
                            // --- CRIAR DADOS
                            int numero_interativos_faltando = ( _ids.Length - numero_interativos_pegos );
                            int distancia_maximo = 5_000; // *** precisa carregar 2500 para a direita e 2500 para a esquerda
                            int valor_atual = 0;

                            int[] pointers_maximos = new int[ numero_interativos_faltando ];
                            byte[][] dados_para_colocar = new byte[ numero_interativos_faltando ][];// ** vai ser descartado depois
                            

                            for( int interativo_index_verificacao = 0 ; interativo_index_verificacao < _ids.Length ; interativo_index_verificacao++ ){

                                    // --- VERIFICAR SE DADOS JA FORAM PEGS
                                    if( dados_interativos[ interativo_index_verificacao ] != null )
                                        { continue; } // --- JA ESTA PEGO
                                            
                                    int pointer_inicial = pointers_dados_interativos[ ( interativo_index_verificacao * 2 ) + 0 ];
                                    int pointer_final = pointers_dados_interativos[ ( interativo_index_verificacao * 2 ) + 1 ];
                                    int length = pointers_dados_interativos[ ( interativo_index_verificacao * 2 ) + 1 ] - pointers_dados_interativos[ ( interativo_index_verificacao * 2 ) + 0 ];


                                    // --- VAI BUSCAR ALGUM DISPONIVEL
                                    for( int possivel_dados = 0 ; possivel_dados < numero_interativos_faltando ; possivel_dados++){

                                            int pointer_inicio_dados = pointers_maximos[ possivel_dados ];

                                            if( possivel_dados == valor_atual )
                                                {
                                                    // --- NAO TEM MAIS DADOS CARREGADOS

                                                    // --- PRECISA CARREGAR
                                                    int localizador = (  pointer_inicial - ( distancia_maximo / 2 ) );
                                                    
                                                    pointers_maximos[ possivel_dados ] = localizador;
                                                    gerenciador_dados_parciais_interativos.Carregar_dados_NA_MULTITHREAD( localizador, distancia_maximo );
                                                    dados_para_colocar[ valor_atual ] = gerenciador_dados_parciais_interativos.Pegar_dados( localizador );
                                                    valor_atual++;

                                                    // --- CRIA CONTAINER
                                                }
                                                else
                                                {
                                                    // --- VERIFICA SE OS DADOS ESTAO NESSE CONTAINER
                                                    if(  ! ( pointer_inicial > pointer_inicio_dados ) || ! ( pointer_final < ( pointer_inicio_dados + distancia_maximo )) )
                                                        { continue;}  // --- DADO NAO ESTA AQUI
                                                        
                                                }

                                            // --- OS DADOS ESTAO NESSE CONTAINER

                                            int ponto_inicial = ( pointer_inicial - pointer_inicio_dados );
                                                

                                            byte[] container_byte = new byte[ length ];
                                            dados_interativos[ interativo_index_verificacao ] = container_byte;

                                            byte[] dados_gerenciador_container = dados_para_colocar[ valor_atual ];

                                            for( int b = 0 ; b < length; b++ ){

                                                    container_byte[ b ] = dados_gerenciador_container[ ( ponto_inicial + b) ];

                                            }



                                            // --- VAI BUSCAR O PROXIMO INTERATIVO
                                            break;
                                        


                                    }
                                    

                            }
                            
                        }


                        // --- TODOS OS INTERATIVOS TEM DADOS


                        Interativo_tela[] interativos_retorno = new Interativo_tela[ _ids.Length ];

                        int periodo = Controlador_timer.Pegar_instancia().periodo_atual_id;

                        for( int interativo_tela_index = 0  ; interativo_tela_index < _ids.Length ; interativo_tela_index++ ){

                            interativos_retorno[ interativo_tela_index ] = Transformar_bytes_em_interativo( _ids[ interativo_tela_index ], periodo, dados_interativos[ interativo_tela_index ] );

                        }

                        return interativos_retorno;



        }


        public static Interativo_tela Transformar_bytes_em_interativo( int _id, int _periodo, byte[] _dados ){



                Interativo_tela interativo_retorno = new Interativo_tela( _id );

                
                int index = 0;
                int tipo = ( int ) _dados[ index ];


                // --- VAI PEGAR SPRITE ID 1

                index += 1;
                int numero_sprites_1 = ( int ) _dados[ index ];
                interativo_retorno.sprites_imagem_1_id_unico = Pegar_sprite_id_com_byte_array( _dados, ( index + 1 ) ,_periodo , numero_sprites_1 );


                // --- VAI PEGAR SPRITE ID 2

                index += ( ( numero_sprites_1 * 4 ) + 1);
                int numero_sprites_2 = ( int ) _dados[ index ];
                interativo_retorno.sprites_imagem_2_id_unico = Pegar_sprite_id_com_byte_array(_dados, ( index + 1 ) ,_periodo , numero_sprites_2 );



                // --- VAI PEGAR COR ID 1

                index += ( ( numero_sprites_2 * 4 ) + 1);
                int numero_cores_1 = ( int ) _dados[ index ];
                interativo_retorno.cor_image_1 = Pegar_cor_com_byte_array(_dados, ( index + 1 ) ,_periodo , numero_cores_1 );


                // --- VAI PEGAR COR ID 2

                index += ( ( numero_cores_1 * 4 ) + 1);
                int numero_cores_2 = ( int ) _dados[ index ];
                interativo_retorno.cor_image_2 = Pegar_cor_com_byte_array(_dados, ( index + 1 ) ,_periodo , numero_cores_2 );



                // --- VAI PEGAR CURSOR ID

                index += ( ( numero_cores_2 * 4 ) + 1);
                int numero_cursor = ( int ) _dados[ index ];
                interativo_retorno.cor_cursor_id = ( int ) Pegar_cor_cursor( _dados, ( index + 1 ) ,_periodo , numero_cursor );




                return interativo_retorno;

        }





            [MethodImpl( MethodImplOptions.AggressiveInlining ) ]
            private static int Pegar_id_por_periodo( int _periodo , int[] _array ){

                    int retorno = -1;
                    switch( _array.Length ){

                    case 1 : retorno = _array[ 0 ] ;break;
                    case 2 : retorno = _array[ ( _periodo / 3 ) ] ;break;
                    case 4 : throw new Exception();
                    case 5 : retorno = _array[ _periodo ];break;
                    default: throw new Exception( $"numero de sprites em Criar_interativos_tela veio com length { _array.Length }" );

                    }

                    return retorno;


            }


            [MethodImpl( MethodImplOptions.AggressiveInlining ) ]
            private static int Pegar_sprite_id_com_byte_array( byte[] _bytes, int _ponto_inicial, int _periodo, int _numero_alocacoes ){

                    int retorno = -1;
                    switch( _numero_alocacoes ){

                        case 1 :    {
                                        // --- UNICO
                                        retorno = BYTE.Pegar_int_em_byte_array( _bytes, _ponto_inicial );
                                        
                                    }
                                    { break; }
                        case 2:     {
                                        // -- DIA E NOITE
                                        int slot = ( _periodo / 3 );
                                        retorno = BYTE.Pegar_int_em_byte_array( _bytes, ( _ponto_inicial + 4 * slot ) );

                                    }
                                    { break;}
                        case 5:     {
                                        // -- TODOS OS PERIODOS
                                        retorno = BYTE.Pegar_int_em_byte_array( _bytes, ( _ponto_inicial + 4 * _periodo ) );
                                        
                                    }
                                    { break;}

                    }

                    throw new Exception("a");




            }

            [MethodImpl( MethodImplOptions.AggressiveInlining ) ]
            private static Color Pegar_cor_com_byte_array( byte[] _bytes, int _ponto_inicial, int _periodo, int _numero_alocacoes ){

                    Color32 retorno = new Color32();

                    switch( _numero_alocacoes ){

                        case 1 :    {
                                        // --- UNICO
                                        retorno.r = _bytes[ ( _ponto_inicial + 0 ) ];
                                        retorno.g = _bytes[ ( _ponto_inicial + 1 ) ]; 
                                        retorno.b = _bytes[ ( _ponto_inicial + 2 ) ]; 
                                        retorno.a = _bytes[ ( _ponto_inicial + 3 ) ]; 
                                        
                                    }
                                    { break; }
                        case 2:     {
                                        // -- DIA E NOITE
                                        int slot = ( _periodo / 3 );

                                        retorno.r = _bytes[ ( ( slot * 4 ) + _ponto_inicial + 0 ) ];
                                        retorno.g = _bytes[ ( ( slot * 4 ) + _ponto_inicial + 1 ) ]; 
                                        retorno.b = _bytes[ ( ( slot * 4 ) + _ponto_inicial + 2 ) ]; 
                                        retorno.a = _bytes[ ( ( slot * 4 ) + _ponto_inicial + 3 ) ]; 

                                    }
                                    { break;}
                        case 5:     {
                                        // -- TODOS OS PERIODOS

                                        retorno.r = _bytes[ ( ( _periodo * 4 ) + _ponto_inicial + 0 ) ];
                                        retorno.g = _bytes[ ( ( _periodo * 4 ) + _ponto_inicial + 1 ) ]; 
                                        retorno.b = _bytes[ ( ( _periodo * 4 ) + _ponto_inicial + 2 ) ]; 
                                        retorno.a = _bytes[ ( ( _periodo * 4 ) + _ponto_inicial + 3 ) ]; 
                                        
                                    }
                                    { break;}

                        default : throw new Exception("");

                    }

                    return ( Color ) retorno;




            }
    


            [MethodImpl( MethodImplOptions.AggressiveInlining ) ]
            private static Cor_cursor Pegar_cor_cursor( byte[] _bytes, int _ponto_inicial, int _periodo, int _numero_alocacoes ){


                    Cor_cursor cor = Cor_cursor.nada;

                    switch( _bytes.Length ){

                    case 1 : cor = ( Cor_cursor ) _bytes[ 0 ] ;break;
                    case 2 : cor = ( Cor_cursor ) _bytes[ ( _periodo / 3 ) ] ;break;
                    case 4 : throw new Exception();
                    case 5 : cor = ( Cor_cursor ) _bytes[ _periodo ] ;break;
                    default: throw new Exception( $"numero de sprites em Criar_interativos_tela veio com length { _bytes.Length }" );

                    }

                    return cor;


            }




            

   
        

    }


#endif