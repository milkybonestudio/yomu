
unsafe public struct Buffer_dll{

        public int buffer_length;
        public int reasson_failed_length;
        public byte get_data;
        public fixed char reasson_failed[ 200 ];
        public fixed byte buffer[ 1_000 ];


    
}

unsafe public static class TOOLS__buffer_dll{

        public static void Verify_buffer( Buffer_dll* _buffer ){

                if( _buffer->get_data == 0 )
                    { 
                        CONTROLLER__errors.Get_instance().Check_pointer_length  (
                                                                                    _check: INT.Guarantee_range( _buffer->reasson_failed_length, 0, 200 ),
                                                                                    _message: $"the max length of reasson to fail was 200 but the dll uses { _buffer->reasson_failed_length }"
                                                                                );

                        CONTROLLER__errors.Get_instance().Check_dll_data    (
                                                                                _check: INT.Guarantee_range( _buffer->reasson_failed_length, 0, 200 ),
                                                                                _message: STRING.Get_string( _buffer->reasson_failed, _buffer->reasson_failed_length )
                                                                            );

                    }

        }


}
