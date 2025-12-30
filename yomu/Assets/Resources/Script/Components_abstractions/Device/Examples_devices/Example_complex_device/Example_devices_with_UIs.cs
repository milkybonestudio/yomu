using UnityEngine;


// ** each device hava an enum, is easy to save/load
public enum Example_devices_with_UIs_types {

        // ** always have the not_give
        not_give,

        type_1,    
        type_2,

}



// ** in the used context will only have the interface
public abstract class Example_devices_with_UIs : Device {

        public Example_devices_with_UIs( string _name ) : base( _name ){}

        // ** sempre construir na classe de interface
        public static Example_devices_with_UIs Construct( Example_devices_with_UIs_types _type ){

                switch( _type ){

                    case Example_devices_with_UIs_types.type_1: return new Example_devices_with_UIs__TYPE_1();
                    case Example_devices_with_UIs_types.not_give: CONTROLLER__errors.Throw( "in <Color=lightBlue>Example_devices_with_UIs</Color> came as type NOT_GIVE" ); return null;

                    // ** never return a true default
                    default: CONTROLLER__errors.Throw( $"Can not handle type <Color=lightBlue>{ _type }</Color>" ); return null;
                }

        }
        


        // ** INTERFACE

            // ** always try to use more CANNOT_CHANGE than CAN_CHANGE than CHANGE
            
            public abstract void Implement_that_change_with_each_type( string _default_argument );

            public virtual void Implement_that_CAN_change_with_each_type( string _default_argument ){

                // ** default 

            }

            public void Implement_that_CANNOT_change_with_each_type( string _default_argument ){

                // ** only this

            }


        // ** METODOS GENERICOS

            public void Change_volume( float _new_volume ){}
            public void Change_full_screen(){}



        protected override void Force_active(){

            UIs_manager.Activate_all_UIs();

        }


}





public class Example_devices_with_UIs__TYPE_1 : Example_devices_with_UIs {


    // ** um tipo em especifico já sabe as coisas que ele precisa

    // ** se a UI for um pouco complicada faz mais sentido deixar em uma classe diferente que vai construir o objeto
    // ** provavelmente vai ser usado em outros lugares
    // ** porem uma imagem unica pode ser criado aqui
    


        public UI_visual_container image_left;
        public UI_visual_container image_right;
        public UI_visual_container image_back;


        public UI_button button_full_screen;
        public UI_button button_full_screen_2;
        public UI_button button_full_screen_3;

        public UI_text_container text_container;

        public Device_animation_simple_2_points animation_module;



        public Example_devices_with_UIs__TYPE_1() : base( "Example_devices_with_UIs__TYPE_1" ){

                
                CONTROLLER__resources resources = Controllers.resources;

                // structure = resources.structures.Get_structure_copy( Resource_context.Script, "Components_abstractions", "Device/Examples_devices/Example_complex_device/device_folder_1/device_folder_2/device", Resource_structure_content.game_object );
                structure = resources.structures.Get_structure_copy( Resource_context.Script, null, "device", Resource_structure_content.game_object );

                body.Set_body_constructor_data(new(){
                    need_anchour = true,
                    anchour_position = new Vector3( 1000f, 1000f, 1000f ),
                    // put_in_container = true,
                });

                

                animation_module = Device_animation_simple_2_points.Construct( this );

                    animation_module.value_1 = new Basic_transform(){
                                                                        position = new Vector3( 250f, 0f, 0f ),
                                                                        rotation = Quaternion.Euler( 45f, 45f, 45f ),
                                                                        scale = Vector3.one
                                                                    };

                    animation_module.value_0 = new Basic_transform(){
                                                                        position = new Vector3( 0f, 0f, 0f ),
                                                                        rotation = Quaternion.identity,                                                                    
                                                                        scale = Vector3.one
                                                                    };



                text_container = EXAMPLE_UI_text_container.Construct( null, "Text_container" );
                UIs_manager.Add( text_container, "others/text_container" );
                
    

                image_back = UI_visual_container.Get( "image_back" );
                UIs_manager.Add( image_back, "images/image_back" );

                    image_back.material_manager.Activate_mask( 500f, 500f );
                    image_back.Change_image( Resource_context.Script, "Components_abstractions", "Device/Examples_devices/Example_complex_device/device_folder_1/device_folder_2/image_back", Resource_image_content.compress_data );
                    image_back.body.Set_body_constructor_data(new(){
                        need_anchour = true,
                        anchour_position = Vector3.one
                    });


                image_left = UI_visual_container.Get( "image_left" );
                UIs_manager.Add( image_left, "images/image_left" );

                    image_left.Change_image( Resource_context.Script, "Components_abstractions", "Device/Examples_devices/Example_complex_device/device_folder_1/image_left", Resource_image_content.compress_data );
                    image_left.body.Set_body_constructor_data(new(){
                        need_anchour = true
                    });
                


                image_right = UI_visual_container.Get( "image_right" );
                UIs_manager.Add( image_right, "images/image_right" );

                    image_right.Change_image( Resource_context.Script, "Components_abstractions", "Device/Examples_devices/Example_complex_device/device_folder_1/image_right", Resource_image_content.compress_data );
                    image_right.material_manager.Activate_mask_position( 500f, 500f, image_back );
                    




                // --- GENERICO
    
                    // ** device nao se preocupa sobre como a parte visual do botao vai ser construida, somente com a implementacao das funcionalidades
                    button_full_screen = EXAMPLE_UI_button.Construct();
                    UIs_manager.Add( button_full_screen, "buttons/button_test_simple_cannot_change" );

                        // ** alguns metodos genericos podem ter a funcao na class da interface
                        // ** a a maior diferença entre implementaçoes for somente o visual a maioria vai ser assim
                        button_full_screen.Activate = Change_full_screen;
                        button_full_screen.Change_text( "Change_full_screen" );
                        button_full_screen.name = "button_full_screen";



                // --- GENERICO COM EXTENSAO
                    
                    button_full_screen_2 = EXAMPLE_UI_button.Construct() ;
                    UIs_manager.Add( button_full_screen_2, "buttons/button_test_simple_can_change" );

                        // ** as vezes a funcionalidade principal é a mesma mas ao interno tem que mudar 
                        // ** nesse caso vai ter um metodo interno que chama o metodo base + adiciona algo
                        button_full_screen_2.Activate = Change_full_screen_CHANGE;
                        button_full_screen_2.Change_text( "Change_full_screen_CHANGE" );
                        button_full_screen_2.body.name = "Change_full_screen_CHANGE";



                // --- UNICO
                    
                    button_full_screen_3 = EXAMPLE_UI_button.Construct(); 
                    UIs_manager.Add( button_full_screen_3, "buttons/button_test_simple_need_implementation" );

                        // ** as vezes um component fogue do generico
                        // ** nesse caso a funcao vai estar completamente dentro da classe 
                        button_full_screen_3.Activate = Complete_different_method;
                        button_full_screen_3.Change_text( "Complete_different_method" );
                        button_full_screen_3.name = "Complete_different_method";
                


        }


