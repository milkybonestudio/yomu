
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;






public class Controlador_save {






      /*

            ** os personagens tem todos os dados que estão disponiveis para eles usarem nos updates normais 
             
                o unico momento que eu posso precisar pegar dados para algum personagem é: 
                     - mudança de prioridade 
                     - update mensal



                essas mudanças podem ser controladas pelo sistema e vão acontecer quando o player for dormir. Isso da uns 2 segundaos para qualquer tipo de calculo 


            ** coisas que podem influenciar o mundo ou outros personagens são armazenadas no proprio mundo.

                  se uma maça foi tirada de um deposito e vai influenciar alguem. quem tirou importa? sim => fica marcado no personagem que tirou 
                                                                                                              e no personagem que vai influenciar 
                                                                                                      nao => personagem + mundo 

                 ** personagem pegou uma maça em um depoisito 
                                  => influencia algum outro personagem ?  nao  => fica somente no player 
                                                                          sim  => afeta muitos? nao => fica no player e no outro personagem 
                                                                                                sim => fica no geral 


                                                                          
            salvar pode criar chunks e ir salvando aos poucos, tendo comente cuidado com cada chunk 

            Pegar dados só vai acontecer em momentos muito especificos que podem ser controlados pelo sistema 

                  ** fazer dormir como um modo e atualizar coisas internas 
                  ** dormir vai ser algo muito importante, o jogo nunca pode pular um dia sem chamar a funcao Dormir() porque ela trabalha para atualizar


            Na realidade isso é muita estupidez. atualizar pode ser em qualquer frame.um personagem com atualização mensal pode carregar os arquivos em 0.5ms 
            Mas controlador personagem tem que ter um sistema para controlador. Todos de uma vez pode travar. 

            Moral: personagens de nivel baixo precisa ter mais cuidado no update em trocas de nivel 



            pegar dados precisa ser na thread, ou seja eu preciso pensar em como fazer para interromper a main thread e esperar ele pegar 


            como interromper a thread :
              
               1 - coroutines => entra no modo update que esta passando de um ponto para outro. mas só completo quando os dados estiverem completos 
               2 - passar para  multithread, criar um loop na main e usar sleep 


      
      */


            
            public static Controlador_save instancia;
            public static Controlador_save Pegar_instancia(){ return instancia; }


            public static bool esta_em_teste = false;

            public static Controlador_save Construir_teste (){

                        // vai ser executado na main thread

                        esta_em_teste = true;

                        instancia = new Controlador_save(); 
                        
                        Dados_blocos.Construir();
                        Controlador_timer.Construir();

                        Controlador_dados_dinamicos.Construir();
                        
                        Controlador_UI.Construir();
                        Controlador_transicao.Construir();

                        Player_estado_atual.Construir();

                        

                        // nao vai construir nenhum personagem além da nara
                        Controlador_personagens.Construir_teste();
                        

                        return instancia;


            }






