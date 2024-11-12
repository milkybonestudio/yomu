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


        public CONTROLLER__resources c =  CONTROLLER__resources.Get_instance();
        public RESOURCE__image_ref image_ref;
        public RESOURCE__structure_copy copy;
        public RESOURCE__structure_copy copy_2;
        
 
        public void Start(){

                Console.Start();
            
                Dados_fundamentais_sistema.jogo_ativo = true;
                Construtor_controlador.Construir( this );

                void Create_character_images( Personagem_nome _personagem ){

                    // string path = Paths_system.Get_instance().Get_character_images_path__DEVELOPMENT( _personagem );
                    // Images_container_result container =  Images_container_creator.Construct( path );
                    // System.IO.File.WriteAllBytes( Paths_system.Get_instance().Get_character_images_container_path( _personagem ) );
                    
                }

                image = GameObject.Find( "Tela/Container_teste/Image" ).GetComponent<Image>();


                c =  CONTROLLER__resources.Get_instance();

                c.resources_images.Get_image_reference( Resource_context.Characters, "Lily", "Clothes/lily_clothes_body_1", Resource_image_content.nothing );
                image_ref = c.resources_images.Get_image_reference( Resource_context.Characters, "Lily", "Clothes/lily_clothes_body_1", Resource_image_content.sprite );
                

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


                Structure_locators locators = new Structure_locators();
                locators.main_struct_name = "Teste";
                
                //copy = c.resources_structures.Get_structure_copy( Resource_context.Characters, "Lily", locators, Resource_structure_content.nothing );
                //copy.Load();
                

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

        Image image;

        public void Update() {

                
                
                CONTROLLER__resources.Get_instance().Update();
            
                controlador_tasks.Update();

                int i = 0;

                // --- CHANGE PRE ALLOC


                if( Input.GetKeyDown( KeyCode.X ) )
                    { i++; }

                // --- UP

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { i++; image_ref.Load(); }

               if( Input.GetKeyDown( KeyCode.W ) )
                    { i++; image_ref.Activate(); }

               if( Input.GetKeyDown( KeyCode.E ) )
                    { i++; image.sprite = image_ref.Get_sprite(); }


                // --- DOWN


                if( Input.GetKeyDown( KeyCode.A ) )
                    { i++; image_ref.Unload(); }

               if( Input.GetKeyDown( KeyCode.S ) )
                    { i++; image_ref.Deactivate(); }

               if( Input.GetKeyDown( KeyCode.D ) )
                    { i++; image_ref.Deinstanciate(); image.sprite = null; }





               if( Input.GetKeyDown( KeyCode.I ) )
                    { i++; image.sprite = image_ref.image.single_image.sprite; }


                

                if( i > 0 )
                    { 

                    
                        Console.Clear();
                        Console.Log( "<Color=lightBlue>-------------------</Color>" );
                        Console.Log( "<Color=lightBlue>REF:</Color>" );


                        Console.Log( $" state: { image_ref.state } " );
                        Console.Log( $" actual_need_content: { image_ref.actual_need_content } " );
                        Console.Log( $" level_pre_allocation: { image_ref.level_pre_allocation } " );
                        Console.Log( $" ref_deleted: { image_ref.ref_deleted } " );
                        Console.Log( $" module: { image_ref.module } " );
                        Console.Log( $" image: { image_ref.image } " );
                        Console.Log( $" image_slot_index: { image_ref.image_slot_index } " );

                        RESOURCE__image image = image_ref.image;

                        if( image != null )
                            {
                                Console.Log( "<Color=lightBlue>  IMAGE:</Color>" );
                                Console.Log( $"   actual_content: { image.actual_content }" );
                                Console.Log( $"   content_going_to: { image.content_going_to }" );
                                Console.Log( $"   stage_getting_resource: { image.stage_getting_resource }" );

                                // -- image 

                                if( image.single_image != null )
                                    {

                                        if(  image.single_image.image_compress != null )
                                            { Console.Log( $"     image_compress.Length:  { image.single_image.image_compress.Length }" ); }


                                        Console.Log( $"     single_image.sprite: { image.single_image.sprite }" );

                                        if( image.single_image.texture_exclusiva != null )
                                            { Console.Log( $"     tamanho: { image.single_image.texture_exclusiva.width * image.single_image.texture_exclusiva.height }" ); }
                                
                                    }

                                Console.Log( $"     counts: " );
                                Console.Log( $"         image.count_places_being_used_nothing: { image.count_places_being_used_nothing }" );
                                Console.Log( $"         image.count_places_being_used_compress_low_quality_data: { image.count_places_being_used_compress_low_quality_data }" );
                                Console.Log( $"         image.count_places_being_used_compress_data: { image.count_places_being_used_compress_data }" );
                                Console.Log( $"         image.count_places_being_used_sprite: { image.count_places_being_used_sprite }" );
                            }
                        
                        


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

