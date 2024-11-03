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


                c =  CONTROLLER__resources.Get_instance();

                // image_ref = c.resources_images.Get_image_reference( Resource_context.Characters, "Lily", "Clothes/lily_clothes_body_1", Resource_image_content.texture );
                // image_ref.Load();


                // Debug.Log( "content: " + image_ref.image.current_content );
                // Debug.Log( "minimun: " + image_ref.image.level_pre_allocation_image );
                // Debug.Log( "stage_getting_resource: " + image_ref.image.stage_getting_resource );


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
                
                copy = c.resources_structures.Get_structure_copy( Resource_context.Characters, "Lily", locators, Resource_structure_content.nothing );
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

        public void Update() {

                
                
                
                CONTROLLER__resources.Get_instance().Update();
            
                //Console.Log_intervalado( "state: " + image_ref.image.current_content );
                controlador_tasks.Update();

                int i = 0;
                
                if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                    { i++; copy.Change_pre_alloc( Resource_structure_content.instance ); }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { i++; copy.Change_pre_alloc( Resource_structure_content.structure_data ); }

                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { i++; copy.Change_pre_alloc( Resource_structure_content.nothing ); }





                // ** up

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { i++; copy.Load(); }

                if( Input.GetKeyDown( KeyCode.W ) )
                    { i++; copy.Activate(); }
                
                if( Input.GetKeyDown( KeyCode.E ) )
                    { i++; copy.Instanciate( GameObject.Find( "Tela/Container_teste" ) ); }

                

                // ** down


                if( Input.GetKeyDown( KeyCode.A ) )
                    { i++; copy.Unload(); }

                if( Input.GetKeyDown( KeyCode.S ) )
                    { i++; copy.Deactivate(); }
                
                if( Input.GetKeyDown( KeyCode.D ) )
                    { i++; copy.Deinstanciate(); }


                // ** delete

                if( Input.GetKeyDown( KeyCode.Z ) )
                    { i++; copy.Delete(); }



                if( Input.GetKeyDown( KeyCode.X ) )
                    { i++; }

                

                if( i > 0 )
                    { 

                        
                        
                        Console.Clear();
                        Console.Log( "<Color=lightBlue>-------------------</Color>" );

                        if( copy.deleted )
                            {
                                Console.Log("copy deleted");
                            }
                            else
                            {
                                RESOURCE__structure str = copy.structure;
                                Console.Log( $"state: { copy.state }" );
                                Console.Log( $"actual_need_content: { copy.actual_need_content }" );
                                Console.Log( $"level_pre_allocation: { copy.level_pre_allocation }" );
                                Console.Log( $"structure_game_object: { copy.structure_game_object }" );

                                

                                if( copy?.structure_game_object != null )
                                    {
                                            Console.Log( $"     structure_game_object parent is container_to_instanciate: { copy.structure_game_object.transform.parent.gameObject == str.module_structures.manager.container_to_instanciate }" );
                                            Console.Log( $" structure_game_object is active : { copy.structure_game_object.activeInHierarchy }" );
                                    }



                                Console.Log( $"      str.actual_content: { str.actual_content }" );
                                Console.Log( $"      str.content_going_to: { str.content_going_to }" );
                                Console.Log( $"      str.stage_getting_resource: { str.stage_getting_resource }" );
                                Console.Log( $"      str.copies_deleted: { str.copies_deleted }" );
                                Console.Log( $"      str.copies_deleted: { str.copies_deleted }" );
                                Console.Log( $"      structure counts:" );
                                Console.Log( $"            str.count_places_being_used_nothing: { str.count_places_being_used_nothing }" );
                                Console.Log( $"            str.count_places_being_used_structure_data: { str.count_places_being_used_structure_data }" );
                                Console.Log( $"            str.count_places_being_used_instance: { str.count_places_being_used_instance }" );

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

