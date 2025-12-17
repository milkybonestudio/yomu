using System.IO;


/*

    tanto pc quanto mobile usam o mesmo sistema graças ao bom deus

*/

/*

    difficulty: 

        berserk    - 999 pontos
        ss         - 500 - 998 pontos
        s          - 250 - 500 pontos   
        a          - 100 - 250 pontos
        b          - 60 - 100 pontos
        c          - 40 - 60 pontos
        d          - 20 - 40 pontos
        e          - 10 - 20 pontos
        f          - 0 - 10 pontos

*/



unsafe public struct Game_unchancheble_data {

        // ** pensar depois
        // ** no caso o sistema pode mudar, ele vai precisar pois a maior parte vai ser decidido durante o jogo

        public bool can_see_people_reactions;

}

public static class New_game_constructor {

        public static Game_unchancheble_data unchancheble_data;

        
        public static void Construct( int _save ){


                // ** isso iria precisar fazer as perguntas

                unchancheble_data = default;
                return;

        }

}