using System;
using UnityEngine;
using UnityEngine.UI;


public struct Figure_mode_animation_SIMPLE {

        public static Figure_mode_animation_SIMPLE def;

        public static Figure_mode_animation_SIMPLE Construct( RESOURCE__image_ref[] _resources_images, SpriteRenderer _sprite_render, int _frames_per_second ){

                if( _resources_images == null )
                    { CONTROLLER__errors.Throw( "The resources_images came null" ); }

                if( _sprite_render == null )
                    { CONTROLLER__errors.Throw( "The _sprite_render came null" ); }

                Figure_mode_animation_SIMPLE animation = default;

                    animation.active = true;
                    animation.resources_images = _resources_images;
                    animation.sprite_render = _sprite_render;
                    animation.frames_per_second = _frames_per_second;
                    animation.seconds_per_frame = ( 1f /  ( float ) _frames_per_second );

                return animation;

        }


        public bool active; // -> isso existe
        public int pointer_data;

        // ** quando for usar 
        public int frames_per_second;
        public float seconds_per_frame;
        

        // ** data 
        public int number_loops; // depende?
        public int current_loop;

        public int actual_index;
        public SpriteRenderer sprite_render;
        public RESOURCE__image_ref[] resources_images;


        public float time_stack;

        public int Update(){

            if( !!!( active ) )
                { return 0; }

            // Console.Log( "<Color=lightBlue>{------------------------}</Color>");
            // Console.Log( "number_loops: " + number_loops );
            // Console.Log( "current_loop: " + current_loop );
            // Console.Log( "resources_images_length: " + resources_images.Length );
            

            if( current_loop == number_loops )
                {  return 0; }

            time_stack += Time_info.delta_time;

            
            if( time_stack < seconds_per_frame )
                { return 0; }

            
            time_stack -= seconds_per_frame;  // --- reseta mas deixa o resto

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
