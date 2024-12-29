using System;

#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || FORCAR_TUDO )


    public static class Leitor_pontos__REGIAO_1__TRECHO_1 {

        public static Ponto_DADOS_DEVELOPMENT Pegar( Locator_position _posicao ){


            REGIAO_1__TRECHO_1__cidade_no_trecho cidade =  ( REGIAO_1__TRECHO_1__cidade_no_trecho ) _posicao.global_position.cidade_no_trecho_id;
            

            switch( cidade ){

                case REGIAO_1__TRECHO_1__cidade_no_trecho.catedral_do_sul: return Leitor_pontos__REGIAO_1__TRECHO_1__CATEDRAL_DO_SUL.Pegar( _posicao );
                default: throw new Exception( $"nao foi achado o handler para o trecho { cidade } no Leitor_interativos__REGIAO_1" );

            }

            return null;

        }



    }

#endif