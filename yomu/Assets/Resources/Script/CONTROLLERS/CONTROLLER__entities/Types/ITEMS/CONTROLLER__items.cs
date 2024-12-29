



public unsafe class CONTROLLER__items {


        public static CONTROLLER__items instance;
        public static CONTROLLER__items Get_instance(){ return instance; }


        public CONTAINER__entities<Item> container_items;
        public OPERATIONS__items operations_items;

        // ** LOAD 
        // ** somente build
        public void Prepare_item( int _item_id ){}


        // ** GET 

        public Item Get_item( int _item_id ){ return container_items.Get( _item_id ); }
        public Item[] Get_items( int[] _item_id ){ return container_items.Get_entities( _item_id ); }

        // ** ACTION

        public Item_allocation_result Add() { return Item_allocation_result.failed_not_enogh_space; }


    
}

public abstract class CONTAINER__characters {

    

}


public enum Item_allocation_result {

    pass, 
    failed_not_enogh_space,

}


public unsafe struct Itens_container {

        public int number_slots;
        public fixed int slots[ 50 ];

}
