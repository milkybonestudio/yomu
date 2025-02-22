// using System;

// #if UNITY_EDITOR || true

//         public static class Verificador_interativos_tela_DESENVOLVIMENTO {

//                 // ** Vai ser usado para verificar se os dados colocados em cada lista de interativos fazem sentido. 
//                 //    Vai ser comum mudar o tipo de como as imagens vão se comportar então essa classe previne que eu mude somente 1 coisa em um contexto que precisa mudar 2 ou algo do tipo


//                 public static void Verificar( ref Interativo_tela_DADOS_DESENVOLVIMENTO[] _dados ){


//                         try { 
                                
//                                 for( int interativo_dados_teste_index = 0 ; interativo_dados_teste_index< _dados.Length ; interativo_dados_teste_index++ ){

//                                         Interativo_tela_DADOS_DESENVOLVIMENTO interativo_dados = _dados[ interativo_dados_teste_index ];

//                                         if( interativo_dados == null )
//                                             { continue; }

//                                         // --- VERIFICAR FUNCOES 

//                                         for( int funcao_index = 0 ; funcao_index < interativo_dados.interativo_funcoes.Length ; funcao_index++ ){

                                                

//                                                 Interativo_funcao funcao = interativo_dados.interativo_funcoes[ funcao_index ];

//                                                 Verificar_se_foi_colocado_os_dados( interativo_dados, funcao );

//                                                 switch( funcao ){

//                                                         case Interativo_funcao.movimento: Verificar_interativo_funcao_MOVIMENTO( interativo_dados ) ; break;
//                                                         case Interativo_funcao.utilidade: Verificar_interativo_funcao_UTILIDADE( interativo_dados ) ; break;
//                                                         case Interativo_funcao.plot: Verificar_interativo_funcao_LOJA( interativo_dados ) ; break;
//                                                         case Interativo_funcao.loja: Verificar_interativo_funcao_PLOT( interativo_dados ) ; break;
//                                                         case Interativo_funcao.controle: Verificar_interativo_funcao_CONTROLE( interativo_dados ) ; break;
//                                                         case Interativo_funcao.minigame: Verificar_interativo_funcao_MINIGAME( interativo_dados ) ; break;
                                                        
//                                                 }

//                                                 continue;

//                                         }



//                                         Checar_interativo_tela( interativo_dados );

//                                         continue;

//                                 }

//                             } 
//                             catch ( Exception e )
//                             {

//                                 _dados = null;
//                                 throw e;

//                             }

//                 }


//                 public static void Verificar_interativo_funcao_MOVIMENTO( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados ){



//                         Dados_interativo_funcao_MOVIMENTO dados_movimento  =  _interativo_dados.dados_interativo_funcoes_DEVELOPMENT.dados_interativo_funcao_MOVIMENTO;

//                         // oque fazer? talvez struct.regiao == 0?
//                         // if( dados_movimento.posicao_unica_destino == null )
//                         //         { throw new Exception( $"nao foi colocado a posicao no interativo { _interativo_dados } tipo moimento" ); }

//                         Ponto_DADOS_DEVELOPMENT ponto_dados = Leitor_pontos.Pegar_ponto( dados_movimento.posicao_unica_destino );

                        

//                 }
//                 public static void Verificar_interativo_funcao_UTILIDADE( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados ){}
//                 public static void Verificar_interativo_funcao_LOJA( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados ){}
//                 public static void Verificar_interativo_funcao_PLOT( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados ){}
//                 public static void Verificar_interativo_funcao_MINIGAME( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados ){}
//                 public static void Verificar_interativo_funcao_CONTROLE( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados ){}


//                 public static void Verificar_se_foi_colocado_os_dados( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados, Interativo_funcao _funcao  ){

//                         Dados_interativo_funcoes_DEVELOPMENT dados =  _interativo_dados.dados_interativo_funcoes_DEVELOPMENT;

//                         switch( _funcao ){

