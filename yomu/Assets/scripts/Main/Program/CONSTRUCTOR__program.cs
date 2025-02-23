using System;
using System.Reflection;
using System.Threading;
using UnityEngine;



public static class CONSTRUCTOR__program {


        public static void Construir( Program _program ){



                #if UNITY_EDITOR

                    // --- DEVELOPMENT

                    Type CONTROLLER__development = Assembly.Load( "Development" ).GetType( "CONTROLLER__development" );
                    object controller_development = Activator.CreateInstance( CONTROLLER__development, new object[ 0 ], null );
                    CONTROLLER__development.GetMethod( "Apply_development_modifications_start" ).Invoke( controller_development, null );

                #endif



            Program.instancia = _program;

                        
                // --- SET THREAD
                if( Thread.CurrentThread.Name == null )
                    { Thread.CurrentThread.Name = "Main"; }

                Dados_fundamentais_sistema.jogo_ativo = true;
                    
                _program.canvas = GameObject.Find( "Tela/Canvas" );

                // --- SETTINGS

                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 60;
                Application.runInBackground = true;

            
                // --- FOLDERS

                #if UNITY_EDITOR

                    if( !!!( System.IO.Directory.Exists( Paths_system.persistent_data_path ) ) )
                        { System.IO.Directory.CreateDirectory( Paths_system.persistent_data_path ); }

                #endif

                
                string[] files_in_persistent = System.IO.Directory.GetFiles( Paths_system.persistent_data_path );

                if( files_in_persistent.Length == 0 )
                    { TOOL__folders_constructor.Construct_new_persistent_data_path(); }

    



                if( !!!( Program_data_version.Verify( System.IO.File.ReadAllBytes( Paths_files.program_data_version ) ) ) )
                    { 
                        Console.Log( $"<Color=lightBlue>Program_data_version</Color> Was diferente" );
                        #if UNITY_EDITOR
                            Console.Log( "The version of the saved data is not the current one" );

                                System.IO.Directory.Delete( Paths_system.persistent_data_path, true );
                                TOOL__folders_constructor.Construct_new_persistent_data_path();

                            Console.Log( "<Color=lightBlue>Updated</Color>" );

                        #else
                            CONSTRUCTOR__controller_errors.Construct(); CONTROLLER__errors.Throw( "The version file was not the same" ); 
                        #endif

                    }
                


                // --- CONSTRUIR CONTROLADORES GERAIS


                // --- GENERIC

                    Controllers.errors =  CONSTRUCTOR__controller_errors.Construct();
                    Controllers.resources = CONSTRUCTOR__controller_resources.Construct();
                    Controllers.tasks = CONSTRUCTOR__controller_tasks.Construct();        
                    Controllers.input = CONSTRUCTOR__controller_input.Construct();
                    Controllers.audio = CONSTRUCTOR__controller_audio.Construct();
                    Controllers.configurations = CONSTRUCTOR__controller_configurations.Construct();
                    
                

                    // ** can not be here
                    Controllers.data = CONSTRUCTOR__controller_data.Construct();
                    Controllers.items = CONSTRUCTOR__controller_items.Construct();


                    Controllers.cameras = CONSTRUCTOR__controller_cameras.Construct();

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
                _program.modes[ ( int ) Program_mode.test ] = new Test();
                _program.modes[ ( int ) Program_mode.new_game ] = new New_game();

                

                _program.current_mode = Program_mode.nothing;


                Controllers.saving = CONSTRUCTOR__controller_saving.Construct();



                // --- START

                #if UNITY_EDITOR

                    // --- DEVELOPMENT

                    // Type controller_development = ( Assembly.Load( "Development" ).CreateInstance( "CONTROLLER__development", false ) ).GetType();
                    _program.Update_development = ( Action<Control_flow> ) CONTROLLER__development.GetMethod( "Get_update" ).Invoke( controller_development, null );
                    CONTROLLER__development.GetMethod( "Apply_development_modifications_end" ).Invoke( controller_development, null );
                    
                #else

                    

                    Program_starter.Start_game();


                #endif



                // --- LISTS
                //performance
                // ** isso pode ser feito em tempos separados

                Figure_emojis_list.list = new Figure_emojis_list();

                List_items.Construct();


                

                
            return ;

        }


}