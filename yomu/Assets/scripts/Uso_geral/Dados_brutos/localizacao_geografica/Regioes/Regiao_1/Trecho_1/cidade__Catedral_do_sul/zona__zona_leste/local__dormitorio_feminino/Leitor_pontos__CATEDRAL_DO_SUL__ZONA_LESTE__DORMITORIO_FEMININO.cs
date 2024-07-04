using System;


#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || REGIAO_1__CATEDRAL_DO_SUL || FORCAR_TUDO  )

    public static class Leitor_pontos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO {

            public static Ponto_DADOS_DEVELOPMENT Pegar_interativo( Posicao _posicao ){

                    CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area area = ( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area ) _posicao.zona_id;
                
                    switch( area ){

                        case CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area.nara_room : return CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__pontos_LISTA_DADOS.Pegar_ponto( _posicao  );
                    
                    }

                    throw new Exception( $"nao foi achado a area { area }" );   

                
            }

    }

#endif