


public static class Conector_teste_estado_generico {


        public static void Ativar( string _modelo ){

                if( _modelo == "estado" )
                        { 
                                Ativar_estado();  
                                return;
                        }

                Ativar_script_inicial();
                return;






        }

        public static void Ativar_estado(){


                // --- construir personagem

                Posicao_geral posicao_geral = new Posicao_geral();
                Atividade atividade = Atividade.nada;

                Personagem lily = new Personagem( ( int ) Personagem_nome.Lily , posicao_geral, ( int ) atividade );

                Dados_containers_personagem dados_para_construir_personagem = new Dados_containers_personagem();

                Dados_blocos.conector_START = new Conector_START();
                
                // Controlador_dados_dinamicos.Pegar_instancia().perso.Carregar_personagem( lily );
                //Controlador_personagens.Pegar_instancia().personagens[ ( int ) Personagem_nome.Lily ] = lily;
                return;


        }


        public static void Ativar_script_inicial(){


                Interativo_tela interativo = Controlador_interativos.Pegar_instancia().construtor_interativos.Criar_interativo_tela_DEVELOPMENT( new Posicao_local() , 0 );
                UnityEngine.Debug.Log( interativo );


        }


}