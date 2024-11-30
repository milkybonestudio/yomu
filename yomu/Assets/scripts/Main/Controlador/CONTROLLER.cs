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



        Botao_dispositivo b_up;

        public void Start(){


                Console.Start();
            
                Dados_fundamentais_sistema.jogo_ativo = true;
                Construtor_controlador.Construir( this );

                
                // Dispositivo d = Dispositivo__teste.Construir(); // pega o prefab 
                // d.Define_all_components();  
                // //d.Load_resources();
                


                Botao_dispositivo botao = new Botao_dispositivo();
                botao.state = Resource_use_state.used;

                Dados_botao_dispositivo dados = new Dados_botao_dispositivo();
                dados.state = Resource_use_state.used;

                botao.data = dados;

                // ** colocar dados

                        dados.tipo_ativacao = Botao_dispositivo_tipo_ativacao.clicar;
                        dados.nome = "a";

                        dados.simple_button_OFF_frame.path = "a";
                        dados.OFF_and_ON_equal = true;
                        dados.tipo_transicao = DEVICE_button_transition_type_OFF_ON.cor;
                        dados.type = UI_button_type.simple;
                        dados.main_folder = "teste";
                        dados.text_on = "on";
                        dados.text_OFF_and_ON_equal = false;
                        dados.text_off = "off";

                        //dados.image_resource_pre_allocation = Resource_image_content.sprite;
                

                // ** get resources 
                botao.Define_button();

                // ** link to game_object
                GameObject botao_game_object = GameObject.Find( "Tela/Container_teste/a" );
                botao.Link_to_game_object( botao_game_object ); // precisa que struct esteja ativa

                // RESOURCE__structure_copy s_c = null;
                // botao.Get_data( s_c.Get_component_game_object( "botao" ) );


                botao.manager_resources.Load();


                
                botao.Activate_button();


                b_up = botao;


        }

        public bool aa = false;

        public void Update() {



                CONTROLLER__input.instancia.Update();
                b_up.Update();

                CONTROLLER__resources.Get_instance().Update();
                CONTROLLER__tasks.Pegar_instancia().Update();
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

