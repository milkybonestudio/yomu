

using System;
using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Explicit)]
unsafe public struct Heap_key {

    [ FieldOffset( 0 ) ]
    public Heap_key_type type;

    [ FieldOffset( 4 ) ]
    public int unique_id;

    [ FieldOffset( 8 ) ]
    public Heap_key_UNIQUE unique_key;

    
    [ FieldOffset( 8 ) ]
    public Heap_key_FIX fix_key;


    [ FieldOffset( 8 ) ]
    public Heap_key_MANAGED_TYPE managed_key;



    public void* Get_pointer(){

        if( type == Heap_key_type.not_give )
            { CONTROLLER__errors.Throw( "Tried to get the pointer of a default heap_key" ); }

        void* ret_pointer = null;

        switch( type ){
            case Heap_key_type.fix: ret_pointer = fix_key.pointer; break;
            case Heap_key_type.unique: ret_pointer = unique_key.pointer; break;
            default: CONTROLLER__errors.Throw( $"can not handle type <Color=lightBlue>{ type }</Color>" ); break;
        }

        if( ret_pointer == null )
            { CONTROLLER__errors.Throw( $"Tried to get the pointer for a heap_key but it was null for the type <Color=lightBlue>{ type }</Color>" ); }
        
        return ret_pointer;

    }


    public int Get_length(){

        if( type == Heap_key_type.not_give )
            { CONTROLLER__errors.Throw( "Tried to get the length of a default heap_key" ); }

        int ret_length = default;

        switch( type ){
            case Heap_key_type.unique: ret_length = unique_key.length; break;
            default: CONTROLLER__errors.Throw( $"can not handle type <Color=lightBlue>{ type }</Color>" ); break;
        }

        if( ret_length == 0 )
            { CONTROLLER__errors.Throw( $"Tried to get the length for a heap_key but it was 0 for the type <Color=lightBlue>{ type }</Color>" ); }
        
        return ret_length;

    }



    // public void* pointer;

    // // ** não usa no fix
    // public Heap_size size;
    // public int heap_slot;


    public bool Is_valid(){ return ( type != Heap_key_type.not_give ); }
    

}


public enum Heap_key_type {

    not_give, 

    unique,
    fix,
    managed_type,


}


unsafe public struct Heap_key_UNIQUE {

    public IntPtr int_pointer;
    public void* pointer;
    public int length;
    
}



unsafe public struct Heap_key_FIX {

    public void* pointer;

    // ** não usa no fix
    public Heap_size size;
    public int heap_slot;
    

}

public enum Heap_key_managed_type{

    _string,

}

unsafe public struct Heap_key_MANAGED_TYPE {

    public Heap_key_managed_type managed_type;
    public int heap_slot;
    

}