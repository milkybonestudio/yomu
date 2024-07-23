using System;
using System.IO;
using UnityEngine;
using System.Runtime.CompilerServices;



public class MODULO_manipulador_imagens_dinamicas {

        public MODULO_manipulador_imagens_dinamicas( string _nome_modulo , string _path_container, int _numero_inicial_de_slots  ){


            if( !( System.IO.File.Exists( _path_container ) ) )
                { throw new Exception();}


            nome_modulo = _nome_modulo;

            path_container = _path_container;


            sprite_ids_unicos = new int[ _numero_inicial_de_slots ];

            sprites_atuais = new Sprite[ _numero_inicial_de_slots ];
            pngs_atuais = new byte[ _numero_inicial_de_slots ][];

            frames_para_guardar_sprites = new int[ _numero_inicial_de_slots ];
            frames_para_guardar_pngs = new int[ _numero_inicial_de_slots ];

            requisicoes_imagens = new Task_req[ _numero_inicial_de_slots ];

        }

        public string nome_modulo;
        
        // SO VAI SER UUSADO NA BUILD  
        // com 5000 * 4 = 20kb. se ficar muito grande pode separar por continenete ou reino ou cidade
        public byte[] localizador;
        public string path_container;

        public int[] sprite_ids_unicos;

        //--- SPRITE 
        public Sprite[] sprites_atuais;
        public int[] frames_para_guardar_sprites;

        // --- PNGS
        public byte[][] pngs_atuais;
        public int[] frames_para_guardar_pngs;


        public Task_req[] requisicoes_imagens;

        public int total_bytes_imagens = 0;



        public void Update(){

            // -1 => guardar indefinidamente 
            //  0 => ja excluiu
            // >0 => esperando para excluir


            for( int sprite_slot = 0 ; sprite_slot < sprite_ids_unicos.Length ; sprite_slot++ ){

                    // --- VERIFICA SE O SLOT ESTA SENDO USADO
                    if( sprite_ids_unicos[ sprite_slot ] == 0 )
                        { continue; } // --- NAO ESTA SENDO USADO




                    // --- VERIFICA SE O SLOT SPRITE PODE SER EXCLUIDO
                    if( frames_para_guardar_sprites[ sprite_slot ] == 1 )
                        { 
                            // --- PODE SER APAGADO ESSE FRAME
                            frames_para_guardar_sprites[ sprite_slot ] = 0;
                            sprites_atuais[ sprite_slot ] = null;
                        } 

                    // --- VERIFICAR SE TEM TEMPO PARA DESCONTAR
                    if( frames_para_guardar_sprites[ sprite_slot ] > 1 )
                        { frames_para_guardar_sprites[ sprite_slot ]--; } // --- TIRA 1 FRAME 
                    

                    
                        
                    // --- VERIFICA SE O SLOT SPRITE PODE SER EXCLUIDO
                    if( frames_para_guardar_sprites[ sprite_slot ] == 1 )
                        { 
                            // --- PODE SER APAGADO ESSE FRAME
                            frames_para_guardar_pngs[ sprite_slot ] = 0;
                            sprites_atuais[ sprite_slot ] = null;
                        } 
                    

                    // --- VERIFICAR SE TEM TEMPO PARA DESCONTAR
                    if( frames_para_guardar_pngs[ sprite_slot ] > 1 )
                        { frames_para_guardar_pngs[ sprite_slot ]--; } // --- TIRA 1 FRAME 





                    // --- VERIFICA SE PODE APAGAR SLOT            
                    if( sprites_atuais[ sprite_slot ] == null && pngs_atuais[ sprite_slot ] == null )
                        { sprite_ids_unicos[ sprite_slot ] = 0;  }// --- SLOT VAI SER LIMPO


                    // --- VAI PARA O PROXIMO
                    continue;

            }



        }



        public void Mudar_tempo_imagem( int _sprite_id_unico, int _tempo_para_salvar_sprite, int _tempo_para_salvar_png ){

                // -- VERIFICA SE JA FOI PEDIDO
                int slot_pedido = INT.Pegar_index_valor( sprite_ids_unicos , _sprite_id_unico );

                if( slot_pedido == -1 )
                    { throw new Exception( $"Nao foi achado a sprite com o id { _sprite_id_unico }" ); }
                
                // --- JA FOI PEDIDO

                frames_para_guardar_pngs[ slot_pedido ] = _tempo_para_salvar_png;
                frames_para_guardar_sprites[ slot_pedido ] = _tempo_para_salvar_sprite;

                return;
            

        }







        public void Carregar_pngs( int[] _pngs_ids_unicos, int _tempo_para_salvar_sprites, int _tempo_para_salvar_pngs ){


                // --- VER O MELHOR JEITO PARA CARREGAR
                // *** 


        }



