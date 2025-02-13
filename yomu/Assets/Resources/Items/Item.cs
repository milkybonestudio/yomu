


public unsafe struct Item_general_data {


        public int base_value;
        public Item_rarity rarity;
        public Item_main_functionality main_functionality;

        public fixed int attributes[ 4 ]; // ** depende da funcao. combate pode ser 


}


public abstract class Item {


        public Item(){ Add_list(); }

        public int id;
        public string type_name; 
        public string name;

        public Item_general_data data;


        public RESOURCE__image_ref small_image;
        public RESOURCE__image_ref medium_image;
        public RESOURCE__image_ref large_image;

        

        public int maximum_agroup_number;
        public Item_rarity rarity;


        // public virtual void Get_card( Card _card ){ throw new System.Exception(); }
        // public virtual void Get_trade_object( Card _card ){ throw new System.Exception(); }


        #if UNITY_EDITOR
            protected void Add_list(){ List_items.items[ id ] = this; }
        #else
            protected void Add_list(){}
        #endif


        protected void Verify(){}


}








