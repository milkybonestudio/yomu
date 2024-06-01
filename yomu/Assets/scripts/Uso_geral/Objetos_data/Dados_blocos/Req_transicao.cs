using System;


public class Req_transicao {

    public Req_transicao(  Tipo_troca_bloco _tipo_troca_bloco ,  Bloco _novo_bloco = Bloco.nada,  Tipo_transicao _tipo_transicao = Tipo_transicao.cor , bool _pega_ui = false ){



            this.novo_bloco = _novo_bloco;
            this.tipo_transicao = _tipo_transicao;
            this.tipo_troca_bloco = _tipo_troca_bloco;
            this.pega_ui = _pega_ui;

            


            if( _tipo_troca_bloco == Tipo_troca_bloco.OUT ){ 

                    this.novo_bloco = Player_estado_atual.Pegar_instancia().Pegar_bloco_anterior();
                    this.bloco_para_excluir = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual(); 

        
            } else 
            
            if(tipo_troca_bloco == Tipo_troca_bloco.START) {

                    this.novo_bloco = _novo_bloco;
                    this.bloco_para_excluir = Bloco.nada;
                    
            } else 
            
            if ( tipo_troca_bloco == Tipo_troca_bloco.SWAP ){

                    novo_bloco = _novo_bloco;
                    bloco_para_excluir = Player_estado_atual.Pegar_instancia().Pegar_bloco_atual();

            }



            
    }


    public Bloco novo_bloco = Bloco.nada;
    public Bloco bloco_para_excluir = Bloco.nada;
    
    public Tipo_transicao tipo_transicao = Tipo_transicao.cor; 
    public Tipo_troca_bloco tipo_troca_bloco = Tipo_troca_bloco.OUT;

    public bool pega_ui;

    public Tipo_UI novo_tipo_UI;
    public bool[] UI_partes;


    public Action start_transition_rise = () =>{};
    public Action end_transition_rise   = () =>{};
    public Action start_transition_down = () =>{};
    public Action end_transition_down   = () =>{};


}


