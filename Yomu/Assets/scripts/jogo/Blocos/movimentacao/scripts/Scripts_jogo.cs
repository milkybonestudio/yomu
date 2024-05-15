using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Scripts_jogo {


    public static void Ativar_script(Script_jogo_nome _script_nome ) {


        if(_script_nome == Script_jogo_nome.nada) { return; } 

        Debug.Log("veio script: " + _script_nome);

        switch( _script_nome ){

            case  Script_jogo_nome.nada:  Debug.Log("Veio script NADA"); break; 
            case  Script_jogo_nome.teste:  teste_mudar_script(); break;             
            case Script_jogo_nome.NARA_INTRODUCAO_espelho : Iniciar_screen_play( Nome_screen_play.NARA_INTRODUCAO_nara_olhando_espelho ) ; break ;
            case Script_jogo_nome.NARA_INTRODUCAO_bilhete : Iniciar_screen_play( Nome_screen_play.NARA_INTRODUCAO_carta_dia ) ; break ;
            case Script_jogo_nome.NARA_INTRODUCAO_buraco : Iniciar_screen_play( Nome_screen_play.NARA_INTRODUCAO_nara_olhando_buraco ) ; break ;
            case Script_jogo_nome.NARA_INTRODUCAO_cama : Iniciar_screen_play( Nome_screen_play.NARA_INTRODUCAO_wake_up ) ; break ;
            case Script_jogo_nome.NARA_INTRODUCAO_corredor : Iniciar_screen_play( Nome_screen_play.NARA_INTRODUCAO_corredor ) ; break ;
            case Script_jogo_nome.NARA_INTRODUCAO_nara_morre_alkatroz_HANDLER : NARA_INTRODUCAO_nara_morre_alkatroz_HANDLER(  ) ; break ;
            case Script_jogo_nome.NARA_INTRODUCAO_finalizar : NARA_INTRODUCAO_finalizar(  ) ; break ;
            
            
            default: throw new ArgumentException("script_jogo_nome nao lidado. veio : " + _script_nome);

        }

        return;

    }




    public static void NARA_INTRODUCAO_finalizar(){


            // // Application.Quit();
            // // return;


            // Debug.Log("entrou NARA_INTRODUCAO_finalizar");
            // //BLOCO_jogo bloco = BLOCO_jogo.Pegar_instancia() ;
            
            // bloco.Colocar_UI_atual = bloco.Colocar_UI_default;
            // bloco.Colocar_input_atual = bloco.Colocar_input_default;

            // Lista_navegacao lista = Lista_navegacao.Pegar_instancia();

            // /// muda Lidar retorno 
            // // 


            // lista.Mudar_interativos_para_subtrair(    Ponto_nome.FRONT_quarto_nara ,  new int[ 1 ]{ 1 },   null  );
            // lista.Mudar_interativos_para_subtrair(    Ponto_nome.BACK_quarto_nara ,  new int[ 1 ]{ 1 },   null  );


            // lista.Adicionar_script_interativo_em_espera( Interativo_nome.MACANETA_corredor_quarto_nara , Script_jogo_nome.nada );
            // lista.Adicionar_script_interativo_em_espera( Interativo_nome.MACANETA_corredor_quarto_nara , Script_jogo_nome.nada );


            // //Controlador_movimento.Pegar_instancia().Mover_player( Ponto_nome.UP_quarto_nara , true  );

            





    }



    public static void Iniciar_screen_play( Nome_screen_play _nome_screen_play ){

    
            Req_transicao req = new Req_transicao(

                  _tipo_troca_bloco: Tipo_troca_bloco.START,
                  _novo_bloco: Bloco.visual_novel,
                  _tipo_transicao: Tipo_transicao.instantaneo

            );

            
            Dados_blocos dados = Dados_blocos.Pegar_instancia();
            dados.visual_novel_START = new Visual_novel_START(   _nome_screen_play   );
            dados.Colocar_nova_req(req);
      

            return;
     


    }


    public static void NARA_INTRODUCAO_nara_morre_alkatroz_HANDLER(){

        Lista_navegacao lista = Lista_navegacao.Pegar_instancia();



        int[] slots = new int[2]{

                  1,
                  1
        };

        Interativo_nome[] interativos_default_front = new Interativo_nome[] {  

            Interativo_nome.MESA_front_quarto_nara,
            Interativo_nome.ESPELHO_front_quarto_nara,
            Interativo_nome.CORREDOR_front_quarto_nara

        };

        Interativo_nome[] interativos_default_back = new Interativo_nome[] {  

            Interativo_nome.BURACO_back_quarto_nara,
            Interativo_nome.CAMA_back_quarto_nara    

        };

        lista.Mudar_interativos_para_subtrair (    Ponto_nome.FRONT_quarto_nara ,  slots,  interativos_default_front  ) ;
        lista.Mudar_interativos_para_subtrair (    Ponto_nome.BACK_quarto_nara ,  slots,  interativos_default_back  ) ;


        lista.Remover_interativo_para_subtrair (  Ponto_nome.BACK_quarto_nara ,  new int[2]{ 1, 1 },   Interativo_nome.CAMA_back_quarto_nara  ) ;
        lista.Remover_interativo_para_subtrair (  Ponto_nome.FRONT_quarto_nara ,  new int[2]{ 1, 1 },   Interativo_nome.CORREDOR_front_quarto_nara  ) ;

        //Controlador_movimento.Pegar_instancia().Mover_player( Ponto_nome.BACK_quarto_nara );

        return;





    }





    public static void teste_mudar_script(){



        Controlador_dados_dinamicos controlador_dados_dinamicos =  Controlador_dados_dinamicos.Pegar_instancia();

        controlador_dados_dinamicos.lista_navegacao.Mudar_interativos_para_acrescentar(  

            _ponto_nome: Ponto_nome.UP_quarto_nara,
            _slots: new int []{1}, 
            _interativos:  new Interativo_nome[1]{ Interativo_nome.ESPELHO_front_quarto_nara }
          
        );



    }




}