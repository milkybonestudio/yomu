using System;

                      
#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || REGIAO_1__CATEDRAL_DO_SUL || FORCAR_TUDO  )


        public static class Leitor_pontos__REGIAO_1__TRECHO_1__CATEDRAL_DO_SUL  {

                public static Ponto_DADOS_DEVELOPMENT Pegar( Locator_position _posicao ){

                        CATEDRAL_DO_SUL__zona zona = ( CATEDRAL_DO_SUL__zona ) _posicao.zona_id;
                    
                        switch( zona ){

                            case CATEDRAL_DO_SUL__zona.zona_leste : return Leitor_pontos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO.Pegar_interativo( _posicao  );
                        
                        }

                        throw new Exception( $"nao foi achado o local { zona }" );   

                    
                }

        }

#endif