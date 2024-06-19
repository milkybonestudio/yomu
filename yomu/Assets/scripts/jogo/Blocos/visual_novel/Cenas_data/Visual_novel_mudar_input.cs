



public static class Visual_novel_mudar_input {


    public static void Default(){

        
            Req_mudar_input novo_input = new Req_mudar_input() ;

            novo_input.ativar_movimentacao_mouse = true;
            novo_input.cor_cursor = Cor_cursor.off;
            novo_input.tipo_teclado = Tipo_teclado.in_game;

            Dados_blocos.req_mudar_input = novo_input ;


    }



}