


public class array<T>{


    private T[] intern_array;
    public int length;

    public T this[ int _index ]{

            get {

                if( _index >= length )
                    { CONTROLLER__errors.Throw( "a" ); }
                return intern_array[ _index ];

            } 
            set {

                
                if( _index >= length )
                    { CONTROLLER__errors.Throw( "a" ); }

                intern_array[ _index ] = value;
                

            }

    }

}


