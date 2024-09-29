using System;


unsafe public static class TOOL__suport_entities {


        public static Generic_entity Get_generic_entity( Generic_entity*  ent_p , int length, int _id ){


                int low = 0;
                int high = ( length - 1 );

                while( low <= high ){

                    int mid_index = ( ( low + high ) / 2 );
                    int mid_value = ( ent_p + mid_index )->entity_id;

                    if( mid_value == _id )
                        { return *( ent_p + mid_index ); }

                    if( mid_value < _id )
                        { low  = ( mid_index + 1 ); }
                        else
                        { high = ( mid_index - 1 ); }

                    continue;

                }

                throw new Exception( "a" );


        }



        // garante que sempre sao novos
        public static void Add_generic_entities( Generic_entity*  current_data, int current_data_pointer,  Generic_entity*  new_data_p , int length ){

                // ** deixa sort
                QuickSort( new_data_p, length, 0, length );


                if( current_data_pointer + length >= current_data_pointer )
                    { throw new Exception("fazer resize"); }

                // passar os dados 

                
        }

        
        // garante que sempre sao novos
        public static void Add_generic_entity( Generic_entity*  current_data, int current_data_pointer, int _length_data,  Generic_entity  new_data ){


                if( current_data_pointer == _length_data )
                    { throw new Exception("fazer resize"); }
                

                int _id = new_data.entity_id;

                int low = 0;
                int high = current_data_pointer;

                // ver amanha

                while( low <= high ){

                    int mid_index = ( ( low + high ) / 2 );
                    int mid_value = ( current_data + mid_index )->entity_id;

                    if( mid_value == _id )
                        { *( current_data + mid_index ) = new_data; return; }

                    if( mid_value < _id )
                        { low  = ( mid_index + 1 ); }
                        else
                        { high = ( mid_index - 1 ); }

                    continue;

                }

                
        }




        // garante que sempre sao novos
        public static void Remove_generic_entities( Generic_entity*  current_data, int _length_data, Generic_entity*  _new_container,  int[] _entities_to_remove ){


                // for( int entity_index = 0 ; entity_index < _entities_to_remove.Length ; entity_index++ ){

                //         Remove_id_generic_entity_JUST_VALUE( current_data, current_data_pointer,  _length_data, _entities_to_remove[ entity_index ] );
                      
                // }

                // int pointer_dados_finais = 0;

                // for( int entidade = 0 ; entidade < current_data_pointer ; entidade++ ){

                //         int id = current_data[ entidade ].entity_id;

                //         if( id == 0 )
                //             { continue; }
                                                
                //         _new_container[ pointer_dados_finais ].entity_id = id;
                //         pointer_dados_finais++;
                //         continue;
                        
                // }
       
        }



        // garante que sempre sao novos
        public static void Remove_generic_entity( Generic_entity*  current_data, int current_data_pointer, int length,  int _entity_to_remove ){

                int valor_inicial = Remove_id_generic_entity_JUST_VALUE( current_data, current_data_pointer, length, _entity_to_remove );

                while( valor_inicial != current_data_pointer ){

                        // --- vai so movendo sempre 1 para a posicao anterior
                        ( current_data + valor_inicial )->entity_id = ( current_data + valor_inicial + 1 ) ->entity_id;
                        valor_inicial++;
                        continue;
                }

                
        }


        
        // garante que sempre sao novos
        private static int Remove_id_generic_entity_JUST_VALUE( Generic_entity*  current_data, int current_data_pointer, int _length, int _entity_to_remove ){


                int low = 0;
                int high = ( _length - 1 );

                while( low <= high ){

                    int mid_index = ( ( low + high ) / 2 );
                    int mid_value = ( current_data + mid_index )->entity_id;

                    if( mid_value == _entity_to_remove )
                        { ( current_data + mid_index )->entity_id = 0; return mid_index;}

                    if( mid_value < _entity_to_remove )
                        { low  = ( mid_index + 1 ); }
                        else
                        { high = ( mid_index - 1 ); }

                    continue;

                }

                throw new Exception("");


                
        }


        
        
        // --- INTERNAL
        
        private static void QuickSort(  Generic_entity* arr, int arr_length, int low, int high ){


            if ( low < high ){

                // Partition the array
                int pi = Partition( arr, arr_length, low, high );

                // Recursively sort elements before
                // partition and after partition
                QuickSort( arr, arr_length, low, pi - 1);
                QuickSort( arr, arr_length,  pi + 1, high);
            }

        }

        private static int Partition( Generic_entity* arr, int arr_length,  int low, int high ){


            int pivot = ( arr + high )->entity_id; // Choosing the last element as pivot
            int i = (low - 1); // Index of smaller element

            for (int j = low; j < high; j++)
            {
                // If current element is smaller than or
                // equal to the pivot
                if ( (arr + j)->entity_id <= pivot )
                {
                    i++; // increment index of smaller element
                    // Swap arr[i] and arr[j]
                    Swap( ( arr + i ), (arr + j) );
                }
            }

            // Swap arr[i + 1] and arr[high] (or pivot)
            Swap( ( arr + i + 1 ), (arr + high) );
            return i + 1;
        }

        private static void Swap( Generic_entity* a, Generic_entity* b){
            
            int temp = a->entity_id;
            a->entity_id = b->entity_id;
            b->entity_id = temp;
        }




}