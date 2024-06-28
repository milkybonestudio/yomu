using System;


#if UNITY_EDITOR

    public static class Leitor_interativos__SAINT_LAND {

            public static Interativo_tela Pegar( Posicao_local _posicao_local, int _interativo_id ){

                    SAINT_LAND__regiao regiao = ( SAINT_LAND__regiao ) _posicao_local.regiao_id;
                    

                    switch( regiao ){

                            case SAINT_LAND__regiao.cathedral : return Leitor_interativos__SAINT_LAND__CATEDRAL.Pegar( _posicao_local, _interativo_id );
                            case SAINT_LAND__regiao.village: return Letor_interativos__SAINT_LAND__VILA.Pegar( _posicao_local, _interativo_id );


                            //                                     {
                            //                                         SAINT_LAND__villege__area  area = ( SAINT_LAND__villege__area ) _area_id;

                            //                                         switch( area ){

                            //                                             case SAINT_LAND__villege__area.center : return SAINT_LAND__CATEDRAL__FEMALE_DORMITORY_interativos_lista.Pegar_interativo(  _posicao_local, _interativo_id ); // ??????
                                                                    
                            //                                         }

                            //                                         throw new Exception( $"nao foi achado a regiao { regiao }" );
                            //                                     }

                        

                    }

                    throw  new Exception( $"Nao foi achado a regiao { regiao } em SAINT LAND." );

                
            }

    }

#endif