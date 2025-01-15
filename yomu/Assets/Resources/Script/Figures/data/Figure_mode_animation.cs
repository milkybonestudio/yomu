using System;
using UnityEngine;
using UnityEngine.UI;


public struct Figure_mode_animation_SIMPLE {


        public bool active;

        public Figure_mode_resoruces_state resources_state;


        public void Load_resources(){

            if( !!!( active ) ) 
                { return; }

            resources_state = Figure_mode_resoruces_state.getting_resources;

        }



        // ** 1 -> precisa atualizar
        public int Check_resources(){


                if( resources_state == Figure_mode_resoruces_state.off )   
                    { return 0; }

                if( resources_state == Figure_mode_resoruces_state.all_resources )
                    { return 0; }



                for( int slot = 0; slot < resources_images.Length ; slot++ ){

                    RESOURCE__image image = resources_images[ slot ].image;

                    //mark
                    // ** precisa 
                    // if( ( image.stage_getting_resource != Resources_getting_image_stage.finished ) || ( image.actual_content != Resource_image_content.sprite ) )
                    //     { return 0; }


                   if( image.stage_getting_resource != Resources_getting_image_stage.finished  )
                        { return 0; }

                    
                }

                resources_state = Figure_mode_resoruces_state.all_resources;

                return 1;


        }



        // ** only changes sprites

        // ** quando for usar 
        public int frames_per_second;
        

        // ** data 
        public int number_loops; // depende?
        public int current_loop;

        public int actual_index;
        public SpriteRenderer sprite_render;
        public RESOURCE__image_ref[] resources_images;


        public float time_stack;

        public int Update(){

            if( resources_images == null )
                { return 0; }


            if( current_loop == number_loops )
                { return 0; }


            float frame_time = Time.deltaTime;

            time_stack += frame_time;

            bool frame_libarated = false;
            Console.Log(  time_stack );

            if( time_stack > ( 1f /  ( float ) frames_per_second ) )
                { 
                    frame_libarated = true; 

                    // --- reseta mas deixa o resto
                    time_stack -= ( 1f / ( ( float ) frames_per_second ) ); 
                }


            if( !!!( frame_libarated ) )
                { return 0; }

            actual_index = ( (actual_index + 1) % resources_images.Length );

            if( actual_index == 0 )
                { current_loop++; }

            sprite_render.sprite = resources_images[ actual_index ].Get_sprite();

            return 1;

        }

        public void Reset(){

                number_loops = 0;
                current_loop = 0;
                time_stack = 0f;
                actual_index = 0;
                sprite_render.sprite = resources_images[ 0 ].Get_sprite();

        }

}


public struct Figure_mode_animation_MULTIPLES {


        public Figure_mode_resoruces_state resources_state;


        public bool active;

        public int number_loops;
        public int current_loop;
        public SpriteRenderer[] sprite_render;
        public RESOURCE__image_ref[,] resources_images;


        public void Load_resources(){

            if( !!!( active ) )
                { return; }
            
            resources_state = Figure_mode_resoruces_state.getting_resources;

        }

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
            { _refs[ slot ].n = "multiples_" + slot; Add( _refs[ slot ] ); }

    }

    public int Add( RESOURCE__ref _ref ){

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
            { resources_refs[ slot ].Activate(); }

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


public enum Figure_mode_resoruces_state {

    off,
    getting_resources,
    all_resources,

}




public struct Figure_mode_main {


    public Figure_mode_resoruces_state resources_state;

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

            
            if( resources_state == Figure_mode_resoruces_state.off )
                { return 0; }

            if( resources_state == Figure_mode_resoruces_state.all_resources )
                { return 0; }


            for( int slot = 0; slot < images_links.Length ; slot++ ){

                if( images_links[ slot ].sprite_render == null )
                    { break; } // ** no more images

                    RESOURCE__image image = images_links[ slot ].resource_ref.image;
                    if( ( image.stage_getting_resource != Resources_getting_image_stage.finished ) || ( image.actual_content != Resource_image_content.sprite ) )
                    { return 0; }
                
            }

            resources_state = Figure_mode_resoruces_state.all_resources;
            return 1;


    }


}
