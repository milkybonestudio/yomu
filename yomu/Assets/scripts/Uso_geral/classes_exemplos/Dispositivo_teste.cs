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

            teste_1,
            b_1, 
            b_2,
            b_3,

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
                botao_fechar_dados.update_secundario = Update_botao_1;


                    // --- IMAGEM 1
                    botao_fechar_dados.sprite_off_id = ( int ) Dispositivo_imagem.b_1;
                    //botao_fechar_dados.cor_imagem_off = Cores.white;

                    // --- IMAGEM 2 
                    botao_fechar_dados.sprite_on_id = ( int ) Dispositivo_imagem.b_2;
                    //botao_fechar_dados.cor_imagem_on = Cores.white;

                    // --- AUDIO
                    // dados.audio_click: 
                    // dados.audio_houver: 

                botao_fechar = dispositivo.Definir_botao(  botao_fechar_dados );









        }

        public void Update_botao_1(){}

        //mark

        // --- isso nao faz sentido. ao invez de usar disp.Definir_imagem(); disp.Definir_audios();... => disp.Definir_objetos() e dentro ele faz a divisao

        public void Definir_imagens_interno( MODULO__imagens_dispositivo imagens ){

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

        public void Definir_audios_interno( MODULO__audios_dispositivo audios ){ 

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

        public void Definir_audios( MODULO__audios_dispositivo _audios ){ Definir_audios_interno( _audios ); }
        public void Definir_imagens( MODULO__imagens_dispositivo _imagens ){ Definir_imagens_interno( _imagens ); }



        public string Pegar_nome(){ if( nome == "COLOCAR_NOME" ){ throw new System.Exception( "Nao foi alterado o nome do dispositivo" );} return nome;}
        public string[] Pegar_folders() { if( (( folders.Length == 1  ) && folders[ 0 ] == "" ) || ( folders.Length == 0) ){ throw new System.Exception("Nao foi definido os folders na classe criadora do dispositivo");} return folders; }
        public  System.Type Pegar_tipo_imagens(){ return typeof( Dispositivo_imagem );}
        public static byte[] Converter_imagens(){ return Conversor_imagens_dispositivos.Converter(  (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType ) );}


}



