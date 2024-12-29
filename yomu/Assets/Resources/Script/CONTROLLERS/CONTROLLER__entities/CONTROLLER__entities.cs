using System;



public abstract unsafe class CONTROLLER__entities<Entity>{ 


            public void Put_information( int _fundamental_length, int _generic_length ){

                    fundamental_length = _fundamental_length;
                    generic_length = _generic_length;
                    
            }

            public void Put_data_managers( CONTAINER__entities<Entity> _container_entities, ENTITIES__manager_save_data _manager_save_data, ENTITIES__run_time_saver _run_time_saver, ENTITIES__loader _loader ){

                    container_entities = _container_entities;
                    manager_save_data = _manager_save_data;
                    run_time_saver = _run_time_saver;
                    loader = _loader;

            }

            public void Put_heap_managers( ENTITIES__manager_heap _manager_heap, ENTITIES__manager_fized_size_heap _manager_fized_size_heap ){

                    manager_heap = _manager_heap;
                    manager_fized_size_heap = _manager_fized_size_heap;
                
            }


        // ** data

            public Entity Get( int _entity_id ){ return container_entities.Get( _entity_id ); }

            public CONTAINER__entities<Entity> container_entities;

            

            public int fundamental_length;
            public int generic_length;


        // ** modfy data

            public void Unload( int[] _entities ){ loader.Unload( _entities ); }

            protected ENTITIES__manager_save_data manager_save_data;
            protected ENTITIES__run_time_saver run_time_saver;
            protected ENTITIES__loader loader;


        // ** data heap

            protected ENTITIES__manager_heap manager_heap;
            protected ENTITIES__manager_fized_size_heap manager_fized_size_heap;

        
}



