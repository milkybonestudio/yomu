using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;



public abstract class Figure : Component {


        /*

            O formato base vai ser:
                para modo em especifico: figure_ob.Get( MODE ).action( args ) 
                para todos os modos: figure_ob.action( args )
                
                certas coisas podem parecer especificas mas na realidade usam todos os modos, por exemplo colocar em evidencia. 

                ex: 
                    se quiser dar prepare ( começar a alocar rescursos completos ) em mod.Mad usa figure_ob.Get( Mode.mad ).prepare(), 
                    se quiser dar prepare em todos uda figure_ob.Prepare()
        
        */


        public static GameObject container_figures = GameObject.Find( "Containers/Figures" );

        public Figure(){


                figure_getter_object = Figure_creation_data.figure_getter_static;

                    name = ( "Figure_" + figure_getter_object.main_folder + figure_getter_object.path_root );
                    container = GAME_OBJECT.Criar_filho( name, container_figures );
                    figure_modes = new Linear_dictionary_figure_modes( figure_getter_object );


        }

        // ** to get the resources the figure_getter is the only necessary. 
        // ** the Linear dic is only later
        public static void Put_data( Figure_use_context _context, string _main_folder, string _root_path, Resource_context _resources_context = Resource_context.Characters  ){ Figure_creation_data.Put_data( _context, _resources_context,_main_folder, _root_path ); }

        public static RESOURCE__image_ref Get_image_reference( string _name ){ return Figure_creation_data.figure_getter_static.Get_image_reference( _name ); }
        public static RESOURCE__image_ref[] Get_images_reference( string _name, int _number_images ){ return Figure_creation_data.figure_getter_static.Get_images_reference( _name, _number_images ); }
        
        public static RESOURCE__image_ref Get_image_reference_not_root( string _name ){return Figure_creation_data.figure_getter_static.Get_image_reference_not_root( _name ); }
        public static RESOURCE__image_ref[] Get_images_reference_not_root( string _name, int _number_images ){return Figure_creation_data.figure_getter_static.Get_images_reference_not_root( _name, _number_images ); }



        // --- DATA

        

        public Linear_dictionary_figure_modes figure_modes;
        public Figure_data_getter figure_getter_object;
        public GameObject container;

        public string name;

        public Material material = new Material( Shaders.teste_shader );

        public Figure_mode_type current_visual;


        // public Figure_visual_data data;


        public Position character_final_position;
        public Position character_current_position;

        

        private const float move_speed_pixels_PER_second = 1_000f;

        public bool end;
        public bool have_place;


        // --- INTERFACE

        // ** only for tests / intern
            public Figure_mode Get( Figure_mode_type _visual_figure ){ return figure_modes[ _visual_figure ]; }
        

        // --- RESOURCES

            // ** todos os modos

            public virtual void Prepare(){

                foreach( Figure_mode mode in figure_modes.Get_valid() )
                    { mode.Prepare(); }; 
                    
                return;

            }


            public virtual void Prepare( Figure_mode_type _visual ){ figure_modes[ _visual ].Prepare(); }

        // // --- CHANGE DATA

        //     public virtual void Change_global_multiplier( float _new_multiplier ){ data.Change_global_multiplier( _new_multiplier ); }

        //     // ** SCALE
                
        //         // 100%?
        //         public virtual void Rescale( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); data.scale.normal += new Vector3( _new_scale, _new_scale, _new_scale ); }
        //             public virtual void Rescale( float _new_scale_percent_X, float _new_scale_percent_Y ){ data.scale.normal += new Vector3( ( _new_scale_percent_X/100f ), ( _new_scale_percent_Y/100f ), 0f ); }
        //                 public virtual void Rescale( Vector3 _new_scale ){ data.scale.normal += _new_scale; }

                    


        //         public virtual void Rescale_to( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); data.scale.normal = new Vector3( _new_scale, _new_scale, _new_scale ); }
        //             public virtual void Rescale_to( float _new_scale_percent_X, float _new_scale_percent_Y ){ data.scale.normal = new Vector3( ( _new_scale_percent_X/100f ), ( _new_scale_percent_Y/100f ), data.scale.normal.z ); }
        //                 public virtual void Rescale_to( Vector3 _new_scale ){ data.scale.normal = _new_scale; }


