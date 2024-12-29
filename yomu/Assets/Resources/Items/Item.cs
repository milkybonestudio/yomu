


public unsafe struct Item_general_data {


        public int base_value;
        public Item_rarity rarity;
        public Item_main_functionality main_functionality;

        public fixed int attributes[ 4 ]; // ** depende da funcao. combate pode ser 


}

public abstract class Item {

    public int id;
    public string path_data; 
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
        protected void DEVELOPMENT( string _name_enum ){

            DEVELOPMENT__items.items_enums_names[ id ] = _name_enum;

        }
    #endif

    protected void Verify(){}


}




// ** 
public unsafe struct Item_locator {

    // ** item id 
    public fixed byte item_key[ 50 ];
    

}



public unsafe static class Item_locator_transformer {


    public static char[] class_name = new char[ 30 ];


    public static Item_locator Get( string _class_name ){

            Item_locator item_locator = new Item_locator();
            
            Item_locator* pointer_locator = &item_locator;

            fixed( char* string_pointer = _class_name ){

                    byte* item_locator_pointer = pointer_locator->item_key;
                    byte* string_pointer_byte = ( byte* ) string_pointer;
                    

                    for( int index = 0 ; index < _class_name.Length ; index++ ){

                        *item_locator_pointer++ = *string_pointer_byte;
                        string_pointer_byte +=2;

                    }


            }

            return item_locator;

    }

    public static string Get_string( ref Item_locator _s ){

        for( int i = 0 ; i < class_name.Length ; i++ )
            { class_name[ i ] = '\0'; }

        fixed( Item_locator* S_p = &( _s ) ){


                char* char_pointer = ( char* ) S_p->item_key;
                char* char_pointer_2 = ( char* ) S_p->item_key;
                char_pointer_2[ 2 ] = 'g' ;
            
                for( int k = 0 ; k < class_name.Length ; k++ )
                    { class_name[ k ] = *char_pointer++;  }

        }

        for( int o = 0 ; o < 60 ; o++ )
            { UnityEngine.Debug.Log(_s.item_key[ o ]); }


        return new string( class_name );

        

    }

}


public static class DEVELOPMENT_bools {


        public const bool item_nomeados = false;


}







