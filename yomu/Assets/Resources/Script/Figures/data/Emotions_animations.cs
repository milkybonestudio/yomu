using System;
using UnityEngine;
using UnityEngine.UI;


public struct Figure_mode_animation_SIMPLE {


        public bool have_all_finished_resources;

        public int Check_resources(){

                if( have_all_finished_resources )   
                    { return 0; }


                for( int slot = 0; slot < resources_images.Length ; slot++ ){

                    RESOURCE__image image = resources_images[ slot ].image;
                    if( ( image.stage_getting_resource != Resources_getting_image_stage.finished ) || ( image.actual_content != Resource_image_content.sprite ) )
                        { return 0; }
                    
                }

                have_all_finished_resources = true;

                return 1;


        }



        // ** only changes sprites

        // ** quando for usar 
        public int frames_per_second;
        public float time;

        // ** data 
        public int number_loops; // depende?
        public int current_loop;

        public int actual_index;
        public SpriteRenderer sprite_render;
        public RESOURCE__image_ref[] resources_images;


        public int Update(){

            if( resources_images == null )
                { return 0; }

            if( actual_index == resources_images.Length )
                { actual_index = 0; current_loop++; }

            if( current_loop == number_loops )
                { return 0; } // --- finished

            sprite_render.sprite = resources_images[ actual_index++ ].Get_sprite();
            return 1;

        }

}


public struct Figure_mode_animation_MULTIPLES {

        public int number_loops;
        public int current_loop;
        public SpriteRenderer[] sprite_render;
        public RESOURCE__image_ref[,] resources_images;

}






public struct Resources_container {

    public static Resources_container Get(){

        Resources_container resources = new Resources_container();
            resources.current_index = 0;
            resources.resources_refs = new RESOURCE__ref[ 100 ];
        return resources;

    }

    public int current_index;
    public RESOURCE__ref[] resources_refs;

    public void Add_multiples( RESOURCE__ref[] _refs, int _number_to_ignor = 0 ){

        for( int slot = _number_to_ignor; slot < _refs.Length; slot++ )
            { _refs[ slot ].n = "multiples_" + slot; Add( _refs[ slot ] ); Console.Log( "adicionou ref " );   }

    }

    public int Add( RESOURCE__ref _ref ){

    Console.Log( "vai adicionar: " + ( _ref.n ) );
        if( current_index == resources_refs.Length )
            { Array.Resize( ref resources_refs, ( resources_refs.Length + 50  )); }

        resources_refs[ current_index++ ] = _ref;
        return ( current_index - 1 );

    }


    public void Load(){

        for( int slot = 0 ; slot < current_index; slot++ )
            { resources_refs[ slot ].Load(); }

    }

    
    public void Activate(){

        for( int slot = 0 ; slot < current_index; slot++ )
            { resources_refs[ slot ].Activate(); Console.Log( "vai ativar: " + ( resources_refs[ slot ].n ) ); }

    }

    public void Instanciate(){

        for( int slot = 0 ; slot < current_index; slot++ )
            { resources_refs[ slot ].Instanciate(); }

    }


    

    public void Unload(){

        for( int slot = 0 ; slot < current_index; slot++ )
            { resources_refs[ slot ].Unload(); }

    }


    public void Deactivate(){

        for( int slot = 0 ; slot < current_index; slot++ )
            { resources_refs[ slot ].Deactivate(); }

    }

    public void Deinstanciate(){

        for( int slot = 0 ; slot < current_index; slot++ )
            { resources_refs[ slot ].Deinstanciate(); }

    }





}


public struct Figure_mode_main {


    public bool have_all_finished_resources;

    // ** todos 
    public RESOURCE__ref[] resources; 
    
    // ** somente body
    public Image_link[] images_links;


    public void Put_sprites(){
        
        for( int slot = 0; slot < images_links.Length ; slot++ ){

            if( images_links[ slot ].sprite_render == null )
                { break; } // ** no more images

            images_links[ slot ].sprite_render.sprite = images_links[ slot ].resource_ref.Get_sprite();

        }
        

    }

    public void Update_material( Material _material ){

        for( int slot = 0; slot < images_links.Length ; slot++ ){

            if( images_links[ slot ].sprite_render == null )
                { break; } // ** no more images

            images_links[ slot ].sprite_render.material = null;
            images_links[ slot ].sprite_render.material = _material;

        }

    }


    public int Check_resources(){

            if( have_all_finished_resources )
                { return 0; }

            for( int slot = 0; slot < images_links.Length ; slot++ ){

                if( images_links[ slot ].sprite_render == null )
                    { break; } // ** no more images

                    RESOURCE__image image = images_links[ slot ].resource_ref.image;
                    if( ( image.stage_getting_resource != Resources_getting_image_stage.finished ) && ( image.actual_content == Resource_image_content.sprite ) )
                    { return 0; }
                
            }

            have_all_finished_resources = true;

            return 1;


    }


}
