
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Controlador_save {

            
            public static Controlador_save instancia;
            public static Controlador_save Pegar_instancia(){ return instancia; }

            
            public Controlador_instrucoes_de_seguranca controlador_instrucoes_de_seguranca;
            public System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding( true );


            public Modo_save modo_save_atual = Modo_save.DEFAULT;
            public static bool esta_em_teste = false;

            public Task_req task_salvar;



            public static Controlador_save Construir( int _save, bool _novo_jogo ){

                  return null ;

                  Controlador_save controlador = new Controlador_save(); 

                        // --- USO GERAL 

                        Paths_sistema.Colocar_save( _save );


                        // --- VERIFICACOES DE SEGURANCA
                  
                        if( _save > 5 ) 
                              { throw new Exception( "tentou carregar save " + _save.ToString() ); }

                        if( _novo_jogo )
                              { controlador.Criar_arquivos_novo_jogo( _save ); }

                        if( ! ( System.IO.File.Exists( Paths_sistema.path_arquivo__dados_dinamicos__uso_completo__dados_sistema ) ) )
                              { throw new Exception( $"dados_programa.dat nao foi encontrado no path { Paths_sistema.path_arquivo__dados_dinamicos__uso_completo__dados_sistema }"); }

                        
                        

                        // --- USAO EXCLUSIVO SAVE
                        Controlador_instrucoes_de_seguranca.Construir();


                        // --- DADOS SISTEMA

                        // dados_sistema => dados essencias entidades, estado atual 
                        byte[] dados_sistema = System.IO.File.ReadAllBytes( Paths_sistema.path_arquivo__dados_dinamicos__uso_completo__dados_sistema );
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
                        Controlador_sistema.Construir( dados_sistema_estado_atual ); // constroi player


                        Controlador_timer.Construir( dados_sistema_estado_atual );
                        
                        


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

                        dados_entidade_para_salvar =  Controlador_sistema.Pegar_instancia().gerenciador_save.Pegar_dados_sistema_para_salvar( modo_save_atual );
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





            public void Copiar_arquivos_do_novo_jogo( int _save ){

                        // *** tem que iniciar o save antes
                        // ** TIRAR DEPOIS 
                        return;

                        
                        // acho que seria melhor colocar somente os personagens principais 
                        // Poderia ter uma funcao Adicionar_personagem 
                        // mas os dados genericos ainda estariam no geral

                        /*

                              a unica coisa de dados_sistema que precisa ter realmente dados fixos é onde que o personagem começa 
                              talvez eu faça uma lista com os dados e o resto é criado tudo por default 

                        */


                        // --- PERSONAGEM

                              // *** vai ter que estar vazio
                              string path_folder_dados_personagens_novo_save = Paths_sistema.path_folder__dados_save_personagens;
                              string path_folder_dados_personagens_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_personagens_MORTE;
                              
                              string path_folder_save_default_personagens = Paths_sistema.path_folder__entidades_para_copiar_novo_save_personagens;


                              // --- COPIA OS DADOS
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_personagens_novo_save, _local_para_copiar : path_folder_save_default_personagens );
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_personagens_novo_save_MORTE, _local_para_copiar : path_folder_save_default_personagens );



                        // --- CIDADES

                              // *** vai ter que estar vazio
                              string path_folder_dados_cidades_novo_save = Paths_sistema.path_folder__dados_save_cidades;
                              string path_folder_dados_cidades_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_cidades_MORTE;
                              
                              string path_folder_save_default_cidades = Paths_sistema.path_folder__entidades_para_copiar_novo_save_cidades;

                              // --- COPIA OS DADOS
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save, _local_para_copiar : path_folder_save_default_cidades );
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save_MORTE, _local_para_copiar : path_folder_save_default_cidades );



                        // --- PLOTS

                              // *** vai ter que estar vazio
                              string path_folder_dados_plots_novo_save = Paths_sistema.path_folder__dados_save_plots;
                              string path_folder_dados_plots_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_plots_MORTE;
                              
                              string path_folder_save_default_plots = Paths_sistema.path_folder__entidades_para_copiar_novo_save_plots;


                              // --- COPIA OS DADOS
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save, _local_para_copiar : path_folder_save_default_plots );
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save_MORTE, _local_para_copiar : path_folder_save_default_plots );



                        // --- BOSSES

                              // *** vai ter que estar vazio
                              string path_folder_dados_bosses_novo_save = Paths_sistema.path_folder__dados_save_bosses;
                              string path_folder_dados_bosses_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_bosses_MORTE;
                              
                              string path_folder_save_default_bosses = Paths_sistema.path_folder__entidades_para_copiar_novo_save_bosses;


                              // --- COPIA OS DADOS
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_bosses_novo_save, _local_para_copiar : path_folder_save_default_bosses );
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_bosses_novo_save_MORTE, _local_para_copiar : path_folder_save_default_bosses );



                        // --- MOBS

                              // *** vai ter que estar vazio
                              string path_folder_dados_mobs_novo_save = Paths_sistema.path_folder__dados_save_mobs;
                              string path_folder_dados_mobs_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_mobs_MORTE;
                              
                              string path_folder_save_default_mobs = Paths_sistema.path_folder__entidades_para_copiar_novo_save_mobs;


                              // --- COPIA OS DADOS
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_mobs_novo_save, _local_para_copiar : path_folder_save_default_mobs );
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_mobs_novo_save_MORTE, _local_para_copiar : path_folder_save_default_mobs );




                        // --- REINOS

                              // *** vai ter que estar vazio
                              string path_folder_dados_reinos_novo_save = Paths_sistema.path_folder__dados_save_reinos;
                              string path_folder_dados_reinos_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_reinos_MORTE;
                              
                              string path_folder_save_default_reinos = Paths_sistema.path_folder__entidades_para_copiar_novo_save_reinos;

                              // --- COPIA OS DADOS
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_reinos_novo_save, _local_para_copiar : path_folder_save_default_reinos );
                              Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_reinos_novo_save_MORTE, _local_para_copiar : path_folder_save_default_reinos );


                        return;


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





      // isso poderia estar em ferramentas 
      public  void  Screen_shot (string _path  , bool _pode_substituir_arquivo,  int _compress_w, int _compress_h ){

            Mono_instancia.Start_coroutine( Screen_shot_c() );
            return;
    
             IEnumerator Screen_shot_c(){

                        yield return new WaitForEndOfFrame();

                        // --- GARANTE QUE PEDIU PARA SALVAR COMO PNG
                        string extensao_do_path = System.IO.Path.GetExtension( _path );
                        if( extensao_do_path != "png" )
                              { throw new Exception( $"a estensao do arqivo { _path } nao veio como png" ); }

                        
                        if( _pode_substituir_arquivo )
                              {
                                    if( System.IO.File.Exists( _path ) )
                                          { File.Delete( _path ); }
                              }
                              else 
                              {
                                    if( System.IO.File.Exists( _path ) )
                                          { throw new System.Exception( $"queria criar um png no path { _path } mas o arquivo já existia" ); }
                              }


                        //string path =  _path != null ? _path : System.IO.Directory.GetCurrentDirectory() + "\\Assets\\Resources\\images\\in_game\\teste_imagem_compress.png" ;
            
                        int  compress_w = _compress_w;
                        int  compress_h = _compress_h;

                        Texture2D texture = new Texture2D( Screen.width, Screen.height  ,  TextureFormat.ARGB32, false );

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

                        byte[] png = texture_compress.EncodeToPNG();
                        File.WriteAllBytes (  _path  , png ) ; 

                        yield break;

      }
        

      }

 

}



