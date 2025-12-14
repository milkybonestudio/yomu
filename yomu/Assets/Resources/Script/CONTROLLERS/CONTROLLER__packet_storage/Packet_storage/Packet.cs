


// ** usada para fazer operacoes
unsafe public struct Packet {

    public static Packet Create( Packet_key _key, Packets_storage _packet_storage, void* _pointer_to_data, int _off_set_to_data_in_file ){

        Packet  ret = default;

            ret.key = _key;
            ret.storage = _packet_storage;
            ret.pointer = (byte*)_pointer_to_data;
            ret.off_set_to_data_in_file  = _off_set_to_data_in_file;

        return ret;
        
    }


    public Packet_key key;
    public Packets_storage storage;


    // ** points to start of the data
    private byte* pointer;

    private int off_set_to_data_in_file;

    private Packet_change_type type;


    // --- SMALL CHANGES

        public T* Get_pointer_partial<T>()where T : unmanaged{

            Safety();
            if( System_run.max_security )
                { 
                    if( type != Packet_change_type.not_give )
                        { CONTROLLER__errors.Throw( $"Already get the pointer to the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color>" );  }
                    if( sizeof( T ) != key.length )
                        { CONTROLLER__errors.Throw( $"The type { typeof(T).Name } <Color=lightBlue> have { sizeof( T ) } bytes, but the key jave { key.length } in the key { key.Get_text_of_identification() }</Color>" );  }
                }

            type = Packet_change_type.partial;

            return (T*)pointer;

        }

        // NORMAL TYPE 

        public void Change<T>( void* _address_variable, T _value ) where T : unmanaged {

            Safety();
            long _off_set =( (long)_address_variable - (long) pointer );
            Check_off_set( _off_set );

            if( System_run.packet_storage_show_messages )
                { Change_SHOW( _off_set, _value.ToString().ToUpper(), sizeof( T ) ); }

            if( System_run.max_security )
                {
                    if( type != Packet_change_type.partial )
                        { CONTROLLER__errors.Throw( $"Tried to change a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ type }</Color>" ); }

                    if( sizeof( T ) > ( 16 * 10 ) )
                        { CONTROLLER__errors.Throw( $"Tried to change a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ sizeof( T ) }</Color>" ); }  
                }


            int point_to_change_in_file = INT.Add( off_set_to_data_in_file, _off_set );            
            Controllers.files.operations.Change_data_file<T>( storage.data, point_to_change_in_file, _value );

            return;

        }


        
        public void Change( void* _address_variable, void* _pointer_to_data, int _length ){

            Safety();
            long _off_set =( (long)_address_variable - (long)pointer );

            if( System_run.packet_storage_show_messages )
                { Change_SHOW( _off_set, "NOT FIX", _length ); }


            if( System_run.max_security )
                {
                    if( type != Packet_change_type.partial )
                        { CONTROLLER__errors.Throw( $"Tried to change a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ type }</Color>" ); }

                    if( _pointer_to_data == null )
                        { CONTROLLER__errors.Throw( $"in the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color> the _pointer_to_data is <Color=lightBlue>NULL</Color>" ); }

                    if( _length < 0 )
                        { CONTROLLER__errors.Throw( $"in the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color> the _length is <Color=lightBlue>0</Color>" ); }
                }

            if( _length == 0 )
                { if( System_run.packet_storage_show_messages ) { Console.Log( $"Came in the packet { key.Get_text_of_identification() } and the length is 0, will jump" ); } return; } // ** JUMP


            if( System_run.packet_storage_show_messages )
                { Console.Log( $"Came in the packet { key.Get_text_of_identification() } and will <Color=lightBlue>transfer the data</Color>" ); }

            int point_to_change_in_file = INT.Add( off_set_to_data_in_file, _off_set );

            Controllers.files.operations.Change_data_file( storage.data, point_to_change_in_file, _pointer_to_data, _length );

            if( System_run.packet_storage_show_messages )
                { Console.Log( $"---finish---" ); }

            return;
            
        }

        public void Add<T>( void* _address_variable, T _value_to_add ) where T : unmanaged {

            Safety();
            long _off_set =( (long)_address_variable - (long) pointer );
            Check_off_set( _off_set );

            if( System_run.packet_storage_show_messages )
                { Change_SHOW( _off_set, _value_to_add.ToString().ToUpper(), sizeof( T ) ); }

            if( System_run.max_security )
                {
                    if( type != Packet_change_type.partial )
                        { CONTROLLER__errors.Throw( $"Tried to change a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ type }</Color>" ); }
                    int size = sizeof( T );
                    if(  (size != 1) && (size != 2) && (size != 4) && (size != 8) )
                        { CONTROLLER__errors.Throw( $"Tried to Add a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ sizeof( T ) }</Color>" ); }  
                }

            T* data_pointer_file = ((T*)( pointer + _off_set ));
            T new_value = default;

            unchecked{
                switch( sizeof( T ) ){
                    case 1: byte v_byte = (byte)( (*(byte*)data_pointer_file) + (*(byte*)&_value_to_add) ); new_value = *(T*)&v_byte; break;
                    case 2: short v_short = (short)( (*(short*)data_pointer_file) + (*(short*)&_value_to_add) ); new_value = *(T*)&v_short ; break;
                    case 4: int v_int = (int)( (*(int*)data_pointer_file) + (*(int*)&_value_to_add) ); new_value = *(T*)&v_int ; break;
                    case 8: long v_long = (long)( (*(long*)data_pointer_file) + (*(long*)&_value_to_add) ); new_value = *(T*)&v_long ; break;
                }
            }
            
            int point_to_change_in_file = INT.Add( off_set_to_data_in_file, _off_set );
            Controllers.files.operations.Change_data_file<T>( storage.data, point_to_change_in_file, new_value );
            
            return; 

        }






