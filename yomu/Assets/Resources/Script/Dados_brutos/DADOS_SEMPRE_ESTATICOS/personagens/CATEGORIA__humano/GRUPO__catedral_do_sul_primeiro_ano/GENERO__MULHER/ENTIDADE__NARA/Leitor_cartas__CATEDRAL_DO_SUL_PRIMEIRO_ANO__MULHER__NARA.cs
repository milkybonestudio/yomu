using System;

public static class CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__nara{


        public static Carta_DADOS_DEVELOPMENT[] cartas;

        public static Carta_DADOS_DEVELOPMENT Pegar_carta( Carta_localizador _carta_localizador ){


                if( cartas == null )
                    {
                        Colocar_cartas();
                        Type tipo = typeof( CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__NARA__carta );
                        Verificador_cartas_DESENVOLVIMENTO.Verificar_cartas(  ref cartas );
                        // Marcador_de_nomes_DEVELOPMENT.Colocar_nome_cartas( tipo, cartas );

                    }



                int carta_id = _carta_localizador.carta_id;

                if( cartas[ carta_id ] == null )
                    { throw new System.Exception( $"nao foi achado a carta { ( CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__NARA__carta ) carta_id }" ); }


                return cartas[ carta_id ];

        }


    public static void Colocar_cartas(){

        int numero_maximo_de_cartas = System.Enum.GetNames( typeof( CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__NARA__carta ) ).Length; 

        cartas = new Carta_DADOS_DEVELOPMENT[ numero_maximo_de_cartas ];

        int index = 0 ;

        index = ( int ) CARTAS__HUMANO__CATEDRAL_DO_SUL_PRIMEIRO_ANO__MULHER__NARA__carta.nara_default ;

        //dados[ index ]

        return;

    }




}