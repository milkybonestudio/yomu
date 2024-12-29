



public static class Interpretador_ponto {



        public static Locator_position[] Pegar_pontos_possiveis_movimento( Ponto _ponto ){

                if( _ponto.ponto_ativo != null  )
                        {
                                int periodo = Controlador_timer.Pegar_instancia().periodo_atual_id;
                                Interativo_tela[] interativos_tela = _ponto.ponto_ativo.interativos_tela;

                                int interativo_index = 0;
                                int numero_interativos_movimento = 0;

                                for( interativo_index = 0 ; interativo_index < interativos_tela.Length ; interativo_index++ ){

                                        if( interativos_tela[ interativo_index ].tipo_interativo_tela ==  Tipo_interativo_tela.movimento )
                                                { numero_interativos_movimento++; }
                                        continue;

                                }

                                Locator_position[] posicoes_retorno = new Locator_position[ numero_interativos_movimento ];

                                // int posicoes_retorno_index = 0;
                                // for( interativo_index = 0 ; interativo_index < interativos_tela.Length ; interativo_index++ ){

                                //         if( interativos_tela[ interativo_index ].tipo_interativo_tela == Tipo_interativo_tela.movimento )
                                //                 { 
                                //                         Locator_position posicao = new Locator_position();
                                //                         byte[] dados = interativos_tela[ interativo_index ].dados_logicas_interativos_tela;

                                //                         posicao.regiao_id = 0;
                                //                         posicao.regiao_id += ( short ) dados[ 0 ];
                                //                         posicao.regiao_id += ( short ) dados[ 1 ];

                                //                         posicao.trecho_id = dados[ 2 ];
                                //                         posicao.cidade_no_trecho_id = dados[ 3 ];
                                //                         posicao.zona_id = dados[ 4 ];
                                //                         posicao.local_id = dados[ 5 ];
                                //                         posicao.area_id = dados[ 6 ];
                                //                         posicao.ponto_id = dados[ 7 ];

                                //                         posicoes_retorno[ posicoes_retorno_index ] = posicao;
                                //                         posicoes_retorno_index++;
                                                        
                                //                 }


                                //         continue;

                                // }

                                return posicoes_retorno;
                                
                        }

                // --- PEGAR COMPRIMIDO
                throw new System.Exception( "ainda nao foi feito" );

   
        }


        public static Interativo_tela[] Pegar_interativos_tela( Ponto _ponto ){

                return null;

                int periodo = Controlador_timer.Pegar_instancia().periodo_atual_id;

                byte[] dados_comprimidos = _ponto.dados_interativos_tela_dados_COMPRIMIDOS;

                // ve quantos periodos tem 
                // 1 => todos n => n
                // 3 => 2( dia e noite ) ( 0,1,2 ) => 0 || ( 3,4 ) => 1
                // 6 => n => 0

                int divisor = dados_comprimidos[ 0 ];

                int pointer_localizador = ( 2 * ( periodo / divisor )) + 1; // como é short tem 2 bytes por localizador

                int ponto_inicial = dados_comprimidos[ pointer_localizador ];



        }



}