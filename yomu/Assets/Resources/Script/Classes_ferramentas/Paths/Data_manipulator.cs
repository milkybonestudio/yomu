

unsafe public struct Data_manipulator_partial{

    public void Start_partial_file(  void* _pointer_full_file, void* _pointer_partial_data_specific, int _size, int _slot ){

        if( had_start )
            { CONTROLLER__errors.Throw( $"Tried to start the data again" ); }
        had_start = true;

        pointer_full_data = _pointer_full_file;
        pointer_partial_data = _pointer_partial_data_specific;
        size = _size;
        slot = _slot;
        gap_from_full_to_partial = ( ( long ) _pointer_partial_data_specific - ( long ) _pointer_full_file );

    }

    private int size;
    private bool had_start;
    private int slot;
    private void* pointer_full_data;
    private long gap_from_full_to_partial;
    private void* pointer_partial_data;

}

unsafe public struct Data_manipulator {


    public void Start( void* _ptr, int _size, int _slot ){

        if( had_start )
            { CONTROLLER__errors.Throw( $"Tried to start the data again" ); }
        had_start = true;

        pointer_full_data = _ptr;
        size = size;
        slot = slot;

    }



    // --- DEFAULT

    private int size;
    private bool had_start;
    private int slot;
    private void* pointer_full_data;
    private long gap_from_full_to_partial;
    private void* pointer_partial_data;
    

    // --- FULL FILE



    // --- PARCIAL FILE


    public void Change( void* _pointer, int _value ){

        *(int*) _pointer  = _value;
        Controllers.stack.Save_data( _pointer, sizeof( int ) );        
        Controllers.stack.files.Save_data_change_data_in_file( slot, ( int )( ( long )pointer_full_data - ( long )_pointer ),  _pointer, _value );

    }

    public void Change( void* _pointer, byte _value ){

        Controllers.stack.Save_data( _pointer, _value );
        *(byte*) _pointer  = _value;

    }



}
