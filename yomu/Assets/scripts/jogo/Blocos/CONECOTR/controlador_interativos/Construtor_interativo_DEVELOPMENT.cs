using System;
using UnityEngine; 



#if UNITY_EDITOR || true

    public static class Construtor_interativos_DEVELOPMENT{

        public static Interativo_tela Criar_interativo_tela_DEVELOPMENT(  Posicao _posicao, int _interativo_id   ) {


                // **como vai lidar com imagens especiais? 
                Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados = Leitor_interativos_tela_DESENVOLVIMENTO.Pegar( _posicao,  _interativo_id );

                Interativo_tela interativo_retorno = new Interativo_tela( _interativo_id );

                
                Colocar_logica_interativo_tela_DEVELOPMENT(  _interativo_tela_dados, interativo_retorno );
                Colocar_cursor_interativo_tela_DEVELOPMENT( _interativo_tela_dados, interativo_retorno );
                Colocar_path_interativo_tela_DEVELOPMENT( _interativo_tela_dados, interativo_retorno );
                Colocar_cores_interativo_tela_DESENVOLVIMENTO(  _interativo_tela_dados, interativo_retorno );
                Colocar_sprites_interativo_tela_DESENVOLVIMENTO(  _interativo_tela_dados, interativo_retorno );
                

                // COLOCAR SHADDER 
                // fazer
                // ...


                return interativo_retorno;


        }


        public static  void Colocar_logica_interativo_tela_DEVELOPMENT( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados_developmetn , Interativo_tela _interativo_tela ){

            
                _interativo_tela.ponto_id = _interativo_tela_dados_developmetn.posicao.ponto_id;
                _interativo_tela.tipo_interativo_id = ( int ) _interativo_tela_dados_developmetn.tipo_interativo;
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
                
                
                string path_imagens_interativos = Paths_gerais.Pegar_path_imagens_interativos_DESENVOLVIMENTO();


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

                    _interativo_tela.cor_image_1 = Cores.Pegar_cor( cor_imagem_1 ) ;
                    _interativo_tela.cor_image_2 = Cores.Pegar_cor( cor_imagem_2 ) ;


                    _interativo_tela.cores_imagem_1_ids_unicos_por_periodo[ periodo_id ] = ( int ) cor_imagem_1;
                    _interativo_tela.cores_imagem_2_ids_unicos_por_periodo[ periodo_id ] = ( int ) cor_imagem_2;

                    return;

            }






            public static void Colocar_sprites_interativo_tela_DESENVOLVIMENTO(  Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados , Interativo_tela _interativo ){





                    // // **como vai lidar com imagens especiais? 


                    int periodo_id = Controlador_timer.Pegar_instancia().periodo_atual_id;


                    string path_imagem = _interativo_dados.path_imagem;
                    string sufixo_modelo = Pegar_sufixo_interativo_modelos_DESENVOLVIMENTO( _interativo_dados );
                    string sufixo_numero = "";


                    string path_imagem_1 = null;
                    string path_imagem_2 = null;






                    if     ( _interativo_dados.metodo_IMAGENS_DISPONIVEIS_no_mouse_hover == Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.nada_E_nada )
                            {

                                    // --- NAO TEM NENHUMA IMAGEM 

                                    _interativo.cores_imagem_1_ids_unicos_por_periodo[ periodo_id ] = ( int ) Nome_cor.transparente;
                                    _interativo.cores_imagem_2_ids_unicos_por_periodo[ periodo_id ] = ( int ) Nome_cor.transparente;

                                    _interativo.cor_image_1 = Cores.Pegar_cor( Nome_cor.transparente ) ;
                                    _interativo.cor_image_2 = Cores.Pegar_cor( Nome_cor.transparente ) ;

                                    _interativo.interativo_sprite_1 = null;
                                    _interativo.interativo_sprite_2 = null;

                                    return;


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
                                    path_imagem_2 = System.IO.Path.Combine( path_imagem, sufixo_modelo, sufixo_numero, ".png" );;

                                    _interativo.cores_imagem_2_ids_unicos_por_periodo[ periodo_id ] = ( int ) Nome_cor.transparente;
                                    _interativo.cor_image_2 = Cores.Pegar_cor( Nome_cor.transparente ) ;


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

                                byte[] png_imagem_1 = System.IO.File.ReadAllBytes( path_imagem_1 );
                                _interativo.interativo_sprite_1 = SPRITE.Transformar_png_TO_sprite( png_imagem_1 );

                            }

                    if( path_imagem_2 != null  )
                            {
                                if( ! ( System.IO.File.Exists( path_imagem_2 ) ))  
                                    { throw new Exception( $"pediu o path { path_imagem_2 } mas não tinha nenhum arquivo no local" ); }                                
                                    
                                byte[] png_imagem_2 = System.IO.File.ReadAllBytes( path_imagem_2 );
                                _interativo.interativo_sprite_1 = SPRITE.Transformar_png_TO_sprite( png_imagem_2 );

                            }

                    return;
                    

            }



        public static string Pegar_sufixo_interativo_modelos_DESENVOLVIMENTO( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados ){

                
                

                Periodo_tempo periodo_atual = ( ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id ) ;

                switch( _interativo_dados.metodo_que_as_imagens_estao_salvas ){


                        case Metodo_que_as_imagens_estao_salvas.dia_E_noite:        {
                                                                                        bool esta_claro  =  (
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
                        case Metodo_que_as_imagens_estao_salvas.todos_os_periodos:  { 
                            
                                                                                        return ( "_" + periodo_atual.ToString() );
                                                                                       
                                                                                    }
                                                                                    {break;}

                        case Metodo_que_as_imagens_estao_salvas.nome:  { 
                            
                                                                                        return ( "_" + periodo_atual.ToString() );
                                                                                       
                                                                                    }
                                                                                    {break;}

                        default: throw new Exception("");



                }

                return ( "_" + periodo_atual.ToString() );




        }


    }

#endif