//                                 case Interativo_funcao.movimento: if( dados.dados_interativo_funcao_MOVIMENTO == null  ){ throw new Exception( $"nao foi criado os dados da funcao tipo { _funcao } no interativo{ _interativo_dados.nome }." ); } ;break;
//                                 case Interativo_funcao.utilidade: if( dados.dados_interativo_funcao_UTILIDADE == null  ){ throw new Exception( $"nao foi criado os dados da funcao tipo { _funcao } no interativo{ _interativo_dados.nome }." ); } ;break;
//                                 case Interativo_funcao.plot: if( dados.dados_interativo_funcao_PLOT == null  ){ throw new Exception( $"nao foi criado os dados da funcao tipo { _funcao } no interativo{ _interativo_dados.nome }." ); } ;break;
//                                 case Interativo_funcao.loja: if( dados.dados_interativo_funcao_LOJA == null  ){ throw new Exception( $"nao foi criado os dados da funcao tipo { _funcao } no interativo{ _interativo_dados.nome }." ); } ;break;
//                                 case Interativo_funcao.minigame: if( dados.dados_interativo_funcao_MINIGAME == null  ){ throw new Exception( $"nao foi criado os dados da funcao tipo { _funcao } no interativo{ _interativo_dados.nome }." ); } ;break;
//                                 case Interativo_funcao.controle: if( dados.dados_interativo_funcao_CONTROLE == null  ){ throw new Exception( $"nao foi criado os dados da funcao tipo { _funcao } no interativo{ _interativo_dados.nome }." ); } ;break;
                                
//                         }

//                         return;

//                 }


//                 public static void Checar_interativo_tela( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_DADOS_DESENVOLVIMENTO ){

//                         string nome = _interativo_tela_DADOS_DESENVOLVIMENTO.nome_insterativo_DESENVOLVIMENTO;


//                         // --- CURSOR

//                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_para_mudar_cursor == Metodo_para_mudar_cursor.uma_cor_para_cada_periodo )
//                                 {
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cores_cursor == null )
//                                                 { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas o array das cores nao esta definido." ); }

//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cores_cursor.Length < 5 )
//                                                 { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas o array das cores nao tinha 5 elementos, um para cada periodo." ); }

//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cores_cursor.Length > 5 )
//                                                 { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas o array das cores tinha mais do que os 5 elementos possiveis, um para cada periodo." ); }

//                                         if(  _interativo_tela_DADOS_DESENVOLVIMENTO.cor_cursor != Cor_cursor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"uma_cor_para_cada_periodo\" mas mas foi definido uma cor unica e não deveria. veio { _interativo_tela_DADOS_DESENVOLVIMENTO.cor_cursor }" ); }
//                                 }

//                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_para_mudar_cursor == Metodo_para_mudar_cursor.cor_unica )
//                                 {

//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cores_cursor != null )
//                                                 { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"cor_unica\" mas o array das cores foi definido e nao poderia." ); }

//                                         if(  _interativo_tela_DADOS_DESENVOLVIMENTO.cor_cursor == Cor_cursor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor do cursor esta definida no metodo \"cor_unica\" mas mas NAO foi definido uma cor unica" ); }
//                                 }



//                         // --- IMAGEM   


//                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_que_as_imagens_estao_salvas == Metodo_que_as_imagens_estao_salvas.nome )
//                                 {
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.nomes_imagens_especificas_periodos == null )
//                                                 { throw new Exception( $"Veio metodo_que_as_imagens_estao_salvas como nome especifico mas o array veio null" ); }
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.nomes_imagens_especificas_periodos.Length != 5 )
//                                                 { throw new Exception( $"Veio metodo_que_as_imagens_estao_salvas como nome especifico mas o array veio null" ); }
//                                         for( int nome_index = 0 ; nome_index < 5 ; nome_index++ ){

//                                                 if( _interativo_tela_DADOS_DESENVOLVIMENTO.nomes_imagens_especificas_periodos[ nome_index ] == null  )
//                                                         { throw new Exception( $"Veio metodo_que_as_imagens_estao_salvas como nome especifico mas o array veio null" ); }
                                                
//                                                 continue;

//                                         }
//                                 }

