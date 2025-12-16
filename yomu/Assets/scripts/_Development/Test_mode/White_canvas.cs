
unsafe public static class White_canvas{


    public class Mode_class {

        public void Create(){

        }

        public Data_file_link data;
        public Mode_class_data data_2;

    }

    public struct Mode_class_data{

        public int a;

        public void A(){

            a = 10;

        }

    }

    public struct Mode_struct{

        public Data_file_link data;

        public int Get(){

            return 0;
        }

    }


    public class Botao {
        public Botao_data data;
    }


    public struct Botao_data {}


    public static Mode_class c;
    public static Mode_struct s;


    public static void Main(){

        // ( White_canvas.s.data )

        Program_data* program = (Program_data*) STATIC_data.program.Get_pointer();
        Fn( &program->program_modes.menu );


    }

    
    public static void Fn( PROGRAM_DATA__menu* _menu ){

        STATIC_data.menu.Change_data( &_menu->type, 10 );

    }


}

public static class STATIC_data{

    public static Data_file_link program;

        public static Data_file_link menu;

}