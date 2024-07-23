using System;
using UnityEngine; 




#if UNITY_EDITOR || true

        // ** sempre vai ser usado no leitor_DEVELOPMENT
        public static class Construtor_interativos_DEVELOPMENT {


                // ** todo dado necessario sempre vai ficar aqui

                // vai guardar o path e simular o id final da imagem

                
                public static string[] paths_imagens = new string[ 1000 ];
                public static int pointer_imagem_atual = 0;



                public static Interativo_tela Criar_interativos_tela(  Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados ) {


                        // *** interativo agora sempre vai ser criado junto com o ponto
                        // *** mas a parte visual foi separada em um outro container que só vai ser intanciado a medida que o player se aproxima 


                        // **como vai lidar com imagens especiais? 

                        byte interativo_id = _interativo_tela_dados.interativo_id;

                        Interativo_tela interativo_retorno = new Interativo_tela( interativo_id );

                        
                        
                        Colocar_logica_interativo_tela_DEVELOPMENT(  _interativo_tela_dados, interativo_retorno ); // ** so passa a logica
                        Colocar_cursor_interativo_tela_DEVELOPMENT( _interativo_tela_dados, interativo_retorno ); // ** 
                        

                        // --- PARTE IMAGENS 
                        Colocar_path_interativo_tela_DEVELOPMENT( _interativo_tela_dados, interativo_retorno );
                        Colocar_cores_interativo_tela_DESENVOLVIMENTO(  _interativo_tela_dados, interativo_retorno );
                        Colocar_sprites_interativo_tela_DESENVOLVIMENTO(  _interativo_tela_dados, interativo_retorno );
                        

                        return interativo_retorno;


                }


                public static  void Colocar_logica_interativo_tela_DEVELOPMENT( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados_developmetn , Interativo_tela _interativo_tela ){

                
                        _interativo_tela.tipo_interativo_tela = _interativo_tela_dados_developmetn.tipo_interativo;
                        _interativo_tela.area = _interativo_tela_dados_developmetn.area;
                        return;

                }


                public static  void Colocar_cursor_interativo_tela_DEVELOPMENT( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados , Interativo_tela _interativo ){

                        

                }


                public static  void Colocar_path_interativo_tela_DEVELOPMENT( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados , Interativo_tela _interativo ){

                
                        string interativo_enum_nome_DESENVOLVIMENTO = _interativo_tela_dados.enum_nome_interativo_DESENVOLVIMENTO; // interativo_enum_nome_DESENVOLVIMENTO => SAINT_LAND__CATHEDRAL__DORMITORIO_FEMININO_interativo 
                        string interativo_nome_DESENVOLVIMENTO =  _interativo_tela_dados.nome_insterativo_DESENVOLVIMENTO; // interativo_nome_DESENVOLVIMENTO => NARA_ROOM__up__janela

                        string[] folders_ate_interativos = interativo_enum_nome_DESENVOLVIMENTO.Split( "__" );

                        if( folders_ate_interativos.Length != 3 )
                                { throw new Exception( $"formato de interativo_enum_nome_DESENVOLVIMENTO nao aceito. Veio: { interativo_enum_nome_DESENVOLVIMENTO }" ); }
                        
                                                                       
                        string path_imagens_interativos = Paths_sistema.path_folder_imagens_pontos_DEVELOPMENT;


                        string cidade = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 0 ] );
                        string regiao = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 1 ] );
                        string area = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 2 ] );


                        string[] folder_contexto_ponto__E__imagem = interativo_nome_DESENVOLVIMENTO.Split( "__" );

                        string folder_contexto_ponto = folder_contexto_ponto__E__imagem[ 0 ].ToLower();
                        string imagem = folder_contexto_ponto__E__imagem[ 1 ].ToLower();

                        if( _interativo_tela_dados.metodo_FOLDER_que_as_imagens_estao_salvas == Metodo_FOLDER_que_as_imagens_estao_salvas.contexto_area )
                                { folder_contexto_ponto = ""; }
                        
                
                        string[] path_imagem_array    =   new  string[] { 

                                                                        path_imagens_interativos, 
                                                                        cidade, 
                                                                        regiao, 
                                                                        area, 
                                                                        folder_contexto_ponto,
                                                                        imagem 
                                                                };

                        _interativo_tela_dados.path_imagem = System.IO.Path.Combine( path_imagem_array );


                }



                public static void Colocar_cores_interativo_tela_DESENVOLVIMENTO( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados_development , Interativo_tela _interativo_tela ){

                
                        int periodo_id = Controlador_timer.Pegar_instancia().periodo_atual_id;

                        Nome_cor cor_imagem_1 = Nome_cor.nada;
                        Nome_cor cor_imagem_2 = Nome_cor.nada; 






                        if     ( _interativo_tela_dados_development.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cores_especificas )
                                {
                                        // PEGAR CORES ESPECIFICAS 

                                        cor_imagem_1 =  _interativo_tela_dados_development.cor_primeira_imagem ;
                                        cor_imagem_2 =  _interativo_tela_dados_development.cor_segunda_imagem ;

                                }
                        else if( _interativo_tela_dados_development.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cor_especifica )
                                {
                                        // PEGAR COR ESPECIFICA

                                        cor_imagem_1 =  _interativo_tela_dados_development.cor_imagens ;
                                        cor_imagem_2 =  _interativo_tela_dados_development.cor_imagens ;

                                }
                        else if( _interativo_tela_dados_development.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.core_80_e_100 )
                                {
                                        // PEGAR COR  80 / 100  

                                        cor_imagem_1 =  Nome_cor.white_080 ;
                                        cor_imagem_2 =  Nome_cor.white_100 ;

                                }
                        else if( _interativo_tela_dados_development.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.normal )
                                {
                                        // DEFINE AS 2 COMO WHITE

                                        cor_imagem_1 =  Nome_cor.white ;
                                        cor_imagem_2 =  Nome_cor.white ;

                                }

                        _interativo_tela.cor_imagem_1_id = ( short ) cor_imagem_1;
                        _interativo_tela.cor_imagem_2_id = ( short ) cor_imagem_2; 

                        return;

                }




                public static void Colocar_sprites_interativo_tela_DESENVOLVIMENTO(  Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados , Interativo_tela _interativo ){

                        



                        // Periodo_tempo[]   periodos   =   new Periodo_tempo[]    {
                        //                                                                 Periodo_tempo.manha,
                        //                                                                 Periodo_tempo.dia,
                        //                                                                 Periodo_tempo.tarde,
                        //                                                                 Periodo_tempo.noite,
                        //                                                                 Periodo_tempo.madrugada
                        //                                                         };



                        Periodo_tempo periodo = ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id;


                        string path_imagem = _interativo_dados.path_imagem;
                        string sufixo_modelo = Pegar_sufixo_interativo_modelos_DESENVOLVIMENTO( _interativo_dados, periodo );
                        string sufixo_numero = "";


                        string path_imagem_1 = null ;
                        string path_imagem_2 = null ;



                        if     ( _interativo_dados.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.nada_E_nada )
                                {

                                        // --- NAO TEM NENHUMA IMAGEM 
                                        // _interativo.cor[ periodo_index ] = ( int ) Nome_cor.transparente;
                                        // _interativo.cores_imagem_2_ids_unicos_por_periodo[ periodo_index ] = ( int ) Nome_cor.transparente;

                                        _interativo.cor_imagem_1_id =  ( short ) Nome_cor.transparente;
                                        _interativo.cor_imagem_2_id =  ( short ) Nome_cor.transparente;

                                        _interativo.sprite_imagem_1_id_unico = -1;
                                        _interativo.sprite_imagem_2_id_unico = -1;

                                        

                                }    
                        else if( _interativo_dados.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.one_E_two )
                                {

                                        // --- TEM AS 2 IMAGENS

                                        // PEGA PRIMEIRA
                                        sufixo_numero = "_1";
                                        path_imagem_1 = System.IO.Path.Combine( path_imagem, sufixo_modelo, sufixo_numero, ".png" );

                                        // PEGA SEGUNDA IMAGEM
                                        sufixo_numero = "_2";
                                        path_imagem_2 = System.IO.Path.Combine( path_imagem, sufixo_modelo, sufixo_numero, ".png" );


                                }
                        else if( _interativo_dados.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.nada_E_one )
                                {
                                        // SO TEM 1 IMAGEM

                                        // PEGA PRIMEIRA
                                        sufixo_numero = "";
                                        path_imagem_1 = null;


                                        // PEGA SEGUNDA IMAGEM
                                        sufixo_numero = "";
                                        path_imagem_2 = System.IO.Path.Combine( path_imagem, sufixo_modelo, sufixo_numero, ".png" );

                                        _interativo.cor_imagem_2_id =  ( short ) Nome_cor.transparente  ;


                                }
                        else if( _interativo_dados.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.one_E_one )
                                {
                                        // SO TEM 1 IMAGEM

                                        // PEGA PRIMEIRA
                                        sufixo_numero = "";
                                        path_imagem_1 = System.IO.Path.Combine( path_imagem, sufixo_modelo, sufixo_numero, ".png" );


                                        // PEGA SEGUNDA IMAGEM
                                        sufixo_numero = "";
                                        path_imagem_2 = System.IO.Path.Combine( path_imagem, sufixo_modelo, sufixo_numero, ".png" );

                                }




                        if( path_imagem_1 != null  )
                                {
                                        if( ! ( System.IO.File.Exists( path_imagem_1 ) ))  
                                        { throw new Exception( $"pediu o path { path_imagem_1 } mas não tinha nenhum arquivo no local" ); }


                                        int index = Gerenciador_imagens_interativos.poiner_imagem++;
                                        Gerenciador_imagens_interativos.paths_imagens_DEVELOPMENT[ index ] = path_imagem_1;

                                        _interativo.sprite_imagem_1_id_unico = ( short ) index;
                                }

                        if( path_imagem_2 != null  )
                                {
                                        if( ! ( System.IO.File.Exists( path_imagem_2 ) ))  
                                        { throw new Exception( $"pediu o path { path_imagem_2 } mas não tinha nenhum arquivo no local" ); }  

                                        
                                        int index = Gerenciador_imagens_interativos.poiner_imagem++;
                                        Gerenciador_imagens_interativos.paths_imagens_DEVELOPMENT[ index ] = path_imagem_2;

                                        _interativo.sprite_imagem_2_id_unico = ( short ) index;


                                }



                        return;
                        

                }



                public static string Pegar_sufixo_interativo_modelos_DESENVOLVIMENTO( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados, Periodo_tempo periodo_atual ){

                        
                        

                        //Periodo_tempo periodo_atual = ( ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id ) ;

                        switch( _interativo_dados.metodo_que_as_imagens_estao_salvas ){


                                case Metodo_que_as_imagens_estao_salvas.nao_altera:             {
                                                                                                        return "";
                                                                                                }
                                                                                                { break; }
                                case Metodo_que_as_imagens_estao_salvas.dia_E_noite:            {
                                                                                                        bool esta_claro    =    (
                                                                                                                                        ( periodo_atual  ==  Periodo_tempo.manha )
                                                                                                                                        ||
                                                                                                                                        ( periodo_atual  ==  Periodo_tempo.dia )
                                                                                                                                        ||
                                                                                                                                        ( periodo_atual  ==  Periodo_tempo.tarde )
                                                                                                                                );


                                                                                                        if ( esta_claro )
                                                                                                                { return "_d"; }
                                                                                                                else 
                                                                                                                { return "_n"; }
                                                                                                        
                                                                                                }
                                                                                                { break; }
                                case Metodo_que_as_imagens_estao_salvas.todos_os_periodos:      { 
                                
                                                                                                        return ( "_" + periodo_atual.ToString().ToUpper() );
                                                                                                
                                                                                                }
                                                                                                { break; }
                                case Metodo_que_as_imagens_estao_salvas.nome:                   { 
                                
                                                                                                        return ( "_" + _interativo_dados.nomes_imagens_especificas_periodos[ ( ( int ) periodo_atual ) ] );
                                                                                        
                                                                                                }
                                                                                                { break; }

                                default: throw new Exception("");



                        }


                }


        }

#endif