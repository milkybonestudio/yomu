using System;
using UnityEngine;





public class Jogo {


        public static Jogo instancia;
        public static Jogo Pegar_instancia(){ return instancia; }
        public static Jogo Construir(){ instancia = new Jogo(); return instancia;}


        public Jogo(){

                Controlador_UI.Construir();
                Controlador_transicao.Construir();
                Dados_blocos.Construir();
                Controlador_dados_dinamicos.Construir();
                Controlador_timer.Construir();
                Player_estado_atual.Construir();


        }



        public Bloco bloco_atual = Bloco.nada;



        public BLOCO_visual_novel bloco_visual_novel;
        public BLOCO_conversas bloco_conversas;
        public BLOCO_movimento bloco_movimento;
        public BLOCO_cartas bloco_cartas;
        public BLOCO_minigames bloco_minigames;
        

        





        public void Update(){


            
                // if(  Controlador_UI.Pegar_instancia().Update() ) { return; }

                // if( Controlador_transicao.Pegar_instancia().em_transicao ) { return; }

                // Controlador_audio.Pegar_instancia().Update();

                

                switch (  Player_estado_atual.Pegar_instancia().bloco_atual ) {
                    
                        // case Bloco.visual_novel :  bloco_visual_novel.Update() ;  break;
                        // case Bloco.jogo :  bloco_jogo.Update(); break;
                        // case Bloco.login :  bloco_login.Update() ; break;
                        // case Bloco.menu : bloco_menu.Update() ; break;
                        //case Bloco.teste: teste.Update();break;
                        //case Bloco.NADA: console.log("esta no modo_tela NADA"); break;

                }





        }






}