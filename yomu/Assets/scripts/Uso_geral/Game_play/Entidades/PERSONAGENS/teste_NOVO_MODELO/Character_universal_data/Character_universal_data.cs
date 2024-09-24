
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;



unsafe public struct Character_universal_data {

        // ** sempre que os dados forem acessados 

        // --- posicao 
        public Locator_local_position local_position;
        public Locator_global_position* locator_global_position_pointer_; // o global fica nos dados essenciais 


        //** self
        public Character_physical_data character_physical_data; 
        public Character_psychological_data character_psychological_data; 


        // ** game data 
        public Character_system_data character_system_data;
        public Character_skills_data character_skills_data;



        // ** parte relacionamentos
        public Character_sexual_data character_sexual_data;
        public Character_romantic_relationships_data character_romantic_relationships_data;
        public Character_social_data character_social_data;
        public Character_political_data character_political_data;

        
               
            
        // ** things
        public Character_equipament_data character_equipament_data;
        public Character_room_data character_room_data;
        public Character_bank_data character_bank_data;



        //**



}




// ** fica dentro da dll
unsafe public interface INTERFACE__personagem_dll {

        public void Update( Character_universal_data* _universal_data_pointer, Character_specific_data* _specific_data );        
    

}





public static class Lily_logic {


        public static INTERFACE__personagem_dll Pegar( string dados ){

            // NativeArrayUnsafeUtility.GetUnsafePtr

                return Get();
                 

        }


        [ DllImport( "Lily_dll" ) ]
        public static extern INTERFACE__personagem_dll Get();


}


unsafe public class Character_general_logic {

    //mark
    // ** quando mudar para public excluir essa classe e colocar o plugin dentro de cada construtor

    public static INTERFACE__personagem_dll Get_dll( string _nome_personagem, byte[] _dados ){


            System.Reflection.Assembly asm = System.Reflection.Assembly.Load( $"{ _nome_personagem }_dll" );
            System.Type type =  asm.GetType( "Constructor" );
            System.Reflection.MethodInfo m_info =  type.GetMethod( "Construct");
            object obj = m_info.Invoke( null, new object[ 1 ]{ _dados } );

            return ( INTERFACE__personagem_dll ) obj ;


    }

}



unsafe public static class Get_character_raw_data {

    public static void Get_data( string _character_name ){

        return;

    }

}






unsafe public class Character_methods {

        public static void Update(){}

        public void Update( Character _character ){

            //_character.personagem_logica.Update( _character.universal_data_pointer, _character.specific_data );

        }
        
}





unsafe public class Lily_constructor {


        public int[] Get_types_size(){

            return null; 

        }


        public static Character Construct( Character* _dados_essenciais ){

            //if( (*_dados_essenciais). )


            return new Character();

            // Personagem retorno = new Personagem();

            //     string path_arquivo = Paths_sistema.Pegar_path_arquivo__dados_dinamicos__entidade( Tipo_entidade.personagem, "Lily" );

            //     if( System.IO.File.Exists( path_arquivo ) )
            //         { throw new System.Exception( $"Nao achou o arquivo no path { path_arquivo }" ); }           

            //     byte[] dados = System.IO.File.ReadAllBytes( path_arquivo );


            //     retorno.personagem_logica = Character_general_logic.Get_dll( "Lily", _dados );


            // return retorno;

        }


        public Character_universal_data* universal_data; 
        public Lily_specific_data* specific_data;

        private INTERFACE__personagem_dll personagem_dll;


        public Character_universal_data* Get_universal_data(){ return universal_data; } 


        // --- EXTERNAL

        // ** Get data
        public void Send_data( object data ){ /* ... */ }

        // ** Send data
        public object Get_data(){ return null;  }
        


}


