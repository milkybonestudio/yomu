




public static class Leitor_itens__ITEM_NOMEADO {

    public static Item_DADOS_DEVELOPMENT Pegar_item( Item_localizador _item_localizador){

            ITEM_NOMEADO__categoria categoria = ( ITEM_NOMEADO__categoria ) _item_localizador.categoria_id;

            switch( categoria ){
                case ITEM_NOMEADO__categoria.item_possuido: return Leitor_itens__ITEM_NOMEADO__ITEM_POSSUIDO.Pegar_item( _item_localizador );
            }

            // talvez depois fazer algo que seja possivel deixar certos Itens_localizador em um classe especial de teste. Eles poderiam sempre ter a primeira chave como -1 ou algo 

            throw new System.Exception( $"nao foi achado a categoria { categoria }" );


    }

    
}