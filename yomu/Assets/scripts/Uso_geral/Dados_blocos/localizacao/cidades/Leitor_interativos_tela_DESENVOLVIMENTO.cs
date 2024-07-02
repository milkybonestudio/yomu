using System;

#if UNITY_EDITOR 

    public static class Leitor_interativos_tela_DESENVOLVIMENTO {



        public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar( Posicao _posicao, int _interativo_id ){


            Cidade_nome cidade =  ( Cidade_nome ) _posicao.cidade_id;

            switch( cidade ){

                case Cidade_nome.san_sebastian: return Leitor_interativos__SAN_SEBASTIAN.Pegar( _posicao, _interativo_id );
                default: throw new Exception( $"nao foi achado o handler para a cidade { cidade } no Leitor_interativos_tela_DESENVOLVIMENTO" );

            }

            return null;

        }



    }

#endif