


public static class List_items {


        public static void Construct(){

                // --- CONSTRUCT ITEMS

                Construct_NAMED();


        }

        private static void Construct_NAMED(){

                new Hokushi();

        }

        public static Item Get( int _item_id ){

                if( items[ _item_id ] == null )
                    { CONTROLLER__errors.Throw( $"Do not constructed the item with id { _item_id }" ); }

                return items[ _item_id ];

        }

        
        public static Item[] items = new Item[ ( int ) Item_type.END ];


}
