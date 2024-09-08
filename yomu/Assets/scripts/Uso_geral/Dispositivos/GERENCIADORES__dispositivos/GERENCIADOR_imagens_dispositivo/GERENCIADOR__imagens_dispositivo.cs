using UnityEngine;
using UnityEngine.UI;
using System;



public enum Tipo_pegar_sprite {

    nada, 
    imagem_especifica, 
    imagem_geral

}


public enum Extensao_imagem {

    png, 
    webp,
    
}

public class GERENCIADOR__imagens_dispositivo {


        // Definir imagens para carregar => classe especifica
        // carregar => modulo
        // colocar imagens => modulo 
        // alterar imagens => classe especifica => modulo


        

        public Extensao_imagem extensao_imagem_atual;

        // --- MODULOS
        public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;

        public Material material_dispositivo;
        

        // --- DADOS
        public Sprite[] sprites_especificas;
        public Sprite[] sprites_geral;
        
        public byte[][] sprites_especificas_formato_compresso;
        public byte[][] sprites_geral_formato_compresso;

        public int bytes_sendo_usados_compresso;

        // ** nome
        int id_atual = 0;
        public string[] nomes;


        // ** define quais vao ser carregados


        // ** especifico
        public int[] imagens_especificos_ativas;
        public int[] pointers_imagens_especificas;
        public int[] lengths_imagens_especificas;



        // ** gerais

        public int sprite_id_geral_pointer_atual; // += length
        public int[] imagens_gerais_indexes_COM_localizador_id;


        // *** animacao ponto inicial
        public int pointer_nome_localizador_atual; // ++
        public string[] imagens_gerais_nomes_localizador;

        // ** build
        public string[] folders_imagens_gerais; // usado para achar o .dat com as imagens
        public int[] ids_imagens_gerais_reais; 

        // ** editor
        public string[] paths_imagens;
        





        


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
        


