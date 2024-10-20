using System;
using System.Collections;
using System.Linq;
using System.Threading;
using UnityEngine;



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


        public CONTROLLER__resources c =  CONTROLLER__resources.Get_instance();
        public RESOURCE__image_ref image_ref;
 
        public void Start(){

                Console.Start();
            
                Dados_fundamentais_sistema.jogo_ativo = true;
                Construtor_controlador.Construir( this );

                void Create_character_images( Personagem_nome _personagem ){

                    // string path = Paths_system.Get_instance().Get_character_images_path__DEVELOPMENT( _personagem );
                    // Images_container_result container =  Images_container_creator.Construct( path );
                    // System.IO.File.WriteAllBytes( Paths_system.Get_instance().Get_character_images_container_path( _personagem ) );
                    
                }




                c =  CONTROLLER__resources.Get_instance();
                image_ref = c.resources_images.Get_image_reference( Resource_context.Characters, "Lily", "corredor", Resource_image_content.texture );
                image_ref.Load();

                // Debug.Log( "content: " + image_ref.image.current_content );
                // Debug.Log( "minimun: " + image_ref.image.level_pre_allocation_image );
                // Debug.Log( "stage_getting_resource: " + image_ref.image.stage_getting_resource );

                // Dispositivo d = Dispositivo__teste.Construir(); // pega o prefab 
                // d.Define_all_components(); // 
                // d.Load_resources();
                

                //Images_container_result container =  Images_container_creator.Construct( "C:\\Users\\User\\Desktop\\yomu_things\\teste" );

                // if( Verifier_image_container.Verify( "C:\\Users\\User\\Desktop\\yomu_things\\teste", System.IO.File.ReadAllLines("C:\\Users\\User\\Desktop\\yomu_things\\container.txt") ))
                //     {  Debug.Log( "Esta diferente" ); }
                

                //System.IO.File.WriteAllLines( "C:\\Users\\User\\Desktop\\yomu_things\\container.txt", container.localizadores );


                // foreach( string s in container.localizadores )
                //     { Debug.Log( s ); }
                


        }

        public void Update() {

    

                CONTROLLER__resources.Get_instance().Update();
            
                //Console.Log_intervalado( "state: " + image_ref.image.current_content );
                controlador_tasks.Update();

                if( Input.GetKeyDown( KeyCode.A ) )
                    {
                        Console.Log( $"count_places_being_used_compress_data: {image_ref.image.count_places_being_used_compress_data}" );
                        Console.Log( $"count_places_being_used_nothing: {image_ref.image.count_places_being_used_nothing}" );
                        Console.Log( $"count_places_being_used_texture: {image_ref.image.count_places_being_used_texture}" );

                    }


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

