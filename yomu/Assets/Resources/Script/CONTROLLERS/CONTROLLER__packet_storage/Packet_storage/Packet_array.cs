

unsafe public struct Packet_array<T> where T: unmanaged {

    public static Packet_array<T> Construct( Packet_key _key, Packets_storage _storage, int _start_point_in_file, void* _pointer_0  ){


        int _type_size = sizeof( T );
        int length_array = ( _key.length / _type_size );

        if( System_run.max_security )
            {
                if( !!! ( _storage.Is_valid() ) )
                    { CONTROLLER__errors.Throw( "packet_storage not valid" ); }

                if( ( _key.length % _type_size ) != 0 )
                    { CONTROLLER__errors.Throw( $"The length of the key {{ <Color=lightBlue>{ _key.length }</Color> }} and the type size {{ <Color=lightBlue>{ _type_size }</Color> }}. The rest of the division is <Color=lightBlue>{ ( _key.length % _type_size ) }</Color> and should be 0" ); }
            }

        Packet_array<T> ret = default;

            ret.key = _key;
            ret.storage = _storage;
            ret.start_point_in_file = _start_point_in_file;
            ret.pointer_0 = _pointer_0;
            ret.type_size = _type_size;
            ret.length = length_array;

        return ret;

    }

    public Packet_key key;
    // public Data_file_link file_link;
    public int start_point_in_file;

    public Packets_storage storage;

    public void* pointer_0;
    public int type_size;
    public int length;


    // ** activate
    public int current_index;
    private Packet_change_type current_type;


    public T Get_value( int _index ){

        if( System_run.max_security && sizeof( T ) > 1_000 )
            { CONTROLLER__errors.Throw( $"Tried to get a value with size { sizeof( T ) }" ); }

        return *(T*)Get_pointer( _index );

    }


    // ** PARTIAL


        public T* Get_element_parcial( int _index ){

            Check_data_to_get_pointer( _index );

                current_index = _index;
                current_type = Packet_change_type.partial;

            return (T*) Get_pointer( _index );

        }


        public void Add<K>( void* _adress_to_change, K _value_to_add ) where K:unmanaged {

            if( System_run.max_security )
                {
                    if( current_type != Packet_change_type.partial )
                        { CONTROLLER__errors.Throw( $"Tried to change a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ current_type }</Color>" ); }

                    int size = sizeof( K );
                    if(  (size != 1) && (size != 2) && (size != 4) && (size != 8) )
                        { CONTROLLER__errors.Throw( $"Tried to Add a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ size }</Color>" ); }  

                }



            int _off_set = INT.Sub( (long)_adress_to_change, (long) pointer_0  ) ;
            Check_off_set( _off_set, current_index, sizeof( K ) );

            K* data_pointer_file = ((K*)( (byte*)pointer_0 + _off_set ));
            K new_value = default;

            unchecked{
                switch( sizeof( K ) ){
                    case 1: byte v_byte = (byte)( (*(byte*)data_pointer_file) + (*(byte*)&_value_to_add) ); new_value = *(K*)&v_byte; break;
                    case 2: short v_short = (short)( (*(short*)data_pointer_file) + (*(short*)&_value_to_add) ); new_value = *(K*)&v_short ; break;
                    case 4: int v_int = (int)( (*(int*)data_pointer_file) + (*(int*)&_value_to_add) ); new_value = *(K*)&v_int ; break;
                    case 8: long v_long = (long)( (*(long*)data_pointer_file) + (*(long*)&_value_to_add) ); new_value = *(K*)&v_long ; break;
                }
            }

            int point_to_change_in_file = ( start_point_in_file + _off_set );

            Controllers.files.operations.Change_data_file<K>( storage.data, point_to_change_in_file, new_value );

            return;       

        }
        public void Change<K>( void* _adress_to_change, K _value ) where K:unmanaged {

            if( System_run.max_security )
                {
                    if( current_type != Packet_change_type.partial )
                        { CONTROLLER__errors.Throw( $"Tried to change a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ current_type }</Color>" ); }

                    if( sizeof( K ) > ( 16 * 10 ) )
                        { CONTROLLER__errors.Throw( $"Tried to change a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ sizeof( T ) }</Color>" ); }  
                }

            int _off_set = INT.Sub( (long)_adress_to_change, (long) pointer_0  ) ;
            Check_off_set( _off_set, current_index, sizeof( K ) );

            int point_to_change_in_file = ( start_point_in_file + _off_set );
            

            Controllers.files.operations.Change_data_file<K>( storage.data, point_to_change_in_file, _value );

            return;       

        }