        public GERENCIADOR__imagens_dispositivo (  Dispositivo _dispositivo ){ 



                string _nome_dispositivo = _dispositivo.nome_dispositivo;
                string[] _folders = _dispositivo.interface_dispositivo.Pegar_folders();
                System.Type _tipo_imagens = _dispositivo.interface_dispositivo.Pegar_tipo_imagens();


                folders = _folders;
                nome_dispositivo = _nome_dispositivo;
                material_dispositivo = new Material( Shaders.normal );
                tipo = _tipo_imagens;
                

                int maximo_sprites_especificas = System.Enum.GetNames( _tipo_imagens ).Length;


                // ** especifico
                imagens_especificos_ativas = new int[ maximo_sprites_especificas ] ;
                pointers_imagens_especificas = new int[ maximo_sprites_especificas ] ;
                lengths_imagens_especificas = new int[ maximo_sprites_especificas ] ;

                // ** geral
                int slots_iniciais_gerais = 25;


                imagens_gerais_nomes_localizador = new string[ slots_iniciais_gerais ];

                // ** build 
                ids_imagens_gerais_reais = new int[ slots_iniciais_gerais ];
                folders_imagens_gerais = new string[ slots_iniciais_gerais ];

                // ** editor
                paths_imagens = new string[ slots_iniciais_gerais * 5 ];






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
                    path_folder__imagens_DEVELOPMENT = GERENCIADOR__imagens_dispositivo.Pegar_path_imagens_DEVELOPMENT( _folders, _nome_dispositivo );

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

                        imagens_especificos_ativas[ imagem_id ] = 1;

                        // --- PEGA NOVO VALOR

                        int pointer = localizador[ imagem_id ];
                        int length = ( localizador[ imagem_id ] - pointer );

                        pointers_imagens_especificas[ imagem_id ] = pointer;
                        lengths_imagens_especificas[ imagem_id ] = length;

                        continue;
                }

        }


        private void Pegar_dados_imagens_especificas_pointers( int _pointer_inicial, int _pointer_final  ){


                // --- VERIFICA SE AS IMAGENS JA FORAM PEGAS
                for( int pointer = _pointer_inicial ; pointer < _pointer_final ; pointer++ ){

                                        
                        #if UNITY_EDITOR
                            Verificar_imagem( pointer );
                        #endif

                        // --- VERIFICA SE JA FOI PEGO
                        if( imagens_especificos_ativas[ pointer ] == 1 )
                            { continue; }

                        imagens_especificos_ativas[ pointer ] = 1;

                        // --- PEGA NOVO VALOR

                        int pointer_imagem = localizador[ pointer ];
                        int length = ( localizador[ ( pointer + 1 )] - pointer_imagem );

                        pointers_imagens_especificas[ pointer ] = pointer;
                        lengths_imagens_especificas[ pointer ] = length;

                        continue;
                }

        }


        private void Pegar_dados_imagem_especifica( int _imagem_id ){


                #if UNITY_EDITOR
                    Verificar_imagem( _imagem_id );
                #endif

                if( imagens_especificos_ativas[ _imagem_id ] == 1 )
                    { return; }

                imagens_especificos_ativas[ _imagem_id ] = 1;  

                

                int pointer = localizador[ _imagem_id ];
                int length = ( localizador[ _imagem_id ] - pointer );

                pointers_imagens_especificas[ _imagem_id ] = pointer;
                lengths_imagens_especificas[ _imagem_id ] = length;

                return;

        }




        // retorno os ids_finais
        private int Pegar_dados_imagens_tipo_geral_com_pointers( object _chave, int _length ){

                
                // ** aniamcao sempre tem que ser do mesmo geral

                if( _chave == null )
                    { throw new Exception("Chave veio null"); }

                
                string folder = _chave.GetType().Name.Split( "__" )[ 0 ];
                string nome_imagem  = _chave.ToString();
                string imagem_localizador_nome = ( folder + "_" + nome_imagem );

                // ** se achar nao precisa procurar mais, pois como toda animacao tem a mesma length todos os itens j[a foram carregados ]

                for( int index = 0 ; index < ( pointer_nome_localizador_atual - 1 ) ; index++  ){


                        string str_para_verificar = imagens_gerais_nomes_localizador[ index ];

                        if( str_para_verificar.Length != imagem_localizador_nome.Length )
                            { continue; }

                        if( str_para_verificar[ 0 ] != imagem_localizador_nome[ 0 ] )
                            { continue; }

                        if( str_para_verificar[ str_para_verificar.Length ] != imagem_localizador_nome[ imagem_localizador_nome.Length ] )
                            { continue; }
                        
                        if( str_para_verificar[ ( str_para_verificar.Length / 2 ) ] != imagem_localizador_nome[ ( imagem_localizador_nome.Length / 2 ) ] )
                            { continue; }

                        // --- ACHOU
                        if( str_para_verificar == imagem_localizador_nome )
                            { return imagens_gerais_indexes_COM_localizador_id[ index ] ; }

                        // --- VERIFICA O PROXIMO ELEMENTO
                        continue;
                        
                }


                // --- TEM QUE CRIAR 


                #if UNITY_EDITOR

                        string[] nomes = Enum.GetNames( _chave.GetType() );
                        int pointer_inicial = ( int ) _chave;

                        int sprite_id_inicial = sprite_id_geral_pointer_atual;

                        string extensao = extensao_imagem_atual.ToString();

                        for( int pointer = pointer_inicial; pointer < ( pointer_inicial + _length ); pointer++ ){

                                string nome_especifico = nomes[ pointer ];
                                paths_imagens[ sprite_id_inicial ] = System.IO.Path.Combine( Paths_sistema.path_folder__imagens_dispositivos_reutilizaveis, folder, nome_especifico );
                                
                                paths_imagens[ sprite_id_inicial ] = System.IO.Path.ChangeExtension( paths_imagens[ sprite_id_inicial ], extensao );

                                Verificar_imagem_geral( nome_especifico );
                                
                                if( paths_imagens.Length == sprite_id_inicial )
                                    { Array.Resize( ref paths_imagens, ( paths_imagens.Length + 50 ) ); }

                                sprite_id_inicial++;
                                continue;

                        }

                #endif



                imagens_gerais_nomes_localizador[ pointer_nome_localizador_atual ] = imagem_localizador_nome; // localizar
                folders_imagens_gerais[ pointer_nome_localizador_atual ] = folder; // usado para achar o .dat
                ids_imagens_gerais_reais[ pointer_nome_localizador_atual ] = ( int ) _chave; // usado para ver o pointer inicial
                imagens_gerais_indexes_COM_localizador_id[ pointer_nome_localizador_atual ] = sprite_id_geral_pointer_atual; // indica pointer nas sprites

                pointer_nome_localizador_atual++;
                sprite_id_geral_pointer_atual += _length;

                return pointer_inicial;

        }







        // retorno os ids_finais
        private int Pegar_dados_imagem_tipo_geral( object _localizador ){


                
                string folder = _localizador.GetType().Name.Split( "__" )[ 0 ];
                string nome_imagem = _localizador.ToString();

                string nome = System.IO.Path.Combine( folder, nome_imagem );
            
                for( int localizador_index = 0 ; localizador_index < ( pointer_nome_localizador_atual - 1 ) ; localizador_index++  ){

                        if( imagens_gerais_nomes_localizador[ localizador_index ] == nome )
                            { return imagens_gerais_indexes_COM_localizador_id[ localizador_index ];}
                            
                }


                // --- PEGAR IMAGEM

                string path_arquivo = System.IO.Path.Combine( Paths_sistema.path_folder__imagens_dispositivos_reutilizaveis, ( nome + "." + extensao_imagem_atual.ToString()) );

                Verificar_imagem_geral( path_arquivo );

                paths_imagens[ sprite_id_geral_pointer_atual ] = path_arquivo;


                imagens_gerais_nomes_localizador[ pointer_nome_localizador_atual ] = nome; // localizar
                folders_imagens_gerais[ pointer_nome_localizador_atual ] = folder; // usado para achar o .dat
                ids_imagens_gerais_reais[ pointer_nome_localizador_atual ] = ( int ) _localizador; // usado para ver o pointer inicial
                imagens_gerais_indexes_COM_localizador_id[ pointer_nome_localizador_atual ] = sprite_id_geral_pointer_atual; // indica pointer nas sprites

                pointer_nome_localizador_atual++;
                sprite_id_geral_pointer_atual++;

                
                if( paths_imagens.Length == sprite_id_geral_pointer_atual )
                    { Array.Resize( ref paths_imagens, ( paths_imagens.Length + 50 ) ); }

                return ( sprite_id_geral_pointer_atual - 1 );


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


        private void Verificar_imagem_geral( string _path ){

            #if UNITY_EDITOR

                if( !!!( System.IO.File.Exists( _path ) ) )
                    { throw new Exception( $"Nao foi achado o arquivo no path { _path }" ); }

            #endif

            
        }




        
        // --- IMAGEM ESTATICA


        public void Definir_imagem_estatica( Dados_imagem_estatica_dispositivo _dados ){

                if( _dados.tipo_pegar_sprite == Tipo_pegar_sprite.imagem_especifica )

                switch( _dados.tipo_pegar_sprite ){

                    case Tipo_pegar_sprite.imagem_especifica: Pegar_dados_imagem_especifica( _dados.imagem_id );  _dados.imagem_id_final = _dados.imagem_id; break;
                    case Tipo_pegar_sprite.imagem_geral: _dados.imagem_id_final = Pegar_dados_imagem_tipo_geral(  _dados.chaves ); break;
                    case Tipo_pegar_sprite.nada: break;

                }

        }


        // --- BOTAO



        private void Definir_imagens_botao_com_array(  int _numero_loop_1, int _numero_loop_2, Dados_para_criar_botao_localizador_imagens[,] _dados_localizador  ){



                for( int parte_animacao_index = 0 ; parte_animacao_index < _numero_loop_1 ; parte_animacao_index++ ){


                        for( int slot_animacao_index = 0, trava_seguranca = 0 ; slot_animacao_index < _numero_loop_2; trava_seguranca++ ){

                                // --- VERIFICA TRAVA
                                if( trava_seguranca > 100_000 )
                                    { throw new Exception("ativou trava seguranca loop"); }


                                Dados_para_criar_botao_localizador_imagens localizador = _dados_localizador[ parte_animacao_index , slot_animacao_index ];

                                // interar sobre a length 
                                if( localizador.length < 1 )
                                    { throw new Exception( $"length { localizador.length }"); }

                                if( localizador.length == 1 )
                                    {

                                        switch( localizador.tipo_pegar_sprite ){

                                            case Tipo_pegar_sprite.imagem_especifica: Pegar_dados_imagem_especifica( localizador.sprite_id ); break;
                                            case Tipo_pegar_sprite.imagem_geral: localizador.sprite_id = Pegar_dados_imagem_tipo_geral( localizador.sprite_id_geral ); break;
                                            case Tipo_pegar_sprite.nada: break;

                                        }

                                        slot_animacao_index++;
                                        continue;

                                    }

                                
                                Tipo_pegar_sprite tipo = localizador.tipo_pegar_sprite;


                                switch( tipo ){

                                    case Tipo_pegar_sprite.imagem_especifica: Pegar_dados_imagens_especificas_pointers( localizador.sprite_id, ( localizador.sprite_id + localizador.length ) ); break;
                                    case Tipo_pegar_sprite.imagem_geral: localizador.sprite_id = Pegar_dados_imagens_tipo_geral_com_pointers( localizador.sprite_id_geral, localizador.length ); break;
                                    case Tipo_pegar_sprite.nada: slot_animacao_index++; continue;


                                }

                                slot_animacao_index += localizador.length;
                                

                                // ** VAI PARA A PROXIMA SPRITE DOS SLOTS, PODE SER DO MESMO TIPO ( BASE, DECORACA, etc ) OU DE UM TIPO DIFERENTE
                                continue;

                        }

                        // ** VAI PARA O PROXIMO TIPO ( OFF, ON, TRANSICAO_ON_para_OFF, etc )
                        continue;

                }

                return;


        }



        public void Definir_botao( Dados_botao_dispositivo dados ){


                Sprite[,] sprites_matrix;
                Dados_para_criar_botao_localizador_imagens[,] dados_localizadores;

                int numero_partes;
                int numero_slots;


                // --- NORMAL
                sprites_matrix = dados.sprites_animacoes_completas;
                dados_localizadores = dados.imagens_localizadores;

                numero_partes = sprites_matrix.GetLength( 0 );
                numero_slots = sprites_matrix.GetLength( 1 );

                Definir_imagens_botao_com_array( numero_partes, numero_slots, dados_localizadores );

                // --- DECORACAO COMPOSTA
                sprites_matrix = dados.sprites_decoracao_composta;
                dados_localizadores = dados.imagens_localizadores_decoracao_composta;

                numero_partes = sprites_matrix.GetLength( 0 );
                numero_slots = sprites_matrix.GetLength( 1 );

                Definir_imagens_botao_com_array( numero_partes, numero_slots, dados_localizadores );

                // for( int parte_animacao_index = 0 ; parte_animacao_index < 5 ; parte_animacao_index++ ){


                //         for( int slot_animacao_index = 0, trava_seguranca = 0 ; slot_animacao_index < numero_slots; trava_seguranca++ ){

                //                 // --- VERIFICA TRAVA
                //                 if( trava_seguranca > 100_000 )
                //                     { throw new Exception("ativou trava seguranca loop"); }


                //                 Dados_para_criar_botao_localizador_imagens localizador = dados_localizadores[ parte_animacao_index , slot_animacao_index ];

                //                 // interar sobre a length 
                //                 if( localizador.length < 1 )
                //                     { throw new Exception( $"length { localizador.length }"); }

                //                 if( localizador.length == 1 )
                //                     {

                //                         switch( localizador.tipo_pegar_sprite ){

                //                             case Tipo_pegar_sprite.imagem_especifica: Pegar_dados_imagem_especifica( localizador.sprite_id ); break;
                //                             case Tipo_pegar_sprite.imagem_geral: localizador.sprite_id = Pegar_dados_imagem_tipo_geral( localizador.sprite_id_geral ); break;
                //                             case Tipo_pegar_sprite.nada: break;

                //                         }

                //                         slot_animacao_index++;
                //                         continue;

                //                     }

                                
                //                 Tipo_pegar_sprite tipo = localizador.tipo_pegar_sprite;


                //                 switch( tipo ){

                //                     case Tipo_pegar_sprite.imagem_especifica: Pegar_dados_imagens_especificas_pointers( localizador.sprite_id, ( localizador.sprite_id + localizador.length ) ); break;
                //                     case Tipo_pegar_sprite.imagem_geral: localizador.sprite_id = Pegar_dados_imagens_tipo_geral_com_pointers( localizador.sprite_id_geral, localizador.length ); break;
                //                     case Tipo_pegar_sprite.nada: slot_animacao_index++; continue;


                //                 }

                //                 slot_animacao_index += localizador.length;
                                

                //                 // ** VAI PARA A PROXIMA SPRITE DOS SLOTS, PODE SER DO MESMO TIPO ( BASE, DECORACA, etc ) OU DE UM TIPO DIFERENTE
                //                 continue;

                //         }

                //         // ** VAI PARA O PROXIMO TIPO ( OFF, ON, TRANSICAO_ON_para_OFF, etc )
                //         continue;

                // }


                // --- DECORACAO COMPOSTA


                // sprites_matrix = dados.sprites_animacoes_completas;
                // dados_localizadores = dados.imagens_localizadores;

                // numero_partes = sprites_matrix.GetLength( 0 );
                // numero_slots = sprites_matrix.GetLength( 1 );

                // for( int parte_animacao_index = 0 ; parte_animacao_index < 5 ; parte_animacao_index++ ){


                //         for( int slot_animacao_index = 0, trava_seguranca = 0 ; slot_animacao_index < numero_slots; trava_seguranca++ ){

                //                 // --- VERIFICA TRAVA
                //                 if( trava_seguranca > 100_000 )
                //                     { throw new Exception("ativou trava seguranca loop"); }


                //                 Dados_para_criar_botao_localizador_imagens localizador = dados_localizadores[ parte_animacao_index , slot_animacao_index ];

                //                 // interar sobre a length 
                //                 if( localizador.length < 1 ) 
                //                     { throw new Exception( $"length { localizador.length }"); } 

                //                 if( localizador.length == 1 )
                //                     {

                //                         switch( localizador.tipo_pegar_sprite ){

                //                             case Tipo_pegar_sprite.imagem_especifica: Pegar_dados_imagem_especifica( localizador.sprite_id ); break;
                //                             case Tipo_pegar_sprite.imagem_geral: localizador.sprite_id = Pegar_dados_imagem_tipo_geral( localizador.sprite_id_geral ); break;
                //                             case Tipo_pegar_sprite.nada: break;

                //                         }

                //                         slot_animacao_index++;
                //                         continue;

                //                     }

                                
                //                 Tipo_pegar_sprite tipo = localizador.tipo_pegar_sprite;


                //                 switch( tipo ){

                //                     case Tipo_pegar_sprite.imagem_especifica: Pegar_dados_imagens_especificas_pointers( localizador.sprite_id, ( localizador.sprite_id + localizador.length ) ); break;
                //                     case Tipo_pegar_sprite.imagem_geral: localizador.sprite_id = Pegar_dados_imagens_tipo_geral_com_pointers( localizador.sprite_id_geral, localizador.length ); break;
                //                     case Tipo_pegar_sprite.nada: slot_animacao_index++; continue;


                //                 }

                //                 slot_animacao_index += localizador.length;
                                

                //                 // ** VAI PARA A PROXIMA SPRITE DOS SLOTS, PODE SER DO MESMO TIPO ( BASE, DECORACA, etc ) OU DE UM TIPO DIFERENTE
                //                 continue;

                //         }

                //         // ** VAI PARA O PROXIMO TIPO ( OFF, ON, TRANSICAO_ON_para_OFF, etc )
                //         continue;

                // }








        }




        // --- CARREGAR IMAGEM

        public void Carregar_imagens(){


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

                sprites_especificas_formato_compresso = new byte[ nomes.Length][];
            

                // --- EDITOR
                #if UNITY_EDITOR
                

                        // --- CARREGA IMAGENS ESPECIFICAS
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
                                sprites_especificas_formato_compresso[ imagem_id ] = System.IO.File.ReadAllBytes( path_imagem );
                                bytes_sendo_usados_compresso += sprites_especificas_formato_compresso[ imagem_id ].Length;
                                
                                continue;

                        }

                        // --- CARREGAR IMAGENS GERAIS
                        sprites_geral_formato_compresso = new byte[ sprite_id_geral_pointer_atual ][];

                        for( int imagem_geral_index = 0 ; imagem_geral_index < paths_imagens.Length ; imagem_geral_index++ ){


                                // --- PEGA NOME ESPECIFICO
                                string path_arquivo = paths_imagens[ imagem_geral_index ];

                                // --- VERIFICA SE AINDA TEm
                                if( path_arquivo == null )
                                    { break; }

                                
                                #if UNITY_EDITOR

                                    if( !!!( System.IO.File.Exists( path_arquivo ) ) )
                                        { throw new System.Exception( $"Tentou pegar imagem especifica de um dispositivo no path  { path_arquivo } mas não foi encontrado" ); }

                                #endif


                                sprites_geral_formato_compresso[ imagem_geral_index ] = System.IO.File.ReadAllBytes( path_arquivo );
                                bytes_sendo_usados_compresso += sprites_geral_formato_compresso[ imagem_geral_index ].Length;

                                continue;

                        }






                
                // ---- BUILD
                #else


                        byte[][] pngs = desmembrador_de_arquivo.Pegar_multiplos_dados( imagens_ids, pointers, lengths );
                        
                        for( int index_novas_sprites_index = 0; index_novas_sprites_index < imagens_ids.Length  ; index_novas_sprites_index++ ){

                                int imagem_id = imagens_ids[ index_novas_sprites_index ];

                                sprites_especificas_formato_compresso[ imagem_id ] = pngs[ index_novas_sprites_index ];
                                bytes_sendo_usados_compresso += sprites_especificas_formato_compresso[ imagem_id ].Length;
                                continue;

                        }

                    
                #endif




        }


        public void Descompactar_dados(){ 

                // *** por hora vais er na main
                
                sprites_especificas = new Sprite[ sprites_especificas_formato_compresso.Length ];
                sprites_geral = new Sprite[ sprites_geral_formato_compresso.Length ];
    
                // --- CARREGA IMAGENS

                for( int imagem_index = 0 ; imagem_index < imagens_especificos_ativas.Length ; imagem_index++ ){

                        if( imagens_especificos_ativas[ imagem_index ] == 0 )
                            { continue; }

                        sprites_especificas[ imagem_index ] = SPRITE.Transformar_png_TO_sprite( sprites_especificas_formato_compresso[ imagem_index ] );
    
                }

                for( int imagem_geral_index = 0 ; imagem_geral_index < sprites_geral_formato_compresso.Length ; imagem_geral_index++ ){

                        sprites_geral[ imagem_geral_index ] = SPRITE.Transformar_png_TO_sprite( sprites_geral_formato_compresso[ imagem_geral_index ] );
    
                }

                return;


        }




        public void Colocar_imagens_tipo_imagem_estatica( Dados_imagem_estatica_dispositivo[] _dados_imagens, string _dispositivo_game_object_path ){


                if( _dados_imagens == null )
                    { throw new Exception( "Dados_imagem_estatica_dispositivo veio null" ); }


                for( int imagem_index = 0 ; imagem_index < _dados_imagens.Length ; imagem_index++ ){

                        Dados_imagem_estatica_dispositivo dados = _dados_imagens[ imagem_index ];

                        if( dados == null )
                            { break; }

                        string nome = dados.nome;

                        string path_objeto = _dispositivo_game_object_path + "/" + nome;

                        GameObject game_object = GameObject.Find( path_objeto );

                        if( game_object == null )
                            { throw new Exception( $"Tentou pegar o gameObject da imagem estatica <color=lightBlue><b>{ nome }</b></color> mas nao foi encontrado no prefab." ); }


                        dados.imagem_game_object = game_object;
                        dados.material_dispositivo = material_dispositivo;

                        
                        int imagem_id = dados.imagem_id_final;

                        if( dados.tipo_pegar_sprite == Tipo_pegar_sprite.imagem_especifica )
                            { dados.imagem_sprite = sprites_especificas[ imagem_id ]; }

                        if( dados.tipo_pegar_sprite == Tipo_pegar_sprite.imagem_geral )
                            { dados.imagem_sprite = sprites_geral[ imagem_id ]; }

                        if( dados.tipo_pegar_sprite == Tipo_pegar_sprite.nada )
                            { dados.imagem_sprite = null; }

                        continue;


                }

                
        }



        private void Colocar_imagens_tipo_botao_com_array( int _loop_1, int _loop_2, Sprite[,] _sprites_matrix, Dados_para_criar_botao_localizador_imagens[,] _dados_localizadores ){

                        for( int parte_animacao_index = 0 ; parte_animacao_index < _loop_1 ; parte_animacao_index++ ){

                                for( int slot_animacao_index = 0, trava_seguranca = 0; slot_animacao_index < _loop_2; trava_seguranca++ ){

                                        // --- VERIFICA TRAVA
                                        if( trava_seguranca > 100_000_000 )
                                            { throw new Exception("ativou trava seguranca loop"); }


                                        Dados_para_criar_botao_localizador_imagens localizador = _dados_localizadores[ parte_animacao_index , slot_animacao_index ];

                                        // interar sobre a length 
                                        if( localizador.length == 0 )
                                            { throw new Exception("length 0"); }

                                        // --- PULA SE FOR IMAGENS VAZIAS
                                        if( localizador.tipo_pegar_sprite == Tipo_pegar_sprite.nada )
                                            {
                                                slot_animacao_index += localizador.length;
                                                continue;
                                            }

                                        Sprite[] sprites = null;

                                        if( localizador.tipo_pegar_sprite == Tipo_pegar_sprite.imagem_especifica )
                                            { sprites = sprites_especificas; }
                                            else
                                            { sprites = sprites_geral; }


                                        for(  int index_sprite = 0 ; index_sprite < localizador.length ; index_sprite++ ){


                                                int index = ( localizador.sprite_id + index_sprite );
                                                int novo_slot = ( slot_animacao_index + index_sprite );


                                                if( index >= sprites.Length )
                                                    { throw new Exception( $"Em um sequencia tentou pegar a sprite do index{ index } mas o array era menor" ); }
                                                
                                                // --- COLOCA SPRITE
                                                _sprites_matrix[ parte_animacao_index , novo_slot ] = sprites[ index ];

                                                // --- AUMENTA SLOT 
                                                slot_animacao_index++; 
                                                continue;


                                        }


                                        // ** VAI PARA A PROXIMA SPRITE NO MESMO TIPO ( BASE, DECORACAO, etc )
                                        continue;

                                }
                                // ** VAI PARA O PROXIMO TIPO ( OFF, ON, TRANSICAO_ON_para_OFF, etc )
                                continue;

                        }



        }



        public void Colocar_imagens_tipo_botao( Dados_botao_dispositivo[] _dados_botoes, string _dispositivo_game_object_path ){


                if( sprites_especificas == null )
                    { throw new Exception( "Nao foi dado o Carregar_imagens no modulo imagens dispositivos" ); }

                if( _dispositivo_game_object_path == null )
                    { throw new Exception( $"_dispositivo_game_object_path veio null" ); }



                // --- VERIFICAR SE DADOS FORAM CARREGADOS

                // ()...



                for( int botao_index = 0 ; botao_index < _dados_botoes.Length ; botao_index++ ){

                        Dados_botao_dispositivo dados = _dados_botoes[ botao_index ];

                        if( dados == null )
                            { continue; }


                        

                        dados.material_dispositivo = material_dispositivo;


                        Sprite[,] sprites_matrix;
                        Dados_para_criar_botao_localizador_imagens[,] dados_localizadores;

                        int numero_partes;
                        int numero_slots;


                        // --- NORMAL
                        sprites_matrix = dados.sprites_animacoes_completas;
                        dados_localizadores = dados.imagens_localizadores;

                        numero_partes = sprites_matrix.GetLength( 0 );
                        numero_slots = sprites_matrix.GetLength( 1 );

                        Colocar_imagens_tipo_botao_com_array( numero_partes, numero_slots, sprites_matrix, dados_localizadores );


                        // --- VERIFICA SE TEM DECORACAO COMPOSTA
                        if( dados.sprites_decoracao_composta == null )
                            { continue; } // --- NAO TEM

                        


                        // --- DECORACAO COMPOSTA
                        sprites_matrix = dados.sprites_decoracao_composta;
                        dados_localizadores = dados.imagens_localizadores_decoracao_composta;

                        numero_partes = sprites_matrix.GetLength( 0 );
                        numero_slots = sprites_matrix.GetLength( 1 );


                        Colocar_imagens_tipo_botao_com_array( numero_partes, numero_slots, sprites_matrix, dados_localizadores );

                        Debug.Log("veio aqui");



                        

                        // for( int parte_animacao_index = 0 ; parte_animacao_index < 5 ; parte_animacao_index++ ){

                        //         for( int slot_animacao_index = 0, trava_seguranca = 0; slot_animacao_index < numero_slots; trava_seguranca++ ){

                        //                 // --- VERIFICA TRAVA
                        //                 if( trava_seguranca > 100_000_000 )
                        //                     { throw new Exception("ativou trava seguranca loop"); }


                        //                 Dados_para_criar_botao_localizador_imagens localizador = dados_localizadores[ parte_animacao_index , slot_animacao_index ];

                        //                 // interar sobre a length 
                        //                 if( localizador.length == 0 )
                        //                     { throw new Exception("length 0"); }

                        //                 // --- PULA SE FOR IMAGENS VAZIAS
                        //                 if( localizador.tipo_pegar_sprite == Tipo_pegar_sprite.nada )
                        //                     {
                        //                         slot_animacao_index += localizador.length;
                        //                         continue;
                        //                     }

                        //                 Sprite[] sprites = null;

                        //                 if( localizador.tipo_pegar_sprite == Tipo_pegar_sprite.imagem_especifica )
                        //                     { sprites = sprites_especificas; }
                        //                     else
                        //                     { sprites = sprites_geral; }


                        //                 for(  int index_sprite = 0 ; index_sprite < localizador.length ; index_sprite++ ){


                        //                         int index = ( localizador.sprite_id + index_sprite );
                        //                         int novo_slot = ( slot_animacao_index + index_sprite );


                        //                         if( index >= sprites.Length )
                        //                             { throw new Exception( $"Em um sequencia tentou pegar a sprite do index{ index } mas o array era menor" ); }
                                                
                        //                         // --- COLOCA SPRITE
                        //                         sprites_matrix[ parte_animacao_index , novo_slot ] = sprites[ index ];

                        //                         // --- AUMENTA SLOT 
                        //                         slot_animacao_index++; 
                        //                         continue;


                        //                 }


                        //                 // ** VAI PARA A PROXIMA SPRITE NO MESMO TIPO ( BASE, DECORACAO, etc )
                        //                 continue;

                        //         }
                        //         // ** VAI PARA O PROXIMO TIPO ( OFF, ON, TRANSICAO_ON_para_OFF, etc )
                        //         continue;

                        // }


                }


        }

        




}





