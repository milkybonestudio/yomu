using UnityEngine.UI;


public struct Emotion_figure_animation_SIMPLE {

        // ** only changes sprites

        public int number_loops;
        public int current_loop;
        public Image image_component;
        public RESOURCE__image_ref[] resources_images;

}

public struct Emotion_figure_animation_MULTIPLES {

        public int number_loops;
        public int current_loop;
        public Image[] image_component;
        public RESOURCE__image_ref[,] resources_images;

}


public struct Emotion_figure_resources {

    // ** todos 
    public RESOURCE__ref[] resources; 
    
    // ** somente body
    public Emotion_figure_image_link[] images_links;


}

public struct Emotion_figure_image_link {


        public Image image_component;
        public RESOURCE__image_ref resource_image;

        
}


