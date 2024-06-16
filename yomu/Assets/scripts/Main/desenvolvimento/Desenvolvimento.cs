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
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.Rendering.VirtualTexturing;
using System.Linq;







public class Desenvolvimento {


          public static Desenvolvimento instancia;
          public static Desenvolvimento Pegar_instancia(){ return instancia; }
          public static Desenvolvimento Construir(){ instancia = new Desenvolvimento(); return instancia;}

     
          // --- FERRAMENTAS 

          public bool bloqueado_por_ferramenta = false;
          public Ferramenta_desenvolvimento ferramenta_atual = Ferramenta_desenvolvimento.nada;
          public Del_void_TO_bool ferramenta_update;


          //  --- MODO TESTE ATUAL
          public Desenvolvimento_atual desenvolvimento_atual = Desenvolvimento_atual.movimento;
          public string chave_teste = "";


          public bool Verificar_teste(){

                    if( desenvolvimento_atual == Desenvolvimento_atual.nada ){ return false;}

                    // TEM TESTE
                    Iniciar_jogo_teste();
                    return true;

          }


          // nada,

          // movimento,
          // visual_novel,
          // conversa,
          // cartas,
          // minigame,


          public void Iniciar_jogo_teste(){

                    // cria espaço para as ferramentas
                    GameObject desenvolvimento_ferramentas = new GameObject( "desenvolvimento_ferramentas");
                    desenvolvimento_ferramentas.transform.SetParent( GameObject.Find( "Tela" ).transform , false );


                    // Inicia o save zerado
                    Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.desenvolvimento;
                    Controlador.Pegar_instancia().jogo =  Jogo.Construir_teste();

                    switch( desenvolvimento_atual ){

                         case Desenvolvimento_atual.movimento : Teste_movimento.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.visual_novel : Teste_visual_novel.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.conversa : Teste_conversa.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.cartas : Teste_cartas.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.minigame : Teste_minigame.Criar( chave_teste ); break;
                         default Desenvolvimento_atual.nada : Console.Log( "wtf?" ); break;
                         
                    }

          }



          public void Update(){

               if( Teste_escopo.ativado )
                    { Teste_escopo.Update(); return;}

               // quando mais suporte Desenvolvimento dar ao desenvolvimento (uou) melhor 
               // o jeito mais eficiente vai ser criar ferramentas que podem ser criadas aqui para manipular, testar e ver dados com mais precisao 
               // as ferramentas vao estar em cada Teste_bloco

               Controlador_ferramentas.Atualizar_ferramentas_desenvolvimento();
               
               if( ferramenta_update != null ){

                    bool pode_atualizar_o_jogo = ferramenta_update();
                    

                    if( !( pode_atualizar_o_jogo ))
                         { return; }
                    // nao atualiza jogo
                    
               }

               // --- VAI PARA O JOGO
               Jogo.Pegar_instancia().Update();
               
          }








}


