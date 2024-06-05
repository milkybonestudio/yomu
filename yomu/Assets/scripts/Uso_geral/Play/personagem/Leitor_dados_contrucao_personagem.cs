


public static class Leitor_dados_contrucao_personagem {


    public static Dados_para_construir_personagem Pegar( string _path_folder_dados_personagem, Dados_sistema_personagem _dados_sistema_personagem ){



            int tipo_armazenamento = _dados_sistema_personagem.tipo_armazenamento;
                        Personagem_nome personagem_nome = _dados_sistema_personagem.nome_personagem;


                        Dados_para_construir_personagem dados_retorno = new Dados_para_construir_personagem();

                        // [  header  ][ file_1 ][ file_2 ][ file_2 ]

                        if( tipo_armazenamento == 0 ){
                                // ** o compacto vai ser na realidade mais dificil, vale a pena por hora fazer todos com arquivos separados
                                // container compacto

                                // container compacto precisa descompactar 

                                throw new System.Exception( "nao era para vir aqui, tipo armazenamento 0 no personagem " + personagem_nome.ToString() );

                        }

                        if( tipo_armazenamento == 1 ){
                                // arquivos separados

                                // Tradutor_personagens_completo.Traduzir( controlador , path_dados_personagem );

                        }


                    
                        return dados_retorno;




    }



}