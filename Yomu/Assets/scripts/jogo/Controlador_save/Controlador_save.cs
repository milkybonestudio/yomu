
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;




public class Controlador_arquivos {


            public static Controlador_arquivos instancia;
            public static Controlador_arquivos Pegar_instancia(){ return instancia; }
            public static Controlador_arquivos Construir( int _save, bool _novo_jogo ){ instancia = new Controlador_arquivos(  _save, _novo_jogo ); return instancia;}


            public Controlador_arquivos( int _save, bool _novo_jogo ){}
      
      
            // sempre fechar quando nao estiver usando 
            // pegar a quantidade para cada operação 




            public StreamReader[] leitor_arquivo ;
            public StreamReader arquivo_de_controle ;



            // salvar arquivos eu nao quero que seja no multithread para não almentar muito a complexidade. 
            // talvez seja necessario mas quando?
            public void Salvar_arquivos( byte[][] _arquivos_arr_byte_arr , string[] _paths ){


            }




}



/*



      ( evento ) => (

            add personagens : (

                  lily_id, container, tipo, id_evento

            )

      )



*/




public class Controlador_save {


      /*

            talvez dados gerais nao precise de nada? 

            genericos tem somente updates que geralmente só escondem os personagens 

            update(){

                  switch( dia_semana ){

                        case segunda: {


                              switch( periodo ){

                                    case manha: {

                                          mov( Ponto_nome.quarto_lily )



                                    }

                              }

                        }

                  }


                  mov( Ponto_nome.Esconder )


            }

            

      
      */


      /*
            1mb parece um absurdo até que nao seja 

            O personagem vai ter dados o suficiente para funcionar no modelo que ele esta
            O unico momento que ele vai poder pegar dados é:

                   - para updates programaveis (tempo)
                   - trocas de rank que não precisam ser no mesmo frame e podem esperar.
                   - conversas 
            
      */




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



      /*


            problema : o jogo precisa ser salvo a todo momento 
            porque? : o player vai fazer muitas escolhas, e eu quero que essa escolhas tenha mais peso 

            preciso confirma: quanto tempo leva para mudar um arquivo de texto e fazer uam relacao de quantidade x tamanho 


            carregar : 
              - alem de carregar os dados normalmente ele vai precisar também verificar se existe algum arquivo que estava sendo salvo. 

                  precisa levar em conta que o computador pode desligar no meio por nenhum motivo e que salvar tem um custo de processamento. 
                  o jogo vai ficar salvando algo em torno de 1 vez por minutos e sempre que o player sair. 
                  para isso seria interessante salvar partes de arquivos de cada vez                
                arquivo_1.dat

            salvar: 
               - tem 2 tipos de salvar : run_time e save_de_morte
               save run_time vai ser 



            ** save vai ficar responsavel por transformar logica em bytes e saber como descompactar 
      
      */

            
            public static Controlador_save instancia;
            public static Controlador_save Pegar_instancia(){ return instancia; }
            public static Controlador_save Construir( int _save, bool _novo_jogo ){ instancia = new Controlador_save( _save, _novo_jogo ); return instancia;}

            public Controlador_save( int _save, bool _novo_jogo ){


                        if( _novo_jogo ){

                              // copiar arquivos que vão estar em path_mutaveis ** definir 
                              
                              Copiar_arquvios_do_novo_jogo( _save );

                        }


                        // tudo aqui vai ser instanciado na multithread 

                        // nao consomem tempo
                        Dados_blocos.Construir();
                        Controlador_timer.Construir();


                        Controlador_dados_dinamicos.Construir();
                        
                        Player_estado_atual.Construir();
                        Controlador_UI.Construir();
                        Controlador_transicao.Construir();




                        // no final vai ter algum Script_retorno.start( byte[] ) ou algo 
                        // quando esse retunr for ativado a tela vai começar a aparecer já no novo modo 



            }