            public static Controlador_save Construir( int _save, bool _novo_jogo ){

                        throw new Exception( "ainda nao esta pronto" );

                        instancia = new Controlador_save(); 
                        
                        
                        // ** nao faz sentido eu pensar em salvar sem ter o formato dos arquivos 

                        
                        // tudo aqui vai ser instanciado na multithread 
                        // nao consomem tempo

                        Dados_blocos.Construir();
                        Controlador_timer.Construir();

                        Controlador_dados_dinamicos.Construir();
                        
                        Controlador_UI.Construir();
                        Controlador_transicao.Construir();






                        if( _save > 5 ) { throw new Exception( "tentou carregar save " + _save.ToString() ); }

                        if( _novo_jogo ){

                              // copiar arquivos que vão estar em path_mutaveis ** definir
                              instancia.Copiar_arquvios_do_novo_jogo( _save );

                        }



                        instancia.path_save_folder = Paths_gerais.Pegar_path_folder_dados_save( _save );






                        // ---- PERSONAGENS
                        


                        string path_dados_sistema = instancia.path_save_folder + "/Dados_programa/dados_programa.dat";
                        string path_dados_seguranca = instancia.path_save_folder + "/Dados_programa/dados_seguranca.txt";
                        string path_personagens = instancia.path_save_folder + "/Personagens/";

                        FileMode file_mode = FileMode.Open;
                        FileAccess file_accees = FileAccess.ReadWrite;
                        FileShare file_share = FileShare.Read;
                        FileOptions file_options = FileOptions.WriteThrough;

                        instancia.stream_dados_sistema  = new FileStream( path_dados_sistema, file_mode, file_accees , file_share, instancia.tamanho_dados_sistema , file_options );

                        if( File.Exists( path_dados_seguranca ) ){

                              // algo deu errado


                        }


                        System.IO.File.WriteAllBytes( path_dados_seguranca, new byte[ instancia.length_arquivo_segurancao_maximo ] );
                        instancia.stream_dados_auto_save = new FileStream( path_dados_seguranca, file_mode, file_accees , file_share, instancia.length_arquivo_segurancao_maximo , file_options );


                        byte[] dados_sistema = new byte[ instancia.tamanho_dados_sistema ];
                        instancia.stream_dados_sistema.Read( dados_sistema , 0, dados_sistema.Length );
                                    

                        // com dados sistema eu posso realmente criar os personagens 

                        Dados_sistema_personagem[] dados_sistema_personagens = Tradutor_save.Descompactar_dados_sistema_personagens( dados_sistema );



                              
                        
                        instancia.controlador_save_personagens = new Controlador_save_personagens(  dados_sistema_personagens,  _save  ); 
                        Controlador_personagens.Construir( dados_sistema_personagens, _save ); 

                        // personagem.Mudar_valores( thing, novo_valor ); => ativa Controlador_personagem => entrega_valores_para_update 

                        // thing_1()
                        // thing_2()
                        // ...

                        // Controlador_save.Update() => pega dados Controlador_personagens

                        // Player_estado_atual.Construir(  ); ** talvez eu tenha que passar o save também 

                        return instancia;


            }










            public string path_save_folder; 
            public int tamanho_dados_sistema = 10_000; // numero de personagens * 

            public byte[][] dados_para_salvar;

            public Controlador_save_personagens controlador_save_personagens;


            public int frame = 0;


            public void Update(){

                  // quando estiver em teste nao vai deixar salvar 
                  if( esta_em_teste ) { return ;}

                  frame = ( frame + 1 ) % 10;

                  // verifiacr atualizacoes em blocos que precisam ser salvos: 
                  // todo dado que for pego aqui já vai estar no jogo 
                  // realmente atualizam a cada 10 frames 

                  if( frame == 0 ){ Atualizar_dados_seguranca(); }


            }



                        
            public void Atualizar_dados_seguranca(){


                        // ** execuar na multithread faria mais sentido

                        // formato: 

                        // sefty   length             sefty  
                        // 1 byte              1 byte

                        // pega todos os dados 

                        byte[] dados_personagens_seguranca = controlador_save_personagens.Pegar_dados_em_espera();
                        //byte[] dados_woirld = controlador_save_world.Pegar_dados_em_espera();

                        int length_dados_reais = dados_personagens_seguranca.Length;

                                          //  1 no inicio e no final  / length    
                        int legnth_dados_para_adicionar = 2   +            2     +  length_dados_reais  ;
                        byte[] dados_para_adicionar = new byte[ legnth_dados_para_adicionar ];

                        // se byte[ length + 1 ] for 0 => nao foi salvo corretamente;

                        dados_para_adicionar[ 0 ] = 1 ;
                        dados_para_adicionar[ 1 ] = ( byte ) (length_dados_reais >> 8 ) ;
                        dados_para_adicionar[ 2 ] = ( byte ) (length_dados_reais >> 0 ) ;
                        dados_para_adicionar[ (dados_para_adicionar.Length - 1) ] = 1 ;

                        int index_acumulador = 3;

                        int index = 0;

                        for(  index = 0;  index < dados_personagens_seguranca.Length ; index++ ){

                                    dados_para_adicionar[ index_acumulador +  index ] = dados_personagens_seguranca[ index ];

                        }

                        //length_arquivo_segurancao += 
                        stream_dados_auto_save.Write( dados_personagens_seguranca, 0, dados_personagens_seguranca.Length );

            }


            
            public byte[] info_auto_save = new byte[ 0 ];

