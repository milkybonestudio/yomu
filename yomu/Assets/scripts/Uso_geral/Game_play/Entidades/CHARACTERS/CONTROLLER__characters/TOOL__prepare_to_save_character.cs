

unsafe public static class TOOL__prepare_to_save_character {


        // ** toda entidade tem fundamental data que sempre vai estar carregado 
        // ** esses dados vao ter pointer que vao levar ao dados originais      

        // generic?
        public static float Pass_unload_files_to_bin( CONTROLLER__characters _controller ){

                
                MODULE__controller_entities_data_manager data = _controller.data_manager;

                // --- NAO TEM PERSONAGENS
                if( !!!( data.slot_entidades_para_excluir.Have_entity() ) )
                    { return 0f; }

                float tempo_maximo_ms = 5f;
                float tempo_atual = 0f;

                while( tempo_atual < tempo_maximo_ms ){


                        int personagem_id = data.slot_entidades_para_excluir.Get_entity_id();
                        if( personagem_id == 0 )
                            { break; }

                        Character character = _controller.characters[ personagem_id ];
                        File_to_save[] files = Create_files_to_save( character );
                        tempo_atual += data.bin.Add_files( files );
                        continue;
                        
                }

                return tempo_atual;

                
        }


        public static File_to_save[] Create_files_to_save(  Character c ){ 
            
            // Character* ent = ( Character* ) character;
            
            return null; 
            
        }


        public static File_to_save[] Create_files_to_save(  void* v_p , Character character ){ 

            // Plot* ent = ( Plot* ) character;
             
            
            return null; 
            
        }





}



unsafe public static class Generic_unload_entities {


        // // ** toda entidade tem fundamental data que sempre vai estar carregado 
        // // ** esses dados vao ter pointer que vao levar ao dados originais      

        // // generic?
        // public static float Unload( float tempo_atual, MODULE__controller_entities_data_manager data ){

                
        //         if( !!!( data.slot_entidades_para_excluir.Have_entity() ) )
        //             { return 0f; }

        //         float tempo_maximo_ms = 5f;
                

        //         while( tempo_atual < tempo_maximo_ms ){


        //                 int personagem_id = data.slot_entidades_para_excluir.Get_entity_id();
        //                 if( personagem_id == 0 )
        //                     { break; }

        //                 Character character = _controller.characters[ personagem_id ];
        //                 File_to_save[] files = Create_files_to_save( character );
        //                 tempo_atual += data.bin.Add_files( files );
        //                 continue;
                        
        //         }

        //         return tempo_atual;

                
        // }


        // public static float Create_files_to_save(  void* entity_pointer, Bin _bin ){ 
            
        //     // Character* ent = ( Character* ) character;
            
        //     return 0f; 
            
        // }


        // public static File_to_save[] Create_files_to_save(  void* v_p , Character character ){ 

        //     // Plot* ent = ( Plot* ) character;
             
            
        //     return null; 
            
        // }





}