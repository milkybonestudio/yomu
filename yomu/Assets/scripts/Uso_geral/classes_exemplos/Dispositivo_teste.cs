using UnityEngine;
using UnityEngine.UI;



public class Dispositivo__teste : INTERFACE__dispositivo {

        
        // --- CONSTRUTOR
        public static Dispositivo Construir(){ return new Dispositivo( new Dispositivo__teste() ); }

        public string nome = "quadrado";

        // ** aponta para onde vao estar os folders com as imagens no editor, o nome do container na build e a primeira pasta da lista indica a pasta com o prefab
        // ** a ultima pasta semre vai ser com o nome do dispositivo
        public string[] folders = new string[]{
            "teste",
        };

        public enum Dispositivo_imagem{

            nada, // deixa invisivel

            teste_1,

            b_1, 
            b_2,
            b_3,
            b_4,
            b_5,

            aq_1 ,
            aq_2 ,
            aq_3 ,
            aq_4 ,
            aq_5 ,
            aq_6 ,

            lb_1 ,
            lb_2 ,
            lb_3 ,
            lb_4 ,
            lb_5 ,
            lb_6 ,

            r_1 ,
            r_2 ,
            r_3 ,
            r_4 ,
            r_5 ,
            r_6 ,

            y_1 ,
            y_2 ,
            y_3 ,
            y_4 ,
            y_5 ,
            y_6 ,

            v_1 ,
            v_2 ,
            v_3 ,
            v_4 ,
            v_5 ,
            v_6 ,

            
            t_1 ,
            t_2 ,
            t_3 ,
            t_4 ,
            t_5 ,
            t_6 ,
            t_7 ,


            ani_1 ,
            ani_2 ,
            ani_3 ,
            ani_4 ,
            ani_5 ,
            ani_6 ,
            ani_7 ,

            an_2_1 ,
            an_2_2 ,
            an_2_3 ,
            an_2_4 ,
            an_2_5 ,
            an_2_6 ,
            an_2_7 ,

            dec_1,
            dec_2,
            dec_3,






        }



        // --- METODOS INTERNOS

        public void Update_interno( Dispositivo _dispositivo ){

                botao_fechar.Update();

                // --- CRIAR 
                // Debug.Log( Input.mousePosition.x );
                // Debug.Log( Input.mousePosition.y );
                // Debug.Log( $"X botao: { botao_fechar.botao_game_object.transform.position.x }" );
                // Debug.Log( $"Y botao: { botao_fechar.botao_game_object.transform.position.y }" );

                // Debug.Log(  botao_fechar.ON_collider.points[ 0 ]);
                // Debug.Log(  botao_fechar.ON_collider.points[ 1 ]);
                // Debug.Log(  botao_fechar.ON_collider.points[ 2 ]);
                // Debug.Log(  botao_fechar.ON_collider.points[ 3 ]);

                // Debug.Log( Verificar_colisao_vec2(botao_fechar.ON_collider.points, ( Vector2 ) botao_fechar.ON_game_object.transform.position, Controlador_input.posicao_mouse) );
                // Debug.Log("--------------------------------");
                

        }



    
        public Botao_dispositivo botao_fechar;


