


public abstract class Figure_type<FIGURE_TYPE> : FIGURE_MODE where FIGURE_TYPE : Figure {

            
        public FIGURE_TYPE figure;


        public FIGURE_MODE Construct( FIGURE_TYPE _figure, Figure_type_construct_data _data ){

            if( _figure == default ) 
                { CONTROLLER__errors.Throw(""); }

            if( _data.visual_figure == default ) 
                { CONTROLLER__errors.Throw(""); }

            if( _data.resources_length == default ) 
                { _data.resources_length = 35; }

            if( _data.images_links_length == default ) 
                { _data.images_links_length = 10; }


            data_construction = _data;


            figure = _figure; 
            visual_figure = _data.visual_figure;
            figure_interface = _figure;


            name = _data.special_name ??  _data.visual_figure.ToString().ToUpper();

            // structure = Controllers.resources.structures.Get_structure_copy_null();
            
            
            return this;

        }

    
}