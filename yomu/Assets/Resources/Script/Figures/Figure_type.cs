


public abstract class Figure_type<FIGURE_TYPE> : Figure_mode where FIGURE_TYPE : Figure {

        
        public Figure_mode Construct( FIGURE_TYPE _figure, Figure_mode_type _visual_figure, int _images_links_length = 10, int _resources_length = 35 ){


                    figure = _figure; 
                    visual_figure = _visual_figure;

                    figure_interface = _figure;
                    visual_figure = _visual_figure;
                    resources   =  new Figure_mode_resources()  {
                                                                    images_links = new Figure_mode_image_link[ _images_links_length ],
                                                                    resources = new RESOURCE__ref[ _resources_length ]
                                                                };

                    return this;

        }
            
        public FIGURE_TYPE figure;
    

}

