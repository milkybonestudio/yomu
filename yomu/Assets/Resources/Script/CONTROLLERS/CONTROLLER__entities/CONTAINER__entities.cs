

public class CONTAINER__entities<Entity> {


        public CONTAINER__entities( int _number_entities ){ entities = new Entity[ _number_entities ]; }

        
        public virtual Entity Get( int _entity_id ){

            if( _entity_id >= entities.Length )
                { CONTROLLER__errors.Throw( $"Tried to get an item with the id { _entity_id }, but the length was { entities.Length }" ); }

            return entities[ _entity_id ];

        }

        public virtual Entity[] Get_entities( int[] _i ){ return null; }

        protected Entity[] entities;

}


