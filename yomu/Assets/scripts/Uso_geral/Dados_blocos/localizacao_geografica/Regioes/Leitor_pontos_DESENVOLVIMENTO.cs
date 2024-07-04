using System;

#if UNITY_EDITOR || true


    public static class Leitor_pontos_DEVELOPMENT {

        public static Ponto_DADOS_DEVELOPMENT Pegar_ponto( Posicao _posicao ){

                Regiao_nome regiao =  ( Regiao_nome ) _posicao.regiao_id;
                
                switch( regiao ){

                    case Regiao_nome.regiao_1: return Leitor_pontos__REGIAO_1.Pegar( _posicao );
                    default: throw new Exception( $"nao foi achado o handler para a cidade { regiao } no Leitor_pontos_DEVELOPMENT." );

                }

                return null;

        }



    }

#endif