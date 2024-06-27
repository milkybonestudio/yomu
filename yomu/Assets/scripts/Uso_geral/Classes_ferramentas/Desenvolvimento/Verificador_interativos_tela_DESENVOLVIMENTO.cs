using System;

public static class Verificador_interativos_tela_DESENVOLVIMENTO {


    public static void Checar_interativo_tela( Interativo_tela _interativo_tela ){



            // --- CURSOR

            if( _interativo_tela.metodo_para_mudar_cursor == Metodo_para_mudar_cursor.uma_cor_para_cada_periodo )
                {
                    if( _interativo_tela.cores_cursor == null )
                        { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas o array das cores estava fazio." ); }

                    if( _interativo_tela.cores_cursor.Length != 5 )
                        { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas o array das cores nao tinha 5 elementos, um para cada periodo." ); }

                    if( _interativo_tela.cor_cursor != Nome_cor.nada )
                        { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas mas foi definido uma cor unica. veio { _interativo_tela.cor_cursor }" ); }
                }

            // --- IMAGEM             

            if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.cores_especificas )
                {
                    // --- TESTE COM CORES ESPECIFICAS

                    // --- SE FAZ SENTIDO AS CORES                    
                    if( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.nada_E_nada )
                        { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"cores_especificas\" mas o Imagens_disponiveis_no_mouse_hover esta como nada_E_nada." ); }

                    if( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.nada_E_one )
                        { 
                            if( _interativo_tela.cor_primeira_imagem == Nome_cor.nada )
                                { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"cores_especificas\" mas o Imagens_disponiveis_no_mouse_hover esta como nada_E_nada." ); }
                        }

                    bool pode_ter_2_imagens  =  (
                                                    ( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.one_E_one )
                                                    ||
                                                    ( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.one_E_two )
                                                );
                                                

                    if( pode_ter_2_imagens )
                        {
                        
                            if( _interativo_tela.cor_primeira_imagem == Nome_cor.nada )
                                { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"cores_especificas\" mas a cor_primeira_imagem nao foi declarada, veio como nada." ); }

                            if( _interativo_tela.cor_segunda_imagem == Nome_cor.nada )
                                { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"cores_especificas\" mas a cor_segunda_imagem nao foi declarada, veio como nada." ); }

                        }

                    
                }

                if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.core_80_e_100 )
                    {

                        if( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.nada_E_nada )
                            { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"core_80_e_100\" mas o Imagens_disponiveis_no_mouse_hover esta como nada_E_nada." ); }

                        if( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.nada_E_one )
                            { 
                                if( _interativo_tela.cor_primeira_imagem == Nome_cor.nada )
                                    { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"core_80_e_100\" mas o Imagens_disponiveis_no_mouse_hover esta como nada_E_nada." ); }
                            }

                            
                        if( _interativo_tela.cor_primeira_imagem != Nome_cor.nada )
                            { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"core_80_e_100\" mas a cor_primeira_imagem o foi declarada, mas ela nao pode. Veio { _interativo_tela.cor_primeira_imagem }." ); }

                        if( _interativo_tela.cor_segunda_imagem != Nome_cor.nada )
                            { throw new Exception( $"No interativo { _interativo_tela.nome_insterativo_DESENVOLVIMENTO } a cor das imagens esta definida no metodo \"core_80_e_100\" mas a cor_segunda_imagem foi declarada, mas ela nao pode. Veio { _interativo_tela.cor_segunda_imagem }." ); }


                    }

            

            

            

            // --- SUPORTE PARA ( IMAGEM / VISUAL )
            
            // public Imagens_disponiveis_no_mouse_hover imagens_disponiveis_no_mouse_hover;
            // public Metodo_para_mudar_cursor metodo_para_mudar_cursor;

            // // so vai ser usado dependendo do Metodo_que_as_imagens_lidam_com_mouse_hover
            // public Nome_cor cor_primeira_imagem = Nome_cor._default;
            // public Nome_cor cor_segunda_imagem = Nome_cor._default;



    }



}