using System;


public class Req_transicao {

    //** nivel bloco 
    public Dados_troca_UI dados_troca_UI;
    public Dados_troca_input dados_troca_input;


    public Bloco novo_bloco = Bloco.nada;
    
    public Tipo_transicao tipo_transicao = Tipo_transicao.cor; 
    public Tipo_troca_bloco tipo_troca_bloco = Tipo_troca_bloco.OUT;

    public bool pega_ui;

    //public Tipo_UI novo_tipo_UI;
    public bool[] UI_partes;



}


