using System;
using UnityEngine;
using UnityEngine.UI;




public class MANAGER__components_device {


        // ** garante que os dados estejam corretos

        public MANAGER__components_device( Dispositivo _dispositivo ){

                dispositivo = _dispositivo;

                const int numero_inicial_de_slots = 5;
                    
                // --- OBJETOS
                imagens_estaticas_dispositivo = new UI_visual_container[ numero_inicial_de_slots ];
                botoes_dispositivo = new UI_button[ numero_inicial_de_slots ];

        }


        public Dispositivo dispositivo;


        public string path_para_o_pai;
        public string path_para_o_dispositivo;


        // --- BOTAO
        public int pointer_atual_botao;

        // ** nao vai funcionar
        public DATA__UI_button[] dados_botoes_dispositivo;
        public UI_button[] botoes_dispositivo;


        // --- IMAGEM ESTATICA
        public int pointer_atual_imagem_estatica;
        public UI_visual_container[] imagens_estaticas_dispositivo;

        // ** dados vao ficar dentro de cada componente
        public DATA__UI_visual_container[] dados_imagens_estaticas_dispositivo;


        public void Load_resources(){

                dispositivo.gerenciador_imagens.Load_resources();
                dispositivo.gerenciador_audios.Carregar_audios();
                dispositivo.ativou_carregar = true;
        }




        // --- DECLARATIONS 
        // ** only store what will have 
        
        public DATA__UI_visual_container Declare_image_container( ref UI_visual_container imagem ){

                imagem = new UI_visual_container();
                imagens_estaticas_dispositivo[ pointer_atual_imagem_estatica++ ] = imagem; 

                if(  imagens_estaticas_dispositivo.Length == pointer_atual_imagem_estatica )
                    { Array.Resize( ref imagens_estaticas_dispositivo, imagens_estaticas_dispositivo.Length + 10 ); }

                return imagem.data;

        }


        public DATA__UI_button Declare_button( ref UI_button button ){

                // //mark  
                // throw new Exception( "nao vai funcionar, agora dados é uma struct, vai voltar uma copia" );


                // button = new UI_button();
                // button.data = new DATA__UI_button();


                // botoes_dispositivo[ pointer_atual_botao++ ] = button; 

                // if(  botoes_dispositivo.Length == pointer_atual_botao )
                //     { Array.Resize( ref botoes_dispositivo, botoes_dispositivo.Length + 10 ); }


                return new DATA__UI_button();

        }





        // --- DEFINITIONS

        public void Define_all_components(){

                
                // --- DEFINE BUTTONS
                for( int button_id = 0 ; button_id < botoes_dispositivo.Length ; button_id++ ){

                        UI_button botao = botoes_dispositivo[ button_id ];
                        if( botao == null  )
                            { break; }

                        botao.Define_button();
                        continue;

                }

                // --- DEFINE IMAGES CONTAINER
                for( int image_container_index = 0 ; image_container_index < imagens_estaticas_dispositivo.Length ; image_container_index++ ){

                        UI_visual_container image_container = imagens_estaticas_dispositivo[ image_container_index ];
                        if( image_container == null  )
                            { break; }

                        Define_image_container( image_container );
                        continue;

                }

        }


        private void Define_image_container( UI_visual_container _imagem ){

            //mark
            // ** tem que refazer todo o formato

        }




        public void Get_data_from_prefab(){

            // ** quando o prefab estiver no world tem que linkar os gameobjects/images de cada UI com os respectivos componentes em jogo

            // --- CRIA IMAGENS ESTATICAS

            for( int imagem_estatica_index = 0 ; imagem_estatica_index < imagens_estaticas_dispositivo.Length ; imagem_estatica_index++ ){

                    if( imagens_estaticas_dispositivo[ imagem_estatica_index ] == null )
                        { continue; }

                     imagens_estaticas_dispositivo[ imagem_estatica_index ].Link_to_game_object( dados_imagens_estaticas_dispositivo[ imagem_estatica_index ], path_para_o_dispositivo );

                    continue;

            }


            // --- CRIA BOTOES

            for( int botao_index = 0 ; botao_index < dados_botoes_dispositivo.Length ; botao_index++ ){

                    //mark
                    // ** naov ai funcionar


                    if( botoes_dispositivo[ botao_index ] == null )
                        { continue; }

                        botoes_dispositivo[ botao_index ].Link_to_game_object( null );

                    continue;

            }

        }





}