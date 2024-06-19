


public static class Teste_minigames {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 

                string[] k_v = _chave.Split( ":" );

                if( k_v.Length != 2 )
                        { throw new System.Exception( " chave minigame nao veio no formato => minigame : chave" ) ;}

                string minigame = k_v[ 0 ].Trim();
                string chave_minigame_especifico = k_v[ 1 ].Trim();
                


                switch( minigame ){

                        case "colheita" : Teste_minigame_colheita.Ativar( chave_minigame_especifico ); break;

                }

                // --- DEAULT


                // --- INICIAR
                Jogo.Pegar_instancia().bloco_atual = Bloco.minigames;
                BLOCO_minigames.Iniciar_bloco_minigames();
                return;
         

        }





}