            public void Copiar_arquvios_do_novo_jogo( int _save ){

                  // acho que seria melhor colocar somente os personagens principais 
                  // Poderia ter uma funcao Adicionar_personagem 
                  // mas os dados genericos ainda estariam no geral

                  string path_save_para_salvar = Paths_gerais.Pegar_path_folder_dados_save( _save );
                  string path_com_os_dados = Paths_gerais.Pegar_path_folder_com_os_saves_defaults();


            }





    public void Criar_dados_iniciais_personagens( int _save ){

            /*
                a unica coisa de dados_sistema que precisa ter realmente dados fixos é onde que o personagem começa 
                talvez eu faça uma lista com os dados e o resto é criado tudo por default 

            */



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



        // assume que a pasta já existe 
        // testei e já funciona corretamente
        public void Copiar_pasta_inteira(  string _local_para_salvar,  string _local_para_copiar ){

                    Debug.Log( $"pasta para salvar: { _local_para_salvar }" );

                
                
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












      

      public bool is_saving = false;


      

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

 

      public Sprite Pegar_sprite_png ( string path ) {
  
  
            byte[] byte_arr; 
            byte_arr = System.IO.File.ReadAllBytes (path); 
            // esta no formato mais lentos
            Texture2D tex = new Texture2D(1,1); 
            tex.LoadImage( byte_arr );

            return Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

   
      }

      

    
      public void Update(){



      }

      
      public void Salvar(  int _save  ){

            throw new ArgumentException("por hora não é para salvar");

      }

      

      public void Carregar( int _save ){



      }

      



      public void Salvar_save_new_thread(int _save, string _path_imagem  , CancellationTokenSource _cancelar = null ){


           // Debug.Log("thread ativada");

            is_saving = true;

           
        
            System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();
         
            if(_save > 6 || _save< 0) throw new ArgumentException("nao veio numero save aceitavel");


            string path_raiz = Controlador_data.Pegar_instancia().Pegar_path_raiz();


            string path_default = path_raiz + "/saves/save_default.txt";
            string path_salvar = path_raiz + "/saves/save_" + _save.ToString() + ".txt";
            string path_SALVANDO = path_raiz + "/saves/SALVANDO_save_" + _save.ToString() + ".txt";
        
       
            StreamReader r = new StreamReader(  path_default  );
            StreamWriter w = new StreamWriter(  path_SALVANDO   );
        
            // bool ler_linhas = false;
            // bool ler_divisao = false;

            // string key;
            // string value;


            Player_estado_atual player_estado_atual = Player_estado_atual.Pegar_instancia();
            Controlador_personagens_ controlador_personagens = Controlador_personagens_.Pegar_instancia();



            // w.WriteLine(r.ReadLine());
            // w.WriteLine(r.ReadLine());
      
            // w.WriteLine(r.ReadLine());
            // w.WriteLine(  IntArr_to_string( player_estado_atual.posicao_arr ) );r.ReadLine();

            // w.WriteLine(r.ReadLine());
            // w.WriteLine( IntArr_to_string(player_estado_atual.interativos) );r.ReadLine();

            // w.WriteLine(r.ReadLine());
            // w.WriteLine(player_estado_atual.dinheiro.ToString());r.ReadLine();

            // w.WriteLine(r.ReadLine());
            // w.WriteLine(  IntArr_to_string(player_estado_atual.mochila) );r.ReadLine();

            // w.WriteLine(r.ReadLine());
            // w.WriteLine(  IntArr_to_string(player_estado_atual.bau) );r.ReadLine();

            // w.WriteLine(r.ReadLine());
            // w.WriteLine(player_estado_atual.sadismo.ToString());r.ReadLine();


            // w.WriteLine(r.ReadLine());


            // //personagens
       
       
            // w.WriteLine(r.ReadLine());
            // w.WriteLine(r.ReadLine());
 
            // // lily
            // w.WriteLine(r.ReadLine());

            // w.WriteLine(r.ReadLine()); 
            // w.WriteLine(controlador_personagens.personagens.lily.relacoes.sara.tesao.ToString());r.ReadLine();

            // w.WriteLine(r.ReadLine());       
            // w.WriteLine(controlador_personagens.personagens.lily.relacoes.sara.amizade.ToString());r.ReadLine();

            // w.WriteLine(r.ReadLine());       
            // w.WriteLine(controlador_personagens.personagens.lily.relacoes.sara.amor.ToString());r.ReadLine();

            // w.WriteLine(r.ReadLine());       
            // w.WriteLine(controlador_personagens.personagens.lily.relacoes.sara.odio.ToString());r.ReadLine();



            // w.WriteLine(r.ReadLine());
            // w.WriteLine(r.ReadLine());



    
            // // dia
            // w.WriteLine(r.ReadLine());

            // w.WriteLine(r.ReadLine()); 
            // w.WriteLine(controlador_personagens.personagens.dia.relacoes.sara.tesao.ToString());r.ReadLine();

            // w.WriteLine(r.ReadLine());        
            // w.WriteLine(controlador_personagens.personagens.dia.relacoes.sara.amizade.ToString());r.ReadLine();

            // w.WriteLine(r.ReadLine());        
            // w.WriteLine(controlador_personagens.personagens.dia.relacoes.sara.amor.ToString());r.ReadLine();

            // w.WriteLine(r.ReadLine());        
            // w.WriteLine(controlador_personagens.personagens.dia.relacoes.sara.odio.ToString());r.ReadLine();




            // w.WriteLine(r.ReadLine());
            // w.WriteLine(r.ReadLine());

            // // jayden
            // w.WriteLine(r.ReadLine());

            // w.WriteLine(r.ReadLine());
            // w.WriteLine(controlador_personagens.personagens.jayden.relacoes.sara.tesao.ToString());r.ReadLine();
            // w.WriteLine(r.ReadLine());       
            // w.WriteLine(controlador_personagens.personagens.jayden.relacoes.sara.amizade.ToString());r.ReadLine();
            // w.WriteLine(r.ReadLine());       
            // w.WriteLine(controlador_personagens.personagens.jayden.relacoes.sara.amor.ToString());r.ReadLine();
            // w.WriteLine(r.ReadLine());       
            // w.WriteLine(controlador_personagens.personagens.jayden.relacoes.sara.odio.ToString());r.ReadLine();


            // w.WriteLine(r.ReadLine());
            // w.WriteLine(r.ReadLine());

            // r.Close();
            // w.Close();

            timePerParse.Stop();

            long ticksThisTime = timePerParse.ElapsedMilliseconds;

            Debug.Log("tempo 1: " + (ticksThisTime) + "ms");

           

             
           File.Delete(path_salvar);


           File.Move(   path_SALVANDO  ,   path_salvar    );
          
           int trava_seguranca = 0;

           //Debug.Log("thread ativada 2");

           while( true ){
                
                if(trava_seguranca > 5 * 10) throw new ArgumentException("imagem do save nao foi salva no intervalo determinado maximo");

                Debug.Log(File.Exists(_path_imagem));

                if(File.Exists(_path_imagem)) break;

                Debug.Log("deu sleep");
                 
                 Thread.Sleep(200);

           }
           

      is_saving = false;

     // Thread.CurrentThread.Join();

      







        }

        






    public int save_para_carregar = 0;   
 
    public void Carregar_save(int _save = -1){

            return;

             
      
     
            // if(save_para_carregar == 0){

            //       // se precisar fazer algo no novo_jogo

            //       Controlador.Pegar_instancia().controlador_scripts_controlador.Ativar_script(0);
            //       return;

            // }

            // save_para_carregar = _save;
            


            // string path = Controlador_data.Pegar_instancia().Pegar_path_raiz() + "/saves/save_" + _save + ".txt";

            

            // if(!File.Exists(path))   throw new ArgumentException("tentou carregar um save que nao existe, numero: " + _save);

            
            

            // StreamReader r = new StreamReader(  path  );
      
            // bool ler_linhas = false;
            // bool ler_divisao = false;

            // string key;
            // string value;



            


            // void ler(){
            // if(ler_divisao){
            //       Debug.Log(r.ReadLine());
            // }
            // else {
            //       r.ReadLine();
            // }
            // return;
            // }

            // string line(){




            //       if(ler_linhas) { 

            //       key = r.ReadLine();
            //       value = r.ReadLine();
                  
            //             Debug.Log (  key + " : " + value);
            //             return value.Trim();

            //       } else {   
                  
            //       r.ReadLine() ; 
            //       return  r.ReadLine().Trim();

            //       } ;


                  

                  


            // //#if UNITY_EDITOR 
            // // #else 

            // //  return  r.ReadLine().Trim();

            // // #endif




                  
            // }


            // Player_estado_atual player_estado_atual = Player_estado_atual.Pegar_instancia();
            // Controlador_personagens controlador_personagens = Controlador_personagens.Pegar_instancia();

            /*

            esses 2 primeiros blocos vão isntanciar cenas e o jogo, controlador_save pode usar controaldor_tela direto pelo controaldor: controlador.jogo_BLOCO.controlador_tela_jogo.background e bla bla bla


            */


            ///----------------------------
            // estado_atual      


            // try{

            // ler();
            // r.ReadLine();
      
            // player_estado_atual.posicao_arr = ToIntArr( line() );

            // player_estado_atual.interativos = ToIntArr( line() );

            // player_estado_atual.dinheiro = Convert.ToInt32( line()  );

            // player_estado_atual.mochila = ToIntArr( line() );

            // player_estado_atual.bau = ToIntArr( line() );

            // player_estado_atual.sadismo =Convert.ToSingle( line() );

            
          
            // player_estado_atual.ponto_atual.ponto_nome = (Ponto_nome) Convert.ToInt32( line() );
            // player_estado_atual.ponto_atual.folder_path = line();

            // player_estado_atual.ponto_atual.ponto_flip = Convert.ToInt32( line() );

            // player_estado_atual.ponto_atual.background_name = line();

            // player_estado_atual.ponto_atual.interativos_nomes  =  ToInterativosArr( line() );


            // player_estado_atual.ponto_atual.personagens_no_ponto = To_personagens_nome_arr( line() ) ;

            // player_estado_atual.ponto_atual.script_entrada = Convert.ToInt32( line() );

            // r.ReadLine();



            // ///----------------------------

            // //   CENAS



            // ///----------------------------



            // //personagens
            // ler();
            // r.ReadLine();
      
            // // lily
            // ler();

            // controlador_personagens.personagens.lily.relacoes.sara.tesao = Convert.ToSingle(  line()  );
            // controlador_personagens.personagens.lily.relacoes.sara.amizade = Convert.ToSingle(  line()  ); 
            // controlador_personagens.personagens.lily.relacoes.sara.amor = Convert.ToSingle(  line()  );
            // controlador_personagens.personagens.lily.relacoes.sara.odio = Convert.ToSingle(  line()  );

            // ler();
            // r.ReadLine();



      
            // // dia
            // ler();

            // controlador_personagens.personagens.dia.relacoes.sara.tesao = Convert.ToSingle(  line()  );
            // controlador_personagens.personagens.dia.relacoes.sara.amizade = Convert.ToSingle(  line()  ); 
            // controlador_personagens.personagens.dia.relacoes.sara.amor = Convert.ToSingle(  line()  );
            // controlador_personagens.personagens.dia.relacoes.sara.odio = Convert.ToSingle(  line()  );


            // ler();
            // r.ReadLine();


            


            // // jayden
            // ler();

            // controlador_personagens.personagens.jayden.relacoes.sara.tesao = Convert.ToSingle(  line()  );
            // controlador_personagens.personagens.jayden.relacoes.sara.amizade = Convert.ToSingle(  line()  ); 
            // controlador_personagens.personagens.jayden.relacoes.sara.amor = Convert.ToSingle(  line()  );
            // controlador_personagens.personagens.jayden.relacoes.sara.odio = Convert.ToSingle(  line()  );


            // ler();
            // r.ReadLine();




            // Debug.Log("a: " + controlador_personagens.personagens.jayden.relacoes.sara.tesao );




            // r.Close();


            // } catch (Exception e){
            //       Debug.Log(e);
            //       Debug.Log("teve um erro");
            // }


      




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



