using System;


#if UNITY_EDITOR

    public static class Letor_interativos_SAINT_LAND_ {

        public static Interativo Pegar( int _regiao_id ,  int _area_id , int _interativo_id ){

            SAINT_LAND__regiao regiao = ( SAINT_LAND__regiao ) _regiao_id;
            

            switch( regiao ){

                case SAINT_LAND__regiao.cathedral : 
                                                    {
                                                            SAINT_LAND__CATEDRAL__area  area = ( SAINT_LAND__CATEDRAL__area ) _area_id;

                                                            switch( area ){

                                                                case SAINT_LAND__CATEDRAL__area.dormitorio_feminino : return SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO_interativos_lista.Pegar_interativo( _interativo_id );
                                                            
                                                            }

                                                            throw new Exception( $"nao foi achado a regiao { regiao }" );
                                                    }


                
                case SAINT_LAND__regiao.village: 
                                                    {
                                                            SAINT_LAND__villege__area  area = ( SAINT_LAND__villege__area ) _area_id;

                                                            switch( area ){

                                                                case SAINT_LAND__villege__area.center : return SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO_interativos_lista.Pegar_interativo( _interativo_id );
                                                            
                                                            }

                                                            throw new Exception( $"nao foi achado a regiao { regiao }" );
                                                    }
                

            }

            return null;

            
        }

    }

#endif