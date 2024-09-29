

public class MODULE__controller_entities_data_manager {

        public MODULE__controller_entities_data_manager( Entity_type _entity_type, int _number_slots ){

            
            bin = new Bin( _number_slots: 20 ); // ** tem os dados para excluir no frame, mas nao necessariamente os dados completos
            slot_entidades_para_excluir = new Slot_entities_to_unload( _number_slots: 20 ); // vai guardar os ids
            //entities_activated = new Entities_container( _number_slots: 20 );
            modulo_buffer_stack = new MODULO__buffer_entidade( _entity_type );

        }


        public Bin bin; // ** tem os dados para excluir no frame, mas nao necessariamente os dados completos
        public Slot_entities_to_unload slot_entidades_para_excluir; // vai guardar os ids
        //public Entities_container entities_activated;
        public MODULO__buffer_entidade modulo_buffer_stack;


        public void Unload_entities( int[] _entidades ){ 

                //entities_activated.Remove_entities( _entidades );
                //System.Array.ForEach( _entidades, n => slot_entidades_para_excluir.Add_entity_id( n ) );

                return; 

        }

}
