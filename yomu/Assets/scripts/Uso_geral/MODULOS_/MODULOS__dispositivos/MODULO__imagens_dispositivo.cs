// using UnityEngine;
// using UnityEngine.UI;
// using System;


// public class MODULO__imagens_dispositivo {


//         // Definir imagens para carregar => classe especifica
//         // carregar => modulo
//         // colocar imagens => modulo 
//         // alterar imagens => classe especifica => modulo


//         public enum Tipo_pegar_sprite {

//             nada, 
//             imagem_especifica, 
//             imagem_geral

//         }

//         // --- MODULOS
//         public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;

//         public Material material_dispositivo;
        

//         // --- DADOS
//         public Sprite[] sprites_especificas;
//         public Sprite[] sprites_geral;

//         // ** nome
//         int id_atual = 0;
//         public string[] nomes;

//         public Objeto_dispositivo_tipo[] objetos_tipos;
//         public Tipo_pegar_sprite[] tipos_pegar_sprite;

//         // ** especifico 
//         public int[][] ids_imagens_tipo_especifico;
//         public int[][] pointers_iniciais_por_funcao;
//         public int[][] lengths_por_funcao;


//         // *** geral
//         public int[][] ids_imagens_tipo_geral;
//         public int pointer_imagens_gerais_atual = 0;
//         public string[] imagens_gerais_paths;


//         public int[] localizador;
//         public string nome_dispositivo;

        
//         public System.Type tipo;
//         public string[] folders;


//         public string path_folder__imagens_DEVELOPMENT;


//         public static string Pegar_path_imagens_DEVELOPMENT( string[] folders, string _nome_dispositivo ){

//                 // --- PATH ATE O FOLDER RAIZ 
//                 string path_folder__imagens_dispositivos = Paths_sistema.path_folder__imagens_dispositivos;

//                 // --- NOME DO FOLDER COM OS FOLDERS DA CATEGORIA
//                 string path_folder__interno_DEVELOPMENT = System.IO.Path.Combine( folders );
//                 path_folder__interno_DEVELOPMENT=  System.IO.Path.Combine( path_folder__interno_DEVELOPMENT, _nome_dispositivo );

//                 string path_folder__imagens_DEVELOPMENT = System.IO.Path.Combine( path_folder__imagens_dispositivos, path_folder__interno_DEVELOPMENT );

//                 if( !!!( System.IO.Directory.Exists( path_folder__imagens_DEVELOPMENT ) ) )
//                     { 
//                         Console.LogError( $"Nao foi achado a pasta com as imagens do dispositivo { _nome_dispositivo } que vão ser pegas no editor" );
//                         Console.LogError( $"folder: <Color=lime><b>{ path_folder__imagens_dispositivos }</b></Color>" );
//                         Console.LogError( $"Sub folder: <Color=lime><b>{ path_folder__interno_DEVELOPMENT }</b></Color>" );
//                         throw new Exception( $"Nao foi achado o folder do path { path_folder__imagens_DEVELOPMENT } pedido no { _nome_dispositivo }" ); 
//                     }




//                 // --- PATH PARA O FOLDER COM AS IMAGENS
//                 return path_folder__imagens_DEVELOPMENT;


//         }
        


//         public MODULO__imagens_dispositivo (  string _nome_dispositivo, string[] _folders, System.Type _tipo_imagens ){ 


//                 folders = _folders;
//                 nome_dispositivo = _nome_dispositivo;
//                 material_dispositivo = new Material( Shaders.normal );
//                 tipo = _tipo_imagens;
                

//                 int slots_iniciais = 5;

                
//                 nomes = new string[ slots_iniciais ];

//                 // sprites_especificas = new Sprite[ slots_iniciais ];
//                 // sprites_geral = new Sprite[ slots_iniciais ];



//                 objetos_tipos = new Objeto_dispositivo_tipo[ slots_iniciais ];
//                 tipos_pegar_sprite = new Tipo_pegar_sprite[ slots_iniciais ];

//                 ids_imagens_tipo_especifico = new int[ slots_iniciais ][];

