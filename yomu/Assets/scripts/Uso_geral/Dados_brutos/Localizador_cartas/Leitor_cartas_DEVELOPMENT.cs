

public static class Leitor_cartas_DEVELOPMENT {


    public static Item Pegar_item( Carta_localizador _carta_localizador ){

        CARTAS__categoria categoria = ( CARTAS__categoria ) _carta_localizador.categoria_id;

        switch( categoria ){

            case CARTAS__categoria.humano : break;

        }

        throw new System.Exception( $"nao foi achado o item { categoria }." );

    }



}