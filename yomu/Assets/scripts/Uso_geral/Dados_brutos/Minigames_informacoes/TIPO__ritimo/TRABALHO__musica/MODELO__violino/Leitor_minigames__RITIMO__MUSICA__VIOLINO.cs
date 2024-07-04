


#if UNITY_EDITOR && (  MINIGAMES_TIPO__RITIMO || MINIGAMES_TRABALHO__MUSICA ||  MUSICA_MODELO__VIOLINO  || FORCAR_TODOS_OS_MINIGAMES  ) || true


        public static class Leitor_minigames__RITIMO__MUSICA__VIOLINO {

                public static Minigame_DADOS_DEVELOPMENT Pegar_minigame( Minigame_localizador _minigame_localizador ){

                        RITIMO__MUSICA__VIOLINO__nome nome = ( RITIMO__MUSICA__VIOLINO__nome ) _minigame_localizador.minigame_id;

                        switch( nome ){

                                case RITIMO__MUSICA__VIOLINO__nome.treinamento_catedral_1: return RITIMO__MUSICA__VIOLINO__TREINAMENTO_CATEDRAL_1.Pegar_minigame();

                        }

                        throw new System.Exception( $"nao foi acho o nome { nome }." );
                        

                }

        }


#endif


