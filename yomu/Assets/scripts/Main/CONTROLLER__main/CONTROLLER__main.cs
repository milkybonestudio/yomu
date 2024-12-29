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





        UI_button_SIMPLE b_up;
        UI_text_container text_container;

        public void Start(){


                Console.Start();
            
                Dados_fundamentais_sistema.jogo_ativo = true; 
                Construtor_controlador.Construir( this ); 

                
                b_up = EXAMPLE_UI_button.Simple( GameObject.Find( "Tela/Container_teste/a" ) ); 
            
                text_container = EXAMPLE_UI_text_container.Simple( GameObject.Find( "Tela/Container_teste/EXAMPLE_text_container" ) ); 

                r_l = CONTROLLER__resources.Get_instance().resources_logics.Get_logic_reference( Resource_context.Characters, "LOGIC__lily_1", "Get_number", Resource_logic_content.method_info );

                    
        }   




        public bool aa = false;

        float ac = 1f;

        CONTAINER__UI_button_SIMPLE ccc = new CONTAINER__UI_button_SIMPLE();

        RESOURCE__logic_ref r_l;

    
        public void Update() {


                //Lettlece l = new();  


                //TOOL__resource_logic_testing.Test( ref r_l, new object[]{ 1, "a" } );


                // return;

        
                // if( Input.GetKeyDown( KeyCode.A ) )
                //     { text_container.Add_dimensions( 20f, 20f ); }

                
                // if( Input.GetKey( KeyCode.LeftArrow ) )
                //     { b_up.container.Move( -200f * Time.deltaTime , 0f ); ac *= 1.05f; }


                // if( Input.GetKey( KeyCode.RightArrow ) )
                //     { b_up.container.Move( 200f * Time.deltaTime, 0f ); ac += 1; }

                // if( Input.GetKey( KeyCode.UpArrow ) )
                //     { b_up.container.Move( 0f, 200f* Time.deltaTime ); ac *= 1.05f; }

                
                // if( Input.GetKey( KeyCode.DownArrow ) )
                //     { b_up.container.Move( 0f, -200f * Time.deltaTime); ac *= 1.05f; }



                // if( Input.GetKey( KeyCode.B ) )
                //     { text_container.Put_text( "abacataoooo<Color=lightBlue>AAAA</Color>ooooooooo", 0, Color.red ); }

                // if( Input.GetKey( KeyCode.V ) )
                //     { text_container.Put_text( "olha ssom que vai vir LOL", 0, Color.green ); }


                // if( Input.GetKey( KeyCode.P ) )
                //     { text_container.Change_type_construction( Type_writing_construction.fade ); }


                    

                // if( Input.GetKeyDown( KeyCode.U ) )
                //     { b_up.container.Add_scale( 0.5f ); }

                // if( Input.GetKeyDown( KeyCode.O ) )
                //     { b_up.container.Add_scale( -0.5f ); }



                // if( Input.GetKey( KeyCode.H ) )
                //     { b_up.container.Add_rotation_Z( 50f * Time.deltaTime ); }

                // if( Input.GetKey( KeyCode.J ) )
                //     { b_up.container.Add_rotation_X( 50f * Time.deltaTime ); }

                // if( Input.GetKey( KeyCode.K ) )
                //     { b_up.container.Add_rotation_Y( 50f * Time.deltaTime ); }


                
                return;


                CONTROLLER__input.instancia.Update();

                b_up.Update();

                text_container?.Update();

                // ** aqui seria o real, ver certo depois
                Process_weight p = new (){ weight = 10 };
                CONTROLLER__resources.Get_instance().Update( ref p );
                CONTROLLER__tasks.Pegar_instancia().Update();
                Console.Update();

            
                return; 

                try{ Update_interno(); } catch( Exception exp ){ Debug.LogError( "Tem que fazer um modo para mandar mensagem " ); }
                
            
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
                
        }

        

}

