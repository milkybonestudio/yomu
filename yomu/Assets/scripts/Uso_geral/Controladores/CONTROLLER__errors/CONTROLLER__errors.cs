using System;



public class CONTROLLER__errors {

    public static void Throw( string _message ){ Get_instance().Throw_intern( _message ); }
    public static void Verify( bool _bool , string _message ){ if( _bool ){ Get_instance().Throw_intern( _message ); } }
    public static void Throw_exception( Exception _exp ){ Get_instance().Throw_exception_internal( _exp ); }

    public static CONTROLLER__errors instance;
    public static CONTROLLER__errors Get_instance(){ return instance; }

    public bool is_checking_pointer_length = true;
    public bool is_checking_dll_data = true;

    private void Throw_intern( string _message ){

        throw new Exception( _message );

    }

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

    private void Throw_exception_internal( Exception _exp  ){

        // ** depois fazer melhor
        throw _exp;

    }


}

