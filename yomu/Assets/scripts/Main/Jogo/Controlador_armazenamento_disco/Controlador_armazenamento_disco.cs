
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Controlador_armazenamento_disco {

            
        public static Controlador_armazenamento_disco instancia;
        public static Controlador_armazenamento_disco Pegar_instancia(){ return instancia; }

        
        public MODULO__gerenciador_instrucoes_de_seguranca modulo_gerenciador_instrucoes_de_seguranca;
        public System.Text.UTF8Encoding encoder;


        public Modo_save modo_save_atual = Modo_save.DEFAULT;
        public static bool esta_em_teste = false;

        // ** quando for realmente salvar todos os dados em disco
        public Task_req task_salvar;

        public INTERFACE_buffer[] buffers_dados;


        public int frame = 1;
        public int espacamento = 60;

        public void Update_bloco(){

            // ---> cuidar animacao
            // ---> verificar se terminou 
            // ---> garantir que nao passe muito tempo

        }


        public void Update(){


                // quando estiver em teste nao vai deixar salvar      
                if( esta_em_teste ) 
                    { return ;}


                // animacao??
                if( task_salvar != null )
                    {
                        if( task_salvar.finalizado )
                            { task_salvar = null; }

                        return;
                    }


                frame = ( frame + 1 ) % espacamento ;


                if( frame  == 0 )
                    { modulo_gerenciador_instrucoes_de_seguranca.Salvar_instrucoes_em_disco(); return; } //--- garante que todos os arquivos das instrucoes de seguranca esstao atualizados 

                if( frame == ( espacamento / 3 ) || frame == ( ( espacamento * 2 ) / 3 ) )
                    { Verificar_dados_para_salvar(); } // --- 2 vezes por espacamento

                

                return;

                
        }




        public void Verificar_dados_para_salvar(){

                // // a maior parte das coisas vao ser salvas em grandes blocos, ver exatamente oque pode/precisa ser salvo run time 
                // ** mesmo que esses dados sejam perdidos em ultima analise os dados vão estar salvo nas instrucoes

                for( int coletores_index = 0 ; coletores_index < coletores_dados.Length ; coletores_index++ ){

                        Dados_para_salvar[] dados_para_salvar = coletores_dados[ coletores_index ].Pegar_dados_para_salvar();

                        if( dados_para_salvar == null )
                            { continue; }

                        Criar_task_salvar_dados( dados_para_salvar );
                
                }

        }






        public void Criar_task_salvar_dados( Dados_para_salvar[] _dados_pedidos ){


                Garantir_dados_para_salvar( _dados_pedidos ); // 0.2ms/file => 2ms 10 - files  => 10ms( 50 files )

                
                task_salvar = new Task_req(  "salvando arquivos" );

                task_salvar.fn_multithread =  ( Task_req _req ) => {


                    for( int pedido_index = 0 ; pedido_index < _dados_pedidos.Length ; pedido_index++ ){

                            Dados_para_salvar dados_para_salvar = _dados_pedidos[ pedido_index ];

                            string path = dados_para_salvar.path;
                            byte[] dados = dados_para_salvar.dados;

                            if( path == null )
                                { continue; }

                            

                            string path_temp_arquivo_NOVO = ( path + ".temp" ) ;
                            string path_temp_arquivo_ANTIGO = ( path + ".2.temp" );

                            System.IO.File.WriteAllBytes( path_temp_arquivo_NOVO , dados  );

                            FileStream str = FILE_STREAM.Criar_stream( _path: path_temp_arquivo_NOVO, _tamanho_buffer: 0 );

                            str.Flush();
                            str.Close();


                            // muda o nome do antigo
                            System.IO.File.Move(  path , path_temp_arquivo_ANTIGO );

                            // coloca o nome correto 
                            System.IO.File.Move(  path_temp_arquivo_NOVO , path  );

                            // deleta o save
                            System.IO.File.Delete( path_temp_arquivo_ANTIGO );


                    }

                
                    return;

                };



                Controlador_tasks.Pegar_instancia().Adicionar_task( task_salvar );

                return;

        }


            private void Garantir_dados_para_salvar( Dados_para_salvar[] _dados ){

                    for( int dados_index = 0 ; dados_index < _dados.Length ; dados_index++ ){
    
                        Dados_para_salvar dados_para_salvar = _dados[ dados_index ];
                        if ( dados_para_salvar.path == null )
                            { continue; }

                        if( !!!( System.IO.File.Exists( dados_para_salvar.path ) ) )
                            { throw new Exception( $"nao foi achado o arquivo no path { dados_para_salvar.path }" ); }
                        
                        if( dados_para_salvar.dados == null )
                            { throw new Exception( $"nao veio os dados do arquivo no path { dados_para_salvar.path }. veiV null" ); }

                    }


            }


            //mark
            // --- isso precisa estar em dev
            public void Criar_arquivos_novo_jogo( int _save ){

                  // ** fazer depois
                  throw new Exception( "nao era para vir aqui" );

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



