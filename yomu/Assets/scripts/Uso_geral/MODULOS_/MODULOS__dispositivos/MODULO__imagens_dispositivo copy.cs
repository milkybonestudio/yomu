using UnityEngine;
using UnityEngine.UI;
using System;



public enum Tipo_pegar_sprite {

    nada, 
    imagem_especifica, 
    imagem_geral

}

public class MODULO__imagens_dispositivo {


        // Definir imagens para carregar => classe especifica
        // carregar => modulo
        // colocar imagens => modulo 
        // alterar imagens => classe especifica => modulo


        // --- MODULOS
        public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;

        public Material material_dispositivo;
        

        // --- DADOS
        public Sprite[] sprites_especificas;
        public Sprite[] sprites_geral;

        // ** nome
        int id_atual = 0;
        public string[] nomes;



        // ** define quais vao ser carregados

        // ** especifico
        public int[] imagens_especificos_ativas;
        public int[] pointers_imagens_especificas;
        public int[] lengths_imagens_especificas;


        // ** gerais
        public int pointer_imagens_gerais_atual;
        public string[] imagens_gerais_nomes;
        public string[] imagens_gerais_paths;
        



        public int[] localizador;
        public string nome_dispositivo;

        
        public System.Type tipo;
        public string[] folders;


        public string path_folder__imagens_DEVELOPMENT;


        public static string Pegar_path_imagens_DEVELOPMENT( string[] folders, string _nome_dispositivo ){

                // --- PATH ATE O FOLDER RAIZ 
                string path_folder__imagens_dispositivos = Paths_sistema.path_folder__imagens_dispositivos;

                // --- NOME DO FOLDER COM OS FOLDERS DA CATEGORIA
                string path_folder__interno_DEVELOPMENT = System.IO.Path.Combine( folders );
                path_folder__interno_DEVELOPMENT=  System.IO.Path.Combine( path_folder__interno_DEVELOPMENT, _nome_dispositivo );

                string path_folder__imagens_DEVELOPMENT = System.IO.Path.Combine( path_folder__imagens_dispositivos, path_folder__interno_DEVELOPMENT );

                if( !!!( System.IO.Directory.Exists( path_folder__imagens_DEVELOPMENT ) ) )
                    { 
                        Console.LogError( $"Nao foi achado a pasta com as imagens do dispositivo { _nome_dispositivo } que vão ser pegas no editor" );
                        Console.LogError( $"folder: <Color=lime><b>{ path_folder__imagens_dispositivos }</b></Color>" );
                        Console.LogError( $"Sub folder: <Color=lime><b>{ path_folder__interno_DEVELOPMENT }</b></Color>" );
                        throw new Exception( $"Nao foi achado o folder do path { path_folder__imagens_DEVELOPMENT } pedido no { _nome_dispositivo }" ); 
                    }

                // --- PATH PARA O FOLDER COM AS IMAGENS
                return path_folder__imagens_DEVELOPMENT;

        }
        


        public MODULO__imagens_dispositivo (  string _nome_dispositivo, string[] _folders, System.Type _tipo_imagens ){ 


                folders = _folders;
                nome_dispositivo = _nome_dispositivo;
                material_dispositivo = new Material( Shaders.normal );
                tipo = _tipo_imagens;
                

                int maximo_sprites_especificas = System.Enum.GetNames( _tipo_imagens ).Length;


                // ** especifico
                imagens_especificos_ativas = new int[ maximo_sprites_especificas ] ;
                pointers_imagens_especificas = new int[ maximo_sprites_especificas ] ;
                lengths_imagens_especificas = new int[ maximo_sprites_especificas ] ;


                int slots_iniciais_gerais = 15;
                imagens_gerais_nomes = new string[ slots_iniciais_gerais ];
                imagens_gerais_paths = new string[ slots_iniciais_gerais ];



                #if !UNITY_EDITOR


                        // ** so usado na build
                        string nome_arquivo = string.Concat( _folders, "__" );
                        nome_arquivo = System.IO.Path.ChangeExtension( nome_arquivo, ".png" );
                        string path_arquivo = System.IO.Path.Combine( Paths_sistema.path_folder__imagens_dispositivos, nome_arquivo );

                        desmembrador_de_arquivo  =  new MODULO__desmembrador_de_arquivo ( 
                                                                                            _gerenciador_nome : _nome_dispositivo,
                                                                                            _path_arquivo: path_arquivo,
                                                                                            _numero_inicial_de_slots: 15
                                                                                        );

                        byte[] localizador_bytes = desmembrador_de_arquivo.Pegar_dados( _localizador_id: -1, _ponto_inicial: 0, _length: 1_000 );
                        localizador = BYTE.Converter_para_int_array( localizador_bytes );

                #else 

                    // --- PATH PARA O FOLDER COM AS IMAGENS
                    path_folder__imagens_DEVELOPMENT = MODULO__imagens_dispositivo.Pegar_path_imagens_DEVELOPMENT( _folders, _nome_dispositivo );

                    localizador = new int[ 200 ];

                #endif

                return;


        }


