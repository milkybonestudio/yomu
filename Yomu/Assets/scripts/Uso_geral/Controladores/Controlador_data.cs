using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public enum Tipo_dado {

      nada, 
      sprite, 

}




public class Controlador_data {



      public static Controlador_data instancia;
      public static Controlador_data Pegar_instancia(){ return instancia; }
      public static Controlador_data Construir(){ instancia = new Controlador_data(); return instancia;}



      public Controlador_data(){

        

      }

      
      public float[] posicao_mouse = new float[2];
      public float  screen_h = 0f;
      public float  screen_w = 0f;
      public float  alpha = 0f;
      public float  dif = 0f;


      



      public void Bloquear_mouse(){

            posicao_mouse[ 0 ] = -10000f;
            posicao_mouse[ 1 ] = -10000f;

      }





      public void Atualizar_mouse_atual(){

              screen_h = Screen.height;
              screen_w = Screen.width;

              if(screen_h / screen_w  < 0.5625f){

                    alpha  =   1080f / screen_h;
                    dif = (screen_w -  screen_h  * 1.7777f) / 2f;


                    posicao_mouse[0] =  ( Input.mousePosition[0] - dif ) * alpha ;
                    posicao_mouse[1] =  ( Input.mousePosition[1]  ) * alpha ;

              }
              else{

                    alpha  =   1920f / screen_w;
                    dif = (screen_h  -  screen_w  * 0.5625f)/2f;

                    posicao_mouse[0] =  (Input.mousePosition[0]) * alpha ;
                    posicao_mouse[1] =  (Input.mousePosition[1] - dif ) * alpha ;

              }


              return;

      }
















      



      // public bool[]  Pegar_UI_partes_default( Bloco _bloco ){

            
      //       bool[] retorno = new bool[ 10 ];

      //       if( _bloco == Bloco.visual_novel){



      //             return retorno;

      //       }

            
      //       if( _bloco == Bloco.jogo ){


      //             retorno[ ( int ) In_game_UI_partes.todas ] = false;
      //             retorno[ ( int ) In_game_UI_partes.barra_superior ] = true;
      //             retorno[ ( int ) In_game_UI_partes.pergaminho ] = true ;

      //             return retorno;

      //       }

            
      //       if( _bloco == Bloco.plataforma ){


      //             retorno[ ( int ) In_game_UI_partes.todas ] = false;
      //             retorno[ ( int ) In_game_UI_partes.barra_superior ] = false;
      //             retorno[ ( int ) In_game_UI_partes.pergaminho ] = false ;

      //             return retorno;

      //       }

            




      //       retorno[ 0 ] = true ;

      //       return retorno;



      // }

 





      public string Pegar_path_raiz() {

            
            #if UNITY_EDITOR

            return Application.dataPath + "/Resources/files/";


            #else
            
            return System.IO.Directory.GetCurrentDirectory();

            #endif

      }





}