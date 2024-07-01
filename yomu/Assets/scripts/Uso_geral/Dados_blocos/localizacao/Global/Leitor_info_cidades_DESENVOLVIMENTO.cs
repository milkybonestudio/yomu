using System;

#if UNITY_EDITOR || true

    public static class Leitor_info_cidades_DESENVOLVIMENTO {


        public static Info_cidade Pegar_info_cidade( Posicao _posicao ){


                Reino_nome reino =  ( Reino_nome ) _posicao.reino_id;

                switch( reino ){

                    case Reino_nome.Humans: return Leitor_Info_cidades_reino_humano_DEVELOPMENT.Pegar_info_cidade( _posicao );
                    default: throw new Exception( $"nao foi achado o handler para pegar as cidades no reino { reino } no Leitor_cidades_DESENVOLVIMENTO" );

                }


        }


    }

#endif