        // --- DEFINIR

        private void Pegar_dados_imagens_especificas( int[] _imagens_ids ){


                // --- VERIFICA SE AS IMAGENS JA FORAM PEGAS
                for( int index = 0 ; index < _imagens_ids.Length ; index++ ){

                
                        int imagem_id = _imagens_ids[ index ];
                                        
                        #if UNITY_EDITOR
                            Verificar_imagem( imagem_id );
                        #endif

                        // --- VERIFICA SE JA FOI PEGO
                        if( imagens_especificos_ativas[ imagem_id ] == 1 )
                            { continue; }

                        // --- PEGA NOVO VALOR

                        int pointer = localizador[ imagem_id ];
                        int length = ( localizador[ imagem_id ] - pointer );

                        pointers_imagens_especificas[ imagem_id ] = pointer;
                        lengths_imagens_especificas[ imagem_id ] = length;

                        continue;
                }

        }

        private void Pegar_dados_imagem_especifica( int _imagem_id ){


                #if UNITY_EDITOR
                    Verificar_imagem( _imagem_id );
                #endif

                if( imagens_especificos_ativas[ _imagem_id ] == 1 )
                    { return; }

                

                int pointer = localizador[ _imagem_id ];
                int length = ( localizador[ _imagem_id ] - pointer );

                pointers_imagens_especificas[ _imagem_id ] = pointer;
                lengths_imagens_especificas[ _imagem_id ] = length;

                return;

        }



        // retorno os ids_finais
        private int[] Pegar_dados_imagens_tipo_geral( string[][] _chaves_array ){

                
                int[] retorno = new int[ _chaves_array.Length];
            
                for( int chave_index = 0 ; chave_index < _chaves_array.Length ; chave_index++ ){

                        string[] chave = _chaves_array[ chave_index ];
                        string nome = System.IO.Path.Combine( chave );
                        bool encontrou = false;
                        
                        for( int index = 0 ; index < ( pointer_imagens_gerais_atual - 1 ) ; index++  ){

                            if( imagens_gerais_nomes[ index ] == nome )
                                {
                                    retorno[ chave_index ] = index;
                                    encontrou = true;
                                    break;
                                }
                                
                        }

                        // --- VERIFICA SE JA TINHA
                        if ( encontrou )
                            { continue; }


                        if( imagens_gerais_nomes.Length == pointer_imagens_gerais_atual )
                            { Array.Resize( ref imagens_gerais_nomes, ( imagens_gerais_nomes.Length + 5 ) ); }
                            

                        imagens_gerais_nomes[ pointer_imagens_gerais_atual ] = nome;
                        retorno[ chave_index ] = pointer_imagens_gerais_atual;

                        Verificar_imagem_geral( nome );
                        pointer_imagens_gerais_atual++;

                        continue;
                        

                }
                return retorno;

        }



