using System;


#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || REGIAO_1__CATEDRAL_DO_SUL || FORCAR_TODAS_AS_REGIOES  )

    public static class Leitor_interativos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO {

            public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_interativo( Posicao _posicao, int _interativo_id ){

                    CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area area = ( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area ) _posicao.zona_id;
                
                    switch( area ){

                        case CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area.nara_room : return Leitor_interativos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO.Pegar_interativo( _posicao , _interativo_id  );
                    
                    }

                    throw new Exception( $"nao foi achado a area { area }" );   

                
            }

    }

#endif