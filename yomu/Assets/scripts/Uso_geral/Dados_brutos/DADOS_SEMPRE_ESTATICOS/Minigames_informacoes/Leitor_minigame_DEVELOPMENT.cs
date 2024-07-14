



public static class Leitor_minigames_DEVELOPMENT {


        public static Minigame_DADOS_DEVELOPMENT Pegar_minigame( Minigame_localizador _minigame_localizador ){

                Tipo_minigame  tipo_minigame = ( Tipo_minigame ) _minigame_localizador.tipo_id;

                switch( tipo_minigame ){

                    case Tipo_minigame.ritimo : return Leitor_minigames__RITIMO.Pegar_minigame( _minigame_localizador );

                }

                throw new System.Exception( "" );

        }


}