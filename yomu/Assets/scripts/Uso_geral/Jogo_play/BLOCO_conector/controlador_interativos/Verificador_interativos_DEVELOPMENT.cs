

public static class  Verificador_interativos_DEVELOPMENT{


        public static void Verificar_interativos_ids(  Ponto _ponto, byte[][] _interativos_default_por_periodo, byte[][] _interativos_para_subtrair_por_posicao_por_periodo, byte[][] _interativos_para_adicionar_por_posicao_por_periodo ){



                            // --- VERIFICAR 

                int periodo = Controlador_timer.Pegar_instancia().periodo_atual_id;


                // --- DEFAULT

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_default_por_periodo, "_interativos_default_por_periodo" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_default_por_periodo[ periodo ] , "interativos_default_regiao[ periodo ]" );
        
                
                // --- SUBTRAIR

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_subtrair_por_posicao_por_periodo , "_interativos_para_subtrair_por_posicao_por_periodo" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_subtrair_por_posicao_por_periodo[ periodo ] , "_interativos_para_subtrair_por_posicao_por_periodo[ periodo ] " );
                
                
                // --- ADICIONAR
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_adicionar_por_posicao_por_periodo , "_interativos_para_adicionar_por_posicao_por_periodo" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_adicionar_por_posicao_por_periodo[ periodo ] , "_interativos_para_adicionar_por_posicao_por_periodo[ periodo ] " );
                
            
                return;

            

        }

    

}