        public void Definir_objetos_iniciais( Dispositivo dispositivo ){


                // --- ESTATICA

                Dados_imagem_estatica_dispositivo dados_teste = new Dados_imagem_estatica_dispositivo();

                dados_teste.imagem_id = ( int ) Dispositivo_imagem.teste_1;
                dados_teste.nome = "aa";

                Imagem_estatica_dispositivo img =  dispositivo.Definir_imagem_estatica( dados_teste );




                // --- BOATAO QUE FECHA

                Dados_botao_dispositivo botao_fechar_dados = new Dados_botao_dispositivo();

                botao_fechar_dados.tipo_ativacao = Botao_dispositivo_tipo_ativacao.clicar;
                botao_fechar_dados.nome = "a";
                botao_fechar_dados.Update_secundario = Update_botao_1;




                    // --- IMAGEM 1
                    botao_fechar_dados.off.animacao_base.sprite_id = ( int ) Dispositivo_imagem.b_1;
                    botao_fechar_dados.off.animacao_base.cor = Cores.red;
                    //botao_fechar_dados.off.animacao_decoracao.cor = Cores.red;
                    botao_fechar_dados.off.texto = "OFF";

                    //botao_fechar_dados.off.animacao_base_cor = Cores.cor_clear_dispositivo;
                    botao_fechar_dados.on.animacao_base.sprite_id = ( int ) Dispositivo_imagem.v_1;
                    botao_fechar_dados.on.animacao_base.cor = Cores.white;
                    // botao_fechar_dados.on.animacao_decoracao.cor = Cores.red;
                    botao_fechar_dados.on.texto = "ON";



                    Botao_dispositivo_CRIAR_DADOS.Criar_decoracao_composta_simples  (
                                                                                        _dados: botao_fechar_dados,
                                                                                        _ids: new int[] {
                                                                                                            ( int ) Dispositivo_imagem.an_2_1
                                                                                                        },
                                                                                        _cor_off : Cores.grey_80,
                                                                                        _cor_on: Cores.white

                                                                                    );


                    
                    

                    // botao_fechar_dados.tipo_transicao_transicao_OFF_para_ON = Tipo_transicao_botao_OFF_ON_dispositivo.cor;
                    // botao_fechar_dados.tipo_transicao_transicao_ON_para_OFF = Tipo_transicao_botao_OFF_ON_dispositivo.animacao_individual;

                    // botao_fechar_dados.animar_atras_texto_animacao_OFF = true;
                    // botao_fechar_dados.animar_atras_texto_animacao_ON = true;

                    // botao_fechar_dados.animar_atras_texto_transicao_OFF_para_ON = true;
                    // botao_fechar_dados.animar_atras_texto_transicao_ON_para_OFF = true;




                    // botao_fechar_dados.sprites_ids_transicao_OFF_para_ON = new int[]{


                    //         ( int ) Dispositivo_imagem.t_1,
                    //         ( int ) Dispositivo_imagem.t_2,
                    //         ( int ) Dispositivo_imagem.t_3,
                    //         ( int ) Dispositivo_imagem.t_4,
                    //         ( int ) Dispositivo_imagem.t_5,
                    //         ( int ) Dispositivo_imagem.t_6
                            

                    // };




                    // botao_fechar_dados.sprite_id_inicial_transicao_OFF_para_ON = ( int ) Dispositivo_imagem.t_1;
                    // botao_fechar_dados.sprite_id_final_transicao_OFF_para_ON   = ( int ) Dispositivo_imagem.t_6;


                    // botao_fechar_dados.sprite_id_inicial_transicao_ON_para_OFF = ( int ) Dispositivo_imagem.t_1;
                    // botao_fechar_dados.sprite_id_final_transicao_ON_para_OFF   = ( int ) Dispositivo_imagem.t_6;




                    
                    // ( ( int ) Dispositivo_imagem.t_1, ( int ) Dispositivo_imagem.t_6 );




                    // botao_fechar_dados.sprites_ids_transicao_ON_para_OFF = new int[]{


                            
                    //         ( int ) Dispositivo_imagem.t_6,
                    //         ( int ) Dispositivo_imagem.t_5,
                    //         ( int ) Dispositivo_imagem.t_4,
                    //         ( int ) Dispositivo_imagem.t_3,
                    //         ( int ) Dispositivo_imagem.t_2,
                    //         ( int ) Dispositivo_imagem.t_1
                    // };



                    // botao_fechar_dados.manter_primeira_sprite_da_animacao_OFF_aparente = true;
                    // botao_fechar_dados.sprites_ids_animacao_off = new int[]{

                    //         ( int ) Dispositivo_imagem.ani_1,
                    //         ( int ) Dispositivo_imagem.ani_2,
                    //         ( int ) Dispositivo_imagem.ani_3,
                    //         ( int ) Dispositivo_imagem.ani_4,
                    //         ( int ) Dispositivo_imagem.ani_5,
                    //         ( int ) Dispositivo_imagem.ani_6,
                    //         ( int ) Dispositivo_imagem.ani_7,

                        
                    // };


                    // botao_fechar_dados.sprites_ids_animacao_on = new int[]{

                    //         ( int ) Dispositivo_imagem.an_2_1,
                    //         ( int ) Dispositivo_imagem.an_2_2,
                    //         ( int ) Dispositivo_imagem.an_2_3,
                    //         ( int ) Dispositivo_imagem.an_2_4,
                    //         ( int ) Dispositivo_imagem.an_2_5,
                    //         ( int ) Dispositivo_imagem.an_2_6,
                    //         ( int ) Dispositivo_imagem.an_2_7,
                        
                    // };


                    // botao_fechar_dados.cores_animacao_imagem_off = new Color[]{

                    //         Cores.red,
                    //         Cores.red,
                    //         Cores.red,
                    //         Cores.red,
                    //         Cores.red
                        
                    // };


                    // --- IMAGEM 2 
                    //botao_fechar_dados.sprite_on_id = ( int ) Dispositivo_imagem.r_1;
                    

                    // --- AUDIO
                    // dados.audio_click: 
                    // dados.audio_houver: 

                botao_fechar = dispositivo.Definir_botao(  botao_fechar_dados );









        }

