using System;

#if UNITY_EDITOR || true 


        public static class Leitor_reinos_DESENVOLVIMENTO {



                public static Reino_nome[] Pegar( Posicao _posicao ){


                        Continente_nome continente =  ( Continente_nome ) _posicao.continente_id;

                        switch( continente ){

                            case Continente_nome.central: return Pegar_reinos_continente_central();
                            default: throw new Exception( $"nao foi achado os reinos do continente { continente } no Leitor_reinos_DESENVOLVIMENTO" );

                        }

                        return null;

                }



                public static Reino_nome[] Pegar_reinos_continente_central(){

                        Reino_nome[] reinos = new Reino_nome[]{

                                Reino_nome.Humans


                        };

                        return reinos;

                }


        }
        

#endif