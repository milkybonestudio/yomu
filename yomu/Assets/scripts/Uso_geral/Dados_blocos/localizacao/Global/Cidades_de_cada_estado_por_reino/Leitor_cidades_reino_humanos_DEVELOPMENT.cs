

#if UNITY_EDITOR || true


    public static class Leitor_cidades_reino_humanos_DEVELOPMENT {


        public static Cidade_nome[] Pegar_cidades_no_estado(  Posicao _posicao ){



            Estado_nome estado_nome = ( Estado_nome ) _posicao.estado_id;

            switch( estado_nome ){


                case Estado_nome.San_sebastian : return Pegar_cidades_SAN_SEBASTIAN();
                default: throw new System.Exception( $"nao foi achado o estado { estado_nome } em Leitor_cidades_reino_humanos_DEVELOPMENT." );


            }


            

            
        }




        public static Cidade_nome[] Pegar_cidades_SAN_SEBASTIAN(){


                return new Cidade_nome[]{

                    Cidade_nome.saint_land,
                    Cidade_nome.sunnyvale,


                };
            
        }





    }


#endif