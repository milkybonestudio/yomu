using UnityEngine;

public struct Figure_emoji_data { 

        public bool activated;


        public SpriteRenderer render;
        public GameObject place;
        public GameObject container; // ** emoji start
        public RESOURCE__image_ref[] images_refs;
        public RESOURCE__audio_ref audio_ref;
        public Figure_emoji_movement move_type;

        public Figure_mode_emoji emoji;
        
        public int frames_per_second;
        public float time_stack;
        public int actual_index;

        public int speed_pixels_per_second;
        public float sin_acc;


        public int Update(){

            if( !!!( activated ) )
                { CONTROLLER__errors.Throw( $"Tried to update figure emoji { emoji }, but the emoji is not activated" ); }

            // --- garante que esta ativo

            if( images_refs == null )
                { CONTROLLER__errors.Throw( $"Did not put the images in the emoji { emoji }" ); }

        
    
            Update_movement();

        
            time_stack += Time.deltaTime;

            float v = ( 1f /  ( float ) frames_per_second );
            
            if( time_stack > v )
                { 
                    
                    time_stack -= v;  // --- reseta mas deixa o resto
                    Pass_image(); 
                    return 1;
                }

            return 0;

        }

        public void Pass_image(){

                actual_index = ( ( actual_index + 1 ) % images_refs.Length );

                render.sprite = images_refs[ actual_index ].Get_sprite();

                if( actual_index == 0 )
                    { End(); }

        }

        public void End(){

            activated = false; 
            render = null;
            GameObject.Destroy( place );

        }


        public const float pixels_per_unity = 100f;
        private void Update_movement(){


            // place

                 if( move_type == Figure_emoji_movement.wave_out )
                    {

                        // testar 

                        float change = ( speed_pixels_per_second / pixels_per_unity ) * Time.deltaTime;

                        Vector3 position = container.transform.localPosition;



                        sin_acc += Time.deltaTime;

                        float var_sin = Mathf.Sin( sin_acc );
                        
                        float v = ( change / ( position.x + position.y + position.z ));


                        place.transform.localPosition += new Vector3( v * position.x * var_sin , v * position.y * var_sin , v * position.z * var_sin );


                    }
            else if( move_type == Figure_emoji_movement.linear_out )
                    {

                        float change = ( speed_pixels_per_second / pixels_per_unity ) * Time.deltaTime;

                        Vector3 position = container.transform.localPosition;
                        
                        float v = ( change / ( position.x + position.y + position.z ));

                        place.transform.localPosition += new Vector3( v * position.x, v * position.y, v * position.z );

                    }
            else if( move_type == Figure_emoji_movement.not_move )
                    {
                        // nada
                    }


        }




}