        private void Check_off_set( int _off_set, int _element, int _type_change_type ){

            if( System_run.max_security )
                {

                    // ** make sense in array perspective
                    if( _off_set < 0 )
                        { CONTROLLER__errors.Throw( $"in the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color> can not hndle off set <Color=lightBlue>{ _off_set }</Color>" ); }

                    if(  key.length < ( _off_set + _type_change_type ) )
                        { CONTROLLER__errors.Throw( $"in the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color> can not hndle off set <Color=lightBlue>{ _off_set }</Color>" ); }

                    // ** make sense in element perspective

                    int start_point_element = ( _element * type_size );
                    int end_point_element = ( ( _element + 1 ) * type_size - 1 ); // valid byte
                    
                    if( BOOL.Not_in_range( start_point_element, _off_set, end_point_element ) )
                        { 
                            CONTROLLER__errors.Throw( 
                                $"in the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color> Tried to verfy an off_set in the elemente { _element } " + 
                                $"but it need to be in the range of { end_point_element } : {start_point_element} but the off set is <Color=lightBlue>{ _off_set }</Color>"
                            ); 
                        }

                }

            return;

        }



    // ** COMPLETE


        public T* Get_element_complete( int _index ){

            Check_data_to_get_pointer( _index );

                current_index = _index;
                current_type = Packet_change_type.complete;

            return (T*) Get_pointer( _index );

            
        }

        public void Finish_use(){

            if( System_run.max_security )
                {
                    if( current_type != Packet_change_type.complete )
                        { CONTROLLER__errors.Throw( $"Call finish_use() but the type is <Color=lightBlue>{ current_type }</Color>" ); }
                }

            current_type = Packet_change_type.not_give;

            // ** sinalize change
            Controllers.stack.files.Save_data_change_data_in_file(
                _file_id              : storage.data.id,
                _file_point_to_change : ( Get_off_set_index( current_index ) + start_point_in_file ),
                _data_pointer         : Get_pointer( current_index ),
                _length               : type_size
            );

            return;

        }

    // ** OVERWRITE

        // ** element
            public void Overwrite<T>( T _value, int _element ) where T : unmanaged {

                
                // if( System_run.packet_storage_show_messages )
                //     { Change_SHOW( 0, _value.ToString().ToUpper(), sizeof( T ) ); }

                // if( System_run.max_security )
                //     {
                //         if( type != Packet_change_type.not_give )
                //             { CONTROLLER__errors.Throw( $"Tried to overwrite with a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ type }</Color>" ); }

                //         if( sizeof( T ) > ( 16 * 10 ) )
                //             { CONTROLLER__errors.Throw( $"Tried to overwrite with a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ sizeof( T ) }</Color>" ); }  

                //         if( sizeof( T ) != key.length )
                //             { CONTROLLER__errors.Throw( $"Tried to overwrite with a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ sizeof( T ) }</Color>" ); }  

                //     }


                // Controllers.files.operations.Change_data_file<T>( storage.data, off_set_to_data_in_file, _value );

                return;

            }    


        // ** all

        // ??






    private void* Get_pointer( int _index ){

        return (((byte*) pointer_0 ) + ( _index * type_size ));

    }


    private int Get_off_set_index( int _index ){

        return ( _index * type_size );

    }



    private void Check_data_to_get_pointer( int _index ){

        if( System_run.max_security )
            {

                if( ( _index >= length ) || ( _index < 0 ) )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the max indes is <Color=lightBlue>{ length }</Color>" ); }

                if( pointer_0 == null )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the pointer to the data is <Color=lightBlue>NULL</Color>" ); }

                if( length == 0 )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the length of the array is <Color=lightBlue>0</Color>" ); }

                if( type_size == 0 )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the type_size of the array is <Color=lightBlue>0</Color>" ); }

                if( current_type == Packet_change_type.complete )
                    { CONTROLLER__errors.Throw( $"Tried to get the index <Color=lightBlue>{ _index }</Color> but the type is complete, so was not finish" ); }

            }

    }




}