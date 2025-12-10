using System;
using System.IO;
using System.Reflection;
using System.Threading;
using UnityEngine;



public static class CONSTRUCTOR__program {

    public static void Construir( Program _program ){

        Controllers.errors =  CONSTRUCTOR__controller_errors.Construct();
        Program.instance = _program;
        
        _program.control_flow = new Control_flow();


        // --- SETTINGS

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            Application.runInBackground = true;

        // --- SET THREAD
        if( Thread.CurrentThread.Name == null )
            { Thread.CurrentThread.Name = "Main"; }


        Dados_fundamentais_sistema.jogo_ativo = true;

        // return;

        string version_folder = Path.Combine( Paths_system.persistent_data, System_information.version.Get_name() );
        Paths_version.Define_version_folder( version_folder );


        // --- CONTROLLERS GENERIC 1

            Controllers_program.crash_handler = CONSTRUCTOR__controller_crash_handler.Construct();

            Controllers.heap = CONSTRUCTOR__controller_heap.Construct();
            Controllers.tasks = CONSTRUCTOR__controller_tasks.Construct();
            Controllers.resources = CONSTRUCTOR__controller_resources.Construct();
            Controllers.packets = CONSTRUCTOR__controller_packets_storage.Construct();
            Controllers.files = CONSTRUCTOR__controller_data_files.Construct();
            Controllers.saving = CONSTRUCTOR__controller_saving.Construct();
            Controllers.stack = CONSTRUCTOR__controller_safety_stack.Construct();
            Controllers.paths_ids = CONSTRUCTOR__controller_paths_ids.Construct();
            Controllers.context =  CONSTRUCTOR__controller_context.Construct();


        
        #if UNITY_EDITOR


            // --- DEVELOPMENT START

                Type CONTROLLER__development = Assembly.Load( "Development" ).GetType( "CONTROLLER__development" );
                object controller_development = Activator.CreateInstance( CONTROLLER__development, new object[ 0 ], null );

                // --- RUN MODIFICATIONS

                    MethodInfo start_method_development = CONTROLLER__development.GetMethod( "Apply_development_modifications_start" );
                    start_method_development.Invoke( controller_development, null );

                // -- UPDATE

                    Action<Control_flow> Update_development = ( Action<Control_flow> ) CONTROLLER__development.GetMethod( "Get_update" ).Invoke( controller_development, null );
                    _program.Update_development = Update_development;

            
        #endif
        
        // --- PERSISTENT AND VERSION FOLDERS

        if( !!!( System.IO.Directory.Exists( Paths_system.persistent_data ) ) )
            {  Directory.CreateDirectory( Paths_system.persistent_data ); } // only editor, is construct by default in build


        bool is_first_play = !!!( System.IO.Directory.Exists( Paths_version.path_to_version ) );
        if( is_first_play )
            { TOOL__version_folders_constructor.Construct(); }

        bool corrupted_when_creating_start_files = !!!( System.IO.File.Exists( Paths_version.security_file ) );
        if( corrupted_when_creating_start_files )
            { 
                Directories.Delete_safe( Paths_version.path_to_version );
                TOOL__version_folders_constructor.Construct();
            }

    
        bool system_crashed = System.IO.Directory.Exists( Paths_run_time.saving_run_time_folder );

        if( system_crashed )
            { 
                Console.Log( "CAME DEAL CRASH" );
                Crash_handle_result result_reconstruct_from_crash = Crash_handle_result.fail;

                if( System_run.activate_crash_handler )
                    { result_reconstruct_from_crash = Controllers_program.crash_handler.Reconstruct_state(); }

                if( result_reconstruct_from_crash == Crash_handle_result.fail )
                    { 
                        // ** handle, tem que usar o save morte nesse caso
                    }
                            
            }
            
        TOOL__run_time_folders_constructor.Construct();

        
        // --- LOAD CONTEXT
            Controllers.paths_ids.Define_paths_ids();
            Controllers.context.Force_change_context( Paths_program.program_context );


        // // --- START 
        //     Controllers.stack.Start_saver();
    
        // --- CONTAINERS

            Containers.Force_static_constructor();

        
        // --- CONSTRUIR CONTROLADORES GERAIS

            Controllers.input = CONSTRUCTOR__controller_input.Construct();
            Controllers.audio = CONSTRUCTOR__controller_audio.Construct();
            Controllers.configurations = CONSTRUCTOR__controller_configurations.Construct();

            // ** can not be here
            // ???
            Controllers.data = CONSTRUCTOR__controller_data.Construct();
            Controllers.items = CONSTRUCTOR__controller_items.Construct();

        // --- PROGRAM

            Controllers_program.program = _program;
            Controllers_program.data = CONSTRUCTOR__controller_program_data.Construct();
            Controllers_program.program_transition = CONSTRUCTOR__controller_program_transition.Construct();
            Controllers_program.canvas_spaces = CONSTRUCTOR__controller_canvas_spaces.Construct();
                

        

        // --- CREATE MODES

        _program.modes = new PROGRAM_MODE[ ( int ) Program_mode.END ];

        Program_modes.login = new Login();
        Program_modes.menu = new Menu();
        Program_modes.game = new Game();


        _program.modes[ ( int ) Program_mode.login ] = Program_modes.login;
        _program.modes[ ( int ) Program_mode.menu ] = Program_modes.menu;
        _program.modes[ ( int ) Program_mode.game ] = Program_modes.game;
                        

        _program.modes[ ( int ) Program_mode.rebuild_save ] = new Rebuild_save();
        _program.modes[ ( int ) Program_mode.nothing ] = new Nothing();
        _program.modes[ ( int ) Program_mode.new_game ] = new New_game();
        _program.modes[ ( int ) Program_mode.program_start_messages ] = new Program_start_messages();


        // ** FORCE NOTHING STAGE 

        _program.current_mode = Program_mode.nothing;  

        RESOURCE__structure_copy nothing_structure = Controllers.resources.structures.Get_structure_copy( Resource_context.System, "Nothing", "structure", Resource_structure_content.game_object );
        nothing_structure.Instanciate();
        Controllers_program.canvas_spaces.canvas_space_current.content.world.Add( nothing_structure );
        
        

        // --- LISTS
        //performance
        // ** isso pode ser feito em tempos separados

        Figure_emojis_list.list = new Figure_emojis_list();

        List_items.Construct();

        
        // --- START



        #if UNITY_EDITOR

        
            // --- CONTAINERS 

                Editor_information.Pass_editor_run_count();
                // Console.Log( Editor_information.play_count );
                typeof( Containers ).GetConstructor( ( BindingFlags.Static | BindingFlags.NonPublic ), null, new Type[ 0 ], null ).Invoke(null, null);

            // --- DEVELOPMENT END

            MethodInfo end_method_development = CONTROLLER__development.GetMethod( "Apply_development_modifications_end" );
            end_method_development.Invoke( controller_development, null );
            
        #else

            // Exclusive_client_program();
            _program.Update_development = ( Control_flow _control )=>{};
            Program_starter.Start_game();

        #endif


            
        return;

    }


}
