


public static class Teste_minigames {



        public static void Criar( string _chave ){


                string[] minigame_E_teste = _chave.Split( ":" );

                if( minigame_E_teste.Length != 2 )
                        { throw new System.Exception( $"A chave minigame <b><color=red>NAO</color></b> veio no formato => minigame : chave. Veio: <color=white>{ _chave }</color>" ) ;}

                string minigame = minigame_E_teste[ 0 ].Trim();
                string chave_minigame_especifico = minigame_E_teste[ 1 ].Trim();


                switch( minigame ){

                        case "colheita" : Teste_minigame_colheita.Criar( chave_minigame_especifico ); break;
                        default : UnityEngine.Debug.LogError($"<b><coler=red>nao</color></b> foi achado o <b><color=white>minigame: \"{ minigame }\"</color></b> em testar <b><color=lime>minigame</color></b>"); throw new System.Exception();

                }

                

                
        }

        


}