//                         // CHECAR: NADA x NADA
//                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.nada_E_nada )
//                                 {

//                                         // --- NAO FAZ SENTIDO TER CORES ESPECIFICAS 
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cores_especificas )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" mas o Metodo_Imagens_disponiveis_no_mouse_hover esta como nada_E_nada. Se nao tem imagem nao tem sentido terem cores especificas" ); }

//                                         // --- SE FAZ SENTIDO TER COR 80/100
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.core_80_e_100 )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas o Metodo_Imagens_disponiveis_no_mouse_hover esta como nada_E_nada." ); }
                                
//                                 }


//                         // CHECAR: NADA x IMAGEM
//                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.nada_E_one )
//                                 {

//                                 if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cores_especificas )
//                                         { 
//                                                 if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_segunda_imagem == Nome_cor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" e as Metodo_imagens_disponiveis_no_mouse_hover como nada_E_one. Mas o a cor da imagem quando estiver hover não foi definida" ); }
                                                
//                                                 if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_primeira_imagem != Nome_cor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" e as Metodo_imagens_disponiveis_no_mouse_hover como nada_E_one. Mas o a cor da primeira imagem foi definida como { _interativo_tela_DADOS_DESENVOLVIMENTO.cor_primeira_imagem }. Nao pode ter nenhuma cor" ); }
                                                
//                                         }

//                                 // se faz sentido 
//                                 if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.core_80_e_100 )
//                                         { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas o Metodo_Imagens_disponiveis_no_mouse_hover esta como nada_E_one. nao tem como porque precisa de 2 imagens" ); }
                        
//                                 }



//                         // --- CORES

//                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cores_especificas )
//                                 {

//                                         // --- TESTE COM CORES ESPECIFICAS

//                                         bool precisa_ter_as_2_cores  =  (
//                                                                         ( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.one_E_one )
//                                                                         ||
//                                                                         ( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.one_E_two )
//                                                                         );
                                                                

//                                         if( precisa_ter_as_2_cores )
//                                                 {
                                                
//                                                 if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_primeira_imagem == Nome_cor.nada )
//                                                         { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" mas a cor_primeira_imagem nao foi declarada, veio como nada." ); }

//                                                 if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_segunda_imagem == Nome_cor.nada )
//                                                         { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cores_especificas\" mas a cor_segunda_imagem nao foi declarada, veio como nada." ); }

//                                                 }

                                
//                                 }
//                                 else if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.core_80_e_100 )
//                                 {
//                                         // --- TESTE COR 80/100

//                                         // --- VER SE FOI COLOCADO COR INDIVIDUAL POR ENGANO
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_primeira_imagem != Nome_cor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas a cor_primeira_imagem o foi declarada, mas ela nao pode. Veio { _interativo_tela_DADOS_DESENVOLVIMENTO.cor_primeira_imagem }." ); }

//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_segunda_imagem != Nome_cor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"core_80_e_100\" mas a cor_segunda_imagem foi declarada, mas ela nao pode. Veio { _interativo_tela_DADOS_DESENVOLVIMENTO.cor_segunda_imagem }." ); }


//                                 }
//                                 else if( _interativo_tela_DADOS_DESENVOLVIMENTO.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cor_especifica )
//                                 {
                                
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_imagens == Nome_cor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cor_especifica\" mas a cor não foi definida" ); }
                                        
//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_primeira_imagem != Nome_cor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cor_especifica\" mas a cor da imagem_1 foi definida como {_interativo_tela_DADOS_DESENVOLVIMENTO.cor_primeira_imagem}" ); }

//                                         if( _interativo_tela_DADOS_DESENVOLVIMENTO.cor_segunda_imagem != Nome_cor.nada )
//                                                 { throw new Exception( $"No interativo { nome } a cor das imagens esta definida no metodo \"cor_especifica\" mas a cor da imagem_2 foi definida como {_interativo_tela_DADOS_DESENVOLVIMENTO.cor_segunda_imagem}" ); }
                                        


//                                 }

//                         return;

//                 }


//         }


// #endif