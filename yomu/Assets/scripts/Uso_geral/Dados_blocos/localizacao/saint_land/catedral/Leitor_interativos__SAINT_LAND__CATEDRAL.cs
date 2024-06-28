using System;


#if UNITY_EDITOR

    public static class Leitor_interativos__SAINT_LAND__CATEDRAL {

            public static Interativo_tela Pegar( Posicao_local _posicao_local, int _interativo_id ){

                    SAINT_LAND__CATEDRAL__area area = ( SAINT_LAND__CATEDRAL__area ) _posicao_local.area_id;
                
                    switch( area ){

                        case SAINT_LAND__CATEDRAL__area.dormitorio_feminino : return SAINT_LAND__CATEDRAL__FEMALE_DORMITORY_interativos_lista.Pegar_interativo( _posicao_local , _interativo_id  );
                    
                    }

                    throw new Exception( $"nao foi achado a area { area }" );   

                
            }

    }

#endif