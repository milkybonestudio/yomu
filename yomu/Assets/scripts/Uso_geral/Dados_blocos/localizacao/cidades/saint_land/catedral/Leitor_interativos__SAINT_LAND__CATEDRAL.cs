using System;


#if UNITY_EDITOR

    public static class Leitor_interativos__SAINT_LAND__CATEDRAL {

            public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar( Posicao _posicao, int _interativo_id ){

                    SAINT_LAND__CATEDRAL__zona zona = ( SAINT_LAND__CATEDRAL__zona ) _posicao.zona_id;
                
                    switch( zona ){

                        case SAINT_LAND__CATEDRAL__zona.dormitorio_feminino : return Leitor_interativos__SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO.Pegar_interativo( _posicao , _interativo_id  );
                    
                    }

                    throw new Exception( $"nao foi achado a zona { zona }" );   

                
            }

    }

#endif