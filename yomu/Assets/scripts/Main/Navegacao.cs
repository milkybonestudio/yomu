using UnityEngine ;
using System;


/*

como situacao é muito especifico vou descartar a ideia, se tiver um cenario que é muito diferente vai ser considerado um outro cenario, e o interativo que normalmente iria par p1 vai ir para p2 por um script de entrada;




*/


// public class Navegador{

//     public static Navegador instancia;
//     public static Navegador Pegar_instancia(){
        
//         if(intancia ==null) intancia = new Navegador();
//         return instancia;

//     }

   


//     public void Pegar_proximo_ponto(  Ponto_navegador p_1_navegacao, Ponto_mapa p_2_mapa ){









// }







//     }




//     public static class Pontos_localizadores{



//                   //    pega o ponto final


//         public static Ponto Pegar(  int[] _pontos ){

//             int ponto_mapa = _pontos[0];
//             int tempo = _pontos[1];


//             Ponto ponto = new Ponto(ponto_mapa , tempo);

//             ponto.interativos = Pegar_interativos(ponto_mapa, tempo);





//             return ponto;

//         }

//         public static Pegar_interativos(int _ponto_mapa, int _tempo){

            

//         }







//     }

//     public class Ponto{

//         public Ponto(int _ponto_mapa, int _tempo){
            
//              this.ponto_mapa = _ponto_mapa;
//              this.tempo = _tempo;

//         }

//         public int ponto_mapa;
//         public int tempo;

//         public Interativo[] interativos_em_cena;
//         public string path_bakcground;
//         public string audio_path = "";

//         public int script_ativacao_imediata = -1;


//     }



    

//     public int[] Calcular_interativos_finais(int[] _default, int[] _subtrair , int[] _acrescentar){
            
//             int default_length = _default != null?_default.Length:0;

//             int subtrair_length = _subtrair != null ?   _subtrair.Length : 0;
//             int acrescentar_length = _acrescentar != null ?   _acrescentar.Length : 0;

//             int max_arr_length = default_length + acrescentar_length;

//             int[] max_arr = new int[default_length + acrescentar_length];

//                                 //   nao tem mais
//             int[] retorno = new int[maximo_interativos_arr];
            
//             int j = 0; 
//             int i , k ;


//             for( i = 0; i< default_length ;i++ ){
//                 for( k = 0;  k<acrescentar_length ;k++){if(_acrescentar[k] == _default[i]) max_arr[k] = -1;}
//             }  
//             for(i = 0, j = 0; i < acrescentar_length ;i++){if(max_arr[i] != -1)  {max_arr[j] = _acrescentar[i]; j++;}}

//             for(i = 0  ; i< default_length ;i++, j++){ max_arr[j] = _default[i];}

//             for(  i = 0; i < max_arr_length ;i++){
//             for( j = 0; j<subtrair_length ;j++){if(_subtrair[j] == max_arr[i])  max_arr[i] = 0;}
//                 }

//             for(  i = 0 , k = 0  ;  i<max_arr_length ;  i++){ if(max_arr[i] != 0) {retorno[k] = max_arr[i]; k++;}}

//             return retorno;
      
//   }







    // public class Ponto_mapa{


        
    //     public Ponto[][] pontos_possibilidades = new Ponto[1][5];
        

    //     pontos_possibilidades[0][0] = new Ponto();





    //     public Pegar_ponto(int _situacao, int periodo){
             



    //     }






    // }

    // public static class Lista_navegador{

    //     public static Ponto[][] Lista;

    //     public static Ponto[] Pegar_lista(int bloco){

    //         if(Lista[bloco] == null) Carregar_lista(bloco);
    //         return Lista[bloco];

    //     }


    //     public static Carregar_lista(int bloco){

    //             switch(bloco){
                       
    //                    case 0:  Carregar_0 ();   break;
    //                    case 1:  Carregar_1 ();   break;
    //                    case 2:  Carregar_2 ();   break;

    //             }

    //             return;
            
    //     }


    //     public static void Carregar_0(){

    //         []
            

    //     }

    // }