//                 ids_imagens_tipo_geral = new int[ slots_iniciais ][];
//                 imagens_gerais_paths = new string[ slots_iniciais ];
//                 pointers_iniciais_por_funcao = new int[ slots_iniciais ][];
//                 lengths_por_funcao = new int[ slots_iniciais ][];




//                 #if !UNITY_EDITOR


//                         // ** so usado na build
//                         string nome_arquivo = string.Concat( _folders, "__" );
//                         nome_arquivo = System.IO.Path.ChangeExtension( nome_arquivo, ".png" );
//                         string path_arquivo = System.IO.Path.Combine( Paths_sistema.path_folder__imagens_dispositivos, nome_arquivo );

//                         desmembrador_de_arquivo  =  new MODULO__desmembrador_de_arquivo ( 
//                                                                                             _gerenciador_nome : _nome_dispositivo,
//                                                                                             _path_arquivo: path_arquivo,
//                                                                                             _numero_inicial_de_slots: 15
//                                                                                         );

//                         byte[] localizador_bytes = desmembrador_de_arquivo.Pegar_dados( _localizador_id: -1, _ponto_inicial: 0, _length: 1_000 );
//                         localizador = BYTE.Converter_para_int_array( localizador_bytes );

//                 #else 


//                 // --- PATH PARA O FOLDER COM AS IMAGENS
//                 path_folder__imagens_DEVELOPMENT = MODULO__imagens_dispositivo.Pegar_path_imagens_DEVELOPMENT( _folders, _nome_dispositivo );




//                 localizador = new int[ 200 ];


//                 #endif

//                 return;


//         }




//         // --- DEFINIR

//         private int Adicionar_objeto( string _nome ){


//             // --- VERIFICA SE TEM QUE AUMENTAR

//             if( tipos_pegar_sprite.Length == id_atual )
//                 {
//                     // --- TEM QUE AUMENTAR
//                     Array.Resize( ref nomes,( nomes.Length + 5 ) );
//                     Array.Resize( ref objetos_tipos,( objetos_tipos.Length + 5 ) );
//                     Array.Resize( ref tipos_pegar_sprite,( tipos_pegar_sprite.Length + 5 ) );

//                     // ** especifico
//                     Array.Resize( ref ids_imagens_tipo_especifico,( ids_imagens_tipo_especifico.Length + 5 ) );
//                     Array.Resize( ref pointers_iniciais_por_funcao,( pointers_iniciais_por_funcao.Length + 5 ) );
//                     Array.Resize( ref lengths_por_funcao,( lengths_por_funcao.Length + 5 ) );

//                     // ** geral
//                     Array.Resize( ref ids_imagens_tipo_geral,( ids_imagens_tipo_geral.Length + 5 ) );

//                 }

//             int slot_livre = id_atual;
//             id_atual++;

//             nomes[ slot_livre ] = _nome;

//             return slot_livre;

//         }


//         private void Colocar_dados_no_objeto_tipo_especifico( int id, int[] _imagens_ids ){


//                 ids_imagens_tipo_especifico[ id ] = new int[ _imagens_ids.Length ];
//                 pointers_iniciais_por_funcao[ id ] = new int[ _imagens_ids.Length ];
//                 lengths_por_funcao[ id ] = new int[ _imagens_ids.Length ];


//                 int[] ids_tipos_especificos = ids_imagens_tipo_especifico[ id ];
//                 int[] pointers_iniciais = pointers_iniciais_por_funcao[ id ]; 
//                 int[] lengths = lengths_por_funcao[ id ]; 

            
//                 for( int index = 0 ; index < _imagens_ids.Length ; index++ ){


//                         int imagem_id = _imagens_ids[ index ];

//                         int pointer = localizador[ imagem_id ];
//                         int length = ( localizador[ imagem_id ] - pointer );

//                         ids_tipos_especificos[ index ] = imagem_id;
//                         pointers_iniciais[ index ] = pointer;
//                         lengths[ index ] = length;

//                         continue;
//                 }

//         }

//         private void Colocar_dados_no_objeto_tipo_geral( int _id, string[][] _chaves_array ){

//                 ids_imagens_tipo_geral[ _id ] = new int[ _chaves_array.Length ];

                

//                 for( int chave_index = 0 ; chave_index < _chaves_array.Length ; chave_index++ ){

