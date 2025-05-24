using System;


public enum Circular_list_handle_no_element {

    return_default,
    error,

}



public class Circular_list<T> {


        public Circular_list( string _name, Circular_list_handle_no_element _handle_no_elements ){

            type = typeof( T );
            handle_no_elements = _handle_no_elements;
            name = _name;

        }

        private Circular_list_handle_no_element handle_no_elements;
        private string name;

        public T Get(){

            if( number_used == 0 )
                { 
                    if( handle_no_elements == Circular_list_handle_no_element.error )
                        { CONTROLLER__errors.Throw( $"In the circular list { name }, was tried to get the first element, <Color=lightBlue>but none was added</Color>" );  }
                    
                    if( handle_no_elements == Circular_list_handle_no_element.return_default )
                        { return default; }

                    CONTROLLER__errors.Throw( $"Can not handle the type Circular_list_handle_no_element <Color=lightBlue>{ handle_no_elements }</Color>" ); 
                }

            if( current_element == number_used )
                { current_element = 0; } // --- reset

            return objects[ current_element++ ];

        }

        public T Add( T t ){

            if( number_used == objects.Length )
                { Array.Resize( ref objects, objects.Length + 10 ); }

            objects[ number_used++ ] = t;
            return t;
            
        }

        private T[] objects = new T[ 10 ];
        private int number_used = 0;
        private int current_element = 0;

        public Type type;
        

    
}