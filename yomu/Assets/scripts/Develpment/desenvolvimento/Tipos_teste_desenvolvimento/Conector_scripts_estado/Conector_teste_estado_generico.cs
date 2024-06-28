using System;


public static class Conector_teste_estado_generico {


        public static void Ativar( string _modelo ){


                switch( _modelo ){

                        case "estado": Ativar_estado(); return;
                        case "script_inicial": Ativar_script_inicial(); return;
                        default: throw new Exception( $"nao foi aceito o modelo { _modelo }" );
                }


        }

        public static void Ativar_estado(){


                // --- construir personagem

                Posicao posicao = new Posicao();
                Atividade atividade = Atividade.nada;

                Personagem lily = new Personagem( ( int ) Personagem_nome.Lily , posicao, ( int ) atividade );

                Dados_containers_personagem dados_para_construir_personagem = new Dados_containers_personagem();

                Dados_blocos.conector_START = new Conector_START();
                
                // Controlador_dados_dinamicos.Pegar_instancia().perso.Carregar_personagem( lily );
                //Controlador_personagens.Pegar_instancia().personagens[ ( int ) Personagem_nome.Lily ] = lily;
                return;


        }


        public static void Ativar_script_inicial(){


                Posicao_local posicao_local = new Posicao_local();

                posicao_local.cidade_id = ( int ) Cidade_nome.saint_land;
                posicao_local.regiao_id = ( int ) SAINT_LAND__regiao.cathedral;
                posicao_local.area_id = ( int ) SAINT_LAND__CATEDRAL__area.dormitorio_feminino;
                posicao_local.ponto_id = ( int ) SAINT_LAND__CATEDRAL__FEMALE_DORMITORY_ponto.NARA_ROOM__up;


                Interativo_tela interativo = Controlador_interativos.Pegar_instancia().construtor_interativos.Criar_interativo_tela_DEVELOPMENT( posicao_local , ( ( int ) SAINT_LAND__CATEDRAL__FEMALE_DORMITORY_interativo.NARA_ROOM__up__espelho) );
                UnityEngine.Debug.Log( interativo );


        }


}