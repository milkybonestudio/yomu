

using System;
using UnityEngine;




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


public abstract class CONTAINER__generic : CONTAINER {


        public void Start( int _start_length ){

                objects_available = Array.CreateInstance( type, _start_length );
                for( int index = 0 ; index < objects_available.Length ; index++ )
                    { objects_available.SetValue( Activator.CreateInstance( type ), index ); }
                    
                // --- CREATE WAITING
                objects_waiting_to_reset = Array.CreateInstance( type, 100 );

        }


        public int Get_length_array(){ return objects_available.Length; }

        public Type type;
        private Array objects_available;
        private Array objects_waiting_to_reset;

                
        private int pointer_object_to_delete = 0;
        private int pointer_object_guaranty_is_null_before = -1;



        public object Get(){

               
                while(  pointer_object_guaranty_is_null_before++ < ( objects_available.Length - 1 )  ){

                        object ob = objects_available.GetValue( pointer_object_guaranty_is_null_before );
                        if( ob == null )
                            { continue; }


                        objects_available.SetValue( null, pointer_object_guaranty_is_null_before );

                        return ob;
                        
                }


                Array new_array = Array.CreateInstance( type, ( objects_available.Length + 150 ) );
                Array.Copy( objects_available, new_array, objects_available.Length  );

                int old_length = objects_available.Length;

                objects_available = new_array;
                

                while(  old_length++ < ( objects_available.Length - 1 )  )
                    { objects_available.SetValue( Activator.CreateInstance( type ), ( old_length - 1 ) ); }


                object new_object = objects_available.GetValue( pointer_object_guaranty_is_null_before );
                objects_available.SetValue( null, pointer_object_guaranty_is_null_before );
            
                return new_object;
            

        }


        public void Return_object( object _object ){


                if( objects_waiting_to_reset.Length == pointer_object_to_delete )
                    { 
                        
                        Array new_array = Array.CreateInstance( type, ( objects_waiting_to_reset.Length + 10 ) );
                        Array.Copy( objects_waiting_to_reset, new_array, objects_waiting_to_reset.Length  );
                        objects_waiting_to_reset = new_array;

                    }



                objects_waiting_to_reset.SetValue(  _object, pointer_object_to_delete++ );

        }


        public override int Update( int _weight_to_stop, int _current_weight ){
            

                int current_index = 0;

                for( int slot = 0 ; slot < pointer_object_to_delete ; slot++ ){

                        if( objects_waiting_to_reset.GetValue( slot ) == null )
                            { continue; }

                        _current_weight += Return_object_to_available( objects_waiting_to_reset.GetValue( slot ), ref current_index );
                        objects_waiting_to_reset.SetValue( null, slot );

                        if( _current_weight >= _weight_to_stop )
                            { return _current_weight; }

                        continue;
                    
                }

                return _current_weight;

        }



        private int Return_object_to_available( object _object, ref int _current_index  ){

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

                CONTROLLER__errors.Throw( $"tried to return a resource__structure but there was no space for it. <Color=lightRed>any object of the type { type }</Color> need to be created in the container with new-keyword. if the object was created here would have space" );
                return 0;

        }


}