        private void Check_off_set( long _off_set ){

            if( System_run.max_security )
                {
                    if( _off_set < 0 || _off_set > key.length )
                        { CONTROLLER__errors.Throw( $"in the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color> can not hndle off set <Color=lightBlue>{ _off_set }</Color>" ); }
                }

        }

        private void Change_SHOW( long _off_set, string _type_name, int _type_size ){

            Console.Log( $"---Came in CHANGE in a packet with type <Color=lightBlue>{ _type_name }</Color>---" );
            Console.Log( $"---key: { key.Get_text_of_identification() }---" );
            Console.Log( $"-----off_set: { (long)_off_set }---" );
            Console.Log( $"-----length: { _type_size }---" );

        }




    // --- BIG CHANGES


    public T* Get_pointer_complete<T>() where T:unmanaged{

        Safety();
        if( System_run.max_security && type != Packet_change_type.not_give )
            { CONTROLLER__errors.Throw( $"Already get the pointer to the packet <Color=lightBlue>{ key.Get_text_of_identification() }</Color>" ); }

        type = Packet_change_type.complete;

        return ((T*) pointer);


    }



    public bool did_already_save_change;
    public void Finish_use(){

        // ** the data should be change before with the pointer
        // ** now will save the whole data
        // ** if the data is too big can be better change only the necessary wit partial

        
        Safety();

        if( System_run.packet_show_messages )
            { Console.Log( $"came finish { key.Get_text_of_identification() }" ); }

        if( System_run.max_security )
            {
                if( type != Packet_change_type.complete )
                    { CONTROLLER__errors.Throw( $"Tried to save change in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ type }</Color>" ); }

                if( did_already_save_change )
                    { CONTROLLER__errors.Throw( $"Tried to save change in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but it was already saved" ); }
                
                did_already_save_change = true;

                if( System_run.packet_show_messages && key.size > Packet_storage_size._300_bytes )
                    { Console.Log( $"The key { key.Get_text_of_identification() } CAN be too big for a <Color=lightBlue>complete change packet</Color>. it will save the whole data in the stack" ); }

            }

        // storage.Sinalize_change( key );

        Controllers.stack.files.Save_data_change_data_in_file(
            _file_id              : storage.data.id,
            _file_point_to_change : off_set_to_data_in_file,
            _data_pointer         : pointer,
            _length               : key.length
        );

    }


    // ** OVERWRITE

        public void Overwrite<T>( T _value ) where T : unmanaged {

            Safety();

            if( System_run.packet_storage_show_messages )
                { Change_SHOW( 0, _value.ToString().ToUpper(), sizeof( T ) ); }

            if( System_run.max_security )
                {
                    if( type != Packet_change_type.not_give )
                        { CONTROLLER__errors.Throw( $"Tried to overwrite with a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the type is <Color=lightBlue>{ type }</Color>" ); }

                    if( sizeof( T ) > ( 16 * 10 ) )
                        { CONTROLLER__errors.Throw( $"Tried to overwrite with a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ sizeof( T ) }</Color>" ); }  

                    if( sizeof( T ) != key.length )
                        { CONTROLLER__errors.Throw( $"Tried to overwrite with a value in the key <Color=lightBlue>{ key.Get_text_of_identification() }</Color> but the generic <T> have a size <Color=lightBlue>{ sizeof( T ) }</Color>" ); }  

                }


            Controllers.files.operations.Change_data_file<T>( storage.data, off_set_to_data_in_file, _value );

            return;

        }    



    // --- SUPORT 

    private void Safety(){

        if( System_run.max_security )
            {
                if( !!!( key.Have_data() ) )
                    { CONTROLLER__errors.Throw( "Packet_key have <Color=lightBlue>NO DATA</Color>" ); }

                if( !!!( storage.Is_valid() ) )
                    { CONTROLLER__errors.Throw( "storage pointer is <Color=lightBlue>NULL</Color>" ); }

                if( pointer == null  )
                    { CONTROLLER__errors.Throw( "pointer to data is <Color=lightBlue>NULL</Color>" ); }
            }

        return;

    }

}

