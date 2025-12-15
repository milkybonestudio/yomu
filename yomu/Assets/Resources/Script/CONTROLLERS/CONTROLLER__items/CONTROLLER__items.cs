



public unsafe class CONTROLLER__items {

        // ** LOAD 
        // ** somente build
        public void Prepare_item( int _item_id ){}


        // ** GET 

        public Item Get_item( int _item_id ){ return null; }
        public Item[] Get_items( int[] _item_id ){ return null; }

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
