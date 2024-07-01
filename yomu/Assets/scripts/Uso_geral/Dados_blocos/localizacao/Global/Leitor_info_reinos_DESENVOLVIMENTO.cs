
#if UNITY_EDITOR || true


        public static class Leitor_info_reinos_DESENVOLVIMENTO {



                public static Info_reino Pegar_info_reino( Posicao _posicao ){


                        Reino_nome reino =  ( Reino_nome ) _posicao.reino_id;

                        switch( reino ){

                            case Reino_nome.Humans: return Pegar_info_HUMANOS();
                            default: throw new System.Exception( $"nao foi achado as infos do reino { reino } no Leitor_info_reinos_DESENVOLVIMENTO" );

                        }

                }



                public static Info_reino Pegar_info_HUMANOS(){

                        Info_reino info_reino = new Info_reino();


                        return info_reino;

                }


        }
        

#endif