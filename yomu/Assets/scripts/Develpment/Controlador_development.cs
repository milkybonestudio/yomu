using System;
using UnityEngine;


public static class Controlador_development {




   public static bool bloquear_development_tests = true;


    // --- CONTROLADORES

    public static bool atualizar_dados_sistema_personagens = false;
    public static bool atualizar_imagens_personagens = false;
    public static bool atualizar_imagens_personagens_especificos = true;

    // --- ALTO CUSTO
    public static bool atualizar_cenas = false;


    public static string[] personagens_para_atualizar_imagens = new string[]{

        "Lily"

    };
    
    


    public static void Verificar(){

        if( bloquear_development_tests){ return; }


        if(  atualizar_dados_sistema_personagens ){ Atualizar_dados_sistema_personagens ();}

        if( atualizar_imagens_personagens_especificos ){ Atualizar_imagens_personagens_especificos.Ativar( personagens_para_atualizar_imagens ); }

    }




        public static void Atualizar_imagens_personagens_especificos_( string[] _nomes ){

//                 /*

//                         quando for ativada vai pegar os dados da figures.txt e criar 4 arquivos princiapis:

//                                 => imagens_container.dat // contem todos os pngs//jpgs que um personagem tem 
//                                 => imagens_localizador.dat // arquivo que vai localizar onde cada imagem esta no container 
//                                 => arquvio_final_compactado
//                                    tamanho do localizador           
//                                     [ 4 bytes ]            +   [ imagens_localizador ] + imagens 
//                                     os 4bytes + tamanho localizador já vão esta ontyabilizados 
                                                
//                                 => imagens_nomes.dat // vai ter os nomes da imagem. nao vai para a build, vai ser usado somente no editor


//                                 => figures_dados.dat // tem os dados de cada figure, quais imagens cada figure tem 
//                                 => figure_localizador.dat // arquivo que vai localizar os dados da figure  
//                                 => figures_nomes.txt // arquivo que vai ter os nomes das figures. nao vai para a build.


//                         ** no .dat o byte separador sempre vai ser byte.MaxValue 
//                            quando precisar eles sempre vao ser lidaos em pares. 
//                            ( max 254  ) ( max 255 )
//                            tirar 1 nao vai importar muito
//                            seria: byte( n ) == 255? => ler byte( n ) + byte( n + 1 ) => byte( n + 3 ) == 255? => break

        
//                 */


//                 Debug.Log("<color=lightblue><size=15>Config:</size> </color>Atualizar_imagens_personagens_especificos esta <color=lime>ativo</color>");


//                 //mark

//                 // INICIO


//                 for(  int personagem_nome_index = 0 ;  personagem_nome_index < _nomes.Length  ; personagem_nome_index++   ){


//                         string nome_personagem_str = _nomes[ personagem_nome_index ];

//                         try { 
//                                 Personagem_nome personagem_nome_enum  = ( Personagem_nome ) Enum.Parse( typeof( Personagem_nome ), nome_personagem_str ); 
//                         } catch ( Exception err ){
//                                 Debug.LogError( $" personagem <color=red><size=15>{nome_personagem_str}</size></color> nao foi encontrado"  ); throw err;
//                         }

//                         // vai resetar a cada novo personagem 
//                         // isso vai ser usado somente para as imagens 

//                         char[][] imagens_alocador_maximo = new char[ 10_000 ][];

//                         // vai pular para o 1, o 0 fica destinado para quando nao tem nada
//                         int pointer_alocador_imagens = 0;


//                         char[][] figures_nomes = new char[1_000][];
//                         byte[][] figures_dados_byte_arrs_maximos = new byte[ 1_000 ][];
                        
//                         for( int figure_id = 0 ; figure_id < figures_dados_byte_arrs_maximos.Length ; figure_id++ ){

//                                 // ***  imagem id 0 => nao tem imagem 

//                                 // aqui vão ser colocados os dados das figures. 
//                                 // formato : 
//                                 // 2 bytes ( imagem_base_id ) 2 bytes ( imagem_secundaria_id ) 4 bytes ( secundaria posicao ) + 
//                                 // 1 byte ( separador animacao)  4 bytes ( posicao_animacao ) 2 bytes / imagem  1 byte ( separador animacao) * 3

//                                 figures_dados_byte_arrs_maximos[ figure_id ] = new byte[ 30 ];

//                         }

                        
//                         int Colocar_image_E_pegar_id( char[] _imagem_char_arr ){


//                                 for( int index = 0 ; index < imagens_alocador_maximo.Length ;  index++  ){

//                                         if( index  == pointer_alocador_imagens ){

//                                                 // nova_imagem
//                                                 imagens_alocador_maximo[ pointer_alocador_imagens ] = _imagem_char_arr;
//                                                 pointer_alocador_imagens++;
//                                                 return pointer_alocador_imagens;

//                                         }

//                                         char[] char_arr_em_analise = imagens_alocador_maximo[ index ];


//                                         if( char_arr_em_analise.Length != _imagem_char_arr.Length ){ continue; }

//                                         int length_half = ( char_arr_em_analise.Length / 2 ) ;
//                                         if( char_arr_em_analise[ length_half ] != _imagem_char_arr[ length_half ] ){ continue; }

//                                         int ultimo_index =  char_arr_em_analise.Length -1 ;


//                                         if( char_arr_em_analise[ ultimo_index ] != _imagem_char_arr[ ultimo_index ] ){ continue; }
                                        
//                                         for( int c = 0 ; c < _imagem_char_arr.Length ; c++ ){

//                                                 if( _imagem_char_arr[ c ] != char_arr_em_analise[ c ] ){ continue; }

//                                         }

//                                         // imagem duplicada
//                                         return index;

//                                 }

//                                 // poha 10000 ta de sacanagem também 
//                                 throw new Exception("a");


                                
//                         }




//                         string path_folder_dados_producao  = Paths_gerais.Pegar_path_folder_dados_producao();
//                         //aponta para o folder do personagem que vai construir o container.dat com as imagens 
//                         string path_folder_personagem = path_folder_dados_producao + "/Personagens/" + nome_personagem_str;

//                         /*
//                                         preciso:
//                                         - dados figures
//                                                 => lista imagens
//                                                         => localizador.dat                              

//                         */

//                         // vai ser o formato completo 
//                         string personagem_figure_dados_path = path_folder_personagem + "/Figures_dados.txt";

//                         // preciso colocar um id para cada imagem 


//                         string texto_completo = System.IO.File.ReadAllText( personagem_figure_dados_path );


//                         string texto_divisao = "**";
                        
//                         string[] figures_separadas = texto_completo.Split( texto_divisao );

                        


//                         //mark
//                         //-------INICIO FIGURE

//                         for( int figure_bloco_index = 0; figure_bloco_index < figures_separadas.Length ; figure_bloco_index++ ){

//                                 Geral.Trava();

//                                 string bloco = figures_separadas[ figure_bloco_index ];                                     
//                                 byte[] figure_slot = figures_dados_byte_arrs_maximos[ figure_bloco_index ];



//                                 int caracter_index = 0;
//                                 char caracter_em_analise = '0';
//                                 int char_inicial = '0';
//                                 int char_final = '0';

//                                 bool comecou_a_ler_string = false;


//                                 // vai achar o inicio do nome 
//                                 for(  caracter_index = 0 ; caracter_index < bloco.Length ; caracter_index++  ){
//                                         Geral.Trava();

//                                         caracter_em_analise = bloco [ caracter_index ];
//                                         if( caracter_em_analise != ':' )  { continue; }
//                                         break;

//                                 }
                                        


//                                 // vai pegar o nome 
//                                 for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
//                                         Geral.Trava();

//                                         caracter_em_analise = bloco [ caracter_index ];

//                                         if( comecou_a_ler_string ){

//                                                 if( caracter_em_analise == ' ' || caracter_em_analise == '\n' ){ 

//                                                         // string nome terminou
//                                                         char_final = caracter_index - 1;

//                                                         char[] nome_figure_char_arr = new char[ ( char_final - char_inicial ) + 1 ];

//                                                         for( int base_char_index = 0 ; base_char_index < nome_figure_char_arr.Length ; base_char_index++ ){
//                                                                 Geral.Trava();

//                                                                 nome_figure_char_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

//                                                         }


//                                                         // verificar_se_tem_duplicada( figures_nomes , nome_figure_char_arr )


//                                                         figures_nomes[ figure_bloco_index ] = nome_figure_char_arr;


                                                        

//                                                         // se já esxiste devolve o id
//                                                        // int id_imagem_base = Colocar_image_E_pegar_id( base_char_arr );

//                                                         //
//                                                         // figure_slot[ 0 ]  id_imagem_base
//                                                         // figure_slot[ 1 ] 


//                                                         comecou_a_ler_string = false;
//                                                         break; 

                                                        
//                                                 }
//                                                 continue;

//                                         }

//                                         caracter_em_analise = bloco [ caracter_index ];
//                                         if( caracter_em_analise == ' ' ){ continue;}

//                                         if( caracter_em_analise == '\n' ){ 

//                                                 // pegar a linha depois
//                                                 throw new Exception( "nao foi colocado nome" );

//                                         }
//                                         comecou_a_ler_string = true;
//                                         char_inicial = caracter_index;
//                                         continue;


//                                 }




//                                 // vai até o inicio da base
//                                 for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
//                                         Geral.Trava();

//                                         caracter_em_analise = bloco [ caracter_index ];
//                                         if( caracter_em_analise != '>' ){ continue; }
//                                         break;

//                                 }

                                

//                                 // vai pegar base
//                                 for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
//                                         Geral.Trava();

//                                         caracter_em_analise = bloco [ caracter_index ];

//                                         if( comecou_a_ler_string ){

//                                                 if( caracter_em_analise == ' ' || caracter_em_analise == '\n' ){ 

//                                                         // string nome terminou
//                                                         char_final = caracter_index - 1;

//                                                         char[] base_char_arr = new char[ ( char_final - char_inicial ) + 1 ];

//                                                         for( int base_char_index = 0 ; base_char_index < base_char_arr.Length ; base_char_index++ ){
//                                                                 Geral.Trava();

//                                                                 base_char_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

//                                                         }



//                                                         // se já esxiste devolve o id, se nao tiver adiciona
//                                                         int id_imagem_base = Colocar_image_E_pegar_id( base_char_arr );

//                                                         //
//                                                         unchecked {

//                                                                 figure_slot[ 0 ] =  ( byte ) ( id_imagem_base >> 8 );
//                                                                 figure_slot[ 1 ] =  ( byte ) ( id_imagem_base );

//                                                         }

                                                        
                                                        


//                                                         comecou_a_ler_string = false;
//                                                         break; 

                                                        
//                                                 }
//                                                 continue;

//                                         }

//                                         caracter_em_analise = bloco [ caracter_index ];
//                                         if( caracter_em_analise == ' ' ){ continue;}
//                                         // nao tem imagem base bytes => 0 | 0
//                                         if( caracter_em_analise == '\n' ){ break; }
//                                         comecou_a_ler_string = true;
//                                         char_inicial = caracter_index;
//                                         continue;


//                                 }





//                                 // vai até o inicio da imagem_secundaria
//                                 for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
//                                         Geral.Trava();

//                                         caracter_em_analise = bloco [ caracter_index ];
//                                         if( caracter_em_analise != '>' ){ continue; }
//                                         break;

//                                 }



                                




//                                 //mark


//                                 //vai pegar imagem_secundaria 
//                                 for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
//                                         Geral.Trava();

//                                         caracter_em_analise = bloco [ caracter_index ];

//                                         if( comecou_a_ler_string ){

//                                                 if( caracter_em_analise == '\r' ){ throw new Exception("nao foi colocado posicao na imagem secundaria"); }
                                                
                                                
//                                                 if( caracter_em_analise == ' '  || caracter_em_analise == ':' ){ 
//                                                 // string nome terminou

//                                                         char_final = caracter_index - 1;

//                                                         char[] imagem_secundaria_char_arr = new char[ ( char_final - char_inicial ) + 1 ];

//                                                         for( int base_char_index = 0 ; base_char_index < imagem_secundaria_char_arr.Length ; base_char_index++ ){
//                                                                 Geral.Trava();

//                                                                 imagem_secundaria_char_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

//                                                         }


//                                                         // se já esxiste devolve o id, se nao tiver adiciona
//                                                         int id_imagem_secundaria = Colocar_image_E_pegar_id( imagem_secundaria_char_arr );
                                                        
//                                                         unchecked {

//                                                                 figure_slot[ 2 ] =  ( byte ) ( id_imagem_secundaria >> 8 ) ;
//                                                                 figure_slot[ 3 ] =  ( byte ) ( id_imagem_secundaria ) ;

//                                                         }
                        

//                                                         comecou_a_ler_string = false;
//                                                         break; 

                                                        
//                                                 }

//                                                 continue;

//                                         }

                                        
//                                         if( caracter_em_analise == ' ' ){ continue;}

//                                         // nao tem imagem secundaria, bytes => 0 0 | 0 0 0 0 
//                                         if( caracter_em_analise == '\r' ){ break; }
                                        
//                                         comecou_a_ler_string = true;
//                                         char_inicial = caracter_index;
//                                         continue;


//                                 }




//                                 // deixa no inicio da posicao
//                                 for(  ; caracter_index < bloco.Length ; caracter_index++ ){
//                                         Geral.Trava();

                                
//                                         caracter_em_analise = bloco [ caracter_index ];
//                                         if( caracter_em_analise == '\r' ){ throw new Exception("nao foi colocado posicao"); }
//                                         if( caracter_em_analise != ':' ){ continue; }
//                                         break;
//                                 }



//                                 // vai ler os numeros
//                                 for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
//                                         Geral.Trava();

//                                         caracter_em_analise = bloco [ caracter_index ];
//                                         if( caracter_em_analise == ' ' ) { continue; }

//                                         // vai pegar posicao x
//                                         int acumulador_posicao_x = 0;
//                                         for( ; caracter_index < bloco.Length ; caracter_index++ ){
//                                                 Geral.Trava();
                                        
//                                                 caracter_em_analise = bloco [ caracter_index ];
                                                
//                                                 if( caracter_em_analise == ' '){ continue; }
//                                                 if( caracter_em_analise == ',' ){  break; }
//                                                 if( caracter_em_analise == '\r' ){ throw new Exception("erro linha, faltou adicionar valor em y");}

                                                

                                                
//                                                 acumulador_posicao_x *= 10;
//                                                                 //      48 => 0, 49 => 1 ... etc
//                                                 int valor_para_adicionar = ( int ) caracter_em_analise - 48;

//                                                 if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
//                                                 acumulador_posicao_x += valor_para_adicionar;




//                                         }

//                                         unchecked {

//                                                 figure_slot[ 4 ] =  ( byte ) ( acumulador_posicao_x >> 8 ) ;
//                                                 figure_slot[ 5 ] =  ( byte ) ( acumulador_posicao_x ) ;

//                                         }


                                        
//                                         int acumulador_posicao_y = 0;
//                                         for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++ ){
//                                                 Geral.Trava();
                                        
//                                                 caracter_em_analise = bloco [ caracter_index ];
                                                
//                                                 if( caracter_em_analise == ' '){ continue; }
//                                                 //if( caracter_em_analise == ',' ){ break; }
//                                                 if( caracter_em_analise =='\r' ){ break ;}

                                                
//                                                 acumulador_posicao_y *= 10;
//                                                                 //      48 => 0, 49 => 1 ... etc
//                                                 int valor_para_adicionar = ( int ) caracter_em_analise - 48;

//                                                 if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
//                                                 acumulador_posicao_y += valor_para_adicionar;
                                                


                                                

//                                         }


//                                         unchecked {

//                                                 figure_slot[ 6 ] =  ( byte ) ( acumulador_posicao_y >> 8 ) ;
//                                                 figure_slot[ 7 ] =  ( byte ) ( acumulador_posicao_y ) ;

//                                         }
                                        

//                                         break;
                                        




//                                 }


































  


// //mark

                                


//                                 // comeca em 7 e aumenta dependendo de quantas imagens tem em cada animacao. Mesmo com 0 fica: 
//                                 // && && &&
//                                 int animacao_pointer = 8;
//                                 byte byte_separador_animacao = byte.MaxValue;

//                                 bool ja_leu_posicao = false; 



//                                 //mark
//                                 // vai pegar animacoes
//                                 for( int slot_animacao = 0 ; slot_animacao < 3 ; slot_animacao++ ){

                                        
//                                         Geral.Trava();



//                                         // vai até o inicio da animcao do loop atual
//                                         for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
//                                                 Geral.Trava();

//                                                 caracter_em_analise = bloco [ caracter_index ];
//                                                 if( caracter_em_analise != '{' ){ continue; }
//                                                 break;

//                                         }



//                                         figure_slot[ animacao_pointer ] = byte_separador_animacao;
//                                         animacao_pointer++;


//                                         for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){



//                                                 Geral.Trava();
//                                                 caracter_em_analise = bloco [ caracter_index ];

//                                                 if( comecou_a_ler_string ){

//                                                         // esta lendo a imagem 
//                                                         // se tiver somente a posicao precisa gerar um erro. 
//                                                         //                                          anim     slot
//                                                         // aqui dentro pode ter um check tipo Checar( 3  ,  slot_animacao )
//                                                         // e no final se todos nao estiverem checados ele gera um erro



//                                                         if( caracter_em_analise == ' ' || caracter_em_analise == '\n' || caracter_em_analise == ':' ){ 

//                                                                 // string nome terminou
//                                                                 char_final = caracter_index - 1;

//                                                                 char[] animacao_imagem_charr_arr = new char[ ( char_final - char_inicial ) + 1 ];

//                                                                 for( int base_char_index = 0 ; base_char_index < animacao_imagem_charr_arr.Length ; base_char_index++ ){
//                                                                         Geral.Trava();

//                                                                         animacao_imagem_charr_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

//                                                                 }



//                                                                 // se já esxiste devolve o id, se nao tiver adiciona
//                                                                 int id_imagem_animacao = Colocar_image_E_pegar_id( animacao_imagem_charr_arr );

                                                                

//                                                                 //
//                                                                 unchecked {

//                                                                         figure_slot[ animacao_pointer ] =  ( byte ) ( id_imagem_animacao >> 8 ) ;
//                                                                         animacao_pointer++;
//                                                                         figure_slot[ animacao_pointer ] =  ( byte ) ( id_imagem_animacao ) ;
//                                                                         animacao_pointer++;

//                                                                 }

//                                                                 // encerrou de ler a string 
//                                                                 comecou_a_ler_string = false;
//                                                                 continue;
                                                                


//                                                         }


//                                                         // vai indo até achar o final da string 
//                                                         continue;



//                                                 }


//                                                 // nao esta lendo nada ainda 

//                                                 if( caracter_em_analise == '}'){ break; } // nao tem animacao
//                                                 if( caracter_em_analise == ' '){ continue; }
//                                                 if( caracter_em_analise == '\n'){ continue; }
//                                                 if( caracter_em_analise == '\r'){ continue; }

//                                                 // achou texto

//                                                 // se nao leu, vai ler posicao 
//                                                 if( ! ( ja_leu_posicao) ){

//                                                         ja_leu_posicao = true;


//                                                         // deixa no inicio da posicao
//                                                         for(  ; caracter_index < bloco.Length ; caracter_index++ ){
//                                                                 Geral.Trava();

//                                                                 caracter_em_analise = bloco [ caracter_index ];
//                                                                 if( caracter_em_analise != ':' ){ continue; }
//                                                                 break;
//                                                         }

//                                                         // vai ler os numeros
//                                                         for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){

//                                                                 Geral.Trava();

//                                                                 caracter_em_analise = bloco [ caracter_index ];
//                                                                 if( caracter_em_analise == ' ' ) { continue; }

//                                                                 // vai pegar posicao x
//                                                                 int acumulador_posicao_x_animacao = 0;
//                                                                 for( ; caracter_index < bloco.Length ; caracter_index++ ){
//                                                                         Geral.Trava();
                                                                
//                                                                         caracter_em_analise = bloco [ caracter_index ];
                                                                        
//                                                                         if( caracter_em_analise == ' '){ continue; }
//                                                                         if( caracter_em_analise == ',' ){ break; }
//                                                                         if( caracter_em_analise == '\r' ){ throw new Exception("erro linha, faltou adicionar valor em y");}

                                                                        
//                                                                         acumulador_posicao_x_animacao *= 10;
//                                                                                         //      48 => 0, 49 => 1 ... etc
//                                                                         int valor_para_adicionar = ( int ) caracter_em_analise - 48;

//                                                                         if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
//                                                                         acumulador_posicao_x_animacao += valor_para_adicionar;


//                                                                 }

//                                                                 unchecked {

//                                                                         figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_x_animacao >> 8 ) ;
//                                                                         animacao_pointer++;
//                                                                         figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_x_animacao ) ;
//                                                                         animacao_pointer++;

//                                                                 }


//                                                                 int acumulador_posicao_y_animacao = 0;
//                                                                 for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++ ){
//                                                                         Geral.Trava();
                                                                
//                                                                         caracter_em_analise = bloco [ caracter_index ];
                                                                        
//                                                                         if( caracter_em_analise == ' '){ continue; }
//                                                                         //if( caracter_em_analise == ',' ){ break; }
//                                                                         if( caracter_em_analise =='\r' ){ break;}

                                                                        
//                                                                         acumulador_posicao_y_animacao *= 10;
//                                                                                         //      48 => 0, 49 => 1 ... etc
//                                                                         int valor_para_adicionar = ( int ) caracter_em_analise - 48;

//                                                                         if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
//                                                                         acumulador_posicao_y_animacao += valor_para_adicionar;


                                                                        

//                                                                 }


//                                                                 unchecked {

//                                                                         figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_y_animacao >> 8 ) ;
//                                                                         animacao_pointer++;
//                                                                         figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_y_animacao ) ;
//                                                                         animacao_pointer++;

//                                                                 }

//                                                                 break;


//                                                         }

//                                                         // ele ainda nao comecou a ler a string, precisa fazer outra busca
//                                                         continue;
                                                        


//                                                 }


                                                

//                                                 comecou_a_ler_string = true;
//                                                 char_inicial = caracter_index;
//                                                 continue;


//                                         }



//                                         ja_leu_posicao = false;

//                                         figure_slot[ animacao_pointer ] = byte_separador_animacao;
//                                         animacao_pointer++;
//                                         // terminou essa animacao 
//                                         // vai para a proxima =>  


//                                 }

//                                 Geral.Salvar_byte_array( figure_slot );

                                

//                         }


//                 }

                
        }


        

                


