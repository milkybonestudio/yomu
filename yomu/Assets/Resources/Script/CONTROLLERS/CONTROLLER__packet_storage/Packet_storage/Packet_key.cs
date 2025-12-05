

using System.Runtime.CompilerServices;



unsafe public struct Packet_key {


    public static Packet_key Construct( Packet_storage_size _size, int _slot, int _length ){

        Packet_key ret = default;

            ret.length = _length;
            ret.slot = _slot;
            ret.size = _size;

            ret.is_valid = true;

        return ret;

    }

    // ** only for when is used, dealloc dont need
    public int length;
    public Packet_storage_size size;
    public int slot;
        public bool is_valid;

    public bool Have_data(){

        bool size_is_ok = ( size > Packet_storage_size._0_bytes );
        bool length_is_ok = length > 0;

        if( System_run.packet_show_messages )
            {

                if( !!!(is_valid) ) 
                    { Console.Log( "is_valid: " + is_valid ); }

                if( !!!(size_is_ok) )
                    { Console.Log( "size_is_ok: " + (size > Packet_storage_size._0_bytes) ); }

                if( !!!( length_is_ok ) )
                    { Console.Log( "length_is_ok: " + (length > 0) ); }
                
            }

        return is_valid && size_is_ok && length_is_ok;

    }


    public string Get_text_of_situation(){

        return $"is_valid:  {{ <Color=lightBlue>{ is_valid }</Color> }}, size:  {{ <Color=lightBlue>{ size }</Color> }}, slot:  {{ <Color=lightBlue>{ slot }</Color> }}, length:  {{ <Color=lightBlue>{ length }</Color> }}";

    }

    public string Get_text_of_identification(){

        return $"{{<Color=lightBlue>{ size }</Color>:<Color=lightBlue>{ slot }</Color>}}";

    }


}