        public void Carregar_png( int _sprite_id_unico, int _tempo_para_salvar_sprite, int _tempo_para_salvar_png ){


                // -- VERIFICA SE JA FOI PEDIDO

                int slot_pedido = INT.Pegar_index_valor( sprite_ids_unicos , _sprite_id_unico );

                if( slot_pedido != -1 )
                    {
                        // --- JA FOI PEDIDO

                        frames_para_guardar_pngs[ slot_pedido ] = _tempo_para_salvar_png;
                        frames_para_guardar_sprites[ slot_pedido ] = _tempo_para_salvar_sprite;

                        return;

                    }
                



                // --- PEGAR SLOT VAZIO
                int slot_vazio = INT.Pegar_index_valor( sprite_ids_unicos , 0 );


                // --- VERIFICAR SE TEM SLOT VAZIO
                if( slot_vazio == -1 )
                    { 
                        // --- PEGA O PRIMEIRO NOVO ELEMENTO
                        slot_vazio = sprite_ids_unicos.Length;
                        
                        // --- VAI EXTENDER
                        Aumentar_length_arrays( _quantidade_para_aumentar: 10 );
                    }
                

                // --- CRIA PEDIDO PARA CARREGAR NA MULTINTHREAD
                Task_req req = new Task_req( new Chave_cache(), ( "pedindo_imagem_" + Convert.ToString( _sprite_id_unico ) ) );
                requisicoes_imagens[ slot_vazio ] = req;
                sprite_ids_unicos[ slot_vazio ] = _sprite_id_unico;
                

                // --- PARTE MULTITHREAD
                req.fn_iniciar = ( Task_req _req )  =>  {
                                                            byte[] png = Pegar_png( _sprite_id_unico );
                                                            _req.dados = ( System.Object ) png;
                                                            return;
                                                        };

                // --- PARTE MAIN THREAD
                req.fn_finalizar = ( Task_req _req ) => {
                                                            byte[] png =  ( byte[] ) _req.dados;
                                                            pngs_atuais[ slot_vazio ] = png;
                                                            return;
                                                        };
            

                return;


        }




        // *** precisa mudar tudo



        public void Carregar_sprite( int _sprite_id_unico, int _tempo_para_salvar_sprite, int _tempo_para_salvar_png ){


                // -- VERIFICA SE JA FOI PEDIDO

                int slot_pedido = INT.Pegar_index_valor( sprite_ids_unicos , _sprite_id_unico );

                if( slot_pedido != -1 )
                    {
                        // --- JA FOI PEDIDO

                        frames_para_guardar_pngs[ slot_pedido ] = _tempo_para_salvar_png;
                        frames_para_guardar_sprites[ slot_pedido ] = _tempo_para_salvar_sprite;

                        return;

                    }
                



                // --- PEGAR SLOT VAZIO
                int slot_vazio = INT.Pegar_index_valor( sprite_ids_unicos , 0 );


                // --- VERIFICAR SE TEM SLOT VAZIO
                if( slot_vazio == -1 )
                    { 

                        // --- PEGA O PRIMEIRO NOVO ELEMENTO
                        slot_vazio = sprite_ids_unicos.Length;
                        
                        // --- VAI EXTENDER
                        Aumentar_length_arrays( _quantidade_para_aumentar: 10 );
                    }
                

                // --- CRIA PEDIDO PARA CARREGAR NA MULTINTHREAD
                Task_req req = new Task_req( new Chave_cache(), ("pedindo_imagem_" + Convert.ToString( _sprite_id_unico ) ) );
                requisicoes_imagens[ slot_vazio ] = req;
                sprite_ids_unicos[ slot_vazio ] = _sprite_id_unico;
                

                // --- PARTE MULTITHREAD
                req.fn_iniciar = ( Task_req _req )  =>  {
                                                            byte[] png = Pegar_png( _sprite_id_unico );
                                                            Color32[] pixels_containers =  PNG.Descomprimir( png );
                                                            _req.dados = ( System.Object ) pixels_containers;
                                                            _req.dados_suporte_1 =  ( System.Object ) PNG.Pegar_width_e_height( png );

                                                            frames_para_guardar_pngs[ slot_vazio ] = _tempo_para_salvar_png;
                                                            frames_para_guardar_sprites[ slot_vazio ] = _tempo_para_salvar_sprite;

                                                            return;

                                                        };

                // --- PARTE MAIN THREAD
                req.fn_finalizar = ( Task_req _req ) => {
                                                            Color32[] container =  ( Color32[] ) _req.dados;
                                                            int[] width__E__height  = ( int[] ) _req.dados_suporte_1;
                                                            Sprite sprite = SPRITE.Transformar_colors_container_TO_sprite( container, width__E__height[ 0 ], width__E__height[ 1 ] );

                                                            sprites_atuais[ slot_vazio ]  = sprite;

                                                            
                                                            return;

                                                        };
            

                return;


        }













