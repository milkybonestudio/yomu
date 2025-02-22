

public static class Cartas_teste_estado_generico {


        public static void Ativar( string _modelo ){


                switch( _modelo ){

                        case "estado": Ativar_estado(); return;
                        case "script_inicial": Ativar_script_inicial(); return;
                        default: throw new System.Exception( $"nao foi aceito o modelo { _modelo }" );
                }


        }

        public static void Ativar_estado(){


                // --- construir personagem

                Locator_position posicao = new Locator_position();
                Atividade atividade = Atividade.nada;
                return;


        }


        public static void Ativar_script_inicial(){


                return;

        }



}