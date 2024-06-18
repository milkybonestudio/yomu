using  System;
using  UnityEngine;



public static class Script_end_1 {


    public static void Lidar_dia_carruagem( Screen_play _screen_play ){


      //  Controlador_dados_dinamicos.Pegar_instancia().pegar_bloco( "bloco_1" )




        // assembly bloco_1;


        // pegar_bloco(string _nome_bloco){

        //     switch (_nome_bloco){
        //         case "bloco_1": if(bloco_1 == null) Pegar_bloco("path", bloco_1)
        //     }

        // } 


        Debug.Log("veio dia carruagem");

        return;

    }


    public static  void NARA_INTRODUCAO_liberar_mesa( Screen_play _screen_play ) {

          Lista_navegacao lista = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao;

            lista.Remover_interativo_para_subtrair (  Ponto_nome.FRONT_quarto_nara ,  new int[ 1 ]{ 1 },   Interativo_nome.MESA_front_quarto_nara  );
            lista.Adicionar_interativo_para_subtrair (  Ponto_nome.FRONT_quarto_nara ,  new int[ 1 ]{ 1 },   Interativo_nome.ESPELHO_front_quarto_nara  );

            
            // mudar background => mesa vazia 
            // tirar interativos licros + tinta + caixa + carta 

            lista.Adicionar_interativo_para_acrescentar (  Ponto_nome.MESA_quarto_nara ,  new int[ 1 ]{ 1 },   Interativo_nome.CARTA_DIA_mesa_quarto_nara  );


    }

    public static  void NARA_INTRODUCAO_liberar_buraco ( Screen_play _screen_play ) {


            Lista_navegacao lista = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao;


            lista.Remover_interativo_para_acrescentar (  Ponto_nome.MESA_quarto_nara ,  new int[ 1 ]{ 1 },   Interativo_nome.CARTA_DIA_mesa_quarto_nara  );
            lista.Remover_interativo_para_subtrair (  Ponto_nome.BACK_quarto_nara ,  new int[ 1 ]{  1 },   Interativo_nome.BURACO_back_quarto_nara  );
            lista.Adicionar_interativo_para_subtrair (  Ponto_nome.FRONT_quarto_nara ,  new int[ 1 ]{ 1 },   Interativo_nome.MESA_front_quarto_nara  );


            lista.Adicionar_script_interativo_em_espera( Interativo_nome.BURACO_back_quarto_nara , Script_jogo_nome.NARA_INTRODUCAO_buraco );

          
            //Jogo_RETURN jogo_return = new Jogo_RETURN();

            //jogo_return.ponto_para_mover = Ponto_nome.FRONT_quarto_nara;

            //Dados_blocos.Pegar_instancia().jogo_RETURN = jogo_return;

          

    }

    public static  void NARA_INTRODUCAO_liberar_cama_E_corredor( Screen_play _screen_play ){


      
          Lista_navegacao lista = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao;

    
          lista.Adicionar_interativo_para_subtrair (  Ponto_nome.BACK_quarto_nara ,  new int[ 1 ]{ 1 },   Interativo_nome.BURACO_back_quarto_nara );

          lista.Remover_interativo_para_subtrair (  Ponto_nome.FRONT_quarto_nara ,  new int[ 1 ]{  1 },   Interativo_nome.CORREDOR_front_quarto_nara  );
          lista.Remover_interativo_para_subtrair (  Ponto_nome.BACK_quarto_nara ,  new int[ 1 ]{ 1 },   Interativo_nome.CAMA_back_quarto_nara );

          lista.Adicionar_script_interativo_em_espera( Interativo_nome.BURACO_back_quarto_nara , Script_jogo_nome.NARA_INTRODUCAO_buraco );




    }


  
    public static  void NARA_INTRODUCAO_alkatroz( Screen_play _screen_play ){


            Dados_blocos dados = Dados_blocos.Pegar_instancia();

            //Jogo_RETURN  jogo_return = new Jogo_RETURN();

            Player_estado_atual.Pegar_instancia().posicao_arr = new Ponto_nome[ 20 ];

            Player_estado_atual.Pegar_instancia().posicao_arr[ 0 ] = Ponto_nome.FRONT_quarto_nara ;
            Player_estado_atual.Pegar_instancia().posicao_arr[ 1 ] = Ponto_nome.BACK_quarto_nara ;

            Ponto novo_ponto = new Ponto();
            novo_ponto.ponto_nome = Ponto_nome.BACK_quarto_nara;

            Player_estado_atual.Pegar_instancia().ponto_atual = novo_ponto ;

    }



    
    public static  void NARA_INTRODUCAO_finalizar ( Screen_play _screen_play ){



                        
            //Jogo_RETURN jogo_return = new Jogo_RETURN() ;
            ////jogo_return.ponto_para_mover = Ponto_nome.UP_quarto_nara ;
            //jogo_return.script_jogo = Script_jogo_nome.NARA_INTRODUCAO_finalizar ;
            //Dados_blocos.Pegar_instancia().jogo_RETURN = jogo_return ;
            


            



    }




}