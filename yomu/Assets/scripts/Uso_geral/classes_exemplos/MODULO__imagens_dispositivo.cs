using UnityEngine;
using UnityEngine.UI;
using System;


public class MODULO__imagens_dispositivo {


        
        // Definir imagens para carregar => classe especifica
        // carregar => modulo
        // colocar imagens => modulo 
        // alterar imagens => classe especifica => modulo



        public enum Tipo_pegar_sprite {

            nada, 
            imagem_especifica, 
            imagem_geral

        }

        // --- MODULOS
        public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;


        // --- DADOS

        public Sprite[][][] sprites_partes_por_funcao;

        public Tipo_pegar_sprite[][][] tipos_pegar_sprite_por_funcao;
        public int[][][] ids_imagens_tipos_especificos_por_funcao;
        public int[][][] pointers_iniciais_por_funcao;
        public int[][][] lengths_por_funcao;
        
        public string[][][][] chaves_imagens_gerais_por_funcao;

        public int[] localizador;
        public string nome_gerenciador;

        public int numero_maximo_de_tipos;


        public string[] paths_imagens_DEVELOPMENT;

        public System.Type tipo;



        public MODULO__imagens_dispositivo(  string _nome_gerenciador, string _path_arquivo ){


                int numero_de_tipos = ( System.Enum.GetValues( typeof( Parte_dispositivo_tipo ) )).Length;

                numero_maximo_de_tipos = numero_de_tipos;
                
                nome_gerenciador = _nome_gerenciador;

                // ** [ tipo ][ id ][ sprites ]
                sprites_partes_por_funcao = new Sprite[ numero_de_tipos ][][];
                tipos_pegar_sprite_por_funcao = new Tipo_pegar_sprite[ numero_de_tipos ][][];
                chaves_imagens_gerais_por_funcao = new string[ numero_de_tipos ][][][];
                pointers_iniciais_por_funcao = new int[ numero_de_tipos ][][];
                lengths_por_funcao = new int[ numero_de_tipos ][][];

                for( int index = 0 ; index < numero_de_tipos ; index++ ){

                        sprites_partes_por_funcao[ index] = new Sprite[ 5 ][];
                        tipos_pegar_sprite_por_funcao[ index ] = new Tipo_pegar_sprite[ 5 ][];
                        chaves_imagens_gerais_por_funcao[ index ] = new string[ 5 ][][];
                        pointers_iniciais_por_funcao[ index ] = new int[ 5 ][];
                        lengths_por_funcao[ index ] = new int[ 5 ][];

                        continue;

                }


                #if !UNITY_EDITOR


                        desmembrador_de_arquivo  =  new MODULO__desmembrador_de_arquivo ( 
                                                                                            _gerenciador_nome : _nome_gerenciador,
                                                                                            _path_arquivo: _path_arquivo,
                                                                                            _numero_inicial_de_slots: 15
                                                                                        );

                        byte[] localizador_bytes = desmembrador_de_arquivo.Pegar_dados( _localizador_id: -1, _ponto_inicial: 0, _length: 1_000 );
                        localizador = BYTE.Converter_para_int_array( localizador_bytes );


                #endif


                return;


        }

        


        // --- DEFINIR


