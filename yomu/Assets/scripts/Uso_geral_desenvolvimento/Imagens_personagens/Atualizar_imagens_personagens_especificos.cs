using System;
using UnityEngine;





public static class Atualizar_imagens_personagens_especificos {


    public static void Ativar( string[] _nomes ){



   /*
                        quando for ativada vai pegar os dados da figures.txt e criar 4 arquivos princiapis:

                                => imagens_container.dat // contem todos os pngs//jpgs que um personagem tem 
                                => imagens_localizador.dat // arquivo que vai localizar onde cada imagem esta no container 
                                => arquvio_final_compactado
                                   tamanho do localizador           
                                    [ 4 bytes ]            +   [ imagens_localizador ] + imagens 
                                    os 4bytes + tamanho localizador já vão esta ontyabilizados 
                                                
                                => imagens_nomes.dat // vai ter os nomes da imagem. nao vai para a build, vai ser usado somente no editor


                                => figures_dados.dat // tem os dados de cada figure, quais imagens cada figure tem 
                                => figure_localizador.dat // arquivo que vai localizar os dados da figure  
                                => figures_nomes.txt // arquivo que vai ter os nomes das figures. nao vai para a build.


                        ** no .dat o byte separador sempre vai ser byte.MaxValue 
                           quando precisar eles sempre vao ser lidaos em pares. 
                           ( max 254  ) ( max 255 )
                           tirar 1 nao vai importar muito
                           seria: byte( n ) == 255? => ler byte( n ) + byte( n + 1 ) => byte( n + 3 ) == 255? => break

        
                */


                Debug.Log("<color=lightblue><size=15>Config:</size> </color>Atualizar_imagens_personagens_especificos esta <color=lime>ativo</color>");


                //mark

                // INICIO


                for(  int personagem_nome_index = 0 ;  personagem_nome_index < _nomes.Length  ; personagem_nome_index++   ){


                        string nome_personagem_str = _nomes[ personagem_nome_index ];

                        try { 
                                Personagem_nome personagem_nome_enum  = ( Personagem_nome ) Enum.Parse( typeof( Personagem_nome ), nome_personagem_str ); 
                        } catch ( Exception err ){
                                Debug.LogError( $" personagem <color=red><size=15>{nome_personagem_str}</size></color> nao foi encontrado"  ); throw err;
                        }

                        // vai resetar a cada novo personagem 
                        // isso vai ser usado somente para as imagens 
                        string[] imagens_nomes_alocador_maximo = new string[ 10_000 ];
                        byte[][] imagens_pngs_alocador_maximo = new byte[10_000][];

                        // 
                        int[] imagens_localizador_pointers = new int[ 10_000 ];
                        

                        // vai pular para o 1, o 0 fica destinado para quando nao tem nada
                        int pointer_alocador_imagens = 1;

                        char[][] figures_nomes = new char[1_000][];
                        byte[][] figures_dados_byte_arrs_maximos = new byte[ 1_000 ][];
                        
                        for( int figure_id = 0 ; figure_id < figures_dados_byte_arrs_maximos.Length ; figure_id++ ){

                                // ***  imagem id 0 => nao tem imagem 

                                // aqui vão ser colocados os dados das figures. 
                                // formato : 
                                // 2 bytes ( imagem_base_id ) 2 bytes ( imagem_secundaria_id ) 4 bytes ( secundaria posicao ) + 
                                // 1 byte ( separador animacao)  4 bytes ( posicao_animacao ) 2 bytes / imagem  1 byte ( separador animacao) * 3

                                figures_dados_byte_arrs_maximos[ figure_id ] = new byte[ 30 ];

                        }

                        
                        int Colocar_nome_image_E_pegar_id( char[] _imagem_char_arr ){

                                // o 0 nunca é pego
                                for( int index = 1 ; index < imagens_nomes_alocador_maximo.Length ;  index++  ){

                                        if( index  == pointer_alocador_imagens ){

                                                // nova_imagem
                                                // precisa carregar a imagem em byte_arr e salvar 

                                                string nova_string = new string( _imagem_char_arr );
                                                int index_para_colocar_nova_imagem = pointer_alocador_imagens;
                                                pointer_alocador_imagens++;

                                                
                                                string path_imagem =  null; // Paths_system.path_folder_dados_DEVELOPMENT + "/Personagens/" + nome_personagem_str + "/Imagens_in_game/" +  nova_string  + ".png";
                                                //
                                                bool arquivo_existe = System.IO.File.Exists( path_imagem );

                                                if( !( arquivo_existe ) ){

                                                        Debug.LogError( $"imagem <color=lightblue>${ nova_string }</color> do personagem <color=lightblue>${ nome_personagem_str }</color> <color=red><size=15> nao foi encontrada.</size></color>" );
                                                        Debug.LogError( $"path: { path_imagem }" );
                                                        throw new Exception("");

                                                }

                                                byte[] image_png = System.IO.File.ReadAllBytes( path_imagem );

                                                //Geral.Salvar_byte_array( image_png );


                                                // 2 coisas 
                                                // definir: comeca aqui e le tanto 
                                                // é mais intuitivo fazer pointer 1 e pointer 2
                                                
                                                // cada imagem tem 2 pointers
                                                // o localizador[ imagem_id ] da o pointer para iniciar a busca
                                                // localizador[ imagem_id + 1] da o pointer que termina 

                                                // a funcao para criar os pointer vai ser : 
                                                /// parece meio estranho mas é o certo 
                                                // quando na imagem_n => salvar em localizador[ imagem_n + 1 ] o valor do pointer atual + o tamanho da imagem 
                                                // o ponto inicial nao tem alteracao. 
                                                // mas o ponto final é o ponto em localizador[index + 1] - 1
                                                // 2 bytes nao podem estar no mesmo index ( uou ) 
                                                // localizador[index + 1] - 1 => final de um 
                                                // localizador[index + 1]     => inicio do outro 

                                                // ** o numero necessario sempre é numero_de_imagens + 1

                                                
                                                int ponto_inicial = imagens_localizador_pointers[ index_para_colocar_nova_imagem ];
                                                int tamanho_da_imagem = image_png.Length;
                                                int ponto_n_plus_1 = ponto_inicial + tamanho_da_imagem;


                                                // pointers 
                                                imagens_localizador_pointers[ index_para_colocar_nova_imagem + 1 ] = ponto_n_plus_1;
                                                
                                                // pngs 
                                                imagens_pngs_alocador_maximo[ index_para_colocar_nova_imagem ] = image_png;

                                                // nomes => vao ser usados para compilar scripts
                                                imagens_nomes_alocador_maximo[ index_para_colocar_nova_imagem ] = nova_string;


                                                return index_para_colocar_nova_imagem ;


                                        }

                                        //char[] char_arr_em_analise = imagens_nomes_alocador_maximo[ index ];

                                        string char_arr_em_analise = imagens_nomes_alocador_maximo[ index ];
                                        

                                        // testa se tem o mesmo tamanho
                                        if( char_arr_em_analise.Length != _imagem_char_arr.Length ){ continue; }

                                        // teste se o meio é o mesmo 
                                        int length_half = ( char_arr_em_analise.Length / 2 ) ;
                                        if( char_arr_em_analise[ length_half ] != _imagem_char_arr[ length_half ] ){ continue; }


                                        int ultimo_index =  char_arr_em_analise.Length -1 ;

                                        // testa se o ultimo é igual
                                        if( char_arr_em_analise[ ultimo_index ] != _imagem_char_arr[ ultimo_index ] ){ continue; }

                                        bool eh_o_mesmo = true;
                                        
                                        // faz o teste completo
                                        for( int c = 0 ; c < _imagem_char_arr.Length ; c++ ){

                                                if( _imagem_char_arr[ c ] != char_arr_em_analise[ c ] ){ 
                                                        eh_o_mesmo = false;
                                                        break;
                                                }

                                        }

                                        if( eh_o_mesmo){ return index;}
                                        continue;

                                }

                                // poha 10000 ta de sacanagem também 
                                throw new Exception("a");

                        }



                        string path_folder_dados_producao  = null; // Paths_system.path_folder_dados_DEVELOPMENT;
                        //aponta para o folder do personagem que vai construir o container.dat com as imagens 
                        string path_folder_personagem = path_folder_dados_producao + "/Personagens/" + nome_personagem_str;

                        /*
                                        preciso:
                                        - dados figures
                                                => lista imagens
                                                        => localizador.dat                              

                        */

                        // vai ser o formato completo 
                        string personagem_figure_dados_path = path_folder_personagem + "/Figures_dados.txt";

                        // preciso colocar um id para cada imagem 


                        string texto_completo = System.IO.File.ReadAllText( personagem_figure_dados_path );


                        string texto_divisao = "**";
                        
                        string[] figures_separadas = texto_completo.Split( texto_divisao );

                        


                        //mark
                        //-------INICIO FIGURE

                        for( int figure_bloco_index = 0; figure_bloco_index < figures_separadas.Length ; figure_bloco_index++ ){

                                Geral.Trava();

                                string bloco = figures_separadas[ figure_bloco_index ];                                     
                                byte[] figure_slot = figures_dados_byte_arrs_maximos[ figure_bloco_index ];



                                int caracter_index = 0;
                                char caracter_em_analise = '0';
                                int char_inicial = '0';
                                int char_final = '0';

                                bool comecou_a_ler_string = false;


                                // vai achar o inicio do nome 
                                for(  caracter_index = 0 ; caracter_index < bloco.Length ; caracter_index++  ){
                                        Geral.Trava();

                                        caracter_em_analise = bloco [ caracter_index ];
                                        if( caracter_em_analise != ':' )  { continue; }
                                        break;

                                }
                                        


                                // vai pegar o nome 
                                for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
                                        Geral.Trava();

                                        caracter_em_analise = bloco [ caracter_index ];

                                        if( comecou_a_ler_string ){

                                                if( caracter_em_analise == ' ' || caracter_em_analise == '\r' ){ 

                                                        // string nome terminou
                                                        char_final = caracter_index - 1;

                                                        char[] nome_figure_char_arr = new char[ ( char_final - char_inicial ) + 1 ];

                                                        for( int base_char_index = 0 ; base_char_index < nome_figure_char_arr.Length ; base_char_index++ ){
                                                                Geral.Trava();

                                                                nome_figure_char_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

                                                        }


                                                        // verificar_se_tem_duplicada( figures_nomes , nome_figure_char_arr )


                                                        figures_nomes[ figure_bloco_index ] = nome_figure_char_arr;


                                                        

                                                        // se já esxiste devolve o id
                                                       // int id_imagem_base = Colocar_nome_image_E_pegar_id( base_char_arr );

                                                        //
                                                        // figure_slot[ 0 ]  id_imagem_base
                                                        // figure_slot[ 1 ] 


                                                        comecou_a_ler_string = false;
                                                        break; 

                                                        
                                                }
                                                continue;

                                        }

                                        caracter_em_analise = bloco [ caracter_index ];
                                        if( caracter_em_analise == ' ' ){ continue;}

                                        if( caracter_em_analise == '\n' ){ 

                                                // pegar a linha depois
                                                throw new Exception( "nao foi colocado nome" );

                                        }
                                        comecou_a_ler_string = true;
                                        char_inicial = caracter_index;
                                        continue;


                                }




                                // vai até o inicio da base
                                for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
                                        Geral.Trava();

                                        caracter_em_analise = bloco [ caracter_index ];
                                        if( caracter_em_analise != '>' ){ continue; }
                                        break;

                                }

                                

                                // vai pegar base
                                for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
                                        Geral.Trava();

                                        caracter_em_analise = bloco [ caracter_index ];

                                        if( comecou_a_ler_string ){

                                                if( caracter_em_analise == ' ' || caracter_em_analise == '\r' ){ 

                                                        // string nome terminou
                                                        char_final = caracter_index - 1;

                                                        char[] base_char_arr = new char[ ( char_final - char_inicial ) + 1 ];

                                                        for( int base_char_index = 0 ; base_char_index < base_char_arr.Length ; base_char_index++ ){
                                                                Geral.Trava();
                                                                base_char_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

                                                        }



                                                        // se já esxiste devolve o id, se nao tiver adiciona
                                                        int id_imagem_base = Colocar_nome_image_E_pegar_id( base_char_arr );

                                                        //
                                                        unchecked {

                                                                figure_slot[ 0 ] =  ( byte ) ( id_imagem_base >> 8 );
                                                                figure_slot[ 1 ] =  ( byte ) ( id_imagem_base );

                                                        }

                                                        
                                                        


                                                        comecou_a_ler_string = false;
                                                        break; 

                                                        
                                                }
                                                continue;

                                        }

                                        caracter_em_analise = bloco [ caracter_index ];
                                        if( caracter_em_analise == ' ' ){ continue;}
                                        // nao tem imagem base bytes => 0 | 0
                                        if( caracter_em_analise == '\n' ){ break; }
                                        comecou_a_ler_string = true;
                                        char_inicial = caracter_index;
                                        continue;


                                }





