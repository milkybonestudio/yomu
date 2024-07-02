
#if UNITY_EDITOR

        public static class Leitor_interativos_TESTE {

                public static Interativo Pegar( int _cidade_id, int _regiao, int _area,  int _interativo_id  ){


                        Cidade_nome cidade = ( Cidade_nome ) _cidade_id;

                        switch( cidade ){

                            case Cidade_nome.san_sebastian: return null;

                        }

                        return null;
                    

                }


        }

#endif