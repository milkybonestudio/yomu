using System;



public static class Marcador_de_nomes_DEVELOPMENT {

        public static void Colocar_nome_interativo_tela( Type _tipo_interativo ,  string _nome_area, Interativo_tela_DADOS_DESENVOLVIMENTO[] _dados  ){


                string[] nomes = Enum.GetNames( _tipo_interativo );
                    
                        
                for( int interativo_dados_teste_index = 0 ; interativo_dados_teste_index< _dados.Length ; interativo_dados_teste_index++ ){

                        Interativo_tela_DADOS_DESENVOLVIMENTO interativo_dados = _dados[ interativo_dados_teste_index ];

                        if( interativo_dados == null )
                            { continue; }

                        // interativo_dados_teste_index => enum_id => se chegar aqui esta sendo usado => existe

                        string nome_insterativo_DESENVOLVIMENTO =  nomes[ interativo_dados_teste_index ];
                        
                        interativo_dados.nome_insterativo_DESENVOLVIMENTO = nome_insterativo_DESENVOLVIMENTO;
                        interativo_dados.enum_nome_interativo_DESENVOLVIMENTO = _nome_area; // "CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP";

                        continue;

                }


                return;

    
        }


        public static void Colocar_nome_itens( Type _tipo_item , Item_DADOS_DEVELOPMENT[] _dados  ){


                string[] nomes = Enum.GetNames( _tipo_item );
                string enum_nome = _tipo_item.Namespace;
                    
                        
                for( int item_dados_teste_index = 0 ; item_dados_teste_index< _dados.Length ; item_dados_teste_index++ ){

                        Item_DADOS_DEVELOPMENT carta_dados = _dados[ item_dados_teste_index ];

                        if( carta_dados == null )
                            { continue; }

                        // carta_dados_teste_index => enum_id => se chegar aqui esta sendo usado => existe

                        string nome_insterativo_DESENVOLVIMENTO =  nomes[ item_dados_teste_index ];
                        
                        carta_dados.nome_item_enum_DEVELOPMENT = nome_insterativo_DESENVOLVIMENTO;
                        carta_dados.enum_nome_item_DEVELOPMENT = enum_nome; //"CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP";
                        

                        continue;

                }


                return;

    
        }


        public static void Colocar_nome_cartas( Type _tipo_carta , Carta_DADOS_DEVELOPMENT[] _dados  ){


                string[] nomes = Enum.GetNames( _tipo_carta );
                string enum_nome = _tipo_carta.Namespace;
                    
                        
                for( int carta_dados_teste_index = 0 ; carta_dados_teste_index< _dados.Length ; carta_dados_teste_index++ ){

                        Carta_DADOS_DEVELOPMENT carta_dados = _dados[ carta_dados_teste_index ];

                        if( carta_dados == null )
                            { continue; }

                        // carta_dados_teste_index => enum_id => se chegar aqui esta sendo usado => existe

                        string nome_insterativo_DESENVOLVIMENTO =  nomes[ carta_dados_teste_index ];
                        
                        carta_dados.nome_carta_DESENVOLVIMENTO = nome_insterativo_DESENVOLVIMENTO;
                        carta_dados.enum_nome_carta_DESENVOLVIMENTO = enum_nome; // para pegar o folder
                        carta_dados.nome_class_com_a_funcao = ( carta_dados.nome_carta_DESENVOLVIMENTO + "_funcao" ) ;

                        continue;

                }


                return;

    
        }

        public static string Pegar_nome_minigame_localizador( Type _tipo, int _minigame_id ){

                return _tipo.Namespace + "__" + Enum.GetNames( _tipo )[ _minigame_id ];

        }








}