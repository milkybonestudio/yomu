using UnityEngine;

public static class Construtor_bloco_CARTAS {
    

        public static INTERFACE__bloco Construir( ){


                    // --- VERIFICAR SE O BLOCO JA NAO FOI CRIADO
                    if( BLOCO_cartas.instancia != null )
                        { throw new System.Exception( "Tentou iniciar o BLOCO_cartas mas a instancia não estava null" ); }


                    // --- TELA

                    BLOCO_cartas bloco = BLOCO_cartas.instancia;
                    BLOCO_cartas.instancia = bloco;


                    return ( INTERFACE__bloco ) bloco;

        }




}