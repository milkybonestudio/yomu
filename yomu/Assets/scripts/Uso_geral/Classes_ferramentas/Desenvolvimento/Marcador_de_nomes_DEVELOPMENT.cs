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
                        interativo_dados.enum_nome_interativo_DESENVOLVIMENTO = _nome_area; //"CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP";

                        continue;

                }


                return;

    
        }

}