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

        }

        public enum Botoes_localizador {

            botao_1,

        }



        Button[] botoes = new Button[ 3 ];
        public enum Botao {

            botao_fechar,

        }




        // --- METODOS INTERNOS

        public void Update_interno( Dispositivo _dispositivo ){

                // --- CRIAR 
                Debug.Log("a");

        }


        public enum Tipo_ativacao_botao {

                clicar_e_soltar,  
                clicar,
                entrar_no_botao,

        }




        // mudanca imagem 
        // como que e dado o click





        public void Definir_logica_interno( MODULO__imagens_dispositivo imagens ){

                // // --- CRIAR

                // botoes[ 0 ] = logica.Definiar_botao(


                //         _tipo_botao: Tipo_botao.normal
                //         _nome: "nome", 
                //         _update: Update_botao_1;

                //         _tipo_ativacao: Tipo_ativacao_botao

                //         _imagem_1_id:  
                //         _cor_imagem_1: 
                //         _imagem_2_id: 
                //         _cor_imagem_2:

                //         _audio_click:  
                //         _audio_houver: 

                // )

                // // --- BOATAO QUE FECHA

                // Dados_botao_simples dados = new Dados_botao_simples();

                // dados.tipo_botao
                // dados.nome = "";
                // dados.update = Update_botao_1;
                // dados.tipo_ativacao = Tipo_ativacao_botao.clicar_e_soltar;


                //     // --- IMAGEM 1
                //     dados.imagem_1_id = ( int ) Dispositivo_imagem.teste_1;
                //     dados.cor_imagem_1 = Cores.white;

                //     // --- IMAGEM 2 
                //     dados.imagem_2_id = -1;
                //     dados.cor_imagem_2 = Cores.clear;

                //     // --- AUDIO
                //     dados.audio_click: 
                //     dados.audio_houver: 

                // botoes[ ( int ) botao.botao_fechar] = dispositivo.Adicionar_botao( dados );




                // logica.Definir_botao{

                //     _nome: "a", 


                // }

                // imagens.Definir_imagem_estatica(
                //         _nome: "a",
                //         _imagem_id: ( int ) Dispositivo_imagem.teste_1
                // );

                // return;


        }


        public void Definir_objetos( Dispositivo dispositivo ){




                // dispositivo.Definir_botao(


                //         _tipo_botao: Tipo_botao.normal
                //         _nome: "nome", 
                //         _update: Update_botao_1;

                //         _imagem_1_id:  
                //         _cor_imagem_1: 
                //         _imagem_2_id: 
                //         _cor_imagem_2:

                //         _audio_click: 
                //         _audio_houver: 


                // )





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



