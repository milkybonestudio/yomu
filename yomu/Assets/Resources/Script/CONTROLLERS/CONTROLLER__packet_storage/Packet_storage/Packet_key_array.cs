


// ** IS NOT TO SAVE JUST TO USE
unsafe public struct Packet_array_pointer {

    public static Packet_array_pointer Construct( Data_file_link _file_link, int _start_point_in_file, void* _pointer_0, int _type_size, int _length ){

        Packet_array_pointer ret = default;

            ret.file_link = _file_link;
            ret.start_point_in_file = _start_point_in_file;
            ret.pointer_0 = _pointer_0;
            ret.type_size = _type_size;
            ret.length = _length;

        return ret;

    }

    public Data_file_link file_link;
    public int start_point_in_file;

    public void* pointer_0;
    public int type_size;
    public int length;
    
    public void* Get( int _index ){

        if( System_run.max_security )
            {

                if( _index >= length )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the max indes is <Color=lightBlue>{ length }</Color>" ); }

                if( _index < 0 )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color>" ); }

                if( pointer_0 == null )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the pointer to the data is <Color=lightBlue>NULL</Color>" ); }

                if( length == 0 )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the length of the array is <Color=lightBlue>0</Color>" ); }

                if( type_size == 0 )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the type_size of the array is <Color=lightBlue>0</Color>" ); }

            }



        return (void*)(((byte*) pointer_0 ) + ( _index * type_size ));

    }


    public void Change_data_full_type( void* _pointer ){


        Controllers.stack.files.Save_data_change_data_in_file( 
            _file_id              : file_link.id,
            _file_point_to_change : start_point_in_file,
            _data_pointer         : _pointer,
            _length               : type_size
        );


    }

}