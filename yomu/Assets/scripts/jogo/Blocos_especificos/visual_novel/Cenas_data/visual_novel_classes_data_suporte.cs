using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public enum Tipo_screen_play {


   producao,
   compilado,

   
}



public enum Tipo_cena{


   set, 
   ic, 
   fn, 
   mov, 
   text, 
   end,
   audio,
   jump,
   pointer,
   choice


}



public enum Visual_novel_extras{

        god = 50,
        narrator, 
        game,
        developer,
        marketing_guy,

}



// // nao preciso


// public class Visual_novel_dados {

//       public Screen_play screen_play;


//       public Action fn_click_espera = null;

//       //   dados para o inverso




   

//       public   bool        have_timer         = false;
//       public   bool        bloqueio_choice    = false;
//       public   bool        bloqueio_transicao    = false;



//       public   bool        is_highlight_activate = false;
//       public   bool        is_tamanho_active = false;
//       public   bool        is_sombra_active = false;
      

//       public  bool auto_ativado = true;
//       public bool modo_jump_cenas = false;







//       /// precisa?

//       public   int         numero_choices     =  0;
//       public   int         choice_index_atual =  0;
//       public   bool        choice_start_2     =  false;
//       public   string[]    choices_texto      =  new string[5];
//       public   string      choice_pergunta;  
//       public   float[][]   choices_areas;


//       public string[]  choice_chaves;
//       public string[]  choice_respostas;



// }



public class Animacao_visual_novel {

      public bool na_frente = true;
      public bool instantaneo = true;
      public bool loop = true;

      /// se loop == false AND animations == null => so destroi a imagem 

      public int frame_jogo_Por_frame_animacao = 1;
      public int ciclos_bloqueio = 30;


      public string folder_path = null;
      public int numero_quadros = 1;

      public int[][] sequencias = null;
      public int numero_imagens_totais = 0;
      

      //  n>0 => vai ser animacoes que param o jogo para mostrar

      public Animacao_visual_novel proxima_animacao_visual_novel= null;
      public Image[] images = null;



      public int frames_passados = 0;
      public int imagem_atual = -1;


}




   public enum Modo_visual_novel {

      normal = 0,
      choice = 1,

   }













