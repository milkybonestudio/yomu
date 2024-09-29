
    public class Slot_entities_to_unload {

        public Slot_entities_to_unload( int _number_slots ){

            entidades_ids = new int[ _number_slots ];

        }

        public int[] entidades_ids;
        public int pointer_read;
        public int pointer_write;

        public bool Have_entity(){ 

            return ( pointer_write == pointer_read ); 

        }



        public void Add_entity_ids( int[] _entities ){


                if( ( pointer_write + _entities.Length ) > entidades_ids.Length )
                    { System.Array.Resize( ref entidades_ids, ( entidades_ids.Length + 20 + _entities.Length) ); }

                
                for( int i = 0 ; i < _entities.Length ; i++ ){

                    entidades_ids[ pointer_write++ ] = _entities[ i ];
                    return;

                }


        }
        
        public void Add_entity_id( int _entity_id ){

                if( pointer_write == entidades_ids.Length )
                    { System.Array.Resize( ref entidades_ids, ( entidades_ids.Length + 20) ); }

                entidades_ids[ pointer_write++ ] = _entity_id;
                return;

        }


        public int Get_entity_id(){

                if( pointer_read == pointer_write )
                    { return 0; }
                
                //** em teoria sempre vai ter um mas né
                while( pointer_read < pointer_write ){

                    if( entidades_ids[ pointer_read ] != 0 )
                        { return entidades_ids[ pointer_read++ ]; }
                        
                    pointer_read++;
                    continue;

                }

                return 0;

        }

        public void Clean(){ 

                pointer_read = 0; 
                pointer_write = 0; 
                return;

        }

    }
