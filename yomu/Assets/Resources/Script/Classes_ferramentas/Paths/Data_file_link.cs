


using System;


// unsafe struct Data_file_link {

//     void* pointer;
//     int length;

// }


unsafe public struct Data_file_link : IEquatable<Data_file_link> {


    public Heap_key heap_key;
    public int size;

    public int id;  // ** 0 is never used by a real file, 0 -> test || always go up



    public void* Get_pointer(){

        return heap_key.Get_pointer();
        
    }

    public int Get_length(){

        return heap_key.Get_length();

    }




    public void Fill_TEST( byte _value ){

        byte* b = (byte*) Get_pointer();
        int lenght = Get_length();
        for( int k = 0 ; k < lenght ; k++ )
            { b[ k ] = _value; }

    }
    public void Guarantee_space( int _size ){

        if( _size < size  )
            { CONTROLLER__errors.Throw( $"the size in the file id { id } is <Color=lightBlue>{ size }</Color> but the data asked to guarantee is have <Color=lightBlue>{ _size }</Color>" ); }

    }

    public override int GetHashCode(){ return id; }
    public bool Equals( Data_file_link _data ){ return ( _data.id == id ); }
        
    public bool Is_valid(){ 
        
        return ( id != 0 ) && Controllers.files.storage.Is_file_already_taken( id ); 

    }

    // test
    public void Change_data( int _off_set, void* _data, int _length ){

        VOID.Transfer_data( _data, ((byte*)heap_key.Get_pointer() + _off_set ), _length );
        Controllers.stack.files.Save_data_change_data_in_file( id, _off_set, _data, _length );

    }


}
