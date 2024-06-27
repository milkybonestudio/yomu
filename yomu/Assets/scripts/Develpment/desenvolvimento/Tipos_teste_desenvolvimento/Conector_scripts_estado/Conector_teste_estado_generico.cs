


public static class Conector_teste_estado_generico {


        public static void Ativar(){


                // --- construir personagem

                SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO_interativos_lista.Pegar_interativo( 0 , 0);

                Posicao_geral posicao_geral = new Posicao_geral();
                Atividade atividade = Atividade.nada;

                Personagem lily = new Personagem( ( int ) Personagem_nome.Lily , posicao_geral, ( int ) atividade );

                Dados_containers_personagem dados_para_construir_personagem = new Dados_containers_personagem();

                Dados_blocos.conector_START = new Conector_START();
                
                // Controlador_dados_dinamicos.Pegar_instancia().perso.Carregar_personagem( lily );
                //Controlador_personagens.Pegar_instancia().personagens[ ( int ) Personagem_nome.Lily ] = lily;
                return;




        }


}