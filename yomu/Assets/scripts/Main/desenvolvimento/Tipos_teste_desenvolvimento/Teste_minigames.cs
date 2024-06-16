


public static class Teste_minigames {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 

                string[] k_v = _chave.Split( ":" );
                string minigame = k_v[ 0 ].Trim();
                string chave_minigame_especifico = k_v[ 1 ].Trim();
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.minigame;

                switch( minigame ){

                        case "colheita" : Teste_minigame_colheita.Ativar( chave_minigame_especifico ); return;

                }

                // --- DEAULT

                return;
         

        }





}