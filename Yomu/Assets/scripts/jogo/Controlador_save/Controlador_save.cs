
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;


/*

controlador_save sempre vai iniciar o modo_tela: jogo, cenas e o modo tela atual se dor diferente (plataforma ou minigames)

*/

/*
-1 -> nada
0  -> iniciar default
1-4 => saves


*/






public class Controlador_save{



    public static Controlador_save instancia;
    public static Controlador_save Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_save")) { instancia = new Controlador_save();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_save(); instancia.Iniciar(); }
            return instancia;

    }

 

  /*
    
    processo para acrescentar variaveis no save: 
      1 : em player_data declarar o tipo como public e com um nome descritivo
      2 : no player_data constructor definir o valor dessa variavel, exemplo: var = controlador.controlador_personagens.personagens.guarda_17.sara.amizade
      3 : aqui em load fazer o caminho inverso:  controlador.controlador_personagens.personagens.guarda_17.sara.amizade =  player_data.var

    para alterar o nome de alguma variavel tem que alterar nas 3 posicoes

    
  */



      

      public bool is_saving = false;

      public void Iniciar(){}




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
            Texture2D tex = new Texture2D(1,1); 
            tex.LoadImage( byte_arr );

            return Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

   
      }

    



      
      public void Salvar_save(  int _save  ){


            throw new ArgumentException("por hora não é para salvar");


      //   //Debug.Log()

      //       string path_imagem = Controlador_data.Pegar_instancia().Pegar_path_raiz() + "/saves/save_" + _save.ToString() + "_image.png";
            
      //       //CancellationTokenSource cancelar = new CancellationTokenSource();


      //       //Thread thread_save = new Thread(   ()=>{    Salvar_save_new_thread(_save , path_imagem , cancelar ) ;}   );
      //       Thread thread_save = new Thread(   ()=>{    Salvar_save_new_thread(_save , path_imagem  ) ;}   );



            
      //       thread_save.Start();
      //       /*
      //       *   StartCoroutine(       animation: check if x = salvando yield return null else break       )
      //       */


          
      //       Screen_shot(path_imagem, 384 ,  216 );

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



