

unsafe public struct Program_brute_data {

    public static void Construct( Program_brute_data* _data ){

            // ** nao pode depender de nenhum input do usuario

            
            Program_data.Construct( &( _data->program ) );
            User_data.Construct( &( _data->user ) );
            Saves_data.Construct( &( _data->saves_data ) );
            Safety_files.Construct( &( _data->safety_files ) );
    }

    public Program_data program;
    public User_data user;
    public Saves_data saves_data;
    public Safety_files safety_files;

}