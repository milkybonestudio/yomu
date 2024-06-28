using System;

public static class Verificador_interativos_tela_DESENVOLVIMENTO {


        public static void Checar_interativo_tela( Interativo_tela _interativo_tela ){

                string nome = _interativo_tela.nome_insterativo_DESENVOLVIMENTO;


                // --- CURSOR

                if( _interativo_tela.metodo_para_mudar_cursor == Metodo_para_mudar_cursor.uma_cor_para_cada_periodo )
                        {
                                if( _interativo_tela.cores_cursor == null )
                                        { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas o array das cores estava fazio." ); }

                                if( _interativo_tela.cores_cursor.Length != 5 )
                                        { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas o array das cores nao tinha 5 elementos, um para cada periodo." ); }

                                if(  _interativo_tela.cor_cursor != Cor_cursor.nada )
                                        { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas mas foi definido uma cor unica. veio { _interativo_tela.cor_cursor }" ); }
                        }

                if( _interativo_tela.metodo_para_mudar_cursor == Metodo_para_mudar_cursor.cor_unica )
                        {

                                if( _interativo_tela.cores_cursor != null )
                                        { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"cor_unica\" mas o array das cores nao estava fazio." ); }

                                if(  _interativo_tela.cor_cursor == Cor_cursor.nada )
                                        { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"cor_unica\" mas mas NAO foi definido uma cor unica" ); }
                        }



                // --- IMAGEM   

                // CHECAR: NADA
                if( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.nada_E_nada )
                        {

                                // --- SE FAZ SENTIDO TER CORES ESPECIFICAS 
                                if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.cores_especificas )
                                        { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" mas o Imagens_disponiveis_no_mouse_hover esta como nada_E_nada. Se nao tem imagem nao tem sentido terrem cores especificas" ); }

                                // --- SE FAZ SENTIDO TER COR 80/100
                                if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.core_80_e_100 )
                                        { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas o Imagens_disponiveis_no_mouse_hover esta como nada_E_nada." ); }
                            
                        }


                // CEHCAR: TEM SOMENTE COM MOUSE HOVER
                if( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.nada_E_one )
                        {

                            if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.cores_especificas )
                                    { 
                                        if( _interativo_tela.cor_segunda_imagem == Nome_cor.nada )
                                            { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" e as imagens_disponiveis_no_mouse_hover como nada_E_one. Mas o a cor da segunda imagem não foi definida" ); }
                                            
                                        if( _interativo_tela.cor_primeira_imagem != Nome_cor.nada )
                                            { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" e as imagens_disponiveis_no_mouse_hover como nada_E_one. Mas o a cor da primeira imagem foi definida como { _interativo_tela.cor_primeira_imagem }. Nao pode ter nenhuma cor" ); }
                                        
                                    }

                            // se faz sentido 
                            if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.core_80_e_100 )
                                    { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas o Imagens_disponiveis_no_mouse_hover esta como nada_E_one. nao tem como porque precisa de 2 imagens" ); }
                    
                        }



                // --- CORES

                if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.cores_especificas )
                        {

                                // --- TESTE COM CORES ESPECIFICAS

                                bool precisa_ter_as_2_cores  =  (
                                                                    ( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.one_E_one )
                                                                    ||
                                                                    ( _interativo_tela.imagens_disponiveis_no_mouse_hover == Imagens_disponiveis_no_mouse_hover.one_E_two )
                                                                );
                                                            

                                if( precisa_ter_as_2_cores )
                                        {
                                        
                                            if( _interativo_tela.cor_primeira_imagem == Nome_cor.nada )
                                                    { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" mas a cor_primeira_imagem nao foi declarada, veio como nada." ); }

                                            if( _interativo_tela.cor_segunda_imagem == Nome_cor.nada )
                                                    { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" mas a cor_segunda_imagem nao foi declarada, veio como nada." ); }

                                        }

                            
                        }
                        else if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.core_80_e_100 )
                        {
                                // --- TESTE COR 80/100

                                // --- VER SE FOI COLOCADO COR INDIVIDUAL POR ENGANO
                                if( _interativo_tela.cor_primeira_imagem != Nome_cor.nada )
                                        { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas a cor_primeira_imagem o foi declarada, mas ela nao pode. Veio { _interativo_tela.cor_primeira_imagem }." ); }

                                if( _interativo_tela.cor_segunda_imagem != Nome_cor.nada )
                                        { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas a cor_segunda_imagem foi declarada, mas ela nao pode. Veio { _interativo_tela.cor_segunda_imagem }." ); }


                        }
                        else if( _interativo_tela.metodo_das_cores_imagens_disponiveis_no_mouse_hover == Metodo_das_cores_imagens_disponiveis_no_mouse_hover.cor_especifica )
                        {
                            
                                if( _interativo_tela.cor_imagens == Nome_cor.nada )
                                        { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cor_especifica\" mas a cor não foi definida" ); }
                                
                                if( _interativo_tela.cor_primeira_imagem != Nome_cor.nada )
                                        { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cor_especifica\" mas a cor da imagem_1 foi definida como {_interativo_tela.cor_primeira_imagem}" ); }

                                if( _interativo_tela.cor_segunda_imagem != Nome_cor.nada )
                                        { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cor_especifica\" mas a cor da imagem_2 foi definida como {_interativo_tela.cor_segunda_imagem}" ); }
                                    


                        }

                return;

        }


}