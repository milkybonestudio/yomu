



unsafe public static class Program_data{

    public static void Start(){

        Data_file_link _program_file = Controllers.files.operations.Get_file( Paths_program.program_data );

        program_file = _program_file;
        heap_key = Controllers.files.operations.Get_heap_key( _program_file.id );

        length = heap_key.Get_length();

        PROGRAM_DATA* root = (PROGRAM_DATA*) heap_key.Get_pointer();
        
            modes = &(root->program_modes);


    }


    public static Data_file_link program_file;
    public static int length;
    public static Heap_key heap_key;

    public static PROGRAM_DATA* root;
        public static Program_modes_data* modes;



    public static void Change<K>( void* _pointer_in_file, K _value )where K : unmanaged{

        int off_set = INT.Sub( (long)_pointer_in_file, (long) root );
        Controllers.files.operations.Change_data_file<K>( program_file, off_set, &_value );

    }
}



unsafe public struct PROGRAM_DATA {

    public static void Start( void* _pointer ){

        Program_data.Change( &Program_data.modes->new_game.type, New_game_type.standart );


    } 

    public Program_modes_data program_modes;
    public Saves_data _saves_data;
    public User_info _user_info;

}



