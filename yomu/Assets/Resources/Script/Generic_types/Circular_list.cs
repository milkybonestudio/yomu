using System;


public class Circular_list<T> {


    public Circular_list( string _name ){
        name = _name;
    }

    private string name;
    private T[] objects;
    private int current_element = 0;

    public T Get(){

        if( objects == null )
            { CONTROLLER__errors.Throw( $"Tried to get a element in the cirscular list { name } but there is no alements" ); }

        if( current_element == objects.Length )
            { current_element = 0; } // --- reset

        return objects[ current_element++ ];

    }

    public void Add_elements( T[] _elements ){

        if( objects != null )
            { CONTROLLER__errors.Throw( $"Tried to add_elements 2 times in the circular_list { name }" ); }
        
        if( _elements == null )
            { CONTROLLER__errors.Throw( $"Tried to add_elements in the circular_list { name } but the data is null" ); }

        if( _elements.Length == 0 )
            { CONTROLLER__errors.Throw( $"Tried to add_elements in the circular_list { name } but the data is empty ([].Length == 0) " ); }
        
        objects = _elements;
        
        return;
        
    }

    
}