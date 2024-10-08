using UnityEngine;
using System;


/*


logica : sempre que for chamado no editor é formato de teste



*/


public static class Leitor_figures {



    public static byte[] figures_dados;
    public static byte[] figures_localizador;

    public static byte caracter_de_separacao_figures_dados =  ( byte ) '|';
    public static byte caracter_de_separacao_dados_individuais =  ( byte ) '|';



    //  so vai ser usado no editor;
    public static string[][] personagens_figures_raw_data;
    public static string[] personagens_figures_em_raw;
    public static string texto_separando_figures_no_raw = "**";


        public static Dados_figure_personagem Pegar_figure_dados_raw ( string _nome_figure , string _personagem   ){

            return null;

        
                // nao é para ser chamado fora do editor
                // a diferença de Pegar_figure_dados_raw para Pegar_figure_dados é que aqui vai pegar os dados com os paths das imagens ao invez de ids
                // os paths vao apontar diretor para as imagens.png 
                // isso é somente usado para quando eu quero fazer testes mudando imagens sem ter que refazer todo os containers.dat

                if( !( Application.isEditor ) ) { throw new Exception("veio em Pegar_dados_figure_paths() estando fora do editor"); }



            // bloco garante que inicie e que tenha slots para o personagem
            // personagens_figures_em_raw e personagens_figures_raw_data sempre vao ficar na memeoria, pois a ideia é que isso seja usado
            // somente para testes. então não vai ocupar muita memoria.
                if( personagens_figures_raw_data == null ) { 

                    personagens_figures_raw_data = new string[ 20 ][];
                    personagens_figures_em_raw = new string[ 20 ];

                }

                int index_personagem = STRING.Pegar_index_valor(  personagens_figures_em_raw , _personagem );

                if( index_personagem == -1  ){

                        int index_livre = STRING.Pegar_index_null( personagens_figures_em_raw );

                        if( index_livre == -1 ) { 

                                index_livre = personagens_figures_em_raw.Length;
                                STRING.Aumentar_length_array( ref personagens_figures_em_raw ,  5 );
                                STRING.Aumentar_length_array_2d( ref personagens_figures_raw_data , 5);
                            
                        }

                        index_personagem = index_livre;
                }



            




                string path = Application.dataPath + "/Editor/Dados_personagens/" + _personagem + "/" + Upper( _personagem ) + "_figures_dados.dat";

                string dados_completos_raw = System.IO.File.ReadAllText( path );


                personagens_figures_raw_data[ index_personagem ] = dados_completos_raw.Split( texto_separando_figures_no_raw );


                





                string Upper( string _nome ) { 

                    char[] nome_char = _nome.ToCharArray();
                    nome_char[ 0 ] = char.ToUpper( nome_char[ 0 ] );
                    return new string( nome_char );

                }
   

        }



