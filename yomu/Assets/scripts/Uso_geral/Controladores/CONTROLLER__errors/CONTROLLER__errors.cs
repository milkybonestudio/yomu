using System;



public class CONTROLLER__errors {

    public static CONTROLLER__errors instance;
    public static CONTROLLER__errors Get_instance(){ return instance; }

    public bool is_checking_pointer_length = true;
    public bool is_checking_dll_data = true;

    public void Check_pointer_length( bool _check, string _message ){

        if( is_checking_pointer_length && _check )
            {
                // ** fazer depois 
                throw new System.Exception( "Error: " + _message );
            }

    }

    public void Check_dll_data( bool _check, string _message ){

        if( is_checking_dll_data && _check )
            {
                // ** fazer depois 
                throw new System.Exception( "Error: " + _message );
            }

    }


}

