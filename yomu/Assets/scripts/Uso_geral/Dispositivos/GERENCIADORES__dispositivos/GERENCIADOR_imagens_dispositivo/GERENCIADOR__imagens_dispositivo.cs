using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;



public class GERENCIADOR__imagens_dispositivo {

    
        public Extensao_imagem extensao_imagem_atual;
        public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;
    
        public Material material_dispositivo;
        

        // --- DADOS
        public Sprite[] sprites;
        public byte[][] pngs;
        public int pointer = -1;


        public Dictionary<string,int> paths_dic;
            
        public string nome_dispositivo;    
        public string path_folder__imagens_DEVELOPMENT = ""; // ** aponta para o folder que tem as imagens 


        public GERENCIADOR__imagens_dispositivo (  Dispositivo _dispositivo ){ 


                nome_dispositivo = _dispositivo.nome_dispositivo;
                material_dispositivo = new Material( Shaders.normal );

                paths_dic = new Dictionary<string, int>();

                
                int numero_inicial_slots = 25;
                                
                sprites = new Sprite[  numero_inicial_slots ];
                pngs = new byte[  numero_inicial_slots ][];
            
                

                return;


        }


        // ** return the index of the image
        public int Declare_image( string _path ){

            int id; 
            if ( paths_dic.TryGetValue( _path, out id ) )
                { return id; }

            // --- novo
            paths_dic.Add( _path, pointer++ );
            return pointer;

        }


        public void Definir_material( Shader _shader_material ){

                if( _shader_material == null )
                    { throw new Exception( $"Tentou criar o material no modulo imagem { nome_dispositivo } mas o shader estava null" ); }
                    
                material_dispositivo = new Material( _shader_material );
                return;


        }


        public void Load_resources(){

            // ** criar 



        }





        //mark
        // ** conteudo importante





        public void Colocar_imagens_tipo_imagem_estatica( Dados_imagem_estatica_dispositivo[] _dados_imagens, string _dispositivo_game_object_path ){


                // if( _dados_imagens == null )
                //     { throw new Exception( "Dados_imagem_estatica_dispositivo veio null" ); }


                // for( int imagem_index = 0 ; imagem_index < _dados_imagens.Length ; imagem_index++ ){

                //         Dados_imagem_estatica_dispositivo dados = _dados_imagens[ imagem_index ];

                //         if( dados == null )
                //             { break; }

                //         string nome = dados.nome;

                //         string path_objeto = _dispositivo_game_object_path + "/" + nome;

                //         GameObject game_object = GameObject.Find( path_objeto );

                //         if( game_object == null )
                //             { throw new Exception( $"Tentou pegar o gameObject da imagem estatica <color=lightBlue><b>{ nome }</b></color> mas nao foi encontrado no prefab." ); }


                //         dados.imagem_game_object = game_object;
                //         dados.material_dispositivo = material_dispositivo;

                        
                //         int imagem_id = dados.imagem_id_final;

                //         if( dados.tipo_pegar_sprite == Tipo_pegar_sprite.imagem_especifica )
                //             { dados.imagem_sprite = sprites_especificas[ imagem_id ]; }

                //         if( dados.tipo_pegar_sprite == Tipo_pegar_sprite.imagem_geral )
                //             { dados.imagem_sprite = sprites_geral[ imagem_id ]; }

                //         if( dados.tipo_pegar_sprite == Tipo_pegar_sprite.nada )
                //             { dados.imagem_sprite = null; }

                //         continue;


                // }

                
        }



        private void Colocar_imagens_tipo_botao_com_array( int _loop_1, int _loop_2, Sprite[,] _sprites_matrix, Dados_para_criar_botao_localizador_imagens[,] _dados_localizadores ){

                        // for( int parte_animacao_index = 0 ; parte_animacao_index < _loop_1 ; parte_animacao_index++ ){

                        //         for( int slot_animacao_index = 0, trava_seguranca = 0; slot_animacao_index < _loop_2; trava_seguranca++ ){

                        //                 // --- VERIFICA TRAVA
                        //                 if( trava_seguranca > 100_000_000 )
                        //                     { throw new Exception("ativou trava seguranca loop"); }


                        //                 Dados_para_criar_botao_localizador_imagens localizador = _dados_localizadores[ parte_animacao_index , slot_animacao_index ];

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
                        //                         _sprites_matrix[ parte_animacao_index , novo_slot ] = sprites[ index ];

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



        public void Colocar_imagens_tipo_botao( Dados_botao_dispositivo[] _dados_botoes, string _dispositivo_game_object_path ){


                // if( sprites_especificas == null )
                //     { throw new Exception( "Nao foi dado o Carregar_imagens no modulo imagens dispositivos" ); }

                // if( _dispositivo_game_object_path == null )
                //     { throw new Exception( $"_dispositivo_game_object_path veio null" ); }



                // // --- VERIFICAR SE DADOS FORAM CARREGADOS

                // // ()...



                // for( int botao_index = 0 ; botao_index < _dados_botoes.Length ; botao_index++ ){

                //         Dados_botao_dispositivo dados = _dados_botoes[ botao_index ];

                //         if( dados == null )
                //             { continue; }


                        

                //         dados.material_dispositivo = material_dispositivo;


                //         Sprite[,] sprites_matrix;
                //         Dados_para_criar_botao_localizador_imagens[,] dados_localizadores;

                //         int numero_partes;
                //         int numero_slots;


                //         // --- NORMAL
                //         sprites_matrix = dados.sprites_animacoes_completas;
                //         dados_localizadores = dados.imagens_localizadores;

                //         numero_partes = sprites_matrix.GetLength( 0 );
                //         numero_slots = sprites_matrix.GetLength( 1 );

                //         Colocar_imagens_tipo_botao_com_array( numero_partes, numero_slots, sprites_matrix, dados_localizadores );


                //         // --- VERIFICA SE TEM DECORACAO COMPOSTA
                //         if( dados.sprites_decoracao_composta == null )
                //             { continue; } // --- NAO TEM

                        

                //         // --- DECORACAO COMPOSTA
                //         sprites_matrix = dados.sprites_decoracao_composta;
                //         dados_localizadores = dados.imagens_localizadores_decoracao_composta;

                //         numero_partes = sprites_matrix.GetLength( 0 );
                //         numero_slots = sprites_matrix.GetLength( 1 );


                //         Colocar_imagens_tipo_botao_com_array( numero_partes, numero_slots, sprites_matrix, dados_localizadores );

                //         Debug.Log("veio aqui");


                // }


        }

        




}





