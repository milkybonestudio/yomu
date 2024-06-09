
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;




public enum Modo_save_atual {


      nada,
      salvando_primeiro_plano,
      salvando_segundo_plano

}

public class Controlador_save {


            
            public static Controlador_save instancia;
            public static Controlador_save Pegar_instancia(){ return instancia; }

            
            public static bool esta_em_teste = false;

            
            public System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding( true );






            public string path_save_folder; 
            public string path_dados_sistema;
            public string path_dados_personagens;

            public Modo_save_atual modo_save_atual = Modo_save_atual.nada;

            public int tamanho_dados_sistema = 10_000; // numero de personagens * 

            public byte[][] dados_para_salvar;

            public Controlador_save_personagens controlador_save_personagens;
            public Controlador_instrucoes_de_seguranca controlador_instrucoes_de_seguranca;




            public Task_req task_salvar;
            public bool esta_salvando_container = false ;  
            public bool esta_esperando_multithread = false ;



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

                  Controlador_save controlador = new Controlador_save(); 
                  

                        if( _save > 5 ) 
                              { throw new Exception( "tentou carregar save " + _save.ToString() ); }


                        if( _novo_jogo )
                              { 

                                    // copiar arquivos que vão estar em path_mutaveis ** definir
                                    controlador.Copiar_arquvios_do_novo_jogo( _save );

                              }

                        // ** nao faz sentido eu pensar em salvar sem ter o formato dos arquivos 

                        
                        // tudo aqui vai ser instanciado na multithread 
                        // nao consomem tempo

                        Dados_blocos.Construir();
                        Controlador_timer.Construir();

                        Controlador_dados_dinamicos.Construir();
                        
                        Controlador_UI.Construir();
                        Controlador_transicao.Construir();


                        // ---- USO SAVE

                        controlador.path_save_folder = Paths_gerais.Pegar_path_folder_dados_save( _save );
                        controlador.path_dados_sistema = controlador.path_save_folder + "/Dados_programa/dados_programa.dat";
                        controlador.path_dados_personagens = controlador.path_save_folder + "/Personagens/";
                        

                        controlador.controlador_save_personagens = new Controlador_save_personagens(); 

                        controlador.controlador_instrucoes_de_seguranca = new Controlador_instrucoes_de_seguranca();
                        controlador.controlador_instrucoes_de_seguranca.Verificar_arquivo_das_instrucoes_de_seguranca();
                        controlador.controlador_instrucoes_de_seguranca.Renovar_arquivo_das_instrucoes();

                  




                        // ----- SISTEMA

                        if( System.IO.File.Exists( controlador.path_dados_sistema ) )
                              { throw new Exception( $"dados_programa.dat nao foi encontrado no path{ path_dados_sistema }"); }


                        byte[] dados_sistema = System.IO.File.ReadAllBytes( path_dados_personagens.path_dados_sistema );


                        // esses dados vão ser colocados nos lugares mais adequados
                        Dados_sistema_personagem_essenciais[] dados_sistema_personagens_necessario = Tradutor_dados_sistema.Descompactar_dados_sistema_personagens_necessarios( dados_sistema );
                        Dados_sistema_cidade_essenciais[] dados_sistema_cidade_essenciais = Tradutor_dados_sistema.Descompactar_dados_sistema_cidades_necessarios( dados_sistema );
                        Dados_sistema_estado_atual dados_sistema_estado_atual = Tradutor_dados_sistema.Descompactar_dados_sistema_atual( dados_sistema );
                        // Coisa_2[] coisa_2 = Tradutor_save.Descompactar_dados_sistema_Coisa_2( dados_sistema );
                        // Coisa_3[] coisa_3 = Tradutor_save.Descompactar_dados_sistema_Coisa_3( dados_sistema );
                        // Coisa_4[] coisa_4 = Tradutor_save.Descompactar_dados_sistema_Coisa_4( dados_sistema );
                        // ....



                        // ----- PLAYER  
                        



                        // ---- PERSONAGENS


                        

                        Controlador_personagens.Construir( dados_sistema_personagens_necessario, _save ); 



                        // personagem.Mudar_valores( thing, novo_valor ); => ativa Controlador_personagem => entrega_valores_para_update 

                        // thing_1()
                        // thing_2()
                        // ...

                        // Controlador_save.Update() => pega dados Controlador_personagens

                        // Player_estado_atual.Construir(  ); ** talvez eu tenha que passar o save também 




                  instancia = controlador;

