

unsafe public static class TOOL__prepare_to_save_character {


        public static float Prepare_to_save_files_intern( CONTROLLER__characters _controller ){

                fixed ( Character* char_p = _controller.characters ){

                        // --- NAO TEM PERSONAGENS
                        if( !!!( _controller.slot_entidades_para_excluir.Have_entity() ) )
                            { return 0f; }

                        float tempo_maximo_ms = 5f;
                        float tempo_atual = 0f;

                        while( tempo_atual < tempo_maximo_ms ){

                                int personagem_id = _controller.slot_entidades_para_excluir.Get_entity_id();
                                if( personagem_id == 0 )
                                    { break; }

                                Character character = char_p[ personagem_id ];
                                File_to_save[] files = Create_files_to_save( character );
                                tempo_atual += _controller.bin.Add_files( files );
                                continue;
                                
                        }

                        return tempo_atual;

                }
                
        }

        public static File_to_save[] Create_files_to_save( Character character ){ 
            
            return null; 
            
        }




}