                                // vai até o inicio da imagem_secundaria
                                for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
                                        Geral.Trava();

                                        caracter_em_analise = bloco [ caracter_index ];
                                        if( caracter_em_analise != '>' ){ continue; }
                                        break;

                                }



                                




                                //mark


                                //vai pegar imagem_secundaria 
                                for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
                                        Geral.Trava();

                                        caracter_em_analise = bloco [ caracter_index ];

                                        if( comecou_a_ler_string ){

                                                if( caracter_em_analise == '\r' ){ throw new Exception("nao foi colocado posicao na imagem secundaria"); }
                                                
                                                
                                                if( caracter_em_analise == ' '  || caracter_em_analise == ':' ){ 
                                                // string nome terminou

                                                        char_final = caracter_index - 1;

                                                        char[] imagem_secundaria_char_arr = new char[ ( char_final - char_inicial ) + 1 ];

                                                        for( int base_char_index = 0 ; base_char_index < imagem_secundaria_char_arr.Length ; base_char_index++ ){
                                                                Geral.Trava();

                                                                imagem_secundaria_char_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

                                                        }


                                                        // se já esxiste devolve o id, se nao tiver adiciona
                                                        int id_imagem_secundaria = Colocar_nome_image_E_pegar_id( imagem_secundaria_char_arr );
                                                        
                                                        unchecked {

                                                                figure_slot[ 2 ] =  ( byte ) ( id_imagem_secundaria >> 8 ) ;
                                                                figure_slot[ 3 ] =  ( byte ) ( id_imagem_secundaria ) ;

                                                        }
                        

                                                        comecou_a_ler_string = false;
                                                        break; 

                                                        
                                                }

                                                continue;

                                        }

                                        
                                        if( caracter_em_analise == ' ' ){ continue;}

                                        // nao tem imagem secundaria, bytes => 0 0 | 0 0 0 0 
                                        if( caracter_em_analise == '\r' ){ break; }
                                        
                                        comecou_a_ler_string = true;
                                        char_inicial = caracter_index;
                                        continue;


                                }




                                // deixa no inicio da posicao
                                for(  ; caracter_index < bloco.Length ; caracter_index++ ){
                                        Geral.Trava();

                                
                                        caracter_em_analise = bloco [ caracter_index ];
                                        if( caracter_em_analise == '\r' ){ throw new Exception("nao foi colocado posicao"); }
                                        if( caracter_em_analise != ':' ){ continue; }
                                        break;
                                }



                                // vai ler os numeros
                                for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
                                        Geral.Trava();

                                        caracter_em_analise = bloco [ caracter_index ];
                                        if( caracter_em_analise == ' ' ) { continue; }

                                        // vai pegar posicao x
                                        int acumulador_posicao_x = 0;
                                        for( ; caracter_index < bloco.Length ; caracter_index++ ){
                                                Geral.Trava();
                                        
                                                caracter_em_analise = bloco [ caracter_index ];
                                                
                                                if( caracter_em_analise == ' '){ continue; }
                                                if( caracter_em_analise == ',' ){  break; }
                                                if( caracter_em_analise == '\r' ){ throw new Exception("erro linha, faltou adicionar valor em y");}

                                                

                                                
                                                acumulador_posicao_x *= 10;
                                                                //      48 => 0, 49 => 1 ... etc
                                                int valor_para_adicionar = ( int ) caracter_em_analise - 48;

                                                if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
                                                acumulador_posicao_x += valor_para_adicionar;




                                        }

                                        unchecked {

                                                figure_slot[ 4 ] =  ( byte ) ( acumulador_posicao_x >> 8 ) ;
                                                figure_slot[ 5 ] =  ( byte ) ( acumulador_posicao_x ) ;

                                        }


                                        
                                        int acumulador_posicao_y = 0;
                                        for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++ ){
                                                Geral.Trava();
                                        
                                                caracter_em_analise = bloco [ caracter_index ];
                                                
                                                if( caracter_em_analise == ' '){ continue; }
                                                //if( caracter_em_analise == ',' ){ break; }
                                                if( caracter_em_analise =='\r' ){ break ;}

                                                
                                                acumulador_posicao_y *= 10;
                                                                //      48 => 0, 49 => 1 ... etc
                                                int valor_para_adicionar = ( int ) caracter_em_analise - 48;

                                                if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
                                                acumulador_posicao_y += valor_para_adicionar;
                                                


                                                

                                        }


                                        unchecked {

                                                figure_slot[ 6 ] =  ( byte ) ( acumulador_posicao_y >> 8 ) ;
                                                figure_slot[ 7 ] =  ( byte ) ( acumulador_posicao_y ) ;

                                        }
                                        

                                        break;
                                        




                                }






















  
