using System;

#if UNITY_EDITOR || true 

    public static class Leitor_cidades_DESENVOLVIMENTO {



        public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_cidades_no_estado( Posicao _posicao, int _interativo_id ){


                Estado_nome estado =  ( Estado_nome ) _posicao.estado_id;

                switch( estado ){

                    case Estado_nome.San_sebastian: return Leitor_interativos__SAINT_LAND.Pegar( _posicao, _interativo_id );
                    default: throw new Exception( $"nao foi achado o handler para a cidade { estado } no Leitor_interativos_tela_DESENVOLVIMENTO" );

                }

                return null;

        }


        public static Cidade_nome[] Pegar_cidades_SAN_SEBASTIAN(){


                return new Cidade_nome[]{

                    Cidade_nome.saint_land


                };
            
        }



    }

#endif