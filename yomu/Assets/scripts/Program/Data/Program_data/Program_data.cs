

unsafe public struct Save_data {
    
    public static Save_data* pointer;
    public int a;

    public static void Construct( Save_data* _pointer ){

    }

}


unsafe public struct Program_data {

    public static void Start( void* _pointer ){

        // ** se depois precisar construir mais coisas vai pegar aqui

    } 

    public static Program_data* pointer;
    public Data_manipulator edit;


    public Program_modes_data program_modes;
    public Saves_data _saves_data;
    public User_info _user_info;



    // **
    public static void Change( int* _point_to_change, int _i ){}


}

public class Q{

    public void q(){

        // Program_data.pointer->program_modes.login.global;

        //Program_data.program_modes->

    }

}

