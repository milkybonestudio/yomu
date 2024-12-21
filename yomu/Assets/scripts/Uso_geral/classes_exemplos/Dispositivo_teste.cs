// using UnityEngine;
// using UnityEngine.UI;



// public class Dispositivo__teste : INTERFACE__dispositivo {

        
//         // --- CONSTRUTOR
//         public static Dispositivo Construir(){ return CONSTRUCTOR__device.Construct( new Dispositivo__teste() ); }

//         public string name = "quadrado";

//         // ** aponta para onde vao estar os folders com as imagens no editor, o nome do container na build e a primeira pasta da lista indica a pasta com o prefab
//         // ** a ultima pasta semre vai ser com o nome do dispositivo


//         public string Get_main_folder(){ return "shapes/quadrado"; }

   
//         // --- METODOS INTERNOS

//         public void Update_interno( Dispositivo _dispositivo ){

//                 botao_fechar.Update();

//         }


//         public UI_button botao_fechar;
//         public UI_button botao_novo;
//         public UI_visual_container img;



//         // ** fala os que vai precisar 
//         public void Declare_components( Dispositivo dispositivo ){

//                 // --- ESTATICA

//                 // ** declare                
//                 DATA__UI_visual_container dados_img = dispositivo.Declare_image( ref img );

//                 // ** put data
//                 dados_img.imagem_id = -1;
//                 dados_img.nome = "aa";

//                 string default_folder = ( Resource_context.Devices.ToString() + "/" + Get_main_folder() + "/");



//                 // --- define 
//                 //mark
//                 // ** nao vai funcionar
//                 DATA__UI_button botao_fechar_dados_novo = dispositivo.Declare_button( ref botao_novo );
//                     {

//                         botao_fechar_dados_novo.tipo_ativacao = UI_button_activation_type.clicar;
//                         botao_fechar_dados_novo.Update_secundario = Update_botao_1;


//                             // --- IMAGEM 1
//                             botao_fechar_dados_novo.off.animacao_base.image_path = default_folder + "path";
//                             botao_fechar_dados_novo.off.animacao_base.cor = Cores.red;

                            
//                             botao_fechar_dados_novo.off.texto = "OFF";

//                             //botao_fechar_dados_novo.off.animacao_base_cor = Cores.cor_clear_dispositivo;
//                             botao_fechar_dados_novo.on.animacao_base.image_path = default_folder + "path_2";
//                             botao_fechar_dados_novo.on.animacao_base.cor = Cores.white;
                            

//                             botao_fechar_dados_novo.on.texto = "ON";



//                     }



//         }

//         public void Update_botao_1(){}



//         public void Definir_imagens_interno( GERENCIADOR__imagens_dispositivo imagens ){

//                 // --- CRIAR

//                 // imagens.Definir_imagem_estatica(
//                 //         _nome: "a",
//                 //         _imagem_id: ( int ) Dispositivo_imagem.teste_1
//                 // );

//                 return;


//         }

      
//         public System.Object Enviar_dados_interno( Dispositivo _dispositivo ){ 

//                 // --- CRIAR

//                 return null; 
//         }

//         public void Receber_dados_interno( Dispositivo _dispositivo , System.Object _dados ){ 

//                 // --- CRIAR

//                 return; 

//         }

//         public void Active_method( Dispositivo _dispositivo , string _method, System.Object _args ){


//                 switch( _method ){

//                     case "Activate_happy": Activate_happy(); break;

//                 }

//         }

//         private void Activate_happy(){

//             // ** do stuff

//         }


//         public void Finalizar_interno( Dispositivo _dispositivo){

//                 // --- CRIAR
                
//                 return;

//         }

//         public void Definir_audios_interno( GERENCIADOR__audios_dispositivo audios ){ 

//                 // --- CRIAR

//                 return; 
                
//         }



//         // --- NAO MUDAR ------
//         // --------------------


//         // --- METODOS QUE VAO SER EXPORTADOS

//         public void Update( Dispositivo _dispositivo ){ Update_interno( _dispositivo ); }

//         public System.Object Enviar_dados( Dispositivo _dispositivo ){ return Enviar_dados_interno( _dispositivo ); }
//         public void Receber_dados( Dispositivo _dispositivo, System.Object _dados ){ Receber_dados_interno( _dispositivo, _dados ); }

//         public void Finalizar( Dispositivo _dispositivo){ Finalizar_interno( _dispositivo ); }

//         public void Definir_audios( GERENCIADOR__audios_dispositivo _audios ){ Definir_audios_interno( _audios ); }
//         public void Definir_imagens( GERENCIADOR__imagens_dispositivo _imagens ){ Definir_imagens_interno( _imagens ); }



//         public string Get_name(){ if( name == "COLOCAR_NOME" ){ throw new System.Exception( "Nao foi alterado o nome do dispositivo" );} return name;}

        
// }



