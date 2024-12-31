


public abstract class Emotion<Figure_type> : Emotion_figure where Figure_type : Figure {


        public Emotion_figure Construct( Figure_type _figure, Visual_figure _visual_figure, int _images_links_length = 10, int _resources_length = 35 ){ 


                    figure = _figure; 
                    visual_figure = _visual_figure;

                    figure_interface = _figure;
                    visual_figure = _visual_figure;
                    resources  = new Emotion_figure_resources() {
                                                                    images_links = new Emotion_figure_image_link[ _images_links_length ],
                                                                    resources = new RESOURCE__ref[ _resources_length ]
                                                                };

                    return this;

        }
            
        public Figure_type figure;
    

}

