using System;
using UnityEngine;





public static class Utilidades_bloco_1 {


       public static Action Bilhete_dia(){


          Action Update =  Imagem_simples_utilidades.Construir(

               _nome: "bilhete_dia", 
               _path_imagem: "utilidades/main_plot/1/sara_wake_up/bilhete_dia",
               _clicks_para_ignorar: 0,
               _frames_para_ignorar: 20, 
               _fn_click: Plot_scripts_jogo_1.NARA_INTRODUCAO_bilhete,
               _width: 821f,
               _height:  916f


          );

          return Update;

       }



}