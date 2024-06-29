using System;
using System.IO;
using UnityEngine;

// personagens e icones nao precisam de tanto trabalho. talvez?

public class Gerenciador_imagens_interativos {

        public Gerenciador_imagens_interativos( byte[] _localizador  ){

            #if !UNITY_EDITOR

                string path_lista_localizador = Paths_sistema.path_localizador_interativos;
                localizador = System.IO.File.ReadAllByte( path_lista_localizador ) ;

            #endif

        }

        
        // SO VAI SER UUSADO NA BUILD  
        // com 5000 * 4 = 20kb. se ficar muito grande pode separar por continenete ou reino ou cidade
        public byte[] localizador;

        public Sprite[] sprites_atuais;
        public int[] sprite_ids_unicos;
        public Task_req[] requisicoes_imagens;

        public int total_bytes_imagens = 0;

        // setar depois 
        public int cidade_pointer_no_localizador;



        public Gerenciador_imagens_interativos(){

            sprites_atuais = new Sprite[ 50 ];
            sprite_ids_unicos = new int[ 50 ];
            requisicoes_imagens = new Task_req[ 50 ];

            
        }

    
    
        public Sprite Pegar_sprite(  int _sprite_id ){

                // sprite_id => id unico de cada imagem 

                // ** iria pegar em um localizador que sempre vai estar na ram 
                // se nao estiver carregado força na main 

                // inverter ordem depois 

                throw  new Exception( "ainda nao esta pronto" );

                int slot_sprite = INT.Pegar_index_valor( sprite_ids_unicos , _sprite_id );


                // --- NAO FOI PEDIDO PARA CARREGAR

                if( slot_sprite == -1 )
                    {
                        Sprite sprite = Criar_sprite( _sprite_id );
                        int slot_vazio = INT.Pegar_index_valor( sprite_ids_unicos , 0 );
                        if( slot_vazio == -1 )
                            { 
                                slot_vazio = sprite_ids_unicos.Length;
                                sprite_ids_unicos = INT.Aumentar_length_array( sprite_ids_unicos , 10 ); 
                                sprites_atuais = SPRITE.Aumentar_length_array( sprites_atuais , 10 );
                            }

                        slot_sprite = slot_vazio;

                        sprite_ids_unicos[ slot_sprite ] = _sprite_id;
                        sprites_atuais[ slot_sprite ] = sprite;   
                        return sprite;

                    }


                // ---  NAO TERMONOU DE CARREGAR

                if( sprites_atuais[ slot_sprite ] == null )
                    {            
                        requisicoes_imagens[ slot_sprite ].pode_executar = false;
                        requisicoes_imagens[ slot_sprite ] = null;
                        Sprite sprite = Criar_sprite( _sprite_id );
                    }


                // --- CARREGADA COM SUCESSO

                return sprites_atuais[ slot_sprite ];
                

        }


        public byte[] Pegar_png( int _sprite_id_unico ){


                // PEGAR RUN TIME

                int pointer_1 = BYTE.Pegar_int_em_byte_array( localizador , ( _sprite_id_unico * 4 ) + 0 );
                int pointer_2 = BYTE.Pegar_int_em_byte_array( localizador , ( _sprite_id_unico * 4 ) + 4 );

                
                int length = ( pointer_2 - pointer_1 - 1 ) ;

                string path_imagens_interativos = Paths_sistema.path_imagens_interativos;
                FileStream leitor = new FileStream( path_imagens_interativos, FileMode.Open );
                leitor.Seek(  pointer_1  , SeekOrigin.Begin  );

                byte[] buffer = new byte[ length ];

                leitor.Read(  buffer, 0, length  );
                leitor.Close();

                return buffer;


        }


        public Sprite Criar_sprite( int _sprite_id_unico ){

                byte[] dados = Pegar_png( _sprite_id_unico );
                Sprite nova_sprite = SPRITE.Transformar_png_TO_sprite( dados );

                return nova_sprite;

        }







        public void Carregar_sprite( int _sprite_id_unico ){
                // começa a carregar na multitheread 

                throw new Exception( "fazer depois" );

                // pegar slot



                Task_req req = new Task_req( new Chave_cache(), ("pedindo_imagem_" + Convert.ToString( _sprite_id_unico ) ) );

                int slot_vazio = INT.Pegar_index_valor( sprite_ids_unicos , 0 );
                if( slot_vazio == -1 )
                    { 
                        slot_vazio = sprite_ids_unicos.Length;
                        sprite_ids_unicos = INT.Aumentar_length_array( sprite_ids_unicos , 10 ); 
                        sprites_atuais = SPRITE.Aumentar_length_array( sprites_atuais , 10 );
                    }

                
                requisicoes_imagens[ slot_vazio ] = req;
                sprite_ids_unicos[ slot_vazio ] = _sprite_id_unico;
                


                req.fn_iniciar = ( Task_req _req )  =>  {
                                                            // 

                                                            byte[] png = Pegar_png( _sprite_id_unico );
                                                            Color32[] pixels_containers =  PNG.Descomprimir( png );
                                                            _req.dados = ( System.Object ) pixels_containers;
                                                            _req.dados_suporte_1 =  ( System.Object ) PNG.Pegar_width_e_height( png );

                                                            return;

                                                        };

                req.fn_finalizar = ( Task_req _req )  =>  {
                                                            // 

                                                            Color32[] container =  ( Color32[] ) _req.dados;
                                                            int[] width__E__height  = ( int[] ) _req.dados_suporte_1;
                                                            Sprite sprite = SPRITE.Transformar_colors_container_TO_sprite( container, width__E__height[ 0 ], width__E__height[ 1 ] );

                                                            sprites_atuais[ slot_vazio ]  = sprite;

                                                            
                                                            return;

                                                        };
            

                return;


        }




        #if UNITY_EDITOR 
        

            public void Colocar_sprites_interativo_tela_DESENVOLVIMENTO(  Interativo_tela_DADOS_DESENVOLVIMENTO _interativo_dados , Interativo_tela _interativo ){


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

        #endif










        public string Pegar_sufixo_interativo_modelos_DESENVOLVIMENTO( Interativo_tela_DADOS_DESENVOLVIMENTO _interativo ){

                // 


                Periodo_tempo periodo_atual = ( ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id ) ;

                switch( _interativo.metodo_que_as_imagens_estao_salvas ){




                        case Metodo_que_as_imagens_estao_salvas.dia_E_noite:         {
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


                                                                                    break;
                                                                                }


                        case Metodo_que_as_imagens_estao_salvas.todos_os_periodos:   {

                                                                                    //_interativo.nomes_imagens_espoecificas_periodos
                                                                                    switch( periodo_atual ){

                                                                                        // talvez mudar para _periodo?
                                                                                        case Periodo_tempo.manha: return "_0";
                                                                                        case Periodo_tempo.dia: return "_1";
                                                                                        case Periodo_tempo.tarde: return "_2";
                                                                                        case Periodo_tempo.noite: return "_3";
                                                                                        case Periodo_tempo.madrugada: return "_4";

                                                                                    }


                                                                                    break;
                                                                                }

                        default: throw new Exception("");



                }

                return ( "_" + periodo_atual.ToString() );




        }


}