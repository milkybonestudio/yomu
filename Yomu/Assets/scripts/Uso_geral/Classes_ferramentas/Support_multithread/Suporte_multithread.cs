using System;
using UnityEngine;
using Png_decoder;



// *** passar para o visual novel
public class Imagem_dados {


    public Personagem_nome personagem_nome = Personagem_nome.nada;
    public string nome_imagem  =  "clothes@happy@direita";
    public float[] posicao = new float [ 2 ] { 0f , 0f};

    

    public bool tem_animacao_boca = false;
    public Chave_cache animacao_boca_chave;


}



public enum Tipo_pegar_png {

    path, 
    pointer,

}






// public static class Dados_imagens {

//     public static Pegar_dados(){

//     }

// }





// nao faz sentido isso ficar aqui 

// public class Pedido_para_criar_load_png {


//     public Tipo_pegar_png tipo_pegar_png = Tipo_pegar_png.path;

//     public string path = null; 
//     public int p1 = -1;
//     public int p2 = -1;





//     public string nome_png = "png_generico";

//     public Chave_cache _chave;

//     public int prioridade = 0;


// }








public static class Suporte_multithread {


        public static Suporte_multithread_PNG png = new Suporte_multithread_PNG();






        // public static Task_req Criar_task_load_png (  byte[] _png_array , Chave_cache _chave_cache ,string _nome = ""  ) {

        //         int[] dimensoes = PNG.Pegar_width_e_height( _png_array );

        //         int width = dimensoes[ 0 ];
        //         int height = dimensoes[ 1 ];

        //         int total_de_pixels = width * height;

        //         if( total_de_pixels < 200_000  ){ return Lidar_imagem_pequena( _png_array, _chave_cache ,_nome ); }

        //         return Lidar_imagem_grande( width, height , _png_array , _chave_cache, _nome );
                
        // }


        // public static Task_req Lidar_imagem_pequena( byte[] _png_array , Chave_cache  _chave_cache ,  string _nome ){

        //         Task_req Task_retorno = new Task_req( _chave_cache );


        //         return new Task_req(   _chave_cache ,  _nome , Lidar_iniciar, Pegar_lidar_finalizar(  ) );






        // }

                



        public static Task_req Lidar_imagem_grande(  int width , int height , byte[] _png_array, Chave_cache _chave_cache,  string _nome ) {


                    /*
                
                            abandonei a ideia pois leva em torno de 300x para por pixl por pixel com SetPixel.
                            provavelmente por não aceitar Color32 


                            ***** 
                            voltei com a ideia. nao vale a pena ter 1 sprite grande e ficar interado um pouco de cada vez. Mas vale a pena fazer 2+ sprites e só juntar elas depois. 
                            eu posso fazer chunks diferentes. ao inves de ter Color32[] eu tenho Color32[][] a funcao png

                            assim eu posso salvar um asset normal em qualquer tamanho e modificar como ele vai salvar aqui. aparentemente a complexidade de pegar 1 ponto é linear então nao improta 

                            t( 1000 px ) +-= 1000 * t ( 1px ) 

                    
                    */


                    // fn_iniciar tem que chamar essa fucnao quando tiver os pixels

                    //  mudar conforme os testes 











                    
                    int quantidade_se_pixels_maximo = 120_000;

                    int total_de_pixels = ( width * height );

                    // cada height tem que ir do inicio até o final, entao cada pixel em height tem 1 width
                    int quantidade_de_height_por_bloco = (quantidade_se_pixels_maximo / width ) ;  // sempre arredonda para baixo 

                    int quantidade_de_interacoes_necessarias =   ( height / quantidade_de_height_por_bloco ) + 1 ; 
                    
                    // ** o numero de 

                    // garante o caso da png ser exatamente multiplos de 120.000
                    if( quantidade_de_height_por_bloco * width == quantidade_se_pixels_maximo ){ quantidade_de_interacoes_necessarias -= 1 ;}

                    int w_atual = 0 ;
                    int h_atual = 0 ;
                    int quantidade_de_pixels_atuais = 0 ;


                    return null;

                    // return new Task_req(  _nome , Lidar_iniciar, Lidar_finalizar, Pegar_parcial() );


                    // Action<Task_req>[] Pegar_parcial;



                    // return new Task_req( _chave_cache, _nome , Lidar_iniciar,  Lidar_finalizar , null , _chave_cache  );

            }


}




