

using System;
using UnityEngine;


#nullable enable


public class CONTAINER__generic<T> : CONTAINER where T : new() {

        // ** get é 5x mais rapido que generic
        // ** criacao é +- o mesmo tempo


        public int id_intern_editor;


        public CONTAINER__generic( int _start_length = 100 ){


                id_intern_editor = Editor_information.play_count;

                expand_length = _start_length * 2;

                objects_available_struct = new Intern_object[ _start_length ];
                
                for( int index = 0 ; index < objects_available_struct.Length ; index++ )
                    { 
                        objects_available_struct[ index ].intern_object = new T();
                        objects_available_struct[ index ].is_available = true;
                    }
                    
                // --- CREATE WAITING
                objects_waiting_to_reset = new T[ 100 ];

                type_name = typeof( T ).ToString();

        }

        private int expand_length;


        public void Set_size( int _length_to_add ){

                
                int old_length = objects_available_struct.Length;
                Array.Resize( ref objects_available_struct, ( old_length + _length_to_add ) );
                            
                while(  old_length++ < ( objects_available_struct.Length - 1 )  ){ 
                    objects_available_struct[ ( old_length - 1 ) ].intern_object = new T(); 
                    objects_available_struct[ ( old_length - 1 ) ].is_available = true; 
                }

        }


        public virtual void Reset_data( T obj ){ CONTROLLER__errors.Throw( $"Need to override method Reset_data in the type { type_name }" ); }
 

        public int Get_length_array(){ return objects_available_struct.Length; }

        public string type_name;


        private Intern_object[] objects_available_struct;


        private T[] objects_waiting_to_reset;

                
        private int pointer_object_to_delete = 0;
        private int pointer_object_guaranty_is_null_before = -1;


        //performance
        // ** criar struct?


        private struct Intern_object {

            public T intern_object;
            public bool is_available;


        }



        public T Get(){

                #if UNITY_EDITOR

                    if( id_intern_editor != Editor_information.play_count )
                        { 
                            Console.LogError( "id_intern_editor: " + id_intern_editor );
                            Console.LogError( "Editor_information.play_count: " + Editor_information.play_count );
                            CONTROLLER__errors.Throw( $"The container static <Color=lightBlue>{ type_name }</Color> did not reset" ); 
                        }

                #endif

               

               int length_to_go = ( objects_available_struct.Length - 1 );

                while(  pointer_object_guaranty_is_null_before++ < ( length_to_go )  ){

                        if( objects_available_struct[ pointer_object_guaranty_is_null_before ].is_available  )
                            { 
                                objects_available_struct[ pointer_object_guaranty_is_null_before ].is_available = false;
                                //mark
                                // ** o objeto ainda fica com a referencia interna, mas como is_available é false ele não vai ser acessado no container
                                // ** vai ser excluido de fato quando algum outro objeto for colocado no slot
                                return objects_available_struct[ pointer_object_guaranty_is_null_before ].intern_object;

                            }

                }




                int old_length = objects_available_struct.Length;

                Array.Resize( ref objects_available_struct, ( objects_available_struct.Length + expand_length ) );

                while(  old_length++ < ( objects_available_struct.Length - 1 )  ){ 

                    objects_available_struct[ ( old_length - 1 ) ].intern_object = new T();
                    objects_available_struct[ ( old_length - 1 ) ].is_available = true;

                }


                T new_object = objects_available_struct[ pointer_object_guaranty_is_null_before ].intern_object;

                    objects_available_struct[ pointer_object_guaranty_is_null_before ] = default;

                return new_object;
            
        }


        public void Return_object( T _object ){

                if( objects_waiting_to_reset.Length == pointer_object_to_delete )
                    { Array.Resize( ref objects_waiting_to_reset, ( objects_waiting_to_reset.Length + ( expand_length / 2 )  ) ); }



                objects_waiting_to_reset[ pointer_object_to_delete++ ] = _object;

        }


        public override int Update( int _weight_to_stop, int _current_weight ){
            

                int current_index = 0;

                for( int slot = 0 ; slot < pointer_object_to_delete ; slot++ ){

                        if( objects_waiting_to_reset[ slot ] == null )
                            { continue; }

                        _current_weight += Return_object_to_available(  objects_waiting_to_reset[ slot ], ref current_index );
                        
                        objects_waiting_to_reset[ slot ] = default( T? );
                        
                        if( _current_weight >= _weight_to_stop )
                            { return _current_weight; }

                        continue;
                    
                }

                return _current_weight;

        }



        private int Return_object_to_available( T _object, ref int _current_index  ){

                _current_index--;
                while( _current_index++ < ( objects_available_struct.Length - 1 ) ){

                        if( objects_available_struct[ _current_index ].is_available )
                            { continue; }

                        objects_available_struct[ _current_index ].is_available = true;
                        objects_available_struct[ _current_index ].intern_object = _object;


                        if( pointer_object_guaranty_is_null_before > _current_index  )
                            { pointer_object_guaranty_is_null_before = _current_index; } // ** says that there is an obj here 

                        Reset_data( _object );
                        return 1;
                        
                }

                CONTROLLER__errors.Throw( $"tried to return a resource__structure but there was no space for it. <Color=lightRed>any object of the type { type_name }</Color> need to be created in the container with new-keyword. if the object was created here would have space" );
                return 0;

        }


}





// --- EXEMPLO

public class exemplo {}

public class CONTAINR_GENERICO_exemplo : CONTAINER__generic<exemplo> {

        public override void Reset_data( exemplo ex ){

            // ** change

        }

}



    // ** especifico vs generico: 
    /*

            // ** com o novo formato fica +- 35 milhoes / segundo

            // ** quando um objeto é pequeno ele consegue até que ser bem rapido ( 12-5 milhoes / segundo )
            // ** mas se o objeto precisar instanciar outros objetos esse tempo é reduzido conforme o numero de instancias
            // ** acionar 4 arrays deixou em torno de 1 milhao / segundo
        

            // ** usar até que causae problemas 

            ir pegando sem usar 3_000 e extendendo:
                generico: +- 1250ms
                especifico: 11ms

            expandir e criar é uma merda

            pegar sem extender 30_000:
                generico: 25ms => 1_200k/seg ( varia muito 11ms - 30ms )
                especifico: 7ms => 4_300k/segundo

    */



