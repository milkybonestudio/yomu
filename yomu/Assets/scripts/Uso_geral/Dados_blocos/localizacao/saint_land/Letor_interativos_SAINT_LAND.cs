using System;


#if UNITY_EDITOR

    public static class Leitor_interativos__SAINT_LAND {

            public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar( Posicao_local _posicao_local, int _interativo_id ){

                    SAINT_LAND__regiao regiao = ( SAINT_LAND__regiao ) _posicao_local.regiao_id;
                    

                    switch( regiao ){

                            case SAINT_LAND__regiao.cathedral : return Leitor_interativos__SAINT_LAND__CATEDRAL.Pegar( _posicao_local, _interativo_id );
                            case SAINT_LAND__regiao.village: return Letor_interativos__SAINT_LAND__VILA.Pegar( _posicao_local, _interativo_id );

                    }

                    throw  new Exception( $"Nao foi achado a regiao { regiao } em SAINT LAND." );

                
            }

    }

#endif