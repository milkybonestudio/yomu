

public static class Leitor_cartas__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER {


    public static Carta_DADOS_DEVELOPMENT Pegar_carta( Carta_localizador _carta_localizador ){

        CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__carta carta = ( CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__carta ) _carta_localizador.carta_id;

        switch( carta ){

            case CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__carta.nara : return CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__nara.Pegar_carta( _carta_localizador );

        }

        throw new System.Exception( $"nao foi achado a carta { carta } em Leitor_cartas__CATEDRAL_DO_SUL_PRIMEIRO_ANO." );

    }



}