





public static class Conversas_teste_estado_generico {


        public static void Ativar(){


                // --- construir personagem

                Posicao_geral posicao_geral = new Posicao_geral();
                Atividade atividade = Atividade.nada;

                Personagem lily = new Personagem( ( int ) Personagem_nome.Lily , posicao_geral, ( int ) atividade );

                Dados_containers_personagem dados_para_construir_personagem = new Dados_containers_personagem();

                Dados_blocos.conversa_START = new Conversa_START();
                Dados_blocos.conversa_START.nome_personagem = "lily";
                Dados_blocos.conversa_START.conversa_nome = "teste";
                
                // Controlador_dados_dinamicos.Pegar_instancia().perso.Carregar_personagem( lily );
                //Controlador_personagens.Pegar_instancia().personagens[ ( int ) Personagem_nome.Lily ] = lily;
                return;




        }


}