using System;

#if UNITY_EDITOR 

    public static class Leitor_cidades_DESENVOLVIMENTO {



        public static Cidade_nome[] Pegar_cidades_no_estado( Posicao _posicao ){


                Reino_nome reino =  ( Reino_nome ) _posicao.reino_id;

                switch( reino ){

                    case Reino_nome.Humans: return Leitor_cidades_reino_humanos_DEVELOPMENT.Pegar_cidades_SAN_SEBASTIAN();
                    default: throw new Exception( $"nao foi achado o handler para pegar as cidades no reino { reino } no Leitor_cidades_DESENVOLVIMENTO" );

                }


        }


    }

#endif