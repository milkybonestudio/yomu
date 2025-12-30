


unsafe public static class Save_data {

    public static void Start( int _save_slot ){

        Paths_current_save.Start_save( _save_slot );

        save_file = Controllers.files.operations.Get_file_from_disk( Paths_current_save.save_data );
        save_storage = Controllers.files.operations.Get_file_from_disk( Paths_current_save.save_storage );

        Heap_key heap_key_data = Controllers.files.operations.Get_heap_key( save_file.id );
        Heap_key heap_key_storage = Controllers.files.operations.Get_heap_key( save_storage.id );

        // ** STORAGE
        storage = (Packets_storage_data*) heap_key_storage.Get_pointer();

        // ** DATA
        length = heap_key.Get_length();

        pointer = (SAVE_DATA*) heap_key.Get_pointer();
        
            modes = &(pointer->d);


    }

    public static Packets_storage_data* storage;

    public static Data_file_link save_file;
    public static Data_file_link save_storage;

    public static int length;
    public static Heap_key heap_key;

    public static SAVE_DATA* pointer;
        public static Character_desire* modes;

    public static void Change<K>( void* _pointer_in_file, K _value )where K : unmanaged{

        int off_set = INT.Sub( (long)_pointer_in_file, (long) pointer );
        Controllers.files.operations.Change_data_file<K>( save_file, off_set, &_value );

    }


}

unsafe public struct SAVE_DATA {

    public Character_desire d;
    

}
