using System;
using UnityEngine;
using UnityEngine.UI;



public struct Dados_para_criar_botao_localizador_imagens {

        //mark
        // ** length ainda era usado para pegar as imagens de uma sequencia, isso parece ser bom para deixar mas tem que pensar em um jeito para fazer.
        // ** talvez deixar a struct como string path, int length

        

        public int sprite_id;
        public object sprite_id_geral;
        public int length; // ** imagens gerais => 0 == id de sequencia, nunca pode iniciar a busca em 0
        // public Tipo_pegar_sprite tipo_pegar_sprite;


}



public class GERENCIADOR__dados_dispositivo {


        // ** garante que os dados estejam corretos

        public GERENCIADOR__dados_dispositivo( Dispositivo _dispositivo ){

                dispositivo = _dispositivo;

                const int numero_inicial_de_slots = 5;
                    
                // --- DADOS
                dados_imagens_estaticas_dispositivo = new Dados_imagem_estatica_dispositivo[ numero_inicial_de_slots ];
                dados_botoes_dispositivo = new Dados_botao_dispositivo[ numero_inicial_de_slots ];

                // --- OBJETOS
                imagens_estaticas_dispositivo = new Imagem_estatica_dispositivo[ numero_inicial_de_slots ];
                botoes_dispositivo = new Botao_dispositivo[ numero_inicial_de_slots ];

        }


        public Dispositivo dispositivo;


        public string path_para_o_pai;
        public string path_para_o_dispositivo;


        // --- BOTAO
        public int pointer_atual_botao;
        public Dados_botao_dispositivo[] dados_botoes_dispositivo;
        public Botao_dispositivo[] botoes_dispositivo;


        // --- IMAGEM ESTATICA
        public int pointer_atual_imagem_estatica;
        public Imagem_estatica_dispositivo[] imagens_estaticas_dispositivo;

        // ** dados vao ficar dentro de cada componente
        public Dados_imagem_estatica_dispositivo[] dados_imagens_estaticas_dispositivo;


        public void Load_resources(){

                dispositivo.gerenciador_imagens.Load_resources();
                dispositivo.gerenciador_audios.Carregar_audios();
                dispositivo.ativou_carregar = true;
        }




        // --- DECLARATIONS 
        // ** only store what will have 
        
        public Dados_imagem_estatica_dispositivo Declare_image_container( ref Imagem_estatica_dispositivo imagem ){

                imagem = new Imagem_estatica_dispositivo( new Dados_imagem_estatica_dispositivo() );
                imagens_estaticas_dispositivo[ pointer_atual_imagem_estatica++ ] = imagem; 

                if(  imagens_estaticas_dispositivo.Length == pointer_atual_imagem_estatica )
                    { Array.Resize( ref imagens_estaticas_dispositivo, imagens_estaticas_dispositivo.Length + 10 ); }

                return imagem.data;

        }


        
        public Dados_botao_dispositivo Declare_button( ref Botao_dispositivo button ){

                button = new Botao_dispositivo( new Dados_botao_dispositivo() );
                botoes_dispositivo[ pointer_atual_botao++ ] = button; 

                if(  botoes_dispositivo.Length == pointer_atual_botao )
                    { Array.Resize( ref botoes_dispositivo, botoes_dispositivo.Length + 10 ); }

                return button.data;

        }





        // --- DEFINITIONS

        public void Define_all_components(){

                
                // --- DEFINE BUTTONS
                for( int button_id = 0 ; button_id < botoes_dispositivo.Length ; button_id++ ){

                        Botao_dispositivo botao = botoes_dispositivo[ button_id ];
                        if( botao == null  )
                            { break; }

                        Define_button( botao );
                        continue;

                }

                // --- DEFINE IMAGES CONTAINER
                for( int image_container_index = 0 ; image_container_index < imagens_estaticas_dispositivo.Length ; image_container_index++ ){

                        Imagem_estatica_dispositivo image_container = imagens_estaticas_dispositivo[ image_container_index ];
                        if( image_container == null  )
                            { break; }

                        Define_image_container( image_container );
                        continue;

                }

        }


        private void Define_image_container( Imagem_estatica_dispositivo _imagem ){

            //mark
            // ** tem que refazer todo o formato

        }

        private void Define_button( Botao_dispositivo _botao ){


                Dados_botao_dispositivo dados_botao = _botao.data;

                // --- VERIFICACOES
                TOOL__device_UI_SUPPORT.Verificar_nome( dispositivo.nome_dispositivo, dados_botao.nome );

                string indentificador = null; // ??
                string nome_default = ( dispositivo.nome_dispositivo + "_BOTAO_" + dados_botao.nome );

                // --- CREATE DATA
                if( dados_botao.animacao_botao == null )
                    { TOOL__devices_data_BUTTON.Construir_botao_simples( dispositivo,  dados_botao, _botao, nome_default ); } // --- BOTAO SIMPLES
                    else
                    { TOOL__devices_data_BUTTON.Construir_botao_completo( dispositivo,  dados_botao, _botao, nome_default ); } // --- BOTAO COMPLEXO

                return;                    

        }



        public void Get_data_from_prefab(){

            // ** quando o prefab estiver no world tem que linkar os gameobjects/images de cada UI com os respectivos componentes em jogo

            // --- CRIA IMAGENS ESTATICAS

            for( int imagem_estatica_index = 0 ; imagem_estatica_index < dados_imagens_estaticas_dispositivo.Length ; imagem_estatica_index++ ){

                    if( dados_imagens_estaticas_dispositivo[ imagem_estatica_index ] == null )
                        { continue; }

                     imagens_estaticas_dispositivo[ imagem_estatica_index ].Get_data_from_prefab( dados_imagens_estaticas_dispositivo[ imagem_estatica_index ], path_para_o_dispositivo );

                    continue;

            }


            // --- CRIA BOTOES

            for( int botao_index = 0 ; botao_index < dados_botoes_dispositivo.Length ; botao_index++ ){


                    if( dados_botoes_dispositivo[ botao_index ] == null )
                        { continue; }

                     botoes_dispositivo[ botao_index ].Get_data_from_prefab( path_para_o_dispositivo );

                    continue;

            }

        }





}