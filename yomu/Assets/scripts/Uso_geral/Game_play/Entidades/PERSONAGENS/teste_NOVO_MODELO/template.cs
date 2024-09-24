using System;
using System.Reflection;
using System.Runtime.InteropServices;




unsafe public class Character_template : INTERFACE__character {

        
        // managed-> 

            // --- CORE
            public INTERFACE__character_dll interface_core_1;

            // --- SCRIPTS
            public INTERFACE__character_dll interface_script_1;

            
        // unmanaged

            public Dll_checks dlls_chacks;


        
        public void Activate_script( int localizador, Character* _char, Buffer_dll* _buffer ){

                // ** script: 
                        // 1   byte: dll  
                        // 2   byte: type 
                        // 3/4 byte: id   
                
                Lily_scripts_dlls dll =  ( Lily_scripts_dlls ) (( localizador & 0b_1111_1111__0000_0000__0000_0000__0000_0000 ) >> 24 );
                    
                
                // ** managed

                    ref INTERFACE__character_dll interface_ref = ref interface_core_1;

                    switch( dll ){

                            case Lily_scripts_dlls.dll_1: interface_ref = interface_core_1; break;
                            default: throw new System.Exception( $"nao achou dll { dll }" );

                    }

                    if( interface_ref == null)
                        { interface_ref  = Loader_character_assembly.Get_dll( "Character_template", dll.ToString() ); }



                

                // unmanaged
        
                // ** isso ainda seria com seguranca porque tem o switch
                // ** poderia colocar diretamente no personagem mas teria que definir um maximo e escalar para todos os personagens 
                // ** teria que fazer algo como ( char->pointer_fn_1 + char->core_id ) -> fn()


                if( dlls_chacks.activates_dll[ ( int ) dll ] == 0 )
                    { /*load*/ }

            
                switch( dll ){

                    case Lily_scripts_dlls.dll_1: Dll_1_get( _char, _buffer ); break;
                    default: throw new System.Exception( $"nao achou dll { dll }" );

                }



        }


        // ** metodos essenciais

        public void Activate_core(  int _type, Character* _char, Buffer_dll* _buffer ){


            switch( ( Lily_core_dlls )( _char -> system_data ->core_logic_id ) ){

                case Lily_core_dlls.dll_1: Dll_core_1_get( _char, _type ); break;
                default: throw new System.Exception("a");

            }


        }

        // ** vai ir adicionando conforme for adicionando dlls

        // --- SCRIPTS

        [ DllImport("a") ]
        public static extern void Dll_1_get( Character* _char, Buffer_dll* _buffer );


        // --- CORE
        [ DllImport("a") ]
        public static extern Internal_pointer Dll_core_1_get( Character* _char, int _type );


}


// ** logicas menores para carregar mais rapido
// ** poderia deixar uma principal e quando tiver alguma outra carregar a parte
public enum Lily_scripts_dlls {

    dll_1,

}

public enum Lily_core_dlls {

    dll_1,

}






