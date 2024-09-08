
// ** talvez depois colocar isso em um assembly especial. coisa que precisam compactar e descompactar podem ficar muito pesados para manter na ram a todo instante 


public static class Tradutor_pontos_estado_atual {


        public static Ponto[][][][] Descompactar_pontos( byte[] _dados_para_criar_pontos , Gerenciador_dados_pontos _gerenciador_dados_pontos  ){

                // *** telvezvalha a pena chamar essa funcao somente depois de carregar os dados no gerenciador_dados_pontos e itnerativos 
                // *** dai aqui eu ó verifico quais pontos estao ativos
                // *** pontos que nao estao ativos podem só voltar 

                int index = 0;

                int quantidade_de_zonas = ( int ) _dados_para_criar_pontos[ index ] ;
                index++;         

                Ponto[][][][] pontos_retorno = new Ponto[ quantidade_de_zonas ][][][]; 

                // --- LOOP ZONAS
                for( int zona_index = 0 ; zona_index < quantidade_de_zonas ; zona_index++ ){


                        int numero_locais = ( int ) _dados_para_criar_pontos[ index ] ;
                        index++;

                        Ponto[][][] zona_pontos = new Ponto[ numero_locais ][][];
                
                        // --- LOOP LOCAIS
                        for( int local_index = 0 ; local_index < numero_locais ; local_index++ ){


                                int numero_areas = ( int ) _dados_para_criar_pontos[ index ];
                                index++;

                                Ponto [][] locais_pontos = new Ponto[ numero_areas ][];
                
                                // --- LOOP AREAS
                                for( int area_index = 0; area_index < numero_areas; area_index++ ){


                                        int numero_pontos = ( int ) _dados_para_criar_pontos[ index ];
                                        index++;
                                        Ponto[] pontos = new Ponto[ numero_pontos ];
                
                                        // --- LOOP PONTOS
                                        for( int ponto_index = 0 ; ponto_index < numero_pontos ; ponto_index++ ){


                                                // --- CRIAR PONTO
                                                Ponto novo_ponto = new Ponto();

                                                // --- COLOCA NO ARRAY
                                                pontos[ ponto_index ] = novo_ponto;

                                                byte tipo = _dados_para_criar_pontos[ index ];
                                                index++;

                                                if( tipo == 0 )
                                                        {
                                                                // --- PONTO COMPRIMIDO => VAI PARA O PROXIMO PONTO
                                                                continue;
                                                        }
                                                        else 
                                                        {
                                                                // --- POTNO ATIVO 
                                                                novo_ponto.ponto_ativo = new Ponto_ativo();


                                                        }



//mark


// *** TEM QUE COLOCAR DEPOIS NO GERENCIADOR PONTOS PARA DESCOMPACTAR

// // --- PEGA PONTO ID
// byte ponto_id = _dados_para_criar_pontos[ index ];
// index++;
// novo_ponto.ponto_id = ponto_id;

// // --- PEGA BACKGROUND ID
// byte imagem_background_base_id =  _dados_para_criar_pontos[ index ];
// index++;
// novo_ponto.background_sprite_base_id = imagem_background_base_id;


// // --- PEGA INTERETIVOS PARA ADICIONAR

// for( int interativo_tipo = 0 ; interativo_tipo < 2 ; interativo_tipo ++ ){

//         // 0 => adicionar
//         // 1 => subtrair

//         int periodos_no_interativo = _dados_para_criar_pontos[ index ];
//         index++;

//         byte[][] interativos_por_periodo = new byte[ periodos_no_interativo ][];


//         // --- LOOP SOBRE CADA PERIODO
//         for( int periodo_index = 0 ; periodo_index < periodos_no_interativo ; periodo_index++ ){

//                 int numero_interativos = _dados_para_criar_pontos[ index ];
//                 index++;
//                 byte[] interativos_ids = new byte[ numero_interativos ];


//                 // --- VAI PEGAR OS INTERATIVOS DESSE PERIODO
//                 for( int interativo_index = 0 ; interativo_index < numero_interativos ; interativo_index++ ){

//                         interativos_ids[ interativo_index ] = _dados_para_criar_pontos[ index ];
//                         index++;
//                         continue;
//                 }

//                 interativos_por_periodo[ periodo_index ] = interativos_ids;

//                 // --- VAI PARA O PROXIMO PERIODO
//                 continue;

//         }


//         // --- COLOCAR NO PONTO

//         if( interativo_tipo == 0 )
//                 { novo_ponto.interativos_por_periodo_para_adicionar =  interativos_por_periodo; } // --- PARA ADICIONAR
//                 else 
//                 { novo_ponto.interativos_por_periodo_para_subtrair  =  interativos_por_periodo; } // --- PARA SUBTRAIR


//         // --- VAI PARA O PROXIMO TIPO
//         continue;
        


// }




// // --- PEGA ITENS NO PONTO
// int numero_itens = ( int ) _dados_para_criar_pontos[ index ];
// index++;

// novo_ponto.itens_no_ponto = new Item_localizador[ numero_itens ];

// // ** tamanho items_localizador = 5
// for( int item_index = 0 ; item_index < numero_itens ; item_index ++ ){

//         // Item_localizador item_Localizador = new Item_localizador();

//         // item_Localizador.tipo_id = _dados_para_criar_pontos[ index ];
//         // index++;
//         // item_Localizador.categoria_id = _dados_para_criar_pontos[ index ];
//         // index++;
//         // item_Localizador.modelo_id = _dados_para_criar_pontos[ index ];
//         // index++;

//         // // --- PASSA 2BYTES => SHORT
//         // item_Localizador.item_id = ( ( short ) _dados_para_criar_pontos[ index ] << 8 );
//         // index++;
//         // item_Localizador.item_id = ( ( short) _dados_para_criar_pontos[ index ] << 0 );
//         // index++;
//         // novo_ponto.itens_no_ponto[ item_index ] = item_Localizador;

//         continue;



// }


// // --- CRIAR SCRIPTS
// int numero_scripts = _dados_para_criar_pontos[ index ];
// index++;
// novo_ponto.scripts_entrada = new Script_localizador[ numero_scripts ];

// // ** tamanho scripts_localizador = 5
// for( int script_index = 0 ; script_index < numero_scripts ; script_index++  ){

//         // Script_localizador script_localizador = new Script_localizador();

//         // script_localizador.escopo_id = _dados_para_criar_pontos[ index ];
//         // index++;
//         // script_localizador.bloco_id = _dados_para_criar_pontos[ index ];
//         // index++;
//         // script_localizador.set_id = _dados_para_criar_pontos[ index ];
//         // index++;
//         // script_localizador.subset_id = _dados_para_criar_pontos[ index ];
//         // index++;
//         // script_localizador.script_id = _dados_para_criar_pontos[ index ]; 
//         // index++;

//         // novo_ponto.scripts_entrada[ script_index ] = script_localizador;

//         continue;

// }


// // --- CRIAR PERSONAGENS
// int numero_personagens = _dados_para_criar_pontos[ index ];
// index++;
// novo_ponto.personagens_no_ponto = new Personagem_nome[ numero_personagens ];

// for( int personagem_index = 0 ; personagem_index < numero_itens ; personagem_index++  ){

//         // ** talvez usar fixed e usar pointers?

//         int personagem_id = 0;

//         // personagem_id += ( ( int ) _dados_para_criar_pontos[ index ] << 24 );
//         // index++;
//         // personagem_id += ( ( int ) _dados_para_criar_pontos[ index ] << 16 );
//         // index++;
//         // personagem_id += ( ( int ) _dados_para_criar_pontos[ index ] <<  8 );
//         // index++;
//         // personagem_id += ( ( int ) _dados_para_criar_pontos[ index ] <<  0 );
//         // index++;



//         novo_ponto.personagens_no_ponto[ personagem_index ] = ( Personagem_nome ) personagem_id;
//         index++;

//         continue;

// }
                                                

                                                

                                                // --- VAI PARA O PROXIMO PONTO
                                                continue;

                                        }

                                        locais_pontos[ area_index] = pontos;

                                        // --- VAI PARA A PROXIMA AREA
                                        continue;


                                }


                                zona_pontos[ local_index ] = locais_pontos;
                                // --- VAI PARA O PROXIMO LOCAL
                                continue;


                        }

                        pontos_retorno[ zona_index ] = zona_pontos;
                        
                        // --- VAI PARA A PROXIMA ZONA
                        continue;
                        
                }


                // --- RETORNA OS PONTOS ATUAIS DA CIDADE PRIMARIA
                return pontos_retorno;

        }






