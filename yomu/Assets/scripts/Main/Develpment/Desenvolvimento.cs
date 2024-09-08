using System;
using System.Collections;
using UnityEngine;


public struct Teste_development {

    public int bloco;
    public int modo;

}


public class Controlador_development {


          public static Controlador_development instancia;
          public static Controlador_development Pegar_instancia(){ return instancia; }
          
          public static Controlador_development Construir(){ instancia = new Controlador_development(); return instancia; }

     
          // --- FERRAMENTAS 

          public bool bloqueado_por_ferramenta = false;
          public Ferramenta_desenvolvimento ferramenta_atual = Ferramenta_desenvolvimento.nada;
          public Del_void_TO_bool ferramenta_update;


          //  --- MODO TESTE ATUAL

          public Desenvolvimento_atual desenvolvimento_atual = Desenvolvimento_atual.interacao;

          public Teste_development teste_development_atual = new Teste_development(); // => nada
          public string chave_teste = "generico";

          public void Iniciar_ferramentas(){

                    
                    // --- CRIA ESPACO
                    GameObject desenvolvimento_ferramentas = new GameObject( "desenvolvimento_ferramentas");
                    desenvolvimento_ferramentas.transform.SetParent( GameObject.Find( "Tela" ).transform , false );
                    // ** se tiver ferramentas especificas colocar aqui
                    return;


          }


          public bool Aplicar_teste(){

                if( teste_development_atual.bloco == ( int ) Bloco.nada )
                    { return false; }

                // --- VAI TESTAR
                Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.desenvolvimento;

                // --- SETA TUDO COMO DEFAULT
                Controlador.Pegar_instancia().jogo = Construtor_jogo.Construir();
                
                // --- DESENVOLVIMENTO UTILIDADES
                Colocar_estado_teste();
                Iniciar_ferramentas();
                
                Console.Log( "veio em iniciar jogo teste" );
                Console.Log( $"modo atual: <b><color=white>{ desenvolvimento_atual }</color></b>" );

                return true;


          }



          public void Colocar_estado_teste(){

                    // Inicia o save zerado
                    // Quando o jogo for iniciado na build ele na realidade vai ler o estado do save default 
                    // no editor ele vai começar em um local "0" sem nenhum contexto
                    // se um teste especifico precisar de contexto como "mover player para POSICAO" => iniciar VN => "mover player dependendo de VN" 


                    // --- COLOCA DADOS DEFAULT

                    TESTE__controlador_save.Construir();


                    switch( desenvolvimento_atual ){

                         case Desenvolvimento_atual.interacao : Teste_interacao.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.story : Teste_story.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.cartas : Teste_cartas.Criar( chave_teste ); break;
                         case Desenvolvimento_atual.minigames : Teste_minigames.Criar( chave_teste ); break;
                         
                         default : Console.Log( "wtf?" ); break;
                         
                    }

          }



          public void Update(){


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