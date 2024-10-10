using UnityEngine;
using UnityEngine.UI;



public class Dispositivo__teste : INTERFACE__dispositivo {

        
        // --- CONSTRUTOR
        public static Dispositivo Construir(){ return CONSTRUCTOR__device.Construct( new Dispositivo__teste() ); }

        public string name = "quadrado";

        // ** aponta para onde vao estar os folders com as imagens no editor, o nome do container na build e a primeira pasta da lista indica a pasta com o prefab
        // ** a ultima pasta semre vai ser com o nome do dispositivo

        public string Get_main_folder(){ return "shapes\\quadrado"; }

   
    

        // --- METODOS INTERNOS

        public void Update_interno( Dispositivo _dispositivo ){

                botao_fechar.Update();

        }



    
        public Botao_dispositivo botao_fechar;
        public Botao_dispositivo botao_novo;
        public Imagem_estatica_dispositivo img;


        public void Declare_components( Dispositivo dispositivo ){


                // --- ESTATICA

                
                Dados_imagem_estatica_dispositivo dados_img =  dispositivo.Declare_image( ref img );

                dados_img.imagem_id = -1;
                dados_img.nome = "aa";

                string default_folder = "t\\";

                // --- define 
                Dados_botao_dispositivo botao_fechar_dados_novo = dispositivo.Declare_button( ref botao_novo );
                    {

                        botao_fechar_dados_novo.tipo_ativacao = Botao_dispositivo_tipo_ativacao.clicar;
                        botao_fechar_dados_novo.nome = "a";
                        botao_fechar_dados_novo.Update_secundario = Update_botao_1;




                            // --- IMAGEM 1
                            botao_fechar_dados_novo.off.animacao_base.image_path = default_folder + "path";
                            botao_fechar_dados_novo.off.animacao_base.cor = Cores.red;

                            
                            botao_fechar_dados_novo.off.texto = "OFF";

                            //botao_fechar_dados_novo.off.animacao_base_cor = Cores.cor_clear_dispositivo;
                            botao_fechar_dados_novo.on.animacao_base.image_path = default_folder + "path_2";
                            botao_fechar_dados_novo.on.animacao_base.cor = Cores.white;
                            

                            botao_fechar_dados_novo.on.texto = "ON";



                            TOOL__button_device_composed_decoration.Create_simple  (
                                                                                        _dados: botao_fechar_dados_novo,
                                                                                        _paths:   new  string[] {
                                                                                                                    "teste"
                                                                                                                },
                                                                                        _cor_off : Cores.grey_80,
                                                                                        _cor_on: Cores.white

                                                                                    );


                    }



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



        public string Get_name(){ if( name == "COLOCAR_NOME" ){ throw new System.Exception( "Nao foi alterado o nome do dispositivo" );} return name;}

        
}



