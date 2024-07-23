


public static class Colocar_UI_bloco_conector {

    public static void Default(){

            Req_mudar_UI novo_UI = new Req_mudar_UI() ;

            novo_UI.UI_partes = new bool[3];


            novo_UI.UI_partes[ ( int ) In_game_UI_partes.todas ] = false ;
            novo_UI.UI_partes[ ( int ) In_game_UI_partes.barra_superior ] = true ;
            novo_UI.UI_partes[ ( int ) In_game_UI_partes.pergaminho ] = false ;

            novo_UI.novo_tipo_UI = Tipo_UI.in_game;
            novo_UI.instantaneo = false;

            Dados_blocos.req_mudar_UI = novo_UI ;


    }

}