


using UnityEngine;

public static class Figure_creation_data {


        public static Figure_data_getter figure_getter_static;

        public static void Put_data( Figure_use_context _context, Resource_context _resources_context,string _main_folder, string _figure_name ){

            figure_getter_static.Put_data( _resources_context, _main_folder, _figure_name, _context );

        }


}
