using UnityEngine;
using UnityEngine.UI;


public static class TOOL__resource_image_testing {



        public static void Start(){

            string path = "Tela/Container_teste";

            canvas = GameObject.Find( path );
            if( canvas == null )
                { CONTROLLER__errors.Throw( $"Dond found the canvas for the RESOURCE__image test. Path:<Color=lightBlue> { path }</Color>" ); }

            image = IMAGE.Criar_imagem_filho( "imagem teste", out image_game_object, canvas );
            IMAGE.Resize( image_game_object, 500f, 500f );

            if( image == null )
                { CONTROLLER__errors.Throw( $"Dond found the iamge container for the RESOURCE__image test. Path: <Color=lightBlue>{ path }<Color>" ); } 


            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );
            
            image_ref = CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Teste", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );

        }

        private static GameObject canvas;
        private static GameObject image_game_object;
        private static RESOURCE__image_ref image_ref;
        private static Image image;



        public static void Test( Control_flow _control_flow ){


                CONTROLLER__resources.Get_instance().Update( _control_flow );
            
                CONTROLLER__tasks.Pegar_instancia().Update( _control_flow );

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

                
                if( Input.GetKeyDown( KeyCode.F ) )
                    { i++; image_ref.Delete(); image_ref = null;  }

                

                // --- CHANGE LEVEL PRE ALLOC
                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { i++; image_ref.Change_level_pre_allocation( Resource_image_content.nothing );  }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { i++; image_ref.Change_level_pre_allocation( Resource_image_content.compress_low_quality_data );  }

                
                if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                    { i++; image_ref.Change_level_pre_allocation( Resource_image_content.compress_data );  }

                if( Input.GetKeyDown( KeyCode.Alpha4 ) )
                    { i++; image_ref.Change_level_pre_allocation( Resource_image_content.sprite );  }




               if( Input.GetKeyDown( KeyCode.I ) )
                    { i++; image.sprite = image_ref.image.single_image.sprite; }



                if( i > 0 )
                    { Print_image_data( image_ref ); }

                Console.Update();



        }


        public static void Print_image_data( RESOURCE__image_ref _image_ref ){


                if( _image_ref == null )
                    { return; }

                RESOURCE__image image = _image_ref.image;

                Console.Clear();

                Console.Log( "<Color=lightBlue>-------------------</Color>" );
                Console.Log( "<Color=lightBlue>REF:</Color>" );


                Console.Log( $" state: { _image_ref.state } " );
                Console.Log( $" actual_need_content: { _image_ref.actual_need_content } " );
                Console.Log( $" level_pre_allocation: { _image_ref.level_pre_allocation } " );
                Console.Log( $" ref_state: { _image_ref.ref_state } " );
                Console.Log( $" module: { _image_ref.module } " );
                Console.Log( $" image: { _image_ref.image } " );
                Console.Log( $" image_slot_index: { _image_ref.image_slot_index } " );

                if( image == null )
                    {  return; }

                Console.Log( "<Color=lightBlue>  IMAGE:</Color>" );
                Console.Log( $"   actual_content: { image.actual_content }" );
                Console.Log( $"   content_going_to: { image.content_going_to }" );
                Console.Log( $"   stage_getting_resource: { image.stage_getting_resource }" );

                // -- image 

                if(  image.single_image.image_compress != null )
                    { Console.Log( $"     image_compress.Length:  { Formater.Format_number(  image.single_image.image_compress.Length ) }" ); }
                    else 
                    { Console.Log( $"     image_compress.Length:  " ); }
                    

                Console.Log( $"     tem low_quality: "  + image.single_image.have_low_quality_compress );
                if(  image.single_image.image_low_quality_compress != null )
                    { Console.Log( $"     image_low_quality_compress.Length:  {  Formater.Format_number( image.single_image.image_low_quality_compress.Length ) }" ); }
                    else
                    { Console.Log( $"     image_low_quality_compress.Length:  " ); }


                Console.Log( $"     single_image.sprite: { image.single_image.sprite }" );

                if( image.single_image.texture_exclusiva != null )
                    { Console.Log( $"     tamanho: { Formater.Format_number( image.single_image.texture_exclusiva.width * image.single_image.texture_exclusiva.height ) } px" ); }

                Console.Log( $"     counts: " );
                Console.Log( $"         image.count_places_being_used_nothing: { image.count_places_being_used_nothing }" );
                Console.Log( $"         image.count_places_being_used_compress_low_quality_data: { image.count_places_being_used_compress_low_quality_data }" );
                Console.Log( $"         image.count_places_being_used_compress_data: { image.count_places_being_used_compress_data }" );
                Console.Log( $"         image.count_places_being_used_sprite: { image.count_places_being_used_sprite }" );
            
                

        }


}