using System;

#if UNITY_EDITOR || true

    public static class Leitor_interativos_tela_DESENVOLVIMENTO {



        public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar( Posicao _posicao, int _interativo_id ){


                Regiao_nome regiao =  ( Regiao_nome ) _posicao.regiao_id;
                

                switch( regiao ){

                    case Regiao_nome.regiao_1: return Leitor_interativos__REGIAO_1.Pegar( _posicao, _interativo_id );
                    default: throw new Exception( $"nao foi achado o handler para a cidade { regiao } no Leitor_interativos_tela_DESENVOLVIMENTO" );

                }

                return null;

        }



    }

#endif