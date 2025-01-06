


public static class Figure_creation_data {



        public static void Clean_context(){ context_static = Figure_use_context.not_give; }
        public static Figure_data_getter figure_getter_static;
        public static Figure_use_context context_static;


        public static void Put_data( Resource_context _resources_context,string _main_folder, string _figure_name ){

            figure_getter_static.Put_data( _resources_context, _main_folder, _figure_name, context_static );

        }


        public static void Set_context( Figure_use_context _new_context ){

                if( context_static != Figure_use_context.not_give )
                    { CONTROLLER__errors.Throw( $"Tried to change the contex to <Color=lightBlue>{ _new_context }</Color>, but the old contex \"<Color=lightBlue>{ context_static }</Color>\" was not cleared" ); }

                context_static = _new_context;

        }


}
