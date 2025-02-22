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

                Locator_position posicao = new Locator_position();
                Atividade atividade = Atividade.nada;
                return;


        }


        public static void Ativar_script_inicial(){


                #if ( UNITY_EDITOR && CIDADE_SAINT_LAND ) || FORCAR_TODOS_OS_ESTADOS 



                Posicao posicao_local = new Posicao();

                posicao_local.cidade_no_trecho_id = ( int ) Cidade_nome.san_sebastian;
                posicao_local.regiao_id = ( int ) SAINT_LAND__regiao.cathedral;
                // posicao_local.area_id   = ( int ) SAINT_LAND__CATEDRAL__area.dormitorio_feminino;
                // posicao_local.ponto_id  = ( int ) SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__ponto.NARA_ROOM__up;



                Interativo_tela interativo = Construtor_interativos_DEVELOPMENT.Criar_interativo_tela_DEVELOPMENT( posicao_local , ( ( int ) SAINT_LAND__CATEDRAL__DORMITORIO_FEMININO__NARA_ROOM__UP__interativo.espelho ) );
                UnityEngine.Debug.Log( interativo );

                #endif

        }


}