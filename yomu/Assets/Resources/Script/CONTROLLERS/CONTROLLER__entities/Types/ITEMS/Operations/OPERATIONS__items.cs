

public unsafe class OPERATIONS__items {

        public OPERATIONS__items( CONTROLLER__items _controller, OPERATIONS__items_SAVING _saving, OPERATIONS__items_VERIFICATIONS _verifications ){

            controller = _controller;
            saving_block = _saving;
            verifications_block = _verifications;

        }

        private OPERATIONS__items_SAVING saving_block;
        private OPERATIONS__items_VERIFICATIONS verifications_block;
        private CONTROLLER__items controller;

        public Item_allocation_result Add( Item _item, int _quantity, ref Itens_container _itens_container ){

                saving_block.Save_add();
                verifications_block.Verify_add();
            
                for( int slot = 0; slot < _itens_container.number_slots; slot++  ){

                        if( _itens_container.slots[ slot ] != ( int ) Item_type.not_give )
                            { continue; } 

                        _itens_container.slots[ slot ] = _item.id;
                        return Item_allocation_result.pass;

                }

                return Item_allocation_result.failed_not_enogh_space;

        }
        public void Remove(){}
        public void Transfer(){}


}








