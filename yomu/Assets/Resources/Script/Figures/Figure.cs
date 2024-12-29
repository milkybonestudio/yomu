using System;
using UnityEngine;

public struct Position {

    public float x;
    public float y;

}

public abstract class Figure {


        public Resource_context resources_context =  Resource_context.Characters;
        public string main_folder = "Lily";
        public string figure_name = "Clothes";


        public abstract void Update();

        // public void Blink(){ figure_interface.Blink( this ); }
        // public void Speak(){ figure_interface.Blink( this ); }
        // public void Change_emotion( ulong _emotion ){ figure_interface.Change_emotion( this, _emotion ); }


        public GameObject figure_container_prefab;
        public GameObject figure_container;


        public RESOURCE__structure_copy structure;


        private const float move_speed_pixels_PER_second = 1_000f;
        


        public void Visual_update(){

            // --- VERIFICA SE PRECISA MOVER
            if( ( character_final_position.x != character_current_position.x ) || ( character_final_position.y != character_current_position.y ) )
                { /*Move*/ }


        }

        public void Put_focus(){}


        public float current_scale;
        public float final_scale;

        public void Set_scale( float _scale ){ final_scale = _scale; }

        
        // --- MOVEMENT PART

        public Position character_final_position;
        public Position character_current_position;

        public void Move( Position _position, bool _force ){

                character_final_position.x += _position.x;
                character_final_position.y += _position.y;

                if( !!!( _force ) )
                    { return; }

                // --- FORCA PARA A POSICAO

                character_current_position = character_final_position;
                Move_character();

        }

        private void Change_current_position(){


                float distance_x = ( character_final_position.x - character_current_position.x );
                float distance_y = ( character_final_position.y - character_current_position.y );

                
                float max_frame_speed = ( Time.deltaTime * move_speed_pixels_PER_second );
                float vec = Mathf.Sqrt( ( distance_x * distance_x ) + ( distance_y * distance_y ) );

                float rate  = ( max_frame_speed / vec );

                if( rate > 0.99f )
                    {
                        // --- ACABOU
                        character_current_position.x = character_final_position.x;
                        character_current_position.y = character_final_position.y;
                    } 
                    else
                    {
                        // --- NAO ACABOU
                        character_current_position.x += ( rate * distance_x );
                        character_current_position.y += ( rate * distance_y );
                    }

                Move_character();

                return;
                
        }


        private float Calculate_final_frame_position( float _current_position, float _final_position ){

                return 0f;


        }

        private void Move_character(){

            
                if( figure_container == null )
                    { CONTROLLER__errors.Throw( $"Tried to move the figure { "name" } but the container was null" ); }
                
                figure_container.transform.localPosition = new Vector3( character_current_position.x, character_current_position.y, 0f );
                
                return;

        }
        public void Set_position( Position _position ){ character_final_position = _position; }





}