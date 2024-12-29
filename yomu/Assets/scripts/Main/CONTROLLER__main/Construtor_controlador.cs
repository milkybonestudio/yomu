using System;
using System.Threading;
using UnityEngine;


public static class Construtor_controlador {


        public static void Construir( CONTROLLER__main controlador ){

            CONTROLLER__main.instancia = controlador;


                // --- SET THREAD
                if( Thread.CurrentThread.Name == null )
                    { Thread.CurrentThread.Name = "Main"; }

                Dados_fundamentais_sistema.jogo_ativo = true;
                    
                controlador.canvas = GameObject.Find( "Tela/Canvas" );

                // --- SETTINGS

                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 60;
                Application.runInBackground = true;

                CONSTRUCTOR__paths_system.Construct();


                // --- CONSTRUIR CONTROLADORES GERAIS

                
                controlador.controlador_tasks = CONSTRUCTOR__controller_tasks.Construct();                
                controlador.controlador_audio = CONSTRUCTOR__controller_audio.Construct();
                controlador.controlador_input = CONSTRUCTOR__controller_input.Construct();


                CONSTRUCTOR__controller_data.Construct();
                CONSTRUCTOR__controller_configurations.Construct();
                CONSTRUCTOR__controller_errors.Construct();
                CONSTRUCTOR__controller_resources.Construct();

                CONSTRUCTOR__controller_items.Construct();
                

                controlador.controlador_development = Construtor_controlador_development.Construir();  

                // --- VERIFICAR DESENVOLVIMENTO ** so pode ativar no editor
                if( controlador.controlador_development.Aplicar_teste())
                    { return ; } 

            
                // --- VERIFICAR ARQUIVO DE SEGURANCA
                if( !!!( Gerenciador_seguranca_main.Garantir_arquivo_de_seguranca()) )
                        { return ; } // --- PRECISA RECONSTRUIR


                
                //mark
                // ** ativar depois
                // controlador.login = Login.Construir();

                
            return ;

        }


}