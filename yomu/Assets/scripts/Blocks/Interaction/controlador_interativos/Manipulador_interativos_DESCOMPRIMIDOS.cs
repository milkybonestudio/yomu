using System;
using System.Runtime.CompilerServices;




public static class Manipulador_interativos_DESCOMPRIMIDOS {




        public static byte[] Criar_interativos_tela_ids_ponto( Ponto_ativo _ponto_ativo  ){

                throw new Exception();


        }





        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] Pegar_interativos_com_alocacao_comprimida( byte[][] _interativos_ids, int _periodo_id ){

                switch( _interativos_ids.Length  ){

                        case 1: return _interativos_ids[ 0 ];
                        case 2: return _interativos_ids[ ( _periodo_id / 3 ) ];
                        case 4: throw new Exception();
                        case 5: return _interativos_ids[ _periodo_id ];
                        default: throw new Exception();

                }

        }





        public static void Comprimir_dados_ponto( Ponto _ponto ){


            throw new System.Exception( "ainda nao era para vir aqui" );



        }




        // --- OPERACOES PRINCIPAIS

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acrescentar_interativos_tela( byte[][] _interativos_por_periodo, byte[][] _interativos_ids ){

                // TEM QUE TESTAR

                // quando vier aqui ja vai estar ajustado


                for( int _bloco = 0 ; _bloco < _interativos_por_periodo.Length ; _bloco++ ){

                        // --- CADA BLOCO

                        byte[] interativos_periodo_unico = _interativos_por_periodo[ _bloco ];
                        byte[] interativos_para_acrescentar = _interativos_ids[ _bloco ];


                        // --- VERIFICA QUANTOS ITENS REALMENTE VAO SER ADICIONADOS 
                        
                        int numero_de_adicionais = interativos_para_acrescentar.Length; 
                        
                        for( int interativo_para_acrescentar_verificacao_index = 0 ; interativo_para_acrescentar_verificacao_index < interativos_para_acrescentar.Length ; interativo_para_acrescentar_verificacao_index++ ){

                                // --- PEGA ID DA ANALISE
                                byte interativo_id_em_analise = interativos_para_acrescentar[ interativo_para_acrescentar_verificacao_index ];

                                for( int interativo_periodo_unico_id = 0 ; interativo_periodo_unico_id < interativos_periodo_unico.Length  ;interativo_periodo_unico_id++ ){

                                        if ( interativo_id_em_analise == interativos_periodo_unico[ interativo_periodo_unico_id ] )
                                            {
                                                    // --- INTERATIVO JA ESTAVA NOS ITENS PARA ADICIONAR
                                                    numero_de_adicionais--;

                                                    // --- NAO DEIXA ADICIONAR DEPOIS
                                                    interativos_para_acrescentar[ interativo_para_acrescentar_verificacao_index ] = 0;
                                                    break;
                                            }

                                        continue;

                                }

                                continue;
                        }


                        // --- GARANTE QUE TEM ALGUM
                        if( numero_de_adicionais == 0 )
                            { 
                                // --- VAI PARA O PROXIMO BLOCO
                                continue; 
                            }


                        // --- VERIFICA QUANTOS SLOTS VAZIOS TEM

                        int numero_slots_vazios = 0;

                        for( int interativo_localizador_zero_index = 0 ; interativo_localizador_zero_index < interativos_periodo_unico.Length  ;interativo_localizador_zero_index++ ){

                                // --- VERIFICA SE É UM SLOT VAZIO
                                if( interativos_periodo_unico[ interativo_localizador_zero_index ] == 0)
                                    { 
                                        // --- ACHOU SLOT VAZIO
                                        numero_slots_vazios = ( interativos_periodo_unico.Length - interativo_localizador_zero_index );
                                        break;

                                    }

                                continue;

                        }


                        // --- VERIFICAR SE CABE NOS SLOTS VAZIOS

                        if( numero_slots_vazios >= numero_de_adicionais  )
                            {

                                // --- COLOCAR SOMENTE OS ADICIONAIS
                                int interativo_final_index = ( interativos_periodo_unico.Length - numero_slots_vazios );

                                for( int interativos_para_acrescentar_index = 0 ; interativos_para_acrescentar_index < interativos_para_acrescentar.Length ; interativos_para_acrescentar_index++ ){

                                        if( interativos_para_acrescentar[ interativos_para_acrescentar_index ] != 0 )
                                                {

                                                        // --- JA COLOCA DIRETO
                                                        interativos_periodo_unico[ interativo_final_index ] = interativos_para_acrescentar[ interativos_para_acrescentar_index ];
                                                        interativo_final_index++;

                                                }

                                        continue;

                                }                        

                                // --- VAI PARA O PROXIMO BLOCO
                                continue;

                            }


                        // --- PRECISA CRIAR OUTRO SLOT

                        byte[] interativos_finais_para_acrescentar = new byte[ ( interativos_periodo_unico.Length + numero_de_adicionais ) ];

                        // --- COLOCAR NORMAIS
                        for( int interativos_finais_index = 0 ; interativos_finais_index < interativos_periodo_unico.Length ; interativos_finais_index++ ){

                                    interativos_finais_para_acrescentar[ interativos_finais_index ] = interativos_periodo_unico[ interativos_finais_index ];

                        }

                        // --- COLOCAR NOVOS
                        int index_interativos_para_acrescentar = interativos_periodo_unico.Length;
                        for( int interativos_finais_novos_index = 0  ; interativos_finais_novos_index < interativos_para_acrescentar.Length ; interativos_finais_novos_index++ ){

                                if( interativos_para_acrescentar[ interativos_finais_novos_index ] != 0 )
                                    {
                                        interativos_finais_para_acrescentar[ index_interativos_para_acrescentar  ] = interativos_para_acrescentar[ interativos_finais_novos_index ];
                                        index_interativos_para_acrescentar++;
                                    }
                                    
                                continue;
                                    
                        }

                        // --- MUDA OS INTERATIVOS 
                        _interativos_por_periodo[ _bloco ] = interativos_finais_para_acrescentar;
                        
                        // --- VAI PARA O PROCIMO BLOCO
                        continue;


                }


                return;


        }






        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remover_interativos_tela( byte[][] _interativos_por_periodo, byte[][] _interativos_ids ){

                // TEM QUE TESTAR

                // quando vier aqui ja vai estar ajustado


                for( int _bloco = 0 ; _bloco < _interativos_por_periodo.Length ; _bloco++ ){


                        // --- CADA BLOCO

                        byte[] interativos_periodo = _interativos_por_periodo[ _bloco ];
                        byte[] interativos_para_remover = _interativos_ids[ _bloco ];


                        // --- VERIFICA SE SO TEM 1 ELEMENTO PARA ADICIONAR
                        if( interativos_para_remover.Length == 1 )
                            {
                                // --- SO TEM 1 ELEMENTO

                                byte interativo_para_remover_unico = interativos_para_remover[ 0 ];

                                // --- VERIFICA SE TEM O ID
                                for( int interativo_index_atual_caso_unico = 0 ; interativo_index_atual_caso_unico < interativos_periodo.Length ; interativo_index_atual_caso_unico++ ){


                                        // --- VAI VERIFICAR SLOT 
                                        if(  interativos_periodo[ interativo_index_atual_caso_unico ] == interativo_para_remover_unico )
                                            {
                                                // --- ACHOU O ID
                                                interativos_periodo[ interativo_index_atual_caso_unico ] = 0 ; // nao precisa mas da pra entender melhor

                                                // --- VAI MOVER OS IDS 1 SLOT PARA A ESQUERDA
                                                for( int interativo_para_flipar = interativo_index_atual_caso_unico  ;  interativo_para_flipar < ( interativos_periodo.Length - 1 ) ; interativo_para_flipar++ ){

                                                        interativos_periodo[ interativo_para_flipar ] = interativos_periodo[ interativo_para_flipar + 1 ];
                                                        continue;

                                                }

                                                // --- GARANTE QUE O ULTIMO Ë ZERO, SE NAO N FICA COM O VALOR DE N-1 
                                                interativos_periodo[ ( interativos_periodo.Length - 1 ) ] = 0;

                                                break;

                                            }

                                        continue;

                                }

                                // --- VAI PARA O PROXIMO BLOCO 
                                break;

                            }

                        // --- REMOVER OS INTERATIVOS
                        for( int interativo_index = 0 ; interativo_index < interativos_para_remover.Length ; interativo_index++ ){

                                byte interativo_id_verificacao = interativos_para_remover[ interativo_index ];

                                for( int interativo_index_atual = 0 ; interativo_index_atual < interativos_periodo.Length ; interativo_index_atual++ ){

                                        if( interativos_periodo[ interativo_index_atual ] == interativo_id_verificacao )
                                            {
                                                // --- TIRA O INTERATIVO
                                                interativos_periodo[ interativo_index ] = 0;
                                                break;
                                                
                                            }

                                        continue;

                                }


                        }

                        // --- AGRUPA OS IDS VALIDOS E ISOLA OS SLOTS VAZIOS

                        // ** nao precisa verificar o ultimo porque: 
                        //      - 1 - ele é um numero valido => nao foi passado para um zero antes => já esta na possicao correta. 
                        //      - 2- é zero => nao tem mais numero para pegar => já esta na posicao correta
                        for( int interativo_para_verificar_trim = 0 ; interativo_para_verificar_trim < ( interativos_periodo.Length - 1 ); interativo_para_verificar_trim++ ){

                                // --- VERIFICA SE O SLOT ATUAL ESTA VAZIO
                                if( interativos_periodo[ interativo_para_verificar_trim ] == 0 )
                                    {
                                        // --- BUSCA O PROXIMO SLOT VALIDO
                                        for( int interativo_para_buscar_0 = ( interativo_para_verificar_trim + 1 ) ;interativo_para_buscar_0 < interativos_periodo.Length ; interativo_para_buscar_0++ ){

                                                byte possivel_interativo_id = interativos_periodo[ interativo_para_buscar_0 ];

                                                // --- VERIFICA SE O SLOT ATUAL É UM ID VALIDO
                                                if( interativos_periodo[ interativo_para_buscar_0 ] != 0 )
                                                    {
                                                        // --- ACHOU UM INTERATIVO VALIDO PARA TROCAR
                                                        interativos_periodo[ interativo_para_verificar_trim ] = possivel_interativo_id;
                                                        interativos_periodo[ interativo_para_buscar_0 ] = 0;

                                                        // --- INICIA BUSCA NO PROXIMO SLOT
                                                        break;
                                                    }
                                                        
                                                continue;

                                        }


                                    }

                                // --- VAI PARA O PROXIMO SLOT
                                continue;

                        }

                        // --- VAI PARA O PROXIMO BLOCO
                        continue;


                }


                // --- TERMINOU TODOS OS BLOCOS
                return;


        }










        // --- REAJUSTES

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[][] Garantir_mesmo_formato_interativos( Ponto_ativo _ponto, Tipo_modificacao_interativo_id _tipo,  int _tipo_alocar_interativos ,byte[][] _interativos_ids ){

                
                // --- PEGA OS INTERATIVOS ATUAIS
                byte[][] interativos_local_ref = null;

                if( _tipo == Tipo_modificacao_interativo_id.adicionar )
                        {  interativos_local_ref = _ponto.interativos_por_periodo_para_adicionar; } // adicionar
                        else 
                        {  interativos_local_ref = _ponto.interativos_por_periodo_para_subtrair; } // subtrair


                #if UNITY_EDITOR 
                    // --- GARANTE QUE VEIO O PEDIDO CERTO

                    switch( _tipo_alocar_interativos ){

                        case ( int ) Metodo_para_alocar_dados_periodo.unico: if( _interativos_ids.Length != 1 ){throw new Exception( $"queria mudar interativos no modo unico mas a length veio { _interativos_ids.Length }");};break;
                        case ( int ) Metodo_para_alocar_dados_periodo.dia_E_noite: if( _interativos_ids.Length != 2 ){throw new Exception( $"queria mudar interativos no modo dia_E_noite mas a length veio { _interativos_ids.Length }");}break;
                        case ( int ) Metodo_para_alocar_dados_periodo.todos_os_periodos: if( _interativos_ids.Length != 5 ){throw new Exception( $"queria mudar interativos no modo todos_os_periodos mas a length veio { _interativos_ids.Length }");}break;
                        default: throw new Exception( $" tipo para alocar interativos veio com o id { _tipo_alocar_interativos }" );

                    }

                #endif 

                // --- GARANTIR QUE OS 2 SAO IGUAAIS

                int metodo_tipo_alocar_atual = 0;

                switch( interativos_local_ref.Length ){

                        case 1 : metodo_tipo_alocar_atual = ( int ) Metodo_para_alocar_dados_periodo.unico; break;
                        case 2 : metodo_tipo_alocar_atual = ( int ) Metodo_para_alocar_dados_periodo.dia_E_noite; break;
                        case 4: throw new Exception( $"os interativos para adicionar estavao com length { interativos_local_ref.Length }." );
                        case 5 : metodo_tipo_alocar_atual = ( int ) Metodo_para_alocar_dados_periodo.todos_os_periodos; break;
                        default: throw new Exception( $"os interativos para adicionar estavao com length { interativos_local_ref.Length }." );

                }

                // --- VERIFICA SE PRECISA MUDAR
                if( metodo_tipo_alocar_atual != _tipo_alocar_interativos )
                        {
                                // --- PRECISA AUMENTAR CONVERTER ALGUM
                                // ** sempre vai aumentar porque aqui nao teria sentido diminuir.
                                // ** se os dados para adicionar sao em dia_E_noite nao teria como reduzir eles mpara "unico"
                                        
                                if( metodo_tipo_alocar_atual > _tipo_alocar_interativos )
                                        {
                                            
                                                // --- PRECISA MUDAR OS INTERATIVOS QUE VAO SER ADICIONADOS

                                                // --- MUDA PARA O TIPO CORRETO
                                                _tipo_alocar_interativos = metodo_tipo_alocar_atual;

                                                switch( _tipo_alocar_interativos ){

                                                    case ( int ) Metodo_para_alocar_dados_periodo.dia_E_noite : _interativos_ids = REAJUSTAR__aumentar_interativos_para_DIA_E_NOITE( _interativos_ids ); break;
                                                    case ( int ) Metodo_para_alocar_dados_periodo.todos_os_periodos: _interativos_ids = REAJUSTAR__aumentar_interativos_para_TODOS_OS_PERIODOS( _interativos_ids ); break;
                                                    default : throw new Exception( $"problema veio { _tipo_alocar_interativos }" );

                                                }

                                        }
                                        else 
                                        {
                                                // --- PRECISA MUDAR OS INTERATIVOS ATUAIS
                                                // ** atuais :: menor => maior
                                                switch( metodo_tipo_alocar_atual ){

                                                    case ( int ) Metodo_para_alocar_dados_periodo.unico: interativos_local_ref = REAJUSTAR__aumentar_interativos_para_DIA_E_NOITE( interativos_local_ref ); break;
                                                    case ( int ) Metodo_para_alocar_dados_periodo.dia_E_noite: interativos_local_ref = REAJUSTAR__aumentar_interativos_para_TODOS_OS_PERIODOS( interativos_local_ref ); break;
                                                    default : throw new Exception( $"problema veio { _tipo_alocar_interativos }" );

                                                }

                                        }

                                        // --- COLOCA DE NOVO NO PONTO
                                        if( _tipo == Tipo_modificacao_interativo_id.adicionar )
                                                { _ponto.interativos_por_periodo_para_adicionar = interativos_local_ref; } // --- ADICIONAR
                                                else 
                                                { _ponto.interativos_por_periodo_para_subtrair = interativos_local_ref; }  // --- SUBTRAIR
                                        

                        }

                        

                // --- RETORNA O ARRAY GARANTIDO
                return interativos_local_ref;
                

        }




        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[][] REAJUSTAR__aumentar_interativos_para_TODOS_OS_PERIODOS( byte[][] _interativos_por_periodo ){

        
                // --- REAJUSTAR
                byte[][] novo_arr = new byte[ 5 ][];

                if     ( _interativos_por_periodo.Length == 2 )
                        {
                                // --- TINHA 2 CONTAINERS DIA/NOITE

                                // --- DIA
                                byte[] elementos_DIA = _interativos_por_periodo[ 0 ];
                                
                                byte[] novo_arr_MANHA = new byte[ elementos_DIA.Length ];
                                byte[] novo_arr_DIA = new byte[ elementos_DIA.Length ];
                                byte[] novo_arr_TARDE = new byte[ elementos_DIA.Length ];

                                novo_arr[ 0 ] = novo_arr_MANHA;
                                novo_arr[ 1 ] = novo_arr_DIA;
                                novo_arr[ 2 ] = novo_arr_TARDE;

                                for( int interativo_dia_index = 0; interativo_dia_index < elementos_DIA.Length ;interativo_dia_index++  ){

                                        byte interativo_id = elementos_DIA[ interativo_dia_index ];

                                        novo_arr_MANHA[ interativo_dia_index ] = interativo_id;
                                        novo_arr_DIA[ interativo_dia_index ] = interativo_id;
                                        novo_arr_TARDE[ interativo_dia_index ] = interativo_id;

                                        continue;

                                }

            
                                // --- NOITE
                                byte[] elementos_NOITE = _interativos_por_periodo[ 1 ];
                                
                                byte[] novo_arr_NOITE = new byte[ elementos_NOITE.Length ];
                                byte[] novo_arr_MADRUGADA = new byte[ elementos_NOITE.Length ];
                                

                                novo_arr[ 3 ] = novo_arr_NOITE;
                                novo_arr[ 4 ] = novo_arr_MADRUGADA;
                                

                                for( int interativo_noite_index = 0; interativo_noite_index < elementos_NOITE.Length ;interativo_noite_index++  ){

                                        byte interativo_id = elementos_NOITE[ interativo_noite_index ];

                                        novo_arr_NOITE[ interativo_noite_index ] = interativo_id;
                                        novo_arr_MADRUGADA[ interativo_noite_index ] = interativo_id;

                                        continue;
                                        
                                }
                       


                        }
                else if( _interativos_por_periodo.Length == 1)
                        {

                                // -- TINHA SOMETE 1 CONTAINER

                                byte[] elementos =  _interativos_por_periodo[ 0 ];
                                int numero_elementos = elementos.Length;

                                byte[] novo_arr_MANHA = new byte[ numero_elementos ];
                                byte[] novo_arr_DIA = new byte[ numero_elementos ];
                                byte[] novo_arr_TARDE = new byte[ numero_elementos ];
                                byte[] novo_arr_NOITE = new byte[ numero_elementos ];
                                byte[] novo_arr_MADRUGADA = new byte[ numero_elementos ];

                                novo_arr[ 0 ] = novo_arr_MANHA;
                                novo_arr[ 1 ] = novo_arr_DIA;
                                novo_arr[ 2 ] = novo_arr_TARDE;
                                novo_arr[ 3 ] = novo_arr_NOITE;
                                novo_arr[ 4 ] = novo_arr_MADRUGADA;

                                for( int interativo_index = 0; interativo_index < numero_elementos ;interativo_index++  ){

                                        byte interativo_id = elementos[ interativo_index ];

                                        novo_arr_MANHA[ interativo_index ] = interativo_id;
                                        novo_arr_DIA[ interativo_index ] = interativo_id;
                                        novo_arr_TARDE[ interativo_index ] = interativo_id;
                                        novo_arr_NOITE[ interativo_index ] = interativo_id;
                                        novo_arr_MADRUGADA[ interativo_index ] = interativo_id;

                                        continue;

                                }

    
                        }
                else    { 
                            throw new System.Exception( $"veio com length {_interativos_por_periodo.Length}" ); 
                        }

                // --- VAI RETORNOAR O ARRAY ARRUMADO

                return novo_arr;


        } 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[][] REAJUSTAR__aumentar_interativos_para_DIA_E_NOITE( byte[][] _interativos_por_periodo ){


                #if UNITY_EDITOR

                    // --- CHECA SE ESTA NO FORMATO "UNICO"
                    if( _interativos_por_periodo.Length != 1 )
                        { throw new Exception( $"tentou reajustar os interativos para DIA_E_NOITE mas a length estava { _interativos_por_periodo.Length }" ); }

                #endif
            

                // --- SEMPRE EH UNICO
                byte[][] arr_dia_E_noite = new byte[ 2 ][];

                byte[] elementos =  _interativos_por_periodo[ 0 ];

                int numero_elementos = elementos.Length;
                
                byte[] novo_arr_NOITE = new byte[ numero_elementos ];
                byte[] novo_arr_DIA = new byte[ numero_elementos ];
                
                
                arr_dia_E_noite[ 0 ] = novo_arr_DIA;
                arr_dia_E_noite[ 1 ] = novo_arr_NOITE;


                for( int interativo_index = 0; interativo_index < numero_elementos ;interativo_index++  ){

                        byte interativo_id = elementos[ interativo_index ];

                        novo_arr_DIA[ interativo_index ] = interativo_id;
                        novo_arr_NOITE[ interativo_index ] = interativo_id;
                        
                        continue;

                }

                // --- VAI RETORNOAR O ARRAY ARRUMADO

                return arr_dia_E_noite;


        }



















        // --- REDUZIR
        


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[][] REAJUSTAR__reduzir_interativos_para_DIA_E_NOITE( Locator_position _posicao, byte[][] _interativos_por_periodo ){


                // --- SO VAI FAZER SE O ATUAL TIVER TODOS OS PERIODOS

                #if UNITY_EDITOR

                // --- VERIFICACAO GARANTIA
                // se vier nessa funcao essa verificacao deveria ser feita antes, fazer isso so tem proposito se puder fazer isso
                // mas por seguranca vai fazer de novo

                        bool pode_converter = Pode_reduzir_para_DIA_E_NOITE( _interativos_por_periodo );
                        if( !( pode_converter ) )
                            { 
                                // --- NAO PODE TROCAR
                                Ponto_DADOS_DEVELOPMENT ponto_dados = Leitor_pontos.Pegar_ponto( _posicao );
                                throw new System.Exception( $"tentou reduzir para dia_E_noite os interativos no ponto { ponto_dados.ponto_nome } mas nao deixou." ); 
                            }

                #endif
                

                byte[][] novo_arr = new byte[ 2 ][];

                // --- DIA
                byte[] elementos_DIA = _interativos_por_periodo[ 0 ]; // 0 => dia
                byte[] novo_arr_DIA = new byte[ elementos_DIA.Length ];

                // --- PASSA A REFERENCIA DIA PARA O ARRAY FINAL
                novo_arr[ 0 ] = novo_arr_DIA;
                

                for( int interativo_dia_index = 0; interativo_dia_index < elementos_DIA.Length ;interativo_dia_index++  ){

                        novo_arr_DIA[ interativo_dia_index ] = elementos_DIA[ interativo_dia_index ];
                        continue;

                }

                // --- NOITE
                byte[] elementos_NOITE = _interativos_por_periodo[ 3 ]; // 3 => noite
                byte[] novo_arr_NOITE = new byte[ elementos_NOITE.Length ];

                // --- PASSA A REFERENCIA NOITE PARA O ARRAY FINAL
                novo_arr[ 1 ] = novo_arr_NOITE;
                

                for( int interativo_noite_index = 0; interativo_noite_index < elementos_NOITE.Length ;interativo_noite_index++  ){

                        novo_arr_NOITE[ interativo_noite_index ] = elementos_NOITE[ interativo_noite_index ];
                        continue;

                }

                // --- VAI RETORNOAR O ARRAY ARRUMADO
                return novo_arr;


                throw new System.Exception( $"veio com length {_interativos_por_periodo.Length}" ); 


        }




        // --- VERIFICACOES

        
        public static bool Pode_reduzir_para_DIA_E_NOITE( byte[][] _interativos ){

                // ** ainda nao foi testado

                // SO PODE REDUZIR SE TIVER TODOS OS PERIODOS

                if( _interativos.Length != 5 )
                    { return false; }

                // GARANTE QUE JA NAO ESTA COMO DIA E NOITE

                if( _interativos.Length == 2 )
                    { return false; }


                // --- DIA

                byte[] arr_MANHA = _interativos[ 0 ];
                byte[] arr_DIA   = _interativos[ 1 ];
                byte[] arr_TARDE = _interativos[ 2 ];

                // --- CHECA SE OS ARRAYS TEM A MESMA QUANTIDADE DE ELEMENTOS
                if ( arr_MANHA.Length != arr_DIA.Length )
                    { return false; }

                if ( arr_DIA.Length != arr_TARDE.Length )
                    { return false; }



                for( int interativo_dia_index = 0 ; interativo_dia_index < arr_DIA.Length ; interativo_dia_index++ ){

                        // sempre estao crescentes

                        int interativo_dia = arr_DIA [ interativo_dia_index ] ;

                        if(  arr_MANHA[ interativo_dia_index ] != interativo_dia )
                            { return false; }

                        if(  arr_TARDE [ interativo_dia_index ] != interativo_dia )
                            { return false; }

                        continue;
                        

                }


                // --- NOITE

                byte[] arr_NOITE = _interativos[ 3 ];
                byte[] arr_MADRUGADA = _interativos[ 4 ];
                

                // --- CHECA SE OS ARRAYS TEM A MESMA QUANTIDADE DE ELEMENTOS
                if( arr_NOITE.Length != arr_MADRUGADA.Length  )
                    { return false; }



                for( int interativo_noite_index = 0 ; interativo_noite_index < arr_NOITE.Length ; interativo_noite_index++ ){

                        // sempre estao crescentes
                        if(  arr_NOITE[ interativo_noite_index ] != arr_MADRUGADA[ interativo_noite_index ]  )
                            { return false; }

                        continue;
                        

                }


                return true;

        }



        public static bool Pode_reduzir_para_UNICO( byte[][] _interativos ){

                // ** ainda nao foi testado

                // GARANTE QUE JA NAO ESTA COM 1

                if( _interativos.Length == 1  )
                        { return false; }


                // VAI CHECAR QUAL O MODO ATUAL

                if     ( _interativos.Length == 2 )
                        {

                                // --- DIA E NOITE

                                byte[] arr_DIA = _interativos[ 0 ];
                                byte[] arr_NOITE = _interativos[ 1 ];

                                // --- CHECA SE OS 2 TEM O MESMO NUMERO DE ELEMENTOS
                                if( arr_DIA.Length != arr_NOITE.Length  )
                                    {  return false;  }

                                // --- VERIFICA SE SAO IGUAIS EM TODOS OS INDEXES
                                for( int interativo_index = 0 ; interativo_index < arr_DIA.Length ; interativo_index++ ){

                                        if (  arr_DIA[ interativo_index ] != arr_NOITE[ interativo_index ]  )
                                            { return false; }
                                            
                                        continue;

                                }

                                // --- PODE REDUZIR
                                return true;


                        }
                else if( _interativos.Length == 5 )
                        {

                                // --- TODOS OS PERIODOS

                                byte[] arr_MANHA     =  _interativos[ 0 ];
                                byte[] arr_DIA       =  _interativos[ 1 ];
                                byte[] arr_TARDE     =  _interativos[ 2 ];
                                byte[] arr_NOITE     =  _interativos[ 3 ];
                                byte[] arr_MADRUGADA =  _interativos[ 4 ];

                                // --- VERIFICA SE O NUMERO DE ELEMENTOS SAO IGUAIS

                                if( arr_MANHA.Length != arr_DIA.Length )
                                    { return false; }

                                if( arr_DIA.Length != arr_TARDE.Length )
                                    { return false; }

                                if( arr_TARDE.Length != arr_NOITE.Length )
                                    { return false; }

                                if( arr_NOITE.Length != arr_MADRUGADA.Length )
                                    { return false; }



                                // --- VERIFICA SE SAO IGUAIS EM TODOS OS INDEXES
                                for( int interativo_index = 0 ; interativo_index < arr_DIA.Length ; interativo_index++ ){

                                        
                                        if(  arr_MANHA[ interativo_index ] != arr_DIA[ interativo_index ]  )
                                            { return false; }

                                        if(  arr_DIA[ interativo_index ] != arr_TARDE[ interativo_index ]  )
                                            { return false; }

                                        if(  arr_TARDE[ interativo_index ] != arr_NOITE[ interativo_index ]  )
                                            { return false; }

                                        if(  arr_NOITE[ interativo_index ] != arr_MADRUGADA[ interativo_index ]  )
                                            { return false; }
                                            
                                        continue;

                                }

                                // --- PODE REDUZIR
                                return true;



                        }
                else    { 
                            throw new Exception( $"tentou reduzir para interativos unico mas veio com length { _interativos.Length }." );
                        }
                    



        }





}