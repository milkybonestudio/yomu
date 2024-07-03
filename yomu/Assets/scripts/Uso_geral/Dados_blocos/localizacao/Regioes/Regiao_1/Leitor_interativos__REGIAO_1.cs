using System;

#if UNITY_EDITOR || true



    public static class Leitor_interativos__REGIAO_1 {

        public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar( Posicao _posicao, int _interativo_id ){


            REGIAO_1__trecho trecho =  ( REGIAO_1__trecho ) _posicao.trecho_id;
            

            switch( trecho ){

                case REGIAO_1__trecho.trecho_1: return Leitor_interativos__REGIAO_1__TRECHO_1.Pegar( _posicao, _interativo_id );
                default: throw new Exception( $"nao foi achado o handler para o trecho { trecho } no Leitor_interativos__REGIAO_1" );

            }

            return null;

        }



    }

#endif