


#if UNITY_EDITOR && (  MINIGAMES_TIPO__RITIMO || MINIGAMES_TRABALHO__MUSICA ||  MUSICA_MODELO__VIOLINO  || FORCAR_TODOS_OS_MINIGAMES  ) || true


        public static class Leitor_minigames__RITIMO__MUSICA__VIOLINO {

                public static Minigame_DADOS_DEVELOPMENT Pegar_minigame( Minigame_localizador _minigame_localizador ){

                        int minigame_id =  _minigame_localizador.minigame_id;

                        RITIMO__MUSICA__VIOLINO__nome nome = ( RITIMO__MUSICA__VIOLINO__nome ) minigame_id ;

                        _minigame_localizador.nome_minigame = Marcador_de_nomes_DEVELOPMENT.Pegar_nome_minigame_localizador( typeof( RITIMO__MUSICA__VIOLINO__nome ), minigame_id);

                        switch( nome ){

                                case RITIMO__MUSICA__VIOLINO__nome.treinamento_catedral_1: return RITIMO__MUSICA__VIOLINO__TREINAMENTO_CATEDRAL_1.Pegar_minigame();

                        }

                        

                        return null;

                }

        }


#endif