    public static void Atualizar_dados_sistema_personagens(){


        Debug.Log("<color=lightblue><size=15>Config:</size> </color>Atualizar_dados_sistema_personagens esta <color=lime>ativo</color>");

        // isso vai atualizar todos os dados_sistemas




            // criar dados sistema 

            throw new Exception();

            // onde vai colocar os arquivos 
            string path_folder_save_default = null;
            // onde que vai pegar
            string path_localidades_personagens =  null;
            string[] personagens_nomes = Enum.GetNames( typeof( Personagem_nome ) );
            int numero_personagens = personagens_nomes.Length ;

             
            string[] linhas = System.IO.File.ReadAllLines( path_localidades_personagens );


            Verificar_se_os_numero_estao_certos( linhas, personagens_nomes );



            int interesse_player_default = 200;




            /*

                ordem: 

                        posicao ( 16 bytes ) - interesse_player ( 2 bytes ) -projecao_interesse ( 2 bytes ) - afetividade ( 2 byte ) - afetividade_projecao ( 2 bytes)
                        personagem_ja_foi_apresentado ( 1 byte ) - data_quando_apresentado( 8 bytes ) - nivel_interesee( 1 byte ) - player colocou personagem em foco ( 1 byte )
                        - personagem_bloqueado( 1 byte)
                        - updates ( n bytes termina em & ) 
            
            */

            // sempre vai ter 0 como valor, pois sempre começar com default no update
            // vou colocar 10 que aguenta
            int numero_de_updates = 10;
            int total_bytes_necessarios = 36 + numero_de_updates;

            byte[] container = new byte[ total_bytes_necessarios * numero_personagens ];



            for( int personagem_dados_default = 0 ; personagem_dados_default < numero_personagens ; personagem_dados_default++ ){

                int acumulador = personagem_dados_default * total_bytes_necessarios;


                unchecked {


                    //inicio interesse                             256    44
                    container[ acumulador + 16 ] =   ( byte )  ( 300 >> 8 ) ;
                    container[ acumulador + 17 ] =   ( byte )  ( 300 ) ;

                    // proj interesse 
                    container[ acumulador + 18 ] =   ( byte )  ( 300 >> 8 )   ;
                    container[ acumulador + 19 ] =   ( byte )  ( 300  ) ;


                    //inicio afetividade                             256    44
                    container[ acumulador + 20 ] =   ( byte )  ( 300 >> 8 )  ;
                    container[ acumulador + 21 ] =   ( byte )  ( 300  )  ;

                    // proj afetividade
                    container[ acumulador + 22 ] =   ( byte )  ( 300 >> 8 )   ;
                    container[ acumulador + 23 ] =   ( byte )  ( 300  )  ;

                    // ** os outros são 0



                }

                


            }

            

                
            for( int personagem_index = 0 ; personagem_index < numero_personagens ; personagem_index++  ){


                    int acumulador_posicao = personagem_index * total_bytes_necessarios ;


                    // dados da posicao 

                    // nao sei onde isso é usado ;-;

                //     string linha = linhas[ personagem_index ];
                //     string[] nome_E_dados = linha.Split( ":" );
                //     string nome = nome_E_dados[ 0 ].Trim();
                //     string[] dados_str = nome_E_dados[ 1 ].Split( "," ) ;
                //     Personagem_nome personagem_nome =  ( Personagem_nome ) Enum.Parse( typeof( Personagem_nome ) , nome ) ;

                //     string ponto_nome_str = dados_str[ 0 ].Trim();
                //     string local_nome_str = dados_str[ 1 ].Trim();
                //     string cidade_nome_str = dados_str[ 2 ].Trim();
                //     string estado_nome_str = dados_str[ 3 ].Trim();
                //     string reino_nome_str = dados_str[ 4 ].Trim();
                //     string continente_nome_str = dados_str[ 5 ].Trim();


                //     int ponto_index =  ( int )  Enum.Parse( typeof( Ponto_nome ) , ponto_nome_str ) ;
                //     int local_index =  ( int )  Enum.Parse( typeof( Local_nome ) , local_nome_str ) ;
                //     int cidade_index =  ( int )  Enum.Parse( typeof( Cidade_nome ) , cidade_nome_str ) ;
                //     short estado_index =  ( short )  Enum.Parse( typeof( Estado_nome ) , estado_nome_str ) ;
                //     byte reino_index =  ( byte )  Enum.Parse( typeof( Reino_nome ) , reino_nome_str ) ;
                //     byte continente_index =  ( byte )  Enum.Parse( typeof( Continente_nome ) , continente_nome_str ) ;


                //     unchecked {

                //             container[ acumulador_posicao ]   =  ( byte )( ponto_index >> 24 ) ;
                //             container[ acumulador_posicao + 1 ]   =  ( byte )( ponto_index >> 16 ) ;
                //             container[ acumulador_posicao + 2 ]   =  ( byte )( ponto_index >> 8 ) ;
                //             container[ acumulador_posicao + 3 ]   =  ( byte )( ponto_index ) ;


                //             container[ acumulador_posicao + 4 ]   =  ( byte )( local_index >> 24 ) ;
                //             container[ acumulador_posicao + 5 ]   =  ( byte )( local_index >> 16 ) ;
                //             container[ acumulador_posicao + 6 ]   =  ( byte )( local_index >> 8 ) ;
                //             container[ acumulador_posicao + 7 ]   =  ( byte )( local_index ) ;
                            

                //             container[ acumulador_posicao + 8 ]   =  ( byte )( cidade_index >> 24 ) ;
                //             container[ acumulador_posicao + 9 ]   =  ( byte )( cidade_index >> 16 ) ;
                //             container[ acumulador_posicao + 10 ]   =  ( byte )( cidade_index >> 8 ) ;
                //             container[ acumulador_posicao + 11 ]   =  ( byte )( cidade_index ) ;

                //             container[ acumulador_posicao + 12 ]   =  ( byte )( estado_index >> 8 ) ;
                //             container[ acumulador_posicao + 13 ]   =  ( byte )( estado_index  ) ;

                //             container[ acumulador_posicao + 14 ]   =  ( byte )( reino_index) ;
                            
                //             container[ acumulador_posicao + 15 ]   =  ( byte )( continente_index ) ;
                            

                //     }




                    // os dados aqui vao estar compactados
                    // eu nao vou ser capaz de usar strings 
                    // minha mente vai ser a minha propria derrota



                    
            }


            return;

            string path_para_salvar_novos_dados =  null; //Paths_sistema.path_arqu  Paths_gerais.Pegar_path_folder_dados_save_default() + "/dados_sistema.dat";

            System.IO.File.WriteAllBytes( path_para_salvar_novos_dados, container );



                

            void Verificar_se_os_numero_estao_certos( string[] linhas, string[] personagens_nomes ){


                    // AINDA NAO TESTADO


                

                    if( (linhas.Length ) < personagens_nomes.Length ){ 

                            // algum personagem nao estava na lista. aqui vai ver qual personagem

                            for( int l = 0 ; l < linhas.Length ;l++ ){
                                    // personagem : dados => personagem
                                    linhas[ l ] =  linhas[ l ].Split(":")[ 0 ].Trim();

                            }
                                
                            for( int p = 0 ; p < personagens_nomes.Length ; p++){


                                    string _nome_personagem = ( ( Personagem_nome ) p ).ToString();

                                    bool achou = false;

                                    for( int k = 0; k < linhas.Length ; k++ ){

                                            if( linhas[ p ] == _nome_personagem ){ 
                                                    achou = true; 
                                                    break;
                                            }
                                            continue;

                                    }

                                    if( !( achou ) ){

                                        Debug.LogError( $"nao foi achado o personagem <b><color=red><size=15>{ _nome_personagem }</size></color></b> na lista_localidade_inicial" );
                                        break;

                                    }

                                    linhas[ p ].Split();

                            }
                            throw new Exception( "problema em personagens localidade");



                    } 



            }






    }

    

}
