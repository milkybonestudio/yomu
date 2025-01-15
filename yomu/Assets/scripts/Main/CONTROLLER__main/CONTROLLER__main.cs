using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Numerics;
using System.Diagnostics;



// ** talvez mudar para Program?


unsafe public class CONTROLLER__main : MonoBehaviour {



        public static CONTROLLER__main Pegar_instancia() { return instancia; }
        public static CONTROLLER__main instancia;

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

        public CONTROLLER__cameras controller_cameras;




        UI_button_SIMPLE b_up;
        UI_text_container text_container;

        public int[] teste;


        public void Start(){


                Console.Start();
            
                
                Dados_fundamentais_sistema.jogo_ativo = true; 
                Construtor_controlador.Construir( this ); 

                CONTROLLER__resources.Get_instance().resources_structures.container_to_instanciate.SetActive( false );

                // ** pra testar é bom deixar aqui, se tiver algum erro e nao tiver auqi vai travar quando tentar setar o contexto
                
                // b_up = EXAMPLE_UI_button.Simple( GameObject.Find( "Tela/Container_teste/a" ) ); 
            
                // text_container = EXAMPLE_UI_text_container.Simple( GameObject.Find( "Tela/Container_teste/EXAMPLE_text_container" ) ); 

                // r_l = CONTROLLER__resources.Get_instance().resources_logics.Get_logic_reference( Resource_context.Characters, "LOGIC__lily_1", "Get_number", Resource_logic_content.method_info );


                //RESOURCE__structure_copy s_c = CONTROLLER__resources.Get_instance().resources_structures.Get_structure_copy(Resource_context.Characters, "Lily", "Clothes/Clothes_prefab", Resource_structure_content.game_object );

                // s_c.Instanciate( GameObject.Find( "Tela/Container_teste" ) );

                story_text_display =  new Golden_text_display_DOWN();


            //mark
            // ** a figure que esta sendo criada nao esta destruindo a texture, esta dando memory leak no editor


                                                                // what
                    // figure = Teste_figure.Construct().Set( GameObject.Find( "Container_teste" ) );

                    figure = Teste_figure.Construct();
                    figure.Prepare( Figure_mode_type.mad );

                    
        }   

        public Figure figure;   
        Story_text_display story_text_display;


        public bool aa = false;

        float ac = 1f;

        CONTAINER__UI_button_SIMPLE ccc = new CONTAINER__UI_button_SIMPLE();

        RESOURCE__logic_ref r_l;

    
        public void Update() {

                story_text_display.Update( null );

                if( Input.GetKeyDown( KeyCode.G ) )
                    { story_text_display .Instanciate( GameObject.Find( "Container_teste" ) ); }

                if( Input.GetKey( KeyCode.LeftArrow ) )
                    { story_text_display .Move( -50f, 0f, 0f ); }
                if( Input.GetKey( KeyCode.RightArrow ) )
                    { story_text_display .Move( 50f, 0f, 0f ); }



                // if( Input.GetKeyDown( KeyCode.J ) )
                //     { CONTROLLER__cameras.Get_instance().Switch_cameras( Camera_switch_type.fade, "Visual_novel" ); }


                if( Input.GetKeyDown( KeyCode.K ) )
                    { CONTROLLER__cameras.Get_instance().Switch_cameras( Camera_switch_type.fade, "Management" ); }


                // if( Input.GetKeyDown( KeyCode.L ) )
                //     { CONTROLLER__cameras.Get_instance().Switch_cameras( Camera_switch_type.fade, "Nothing" ); }

                if( Input.GetKeyDown( KeyCode.B ) )
                    { figure.Instanciate( Figure_mode_type.mad, GameObject.Find( "Container_teste" ) ); }
                    

                // if( Input.GetKeyDown( KeyCode.M ) )
                //     { figure.Get( Figure_mode_type.mad ).Speak( new Speak_data(){ loops = 10 } ); }


                if( Input.GetKeyDown( KeyCode.J ) )
                    { figure.Activate_emoji( Figure_emoji.heart ); }



                figure.Update();

                
            

                CONTROLLER__input.instancia.Update();

                b_up?.Update();

                text_container?.Update();

                // ** aqui seria o real, ver certo depois
                Process_weight p = new (){ weight = 10 };
                CONTROLLER__cameras.Get_instance().Update();
                CONTROLLER__resources.Get_instance().Update( ref p );
                CONTROLLER__tasks.Pegar_instancia().Update();
                Console.Update();

            
                return; 

                try{ Update_interno(); } catch( Exception exp ){ UnityEngine.Debug.LogError( "Tem que fazer um modo para mandar mensagem " ); }
                
            
        }


        public void Update_interno(){


                
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
                MANAGER__textures_resources.Clean_all();
                
        }

        

}