        // retorno os ids_finais
        private int Pegar_dados_imagem_tipo_geral( string[] _chaves ){

                
                string nome = System.IO.Path.Combine( _chaves );
            
                for( int index = 0 ; index < ( pointer_imagens_gerais_atual - 1 ) ; index++  ){

                        if( imagens_gerais_nomes[ index ] == nome )
                            { return index;}
                            
                }

                // --- VAI PEGAR 
                if( imagens_gerais_nomes.Length == pointer_imagens_gerais_atual )
                    { Array.Resize( ref imagens_gerais_nomes, ( imagens_gerais_nomes.Length + 5 ) ); }
                    

                imagens_gerais_nomes[ pointer_imagens_gerais_atual ] = nome;
                
                Verificar_imagem_geral( nome );
                pointer_imagens_gerais_atual++;

                return ( pointer_imagens_gerais_atual - 1 ) ;
                
        }




        public void Definir_material( Shader _shader_material ){

                if( _shader_material == null )
                    { throw new Exception( $"Tentou criar o material no modulo imagem { nome_dispositivo } mas o shader estava null" ); }
                    
                material_dispositivo = new Material( _shader_material );
                return;


        }


        private void Verificar_imagem( int _id ){

            string[] nomes = Enum.GetNames( tipo );

            if( _id >= nomes.Length )
            { throw new Exception( $"tentou colocar a imagem com id { _id } mas tinha { nomes.Length} itens no enum" ); }

            string nome = nomes[ _id ];
            

            string path_imagem = System.IO.Path.Combine( path_folder__imagens_DEVELOPMENT, ( nome + ".png" ) ) ;

            if( !!!( System.IO.File.Exists( path_imagem ) ) )
                { throw new Exception( $"Nao foi achado o arquivo no path { path_imagem }" ); }

            
        }


        private void Verificar_imagem_geral( string _nome ){


            string path_imagem = System.IO.Path.Combine( Paths_sistema.path_folder__imagens_dispositivos_reutilizaveis, ( _nome + ".png" ) ) ;

            if( !!!( System.IO.File.Exists( path_imagem ) ) )
                { throw new Exception( $"Nao foi achado o arquivo no path { path_imagem }" ); }

            
        }




        
        // --- IMAGEM ESTATICA


        public void Definir_imagem_estatica( Dados_imagem_estatica _dados ){

            
                Pegar_dados_imagem_especifica( _dados.imagem_id );

                _dados.tipo_pegar_sprite = Tipo_pegar_sprite.imagem_especifica;
                _dados.imagem_id_final = _dados.imagem_id;

                return;

        }


        // *** MUDAR TIPO
        public void Definir_imagem_estatica_com_imagem_geral( Dados_imagem_estatica _dados ){


                _dados.imagem_id_final = Pegar_dados_imagem_tipo_geral(  _dados.chaves );
                _dados.tipo_pegar_sprite = Tipo_pegar_sprite.imagem_geral;

                return;

        }


        // --- BOTAO

        public void Definir_imagem_botao( Dados_botao _dados ){


            
            // --- IMAGEM OFF

                // ** PARTE ESTATICA

                    _dados.tipo_pegar_sprite_off = Tipo_pegar_sprite.imagem_especifica; 
                    Pegar_dados_imagem_especifica( _dados.sprite_off_id );
                    _dados.sprite_off_id_final = _dados.sprite_off_id;   
                    
                // ** PARTE ANIMADA

                if( _dados.imagens_animacao_ids_imagem_off != null )
                    {   
                        _dados.tem_animacao_imagem_off = true;
                        _dados.tipo_pegar_sprite_off_animacao = Tipo_pegar_sprite.imagem_especifica; 
                        Pegar_dados_imagens_especificas( _dados.imagens_animacao_ids_imagem_off );
                        _dados.imagens_animacao_ids_imagem_off_final = _dados.imagens_animacao_ids_imagem_off;   
                    }

                    
            // --- IMAGEM ON

                // ** PARTE ESTATICA
                    _dados.tipo_pegar_sprite_on = Tipo_pegar_sprite.imagem_especifica;
                    Pegar_dados_imagem_especifica( _dados.sprite_on_id );
                    _dados.sprite_on_id_final = _dados.sprite_on_id;
            
                    
                // ** PARTE ANIMADA
                if( _dados.imagens_animacao_ids_imagem_on != null )
                    {
                        _dados.tem_animacao_imagem_on = true;
                        _dados.tipo_pegar_sprite_on_animacao = Tipo_pegar_sprite.imagem_especifica;  
                        Pegar_dados_imagens_especificas( _dados.imagens_animacao_ids_imagem_on );
                        _dados.imagens_animacao_ids_imagem_on_final = _dados.imagens_animacao_ids_imagem_on;   
                    }

                
            // --- TRANSICAO OFF -> ON

                if( _dados.imagens_animacao_ids_imagem_transicao != null )
                    {
                        _dados.tem_animacao_transicao = true;
                        _dados.tipo_pegar_sprite_transicao_animacao = Tipo_pegar_sprite.imagem_especifica;  
                        Pegar_dados_imagens_especificas( _dados.imagens_animacao_ids_imagem_transicao );
                        _dados.imagens_animacao_ids_imagem_transicao_final = _dados.imagens_animacao_ids_imagem_transicao;   
                        
                    }

                return;

        }


