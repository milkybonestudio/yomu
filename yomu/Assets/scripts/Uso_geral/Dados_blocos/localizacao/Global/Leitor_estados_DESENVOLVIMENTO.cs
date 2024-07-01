using System;

#if UNITY_EDITOR


        public static class Leitor_estados_DESENVOLVIMENTO {



                public static Estado_nome[] Pegar_estados_no_reino( Posicao _posicao ){



                        Reino_nome reino =  ( Reino_nome ) _posicao.reino_id;

                        switch( reino ){

                            case Reino_nome.Humans: return Pegar_estados_reino_humanos();
                            default: throw new Exception( $"nao foi achado os reinos do continente { reino } no Leitor_reinos_DESENVOLVIMENTO" );

                        }

                        return null;

                }



                public static Estado_nome[] Pegar_estados_reino_humanos(){

                        return new Estado_nome[]{

                                Estado_nome.San_sebastian


                        };
                        
                }


        }
        

#endif