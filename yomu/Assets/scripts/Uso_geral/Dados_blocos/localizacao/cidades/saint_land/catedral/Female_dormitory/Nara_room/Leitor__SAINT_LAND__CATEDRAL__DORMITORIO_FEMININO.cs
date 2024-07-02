

#if ( UNITY_EDITOR && CIDADE_SAN_SEBASTIAN ) || FORCAR_TODOS_OS_ESTADOS 

    public static class Leitor_interativos__SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__NARA_ROOM {

            public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_interativo( Posicao _posicao, int _interativo_id ){

                    SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__NARA_ROOM__ponto ponto = ( SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__NARA_ROOM__ponto ) _posicao.ponto_id;
                
                    switch( ponto ){

                        case SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__NARA_ROOM__ponto.up : return SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__NARA_ROOM__interativos_UP__LISTA_DADOS.Pegar_interativo( _posicao , _interativo_id  );
                    
                    }

                    throw new System.Exception( $"nao foi achado o ponto { ponto }" );   

                
            }

    }

#endif