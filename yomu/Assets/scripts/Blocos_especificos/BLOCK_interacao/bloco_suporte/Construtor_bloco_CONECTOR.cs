using UnityEngine;

public static class Construtor_bloco_INTERACAO {
    

        public static INTERFACE__bloco Construir(){


                    // --- VERIFICAR SE O BLOCO JA NAO FOI CRIADO
                    if( BLOCO_interacao.instancia != null )
                        { throw new System.Exception( "Tentou iniciar o BLOCO_interacao mas a instancia não estava null" ); }


                    // --- TELA

                    BLOCO_interacao bloco = new BLOCO_interacao();
                    BLOCO_interacao.instancia = bloco;

        
                    // -- CONTROLADORES

                    Construtor_controlador_tela_conector.Construir();
                    Construtor_controlador_interativos.Construir();
                    Controlador_movimento.Construir();

                    // --- COISAS
                    

                    return ( INTERFACE__bloco ) bloco;

        }


}