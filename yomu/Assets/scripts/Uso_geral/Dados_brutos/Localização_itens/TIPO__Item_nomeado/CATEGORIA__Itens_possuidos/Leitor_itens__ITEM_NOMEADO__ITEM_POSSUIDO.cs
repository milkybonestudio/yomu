


public static class Leitor_itens__ITEM_NOMEADO__ITEM_POSSUIDO {

    public static Item_DADOS_DEVELOPMENT Pegar_item( Item_localizador _item_localizador){

            ITEM_NOMEADO__ITEM_POSSUIDO__modelo modelo = ( ITEM_NOMEADO__ITEM_POSSUIDO__modelo ) _item_localizador.modelo_id;

            switch( modelo ){
                case ITEM_NOMEADO__ITEM_POSSUIDO__modelo.armas_primordiais: return Leitor_itens__ITEM_NOMEADO__ITEM_POSSUIDO__ARMA_PRIMORDIAL.Pegar_item( _item_localizador );
            }

            throw new System.Exception( $"nao foi achado modelo { modelo }" );



    }

}