

public static class Leitor_itens_DEVELOPMENT {


    public static Item Pegar_item( Item_localizador _item_localizador ){

        Tipo_item tipo_item = ( Tipo_item ) _item_localizador.tipo_id;

        switch( tipo_item ){

            case Tipo_item.consumivel : break;
            case Tipo_item.duravel : break;
            case Tipo_item.arma : break;
            case Tipo_item.material : break;
            case Tipo_item.ser_vivo : break;
            case Tipo_item.item_nomeado : return Leitor_itens__ITEM_NOMEADO.Pegar_item( _item_localizador );
            case Tipo_item.item_missao : break;

        }

        throw new System.Exception( $"nao foi achado o item { tipo_item }." );

    }



}