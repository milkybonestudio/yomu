



/*


    ** pegar o index de uma figura no scrip construtor
    **preciso de um arquivo que vai ter os dados das imagens 


    //---------------- PERSONAGEM -------------------
    
            ** ( separa cada um )

            Lily: 
     
                                nome : clothes@happy@esquerda 
                  
                                            => base            =>    imagem_nome // path 
                                            => secundaria      =>    iamgem_nome // path : posicao
                                            => animacao_boca   =>  {
                                                                        posicao :  500 , 150 

                                                                        imagem_nome // path    
                                                                        imagem_nome // path  

                                                                    }
                                            => animacao_olhos    => {}
                                            => animacao_completa => {}

    //---------------------------------------------------

            eu preciso criar os arquivos para a versao final : 

                - imagens.dat que tem os pngs que vai ser pesado e pode ter mais de 1 
                - figuras_dados.dat // chunk de dados sao diferentes 
                - figuras_localizador.dat // chucks de dados fixos ** index dos dados = figure_id * ( bytes / figure)


            para a versao de teste no editor é possivel interar sobre o teste e pegar somente as partes que importam. 
            as figuras_dados e figuras_localizador sao um jeito de realiar tudo antes do inicio do frame. mas em teste perder alguns milisegundos nao vai fazer difereça
            ** tem que tomar cuidado porque o jeito para pegar a imagem vai mudar, "imagem_nome" nao vai ser um id que aponta para uma data.dat e 2 pointers. vai ser o path para a imagem dentro da pasta do personagem
            



     
            ao invez de fazer um grande data.dat vale mais a pena fazer varios pequenos
            Lily.data, Ruby.data
            e depois justar tudo 

            ** criar um arquivo que vai ser trocado em cada personagem que vai ter as imagens que ja foram contabilizadas 

            file: localizador_lily.txt: 
                    clothes@happy_and_mad@esquerda

            internamente vai ter uma variavel que pega qual id o personagem comeca. Para pegar o id da imagem verifica se existe: 

            tem =>    imagem_id  =  linha_id  + id_inicial_personagem
            nao tem => colocar imagem_na_lista( index_vazio ) ;  imagem_id = index_vazio + id_inicial_personagem


            


                    

*/










// public static class Pegar_dados_figuras_personagens {


//     public string[] dados_completos = null;

//     public static Pegar_lista_com_dados_internos (){



//     }

//     public static Dados_figura_personagem Pegar_dados( int id_imagem ){

//         if( dados_completos == null  ){ Pegar_lista_com_dados_internos() ; }

//         Dados_imagem_personagem dados_retorno 

//         string dados = 



//     }

// }









// public class Controlador_cache_imagem_visual_novel {


//     public int[] imagens_ids;
//     public Chave_cache[] imagens_chaves;

//     public Verificar_se_imagem_esta_carregada( int id ){

//     }

//     public Pegar_imagem( int id ){

//         // se nao tem em cache iniciar a de baixa resolucao 



//     }



// }









