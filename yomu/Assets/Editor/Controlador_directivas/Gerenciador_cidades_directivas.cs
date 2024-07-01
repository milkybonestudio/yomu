

public static class Gerenciador_cidades_directivas {






                public static string Pegar_cidades_para_adicionar(   Estado_nome[] _estados_ativos_pre, Cidade_nome[] _cidades_ativas_pre,  string _texto ){



                                Verificar_se_tem_cidades_repetidas( _cidades_ativas_pre );

                                Cidade_nome[] cidades_por_estado_forcado = Pegar_cidades_por_estado( _estados_ativos_pre );
                                Cidade_nome[] cidades_ativas = Pegar_cidades_ativas_sem_repetidas( cidades_por_estado_forcado, _cidades_ativas_pre );

                                string[] nomes_array = new string[ cidades_por_estado_forcado.Length + cidades_ativas.Length  ];
                                

                                int index = 0 ;

                                for( index = 0 ; index < cidades_por_estado_forcado.Length ; index++ ){

                                        nomes_array[ index ] = cidades_por_estado_forcado[ index ].ToString().ToUpper() ;

                                }

                                int ponto_inicial = cidades_por_estado_forcado.Length;

                                for( index = 0 ; index < cidades_ativas.Length ; index++ ){

                                        nomes_array[ ponto_inicial+ index ] =   cidades_ativas[ index ].ToString().ToUpper() ;

                                }

                                return  string.Join( ';' , nomes_array );







                }


                public static Cidade_nome[] Pegar_cidades_ativas_sem_repetidas( Cidade_nome[] _cidades_por_estado_forcado , Cidade_nome[] _cidades_ativas_pre){



                                // --- VERIFICAR CIDADES REPETIDAS

                                int cidade_index = 0;
                                int numero_para_excluir = 0;

                                for(  cidade_index = 0 ; cidade_index < _cidades_por_estado_forcado.Length ; cidade_index++ ){

                                                Cidade_nome cidade_para_verificar = _cidades_por_estado_forcado[ cidade_index ];

                                                for(   int cidade_ativa_index = 0 ;  cidade_ativa_index < _cidades_ativas_pre.Length ; cidade_ativa_index++ ){

                                                        if( _cidades_ativas_pre[ cidade_ativa_index ] == cidade_para_verificar )
                                                                { 
                                                                        numero_para_excluir++; 
                                                                        _cidades_ativas_pre[ cidade_ativa_index ] = Cidade_nome.nada;
                                                                        break;
                                                                }

                                                        continue;

                                                }

                                                continue;
                                                
                                }


                                Cidade_nome[] cidades_ativas = new Cidade_nome[ ( _cidades_ativas_pre.Length - numero_para_excluir ) ];

                                int novo_index = 0;
                                for( cidade_index = 0 ; cidade_index < _cidades_ativas_pre.Length ; cidade_index++ ){

                                        if( _cidades_ativas_pre[ cidade_index ] == Cidade_nome.nada )
                                                { continue; }

                                        cidades_ativas[ novo_index ] = _cidades_ativas_pre[ cidade_index ];
                                        novo_index++;
                                        continue;

                                }

                                

                                return cidades_ativas;


                }


                                // --- VERIFICAR SE TEM REPEDITO NAS CIDADES ATIVAS


                public static  void Verificar_se_tem_cidades_repetidas( Cidade_nome[] _cidades_ativas ){



                                for( int cidade_ativa_para_verificar_igual_index = 0 ; cidade_ativa_para_verificar_igual_index < ( _cidades_ativas.Length - 1 ); cidade_ativa_para_verificar_igual_index++ ){

                                                Cidade_nome cidade_para_verificar = _cidades_ativas[ cidade_ativa_para_verificar_igual_index ];

                                                for( int cidade_ativa_secundaria_index = cidade_ativa_para_verificar_igual_index + 1 ; cidade_ativa_secundaria_index < _cidades_ativas.Length ; cidade_ativa_secundaria_index++ ){

                                                                if( _cidades_ativas[ cidade_ativa_secundaria_index ] == cidade_para_verificar )
                                                                        { throw new System.Exception( $"veio a cidade { _cidades_ativas[ cidade_ativa_secundaria_index ] } veio repetida em controlador simbulos" ); }

                                                                continue;

                                                }

                                                continue;

                                       
                                }

                                return;

                }



        
                public static Cidade_nome[] Pegar_cidades_por_estado( Estado_nome[] _estados_ativos_pre ){


                                // --- PEGA AS CIDADES 

                                Cidade_nome[][] cidades_arr = new Cidade_nome[ _estados_ativos_pre.Length ][];
                                
                                for( int estado_slot = 0; estado_slot < _estados_ativos_pre.Length ; estado_slot++  ){

                                                Estado_nome estado = _estados_ativos_pre[ estado_slot ];
                                                Posicao posicao = new Posicao();
                                                posicao.estado_id = ( int ) estado;

                                                cidades_arr[ estado_slot ] = Leitor_cidades_DESENVOLVIMENTO.Pegar_cidades_no_estado( posicao );
                                                continue;

                                }


                                // --- PEGA A QUANTIDADE DE CIDADES

                                int length = 0;
                                foreach( Cidade_nome[] cidades_slot in cidades_arr  ){ length += cidades_slot.Length;  }

                                Cidade_nome[] cidades = new Cidade_nome[ length ];


                                // --- PASSA AS CIDADES PARA O CONTAINER
                                int index = 0;
                                for( int slot_index = 0 ; slot_index < cidades_arr.Length ; slot_index++ ){

                                                Cidade_nome[] cidades_para_pegar = cidades_arr[ slot_index ];
                                                
                                                for(  int cidade_slot = 0 ; cidade_slot < cidades_para_pegar.Length ; cidade_slot++ ){

                                                                Cidade_nome cidade = cidades_para_pegar[ cidade_slot ];
                                                                cidades[ index ] = cidade ;
                                                                index++;
                                                                continue;

                                                }

                                                continue;

                                }

                                return cidades;



                }










}