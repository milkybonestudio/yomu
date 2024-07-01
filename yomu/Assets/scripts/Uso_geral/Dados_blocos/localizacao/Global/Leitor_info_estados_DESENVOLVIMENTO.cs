using System;

#if UNITY_EDITOR || true


        public static class Leitor_info_estados_DESENVOLVIMENTO {



                public static Info_estado Pegar_info_estado( Posicao _posicao ){



                        Reino_nome reino =  ( Reino_nome ) _posicao.reino_id;

                        switch( reino ){

                            case Reino_nome.Humans: return Leitor_info_estados_reino_humano_DEVELOPMENT.Pegar_info_estado( _posicao );
                            default: throw new Exception( $"nao foi achado os reinos do continente { reino } no Leitor_reinos_DESENVOLVIMENTO" );

                        }

                        return null;

                }


        }
        

#endif