

#if UNITY_EDITOR

    public class Leitor_itens {


        public Item_DADOS_DEVELOPMENT Pegar_item( Item_localizador _item_localizador ){

            ITEM__tipo_item tipo_item = ( ITEM__tipo_item ) _item_localizador.tipo_id;

            switch( tipo_item ){

                case ITEM__tipo_item.consumivel : break;
                case ITEM__tipo_item.duravel : break;
                case ITEM__tipo_item.arma : break;
                case ITEM__tipo_item.material : break;
                case ITEM__tipo_item.ser_vivo : break;
                case ITEM__tipo_item.item_nomeado : return Leitor_itens__ITEM_NOMEADO.Pegar_item( _item_localizador );
                case ITEM__tipo_item.item_missao : break;

            }

            throw new System.Exception( $"nao foi achado o item { tipo_item }." );

        }



    }

#else 

    public class Leitor_itens {

        public byte[][][][] dados_itens ;

        public Item Pegar_item( Item_localizador _item_localizador ){

                return null;
          

        }



    }




#endif