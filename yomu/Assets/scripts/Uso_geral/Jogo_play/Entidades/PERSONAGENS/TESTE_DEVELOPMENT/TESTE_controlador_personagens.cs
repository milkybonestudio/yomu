using System;


#if UNITY_EDITOR 


        public static class TESTE_controlador_personagens {

                public static void Construir_controlador(){


                // aqui todos os personagens exceto a nara vão ser instanciados como null
                
                        // precisa cuidadar para quando for por teste. 
                        // quando o sitema pedir para carregar um personagem ele nao pode ir para o normal

                        Controlador_personagens controlador = new Controlador_personagens();

                        // inicia somente com o player ativo
                        string[] personagens_nomes = Enum.GetNames( typeof( Personagem_nome ) );
                        controlador.dados_sistema_personagens_essenciais = new Dados_sistema_personagem_essenciais[ personagens_nomes.Length ];
                        Personagem[] personagens = new Personagem[ personagens_nomes.Length ];

                        //controlador.personagens_ativos = new int [ 20 ];


                        for( int per = 0 ; per < personagens_nomes.Length ; per++ ){ 

                                controlador.dados_sistema_personagens_essenciais[ per ] = new Dados_sistema_personagem_essenciais();
                                
                        }

                        int nara_id = ( int ) Personagem_nome.Nara;
                        
                        
                        controlador.personagens = personagens;
                        personagens[ nara_id ] = new Personagem( nara_id, new Locator_position(), ( int ) Atividade.nada );


                        Controlador_personagens.instancia = controlador;				
                        
                }

        }

#endif