            public FileStream stream_dados_sistema ;
            
            public System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding( true );


            int length_arquivo_segurancao_maximo = 50_000;
            int length_arquivo_segurancao = 0;
            public FileStream stream_dados_auto_save;





            public void Copiar_arquvios_do_novo_jogo( int _save ){

                        
                        // acho que seria melhor colocar somente os personagens principais 
                        // Poderia ter uma funcao Adicionar_personagem 
                        // mas os dados genericos ainda estariam no geral

                        /*

                              a unica coisa de dados_sistema que precisa ter realmente dados fixos é onde que o personagem começa 
                              talvez eu faça uma lista com os dados e o resto é criado tudo por default 

                        */

                        string path_com_os_dados = Paths_gerais.Pegar_path_folder_com_os_saves_defaults();


                        // onde vai ser salvo
                        string path_folder_dados_personagens = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/Personagens";
                        string path_folder_dados_personagens_morte = Paths_gerais.Pegar_path_folder_dados_save( _save )  + "save_morte/Personagens";
                        
                        string path_folder_save_default = Paths_gerais.Pegar_path_folder_dados_save_default() + "/Personagens";

                        // normal
                        Copiar_pasta_inteira(  

                        _local_para_salvar: path_folder_dados_personagens ,
                        _local_para_copiar : path_folder_save_default
                        );

                        // morte 
                        Copiar_pasta_inteira(  

                        _local_para_salvar: path_folder_dados_personagens_morte ,
                        _local_para_copiar : path_folder_save_default
                        );


            }


      






      // pastas só são criadas no save 
      // testei e já funciona corretamente
      // talvez possar ter o argumento para ver se pode ser com cache ou nao
      public void Copiar_pasta_inteira(  string _local_para_salvar,  string _local_para_copiar ){

                                
                // Sempre assume que o folder nao foi criado
                System.IO.Directory.CreateDirectory( _local_para_salvar );

                // vem como path completo
                string[] folders = System.IO.Directory.GetDirectories( _local_para_copiar );

                for( int folder_id = 0 ; folder_id < folders.Length ; folder_id++ ){
                                                                           //   ta certo, vai pegar somente o nome do diretory
                    string folder_path_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( folders[ folder_id ] );
                    string folder_path_para_copiar = folders[ folder_id ] ;
                    Copiar_pasta_inteira( folder_path_para_salvar , folder_path_para_copiar );

                }
                /// vem com o path completo
                string[] nomes_arquivos = System.IO.Directory.GetFiles( _local_para_copiar );

                for( int arquivo_id = 0 ; arquivo_id < nomes_arquivos.Length ; arquivo_id++ ){

                    
                    string path_arquivo_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( nomes_arquivos[ arquivo_id ] );
                    string path_arquivo_para_copiar =  nomes_arquivos[ arquivo_id ];
                    System.IO.File.Copy(  path_arquivo_para_copiar,  path_arquivo_para_salvar  );

                }

                return;

      }






      // public void Update(){

      //       // Save pode usar o update para salvar os arquivos de segurança 

      // }


      

