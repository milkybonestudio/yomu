


unsafe public struct Data_file_link {

    // ** for testing / reconstruct
    public static Data_file_link Construct_fast( void* _data_pointer, int _id, int _length ){

        return new Data_file_link(){

            heap_key = Heap_key.Construct_fast(
                _pointer: _data_pointer,
                _length: _length
            ),
            id = _id,
            situation = Data_file_link.Situation.clean,
            size = _length
        };
    }

    //mark
    // ** dont make sense being here
    // ** is a struct
    public enum Situation {
        
        clean, // ** not in sistem
        used,
        bin,
    }

    public Heap_key heap_key;
    public int size;

    // ** 0 is never used by a real file, 0 -> test
    public int id; // ** always go up
    public Situation situation;


    public void Guarantee_space( int _size ){

        if( _size < size  )
            { CONTROLLER__errors.Throw( $"the size in the file id { id } is <Color=lightBlue>{ size }</Color> but the data asked to guarantee is have <Color=lightBlue>{ _size }</Color>" ); }

    }

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


}
