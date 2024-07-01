using System;


#if ( UNITY_EDITOR && CIDADE_SAINT_LAND ) || FORCAR_TODOS_OS_ESTADOS 

    public static class Leitor_interativos__SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO {

            public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_interativo( Posicao _posicao, int _interativo_id ){

                    SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO_area area = ( SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO_area ) _posicao.zona_id;
                
                    switch( area ){

                        case SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO_area.nara_room : return Leitor_interativos__SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__NARA_ROOM.Pegar_interativo( _posicao , _interativo_id  );
                    
                    }

                    throw new Exception( $"nao foi achado a area { area }" );   

                
            }

    }

#endif