      // isso poderia estar em ferramentas 
      public  void  Screen_shot (string _path = null , int _compress_w = 1920 , int _compress_h = 1080){

            Mono_instancia.Start_coroutine(a());
            return;
    
             IEnumerator a(){

                        yield return new WaitForEndOfFrame();        

                        string path =  _path != null ? _path : System.IO.Directory.GetCurrentDirectory() + "\\Assets\\Resources\\images\\in_game\\teste_imagem_compress.png" ;
            
                        int  compress_w = _compress_w;
                        int  compress_h = _compress_h;

                        Texture2D texture = new Texture2D(Screen.width, Screen.height  ,  TextureFormat.ARGB32, false );

                        texture.ReadPixels(    new Rect(0,0,Screen.width, Screen.height)    ,  0 , 0 );
                        texture.Apply();

                        int image_w = texture.width;
                        int image_h = texture.height;
                        
                        Texture2D texture_compress = new Texture2D(  compress_w , compress_h  );

                        int pular_h = 0;
                        int pular_w = 0;

                        int image_h_final = 0;
                        int image_w_final = 0;

            
                        if(  ( (float)  ( (float)image_h  /  (float) image_w) )    > 0.5625f){

                              image_h_final =    Convert.ToInt32((float) image_w * 0.5625f);
                              image_w_final =    image_w;

                              pular_h =  Convert.ToInt32 ( (float)( image_h - image_h_final ) / 2f );
                              pular_w = 0;

                        }  else{


                              image_w_final = Convert.ToInt32( (float) image_h * 1.7777f);
                              image_h_final = image_h;

                              pular_w = Convert.ToInt32 (  (float) (    image_w - image_w_final) / 2f  );
                              pular_h =   0;
            
                        }
                  
                        int I_H = pular_h;
                        int I_W = pular_w;
            

                        for(   int i_h =0  ;    i_h  <  compress_h  ;    i_h++    ){

                              I_H =   (pular_h ) +  (int)   (   (float) i_h *  (  (float) (image_h_final)/  (float)  compress_h) )  ;

                              for( int i_w = 0;   i_w < compress_w  ;i_w++  ){

                                    I_W = pular_w   +   (int)   (   (float) i_w  *  ( (float) (image_w_final)  / (float) compress_w) )  ;
                                    texture_compress.SetPixel(   i_w, i_h,  (Color)  texture.GetPixel(   I_W  ,  I_H )  );

                              }
                        }
                  
                        File.Delete(path);
                        File.WriteAllBytes (  path  , texture_compress.EncodeToPNG()) ; 

                        yield break;

      }
        

      }

 

    

      
      // public void Salvar(  int _save  ){

      //       throw new ArgumentException("por hora não é para salvar");

      // }

      

      // public void Carregar( int _save ){



      // }

      


 
    public void Carregar_save(  int _save = -1 ){

            return;

             


    }








    public string IntArr_to_string(int[] arr){

       if(arr.Length == 0) return "";
        
        string final = "";

        for(  int i = 0 ; i < arr.Length - 1 ; i++ ){

           final = final + arr[i].ToString() + ",";

        }


        final = final + arr[arr.Length -1 ].ToString();

        return final;

    }


    public int[] ToIntArr(string line){

        if(line == "") return new int[0];

        string[] arr = line.Split(",");
   
        int n = arr.Length;
        int[] retorno = new int[n];
       
        for(int i = 0  ;  i< n ;i++ ){
           
              retorno[i] = Convert.ToInt32(arr[i]);

        }

       return retorno;
   
    }

    public Interativo_nome[] ToInterativosArr(string line){

        if(line == "") return new Interativo_nome[0];

        string[] arr = line.Split(",");
   
        int n = arr.Length;

        Interativo_nome[] retorno = new Interativo_nome[n];
       
        for(int i = 0  ;  i< n ;i++ ){
           
            retorno[i] =  (Interativo_nome) Convert.ToInt32(arr[i]);

        }

       return retorno;
   
    }



    
   
        public Personagem_nome[] To_personagens_nome_arr(string line){

        if(line == "") return new Personagem_nome[0];

        string[] arr = line.Split(",");
   
        int n = arr.Length;
        Personagem_nome[] retorno = new Personagem_nome[n];
       
        for(int i = 0  ;  i< n ;i++ ){
           
              retorno[i] =  (Personagem_nome) Enum.Parse(  typeof(Personagem_nome) , arr[i]  );
              

        }

       return retorno;
   
    }


}



