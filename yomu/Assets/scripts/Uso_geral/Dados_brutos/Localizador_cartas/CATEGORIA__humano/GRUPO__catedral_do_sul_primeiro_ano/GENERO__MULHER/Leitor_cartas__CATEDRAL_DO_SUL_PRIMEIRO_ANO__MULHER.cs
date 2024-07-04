



public static class Leitor_cartas__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER {


        public static Carta_DADOS_DEVELOPMENT Pegar_carta( Carta_localizador _carta_localizador ){

            CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__entidade entidade = ( CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__entidade ) _carta_localizador.entidade_id;

            switch( entidade ){

                    case CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__entidade.nara : return CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__nara.Pegar_carta( _carta_localizador );

            }

            throw new System.Exception( $"nao foi achado a entidade { entidade } em Leitor_cartas__CATEDRAL_DO_SUL_PRIMEIRO_ANO." );

        }



}