        // *** MUDAR TIPO
        public void Definir_imagem_estatica( int _parte_id,  int _imagem_id ){


                Tipo_pegar_sprite[][] tipos = tipos_pegar_sprite_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica ];
                int[][] ids_tipos_especificos = ids_imagens_tipos_especificos_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica ];
                int[][] pointers_iniciais = pointers_iniciais_por_funcao[( int ) Parte_dispositivo_tipo.imagem_estatica ]; 
                int[][] lengths = lengths_por_funcao[( int ) Parte_dispositivo_tipo.imagem_estatica ]; 
            

                if( tipos_pegar_sprite_por_funcao.Length < _parte_id )
                    { 
                        throw new System.Exception( "tem que ver se vai funcionar" );
                        System.Array.Resize( ref ids_tipos_especificos, ( _parte_id - tipos_pegar_sprite_por_funcao.Length + 1 ) );
                        System.Array.Resize( ref tipos, ( _parte_id - tipos_pegar_sprite_por_funcao.Length + 1 ) );
                        System.Array.Resize( ref pointers_iniciais, ( _parte_id - tipos_pegar_sprite_por_funcao.Length + 1 ) );
                        System.Array.Resize( ref lengths, ( _parte_id - tipos_pegar_sprite_por_funcao.Length + 1 ) );

                        Debug.Log( "tipos_pegar_sprite_por_funcao " + tipos_pegar_sprite_por_funcao.Length );
                        Debug.Log( "tipos_pegar_sprite_por_funcao superior " + tipos_pegar_sprite_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica ].Length );

                    }

                // --- PEGAR POINTER

                tipos[ _parte_id ] = new Tipo_pegar_sprite[ 1 ] { Tipo_pegar_sprite.imagem_especifica };
                ids_tipos_especificos[ _parte_id ] =  new int[ 1 ]{ _imagem_id };


                int pointer = localizador[ _imagem_id ];
                int length = ( localizador[ _imagem_id ] - pointer );

                pointers_iniciais[ _parte_id ] = new int[]{ pointer };
                lengths[ _parte_id ] = new int[]{ length }; 

                return;


        }



        // *** MUDAR TIPO
        public void Definir_imagem_estatica_com_imagem_geral( int _parte_id, string[] _chaves ){


                Tipo_pegar_sprite[] tipos = tipos_pegar_sprite_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica ][ _parte_id ];
                string[][] chaves_imagens_gerais = chaves_imagens_gerais_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica ][ _parte_id ]; 
                

                if( tipos_pegar_sprite_por_funcao.Length < _parte_id )
                    { 
                        throw new System.Exception( "tem que ver se vai funcionar" );
                        System.Array.Resize( ref tipos, ( _parte_id - tipos_pegar_sprite_por_funcao.Length + 1 ) );
                        System.Array.Resize( ref chaves_imagens_gerais, ( _parte_id - tipos_pegar_sprite_por_funcao.Length + 1 ) );

                        Debug.Log( "tipos_pegar_sprite_por_funcao " + tipos_pegar_sprite_por_funcao.Length );
                        Debug.Log( "tipos_pegar_sprite_por_funcao superior " + tipos_pegar_sprite_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica ].Length );

                    }


                tipos[ _parte_id ] = Tipo_pegar_sprite.imagem_geral;

                chaves_imagens_gerais[ _parte_id ] = _chaves;
                return;


        }




        // *** MUDAR TIPO
        // **  ver argumentos depois
        public void Definir_imagem_botao( int _parte_id,  int _imagem_id ){}
        public void Definir_imagem_scrollbar( int _parte_id,  int _imagem_id ){}
        public void Definir_imagem_slider( int _parte_id,  int _imagem_id ){}
        public void Definir_imagem_toggle( int _parte_id,  int _imagem_id ){}
        public void Definir_imagem_toggle_grupo( int _parte_id,  int _imagem_id ){}
        public void Definir_imagem_input_field( int _parte_id,  int _imagem_id ){}
        public void Definir_imagem_drop_down( int _parte_id,  int _imagem_id ){}




        // --- CARREGAR IMAGEM


        private Dados_para_carregar_imagens Criar_dados_default(){

                Dados_para_carregar_imagens dados = new Dados_para_carregar_imagens();


                // --- INDEXES QUE TEM CADA IMAGEM POR FUNCAO                
                int numero_maximo_de_imagens = Pegar_numero_maximo_de_tipos();

                // --- CRIA SLOTS
                dados.imagens_ids = new int[ numero_maximo_de_imagens ];
                dados.pointers = new int[ numero_maximo_de_imagens ];
                dados.lengths = new int[ numero_maximo_de_imagens ];

                dados.localizadores_proprias = new int[ numero_maximo_de_tipos ][][];

                return dados;

        }

        private class Dados_para_carregar_imagens {


                // --- PROPRIAS
                public int[] imagens_ids;
                public int[] pointers;
                public int[] lengths;

                // ** o localizador é diferente dos ids, porque aqui nao vai falar qual imagem que é mas qual slot esse id esta no array que vai voltar com os pngs
                public int[][][] localizadores_proprias;

                // --- GERAIS
                public string[][][] paths;

        }




        private int Pegar_numero_maximo_de_tipos(){

                int total_imagens = 0;
                // --- PEGAR NUMERO DE IMAGENS 
                for( int tipo_funcao_index = 0 ; tipo_funcao_index < tipos_pegar_sprite_por_funcao.Length ; tipo_funcao_index++ ){


                        for( int index_para_pegar_numero = 0 ; index_para_pegar_numero < tipos_pegar_sprite_por_funcao[ tipo_funcao_index ].Length ; index_para_pegar_numero++ ){

                                // --- VERIFICA SE TEM
                                if( tipos_pegar_sprite_por_funcao[ tipo_funcao_index ][ index_para_pegar_numero ] == null )
                                    { continue; }

                                for( int i = 0 ; i < tipos_pegar_sprite_por_funcao[ tipo_funcao_index ][ index_para_pegar_numero ].Length ; i++ ){

                                        if( tipos_pegar_sprite_por_funcao[ tipo_funcao_index ][ index_para_pegar_numero ][ i ] != Tipo_pegar_sprite.imagem_especifica )
                                            { continue; }
                                        total_imagens++;

                                        continue;
                                }

                                continue;
                        }

                        continue;
                }

                return total_imagens;

        }



        private Dados_para_carregar_imagens Filtrar_imagens(){


                Dados_para_carregar_imagens dados_retorno = Criar_dados_default();

                int index_para_colocar = 0;
                for( int tipo_funcao_index = 0 ; tipo_funcao_index < tipos_pegar_sprite_por_funcao.Length ; tipo_funcao_index++ ){

                        // --- CADA TIPO
                        Tipo_pegar_sprite[][] tipos_para_pegar_imagem_objeto = tipos_pegar_sprite_por_funcao[ tipo_funcao_index ];
                        dados_retorno.localizadores_proprias[ tipo_funcao_index ] = new int[ tipos_para_pegar_imagem_objeto.Length ][];
                        dados_retorno.paths[ tipo_funcao_index ] = new string[ tipos_para_pegar_imagem_objeto.Length ][];
                        
                        for( int index_objeto_para_verificar = 0; index_objeto_para_verificar < tipos_para_pegar_imagem_objeto.Length ; index_objeto_para_verificar++ ){

                                // --- CADA OBJETO
                                // --- VERIFICA SE ESTA VAZIO
                                if( tipos_para_pegar_imagem_objeto[ index_objeto_para_verificar ] == null )
                                    { continue; } // --- NAO EXISTE
                                
                                Tipo_pegar_sprite[] tipos = tipos_para_pegar_imagem_objeto[ index_objeto_para_verificar ];
                                int[] imagens_ids_objeto = ids_imagens_tipos_especificos_por_funcao[ tipo_funcao_index ][ index_objeto_para_verificar ];
                                    
                                dados_retorno.localizadores_proprias[ tipo_funcao_index ][ index_objeto_para_verificar ]  = new int[ ( tipos.Length ) ];// --- CRIA A QUANTIDADE DE IMAGENS POSSIVIES
                                dados_retorno.paths[ tipo_funcao_index ][ index_objeto_para_verificar ] = new string[ tipos.Length ];

                                for( int objeto_parte_index = 0 ; objeto_parte_index < tipos.Length ; objeto_parte_index++ ){

                                        switch( tipos[ objeto_parte_index ] ){
                                            
                                                case Tipo_pegar_sprite.imagem_especifica : Acrescentar_imagem_no_objeto_ESPECFICO(  tipo_funcao_index,  index_objeto_para_verificar, objeto_parte_index, ref index_para_colocar, imagens_ids_objeto,  dados_retorno  ); break;
                                                case Tipo_pegar_sprite.imagem_geral : Acrescentar_imagem_no_objeto_GERAL( tipo_funcao_index,  index_objeto_para_verificar, objeto_parte_index, dados_retorno  ); break;
                                                case Tipo_pegar_sprite.nada : break;
                                        }

                                }

                                continue;

                        }

                }

                // --- TIRAR EXTRA

                dados_retorno.imagens_ids = INT.Remover_valor( dados_retorno.imagens_ids, 0 );
                dados_retorno.pointers = INT.Remover_valor( dados_retorno.pointers, 0 );
                dados_retorno.lengths = INT.Remover_valor( dados_retorno.lengths, 0 );

                return dados_retorno;


        }



        private void Acrescentar_imagem_no_objeto_ESPECFICO( int _funcao_id, int _index_objeto_para_verificar, int _objeto_parte_index, ref int _index_para_colocar_REF , int[] _imagens_ids_objeto, Dados_para_carregar_imagens _dados_retorno  ){


                int imagem = _imagens_ids_objeto [ _objeto_parte_index ];

                if( imagem < 1 )
                    { throw new System.Exception( $"Tentou pegar uma imagem no gerenciador { nome_gerenciador } mas a iamgem estava com id invalido. id: { imagem  }" ); }


                int slot = INT.Pegar_index_valor( _imagens_ids_objeto, imagem );

                if( slot != -1 )
                    {
                        _dados_retorno.localizadores_proprias[ _funcao_id ][ _index_objeto_para_verificar ][ _objeto_parte_index ] = slot; // --- O INDEX COM O VALOR ANTERIOR
                        return;
                    }

                
                // --- ACRESCENTA NOVA IMAGEM
                _dados_retorno.imagens_ids[ _index_para_colocar_REF ] = imagem;
                _dados_retorno.pointers[ _index_para_colocar_REF ] = pointers_iniciais_por_funcao[ _funcao_id ][ _index_objeto_para_verificar ][ _objeto_parte_index ];
                _dados_retorno.lengths[ _index_para_colocar_REF ] = lengths_por_funcao[ _funcao_id ][ _index_objeto_para_verificar ][ _objeto_parte_index ];

                // --- coloca qual index do localizador tem o id da imagem
                _dados_retorno.localizadores_proprias[ _funcao_id ][ _index_objeto_para_verificar ][ _objeto_parte_index ] = _index_para_colocar_REF;

                _index_para_colocar_REF++;

                return;

        }



        private void Acrescentar_imagem_no_objeto_GERAL( int _funcao_id, int _index_objeto_para_verificar, int _objeto_parte_index, Dados_para_carregar_imagens _dados  ){


                string[] chaves = chaves_imagens_gerais_por_funcao[ _funcao_id ][ _index_objeto_para_verificar ][ _objeto_parte_index ]; 

                string path_folder__imagens_gerais = Paths_sistema.path_folder__imagens_gerais;

                string path_folder_principal = System.IO.Path.Combine( path_folder__imagens_gerais, chaves[ 0 ] );
                string path_arquivo = System.IO.Path.Combine( path_folder_principal, chaves[ 0 ] );
                System.IO.Path.ChangeExtension( path_arquivo, ".png" );

                #if UNITY_EDITOR

                    if( !!!( System.IO.Directory.Exists( path_folder_principal ) ) )
                        { throw new System.Exception($"Tentou pegar imagem especifica de um dispositivo no path do folder { path_folder_principal } mas não foi encontrado"); }

                    if( !!!( System.IO.File.Exists( path_arquivo ) ) )
                        { throw new System.Exception($"Tentou pegar imagem especifica de um dispositivo no path  { path_arquivo } mas não foi encontrado"); }

                #endif

                _dados.paths[ _funcao_id ][ _index_objeto_para_verificar ][ _objeto_parte_index ] = path_arquivo;
                return;


        }




        private int[] Criar_int_array_tudo_menos_1( int _length ){

                int[] retorno = new int[ _length ];

                for( int index = 0 ; index < _length ; index++){ 

                    retorno[ index ] = -1; 
                    continue;
                }
                    
                return retorno;

        }



        public void Carregar_imagens(){



                // --- CARREGAR ESPECIFICAS


                Dados_para_carregar_imagens dados = Filtrar_imagens();


                int[] imagens_ids = dados.imagens_ids;
                int[] pointers = dados.pointers;
                int[] lengths = dados.lengths;
                string[][][] paths = dados.paths;

                int[][][] index_localizador_por_funcao = dados.localizadores_proprias; 


                // --- CRIAR SPRITES

                Sprite[] sprites = null;



                // --- EDITOR
                #if UNITY_EDITOR

                        sprites = new Sprite[ imagens_ids.Length ];
                    
                        string[] nomes = Enum.GetNames( tipo );

                        string folder_nome_completo = tipo.Name;

                        // DISPOSITIVO__USO_PLAYER__CONECTOR__EXEMPLO__imagem

                        string[] folder_partes = folder_nome_completo.Split( "__" );
                        folder_partes[ ( folder_partes.Length - 1 ) ] = "";

                        string path_folder = System.IO.Path.Combine( folder_partes );

                        if( !!!( System.IO.Directory.Exists( path_folder ) ) )
                            { throw new Exception( $"Nao foi achado o folder do path { path_folder } pedido no { nome_gerenciador }" ); }


                        for( int imagem_index_dev = 0 ; imagem_index_dev < imagens_ids.Length ; imagem_index_dev++ ){

                                // --- PEGA NOME ESPECIFICO
                                int imagem_id = imagens_ids[ imagem_index_dev ];
                                string nome_imagem_enum =    nomes[ imagem_id ];

                                // --- PEGA PATH ARQUIVO
                                string path_imagem = System.IO.Path.Combine( path_folder, nome_imagem_enum );
                                path_imagem = System.IO.Path.ChangeExtension( path_imagem, ".png" );

                                // --- VERIFICA SE ARQUIVO EXISTE
                                if( !!!( System.IO.File.Exists( path_imagem ) ) )
                                    { throw new Exception( $"Nao foi achado o arquivo no path { path_imagem } pedido no { nome_gerenciador }" ); }

                                // --- CRIA ASPRITE
                                byte[] png = System.IO.File.ReadAllBytes( path_imagem );
                                sprites[ imagem_index_dev ] = SPRITE.Transformar_png_TO_sprite( png );

                                
                                continue;
                            

                        }

                
                // ---- BUILD
                #else


                        byte[][] pngs = desmembrador_de_arquivo.Pegar_multiplos_dados( imagens_ids, pointers, lengths );
                        sprites = new Sprite[ pngs.Length ];


                        for( int index_novas_sprites_index = 0; index_novas_sprites_index < sprites.Length  ; index_novas_sprites_index++ ){

                                sprites[ index_novas_sprites_index ] = SPRITE.Transformar_png_TO_sprite( pngs[ index_novas_sprites_index ] );
                                continue;

                        }

                        

                #endif




                // --- CARREGAR COLOCA IMAGENS NOS SLOTS CORRETOS
                byte[][] pngs_gerais = desmembrador_de_arquivo.Pegar_multiplos_dados( imagens_ids, pointers, lengths );


                for( int index_tipo_especifico = 0 ; index_tipo_especifico < sprites.Length ; index_tipo_especifico++){

                        Tipo_pegar_sprite[][] tipos_pegar_imagens_objetos = tipos_pegar_sprite_por_funcao[ index_tipo_especifico ];

                        for( int objeto_index = 0 ; objeto_index < tipos_pegar_imagens_objetos.Length ; objeto_index++ ){

                                Tipo_pegar_sprite[] tipos_pegar_imagens_partes = tipos_pegar_imagens_objetos[ objeto_index ];

                                for( int objeto_parte_index = 0 ; objeto_parte_index < tipos_pegar_imagens_partes.Length ; objeto_parte_index++ ){

                                        // --- COLOCA IMAGEM ESPECIFICA                                        
                                        if(  tipos_pegar_imagens_partes[ objeto_parte_index ] == Tipo_pegar_sprite.imagem_especifica )
                                            {
                                                int slot = index_localizador_por_funcao[ index_tipo_especifico ][ objeto_index ][ objeto_parte_index ];
                                                sprites_partes_por_funcao[ index_tipo_especifico ][ objeto_index ][ objeto_parte_index ] = sprites[ slot ];
                                                continue;

                                            }

                                        // --- COLOCA IMAGEM GERAL
                                        if( tipos_pegar_imagens_partes[ objeto_parte_index ] == Tipo_pegar_sprite.imagem_geral )
                                            {
                                                string path_arquivo = paths[ index_tipo_especifico ][ objeto_index ][ objeto_parte_index ];

                                                byte[] png = Controlador_imagens_gerais.Pegar_png( path_arquivo );
                                                sprites_partes_por_funcao[ index_tipo_especifico ][ objeto_index ][ objeto_parte_index ] = SPRITE.Transformar_png_TO_sprite( png );
                                                continue;

                                            }
                                            
                                        continue;

                                }


                        }

                    
                }

                

                #if UNITY_EDITOR

                        // string path_folder = Paths_sistema.path_folder_imagens_DEVELOPMENT;

                        // string[] paths = Parser_enum_localizador( typeof(  ), path_folder );

                #endif



        }


        

        
        public void Colocar_imagens( MODULO__dados_dispositivo _dados  ){


                // --- ESTATICAS


                GameObject[] game_objects = _dados.game_objects_imagens_estaticas;
                Tipo_pegar_sprite[][] tipos_pegar_sprite_imagem_estatica = tipos_pegar_sprite_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica ];
                Sprite[][] sprites_imagem_estatica = sprites_partes_por_funcao[ ( int ) Parte_dispositivo_tipo.imagem_estatica  ];

                for( int objeto_index_estatico = 0 ; objeto_index_estatico < game_objects.Length ; objeto_index_estatico++ ){


                        GameObject game_object = game_objects[ objeto_index_estatico ];
                        Image image = game_object.GetComponent<Image>();

                        Tipo_pegar_sprite tipo = tipos_pegar_sprite_imagem_estatica[ objeto_index_estatico ][ 0 ];
                        Sprite sprite = sprites_imagem_estatica[ objeto_index_estatico ][ 0 ];

                        
                        if( tipo == Tipo_pegar_sprite.nada )
                            {
                                // --- NADA
                                image.sprite = null;
                                image.color = Color.clear;
                                continue;
                            }

                        if( sprite == null)
                            { throw new Exception( $"precisada da imagem { objeto_index_estatico } mas no slot estava null;" ); }
                        
                        

                        image.sprite = sprite;
                        image.color = Color.white;

                        continue;

                }





                // --- BOTOES

                    Button[] botoes = _dados.botoes;

                    for( int botao_index = 0 ; botao_index < botoes.Length ; botao_index++ ){



                    }


                // --- SLIDERS

                    Slider[] sliders = _dados.sliders;
                    for( int slider_index = 0 ; slider_index < sliders.Length ; slider_index++ ){

                        

                    }


                // --- SCROLLBAR

                    Scrollbar[] scrollbars = _dados.scrollbars;
                    for( int scrollbar_index = 0 ; scrollbar_index < scrollbars.Length ; scrollbar_index++ ){

                        

                    }


                // --- DROP_DOWN

                    Dropdown[] drop_downs = _dados.drop_downs;
                    for( int drop_down_index = 0 ; drop_down_index < drop_downs.Length ; drop_down_index++ ){

                        

                    }


                // --- TOGGLES

                    Toggle[] toggles = _dados.toggles;
                    for( int toggle_index = 0 ; toggle_index < toggles.Length ; toggle_index++ ){

                        

                    }

                // --- TOGGLE_GROUPS

                    ToggleGroup[] toggle_groups =_dados.toggle_groups;
                    for( int toggle_index = 0 ; toggle_index < toggles.Length ; toggle_index++ ){

                        

                    }

                // --- INPUT_FIELDS

                    InputField[] input_fields = _dados.input_fields;
                    for( int input_field_index = 0 ; input_field_index < input_fields.Length ; input_field_index++ ){

                        

                    }

                

                




        }



}