        public void Update_botao_1(){}

        //mark

        // --- isso nao faz sentido. ao invez de usar disp.Definir_imagem(); disp.Definir_audios();... => disp.Definir_objetos() e dentro ele faz a divisao

        public void Definir_imagens_interno( GERENCIADOR__imagens_dispositivo imagens ){

                // --- CRIAR

                // imagens.Definir_imagem_estatica(
                //         _nome: "a",
                //         _imagem_id: ( int ) Dispositivo_imagem.teste_1
                // );

                return;


        }

      
        public System.Object Enviar_dados_interno( Dispositivo _dispositivo ){ 

                // --- CRIAR

                return null; 
        }

        public void Receber_dados_interno( Dispositivo _dispositivo , System.Object _dados ){ 

                // --- CRIAR

                return; 

        }
        public void Finalizar_interno( Dispositivo _dispositivo){

                // --- CRIAR
                
                return;

        }

        public void Definir_audios_interno( GERENCIADOR__audios_dispositivo audios ){ 

                // --- CRIAR

                return; 
                
        }




        // --- NAO MUDAR ------
        // --------------------


        // --- METODOS QUE VAO SER EXPORTADOS

        public void Update( Dispositivo _dispositivo ){ Update_interno( _dispositivo ); }

        public System.Object Enviar_dados( Dispositivo _dispositivo ){ return Enviar_dados_interno( _dispositivo ); }
        public void Receber_dados( Dispositivo _dispositivo, System.Object _dados ){ Receber_dados_interno( _dispositivo, _dados ); }
        public void Finalizar( Dispositivo _dispositivo){ Finalizar_interno( _dispositivo ); }

        public void Definir_audios( GERENCIADOR__audios_dispositivo _audios ){ Definir_audios_interno( _audios ); }
        public void Definir_imagens( GERENCIADOR__imagens_dispositivo _imagens ){ Definir_imagens_interno( _imagens ); }



        public string Pegar_nome(){ if( nome == "COLOCAR_NOME" ){ throw new System.Exception( "Nao foi alterado o nome do dispositivo" );} return nome;}
        public string[] Pegar_folders() { if( (( folders.Length == 1  ) && folders[ 0 ] == "" ) || ( folders.Length == 0) ){ throw new System.Exception("Nao foi definido os folders na classe criadora do dispositivo");} return folders; }
        public  System.Type Pegar_tipo_imagens(){ return typeof( Dispositivo_imagem );}
        public static byte[] Converter_imagens(){ return Conversor_imagens_dispositivos.Converter(  (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType ) );}


}



