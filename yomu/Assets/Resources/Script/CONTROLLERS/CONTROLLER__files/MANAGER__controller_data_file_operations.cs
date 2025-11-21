

unsafe public struct MANAGER__controller_data_file_operations {

    
    public void Change_length_file(  ref Data_file_link _data_link, int _new_length ){

        if( Controllers.files.is_reconstructing_stack )
            { return; }

        Heap_key heap_key = Controllers.heap.Change_length_key( _data_link.heap_key, _new_length );
        _data_link.heap_key = heap_key;

        Controllers.files.current_files[ _data_link.id ] = _data_link;

        Controllers.stack.files.Save_data_change_length_file( _data_link.id, _new_length );
        
        return ;

    }


}