        // *** MUDAR TIPO
        public void Definir_botao_com_imagem_geral( Dados_botao _dados ){

                
            // --- IMAGEM OFF

                // ** PARTE ESTATICA

                    _dados.tipo_pegar_sprite_off = Tipo_pegar_sprite.imagem_geral; 
                    _dados.sprite_off_id_final = Pegar_dados_imagem_tipo_geral( _dados.chaves_imagem_off );
                     

                // ** PARTE ANIMADA
                if( _dados.imagens_animacao_ids_imagem_off != null )
                    {   
                        _dados.tem_animacao_imagem_off = true;
                        _dados.tipo_pegar_sprite_off_animacao = Tipo_pegar_sprite.imagem_geral; 
                        _dados.imagens_animacao_ids_imagem_off_final = Pegar_dados_imagens_tipo_geral( _dados.chaves_imagens_animacao_ids_imagem_off );
                        
                    }

                    
            // --- IMAGEM ON

                // ** PARTE ESTATICA
                    _dados.tipo_pegar_sprite_on = Tipo_pegar_sprite.imagem_geral; 
                    _dados.sprite_on_id_final = Pegar_dados_imagem_tipo_geral( _dados.chaves_imagem_on );
                     

                // ** PARTE ANIMADA
                if( _dados.imagens_animacao_ids_imagem_on != null )
                    {   
                        _dados.tem_animacao_imagem_on = true;
                        _dados.tipo_pegar_sprite_on_animacao = Tipo_pegar_sprite.imagem_geral; 
                        _dados.imagens_animacao_ids_imagem_on_final = Pegar_dados_imagens_tipo_geral( _dados.chaves_imagens_animacao_ids_imagem_on );
                        
                    }

                
            // --- TRANSICAO OFF -> ON

                if( _dados.imagens_animacao_ids_imagem_transicao != null )
                    {
                        _dados.tem_animacao_imagem_on = true;
                        _dados.tipo_pegar_sprite_on_animacao = Tipo_pegar_sprite.imagem_geral; 
                        _dados.imagens_animacao_ids_imagem_transicao_final = Pegar_dados_imagens_tipo_geral( _dados.chaves_imagens_animacao_ids_imagem_on );
                        
                    }

                return;


        }




        // *** MUDAR TIPO
        // **  ver argumentos depois
        
        // public void Definir_imagem_scrollbar( int _parte_id,  int _imagem_id ){}
        // public void Definir_imagem_slider( int _parte_id,  int _imagem_id ){}
        // public void Definir_imagem_toggle( int _parte_id,  int _imagem_id ){}
        // public void Definir_imagem_toggle_grupo( int _parte_id,  int _imagem_id ){}
        // public void Definir_imagem_input_field( int _parte_id,  int _imagem_id ){}
        // public void Definir_imagem_drop_down( int _parte_id,  int _imagem_id ){}




        // --- CARREGAR IMAGEM

