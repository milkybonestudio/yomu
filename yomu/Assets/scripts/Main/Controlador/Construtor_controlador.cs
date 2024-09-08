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

                controlador.controlador_tasks = Controlador_tasks.Construir();                
                controlador.controlador_audio = Construtor_controlador_audio.Construir();
                controlador.controlador_input = Construtor_controlador_input.Construir();


                Construtor_controlador_cursor.Construir();
                Controlador_dados.Construir();
                Controlador_configuracoes.Construir();
                

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