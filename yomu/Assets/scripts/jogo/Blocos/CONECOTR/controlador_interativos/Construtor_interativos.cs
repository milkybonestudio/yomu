using System;
using UnityEngine;

public class Construtor_interativos {

        

        public Construtor_interativos( Controlador_interativos _controlador ){

            controlador_interativos = _controlador;

        }


        public Controlador_interativos controlador_interativos;

        // sempre vai ter todos os dados
        public byte[] localizador_dados_interativos;
        public byte[][] containers_dados_interativos;



        public Interativo_tela Criar_interativo_tela_DEVELOPMENT( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_tela_dados ){

                int interativo_id = _interativo_tela_dados.interativo_id;

                Interativo_tela interativo_retorno = new Interativo_tela( interativo_id );

                interativo_retorno.ponto_id = _interativo_tela_dados.posicao_local.ponto_id;
                interativo_retorno.tipo_interativo_id = ( int ) _interativo_tela_dados.tipo_interativo;
                interativo_retorno.area = _interativo_tela_dados.area;

                 // **como vai lidar com imagens especiais? 


                int periodo_id = Controlador_timer.Pegar_instancia().periodo_atual_id;

        
                string interativo_enum_nome_DESENVOLVIMENTO = _interativo_tela_dados.enum_nome_interativo_DESENVOLVIMENTO; // interativo_enum_nome_DESENVOLVIMENTO => SAINT_LAND__CATHEDRAL__DORMITORIO_FEMININO_interativo 
                string interativo_nome_DESENVOLVIMENTO =  _interativo_tela_dados.nome_insterativo_DESENVOLVIMENTO; // interativo_nome_DESENVOLVIMENTO => NARA_ROOM__up__janela


                // --- Pegar_path


                string[] folders_ate_interativos = interativo_enum_nome_DESENVOLVIMENTO.Split( "__" );

                if( folders_ate_interativos.Length != 3 )
                        { throw new Exception( $"formato de interativo_enum_nome_DESENVOLVIMENTO nao aceito. Veio: { interativo_enum_nome_DESENVOLVIMENTO }" ); }
                
                
                string path_imagens_interativos = Paths_gerais.Pegar_path_imagens_interativos_DESENVOLVIMENTO();


                string cidade = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 0 ] );
                string regiao = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 1 ] );
                string area = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 2 ] );


                string[] folder_final__E__imagem = interativo_nome_DESENVOLVIMENTO.Split( "__" );

                string folder_final = folder_final__E__imagem[ 0 ].ToLower();
                string imagem = folder_final__E__imagem[ 1 ].ToLower();
                
        
                string[] path_imagem_array    =   new  string[] { 

                                                                path_imagens_interativos, 
                                                                cidade, 
                                                                regiao, 
                                                                area, 
                                                                folder_final, 
                                                                imagem 
                                                        };

                _interativo_tela_dados.path_imagem = System.IO.Path.Combine( path_imagem_array );

                // COLOCAR COR CURSOR



                // COLOCAR COR IMAGEM

                Nome_cor cor_imagem_1 = Nome_cor.nada;
                Nome_cor cor_imagem_2 = Nome_cor.nada; 


                if     ( _interativo_tela_dados.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cores_especificas )
                        {
                                // PEGAR CORES ESPECIFICAS 

                                cor_imagem_1 =  _interativo_tela_dados.cor_primeira_imagem ;
                                cor_imagem_2 =  _interativo_tela_dados.cor_segunda_imagem ;

                        }
                else if( _interativo_tela_dados.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.cor_especifica )
                        {
                                // PEGAR COR ESPECIFICA

                                cor_imagem_1 =  _interativo_tela_dados.cor_imagens ;
                                cor_imagem_2 =  _interativo_tela_dados.cor_imagens ;

                        }
                else if( _interativo_tela_dados.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.core_80_e_100 )
                        {
                                // PEGAR COR  80 / 100  

                                cor_imagem_1 =  Nome_cor.white_080 ;
                                cor_imagem_2 =  Nome_cor.white_100 ;

                        }
                else if( _interativo_tela_dados.metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover == Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.normal )
                        {
                                // DEFINE AS 2 COMO WHITE

                                cor_imagem_1 =  Nome_cor.white ;
                                cor_imagem_2 =  Nome_cor.white ;

                        }

                interativo_retorno.cor_image_1 = Cores.Pegar_cor( cor_imagem_1 ) ;
                interativo_retorno.cor_image_2 = Cores.Pegar_cor( cor_imagem_2 ) ;


                interativo_retorno.cores_imagem_1_ids_unicos_por_periodo[ periodo_id ] = ( int ) cor_imagem_1;
                interativo_retorno.cores_imagem_2_ids_unicos_por_periodo[ periodo_id ] = ( int ) cor_imagem_2;

                // COLOCAR SHADDER 
                // fazer
                // ...


                return interativo_retorno;



        }



        //** faz depois
        public Interativo_personagem[] Criar_interativos_tipo_personagem( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }
        public Interativo_item[] Criar_interativos_tipo_item( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }


        // ** nao vai criar as imagens
        public Interativo_tela[] Criar_interativo_tipo_tela( int[] _lista_ids ){


                
        
                return null;

        }

}