        public Sprite Pegar_sprite(  int _localizador,   int _pointer_inicial, int _length,  int _tempo_para_salvar_png, int _tempo_para_salvar_sprite ){


                // --- PEGA O SLOT DA IMAGEM
                int slot_sprite = INT.Pegar_index_valor( sprite_ids_unicos , _localizador );

                Sprite sprite_retorno = null;

                // --- VERIFICA SE FOI PEDIDO
                if( slot_sprite == -1 )
                    {
                        // --- NAO FOI PEDIDO

                        byte[] png = Pegar_png( _localizador );
                        sprite_retorno = SPRITE.Transformar_png_TO_sprite( png );

                        // --- PEGA SLOT VAZIO
                        int slot_vazio = INT.Pegar_index_valor( sprite_ids_unicos , 0 );

                        // --- VERIFICA SE TEM SLOT VAZIO
                        if( slot_vazio == -1 )
                            { 
                                // --- PEGA O PRIMEIRO NOVO ELEMENTO
                                slot_vazio = sprite_ids_unicos.Length;
                                // --- VAI EXTENDER
                                Aumentar_length_arrays( _quantidade_para_aumentar: 10 );
                            }

                        slot_sprite = slot_vazio;

                        // --- COLOCA OS DADOS NOS SLOTS 
                        sprite_ids_unicos[ slot_sprite ] = _localizador;
                        sprites_atuais[ slot_sprite ] = sprite_retorno;
                        pngs_atuais[ slot_sprite ] = png;   

                        // --- ATUALIZAR OS TEMPOS
                        frames_para_guardar_pngs[ slot_sprite ] = _tempo_para_salvar_png;
                        frames_para_guardar_sprites[ slot_sprite ] = _tempo_para_salvar_sprite;

                        return sprite_retorno;

                    }

                // --- VERIFICAR SE FOI CARREGADO SOMENTE O PNG

                if( sprites_atuais[ slot_sprite ] == null && pngs_atuais[ slot_sprite ] != null )
                    {
                        // --- TEM SOMENTE O PNG 

                        sprite_retorno = SPRITE.Transformar_png_TO_sprite( pngs_atuais[ slot_sprite ] );
                        
                        // --- ATUALIZAR OS TEMPOS
                        frames_para_guardar_pngs[ slot_sprite ] = _tempo_para_salvar_png;
                        frames_para_guardar_sprites[ slot_sprite ] = _tempo_para_salvar_sprite;


                        return sprite_retorno;

                    }


                // --- VERIFICAR SE TERMINOU DE CARREGAR
                if( sprites_atuais[ slot_sprite ] == null )
                    {            
                        // ---  NAO TERMONOU DE CARREGAR

                        requisicoes_imagens[ slot_sprite ].pode_executar = false;
                        requisicoes_imagens[ slot_sprite ] = null;

                        // --- 
                        byte[] png_forcado = Pegar_png( _localizador, _length );
                        Sprite sprite_forcada = SPRITE.Transformar_png_TO_sprite( png_forcado );

                        sprites_atuais[ slot_sprite ] = sprite_forcada;   
                        pngs_atuais[ slot_sprite ] = png_forcado;   

                    }
                    else
                    {
                        // --- SPRITE FOI CARRADADA COM ANTECEDENCIA
                        sprite_retorno = sprites_atuais[ slot_sprite ];
                    }

                    // --- ATUALIZAR OS TEMPOS
                    frames_para_guardar_pngs[ slot_sprite ] = _tempo_para_salvar_png;
                    frames_para_guardar_sprites[ slot_sprite ] = _tempo_para_salvar_sprite;

                // --- CARREGADA COM SUCESSO

                return sprite_retorno;
                

        }
