        public void Carregar_imagens(){


                // --- INDEXES QUE TEM CADA IMAGEM POR FUNCAO                
                
                int numero_de_imagens = 0;
                // --- PEGAR NUMERO DE IMAGENS 

                for( int objeto_index = 0 ; objeto_index < imagens_especificos_ativas.Length ; objeto_index++ ){

                        // --- VERIFICA SE TEM 
                        if( imagens_especificos_ativas[ objeto_index ] == 1 )
                            { numero_de_imagens++; }
                        continue;
                }


                // --- CRIA SLOTS
                int[] imagens_ids = new int[ numero_de_imagens ];
                int[] pointers = new int[ numero_de_imagens ];
                int[] lengths = new int[ numero_de_imagens ];


                int index_para_colocar = 0;
                
                for( int id_index = 0; id_index < imagens_especificos_ativas.Length ; id_index++ ){

                        if( imagens_especificos_ativas[ id_index ] == 0 )
                            { continue; }
                        
                        imagens_ids[ index_para_colocar ] = id_index;
                        pointers[ index_para_colocar ] = pointers_imagens_especificas[ id_index ];
                        lengths[ index_para_colocar ] = lengths_imagens_especificas[ id_index ];

                        index_para_colocar++;
                        continue;

            
                }

                string[] nomes = Enum.GetNames( tipo );

                sprites_especificas = new Sprite[ nomes.Length ];


                // --- EDITOR
                #if UNITY_EDITOR
                
    
                        // --- CARREGA IMAGENS

                        for( int imagem_slot = 0 ; imagem_slot < imagens_ids.Length ; imagem_slot++ ){

                                
                                // --- PEGA NOME ESPECIFICO
                                int imagem_id = imagens_ids[ imagem_slot ];
                                if( imagem_id >= nomes.Length )
                                    { throw new Exception( $"Veio um imagem_id de valor { imagem_id } mas o enum tinha { nomes.Length } itens" ); }

                                string nome_imagem_enum =  nomes[ imagem_id ];

                                // --- PEGA PATH ARQUIVO
                                string path_imagem = System.IO.Path.Combine( path_folder__imagens_DEVELOPMENT, nome_imagem_enum );
                                path_imagem = System.IO.Path.ChangeExtension( path_imagem, ".png" );

                                
                                // --- VERIFICA SE ARQUIVO EXISTE
                                if( !!!( System.IO.File.Exists( path_imagem ) ) )
                                    { throw new Exception( $"Nao foi achado o arquivo com o nome <color=red><b>{ nome_imagem_enum }</b></color>pedido no gerenciador { nome_dispositivo } e no path: { path_imagem }" ); }

                                // --- CRIA ASPRITE
                                byte[] png = System.IO.File.ReadAllBytes( path_imagem );
                                sprites_especificas[ imagem_id ] = SPRITE.Transformar_png_TO_sprite( png );

                                continue;

                        }


                
                // ---- BUILD
                #else


                        byte[][] pngs = desmembrador_de_arquivo.Pegar_multiplos_dados( imagens_ids, pointers, lengths );
                        
                        for( int index_novas_sprites_index = 0; index_novas_sprites_index < imagens_ids.Length  ; index_novas_sprites_index++ ){

                                int imagem_id = imagens_ids.Length;
                                sprites_especificas[ imagem_id ] = SPRITE.Transformar_png_TO_sprite( pngs[ index_novas_sprites_index ] );
                                continue;

                        }

                    
                #endif



                // --- CARREGAR IMAGENS GERAIS

                string path_folder__imagens_dispositivos_reutilizaveis = Paths_sistema.path_folder__imagens_dispositivos_reutilizaveis;

                for( int imagem_geral_index = 0 ; imagem_geral_index < imagens_gerais_paths.Length ; imagem_geral_index++ ){


                        // --- PEGA NOME ESPECIFICO
                        string path_arquivo_interno = imagens_gerais_paths[ imagem_geral_index ];

                        // --- VERIFICA SE AINDA TEm
                        if( path_arquivo_interno == null )
                            { break; }

                        
                        string path_arquivo = System.IO.Path.Combine( path_folder__imagens_dispositivos_reutilizaveis, path_arquivo_interno );
                        path_arquivo = System.IO.Path.ChangeExtension( path_arquivo, "png" );


                        #if UNITY_EDITOR

                            if( !!!( System.IO.File.Exists( path_arquivo ) ) )
                                { throw new System.Exception( $"Tentou pegar imagem especifica de um dispositivo no path  { path_arquivo } mas não foi encontrado"); }

                        #endif


                        // --- CRIA ASPRITE
                        byte[] png = System.IO.File.ReadAllBytes( path_arquivo );
                        sprites_geral[ imagem_geral_index ] = SPRITE.Transformar_png_TO_sprite( png );

                        continue;

                }

        }