//                         string[] chave = _chaves_array[ chave_index ];
//                         string path = System.IO.Path.Combine( chave );
//                         bool encontrou = false;
                        
//                         for( int index = 0 ; index < ( pointer_imagens_gerais_atual - 1 ) ; index++  ){

//                             if( imagens_gerais_paths[ index ] == path )
//                                 {
//                                     ids_imagens_tipo_geral[ _id ][ chave_index ] = index;
//                                     encontrou = true;
//                                     break;
//                                 }
                                
//                             continue;

//                         }

//                         if ( encontrou )
//                             { continue; }

//                         if( imagens_gerais_paths.Length == pointer_imagens_gerais_atual )
//                             { Array.Resize( ref imagens_gerais_paths, ( imagens_gerais_paths.Length + 5 ) ); }

//                         imagens_gerais_paths[ pointer_imagens_gerais_atual ] = path;

//                         pointer_imagens_gerais_atual++;
//                         continue;


//                 }





//         }


//         public void Definir_material( Shader _shader_material ){

//                 if( _shader_material == null )
//                     { throw new Exception( $"Tentou criar o material no modulo imagem { nome_dispositivo } mas o shader estava null" ); }
                    
//                 material_dispositivo = new Material( _shader_material );
//                 return;


//         }


//         private void Verificar_imagem( int _id ){

//             string[] nomes = Enum.GetNames( tipo );

//             if( _id >= nomes.Length )
//             { throw new Exception( $"tentou colocar a imagem com id { _id } mas tinha { nomes.Length} itens no enum" ); }

//             string nome = nomes[ _id ];
            

//             string path_imagem = System.IO.Path.Combine( path_folder__imagens_DEVELOPMENT, ( nome + ".png" ) ) ;

//             if( !!!( System.IO.File.Exists( path_imagem ) ) )
//                 { throw new Exception( $"Nao foi achado o arquivo no path { path_imagem }" ); }

            
//         }


//         // *** MUDAR TIPO
//         public void Definir_imagem_estatica( Dados_imagem_estatica _dados ){

//                 string _nome = _dados.imagem_id;
//                 int _imagem_id = _dados.imagem_id;

//                 // *** talvez dar a opcao para fazer a imagem ter as dimensoes da sprite?

//                 #if UNITY_EDITOR
//                     Verificar_imagem( _imagem_id );
//                 #endif

                
//                 int id = Adicionar_objeto( _nome );
                
//                 objetos_tipos[ id ] = Objeto_dispositivo_tipo.imagem_estatica;
//                 tipos_pegar_sprite[ id ] = Tipo_pegar_sprite.imagem_especifica;
                
//                 Colocar_dados_no_objeto_tipo_especifico( id, new int[]{ _imagem_id } );

//                 return;


//         }


//         // *** MUDAR TIPO
//         public void Definir_imagem_estatica_com_imagem_geral( string _nome,  string[] _chaves ){

                
//                 int id = Adicionar_objeto( _nome );
                
//                 objetos_tipos[ id ] = Objeto_dispositivo_tipo.imagem_estatica;
//                 tipos_pegar_sprite[ id ] = Tipo_pegar_sprite.imagem_geral;
                
//                 Colocar_dados_no_objeto_tipo_geral( id, new string[][] { _chaves } );

//                 return;


//         }






//         // *** MUDAR TIPO
//         // **  ver argumentos depois
//         public void Definir_imagem_botao( Dados_botao _dados_botao ){}
//         // public void Definir_imagem_scrollbar( int _parte_id,  int _imagem_id ){}
//         // public void Definir_imagem_slider( int _parte_id,  int _imagem_id ){}
//         // public void Definir_imagem_toggle( int _parte_id,  int _imagem_id ){}
//         // public void Definir_imagem_toggle_grupo( int _parte_id,  int _imagem_id ){}
//         // public void Definir_imagem_input_field( int _parte_id,  int _imagem_id ){}
//         // public void Definir_imagem_drop_down( int _parte_id,  int _imagem_id ){}




//         // --- CARREGAR IMAGEM


//         private Dados_para_carregar_imagens Criar_dados_default(){

//                 Dados_para_carregar_imagens dados = new Dados_para_carregar_imagens();

