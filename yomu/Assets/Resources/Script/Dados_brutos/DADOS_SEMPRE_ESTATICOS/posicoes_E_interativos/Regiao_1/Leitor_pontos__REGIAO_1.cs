using System;

#if UNITY_EDITOR || true



    public static class Leitor_pontos__REGIAO_1 {

        public static Ponto_DADOS_DEVELOPMENT Pegar( Locator_position _posicao ){


            REGIAO_1__trecho trecho =  ( REGIAO_1__trecho ) _posicao.global_position.trecho_id;
            

            switch( trecho ){

                case REGIAO_1__trecho.trecho_1: return Leitor_pontos__REGIAO_1__TRECHO_1.Pegar( _posicao );
                
            }

            throw new Exception( $"nao foi achado o handler para o trecho { trecho } no Leitor_interativos__REGIAO_1" );

        }



    }

#endif