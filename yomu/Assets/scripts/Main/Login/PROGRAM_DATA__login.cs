

public unsafe struct PROGRAM_DATA__login {

    // ** always on top
    // ** need to be flip when put data, the transition will put it down after use the data
    public Lock_program_data lock_data;

    public Login_type type;

    public fixed char image_path[ 100 ];
    public const int image_path_limit = 100;

    public static void Construct( PROGRAM_DATA__login* _data ){}


}

