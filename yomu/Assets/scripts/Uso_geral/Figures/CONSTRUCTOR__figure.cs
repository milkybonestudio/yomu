using UnityEngine;

public static class CONSTRUCTOR__figure {

    public static Figure Construct( INTERFACE__figure _unique_figure_interface ){

            Figure figure = new Figure();
            figure.figure_interface = _unique_figure_interface;


            string context_name = _unique_figure_interface.Get_context().ToString();
            string main_folder = _unique_figure_interface.Get_main_folder();
            string figure_name = _unique_figure_interface.Get_figure_name();

            string folder_path = System.IO.Path.Combine( context_name, main_folder, figure_name );
            string prefab_path = System.IO.Path.Combine( folder_path, ( figure_name + "_prefab" ) );

            // --- PEGA O PREFAB
            figure.figure_container_prefab = Resources.Load<GameObject>( prefab_path );

            if( figure.figure_container_prefab == null )
                { CONTROLLER__errors.Throw( $"Prefab { figure_name } was not found in the path:<Color=lightBlue> { folder_path }</Color>" ); }

            
            return figure;

    }

}