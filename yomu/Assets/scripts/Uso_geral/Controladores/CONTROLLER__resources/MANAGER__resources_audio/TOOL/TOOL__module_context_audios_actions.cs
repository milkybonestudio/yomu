using System;
using UnityEngine;
using UnityEngine.UI;

public static class TOOL__module_context_audios_actions {



        public static Sprite Get_sprite( RESOURCE__audio_ref _ref ){


                RESOURCE__audio image = _ref.image;
                
                CONTROLLER__errors.Verify(  !!!( image.single_image.used ),  "Called Get_sprite() but the image dont have the single_image data" );

                
                if( _ref.state != Resource_state.instanciated )
                    { Instanciate( _ref  ); }

                CONTROLLER__errors.Verify( ( image.single_image.sprite == null ), $"Sprite of the image { image.name } was null" );
                
                return image.single_image.sprite;

        }


        // --- DOWN

        // ** imagem vai ser deletada completamente 
        public static void Delete( RESOURCE__audio_ref _ref ){


                RESOURCE__audio image = _ref.image;

                // ** LOSE REF
                image.need_reajust = true;
                image.refs[ _ref.image_slot_index ] = null;

                TOOL__resource_audio.Decrease_count( image, _ref.actual_need_content ); 
                _ref.image.module_images.manager.container_image_refs.Return_image_ref( _ref );
                
                TOOL__module_context_audios.Update_resource_level( image );
                
                return;

        } 

        
        public static void Unload( RESOURCE__audio_ref _ref ){

                // ** VAI PARA O NADA

                Console.Log( "Veio Unload()" );
                CONTROLLER__errors.Verify( ( _ref.image == null ), $"Tried to Unload ref { _ref.identifire }, but the RESOURCE__audio is null" );

                if( _ref.state == Resource_state.nothing )
                    { return; } _ref.state = Resource_state.nothing;

                if( _ref.actual_need_content == Resource_audio_content.nothing )
                    { return; }

                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.nothing );

                TOOL__module_context_audios.Update_resource_level( _ref.image );

                return;            

        }

        public static void Deactivate( RESOURCE__audio_ref _ref ){

            // ** GO BACK TO MINIMUN

                // ** VAI PARA O NADA

                Console.Log( "Veio Deactivate()" );
                CONTROLLER__errors.Verify( ( _ref.image == null ), $"Tried to Deactivate ref { _ref.identifire }, but the RESOURCE__audio is null" );


                if( _ref.state <= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content == _ref.level_pre_allocation )
                    { return; }

                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.image );

                return;    


        }

        public static void Deinstanciate( RESOURCE__audio_ref _ref ){

            // ** FORCE TO GO TO activate if isntanciate

                Console.Log( "Veio Deinstanciate()" );
                CONTROLLER__errors.Verify( ( _ref.image == null ), $"Tried to Deactivate ref { _ref.identifire }, but the RESOURCE__audio is null" );


                if( _ref.state <= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_audio_content.sprite )
                    { return; }


                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.image );

                return;    

        }



        // --- UP

        // ** sinaliza que a imagem pode carregar o minimo 
        public static void Load( RESOURCE__audio_ref _ref ){


                Console.Log( "Veio Load()" );
                CONTROLLER__errors.Verify( ( _ref.image == null ), $"Tried to Load ref { _ref.identifire }, but the RESOURCE__audio is null" );


                Console.Log(  "_ref.state: " + _ref.state  );
                Console.Log(  "_ref.actual_need_content: " + _ref.actual_need_content  );

                if( _ref.state >= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content >= _ref.level_pre_allocation )
                    { return; }

            
                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.image );

                return;

        }

        // ** sinaliza que pode começar a pegar a texture
        public static void Activate( RESOURCE__audio_ref _ref ){


                Console.Log( "veio Activate()" );

                CONTROLLER__errors.Verify( ( _ref.image == null ), $"Tried to Activate ref { _ref.identifire }, but the RESOURCE__audio is null" );

                if( _ref.state >= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_audio_content.sprite )
                    { return; }


                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.sprite );

                TOOL__module_context_audios.Update_resource_level( _ref.image );
                
                return;

        }

    
        public static void Instanciate( RESOURCE__audio_ref _ref ){

                // ** FORCE TO CREATE SPRITE 


                Console.Log( "Veio Instanciate()" );

                CONTROLLER__errors.Verify( ( _ref.image == null ), $"Tried to Activate ref { _ref.identifire }, but the RESOURCE__audio is null" );

                Console.Log( "REF STATE: " + _ref.state );

                if( _ref.state == Resource_state.instanciated )
                    { return; } _ref.state = Resource_state.instanciated;

                            
                RESOURCE__audio image = _ref.image;
                MANAGER__resources_audios manager = image.module_images.manager;


                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.sprite );


                
                return;

        }


}