        //         public virtual void Change_focus_scale( float _new_scale ){ data.scale.focus = new Vector3( _new_scale, _new_scale, _new_scale ); }
        //             public virtual void Change_focus_scale( Vector3 _new_scale ){ data.scale.focus = _new_scale; }
        //         public virtual void Change_off_set_scale( Vector3 _position ){ data.scale.off_set = _position; }

        //         public virtual void Change_base_speed_per_second_scale( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); data.scale.base_speed_per_second = _new_scale; }
                

        //         public virtual void Force_scale(){  }


        //     // ** POSITION
                
        //         public virtual void Move( Vector3 _position ){ data.position.normal += _position; }
        //             public virtual void Move( float _x, float _y, float _z = 0f ){ data.position.normal += new Vector3( _x, _y, _z ); }

        //         public virtual void Move_to( Vector3 _position ){ data.position.normal = _position; }
        //             public virtual void Move_to( float _x, float _y, float _z ){ data.position.normal = new Vector3( _x, _y, _z ); }

        //         public virtual void Change_focus_position( Vector3 _position ){ data.position.focus = _position; }
        //             public virtual void Change_focus_position( float _x, float _y, float _z ){ data.position.focus = new Vector3( _x, _y, _z ); }

        //         public virtual void Change_off_set_position( Vector3 _position ){ data.position.off_set = _position; }
        //             public virtual void Change_off_set_position( float _x, float _y, float _z ){ data.position.off_set = new Vector3( _x, _y, _z ); }
                    
        //         public virtual void Change_base_speed_position( float _position ){ data.position.base_speed_per_second = _position; }
            

        //     public virtual void Force_move(){}


        //     // ** ROTATION
            
            
        //     public virtual void Rotate_to( Quaternion _rotation ){ data.rotation.normal = _rotation; }

        //     public virtual void Rotate( Quaternion _rotation ){ data.rotation.normal *= _rotation; }
        //         public virtual void Rotate( float _x, float _y, float _z ){ data.rotation.normal *= Quaternion.Euler( _x, _y, _z ); }

        //     public virtual void Change_focus_rotation( Quaternion _rotation ){ data.rotation.focus = _rotation; }
        //     public virtual void Change_off_set_rotation( Quaternion _rotation ){ data.rotation.off_set = _rotation; }
        //     public virtual void Change_base_speed_rotation( float _rotation ){ data.rotation.base_speed_per_second = _rotation; }
            


            // ** color?



        // --- LOGIC
        public Figure Set( GameObject _container ){ have_place = true; container.transform.SetParent( _container.transform, false ); return this; }
        public void End(){ end = true; Figure_creation_data.figure_getter_static = default; }



        public virtual void Update(){

                if( !!!( end ) )
                    { CONTROLLER__errors.Throw( $"Do not end the figure <Color=lightBlue>{ figure_getter_object.path_root }</Color>" ); }


                foreach( Figure_mode mode in figure_modes.Get_valid() )
                    { mode.Update();}

                // ** updates
                //Get( current_visual ).Update_material();

                container.transform.localPosition = data.position.Calculate_final();
                container.transform.localRotation = data.rotation.Calculate_final();
                container.transform.localScale = data.scale.Calculate_final();


                // ** update shader?
                
        }

    
        public virtual void Instanciate( Figure_mode_type _visual, GameObject _place ){

                Get( _visual ).Instanciate( _place );
                current_visual = _visual;

        }
        
        public virtual void Change_mode( Figure_mode_type _visual ){


                Get( _visual ).Instanciate();
                Get( current_visual ).Deactivate();

                current_visual = _visual;

                return;
                
        }


        public virtual void Blick( Blink_data _data ){ Get( current_visual ).Blick( _data ); }
        public virtual void Speak( Speak_data _data ){ Get( current_visual ).Speak( _data ); }
        public virtual void Activate_emoji( Figure_emoji _emoji ){ Get( current_visual ).Activate_emoji( _emoji ); }


        public void Focus( bool _is_focus ){ data.Set_focus( _is_focus ); }




}