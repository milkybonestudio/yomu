using System;
using System.Collections;
using UnityEngine;



public class Desenvolvimento {


          public static Desenvolvimento instancia;
          public static Desenvolvimento Pegar_instancia(){ return instancia; }
          public static Desenvolvimento Construir(){ instancia = new Desenvolvimento(); return instancia; }

     
          // --- FERRAMENTAS 

          public bool bloqueado_por_ferramenta = false;
          public Ferramenta_desenvolvimento ferramenta_atual = Ferramenta_desenvolvimento.nada;
          public Del_void_TO_bool ferramenta_update;


          //  --- MODO TESTE ATUAL

          public Desenvolvimento_atual desenvolvimento_atual = Desenvolvimento_atual.conector;
          public string chave_teste = "colheita:generico";

          public void Iniciar_ferramentas(){

                    
                    // --- CRIA ESPACO
                    GameObject desenvolvimento_ferramentas = new GameObject( "desenvolvimento_ferramentas");
                    desenvolvimento_ferramentas.transform.SetParent( GameObject.Find( "Tela" ).transform , false );
                    // ** se tiver ferramentas especificas colocar aqui
                    return;


          }



          public void Colocar_estado_teste(){

                    // Inicia o save zerado
                    // Quando o jogo for iniciado na build ele na realidade vai ler o estado do save default 
                    // no editor ele vai começar em um local "0" sem nenhum contexto
                    // se um teste especifico precisar de contexto como "mover player para POSICAO" => iniciar VN => "mover player dependendo de VN" 


                    // --- COLOCA DADOS DEFAULT

                    Controlador_save.Construir_teste();


                    switch( desenvolvimento_atual ){

                         case Desenvolvimento_atual.conector : Teste_conector.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.visual_novel : Teste_visual_novel.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.conversas : Teste_conversas.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.cartas : Teste_cartas.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.minigames : Teste_minigames.Criar( chave_teste ); break;
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
               
          
               if( ferramenta_update != null )
                    {
                         bool pode_atualizar_o_jogo = ferramenta_update();
                         	if( !( pode_atualizar_o_jogo ))
                                   { return; }
                    }

               // --- VAI PARA O JOGO
               Jogo.Pegar_instancia().Update();

               return;
               
          }




}