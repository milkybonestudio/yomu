// using UnityEngine;




// public class Dispositivo__exemplo : INTERFACE__dispositivo {

        
//         // --- CONSTRUTOR
//         public static Dispositivo Construir(){ return CONSTRUCTOR__device.Construct( new Dispositivo_que_nao_pode_ser_instanciado() ); }


//         public string nome = "COLOCAR_NOME";


//         // ** aponta para onde vao estar os folders com as imagens no editor, o nome do container na build e a primeira pasta da lista indica a pasta com o prefab
//         // ** a ultima pasta semre vai ser com o nome do dispositivo
//         public string[] folders = new string[]{

//             "",

//         };

//         public enum Dispositivo_imagem{}


        

//         // --- METODOS INTERNOS

//         public void Update_interno( Dispositivo _dispositivo ){

//                 // --- CRIAR 

//         }


//         public void Definir_imagens_interno( GERENCIADOR__imagens_dispositivo imagens ){

//                 // --- CRIAR

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
//         public void Finalizar_interno( Dispositivo _dispositivo){

//                 // --- CRIAR
                
//                 return;

//         }

//         public void Definir_audios_interno( GERENCIADOR__audios_dispositivo audios ){ 

//                 // --- CRIAR

//                 return; 
                
//         }


//         public void Declare_components( Dispositivo _device ){



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


//         //byte[] bytes = ( new Dispositivo__exemplo() ).Converter_imagens();



//         public string Pegar_nome(){ if( nome == "COLOCAR_NOME" ){ throw new System.Exception( "Nao foi alterado o nome do dispositivo" );} return nome;}
//         public string[] Pegar_folders() { if( (( folders.Length == 1  ) && folders[ 0 ] == "" ) || ( folders.Length == 0) ){ throw new System.Exception("Nao foi definido os folders na classe criadora do dispositivo");} return folders; }
//         public  System.Type Pegar_tipo_imagens(){ return typeof( Dispositivo_imagem );}
        

// }











// /*

//     Protege: 

//         prefab: 
//             - garante que quando for fazer algo no prefab ele precisa estar no jogo
//             - verifica se o prefab existe
//             - verifica se o objeto existe dentro do prefab quando a imagem é colocada

//         Imagens: 
//             - alerta se o folder com as imagens nao for encontrado
//             - se a imagem nao for encontrada no folder 
        
//         Quando for iniciar as imagens: 
//             - Garante que as imagens precisam estar carregadas


// */



