




public static class Lidar_retorno_bloco_conector{


    public static void Default(){



        BLOCO_conector bloco_conector = BLOCO_conector.Pegar_instancia();
        

        Conector_RETURN conector_return = Dados_blocos.conector_RETURN;

        if( conector_return != null  ){


                Script_jogo_nome script_retorno = conector_return.script_jogo;
                Ponto_nome ponto_para_mover = conector_return.ponto_para_mover ;



                if ( script_retorno != Script_jogo_nome.nada  ) {

                    //Scripts_jogo.Ativar_script( script_retorno );
                    //dados_blocos.jogo_RETURN.script_jogo = Script_jogo_nome.nada ;

                }

                if( ponto_para_mover != Ponto_nome.nada ){

                    ///controlador_movimento.Mover_player( ponto_para_mover );

                } else {

                Ponto_nome ponto = Player_estado_atual.Pegar_instancia().ponto_atual.ponto_nome;
                ///controlador_movimento.Mover_player( ponto );


                }


        } else {

            
                Ponto_nome ponto = Player_estado_atual.Pegar_instancia().ponto_atual.ponto_nome;
                ///controlador_movimento.Mover_player( ponto );

        }


           
        bloco_conector.Colocar_input_atual();
        bloco_conector.Colocar_UI_atual();

        Dados_blocos.conector_RETURN = null;


        return;
        }



    }



