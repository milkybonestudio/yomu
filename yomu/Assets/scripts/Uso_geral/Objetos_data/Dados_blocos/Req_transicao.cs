using System;


public class Req_transicao {


        // tem que tirar os defaults 
    public Req_transicao(  Tipo_troca_bloco _tipo_troca_bloco ,  Bloco _novo_bloco = Bloco.nada,  Tipo_transicao _tipo_transicao = Tipo_transicao.cor , bool _pega_ui = false ){


            novo_bloco = _novo_bloco;
            tipo_troca_bloco = _tipo_troca_bloco;
            
            tipo_transicao = _tipo_transicao;
            pega_ui = _pega_ui;

            


            if( _tipo_troca_bloco == Tipo_troca_bloco.OUT ){ 

                    novo_bloco = Player_estado_atual.Pegar_instancia().Pegar_bloco_anterior();
                    bloco_para_excluir = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual(); 

        
            }

            
            if( tipo_troca_bloco == Tipo_troca_bloco.START ) {

                    novo_bloco = _novo_bloco;
                    bloco_para_excluir = Bloco.nada;
                    
            } 


            
    }


    public Bloco novo_bloco = Bloco.nada;
    public Bloco bloco_para_excluir = Bloco.nada;
    
    public Tipo_transicao tipo_transicao = Tipo_transicao.cor; 
    public Tipo_troca_bloco tipo_troca_bloco = Tipo_troca_bloco.OUT;

    public bool pega_ui;

    public Tipo_UI novo_tipo_UI;
    public bool[] UI_partes;



}


