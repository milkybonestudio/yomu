using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;
using Png_decoder;
using Unity.Collections;



using System.Drawing;




//using UnityEditor.Animations;

using UnityEngine.SceneManagement;
 

using System.Runtime.InteropServices;

using System.Text;
using UnityEngine.Rendering.VirtualTexturing;
using System.Linq;




public class Test_dll : MonoBehaviour{


     [DllImport("a")] public static extern float Somar(float a, float b);




}




public enum Desenvolvimento_atual {

     nada,

     movimento,


}




public class Desenvolvimento {


          public static Desenvolvimento instancia;
          public static Desenvolvimento Pegar_instancia(){ return instancia; }
          public static Desenvolvimento Construir(){ instancia = new Desenvolvimento(); return instancia;}


          public Desenvolvimento_atual desenvolvimento_atual = Desenvolvimento_atual.movimento;

          public bool Verificar_teste(){


                    if( desenvolvimento_atual == Desenvolvimento_atual.nada ){ return false;}

                    // TEM TESTE

                    // cria espaço para as ferramentas
                    GameObject desenvolvimento_ferramentas = new GameObject( "desenvolvimento_ferramentas");
                    desenvolvimento_ferramentas.transform.SetParent( GameObject.Find( "Tela" ).transform , false );


                    // Inicia o save zerado
                    Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.jogo;
                    Controlador.Pegar_instancia().jogo =  Jogo.Construir_teste();

                    switch( desenvolvimento_atual ){

                         case Desenvolvimento_atual.movimento : Teste_movimento.Criar(); break;

                    }

                    return true;


          }

          public bool bloqueado_por_ferramenta = false;
          public KeyCode ferramenta_atual = KeyCode.Space;




          public void Update(){

               // quando mais suporte Desenvolvimento dar ao desenvolvimento (uou) melhor 
               // o jeito mais eficiente vai ser criar ferramentas que podem ser criadas aqui para manipular, testar e ver dados com mais precisao 
               // as ferramentas vao estar em cada Teste_bloco

               Ferramentas_desenvolvimento_update();
               
               if( ferramenta_update != null ){

                    ferramenta_update();
                    // nao atualiza jogo
                    return;

               }


               Jogo.Pegar_instancia().Update();
               
          }


          public Action ferramenta_update;


          public void Ferramentas_desenvolvimento_update() {
               // aqui pode criar as ferramentas 
               // vaoi ser criadas com as F teclas. F1, F2 ... 

               if( Input.GetKeyDown( KeyCode.F1 ) ){

                    if( ferramenta_atual == KeyCode.F1 ) { 

                         ferramenta_atual = KeyCode.Space;
                         // deletar 

                    }


                    // criar

                    return;

               }


          }







     // public bool bloquear_testes = false ;



     // public bool teste_generico = true ;

     // public bool testar_login = false;
     // public bool testar_menu = false ;



     // public bool testar_plataform = false ;
     // public string teste_fase = "";




     // public bool testar_jogo = false ;
     // public Ponto_nome ponto_nome =   Ponto_nome.UP_quarto_nara ; 

     // public int[] interativos = new int[]{};
     // public int testar_save = 0;



     // public bool testar_visual_novel = false ;
     // public Nome_screen_play screen_play_teste =  Nome_screen_play.NARA_INTRODUCAO_dia_introducao_carruagem ;        //"cenas_obrigatorias/1/sara_wake_up/rota_final"; 




}

