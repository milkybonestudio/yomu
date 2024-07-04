


public static class Leitor_minigames__RITIMO {

    public static Minigame_DADOS_DEVELOPMENT Pegar_minigame( Minigame_localizador _minigame_localizador ){

        RITIMO__trabalho trabalho = ( RITIMO__trabalho ) _minigame_localizador.trabalho_id;

        switch( trabalho ){

            case RITIMO__trabalho.musica: return Leitor_minigames__RITIMO__MUSICA.Pegar_minigame( _minigame_localizador );

        }

        throw new System.Exception( $"nao foi achado o trabalho { trabalho }" );


    }

}