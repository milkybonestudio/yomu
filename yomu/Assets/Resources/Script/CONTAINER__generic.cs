

using System;
using UnityEngine;



public class exemplo {}

public class CONTAINR_GENERICO_exemplo : CONTAINER__generic<exemplo> {

        public override void Reset_data( exemplo ex ){

            // ** change

        }

}



    // ** especifico vs generico: 
    /*

            // ** usar até que causae problemas 

            ir pegando sem usar 3_000 e extendendo:
                generico: +- 1250ms
                especifico: 11ms

            expandir e criar é uma merda

            pegar sem extender 30_000:
                generico: 25ms => 1_200k/seg ( varia muito 11ms - 30ms )
                especifico: 7ms => 4_300k/segundo

    */


#nullable enable

public class CONTAINER__generic<T> : CONTAINER where T : new() {

        // ** get é 5x mais rapido que generic
        // ** criacao é +- o mesmo tempo


        public CONTAINER__generic( int _start_length = 100 ){


                objects_available = new T[ _start_length ];
                
                for( int index = 0 ; index < objects_available.Length ; index++ )
                    { objects_available[ index ] = new T(); }
                    
                // --- CREATE WAITING
                objects_waiting_to_reset = new T[ 100 ];

                type_name = typeof( T ).ToString();

        }


        public void Set_size( int _length_to_add ){

                
                int old_length = objects_available.Length;
                Array.Resize( ref objects_available, objects_available.Length + _length_to_add );
                            
                while(  old_length++ < ( objects_available.Length - 1 )  )
                    { objects_available[ ( old_length - 1 ) ] = new T(); }

        }


        public virtual void Reset_data( T obj ){ CONTROLLER__errors.Throw( $"Need to override method Reset_data in the type { type_name }" ); }
 

        public int Get_length_array(){ return objects_available.Length; }

        public string type_name;
        private T[] objects_available;
        private T[] objects_waiting_to_reset;

                
        private int pointer_object_to_delete = 0;
        private int pointer_object_guaranty_is_null_before = -1;



        public T Get(){

               
                while(  pointer_object_guaranty_is_null_before++ < ( objects_available.Length - 1 )  ){

                        T ob = objects_available[ pointer_object_guaranty_is_null_before ];
                        if( ob == null )
                            { continue; }

                        objects_available[ pointer_object_guaranty_is_null_before ] = default( T? );

                        return ob;
                        
                }


                int old_length = objects_available.Length;
                Array.Resize( ref objects_available, objects_available.Length + 150 );
                            
                while(  old_length++ < ( objects_available.Length - 1 )  )
                    { objects_available[ ( old_length - 1 ) ] = new T(); }


                T new_object = objects_available[ pointer_object_guaranty_is_null_before ];
                objects_available[ pointer_object_guaranty_is_null_before ] = default(T?);

                return new_object;
            
        }


        public void Return_object( T _object ){

                if( objects_waiting_to_reset.Length == pointer_object_to_delete )
                    { Array.Resize( ref objects_waiting_to_reset, ( objects_waiting_to_reset.Length + 10  ) ); }



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
                while( _current_index++ < ( objects_available.Length - 1 ) ){

                        if( objects_available.GetValue( _current_index ) != null )
                            { continue; }
                        
                        objects_available.SetValue( _object, _current_index ) ;

                        if( pointer_object_guaranty_is_null_before > _current_index  )
                            { pointer_object_guaranty_is_null_before = _current_index; } // ** says that there is an obj here 

                        Reset_data( _object );
                        return 1;
                        
                }

                CONTROLLER__errors.Throw( $"tried to return a resource__structure but there was no space for it. <Color=lightRed>any object of the type { type_name }</Color> need to be created in the container with new-keyword. if the object was created here would have space" );
                return 0;

        }


}