        public Sprite Pegar_sprite(  int _sprite_id, int _tempo_para_salvar_png, int _tempo_para_salvar_sprite ){

                throw new Exception( "tem que testar" );

                // sprite_id => id unico de cada imagem 

                // ** iria pegar em um localizador que sempre vai estar na ram 
                // se nao estiver carregado força na main 

                // --- PEGA O SLOT DA IMAGEM
                int slot_sprite = INT.Pegar_index_valor( sprite_ids_unicos , _sprite_id );

                Sprite sprite_retorno = null;

                // --- VERIFICA SE FOI PEDIDO
                if( slot_sprite == -1 )
                    {
                        // --- NAO FOI PEDIDO

                        byte[] png = Pegar_png( _sprite_id );
                        sprite_retorno = SPRITE.Transformar_png_TO_sprite( png );

                        // --- PEGA SLOT VAZIO
                        int slot_vazio = INT.Pegar_index_valor( sprite_ids_unicos , 0 );

                        // --- VERIFICA SE TEM SLOT VAZIO
                        if( slot_vazio == -1 )
                            { 
                                // --- PEGA O PRIMEIRO NOVO ELEMENTO
                                slot_vazio = sprite_ids_unicos.Length;
                                // --- VAI EXTENDER
                                Aumentar_length_arrays( _quantidade_para_aumentar: 10 );
                            }

                        slot_sprite = slot_vazio;

                        // --- COLOCA OS DADOS NOS SLOTS 
                        sprite_ids_unicos[ slot_sprite ] = _sprite_id;
                        sprites_atuais[ slot_sprite ] = sprite_retorno;
                        pngs_atuais[ slot_sprite ] = png;   

                        // --- ATUALIZAR OS TEMPOS
                        frames_para_guardar_pngs[ slot_sprite ] = _tempo_para_salvar_png;
                        frames_para_guardar_sprites[ slot_sprite ] = _tempo_para_salvar_sprite;

                        return sprite_retorno;

                    }

                // --- VERIFICAR SE FOI CARREGADO SOMENTE O PNG

                if( sprites_atuais[ slot_sprite ] == null && pngs_atuais[ slot_sprite ] != null )
                    {
                        // --- TEM SOMENTE O PNG 

                        sprite_retorno = SPRITE.Transformar_png_TO_sprite( pngs_atuais[ slot_sprite ] );
                        
                        // --- ATUALIZAR OS TEMPOS
                        frames_para_guardar_pngs[ slot_sprite ] = _tempo_para_salvar_png;
                        frames_para_guardar_sprites[ slot_sprite ] = _tempo_para_salvar_sprite;


                        return sprite_retorno;

                    }


                // --- VERIFICAR SE TERMINOU DE CARREGAR
                if( sprites_atuais[ slot_sprite ] == null )
                    {            
                        // ---  NAO TERMONOU DE CARREGAR

                        requisicoes_imagens[ slot_sprite ].pode_executar = false;
                        requisicoes_imagens[ slot_sprite ] = null;

                        // --- 
                        byte[] png_forcado = Pegar_png( _sprite_id );
                        Sprite sprite_forcada = SPRITE.Transformar_png_TO_sprite( png_forcado );

                        sprites_atuais[ slot_sprite ] = sprite_forcada;   
                        pngs_atuais[ slot_sprite ] = png_forcado;   

                    }
                    else
                    {
                        // --- SPRITE FOI CARRADADA COM ANTECEDENCIA
                        sprite_retorno = sprites_atuais[ slot_sprite ];
                    }

                    // --- ATUALIZAR OS TEMPOS
                    frames_para_guardar_pngs[ slot_sprite ] = _tempo_para_salvar_png;
                    frames_para_guardar_sprites[ slot_sprite ] = _tempo_para_salvar_sprite;

                // --- CARREGADA COM SUCESSO

                return sprite_retorno;
                

        }





        public byte[] Pegar_png( int _pointer_inicial, int _length ){

                

                FileStream leitor = new FileStream( path_container, FileMode.Open );
                leitor.Seek(  _pointer_inicial  , SeekOrigin.Begin  );

                byte[] buffer = new byte[ _length ];

                leitor.Read(  buffer, 0, _length  );
                leitor.Close();

                return buffer;


        }






        public byte[] Pegar_png( int _sprite_id_unico ){


                // PEGAR RUN TIME

                int pointer_1 = BYTE.Pegar_int_em_byte_array( localizador , ( _sprite_id_unico * 4 ) + 0 );
                int pointer_2 = BYTE.Pegar_int_em_byte_array( localizador , ( _sprite_id_unico * 4 ) + 4 );

                
                int length = ( pointer_2 - pointer_1 - 1 ) ;

                FileStream leitor = new FileStream( path_container, FileMode.Open );
                leitor.Seek(  pointer_1  , SeekOrigin.Begin  );

                byte[] buffer = new byte[ length ];

                leitor.Read(  buffer, 0, length  );
                leitor.Close();

                return buffer;


        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Aumentar_length_arrays( int _quantidade_para_aumentar ){

                // --- EXTENDE OS ARRAYS
                sprite_ids_unicos = INT.Aumentar_length_array( sprite_ids_unicos , _quantidade_para_aumentar ); 
                pngs_atuais =  BYTE.Aumentar_length_array_2d( pngs_atuais , _quantidade_para_aumentar ); 
                frames_para_guardar_pngs = INT.Aumentar_length_array( frames_para_guardar_pngs , _quantidade_para_aumentar ); 
                frames_para_guardar_sprites = INT.Aumentar_length_array( frames_para_guardar_sprites , _quantidade_para_aumentar ); 

                sprites_atuais = SPRITE.Aumentar_length_array( sprites_atuais , _quantidade_para_aumentar );

                return;

        }


}