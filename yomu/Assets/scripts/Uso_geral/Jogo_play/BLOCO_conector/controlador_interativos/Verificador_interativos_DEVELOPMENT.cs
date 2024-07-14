

public static class  Verificador_interativos_DEVELOPMENT{


        public static void Verificar_interativos_ids(  Posicao _posicao, int[][][][] _interativos_default_por_posicao, int[][][][] _interativos_para_subtrair_por_posicao, int[][][][] _interativos_para_adicionar_por_posicao ){



                            // --- VERIFICAR 


                // --- DEFAULT

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_default_por_posicao , "interativos_default_por_posicao" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_default_por_posicao[ _posicao.regiao_id ] , "interativos_default_regiao" );

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_default_por_posicao[ _posicao.regiao_id ][ _posicao.area_id ] , "interativos_default_area" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_default_por_posicao[ _posicao.regiao_id ][ _posicao.area_id ][ _posicao.ponto_id ] , "interativos_default_ponto" );


                // --- SUBTRAIR

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_subtrair_por_posicao , "_interativos_para_subtrair_por_posicao" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_subtrair_por_posicao[ _posicao.regiao_id ] , "interativos_para_subtrair_regiao" );

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_subtrair_por_posicao[ _posicao.regiao_id ][ _posicao.area_id ] , "interativos_para_subtrair_area" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_subtrair_por_posicao[ _posicao.regiao_id ][ _posicao.area_id ][ _posicao.ponto_id ] , "interativos_para_subtrair_ponto" );

                // --- ADICIONAR

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_adicionar_por_posicao , "interativos_para_adicionar_por_posicao" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_adicionar_por_posicao[ _posicao.regiao_id ] , "interativos_para_adicionar_regiao" );

                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_adicionar_por_posicao[ _posicao.regiao_id ][ _posicao.area_id ] , "interativos_para_adicionar_area" );
                Verificador_valor_null_DEVELOPMENT.Verifica_valor( _interativos_para_adicionar_por_posicao[ _posicao.regiao_id ][ _posicao.area_id ][ _posicao.ponto_id ] , "interativos_para_adicionar_ponto" );

                return;

            

        }

    

}