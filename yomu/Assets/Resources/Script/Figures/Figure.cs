using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;



public abstract class Figure {


        public static void Put_data( string _main_folder, string _figure_name, Resource_context _resources_context = Resource_context.Characters  ){

                // ** to get the resources the figure_getter is the only necessary. 
                // ** the Linear dic is only later
                figure_getter_static.Put_data( _resources_context, _main_folder, _figure_name, Figure.context_static );

        }

        public Figure(){

                figure_getter_object = figure_getter_static;
                
                figure_container = new GameObject( figure_getter_object.path_root );
                figure_emotions = new Linear_dictionary_figure_emotions( figure_getter_object );

        }


        public static RESOURCE__image_ref Get_image_reference( string _name ){ return figure_getter_static.Get_image_reference( _name ); }
        public static RESOURCE__image_ref Get_image_reference_not_root( string _name ){return figure_getter_static.Get_image_reference_not_root( _name ); }

        public static void Set_context( Figure_use_context _new_context ){


                if( context_static != Figure_use_context.not_give )
                    { CONTROLLER__errors.Throw( $"Tried to change the contex to <Color=lightBlue>{ _new_context }</Color>, but the old contex \"<Color=lightBlue>{ context_static }</Color>\" was not cleared" ); }

                context_static = _new_context;

        }


        public static void Clean_context(){ context_static = Figure_use_context.not_give; }

        public static Figure_data_getter figure_getter_static;
        public static Figure_use_context context_static;


        public Figure_data_getter figure_getter_object;

 
        public GameObject figure_container;


        public Linear_dictionary_figure_emotions figure_emotions;
        public Emotion_figure[] valid_figures_emotions;
        protected void Finalize_emotions(){ valid_figures_emotions = figure_emotions.Seal();  }
        

        public virtual void Update(){

                if( valid_figures_emotions == null )
                    { Finalize_emotions(); }

                foreach( Emotion_figure emotion in valid_figures_emotions )
                    { emotion.Update();}
            
        }

    

        private const float move_speed_pixels_PER_second = 1_000f;
        


        public void Visual_update(){

            // --- VERIFICA SE PRECISA MOVER
            if( ( character_final_position.x != character_current_position.x ) || ( character_final_position.y != character_current_position.y ) )
                { /*Move*/ }


        }


        public Visual_figure current_visual;

        public virtual void Change_form( Visual_figure _visual ){


                figure_emotions[ ( int ) _visual ].Activate();
                figure_emotions[ ( int ) current_visual ].Deactivate();

                current_visual = _visual;
                
                
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