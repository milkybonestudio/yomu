


public static class Leitor_minigames__RITIMO__MUSICA {

        public static Minigame_DADOS_DEVELOPMENT Pegar_minigame( Minigame_localizador _minigame_localizador ){

                RITIMO__MUSICA__modelo modelo = ( RITIMO__MUSICA__modelo ) _minigame_localizador.modelo_id;

                switch( modelo ){

                    case RITIMO__MUSICA__modelo.violino: return Leitor_minigames__RITIMO__MUSICA__VIOLINO.Pegar_minigame( _minigame_localizador );

                }

                throw new System.Exception( $"nao foi achado o modelo { modelo }" );

        }

}