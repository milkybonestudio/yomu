using System;
using System.Reflection;
using System.Threading;
using UnityEngine;



public static class CONSTRUCTOR__program {


        public static void Construir( Program _program ){

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

                CONSTRUCTOR__paths_system.Construct();
                


                // --- CONSTRUIR CONTROLADORES GERAIS


                // --- GENERIC

                    Controllers.errors =  CONSTRUCTOR__controller_errors.Construct();
                    Controllers.resources = CONSTRUCTOR__controller_resources.Construct();
                    Controllers.tasks = CONSTRUCTOR__controller_tasks.Construct();        
                    Controllers.input = CONSTRUCTOR__controller_input.Construct();
                    Controllers.audio = CONSTRUCTOR__controller_audio.Construct();
                    Controllers.configurations = CONSTRUCTOR__controller_configurations.Construct();
                
                    Controllers.data = CONSTRUCTOR__controller_data.Construct();
                    Controllers.items = CONSTRUCTOR__controller_items.Construct();


                    Controllers.cameras = CONSTRUCTOR__controller_cameras.Construct();

                // --- PROGRAM

                    Controllers_program.program = _program;
                    Controllers_program.program_transition = CONSTRUCTOR__controller_program_transition.Construct();
                    Controllers_program.data = CONSTRUCTOR__controller_program_data.Construct();
                        Controllers_program.data.Get_data();


            
                // --- VERIFICAR ARQUIVO DE SEGURANCA
                if( !!!( Gerenciador_seguranca_main.Garantir_arquivo_de_seguranca()) )
                        { return ; } // --- PRECISA RECONSTRUIR


                // --- CREATE MODES

                _program.modes = new PROGRAM_MODE[ ( int ) Program_mode.END ];

                Program_modes.login = new Login();
                Program_modes.menu = new Menu();
                Program_modes.game = new Game();

                _program.modes[ ( int ) Program_mode.login ] = Program_modes.login;
                _program.modes[ ( int ) Program_mode.menu ] = Program_modes.menu;
                _program.modes[ ( int ) Program_mode.jogo ] = Program_modes.game;

                _program.modes[ ( int ) Program_mode.nothing ] = new Nothing();
                _program.modes[ ( int ) Program_mode.test ] = new Test();

                _program.current_mode = Program_mode.nothing;


                // --- START

                #if UNITY_EDITOR

                    Type controller_development = ( Assembly.Load( "Development" ).CreateInstance( "CONTROLLER__development", false ) ).GetType();
                    _program.Update_development = ( Action<Control_flow> ) controller_development.GetMethod( "Get_update" ).Invoke( controller_development, null );
                    controller_development.GetMethod( "Apply_development_modifications" ).Invoke( controller_development, null );
                    
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