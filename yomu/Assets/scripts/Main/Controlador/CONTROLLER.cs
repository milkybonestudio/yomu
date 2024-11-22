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



        public RESOURCE__image_ref image_ref;

        public RESOURCE__structure_copy copy;
        public RESOURCE__structure_copy copy_2;

        public RESOURCE__audio_ref audio_ref;

 
        public void Start(){

                Console.Start();
            
                Dados_fundamentais_sistema.jogo_ativo = true;
                Construtor_controlador.Construir( this );

                //image = GameObject.Find( "Tela/Container_teste/Image" ).GetComponent<Image>();
                //image_ref = c.resources_images.Get_image_reference( Resource_context.Characters, "Lily", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
                

                // Dispositivo d = Dispositivo__teste.Construir(); // pega o prefab 
                // d.Define_all_components(); // 
                // d.Load_resources();
                
                // Dispositivo lily_clothes = Dispositivo__teste.Construir(); // pega o prefab 




                //mark
                // ** tem que fazer um jeito para começar no chao
                // ** como nao vai ter uma texture em si talvez tenha que fazer na mão, ou algum jeito para pegar todas as images ativas e fazer algum calculo com elas. 
                // ** por exemplo para colocar algo em cima da posicao inicial seria position_Y = localPosition.y + height/2 => vai meia height para cima
                // ** fazer com todas as textures pode representar a iamgem inteira
                // ** pegando o minimo e o maximo e depois assumindo ela como um grande bloco


                //audio_ref = CONTROLLER__resources.Get_instance().resources_audios.Get_audio_reference( Resource_context.Characters, "Lily", "teste", Resource_audio_content.nothing );

                TOOL__resource_image_testing.Start();
                TOOL__resource_structure_testing.Start();


                // Figure lily = Teste_figure.Construct();
                // lily.Instanciate( GameObject.Find( "Tela/Container_teste" ), Figure_use_context.visual_novel );
                
                // lily.Prepare_to_use_resources( "mad" );
                // lily.Change_form( "mad" );
                
                // Images_container_result container =  Images_container_creator.Construct( "C:\\Users\\User\\Desktop\\yomu_things\\teste" );

                // if( Verifier_image_container.Verify( "C:\\Users\\User\\Desktop\\yomu_things\\teste", System.IO.File.ReadAllLines("C:\\Users\\User\\Desktop\\yomu_things\\container.txt") ))
                //     {  Debug.Log( "Esta diferente" ); }
                

                //System.IO.File.WriteAllLines( "C:\\Users\\User\\Desktop\\yomu_things\\container.txt", container.localizadores );


                // foreach( string s in container.localizadores )
                //     { Debug.Log( s ); }
                


        }

        public void Update() {
                

                TOOL__resource_structure_testing.Test();
            
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