                  return instancia;


            }




            public int frame = 0;
            public int espacamento = 10;
            public void Update(){


                  // quando estiver em teste nao vai deixar salvar      
                  if( esta_em_teste ) 
                        { return ;}


                  // ** vai ser chamado a cada 10 frames 

                  frame = ( frame + 1 ) % espacamento ;
                  if( frame  == 0 )
                        {
                              // Main thread
                              // garante que todos os arquivos das instrucoes de seguranca esstao atualizados 
                              Controlador_instrucoes_de_seguranca.Pegar_instancia().Update(); 
                              return;
                        } 

                                    

                  if( modo_save_atual == Modo_save_atual.nada ) 
                        { 
                              if( frame == 5 )
                                    {
                                          Verificar_arquivos_para_salvar();
                                    }
                              return;
                        }


                        
                  if( ! ( task_salvar.finalizado ) ) 
                        { return; }


                  switch( modo_save_atual ){

                        case Modo_save_atual.salvando_primeiro_plano: Salvar_primeiro_plano_update(); break;
                        case Modo_save_atual.salvando_primeiro_plano: Salvar_segundo_plano_update();  break;

                  }









                  // #if UNITY_EDITOR

                  //       if( Config.salvar_arquivos_instrucoes_de_segurança )
                  //             {
                  //                   string path_folder_para_analisar = Application.dataPath + "/colocar_depois";

                  //             }


                  // #endif

                  


            }


            public void Verificar_arquivos_para_salvar(){

                  // verificar primario

                  if( controlador_instrucoes_de_seguranca.index_byte_instrucoes_de_seguranca_1 > 200_000 )
                        {
                              // vai iniciar salvar primario

                              modo_save_atual = Modo_save_atual.salvando_segundo_plano;
                              controlador_save_personagens.Iniciar_salvar_primeiro_plano();
                              return;

                        }


                  // salva segundo plano 
                  // ** segundo plano sempre vai ter algo para salvar, mas ele vai ser salvo mais lentamente 

                  if( controlador_ )

                  modo_save_atual = Modo_save_atual.salvando_segundo_plano;
                  return;

                  
            }


            
            public bool Salvar_primeiro_plano_update(){

                  // quando for iniciar o salvar sempre tem que criar a task 


                  bool dados_para_salvar = false;

                  
                  tem_dados_para_salvar = controlador_save_personagens.Verificar_se_tem_personagens_para_salvar();
                  if( tem_dados_para_salvar ) 
                        { return ; }




                  esta_salvando_container = false;
                  return;



            }



            
            public bool Salvar_segundo_plano_update(){

                  // o segundo plano vai ser um pouco diferente 
                  // ele sempre tem uma quantidade de cidades na ram com uma em foco
                  // as cidades vizinhas 


                  bool dados_para_salvar = false;

                  
                  tem_dados_para_salvar = controlador_save_personagens.Verificar_se_tem_personagens_para_salvar();
                  if( tem_dados_para_salvar ) 
                        { return ; }




                  esta_salvando_container = false;
                  return;



            }



            



            public void Iniciar_salvar(){

                  // só vai ser chamada quando a quantidade de dados no buffer passar de 200kb

                  int[] personagens_ids =  controlador_save_personagens.Iniciar_salvar();

            }


            public void Salvar_multithread( Action fn ){


            }


            public void Criar_task_salvar_dados( string _path , byte[] _dados ){

                  
                  task_salvar = new Task_req( new Chave_cache() , "salvando arquivos" );

                  task_salvar.fn_iniciar =  () => {

                        string path_temp = ( _path + ".temp" ) ;
                        string path_temp_save = ( _path + ".2.temp" );

                        //System.IO.File.Create(  path_temp , _dados.Length, FileOptions.WriteThrough );
                        System.IO.File.WriteAllBytes( path_temp , _dados  );

                        FileMode file_mode = FileMode.Open;
                        FileAccess file_accees = FileAccess.ReadWrite;
                        FileShare file_share = FileShare.Read;
                        FileOptions file_options = FileOptions.WriteThrough;

                        FileStream str = new FileStream(  path_temp,  file_mode, file_accees , file_share, _dados.Length , file_options );

                        str.Flush();
                        str.Close();


                        // muda o nome do antigo
                        System.IO.File.Move(  _path , path_temp_save );

                        // coloca o nome correto 
                        System.IO.File.Move(  _path_temp , _path  );

                        // deleta o save
                        System.IO.File.Delete( path_temp_save );

                  
                        return;

                  };



                  Controlador_multithread.Pegar_instancia().Adicionar_task( task_salvar );

                  return;

            }




                        

























            public void Copiar_arquvios_do_novo_jogo( int _save ){


                        // ** TIRAR DEPOIS 
                        return;

                        
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



