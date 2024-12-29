

public struct Enum_key {

    public string enum_name;
    public string field_name;

}




public class DEVELOPMENT_CONTAINER__enum {

        public DEVELOPMENT_CONTAINER__enum( string _name ){

                main_type = _name;

        }

        public string main_type;

        public Enum_key[] keys = new Enum_key[ 2_000 ];

        public void Add( int _enum_key, string _enum_name, string _field_name ){

                Enum_key key = keys[ _enum_key ];
                if( key.enum_name != null || key.enum_name != null )
                    { CONTROLLER__errors.Throw( $"tried to add the key { _enum_key }, enum { _enum_name } and item { _field_name }" ); }

                key.enum_name = _enum_name;
                key.field_name = _field_name;

                keys[ _enum_key ] = key; 

                return;
        }


        public Enum_key Get( int _key ){

                if( keys.Length >= _key )
                    { CONTROLLER__errors.Throw( $"Tried to get the key { _key }, but the length is { keys.Length }" ); }

                Enum_key key = keys[ _key ];

                if( ( key.enum_name == null ) || ( key.field_name == null ) )
                    { CONTROLLER__errors.Throw( $"Tried to get the key { _key }, but the enum_name is { key.enum_name } and the field name is { key.field_name }" ); }
            
                return key;
        }


}

