
    public class Slot_entities {

        public int[] entidades_ids_para_excluir;
        public int pointer_read;
        public int pointer_write;

        public bool Have_entity(){ 

            return ( pointer_write == pointer_read ); 

        }

        
        public void Add_entity_id( int _entity_id ){

                if( pointer_write == entidades_ids_para_excluir.Length )
                    { System.Array.Resize( ref entidades_ids_para_excluir, ( entidades_ids_para_excluir.Length + 20) ); }

                entidades_ids_para_excluir[ pointer_write++ ] = _entity_id;
                return;

        }


        public int Get_entity_id(){

                if( pointer_read == pointer_write )
                    { return 0; }
                
                //** em teoria sempre vai ter um mas né
                while( pointer_read < pointer_write ){

                    if( entidades_ids_para_excluir[ pointer_read ] != 0 )
                        { return entidades_ids_para_excluir[ pointer_read++ ]; }
                        
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
