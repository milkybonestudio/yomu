


public static class Leitor_minigames__RITIMO {

    public static Minigame_DADOS_DEVELOPMENT Pegar_minigame( Minigame_localizador _minigame_localizador ){

        RITIMO__trabalho trabalho = ( RITIMO__trabalho ) _minigame_localizador.trabalho_id;

        Minigame_DADOS_DEVELOPMENT minigame_dados = null;
        

        switch( trabalho ){

            case RITIMO__trabalho.musica: minigame_dados =  Leitor_minigames__RITIMO__MUSICA.Pegar_minigame( _minigame_localizador ); break;

        }

        if( minigame_dados == null )
            { throw new System.Exception(  $"nao foi achado o minigame: { _minigame_localizador.nome_minigame }" ); }

            return minigame_dados;

    }

}