//mark

                                

                                // comeca em 7 e aumenta dependendo de quantas imagens tem em cada animacao. Mesmo com 0 fica: 
                                // && && &&
                                int animacao_pointer = 8;
                                byte byte_separador_animacao = byte.MaxValue;

                                bool ja_leu_posicao = false; 



                                //mark
                                // vai pegar animacoes
                                for( int slot_animacao = 0 ; slot_animacao < 3 ; slot_animacao++ ){

                                        
                                        Geral.Trava();



                                        // vai até o inicio da animcao do loop atual
                                        for(  caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){
                                                Geral.Trava();

                                                caracter_em_analise = bloco [ caracter_index ];
                                                if( caracter_em_analise != '{' ){ continue; }
                                                break;

                                        }



                                        figure_slot[ animacao_pointer ] = byte_separador_animacao;
                                        animacao_pointer++;


                                        for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){



                                                Geral.Trava();
                                                caracter_em_analise = bloco [ caracter_index ];

                                                if( comecou_a_ler_string ){

                                                        // esta lendo a imagem 
                                                        // se tiver somente a posicao precisa gerar um erro. 
                                                        //                                          anim     slot
                                                        // aqui dentro pode ter um check tipo Checar( 3  ,  slot_animacao )
                                                        // e no final se todos nao estiverem checados ele gera um erro



                                                        if( caracter_em_analise == ' ' || caracter_em_analise == '\r' || caracter_em_analise == ':' ){ 

                                                                // string nome terminou
                                                                char_final = caracter_index - 1;

                                                                char[] animacao_imagem_charr_arr = new char[ ( char_final - char_inicial ) + 1 ];

                                                                for( int base_char_index = 0 ; base_char_index < animacao_imagem_charr_arr.Length ; base_char_index++ ){
                                                                        Geral.Trava();

                                                                        animacao_imagem_charr_arr[ base_char_index ] = bloco[ char_inicial + base_char_index ];

                                                                }



                                                                // se já esxiste devolve o id, se nao tiver adiciona
                                                                int id_imagem_animacao = Colocar_nome_image_E_pegar_id( animacao_imagem_charr_arr );

                                                                

                                                                //
                                                                unchecked {

                                                                        figure_slot[ animacao_pointer ] =  ( byte ) ( id_imagem_animacao >> 8 ) ;
                                                                        animacao_pointer++;
                                                                        figure_slot[ animacao_pointer ] =  ( byte ) ( id_imagem_animacao ) ;
                                                                        animacao_pointer++;

                                                                }

                                                                // encerrou de ler a string 
                                                                comecou_a_ler_string = false;
                                                                continue;
                                                                


                                                        }


                                                        // vai indo até achar o final da string 
                                                        continue;



                                                }


                                                // nao esta lendo nada ainda 

                                                if( caracter_em_analise == '}'){ break; } // nao tem animacao
                                                if( caracter_em_analise == ' '){ continue; }
                                                if( caracter_em_analise == '\n'){ continue; }
                                                if( caracter_em_analise == '\r'){ continue; }

                                                // achou texto

                                                // se nao leu, vai ler posicao 
                                                if( ! ( ja_leu_posicao) ){

                                                        ja_leu_posicao = true;


                                                        // deixa no inicio da posicao
                                                        for(  ; caracter_index < bloco.Length ; caracter_index++ ){
                                                                Geral.Trava();

                                                                caracter_em_analise = bloco [ caracter_index ];
                                                                if( caracter_em_analise != ':' ){ continue; }
                                                                break;
                                                        }

                                                        // vai ler os numeros
                                                        for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++  ){

                                                                Geral.Trava();

                                                                caracter_em_analise = bloco [ caracter_index ];
                                                                if( caracter_em_analise == ' ' ) { continue; }

                                                                // vai pegar posicao x
                                                                int acumulador_posicao_x_animacao = 0;
                                                                for( ; caracter_index < bloco.Length ; caracter_index++ ){
                                                                        Geral.Trava();
                                                                
                                                                        caracter_em_analise = bloco [ caracter_index ];
                                                                        
                                                                        if( caracter_em_analise == ' '){ continue; }
                                                                        if( caracter_em_analise == ',' ){ break; }
                                                                        if( caracter_em_analise == '\r' ){ throw new Exception("erro linha, faltou adicionar valor em y");}

                                                                        
                                                                        acumulador_posicao_x_animacao *= 10;
                                                                                        //      48 => 0, 49 => 1 ... etc
                                                                        int valor_para_adicionar = ( int ) caracter_em_analise - 48;

                                                                        if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
                                                                        acumulador_posicao_x_animacao += valor_para_adicionar;


                                                                }

                                                                unchecked {

                                                                        figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_x_animacao >> 8 ) ;
                                                                        animacao_pointer++;
                                                                        figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_x_animacao ) ;
                                                                        animacao_pointer++;

                                                                }


                                                                int acumulador_posicao_y_animacao = 0;
                                                                for( caracter_index++ ; caracter_index < bloco.Length ; caracter_index++ ){
                                                                        Geral.Trava();
                                                                
                                                                        caracter_em_analise = bloco [ caracter_index ];
                                                                        
                                                                        if( caracter_em_analise == ' '){ continue; }
                                                                        //if( caracter_em_analise == ',' ){ break; }
                                                                        if( caracter_em_analise =='\r' ){ break;}

                                                                        
                                                                        acumulador_posicao_y_animacao *= 10;
                                                                                        //      48 => 0, 49 => 1 ... etc
                                                                        int valor_para_adicionar = ( int ) caracter_em_analise - 48;

                                                                        if( valor_para_adicionar < 0 || valor_para_adicionar > 10  ){ throw new Exception( "foi digitado uma letra simbulo em posicao x" ); }
                                                                        acumulador_posicao_y_animacao += valor_para_adicionar;


                                                                        

                                                                }


                                                                unchecked {

                                                                        figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_y_animacao >> 8 ) ;
                                                                        animacao_pointer++;
                                                                        figure_slot[ animacao_pointer ] =  ( byte ) ( acumulador_posicao_y_animacao ) ;
                                                                        animacao_pointer++;

                                                                }

                                                                break;


                                                        }

                                                        // ele ainda nao comecou a ler a string, precisa fazer outra busca
                                                        continue;
                                                        


                                                }


                                                

                                                comecou_a_ler_string = true;
                                                char_inicial = caracter_index;
                                                continue;


                                        }



                                        ja_leu_posicao = false;

                                        figure_slot[ animacao_pointer ] = byte_separador_animacao;
                                        animacao_pointer++;
                                        // terminou essa animacao 
                                        // vai para a proxima =>  


                                }


                                // final figure => proxima figure

                        }


                        // aqui os dados já vão estar completos
                        // colocar o contianer.dat em strammingassets

                        // primeiro atualizar os pointers 
                        // fazer um loop para ver quanto espaço o localizador vai ocupar 

                        //           1  2  3  4            1  2      3  4  5  6    
                        //         [ 0  0  0  0 ]  =>   [  0  0  ] [ 0  0  0  0 ]


                        // quantos bytes o container final vai ter? 
                        //  imagens_localizador_pointers[ pointer_alocador_imagens ] => quando a ultima imagem começa => quantos bytes tem 
                        //  pointer_alocador_imagens => numero de imagens + 1
                        // ** IMPORTANTE pointer_alocador_imagens sempre esta 1 na frente, ele pega o valor quando vai atualizar e ++

                        // quantos bytes? =>  imagens_localizador_pointers[ pointer_alocador_imagens ] + pointer_alocador_imagens * 4

                        int novo_ponto_zero = (pointer_alocador_imagens + 1) * 4;
                                                                                // ultimo pointer                    numero de pointer( int ) 
                        int total_bytes_conteiner = imagens_localizador_pointers[ pointer_alocador_imagens ] + (pointer_alocador_imagens + 1) * 4;


                        byte[] container_final = new byte[ total_bytes_conteiner ];

                        int index = 0;

                        

                        

                        for( index = 0 ; index < pointer_alocador_imagens + 1 ; index++ ){

                                int pointer = imagens_localizador_pointers[ index ] + novo_ponto_zero;

                                unchecked {

                                        container_final[ ( index * 4 ) + 0 ] = ( byte ) ( pointer >> 24 );
                                        container_final[ ( index * 4 ) + 1 ] = ( byte ) ( pointer >> 16 );
                                        container_final[ ( index * 4 ) + 2 ] = ( byte ) ( pointer >> 8  );
                                        container_final[ ( index * 4 ) + 3 ] = ( byte ) ( pointer >> 0  );
                                        
                                }


                        }



                        int legnth_anterior = 0;

                        int numero_pngs = pointer_alocador_imagens - 1;


                        for( index = 1 ; index < numero_pngs + 1  ; index++ ){

                                byte[] png_byte_arr =  imagens_pngs_alocador_maximo[ index ];

                                int ponto_inicial = legnth_anterior + novo_ponto_zero;
                                Debug.Log( "ponto_inicial: " + ponto_inicial );

                                //throw new Exception("a");

                                for( int b = 0 ; b < png_byte_arr.Length ;b++ ){

                                        container_final[ ponto_inicial + b ] = png_byte_arr[ b ];

                                }

                                Geral.Salvar_byte_array( container_final );
                                legnth_anterior = png_byte_arr.Length;

                        }


                        
                        //Geral.Salvar_byte_array( container_final );







        	        // // dnumero de imagens : pointer_alocador_imagens - 1
                        

                        //                         // pointers 
                        // imagens_localizador_pointers[ index_para_colocar_nova_imagem ] = ponto_n_plus_1;
                        
                        // // pngs 
                        // imagens_pngs_alocador_maximo[ index_para_colocar_nova_imagem ] = image_png;

                        // // nomes => vao ser usados para compilar scripts
                        // imagens_nomes_alocador_maximo[ index_para_colocar_nova_imagem ] = nova_string;




                        // int tamanho_do_localizador = 0;

                        // for( int localizador_index = 0 ; localizador_index < pointer_alocador_imagens ; localizador_index++ ) {}

                                




                }

                









    }



}