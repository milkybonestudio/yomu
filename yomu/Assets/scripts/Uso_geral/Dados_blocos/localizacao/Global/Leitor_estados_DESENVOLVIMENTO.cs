using System;

#if UNITY_EDITOR || true 


        public static class Leitor_estados_DESENVOLVIMENTO {



                public static Estado_nome[] Pegar( Posicao _posicao ){



                        Cidade_nome


                        Reino_nome reino =  ( Reino_nome ) _posicao.reino_id;

                        switch( reino ){

                            case Reino_nome.Humans: return Pegar_cidades_reino_humanos();
                            default: throw new Exception( $"nao foi achado os reinos do continente { reino } no Leitor_reinos_DESENVOLVIMENTO" );

                        }

                        return null;

                }



                public static Estado_nome[] Pegar_cidades_reino_humanos(){

                        Estado_nome[] cidades = new Estado_nome[]{

                                Estado_nome.saint_land,


                        };

                        return cidades;

                }


        }
        

#endif