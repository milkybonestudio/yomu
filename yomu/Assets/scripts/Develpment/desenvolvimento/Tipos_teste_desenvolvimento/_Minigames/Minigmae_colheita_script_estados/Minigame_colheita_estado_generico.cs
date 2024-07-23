

public static class Minigame_colheita_estado_generico {



        public static void Ativar( string _modelo ){


                switch( _modelo ){

                        case "estado": Ativar_estado(); return;
                        case "script_inicial": Ativar_script_inicial(); return;
                        default: throw new System.Exception( $"nao foi aceito o modelo { _modelo }" );
                }


        }

        public static void Ativar_estado(){


                // --- construir personagem

                Posicao posicao = new Posicao();
                Atividade atividade = Atividade.nada;

                Personagem lily = new Personagem( ( int ) Personagem_nome.Lily , posicao, ( int ) atividade );

                Dados_containers_personagem dados_para_construir_personagem = new Dados_containers_personagem();

                Dados_blocos.minigames_START = new Minigame_START();
                
                // Controlador_dados_dinamicos.Pegar_instancia().perso.Carregar_personagem( lily );
                //Controlador_personagens.Pegar_instancia().personagens[ ( int ) Personagem_nome.Lily ] = lily;
                return;


        }


        public static void Ativar_script_inicial(){


                return;

        }



}