


using System;


// unsafe struct Data_file_link {

//     void* pointer;
//     int length;

// }


unsafe public struct Data_file_link : IEquatable<Data_file_link> {

    public static Data_file_link Construct( int _id ){ return new Data_file_link(){ id = _id };  }
    
    public int id;  // ** 0 is never used by a real file, 0 -> test || always go up


    public void* Get_pointer(){

        return Get_heap_key().Get_pointer();
    }

    public int Get_length(){

        return Get_heap_key().Get_length();
    }

    public Heap_key_type Get_heap_key_type(){

        return Get_heap_key().type;
    }

    
    public Heap_key Get_heap_key(){

        return Controllers.files.operations.Get_heap_key( id );
    }



    public void Fill_TEST( byte _value ){

        byte* b = (byte*) Get_pointer();
        int lenght = Get_length();
        for( int k = 0 ; k < lenght ; k++ )
            { b[ k ] = _value; }

    }
    public void Guarantee_space( int _size ){

        if( _size < Get_length()  )
            { CONTROLLER__errors.Throw( $"the size in the file id { id } is <Color=lightBlue>{ Get_length() }</Color> but the data asked to guarantee is have <Color=lightBlue>{ _size }</Color>" ); }

    }

    public override int GetHashCode(){ return id; }
    public bool Equals( Data_file_link _data ){ return ( _data.id == id ); }
        
    public bool Is_valid(){ 
        
        return ( id != 0 ) && Controllers.files.storage.Is_file_already_taken( id ); 

    }

    // test
    public void Change_data( int _off_set, void* _data, int _length ){

        VOID.Transfer_data( _data, ((byte*)Controllers.files.operations.Get_heap_key( id ).Get_pointer() + _off_set ), _length );
        Controllers.stack.files.Save_data_change_data_in_file( id, _off_set, _data, _length );

    }


}
