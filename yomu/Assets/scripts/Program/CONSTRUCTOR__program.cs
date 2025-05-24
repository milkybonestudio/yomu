using System;
using System.Reflection;
using System.Threading;
using UnityEngine;



public static class CONSTRUCTOR__program {




        public static void Construir( Program _program ){


                Controllers.errors =  CONSTRUCTOR__controller_errors.Construct();
                Program.instance = _program;
                
                #if UNITY_EDITOR

                    // --- DEVELOPMENT

                    Type CONTROLLER__development = Assembly.Load( "Development" ).GetType( "CONTROLLER__development" );
                    object controller_development = Activator.CreateInstance( CONTROLLER__development, new object[ 0 ], null );
                    CONTROLLER__development.GetMethod( "Apply_development_modifications_start" ).Invoke( controller_development, null );

                #endif







                _program.control_flow = new Control_flow();

                        
                // --- SET THREAD
                if( Thread.CurrentThread.Name == null )
                    { Thread.CurrentThread.Name = "Main"; }


                Dados_fundamentais_sistema.jogo_ativo = true;
                _program.Update_development = ( Control_flow _control )=>{};
                
                // --- SETTINGS

                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 60;
                Application.runInBackground = true;

            
                // --- FOLDERS


                // *** GARANTE QUE TENHA
                    if( !!!( System.IO.Directory.Exists( Paths_system.persistent_data_path ) ) )
                        { TOOL__folders_constructor.Construct_new_persistent_data_path(); }
                
    
                // *** VERIFICA SE EH O CERTO
                CONTROLLER__yomu_version.Verify();

                


                // --- CONTAINERS

                #if UNITY_EDITOR

                    Editor_information.play_count++;
                    if( Editor_information.play_count != 1 )
                        { typeof( Containers ).GetConstructor( ( BindingFlags.Static | BindingFlags.NonPublic ), null, new Type[ 0 ], null ).Invoke(null, null);  }
                        else
                        { Containers.k(); }

                #endif





                // --- CONSTRUIR CONTROLADORES GERAIS


                // --- GENERIC

                    
                    Controllers.resources = CONSTRUCTOR__controller_resources.Construct();
                    Controllers.tasks = CONSTRUCTOR__controller_tasks.Construct();        
                    Controllers.input = CONSTRUCTOR__controller_input.Construct();
                    Controllers.audio = CONSTRUCTOR__controller_audio.Construct();
                    Controllers.configurations = CONSTRUCTOR__controller_configurations.Construct();
                    
                

                    // ** can not be here
                    Controllers.data = CONSTRUCTOR__controller_data.Construct();
                    Controllers.items = CONSTRUCTOR__controller_items.Construct();
                    Controllers.canvas_spaces = CONSTRUCTOR__controller_canvas_spaces.Construct();

                // --- PROGRAM

                    Controllers_program.program = _program;
                    Controllers_program.program_transition = CONSTRUCTOR__controller_program_transition.Construct();
                    Controllers_program.data = CONSTRUCTOR__controller_program_data.Construct();
                        

                

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
                Controllers.canvas_spaces.canvas_space_current.content.world.Add( nothing_structure );
                
                


                Controllers.saving = CONSTRUCTOR__controller_saving.Construct();






                // --- LISTS
                //performance
                // ** isso pode ser feito em tempos separados

                Figure_emojis_list.list = new Figure_emojis_list();

                List_items.Construct();



                // --- START


                #if UNITY_EDITOR

                    // --- DEVELOPMENT

                    // Type controller_development = ( Assembly.Load( "Development" ).CreateInstance( "CONTROLLER__development", false ) ).GetType();
                    _program.Update_development = ( Action<Control_flow> ) CONTROLLER__development.GetMethod( "Get_update" ).Invoke( controller_development, null );
                    CONTROLLER__development.GetMethod( "Apply_development_modifications_end" ).Invoke( controller_development, null );
                    
                #else

                    Program_starter.Start_game();

                #endif


                
            return ;

        }


}
