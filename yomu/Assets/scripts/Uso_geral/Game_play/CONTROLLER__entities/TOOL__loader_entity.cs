

unsafe public static class TOOL__loader_entity {


        //mark

        // ** load e unload sempre vão ser feitos em momentos que nao vão atrapalhar a thread
        // **     => troca de timeframes/dias
        // ** mesmo que eles tenham que pegar muita coisa em disco não importa


        // ** load => fisicamente carregar na memoria
        // ** add => virtualmente o sistema reconhece

        //** assumir que load e add estejam em momentos diferentes assume que o sistema possa reconhecer que esta carregando 

        // ** remove => virtualmente o sistema nao reconhece mais
        // ** unload => salva dados em disco

        // ** o sistema nunca faz o load sem ter completamente limpado o bin 
        // ** o sistema provavelmtne vai fazer load vai ser feito na multitread e add/remove na main

        // ** o maior problema é que coisas vao precisar limpar o bin. Mas sao coisas de segundo plano

        // ** unload tem varios processos 
        //         => passar dados unmanaged para managed
        //         => liberar espaço heap interno
        //         => 



        // --- CARACTER

        public static Character Load_character( CONTROLLER__entities _controller, int _character_id ){


                Character character = new Character();
                character.fundamental_data = &( _controller.fundamental_data.characters[ _character_id ] );

                // --- PEGAR PATHS

                string path_folder = System.IO.Path.Combine( Paths_sistema.path_folder__dados_save_personagens, _character_id.ToString() );
                string dados_path = System.IO.Path.Combine( path_folder, "fix.dat" );
                string dados_path_heap = System.IO.Path.Combine( path_folder, "heap.dat" );

                // --- VERIFICAR 
                Files.Guarantee_exists_editor( dados_path );
                Files.Guarantee_exists_editor( dados_path_heap );

                // --- CERREGAR DADOS
                byte[] dados = System.IO.File.ReadAllBytes( dados_path );
                byte[] dados_heap = System.IO.File.ReadAllBytes( dados_path_heap );


                // --- CHECA SE O ARQUIVO ESTA COM O TAMANHO CORRETO
                if( dados.Length != ( sizeof( Character_universal_data ) + ( character.fundamental_data -> specific_data_length ) + sizeof ( Character_system_data ) ) )
                        { throw new System.Exception(""); }


                // --- PEGAR POINTERS

                byte* character_fix_data = Get_pointer( dados.Length );
                byte* character_heap_data = Get_pointer( dados_heap.Length );
                    
                // --- PASSAR MANAGED => UNMANAGED
                fixed( byte* dados_p_inicial = dados ){ Coppy( ( byte* ) character_fix_data, dados_p_inicial, dados.Length ); }
                fixed( byte* dados_heap_p_inicial = dados_heap ){ Coppy( character_heap_data, dados_heap_p_inicial, dados.Length ); }

                // --- COLOCAR POINTERS
                    
                character.universal_data = ( Character_universal_data* )character_fix_data;
                character_fix_data += sizeof( Character_universal_data ); // --- AUMENTA POINTER                    
            
                character.system_data = ( Character_system_data* )character_fix_data;
                character_fix_data += sizeof( Character_system_data ); // --- AUMENTA POINTER 

                character.specific_data = ( Character_specific_data* )character_fix_data;
                        
                character.heap_pointer = ( void* )character_heap_data;

                // --- CARREGAR LOGICA



                                
                return character;

    
        }

        public static void Unload_character( CONTROLLER__entities _controller, int _character_id ){

                // virtual unload 



        }


       // --- CITY

        public static City Load_city( CONTROLLER__entities _controller, int _city_id ){


                City city = new City();
                city.fundamental_data = &( _controller.fundamental_data.cities[ _city_id ] );

                // --- PEGA PATH FOLDER
                string path_folder = System.IO.Path.Combine( Paths_sistema.path_folder__dados_save_cidades, _city_id.ToString() );

                // --- PEGA DADOS FIXOS
                    string dados_path = System.IO.Path.Combine( path_folder, "fix.dat" );
                    Files.Guarantee_exists_editor( dados_path );
                    byte[] dados = System.IO.File.ReadAllBytes( dados_path );

                    // --- CHECA SE O ARQUIVO ESTA COM O TAMANHO CORRETO
                    if( dados.Length != ( sizeof( City_universal_data ) + ( city.fundamental_data -> specific_data_length ) + sizeof ( City_system_data ) ) )
                            { throw new System.Exception(""); }


                    // --- PASSAR TODOS OS DADOS FIXOS
                    byte* city_fix_data = Get_pointer( dados.Length );
                    fixed( byte* dados_p_inicial = dados ){ Coppy( city_fix_data, dados_p_inicial, dados.Length ); }


                    // --- PEGA POITERS
                    
                        city.universal_data = ( City_universal_data* )city_fix_data;
                        city_fix_data += sizeof( City_universal_data ); // --- AUMENTA POINTER                    
                    
                        city.system_data = ( City_system_data* )city_fix_data;
                        city_fix_data += sizeof( City_system_data ); // --- AUMENTA POINTER 

                        city.specific_data = ( City_specific_data* )city_fix_data;
                        
                        
                // --- PEGA DADOS HEAP

                    
                    string dados_path_heap = System.IO.Path.Combine( path_folder, "heap.dat" );
                    Files.Guarantee_exists_editor( dados_path_heap );
                    byte[] dados_heap = System.IO.File.ReadAllBytes( dados_path_heap );
        
                    byte* city_heap_data = Get_pointer( dados_heap.Length );
                    city.heap_pointer = ( void* )city_heap_data;
                    fixed( byte* dados_heap_p_inicial = dados_heap ){ Coppy( city_heap_data, dados_heap_p_inicial, dados.Length ); }
                                
                return city;


    
        }



        public static void Coppy( byte* character, byte* b, int length ){

        
            byte* data_b_p = b;

            for( int  i = 0 ; i < length ; i++ ){

                    *character = *data_b_p;
                    data_b_p++;
                    character++;
            }


        }

    public static byte* Get_pointer( int _length ){ 
        // ** fazer o sistema depois
        // ** quando entregar um pointer o sistema vai guardar esse pointer e manter ele ativo até ser liberado

        return null; 
        
    }




}