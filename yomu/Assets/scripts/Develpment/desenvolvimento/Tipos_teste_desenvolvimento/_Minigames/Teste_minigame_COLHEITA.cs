


public static class Teste_minigame_colheita {

    public static void Ativar( string _chave ){

        switch( _chave ){

                case "generico": Minigame_colheita_estado_generico.Ativar(); return;
                default : throw new System.Exception( $"<b><coler=red>nao</color></b> foi achado a <b><color=white>chave: \"{ _chave }\"</color></b> em testar o minigame:<b><color=lime>COLHEITA</color></b>");

        }

    }

}