//                 // --- INDEXES QUE TEM CADA IMAGEM POR FUNCAO                
                
//                 int numero_maximo_de_imagens = 0;
//                 // --- PEGAR NUMERO DE IMAGENS 

//                 for( int objeto_index = 0 ; objeto_index < tipos_pegar_sprite.Length ; objeto_index++ ){

//                         int[] objeto_ids  = ids_imagens_tipo_especifico[ objeto_index ];

//                         // --- VERIFICA SE TEM 
//                         if( objeto_ids == null )
//                             { continue; }

//                         numero_maximo_de_imagens += objeto_ids.Length;
//                         continue;
//                 }


//                 // --- CRIA SLOTS
//                 dados.imagens_ids = INT.Criar_array_com_valor_especifico( numero_maximo_de_imagens, -1 );
//                 dados.pointers = INT.Criar_array_com_valor_especifico( numero_maximo_de_imagens, -1 );
//                 dados.lengths = INT.Criar_array_com_valor_especifico( numero_maximo_de_imagens, -1 );

//                 //dados.localizadores_proprias = new int[ numero_maximo_de_tipos ][];

//                 // dados.paths_imagens_gerais = new string[ numero_maximo_de_tipos ];

//                 return dados;

//         }

//         public class Dados_para_carregar_imagens {


//                 // --- PROPRIAS
//                 public int[] imagens_ids;
//                 public int[] pointers;
//                 public int[] lengths;

//                 // ** o localizador é diferente dos ids, porque aqui nao vai falar qual imagem que é mas qual slot esse id esta no array que vai voltar com os pngs
//                 public int[][] localizadores_proprias;

//                 // --- GERAIS
//                 public string[] paths_imagens_gerais;

//         }



//         private Dados_para_carregar_imagens Filtrar_imagens(){


//                 Dados_para_carregar_imagens dados_retorno = Criar_dados_default();

//                 int index_para_colocar = 0;
                
//                 for( int objeto_index = 0; objeto_index < nomes.Length ; objeto_index++ ){

//                         // --- VERIFICA SE ESTA VAZIO
//                         if( nomes[ objeto_index ] == null )
//                             { break; } // --- NAO EXISTE MAIS

//                         if( tipos_pegar_sprite[ objeto_index ] != Tipo_pegar_sprite.imagem_especifica )
//                             { continue; }

                        
//                         int[] imagens_ids_objeto = ids_imagens_tipo_especifico[ objeto_index ];
//                         //dados_retorno.localizadores_proprias[ objeto_index ] = new int[ imagens_ids_objeto.Length ];


//                         for( int index = 0 ; index < imagens_ids_objeto.Length ; index++ ){

//                                 int imagem_id = imagens_ids_objeto [ index ];

//                                 // --- VERIFICACOES
//                                 if( imagem_id < 0 )
//                                     { throw new System.Exception( $"Tentou pegar uma imagem no gerenciador { nome_dispositivo } mas a iamgem estava com id invalido. id: { imagem_id  }" ); }

//                                 int slot = INT.Pegar_index_valor( dados_retorno.imagens_ids, imagem_id );
//                                 if( slot != -1 )
//                                     {   
//                                         //dados_retorno.localizadores_proprias[ objeto_index ][ index ] = slot; 
//                                         continue;
//                                     }

                                
//                                 // --- ACRESCENTA NOVA IMAGEM
//                                 dados_retorno.imagens_ids[ index_para_colocar ] = imagem_id;
//                                 dados_retorno.pointers[ index_para_colocar ] = pointers_iniciais_por_funcao[ objeto_index ][ index ];
//                                 dados_retorno.lengths[ index_para_colocar ] = lengths_por_funcao[ objeto_index ][ index ];


//                                 // --- coloca qual index do localizador tem o id da imagem
//                                 //dados_retorno.localizadores_proprias[ objeto_index ][ index ] = index_para_colocar;

//                                 index_para_colocar++;

//                                 continue;

//                         }


            
//                 }

//                 // --- TIRAR EXTRA

//                 dados_retorno.imagens_ids = INT.Remover_valor( dados_retorno.imagens_ids, -1 );
//                 dados_retorno.pointers = INT.Remover_valor( dados_retorno.pointers, -1 );
//                 dados_retorno.lengths = INT.Remover_valor( dados_retorno.lengths, -1 );

