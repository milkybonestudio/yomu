

unsafe public struct Program_data_version {

    public static Program_data_version Construct(){

        Program_data_version ret = default;

            ret.program = sizeof( Program_data );
            ret.user = sizeof( User_data );
            ret.saves_data = sizeof( Saves_data );
            ret.safety_files = sizeof( Safety_files );

        return ret;

    }

    public static bool Verify( byte[] _data ){

            fixed( byte* pointer = _data ){

                    Program_data_version* _v1 = ( Program_data_version* ) pointer;
                    Program_data_version _v2 = Construct();

                    bool value = true;

                    if( _v1->program != _v2.program )
                        { value = false; }

                    if( _v1->user != _v2.user )
                        { value = false; }

                    if( _v1->safety_files != _v2.safety_files )
                        { value = false; }
                        
                    if( _v1->saves_data != _v2.saves_data )
                        { value = false; }

                    return value;

            }


    }

    public int program;
    public int user;
    public int saves_data;
    public int safety_files;

}
