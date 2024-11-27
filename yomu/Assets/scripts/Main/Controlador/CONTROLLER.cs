using System;
using System.Collections;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;



// ** talvez mudar para Program?


unsafe public class Controlador : MonoBehaviour {


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
        public CONTROLLER__UI controlador_UI;
        public CONTROLLER__input controlador_input;

        public CONTROLLER__tasks controlador_tasks;
        public CONTROLLER__audio controlador_audio;





        public void Start(){

                Console.Start();
            
                Dados_fundamentais_sistema.jogo_ativo = true;
                Construtor_controlador.Construir( this );
                

                // Dispositivo d = Dispositivo__teste.Construir(); // pega o prefab 
                // d.Define_all_components();  
                // //d.Load_resources();
                

                Botao_dispositivo botao = new Botao_dispositivo();
                Dados_botao_dispositivo dados = new Dados_botao_dispositivo();
                botao.data = dados;

                // ** colocar dados

                        dados.tipo_ativacao = Botao_dispositivo_tipo_ativacao.clicar;
                        dados.nome = "a";
                    

                TOOL__UI_button_getter.Get_data( botao, "Tela/Container_teste" );
                

        }


        public void Update() {




                Console.Update();

            
                return; 

                try{ Update_interno(); } catch( Exception exp ){ Debug.LogError( "Tem que fazer um modo para mandar mensagem " ); }
            
        }


        public void Update_interno() {


                controlador_audio.Update();

                CONTROLLER__data.Pegar_instancia().Atualizar_mouse_atual(); 
                controlador_input.Update();

                Console.Update();

            return;
                
                switch (  modo_controlador_atual ){
                        

                        case Controlador_modo.desenvolvimento: controlador_development.Update(); break; // --- SE EM DESENVOLVIMENTO : DESENVOLVIMENTO.UPDATE => MODO ESPECIFICO UPDATE

                        case Controlador_modo.jogo :  jogo.Update(); break;
                        case Controlador_modo.login :  login.Update() ; break;
                        case Controlador_modo.menu : menu.Update() ; break;

                        case Controlador_modo.reconstruindo_save : return;
                        //case Controlador_modo.transicao: console.log("esta no modo_tela transicao"); break;
                        

                }

                
                controlador_tasks.Update();
                return;
                
    
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

