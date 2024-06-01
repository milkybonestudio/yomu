// using System;



// // isso tem que estar no geral. 
// public class Personagem {

//       // --------------- DATA --------------------
      
   
//       public Ponto ponto_atual;    
   
//       public Conversa[] conversas; 
//       public Quest[] quests;   
//       public Plot[] plots;
      
      
   
//       // -------------- METODOS -----------------

   
      
//       // no mes o foco vai ser diminuir a influencia de atos passados caso tenha algum
//       // se alguem morreu => a tendencia é ficar mais deprimido
//       // cada mes esse valor reduz em 20%
//       public Action<Personagem> Verificar_mudancas_variaveis_internas_mes;
      
//       // ** esse vai ser o unico que é obrigatorio para todos
//       // o dia vai fazer o estado atual do personagem voltar a um estado de equilibrio
//       // pode também mudar lentamente o estado de equilibrio
//       public Action<Personagem> Verificar_mudancas_variaveis_internas_dia;
      
//       // Pode alterar o humor dependendo do que o personagem esta fazendo 
//       public Action<Personagem> Verificar_mudancas_variaveis_internas_periodo;
      

//       // ---- atualizado cada dia 
//       // ----------------------------

//       //  isso teria 3 funcoes
//  		//	  conversa :   "falar mal de pessoas que usam rosa" => 3 dias depois : "eu estava pensando... se eu usasse rosa voce não iria gostar de mim?" 
//       //   plot     :   "quer convidar ele para a cacheira caso a intimidade passe de 700" => precisa de 3 relacoes de intimidade primeiro 
//       //   quest    :   "vai pedir para o player ajudar ela a matar um cavalo que matou o canario dela" => precisa ter 500g para pagar pelo transporte 
   
//       public Action<Personagem> Verificar_assuntos_internos;
//       public Action<Personagem> Verificar_assuntos_internos;


    
    
// }







// // enums que vao ser somente dessa dll 

// public enum Tipo_movimento_PERSONAGEM {
    
//     DEFAULT, 
//     tipo_1,
    
// }

// public enum Acontecimentos {

//    Lily_comeu_cookie_da_DIA_dia_250,
   
// }
    
    

// // tem que ser static porque ela vai somente passar os metodos

// public static class Construtor_PERSONAGEM {

//      // essa classe pode ter dados especificos do personagem. por exemplo: 
//      public static string Lily_pet_nome;
//      // os metodos da classe vão ter acesso a essas variaveis
//      // quando o metodo Construir for chamado ele vai colocar o nome do pet que pode mudar dependendo do save

//     public static string teste_dados_str = "";

//     public static void Colocar_dados( Personagem _PERSONAGEM , string _dados  ){
        
//         // os dados vão ser pegos aqui dentro 
//             // ** talvez Controlador_personagens possa ter o metodo que pega de todos os personagens e pode ser por container?
                
//             string path_folder = Controlador_personagens.Pegar_path_dados( "Lily" );            
//             // esses dados vao ser ter quais funcoes colocar em cada slot e dados referentes a suporte de sistema. 
//             // por exemplo, dados de como que o player se comporta com esse personagem.
//             // uma coisa importante é que aqui vai estar escrito se o personagem foi iniciado 
//             string path_dados_de_sistema = path_folder + "PERSONAGEM_dados_gerais.dat";
            
//             // esses dados vao ter dados da mentalidade do personagem e dados psicologicos referentes a outros personagens. 
//             // esse container vai ser generico em formato. Todo personagem vai ter um.
//             string path_dados_psique = path_folder + "PERSONAGEM_dados_gerais.dat";
            
//             // dados gerais vão ser o foco para fazer a logica. a mais importante vai ser os bools para 
//             // mostrar se algo aconteceu
//             string path_dados_gerais_string = path_folder + "PERSONAGEM_dados_gerais.dat";
//             string path_dados_gerais_int = path_folder + "PERSONAGEM_dados_gerais.dat";
//             string path_dados_gerais_bool = path_folder + "PERSONAGEM_dados_gerais.dat";

//             string path_dados_ = path_folder + "PERSONAGEM_dados_gerais.dat";



            
//         string dados_personagem = null;
            

        
                
        

// //  string :

// //               1       0       0
// //            tipo_mov  
// // _dados vai ser igual para todos os personagens 

//             int numero_de_elementos = NUMERO;
//             char[] dados_char_arr = new char[ numero_de_elementos ];

//             int numero_de_info_compacta = NUMERO_COMPACTA;

//             for( int index_dados_char = 0 ;  index_dados_char < numero_de_info_compacta ; index_dados_char++ ){

                    
                
//             }

            
            
//             byte[] todos_os_bytes = Pegar_bytes();
//             info = todos_os_bytes[ dados.id ];

//             bool[] bool_arr = Pegar_bool_por_byte();

            

        
//     }


//     public enum Dados {

       
//         lily_pegou_a_trompa, // 0 
//         lily_pegou_o_carro, // 1  
//         id = 33, 
        
        
//     }

//     // isso nao faz sentido porque se jogar junto com o asm vai ficar grande do mesmo jeito
//     public bool[] Pegar_bool_por_byte( byte _byte ){


//             bool[] bool_arr_return = new bool[ 8 ];
//             for( int i = 0 ; i < 8 ; i++ ){
                
//                    bool_arr_return[ i ]  = ( ( ( _byte >> i ) & 1 ) == 1 );
                    
//             }

                
//     }

  
// }
