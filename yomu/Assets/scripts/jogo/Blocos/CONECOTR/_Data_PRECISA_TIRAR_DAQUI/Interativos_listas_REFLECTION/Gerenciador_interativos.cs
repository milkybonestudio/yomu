using System;
using System.Reflection

public class Gerenciador_interativos {


    #if !UNITY_EDITOR

        public Interativo Pegar_interativo_DESENVOLVIMENTO( int _interativo_id ){

            // ** vai ser diferente em desenvolvimento e no final 

            int slot = ( _interativo_id / 100 );

            int interativo_id_no_slot = _interativo_id - ( 100 * slot );
            

            switch( slot ){
                //                                  CRIAR ASM DEF
                case 0 : return Assembly.Load( "Interativos_0_TO_9" ).GetType( "Interativos_lista_0" ).GetMethod("Pegar_interativos").Invoke( null , new System.Object[] { interativo_id_no_slot });
                default: throw new Exception( $"nao foi achado o interativo {_interativo_id} no gerenciador_interativos. Nao estava em nenhuma lista" );

            }

        }

    #endif




}