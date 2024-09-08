

#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || REGIAO_1__CATEDRAL_DO_SUL || FORCAR_TUDO  )


        public static class Leitor_interativos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM {

                public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_interativo( Locator_position _posicao, int _interativo_id ){

                        CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto ponto = ( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto ) _posicao.ponto_id;
                        
                        switch( ponto ){

                                case CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto.up : return CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__interativos_UP__LISTA_DADOS.Pegar_interativo( _posicao , _interativo_id  );
                        
                        }

                        throw new System.Exception( $"nao foi achado o ponto { ponto }" );

                        
                }

        }

#endif