        public void Criar_sprites(){ 

            // ** fazer depois
            // quando criar => quando for chamar Colocar_imanges() vai ter que verificar se as sprites foram criadas

        }




        public void Colocar_imagens_tipo_imagem_estatica( Dados_imagem_estatica[] _dados_imagens, string _dispositivo_game_object_path ){




                for( int imagem_index = 0 ; imagem_index < _dados_imagens.Length ; imagem_index++ ){

                        Dados_imagem_estatica dados = _dados_imagens[ imagem_index ];
                        string nome = dados.nome;

                        string path_objeto = _dispositivo_game_object_path + "/" + nome;

                        GameObject game_object = GameObject.Find( path_objeto );

                        if( game_object == null )
                            { throw new Exception( $"Tentou pegar o gameObject da imagem estatica <color=lightBlue><b>{ nome }</b></color> mas nao foi encontrado no prefab." ); }



                        Image image = game_object.GetComponent<Image>();

                        if( image== null )
                            { throw  new Exception( $"Nao foi colocado o componente Image na imagem do { nome } " ); }

                        image.material = material_dispositivo;
                        

                        Tipo_pegar_sprite tipo_pegar_sprite = dados.tipo_pegar_sprite;
                        int imagem_id = dados.imagem_id_final;

                        if( tipo_pegar_sprite == Tipo_pegar_sprite.imagem_especifica )
                            {

                                image.sprite = sprites_especificas[ imagem_id ];
                                image.color = Color.white;
                                return;
                            }

                        if( tipo_pegar_sprite == Tipo_pegar_sprite.imagem_geral )
                            {

                                image.sprite = sprites_geral[ imagem_id ];
                                image.color = Color.white;
                                return;
                            }
                        if( tipo_pegar_sprite == Tipo_pegar_sprite.nada )
                            {

                                image.sprite = null;
                                image.color = Color.clear;
                                return;
                            }


                }

                

        }



        public void Colocar_imagens_tipo_botao( Dados_botao[] _dados_botoes, string _dispositivo_game_object_path ){



                if( sprites_especificas == null )
                    { throw new Exception( "Nao foi dado o Carregar_imagens no modulo imagens dispositivos" ); }


                // if( _dispositivo_game_object == null )
                //     { throw new Exception( $"Tentou pegar o gameObject <color=lightBlue><b>{ _nome }</b></color> mas nao foi encontrado no prefab" ); }

                for( int botao_index = 0 ; botao_index < _dados_botoes.Length ; botao_index++ ){

                        Dados_botao dados = _dados_botoes[ botao_index ];

                        if( dados == null )
                            { continue; }


                        string nome = dados.nome;
                        string path_objeto = _dispositivo_game_object_path + "/" + nome;

                        GameObject game_object = GameObject.Find( path_objeto );

                        if( game_object == null )
                            { throw  new Exception( $"Nao foi achado a imagem { nome }" ); }


                        Image image = game_object.GetComponent<Image>();

                        if( image== null )
                            { throw  new Exception( $"Nao foi colocado o componente Image na imagem do { nome } " ); }

                        image.material = material_dispositivo;
                        

                        Tipo_pegar_sprite tipo_pegar_sprite = dados.tipo_pegar_sprite;
                        int imagem_id = dados.imagem_id_final;



                }


        }

        private void Colocar_imagem_tipo_scrollbar( int _id, string _path_game_object ){}
        private void Colocar_imagem_tipo_drop_down( int _id, string _path_game_object ){}
        private void Colocar_imagem_tipo_input_field( int _id, string _path_game_object ){}
        private void Colocar_imagem_tipo_slider( int _id, string _path_game_object ){}
        private void Colocar_imagem_tipo_toggle( int _id, string _path_game_object ){}
        private void Colocar_imagem_tipo_toggle_grupo( int _id, string _path_game_object ){}
    



}





