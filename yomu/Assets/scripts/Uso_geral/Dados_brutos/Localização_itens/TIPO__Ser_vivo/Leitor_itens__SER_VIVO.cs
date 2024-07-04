




public static class Leitor_itens__SER_VIVO {

    public static Item Pegar_item( Item_localizador _item_localizador){

            SER_VIVO__categoria categoria = ( SER_VIVO__categoria ) _item_localizador.categoria_id;

            switch( categoria ){
                case SER_VIVO__categoria.mob: return Leitor_itens__ITEM_NOMEADO__ITEM_POSSUIDO__ARMA_PRIMORDIAL.Pegar_item( _item_localizador );
            }

            throw new System.Exception( $"nao foi achado a categoria { categoria }" );



    }

}