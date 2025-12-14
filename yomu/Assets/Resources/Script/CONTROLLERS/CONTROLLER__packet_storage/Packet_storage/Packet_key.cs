

using System.Runtime.CompilerServices;



unsafe public struct Packet_key {


    public static Packet_key Construct( Data_file_link _storage_data_file, Packet_storage_size _size, int _slot, int _length ){

        Packet_key ret = default;

            ret.length = _length;
            ret.slot = _slot;
            ret.size = _size;
            ret.storage_data_file = _storage_data_file;

        return ret;

    }

    
    public int length;
    public Packet_storage_size size;
    public int slot;
    public Data_file_link storage_data_file;


    // ** overwrite

    public void Overwrite<T>( T _value )where T:unmanaged{

        Get_packet().Overwrite<T>( _value );

    }

    public void Overwrite_packet_array<T>( int _index, T _value )where T:unmanaged{

        Packets_storage.Construct( storage_data_file ).Get_packet_array<T>( this ).Overwrite( _index, _value );
    }


    // ** get packets

    public Packet Get_packet(){

        return Packets_storage.Construct( storage_data_file ).Get_packet( this );
    }

    public Packet_array<T> Get_packet_array<T>()where T:unmanaged{

        return Packets_storage.Construct( storage_data_file ).Get_packet_array<T>( this );
    }

    // ** values

    public T Get_value<T>() where T: unmanaged { 

        return Packets_storage.Construct( storage_data_file ).Get_value<T>( this ); 
    }

    public T Get_value_array<T>( int _index ) where T: unmanaged { 

        return Packets_storage.Construct( storage_data_file ).Get_value_array<T>( this, _index ); 
    }





    public bool Is_valid(){
        return storage_data_file.Is_valid();
    }

    public bool Have_data(){

        bool size_is_ok = ( size > Packet_storage_size._0_bytes );
        bool length_is_ok = length > 0;

        if( System_run.packet_show_messages )
            {

                if( !!!( Is_valid() ) ) 
                    { Console.Log( "is_valid: " + false ); }

                if( !!!(size_is_ok) )
                    { Console.Log( "size_is_ok: " + (size > Packet_storage_size._0_bytes) ); }

                if( !!!( length_is_ok ) )
                    { Console.Log( "length_is_ok: " + (length > 0) ); }
                
            }

        return Is_valid() && size_is_ok && length_is_ok;

    }


    public string Get_text_of_situation(){

        return $"is_valid:  {{ <Color=lightBlue>{ Is_valid() }</Color> }}, size:  {{ <Color=lightBlue>{ size }</Color> }}, slot:  {{ <Color=lightBlue>{ slot }</Color> }}, length:  {{ <Color=lightBlue>{ length }</Color> }}";

    }

    public string Get_text_of_identification(){

        return $"{{<Color=lightBlue>{ size }</Color>:<Color=lightBlue>{ slot }</Color>}}";

    }


}
