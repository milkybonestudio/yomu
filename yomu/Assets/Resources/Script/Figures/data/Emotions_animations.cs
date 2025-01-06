using UnityEngine;
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


public struct Figure_mode_resources {

    // ** todos 
    public RESOURCE__ref[] resources; 
    
    // ** somente body
    public Figure_mode_image_link[] images_links;

    // ** activate
    public void Prepare(){

            //Console.Log( "veio load" );

            // foreach( Figure_mode_image_link im in images_links ){
            //     Console.Log( im.image_component );
            // }

            for( int slot = 0; slot < images_links.Length ; slot++ ){

                    if( images_links[ slot ].image_component == null )
                        { break; } // ** no more images

                    // Console.Log(  "level: " +  images_links[ slot ].resource_image.level_pre_allocation );
                    images_links[ slot ].resource_image.Activate();

            }
        
    }

    public void Put_sprites(){
        
        for( int slot = 0; slot < images_links.Length ; slot++ ){

            if( images_links[ slot ].image_component == null )
                { break; } // ** no more images

            images_links[ slot ].image_component.sprite = images_links[ slot ].resource_image.Get_sprite();

        }
        

    }

    public void Update_material( Material _material ){

        for( int slot = 0; slot < images_links.Length ; slot++ ){

            if( images_links[ slot ].image_component == null )
                { break; } // ** no more images

            Console.Log( "Vai atualizar" );

            // Console.Log(  "level: " +  images_links[ slot ].resource_image.level_pre_allocation );
            images_links[ slot ].image_component.material = null;
            images_links[ slot ].image_component.material = _material;

        }

    }


}

public struct Figure_mode_image_link {


        public Image image_component;
        public RESOURCE__image_ref resource_image;

        
}


