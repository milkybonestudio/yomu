using System;
using System.Threading;
using UnityEngine;


public static class Construtor_controlador {


        public static Controlador Construir(){

            Controlador controlador = new Controlador();
            Controlador.instancia = controlador;


                // --- SET THREAD
                if( Thread.CurrentThread.Name == null )
                    { Thread.CurrentThread.Name = "Main"; }

                Dados_fundamentais_sistema.jogo_ativo = true;
                    
                controlador.canvas = GameObject.Find( "Tela/Canvas" );

                // --- SETTINGS

                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 60;
                Application.runInBackground = true;


                // --- CONSTRUIR CONTROLADORES GERAIS

                Controlador_cache.Construir();

                controlador.controlador_tasks = CONSTRUCTOR__controller_tasks.Construct();                
                controlador.controlador_audio = CONSTRUCTOR__controller_audio.Construct();
                controlador.controlador_input = CONSTRUCTOR__controller_input.Construct();


                Construtor_controlador_cursor.Construir();
                CONSTRUCTOR__controller_data.Construct();
                CONSTRUCTOR__controller_configurations.Construct();
                CONSTRUCTOR__controller_errors.Construct();
                

                controlador.controlador_development = Construtor_controlador_development.Construir();  

                // --- VERIFICAR DESENVOLVIMENTO ** so pode ativar no editor
                if( controlador.controlador_development.Aplicar_teste())
                    { return controlador; } 

            
                // --- VERIFICAR ARQUIVO DE SEGURANCA
                if( !!!( Gerenciador_seguranca_main.Garantir_arquivo_de_seguranca()) )
                        { return controlador; } // --- PRECISA RECONSTRUIR


                
                //mark
                // ** ativar depois
                // controlador.login = Login.Construir();

                
            return controlador;

        }


}