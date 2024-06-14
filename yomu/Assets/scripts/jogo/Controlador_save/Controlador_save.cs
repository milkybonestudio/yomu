
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;




public class Controlador_save {

            
            public static Controlador_save instancia;
            public static Controlador_save Pegar_instancia(){ return instancia; }

            
            public Controlador_instrucoes_de_seguranca controlador_instrucoes_de_seguranca;
            public System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding( true );


            public Modo_save modo_save_atual = Modo_save.DEFAULT;
            public static bool esta_em_teste = false;

            public Task_req task_salvar;


            public static Controlador_save Construir_teste (){

                        // vai ser executado na main thread
                        esta_em_teste = true;

                        Controlador_save controlador = new Controlador_save(); 
                              
                              Dados_blocos.Construir();
                              Controlador_timer.Construir_teste( null );
                              Controlador_dados_dinamicos.Construir_teste( null );

                              Controlador_UI.Construir();
                              Controlador_transicao.Construir();

                              Player_estado_atual.Construir();

                              
                              // nao vai construir nenhum personagem além da nara
                              TESTE_controlador_personagens.Construir_controlador();
                              TESTE_controlador_cidades.Construir_controlador();
                              TESTE_controlador_plots.Construir_controlador();

                        instancia = controlador;
                        return controlador;

            }



            public static Controlador_save Construir( int _save, bool _novo_jogo ){

                  // ** TUDO NA MULTITHREAD

                  throw new Exception( "ainda nao esta pronto" );


                  Controlador_save controlador = new Controlador_save(); 

                        // --- USO GERAL 

                        Paths_sistema.Colocar_save( _save );


                        // --- VERIFICACOES DE SEGURANCA
                  
                        if( _save > 5 ) 
                              { throw new Exception( "tentou carregar save " + _save.ToString() ); }

                        if( _novo_jogo )
                              { controlador.Criar_arquivos_novo_jogo( _save ); }

                        if( ! ( System.IO.File.Exists( Paths_sistema.path_dados_sistema ) ) )
                              { throw new Exception( $"dados_programa.dat nao foi encontrado no path { Paths_sistema.path_dados_sistema }"); }

                        
                        

                        // --- USAO EXCLUSIVO SAVE
                        Controlador_instrucoes_de_seguranca.Construir();


                        // --- DADOS SISTEMA

                        // dados_sistema => dados essencias entidades, estado atual 
                        byte[] dados_sistema = System.IO.File.ReadAllBytes( Paths_sistema.path_dados_sistema );
                        Dados_sistema_estado_atual dados_sistema_estado_atual = Tradutor_dados_sistema.Descompactar_dados_sistema_estado_atual( dados_sistema );


                        // --- ENTIDADES

                              // --- personagens
                              Dados_sistema_personagem_essenciais[] dados_sistema_personagens_essenciais = Tradutor_dados_sistema.Descompactar_dados_sistema_personagens_essenciais( dados_sistema );
                              Controlador_personagens.Construir( dados_sistema_personagens_essenciais, dados_sistema_estado_atual ); 

                              // --- cidades
                              Dados_sistema_cidade_essenciais[] dados_sistema_cidades_essenciais = Tradutor_dados_sistema.Descompactar_dados_sistema_cidades_essenciais( dados_sistema );
                              Controlador_cidades.Construir( dados_sistema_cidades_essenciais, dados_sistema_estado_atual ); 

                              // --- plots
                              Dados_sistema_plot_essenciais[] dados_sistema_plots_essenciais = Tradutor_dados_sistema.Descompactar_dados_sistema_plots_essenciais( dados_sistema );
                              Controlador_plots.Construir( dados_sistema_plots_essenciais, dados_sistema_estado_atual ); 


                        // --- SISTEMA
                        Controlador_dados_sistema.Construir( dados_sistema_estado_atual ); // constroi player


                        Controlador_timer.Construir( dados_sistema_estado_atual );
                        Controlador_dados_dinamicos.Construir( dados_sistema_estado_atual );
                        


                  instancia = controlador;

                  return instancia;


            }


