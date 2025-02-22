


public unsafe struct PROGRAM_DATA__menu {



    public PROGRAM_DATA__menu* pointer;

    // --- CREATION
    // ** need on creation
    public Menu_type type;



    // --- SAVES

    public const int number_saves = 7;
    public Save_menu save_1;
    public Save_menu save_2;
    public Save_menu save_3;
    public Save_menu save_4;
    public Save_menu save_5;
    public Save_menu save_6;
    public Save_menu save_7;


    // ** depende da regiao 

        // --- SOUTH CATHEDRAL




    public static void Construct( PROGRAM_DATA__menu* _data ){
        
        _data->type = Menu_type.south_cathedral;

    }


}




unsafe public struct Image_galery {

    

    // ** cada lugar ( tipos menu ) vai ter uma galeria diferente

    //  100 imgs * 100chars -> 10kb



}




