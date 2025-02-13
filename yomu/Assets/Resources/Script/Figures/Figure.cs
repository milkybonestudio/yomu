using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;



public abstract class Figure : Body {


        public static GameObject container_figures = GameObject.Find( "Containers/Figures" );

        public Figure(){

                

                figure_getter_object = Figure_creation_data.figure_getter_static;

                    name = ( "Figure_" + figure_getter_object.main_folder + figure_getter_object.path_root );


                    Create_body( null );

                    // Create_body_containers( null ); // cria o container base
                    // Link_structure( null ); // cria um novo

                    // container = GAME_OBJECT.Criar_filho( name, container_figures );
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

        public Material material = new Material( Shaders.teste_shader );


        public bool activated;
        public bool have_place;
        public Figure_mode_type current_visual;


        // --- INTERFACE

        // ** only for tests / intern
            public Figure_mode Get( Figure_mode_type _visual_figure ){ return figure_modes[ _visual_figure ]; }
        

        // --- RESOURCES

            // ** todos os modos

            public virtual void Prepare( Figure_mode_type _visual ){ figure_modes[ _visual ].Prepare(); }
            public virtual void Prepare( /*nothing*/ ){ foreach( Figure_mode mode in figure_modes.Get_valid() ) { mode.Prepare(); }; }


            public virtual void Reduce( Figure_mode_type _visual ){ figure_modes[ _visual ].Reduce(); }
            public virtual void Reduce( /*nothing*/ ){ foreach( Figure_mode mode in figure_modes.Get_valid() ){ mode.Reduce(); }; }



        // --- LOGIC
        public Figure Set( GameObject _container ){ 
                
                
                if( ( _container == null ) && !!!( have_place ) )
                    { Console.Log( $"will declare the container to the figure { name } as the default for figures" ); }

                have_place = true; 

                if( _container == null )
                    { return this; } 

                Set_body_container_parent( _container );

                return this; 

        }



        public virtual void Update( Control_flow _control_flow ){

                if( !!!( activated ) )
                    { return; }

                base.Update( _control_flow );

                foreach( Figure_mode mode in figure_modes.Get_valid() )
                    { mode.Update();}
                
        }

    
        public void Instanciate( Figure_mode_type _visual, GameObject _place = null ){

                activated = true;

                if( _place == null && !!!( have_place ))
                    { CONTROLLER__errors.Throw( $"Do not define the place to put the figure <Color=lightBlue>{ name }</Color>" ); }
                

                if( _place != null )
                    { Set( _place ); }


                Get( _visual ).Instanciate();
                current_visual = _visual;

        }

        public void Delete( ref Figure _figure_ref ){

            
                foreach( Figure_mode mode in figure_modes.Get_valid() )
                    { mode.Delete();}

                _figure_ref = null;

        }


        

        public virtual void Change_mode( Figure_mode_type _visual ){

                //mark
                // ** sempre dar o Figure.Prepare() antes

                Get( _visual ).Instanciate();
                Get( current_visual ).Hide();

                current_visual = _visual;

                return;
                
        }


        // --- EXPORTED METHODS

            public virtual void Blick( Blink_data _data ){ Get( current_visual ).Blick( _data ); }
            public virtual void Speak( Speak_data _data ){ Get( current_visual ).Speak( _data ); }
            public virtual void Activate_emoji( Figure_emoji _emoji ){ Get( current_visual ).Activate_emoji( _emoji ); }


            public void Focus( bool _is_focus ){ body_data.Set_focus( _is_focus ); }




}