        // ** implementation

        public override void Implement_that_change_with_each_type( string _a ){

                Console.Log( "applicou metodo unico do tipo" );

        }

        public override void Implement_that_CAN_change_with_each_type( string _a ){

                base.Implement_that_CAN_change_with_each_type( _a );
                Console.Log( "Aplicou a extensao do metodo" );

        }



        protected override void Update_phase(){

                
                if( Input.GetKeyDown( KeyCode.Alpha7 ) )
                    { text_container.Put_text( "abce def ef j sha da sdkajs", 0, Cores.white ); }


                if( Input.GetKeyDown( KeyCode.Alpha6 ) )
                    { text_container.Change_type_construction( Type_writing_construction.fade ); }


                if( Input.GetKeyDown( KeyCode.Alpha5 ) )
                    { text_container.Change_type_construction( Type_writing_construction.instant ); }


                if( Input.GetKeyDown( KeyCode.LeftArrow ) )
                    { body.position.Add( -100f, 0f, 0f ); }

                if( Input.GetKeyDown( KeyCode.RightArrow ) )
                    { body.position.Add( 100f, 0f, 0f ); }



                if( Input.GetKeyDown( KeyCode.D ) )
                    { text_container.Add_dimensions( 50f, 50f ); }


                if( Input.GetKeyDown( KeyCode.N ) )
                    { body.anchour_rotation.Add( 50f, 0f, 0f ); }


                if( Input.GetKeyDown( KeyCode.M ) )
                    { body.anchour_rotation.Add( 0f, 50f, 0f ); }


                if( Input.GetKeyDown( KeyCode.B ) )
                    { body.anchour_rotation.Add( 0f, 0f, 50f ); }


                if( Input.GetKeyDown( KeyCode.V ) )
                    { body.anchour_rotation.Add( 20f, 20f, 20f ); }



                if( Input.GetKeyDown( KeyCode.V ) )
                    { body.anchour_rotation.Add( 20f, 20f, 20f ); }




                
                    
                if( Input.GetKeyDown( KeyCode.F ) )
                    { text_container.Resize( 200f, 200f ); }



                if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                    { animation_module.Change( 1 ); }


                if( Input.GetKeyDown( KeyCode.Alpha4 ) )
                    { animation_module.Change( 0 ); }



                image_left.body.anchour_position.Set( 5f, 0f, 0f );

                if( Input.GetKeyDown( KeyCode.A ) )
                    { image_back.material_manager.Add_mask( -100f, 0f ); }


                if( Input.GetKeyDown( KeyCode.S ) )
                    { image_back.material_manager.Add_mask( 100f, 0f ); }

                
            
        }


        public void Complete_different_method(){
            // ** things
        }

        public void Change_full_screen_CHANGE(){

            Change_full_screen();
            // ** something 

        }


 
}




// --- CONTEXT

// ** todo device precisa ser iniciado em algum contexto. se tiver alguma barra de texto em vn e em um minigame essa barra vai ser criada em cada contexto

public class Teste_exemple_device_CONTEXT_1 {

        private Example_devices_with_UIs menu_configuration;

        public void Create(){


                // ** situação para usar
                menu_configuration = Example_devices_with_UIs.Construct( Example_devices_with_UIs_types.type_1 );


        
        }


}

public class Teste_exemple_device_CONTEXT_2 {

        private Example_devices_with_UIs menu_configuration;

        public void Create(){


            // ** situação para usar
            menu_configuration = Example_devices_with_UIs.Construct( Example_devices_with_UIs_types.type_2 );


            

        }


}