            public int frame = 0;
            public int espacamento = 60;

            public void Update(){


                        // quando estiver em teste nao vai deixar salvar      
                        if( esta_em_teste ) 
                              { return ;}


                        frame = ( frame + 1 ) % espacamento ;

                        // ** vai ser chamado a cada 1 vez por segundo 
                        if( frame  == 0 )
                              {
                                    // Main thread
                                    // garante que todos os arquivos das instrucoes de seguranca esstao atualizados 
                                    controlador_instrucoes_de_seguranca.Update( modo_save_atual ); 
                                    return;
                              } 


                        if( task_salvar != null )
                              {
                                    if(  task_salvar.finalizado  )
                                          { task_salvar = null; }

                                    return;
                              }

                        
                        if( frame != 30 )
                              { return; }

                        Verificar_dados_para_salvar();

                        return;

                  
            }




            public void Verificar_dados_para_salvar(){


                        Dados_para_salvar dados_entidade_para_salvar = null; 

                        // --- PERSONAGENS
                        dados_entidade_para_salvar =  Controlador_personagens.Pegar_instancia().gerenciador_save.Pegar_personagem_para_salvar( modo_save_atual );
                        if( dados_entidade_para_salvar != null )
                              { 
                                    Criar_task_salvar_dados( dados_entidade_para_salvar ); 
                                    return;
                              }

                        // --- CIDADES

                        dados_entidade_para_salvar =  Controlador_cidades.Pegar_instancia().gerenciador_save.Pegar_cidade_para_salvar( modo_save_atual );
                        if( dados_entidade_para_salvar != null )
                              { 
                                    Criar_task_salvar_dados( dados_entidade_para_salvar ); 
                                    return;
                              }

                  
                        // --- PLOTS

                        dados_entidade_para_salvar =  Controlador_plots.Pegar_instancia().gerenciador_save.Pegar_plot_para_salvar( modo_save_atual );
                        if( dados_entidade_para_salvar != null )
                              { 
                                    Criar_task_salvar_dados( dados_entidade_para_salvar ); 
                                    return;
                              }


                        // --- SISTEMA 

                        dados_entidade_para_salvar =  Controlador_dados_sistema.Pegar_instancia().gerenciador_save.Pegar_dados_sistema_para_salvar( modo_save_atual );
                        if( dados_entidade_para_salvar != null )
                              { 
                                    Criar_task_salvar_dados( dados_entidade_para_salvar ); 
                                    return;
                              }


                  
                        return;


            }


            public void Criar_arquivos_novo_jogo( int _save ){

                  // ** fazer depois
                  throw new Exception( "nao era para vir aqui" );

                  return;

            }



            public void Criar_task_salvar_dados( Dados_para_salvar _dados_pedido ){


            
                  string path = _dados_pedido.path;
                  byte[] dados = _dados_pedido.dados;


                  
                  task_salvar = new Task_req( new Chave_cache() , "salvando arquivos" );

                  task_salvar.fn_iniciar =  ( Task_req _req ) => {

                        string path_temp = ( path + ".temp" ) ;
                        string path_temp_save = ( path + ".2.temp" );

                        //System.IO.File.Create(  path_temp , dados.Length, FileOptions.WriteThrough );
                        System.IO.File.WriteAllBytes( path_temp , dados  );

                        FileMode file_mode = FileMode.Open;
                        FileAccess file_accees = FileAccess.ReadWrite;
                        FileShare file_share = FileShare.Read;
                        FileOptions file_options = FileOptions.WriteThrough;

                        FileStream str = new FileStream(  path_temp,  file_mode, file_accees , file_share, dados.Length , file_options );

                        str.Flush();
                        str.Close();


                        // muda o nome do antigo
                        System.IO.File.Move(  path , path_temp_save );

                        // coloca o nome correto 
                        System.IO.File.Move(  path_temp , path  );

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



