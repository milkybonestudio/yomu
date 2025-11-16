using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/*

    CHANGED SOMETHING : ** NO ** 

                 ________v____________v______________________v_______________________v_________________
                |        U            U                      U                       U                 |
        figure  |    Activate    Deactivate       |  Change_conten_level      Change_mode_level        |
                |______________________________________________________________________________________|
  
                        |            |            |          |          |          |
                        |            |            |          |          |          |
                        |            |            |          |          |          V
                        |            |            |          |          |     ______________
                        |            |            |          |          |    |              |
                        V            V            |          V          |    |  controller  | ** always have update ** <----
                    ( stop )  ( start again )     |   | muda final |    |    |    modes     |                              |
                      |-----------------|         |                     |    |______________|                              |
 Update()   --->      | fluxo de update | ---->   |    vai sempre       |      |                                           |
                      |    content      |         |   para o final      |      |-----------> mode 1 Update()               |
    |                 |_________________|         |                     |      |-----------> mode 2 Update()               |
    |                                             |                     |      |-----------> mode 3 Update()               |
    |                                             |                     |      |-----------> mode 4 Update()               |
    |                                             |                     |      |-----------> ...                           |
    |                                                                                                                      |
    |______________________________________________________________________________________________________________________|

*/



public abstract partial class Figure{


        public static bool teste;
        public static GameObject container_figures = GameObject.Find( "Containers/Figures" );

        public Body body;
        public string name;

        public Figure_creation_data data;
        public Figure_data_getter figure_getter_object;

        public Figure_state state;

        public MANAGER__figure_modes modes;

        public Material material = new Material( Shaders.teste_shader );

        public Figure_mode current_mode_type;
        public FIGURE_MODE current_mode;

        public Figure_mode transition_mode_type;
        public FIGURE_MODE transition_mode;

        protected abstract Figure_mode Get_default_mode();

        private bool deleted;


        public Figure Construct( Figure_creation_data _data, string _main_folder, string _root_path, Resource_context _context ){ 

            body.Set_body_constructor_data( _data.body_data_creation );

            data = _data;
            
            figure_getter_object.main_folder = _main_folder;
            figure_getter_object.root = _root_path;
            figure_getter_object.context = _context;
            
            final_content = Figure_content.nothing;
            current_content = Figure_content.nothing;
            minimun_content = Figure_content.modes_content;

            // ** se ficar grande ao ponto que use muita ram pode mudar para minimum/nothing
            // ** mas para simplificar a edicao 1 dificilmente vai precisar pela reducao da dimensao
            if( _data.content_level_modes_default == Content_level.not_give )
                { _data.content_level_modes_default = Content_level.full; }


            for( int content_level_default = 0; content_level_default < content_levels_modes.Length ; content_level_default++ )
                { content_levels_modes[ content_level_default ] = _data.content_level_modes_default; }

            if( data.start_mode == Figure_mode.not_give )
                { data.start_mode = Get_default_mode(); }

            name = ( "Figure_" + figure_getter_object.main_folder + figure_getter_object.root );

            modes = MANAGER__figure_modes.Construct( this );
            
            return this;

        }

        
        // --- DATA
        public virtual void Update_support( Control_flow _flow ){}
        public void Update( Control_flow _flow ){

                if( deleted )
                    { CONTROLLER__errors.Throw( $"Tried to update the figure <Color=lightBlue>{ name }</Color> but it was <Color=lightBlue>deleted</Color>" ); }

                Console.Log( Figure.teste, $"<Color=lightBlue>--------------------------</Color>" );
                Console.Log( Figure.teste, $"Update figure <Color=lightBlue>{ name }</Color>" );

                Update_support( _flow );
            
                // ** when the modes are not implemented it still works, but there is no modes to update
                // ** for( nothing ){ ... }
                modes.Update( _flow );

                if( state != Figure_state.active )
                    {  Update_content( _flow ); return; }

                _flow.weight_frame_available -= body.Update();
                
        }


}