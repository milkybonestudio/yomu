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
        public int[] sprite_ids;
        public Task_req[] requisicoes_imagens;

        public int total_bytes_imagens = 0;

        // setar depois 
        public int cidade_pointer_no_localizador;



        public Gerenciador_imagens_interativos(){

            sprites_atuais = new Sprite[ 50 ];
            sprite_ids = new int[ 50 ];
            requisicoes_imagens = new Task_req[ 50 ];

            
        }

    
    
        public Sprite Pegar_sprite(  int _sprite_id ){

                // sprite_id => id unico de cada imagem 

                // ** iria pegar em um localizador que sempre vai estar na ram 
                // se nao estiver carregado força na main 

                // inverter ordem depois 

                throw  new Exception( "ainda nao esta pronto" );

                int slot_sprite = INT.Pegar_index_valor( sprite_ids , _sprite_id );


                // --- NAO FOI PEDIDO PARA CARREGAR

                if( slot_sprite == -1 )
                    {
                        Sprite sprite = Criar_sprite( _sprite_id );
                        int slot_vazio = INT.Pegar_index_valor( sprite_ids , 0 );
                        if( slot_vazio == -1 )
                            { 
                                slot_vazio = sprite_ids.Length;
                                sprite_ids = INT.Aumentar_length_array( sprite_ids , 10 ); 
                                sprites_atuais = SPRITE.Aumentar_length_array( sprites_atuais , 10 );
                            }

                        slot_sprite = slot_vazio;

                        sprite_ids[ slot_sprite ] = _sprite_id;
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

                int slot_vazio = INT.Pegar_index_valor( sprite_ids , 0 );
                if( slot_vazio == -1 )
                    { 
                        slot_vazio = sprite_ids.Length;
                        sprite_ids = INT.Aumentar_length_array( sprite_ids , 10 ); 
                        sprites_atuais = SPRITE.Aumentar_length_array( sprites_atuais , 10 );
                    }

                
                requisicoes_imagens[ slot_vazio ] = req;
                sprite_ids[ slot_vazio ] = _sprite_id_unico;
                


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
        

            public Sprite Pegar_sprite_DESENVOLVIMENTO( Interativo_tela _interativo ){


                    
                    string interativo_enum_nome_DESENVOLVIMENTO = _interativo.enum_nome_interativo_DESENVOLVIMENTO;
                    string interativo_nome_DESENVOLVIMENTO =  _interativo.nome_insterativo_DESENVOLVIMENTO;
                    string _sufixo = Pegar_sufixo_interativo_DESENVOLVIMENTO( _interativo );

                    // tem que pegar o nome em outro lugar 

                    throw new Exception( "testar aqui" );

                    // interativo_enum_nome_DESENVOLVIMENTO => SAINT_LAND__CATHEDRAL__DORMITORIO_FEMININO_interativo 

                    // interativo_nome_DESENVOLVIMENTO => NARA_ROOM__up__janela

                    // transformar em: saint_land/cathedral/dormitorio_feminino/nara_room/up__janela.png
                    // folder nao pode estar no folder do editor

                    // sufixo = _d, _n, "",  _0, _1, _2, _3, _4,  

                    string[] folders_ate_interativos = interativo_enum_nome_DESENVOLVIMENTO.Split( "__" );

                    if( folders_ate_interativos.Length != 3 )
                        { throw new Exception( $"formato de interativo_enum_nome_DESENVOLVIMENTO nao aceito. Veio: { interativo_enum_nome_DESENVOLVIMENTO }" ); }
                    
                    
                    string path_imagens_interativos = Paths_gerais.Pegar_path_imagens_interativos_DESENVOLVIMENTO();


                    string cidade = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 0 ] );
                    string regiao = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 1 ] );
                    string area = STRING.Deixar_somente_a_primeira_letra_maiuscula( folders_ate_interativos[ 2 ] );


                    string[] folder_final__E__imagem = interativo_nome_DESENVOLVIMENTO.Split( "__" );

                    string folder_final = folder_final__E__imagem[ 0 ].ToLower();
                    string imagem = folder_final__E__imagem[ 1 ].ToLower() ;

                    string[] nomes   =  new string[]{
                                                        path_imagens_interativos,
                                                        cidade, 
                                                        regiao,
                                                        area,
                                                        folder_final, 
                                                        ( imagem + _sufixo + ".png" )
                                                
                                                    };

                    string path_imagem = System.IO.Path.Combine( nomes );

                    byte[] png = System.IO.File.ReadAllBytes( path_imagem );

                    Sprite sprite = SPRITE.Transformar_png_TO_sprite( png );

                    return sprite;


            }

        #endif


        public string Pegar_sufixo_interativo_DESENVOLVIMENTO( Interativo_tela _interativo ){


                Periodo_tempo periodo_atual = ( ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id ) ;

                switch(  ( Tipo_sufixo_para_pegar_imagem ) _interativo.tipo_sufixo_para_pegar_imagem_id ){




                        case Tipo_sufixo_para_pegar_imagem.dia_E_noite:         {
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


                        case Tipo_sufixo_para_pegar_imagem.todos_os_periodos:   {

                                                                                    _interativo.nomes_imagens_espoecificas_periodos
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





        protected void Pegar_dia_E_noite(){




        }




}