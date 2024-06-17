using System;
using System.Collections;
using UnityEngine;



public class Desenvolvimento {


          public static Desenvolvimento instancia;
          public static Desenvolvimento Pegar_instancia(){ return instancia; }
          public static Desenvolvimento Construir(){ instancia = new Desenvolvimento(); return instancia;}

     
          // --- FERRAMENTAS 

          public bool bloqueado_por_ferramenta = false;
          public Ferramenta_desenvolvimento ferramenta_atual = Ferramenta_desenvolvimento.nada;
          public Del_void_TO_bool ferramenta_update;


          //  --- MODO TESTE ATUAL

          public Desenvolvimento_atual desenvolvimento_atual = Desenvolvimento_atual.visual_novel;
          public string chave_teste = "generico";



          public bool Verificar_teste(){

                    if( desenvolvimento_atual == Desenvolvimento_atual.nada ){ return false;}

                    // TEM TESTE
                    Iniciar_jogo_teste();
                    return true;

          }


          public void Iniciar_jogo_teste(){

                    Console.Log( "veio em iniciar jogo teste" );
                    Console.Log( $"modo atual: {desenvolvimento_atual}" );
                    
                    // cria espaço para as ferramentas
                    GameObject desenvolvimento_ferramentas = new GameObject( "desenvolvimento_ferramentas");
                    desenvolvimento_ferramentas.transform.SetParent( GameObject.Find( "Tela" ).transform , false );


                    // Inicia o save zerado


                    switch( desenvolvimento_atual ){

                         case Desenvolvimento_atual.movimento : Teste_movimento.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.visual_novel : Teste_visual_novel.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.conversa : Teste_conversa.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.cartas : Teste_cartas.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.minigame : Teste_minigames.Criar( chave_teste ); break;
                         default : Console.Log( "wtf?" ); break;
                         
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