        public static byte[] Compactar_pontos( Ponto[][][][] _pontos_completos){

                // ** 50k acho que da 
                byte[] dados_para_criar_pontos = new byte[ 50_000 ];

                // --- PEGAR LENGTH

                int index = 0;

                // --- PEGA QUANTIDADE DE ZONAS 
                dados_para_criar_pontos[ index ] = ( byte ) _pontos_completos.Length;
                index++;

                // --- LOOPE SOBRE ZONAS
                for( int zona_index = 0 ; zona_index < _pontos_completos.Length ; zona_index++ ){

                        // --- VERIFICA SE PRECISA AUMENTAR
                        if( ( index - dados_para_criar_pontos.Length ) < 5_000 )
                            { dados_para_criar_pontos = BYTE.Aumentar_length_array( dados_para_criar_pontos, 10_000 ); } // --- VAI AUMENTAR


                        Ponto[][][] zona_pontos = _pontos_completos[ zona_index ];

                        // --- PEGA NUMERO DE LOCAIS DA ZONA
                        dados_para_criar_pontos[ index ] = ( byte ) zona_pontos.Length;
                        index++;

                        // --- LOOP LOCAIS
                        for( int local_index = 0 ; local_index < zona_pontos.Length ; local_index++ ){

                            
                                Ponto[][] locais_pontos = zona_pontos[ local_index ];

                                // --- PEGA NUMERO DE AREAS NO LOCAL
                                dados_para_criar_pontos[ index ] = ( byte ) locais_pontos.Length;
                                index++;
                                
                                // --- LOOP AREAS
                                for( int area_index = 0; area_index < locais_pontos.Length; area_index++ ){


                                        Ponto[] area_pontos = locais_pontos[ area_index ];
                                        
                                        // --- PEGA NUMERO DE PONTOS NA AREA
                                        dados_para_criar_pontos[ index ] = ( byte ) area_pontos.Length;
                                        index++;

                                        // --- LOOP PONTO
                                        for( int ponto_index = 0 ; ponto_index < area_pontos.Length ; ponto_index++ ){


                                                // --- PEGA PONTO PARA COMPACTAR
                                                Ponto ponto = area_pontos[ ponto_index ];

                                                if( ponto.ponto_ativo != null )
                                                        {
                                                                // --- ESTA ATIVO
                                                                dados_para_criar_pontos[ index ] = 1;
                                                                index++;
                                                        
                                                        }
                                                        else 
                                                        {
                                                                // --- NAO ESTA ATIVO
                                                                dados_para_criar_pontos[ index ] = 0;
                                                                index++;

                                                        }




//mark

// *** COLOCA DEPOIS NO GERENCIADOR PONTOS

// // --- COLOCA ID
// dados_para_criar_pontos[ index ] = ponto.ponto_id;
// index++;

// // --- COLOCA BACKGROUND ID
// dados_para_criar_pontos[ index ] =  ponto.background_sprite_base_id;
// index++;




// // --- COLOCA INTERETIVOS PARA ADICIONAR

// for( int interativo_tipo = 0 ; interativo_tipo < 2 ; interativo_tipo ++ ){

//         // 0 => adicionar
//         // 1 => subtrair

//         // --- PEGA DADOS DO PONTO

//         byte[][] interativos_por_periodo = null;

//         if( interativo_tipo == 0 )
//                 { interativos_por_periodo = ponto.interativos_por_periodo_para_adicionar ; } // --- PARA ADICIONAR
//                 else 
//                 { interativos_por_periodo = ponto.interativos_por_periodo_para_subtrair  ; } // --- PARA SUBTRAIR


//         // --- PEGA QUANTOS PERIODOS TEM NO TIPO
//         dados_para_criar_pontos[ index ] = ( byte ) interativos_por_periodo.Length; 
//         index++;


//         // --- LOOP SOBRE CADA PERIODO
//         for( int periodo_index = 0 ; periodo_index < interativos_por_periodo.Length ; periodo_index++ ){

//                 // --- PEGA QUNATOS INTERATIVOS TEM EM CADA PERIODO
//                 dados_para_criar_pontos[ index ] = ( byte ) interativos_por_periodo[ periodo_index ].Length ;
//                 index++;

//                 byte[] interativos_ids = interativos_por_periodo[ periodo_index ];


//                 // --- VAI COLOCAR OS INTERATIVOS DESSE PERIODO
//                 for( int interativo_index = 0 ; interativo_index < interativos_por_periodo[ periodo_index ].Length ; interativo_index++ ){

//                         dados_para_criar_pontos[ index ] = interativos_ids[ interativo_index ];
//                         index++;
//                         continue;
//                 }

//                 // --- VAI PARA O PROXIMO PERIODO
//                 continue;

//         }




//         // --- VAI PARA O PROXIMO TIPO
//         continue;
        


// }















// // --- COLOCA ITENS NO PONTO
// Item_localizador[] item_localizadores = ponto.itens_no_ponto;
// dados_para_criar_pontos[ index ] = ( byte ) item_localizadores.Length;
// index++;



// // ** tamanho items_localizador = 5
// for( int item_index = 0 ; item_index < ponto.itens_no_ponto.Length ; item_index++  ){

//         Item_localizador item_Localizador = ponto.itens_no_ponto[ item_index ];

//         dados_para_criar_pontos[ index ] = item_Localizador.tipo_id;
//         index++;

//         dados_para_criar_pontos[ index ] = item_Localizador.categoria_id;
//         index++;
        
//         dados_para_criar_pontos[ index ] = item_Localizador.modelo_id;
//         index++;

//         // --- PASSA SHORT  => 2 BYTES
//         dados_para_criar_pontos[ index ] = ( byte )( item_Localizador.item_id >> 8 );
//         index++;
//         dados_para_criar_pontos[ index ] = ( byte )( item_Localizador.item_id >> 0 );
//         index++;
        
//         continue;

// }


// // --- CRIAR SCRIPTS
// Script_localizador[] script_Localizadors = ponto.scripts_entrada;
// dados_para_criar_pontos[ index ] = ( byte ) script_Localizadors.Length;
// index++;

// // ** tamanho scripts_localizador = 5
// for( int script_index = 0 ; script_index < script_Localizadors.Length ; script_index++ ){

//         Script_localizador script_localizador = ponto.scripts_entrada[ script_index ];

//         dados_para_criar_pontos[ index ] = script_localizador.escopo_id;
//         index++;
//         dados_para_criar_pontos[ index ] = script_localizador.bloco_id; 
//         index++;
//         dados_para_criar_pontos[ index ] = script_localizador.set_id;
//         index++;
//         dados_para_criar_pontos[ index ] = script_localizador.subset_id;
//         index++;
//         dados_para_criar_pontos[ index ] = script_localizador.script_id; 
//         index++;

//         continue;

// }


// // --- COLOCA PERSONAGENS
// Personagem_nome[] personagens = ponto.personagens_no_ponto;

// // ** PEGA LENGTH
// dados_para_criar_pontos[ index ] = ( byte ) personagens.Length;
// index++;


// for( int personagem_index = 0 ; personagem_index < personagens.Length ; personagem_index++  ){

//         int personagem_id = ( int ) personagens[ personagem_index ];

//         dados_para_criar_pontos[ index ] = ( byte ) ( personagem_id >> 24 );
//         index++;
//         dados_para_criar_pontos[ index ] = ( byte ) ( personagem_id >> 16 );
//         index++;
//         dados_para_criar_pontos[ index ] = ( byte ) ( personagem_id >>  8 );
//         index++;
//         dados_para_criar_pontos[ index ] = ( byte ) ( personagem_id >>  0 );
//         index++;


//         continue;

// }


                                                // --- VAI PARA O PROXIMO PRONTO
                                                continue;

                                        }


                                        // --- VAI PARA A PROXIMA AREA
                                        continue;


                                }


                                // --- VAI PARA O PROXIMO LOCAL
                                continue;


                        }


                        // --- VAI PARA A PROXIMA ZONA
                        continue;
                        
                }

                int tamanho_dados = ( dados_para_criar_pontos.Length - index );

                byte[] dados_para_criar_pontos_finais = new byte[ tamanho_dados ];

                for( int b = 0 ; b < dados_para_criar_pontos_finais.Length ; b++ ){

                        dados_para_criar_pontos_finais[ b ] = dados_para_criar_pontos[ b ];
                        continue;
                }

                return dados_para_criar_pontos_finais;


        }



}