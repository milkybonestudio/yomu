




public static class Lidar_retorno_bloco_movimento{


    public static void Default(){



        BLOCO_movimento bloco_movimento = BLOCO_movimento.Pegar_instancia();
        Dados_blocos dados_blocos  = Dados_blocos.Pegar_instancia();


        Jogo_RETURN jogo_return = dados_blocos.jogo_RETURN;

        if( jogo_return != null  ){


                Script_jogo_nome script_retorno = jogo_return.script_jogo;
                Ponto_nome ponto_para_mover = jogo_return.ponto_para_mover ;



                if ( script_retorno != Script_jogo_nome.nada  ) {

                    Scripts_jogo.Ativar_script( script_retorno );
                    dados_blocos.jogo_RETURN.script_jogo = Script_jogo_nome.nada ;

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


           
        bloco_movimento.Colocar_input_atual();
        bloco_movimento.Colocar_UI_atual();

        dados_blocos.jogo_RETURN = null;


        return;
        }



    }