//                 return dados_retorno;


//         }


//         public void Carregar_imagens(){


//                 Dados_para_carregar_imagens dados = Filtrar_imagens();


//                 int[] imagens_ids = dados.imagens_ids;
//                 int[] pointers = dados.pointers;
//                 int[] lengths = dados.lengths;
//                 // string[] paths = dados.paths;

//                 int[][] index_localizador_por_funcao = dados.localizadores_proprias; 


//                 // --- CRIAR SPRITES

//                 if( tipo == null )
//                     {

//                     }

//                 string[] nomes = Enum.GetNames( tipo );

//                 sprites_especificas = new Sprite[ nomes.Length ];


//                 // --- EDITOR
//                 #if UNITY_EDITOR

                
    
//                         // --- CARREGA IMAGENS

//                         for( int imagem_slot = 0 ; imagem_slot < imagens_ids.Length ; imagem_slot++ ){

                                
//                                 // --- PEGA NOME ESPECIFICO
//                                 int imagem_id = imagens_ids[ imagem_slot ];
//                                 if( imagem_id >= nomes.Length )
//                                     { throw new Exception( $"Veio um imagem_id de valor { imagem_id } mas o enum tinha { nomes.Length } itens" ); }

//                                 string nome_imagem_enum =  nomes[ imagem_id ];

//                                 // --- PEGA PATH ARQUIVO
//                                 string path_imagem = System.IO.Path.Combine( path_folder__imagens_DEVELOPMENT, nome_imagem_enum );
//                                 path_imagem = System.IO.Path.ChangeExtension( path_imagem, ".png" );

                                
//                                 // --- VERIFICA SE ARQUIVO EXISTE
//                                 if( !!!( System.IO.File.Exists( path_imagem ) ) )
//                                     { throw new Exception( $"Nao foi achado o arquivo com o nome <color=red><b>{ nome_imagem_enum }</b></color>pedido no gerenciador { nome_dispositivo } e no path: { path_imagem }" ); }

//                                 // --- CRIA ASPRITE
//                                 byte[] png = System.IO.File.ReadAllBytes( path_imagem );
//                                 sprites_especificas[ imagem_id ] = SPRITE.Transformar_png_TO_sprite( png );

//                                 continue;

//                         }


                                            

                
//                 // ---- BUILD
//                 #else


//                         byte[][] pngs = desmembrador_de_arquivo.Pegar_multiplos_dados( imagens_ids, pointers, lengths );
                        
//                         for( int index_novas_sprites_index = 0; index_novas_sprites_index < imagens_ids.Length  ; index_novas_sprites_index++ ){

//                                 int imagem_id = imagens_ids.Length;
//                                 sprites_especificas[ imagem_id ] = SPRITE.Transformar_png_TO_sprite( pngs[ index_novas_sprites_index ] );
//                                 continue;

//                         }

                    
//                 #endif



//                 // --- CARREGAR IMAGENS GERAIS

//                 string path_folder__imagens_dispositivos_reutilizaveis = Paths_sistema.path_folder__imagens_dispositivos_reutilizaveis;

//                 for( int imagem_geral_index = 0 ; imagem_geral_index < imagens_gerais_paths.Length ; imagem_geral_index++ ){


//                         // --- PEGA NOME ESPECIFICO
//                         string path_arquivo_interno = imagens_gerais_paths[ imagem_geral_index ];

//                         // --- VERIFICA SE AINDA TEm
//                         if( path_arquivo_interno == null )
//                             { break; }

                        
//                         string path_arquivo = System.IO.Path.Combine( path_folder__imagens_dispositivos_reutilizaveis, path_arquivo_interno );
//                         path_arquivo = System.IO.Path.ChangeExtension( path_arquivo, "png" );


//                         #if UNITY_EDITOR

//                             if( !!!( System.IO.File.Exists( path_arquivo ) ) )
//                                 { throw new System.Exception( $"Tentou pegar imagem especifica de um dispositivo no path  { path_arquivo } mas não foi encontrado"); }

//                         #endif


