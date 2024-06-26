using System;
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
                        sprites_atuais[ slot_sprite ] = nova_sprite;   
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

        #if UNITY_EDITOR || true
        

            public Sprite Pegar_sprite_DESENVOLVIMENTO( string _interativo_enum_nome_DESENVOLVIMENTO, string _interativo_nome_DESENVOLVIMENTO, string _sufixo ){

                    throw new Exception( "testar aqui" );

                    // _interativo_enum_nome_DESENVOLVIMENTO => SAINT_LAND__CATHEDRAL__DORMITORIO_FEMININO_interativo 

                    // _interativo_nome_DESENVOLVIMENTO => NARA_ROOM__up__janela

                    // transformar em: saint_land/cathedral/dormitorio_feminino/nara_room/up__janela.png
                    // folder nao pode estar no folder do editor

                    // sufixo = _d, _n, "",  _0, _1, _2, _3, _4,  

                    string[] folders_ate_interativos = _interativo_enum_nome_DESENVOLVIMENTO.Split( "__" );

                    if( folders_ate_interativos.Length != 3 )
                        { throw new Exception( $"formato de _interativo_enum_nome_DESENVOLVIMENTO nao aceito. Veio: { _interativo_enum_nome_DESENVOLVIMENTO }" ); }
                    
                    
                    string path_imagens = Paths_gerais.Pegar_path_imagens_DESENVOLVIMENTO();


                    string cidade = folders_ate_interativos[ 0 ].ToLower();
                    string regiao = folders_ate_interativos[ 1 ].ToLower();
                    string area = folders_ate_interativos[ 2 ].Split( "_" )[ 0 ].ToLower();


                    string folder_final__E__imagem = _interativo_nome_DESENVOLVIMENTO.Split( "__" );

                    string folder_final = folder_final__E__imagem[ 0 ].ToLower();
                    string imagem = folder_final__E__imagem[ 1 ].ToLower() ;

                    string path_imagem = System.IO.Path.Combine(   
                        
                            new string[]{

                                path_imagens,
                                "interativos",
                                cidade, 
                                regiao,
                                area,
                                folder_final, 
                                ( imagem + _sufixo + ".png" )
                            
                            }

                    );

                    byte[] png = System.IO.File.ReadAlllBytes( path_imagem );

                    sprite = SPRITE.Pegar_imagem( png );

                    return sprite;


            }

        #endif



        public Sprite Criar_sprite( int _sprite_id ){


                // PEGAR RUN TIME

                int pointer_1 = BYTE.Pegar_int_em_byte_array( localizador , ( _sprite_id * 4 ) + 0 );
                int pointer_2 = BYTE.Pegar_int_em_byte_array( localizador , ( _sprite_id * 4 ) + 4 );

                
                int length = ( pointer_2 - pointer_1 - 1 ) ;

                string path = Paths_sistem.path_imagens_interativos;
                FileStream leitor = new FileStream( path_imagens_interativos );
                leitor.Seek(  pointer_1  , SeekOrigin.begin  );

                byte[] buffer = new byte[ length ];

                leitor.Read(  buffer, 0, length  );


                Sprite nova_sprite = SPRITE.Transformar_byte_in_sprite( buffer );

                return nova_sprite;

        }

        public void Carregar_sprite( int _interativo_imagem_id ){
                // começa a carregar na multitheread 

                throw new Exception( "fazer depois" );

        }


        protected void Pegar_dia_E_noite(){


            if( _periodo < 3 )
                { 
                    variante_periodo = "_d"; 
                } 
                else 
                { variante_periodo = "_n";}


        }




}