using System;
using System.Collections;
using System.Threading;
using UnityEngine;



public class Controlador : MonoBehaviour {


        public static Controlador Pegar_instancia() { return instancia; }
        public static Controlador instancia;

        public Controlador_modo modo_controlador_atual;
        public static bool jogo_ativo = true;

        public GameObject canvas;


        // --- MODOS

        public Login login;
        public Menu menu;
        public Jogo jogo;


        // --- USO CONTROLADOR

        public Controlador_development controlador_development;
        public Controlador_UI controlador_UI;
        public Controlador_input controlador_input;

        public Controlador_tasks controlador_tasks;
        public Controlador_audio controlador_audio;
            

        public void Start(){

                Construtor_controlador.Construir();

        }


        public void Update() {

            
                foreach( KeyCode kc in Enum.GetValues( typeof( KeyCode ) ) ){

                    if( Input.GetKeyDown( kc ) )
                        { Debug.Log( kc ); }

                }

                try{ Update_interno(); } catch( Exception exp ){ Debug.LogError( "Tem que fazer um modo para mandar mensagem " ); }
            
        }


        public void Update_interno() {

            return;

            
                if( Input.GetKey( KeyCode.F1 ) && Input.GetKey( KeyCode.Escape ) ) 
                        { Application.Quit(); } 

                Console.Update();
                controlador_audio.Update();

                //Controlador_input.Update_mouse();
                Controlador_dados.Pegar_instancia().Atualizar_mouse_atual(); 

                
                switch (  modo_controlador_atual ) {
                        
                        case Controlador_modo.desenvolvimento: controlador_development.Update(); break;// --- SE EM DESENVOLVIMENTO : DESENVOLVIMENTO.UPDATE => MODO ESPECIFICO UPDATE

                        case Controlador_modo.jogo :  jogo.Update(); break;
                        case Controlador_modo.login :  login.Update() ; break;
                        case Controlador_modo.menu : menu.Update() ; break;

                        case Controlador_modo.reconstruindo_save : return;
                        case Controlador_modo.transicao: console.log("esta no modo_tela transicao"); break;
                        case Controlador_modo.nada:  break; 

                }


                controlador_input.Update();
                controlador_tasks.Update();
                
    
        }



        public void OnApplicationQuit(){
                
                #if !UNITY_EDITOR

                    Dados_fundamentais_sistema.jogo_ativo = false;
                    controlador_configuracoes.Salvar_configurations();

                #endif
                
        }


        public void OnDisable(){

                Dados_fundamentais_sistema.jogo_ativo = false;
                Jogo.Zerar_dados();
                
        }

        

}