//                         // --- CRIA ASPRITE
//                         byte[] png = System.IO.File.ReadAllBytes( path_arquivo );
//                         sprites_geral[ imagem_geral_index ] = SPRITE.Transformar_png_TO_sprite( png );

//                         continue;

//                 }






//         }


//         public void Criar_sprites(){ 

//             // ** fazer depois
//             // quando criar => quando for chamar Colocar_imanges() vai ter que verificar se as sprites foram criadas

//         }



    
//         private void Colocar_imagem_tipo_estatico( int _id, string _path_game_object, string _nome ){

//                 if( sprites_especificas == null )
//                     { throw new Exception( "Nao foi dado o Carregar_imagens no modulo imagens dispositivos" ); }


//                 GameObject game_object = GameObject.Find( _path_game_object );

//                 if( game_object == null )
//                     { throw new Exception( $"Tentou pegar o gameObject <color=lightBlue><b>{ _nome }</b></color> mas nao foi encontrado no prefab" ); }


                
//                 Image image = game_object.GetComponent<Image>();
//                 image.material = material_dispositivo;


//                 Tipo_pegar_sprite tipo_pegar_sprite = tipos_pegar_sprite[ _id ];

//                 if( tipo_pegar_sprite == Tipo_pegar_sprite.imagem_especifica )
//                     {

//                         image.sprite = sprites_especificas[ _id ];
//                         image.color = Color.white;
//                         return;
//                     }

//                 if( tipo_pegar_sprite == Tipo_pegar_sprite.imagem_geral )
//                     {

//                         image.sprite = sprites_geral[ _id ];
//                         image.color = Color.white;
//                         return;
//                     }
//                 if( tipo_pegar_sprite == Tipo_pegar_sprite.nada )
//                     {

//                         image.sprite = null;
//                         image.color = Color.clear;
//                         return;
//                     }

                
                


//         }

//         private void Colocar_imagem_tipo_botao( int _id, string _path_game_object ){}
//         private void Colocar_imagem_tipo_scrollbar( int _id, string _path_game_object ){}
//         private void Colocar_imagem_tipo_drop_down( int _id, string _path_game_object ){}
//         private void Colocar_imagem_tipo_input_field( int _id, string _path_game_object ){}
//         private void Colocar_imagem_tipo_slider( int _id, string _path_game_object ){}
//         private void Colocar_imagem_tipo_toggle( int _id, string _path_game_object ){}
//         private void Colocar_imagem_tipo_toggle_grupo( int _id, string _path_game_object ){}
    


        
//         public void Colocar_imagens( GameObject _dispositivo_game_object ){


//                 // --- ESTATICAS

//                 string path_prefab = GAME_OBJECT.Pegar_path( _dispositivo_game_object );
                
//                 for( int nome_index = 0 ; nome_index < nomes.Length; nome_index++ ){

//                     string nome = nomes[ nome_index ];
//                     string nome_game_object = path_prefab + "/" + nome;

//                     Objeto_dispositivo_tipo tipo = objetos_tipos[ nome_index ];

//                     switch( tipo ){

//                         case Objeto_dispositivo_tipo.imagem_estatica : Colocar_imagem_tipo_estatico( nome_index, nome_game_object, nome ); break;
//                         case Objeto_dispositivo_tipo.botao : Colocar_imagem_tipo_botao( nome_index, nome_game_object ); break;
//                         case Objeto_dispositivo_tipo.scrollbar : Colocar_imagem_tipo_scrollbar( nome_index, nome_game_object ); break;
//                         case Objeto_dispositivo_tipo.drop_down : Colocar_imagem_tipo_drop_down( nome_index, nome_game_object ); break;
//                         case Objeto_dispositivo_tipo.input_field : Colocar_imagem_tipo_input_field( nome_index, nome_game_object ); break;
//                         case Objeto_dispositivo_tipo.slider : Colocar_imagem_tipo_slider( nome_index, nome_game_object ); break;
//                         case Objeto_dispositivo_tipo.toggle : Colocar_imagem_tipo_toggle( nome_index, nome_game_object ); break;
//                         case Objeto_dispositivo_tipo.toggle_grupo : Colocar_imagem_tipo_toggle_grupo( nome_index, nome_game_object ); break;
                        
//                     }



//                 }




                




//         }



// }





