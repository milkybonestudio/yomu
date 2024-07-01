
#if UNITY_EDITOR || true


        public static class Leitor_info_continentes_DEVELOPMENT {



                public static Info_continente Pegar_info_continente( Posicao _posicao ){


                        Continente_nome continente =  ( Continente_nome ) _posicao.continente_id;

                        switch( continente ){

                            case Continente_nome.central: return Pegar_info_CENTRAL();
                            default: throw new System.Exception( $"nao foi achado as infos do continente { continente } no Leitor_info_continentes_DEVELOPMENT" );

                        }

                }



                public static Info_continente Pegar_info_CENTRAL(){

                        Info_continente info_continente = new Info_continente();


                        return info_continente;

                }


        }
        

#endif