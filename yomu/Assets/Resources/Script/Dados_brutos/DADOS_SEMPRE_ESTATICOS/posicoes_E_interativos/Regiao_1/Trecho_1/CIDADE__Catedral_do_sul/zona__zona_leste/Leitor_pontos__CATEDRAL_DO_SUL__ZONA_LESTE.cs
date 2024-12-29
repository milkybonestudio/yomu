using System;

                      
#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || REGIAO_1__CATEDRAL_DO_SUL || FORCAR_TUDO  )

    public static class Leitor_pontos__CATEDRAL_DO_SUL__ZONA_LESTE {

            public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar( Locator_position _posicao, int _interativo_id ){

                    CATEDRAL_DO_SUL__zona zona = ( CATEDRAL_DO_SUL__zona ) _posicao.local_position.zona_id;
                
                    switch( zona ){

                        case CATEDRAL_DO_SUL__zona.zona_leste : return Leitor_interativos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO.Pegar_interativo( _posicao , _interativo_id  );
                    
                    }

                    throw new Exception( $"nao foi achado o local { zona }" );   

                
            }

    }

#endif