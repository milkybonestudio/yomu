

public static class Leitor_cartas__CATEDRAL_DO_SUL_PRIMEIRO_ANO {


    public static Carta_DADOS_DEVELOPMENT Pegar_carta( Carta_localizador _carta_localizador ){

        CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__genero genero = ( CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__genero ) _carta_localizador.genero_id;

        switch( genero ){

            case CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__genero.mulher : return Leitor_cartas__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER.Pegar_carta( _carta_localizador );

        }

        throw new System.Exception( $"nao foi achado o genero { genero } em Leitor_cartas__CATEDRAL_DO_SUL_PRIMEIRO_ANO." );

    }



}