    public static Dados_figure_personagem Pegar_figure_dados ( int _figure_id ) {

            Dados_figure_personagem dados_retorno = new Dados_figure_personagem();

            if( figures_dados == null ) { Pegar_figures_dados(); }

            int index_inicio_informacoes =  ( int ) figures_localizador[ _figure_id ] ;

            int numero_maximo = 1000;
            int tentativa = 0;
            int index_final_informacoes = 0;

            int numero_de_separadores = 4;
            int[] indexes_separadores = new int[ numero_de_separadores ];
            int index_separador = 0;

            

            while( true ){

                tentativa++;
                if( tentativa < numero_maximo ){ throw new ArgumentException("passou do limite maximo em Litor_figures.Pegar_figure_dados") ;}

                if( figures_dados[ tentativa ] == caracter_de_separacao_dados_individuais ){

                    indexes_separadores[ index_separador ] = tentativa;
                    index_separador++;
                    continue;

                }


                if( figures_dados[ tentativa ] == caracter_de_separacao_figures_dados ){

                    index_final_informacoes = tentativa;
                    break;
                }
                continue;
                
            }

            int quantidade_caracteres_nome = ( index_inicio_informacoes - indexes_separadores[ 0 ] );

            char[] nome_figure_char_arr = new char[ quantidade_caracteres_nome ];

            for( int char_nome_figure = 0;  char_nome_figure < quantidade_caracteres_nome  ; char_nome_figure++ ){

                nome_figure_char_arr[ char_nome_figure ] = ( char ) figures_dados[ index_inicio_informacoes + char_nome_figure ];

            }

            string nome_final = nome_figure_char_arr.ToString();
            dados_retorno.figura_nome = nome_final;

            int index_primeiro_separador = indexes_separadores[ 0 ];
            int index_segundo_separador  =  indexes_separadores[ 1 ] ;
            int index_terceiro_separador =   indexes_separadores[ 2 ] ;
            int index_quarto_separador =   indexes_separadores[ 3 ] ;

            dados_retorno.width  =   figures_dados[ index_primeiro_separador + 1 ] ;
            dados_retorno.height =   figures_dados[ index_primeiro_separador + 2 ] ;

                                        //     logica para pegar o valor:
                                        //     short ( max 65k)   =>    (byte 1  * 256 ) +  ( byte 2 * 1 )    

            dados_retorno.imagem_base_id =     ( figures_dados[ index_primeiro_separador + 3 ] * 256  ) +  ( figures_dados[ index_primeiro_separador + 4 ] );
            dados_retorno.imagem_secundaria_id =     ( figures_dados[ index_primeiro_separador + 5 ] * 256  ) +  ( figures_dados[ index_primeiro_separador + 6 ] );

            dados_retorno.posicao_imagem_secundaria_x =   ( float ) (( figures_dados[ index_primeiro_separador + 7 ] * 256  ) +  ( figures_dados[ index_primeiro_separador + 8 ] )) ;
            dados_retorno.posicao_imagem_secundaria_y =   ( float ) (( figures_dados[ index_primeiro_separador + 9 ] * 256  ) +  ( figures_dados[ index_primeiro_separador + 10 ] )) ;




            /*  obviamente isso da para fazer de um jeito melhor, mas para deixar com nome bunitinho vou deixar assim for hora, se quiser arrumar depois boa sorte ai */


            int[] numero_animacoes_COMPLETAS = new int[]{

                                                    /* int numero_animacao_boca */    ( index_segundo_separador  - index_terceiro_separador - 1 ) , // -1 é porque faz sentido  1 2 3 4, numero entre 2 e 3 nao eh 3 - 2
                                                    /*int numero_animacao_olhos*/     ( index_terceiro_separador  - index_quarto_separador - 1 ) , 
                                                    /*int numero_animacao_completa*/  ( index_quarto_separador  - index_final_informacoes - 1 )  

                                                };

            int[][] novos_arrays_animacao = new int[ 3 ][];
            float[] posicoes = new float[ 6 ];


            for( int slot_animacao = 0 ; slot_animacao <  numero_animacoes_COMPLETAS.Length ; slot_animacao++ ){



                    if( numero_animacoes_COMPLETAS[ slot_animacao ] < 0 ){


                            posicoes[ (slot_animacao * 2) ] = ( float ) (( figures_dados[ indexes_separadores[ 1 + slot_animacao ] + 1 ]  * 256  ) +  ( figures_dados[ indexes_separadores[ 1 + slot_animacao ]  + 2 ] )) ;
                            posicoes[ (slot_animacao * 2) + 1] = ( float ) (( figures_dados[ indexes_separadores[ 1 + slot_animacao ] + 3 ]  * 256  ) +  ( figures_dados[ indexes_separadores[ 1 + slot_animacao ]  + 4 ] )) ;

                                                        //                    posicao     bytes / id
                            int numero_de_imagens_animacao = ((numero_animacoes_COMPLETAS[ slot_animacao ] - 4  )    /    2 ) ;

                            novos_arrays_animacao[ slot_animacao ] =  new int[ numero_de_imagens_animacao ];

                            

                                    //          sem contar a posicao x e y 
                            for( int index_animacao_boca = 0 ; index_animacao_boca < numero_de_imagens_animacao ; index_animacao_boca++ ){

                                    novos_arrays_animacao[ slot_animacao ][ index_animacao_boca ]  = (( figures_dados[ indexes_separadores[ 1 + slot_animacao ] + 4  + ( index_animacao_boca * 2 )  ]  * 256  ) +  ( figures_dados[ indexes_separadores[ 1 + slot_animacao ]  + 4 + ( index_animacao_boca * 2 ) + 1] )) ;

                            }


                    }


            }

            dados_retorno.boca_imagens_ids_animacao = novos_arrays_animacao[ 0 ];
            dados_retorno.boca_posicao_x_animacao = posicoes[ 0 ];
            dados_retorno.boca_posicao_y_animacao = posicoes[ 1 ];
            
            dados_retorno.olhos_imagens_ids_animacao = novos_arrays_animacao[ 1 ];
            dados_retorno.olhos_posicao_x_animacao = posicoes[ 2 ];
            dados_retorno.olhos_posicao_y_animacao = posicoes[ 3 ];

            dados_retorno.animacao_completa_imagens_ids_animacao = novos_arrays_animacao[ 2 ];

            dados_retorno.animacao_completa_posicao_x_animacao = posicoes[ 4 ];
            dados_retorno.animacao_completa_posicao_y_animacao = posicoes[ 5 ];

            return dados_retorno;
            

    }






    private static void Pegar_figures_dados(){

        // se demorar iniciar junto com o controlador


        // no android valeria mais a pena ter um instalador e baixar os arquivos.dat e deixas no persistent. aparanetemente pode usar as coisas normais ali. 
        // aparentemente todo o jogo vai virar um arquivo.apk . mas posso salvar na pasta depois


        //#if UNITY_EDITOR

        string path = Application.streamingAssetsPath + "/figures_dados.dat";

        figures_dados = System.IO.File.ReadAllBytes( path );

        path = Application.streamingAssetsPath + "/figures_localizador.dat";

        figures_localizador = System.IO.File.ReadAllBytes( path );

        //#endif

        return;




    }






}