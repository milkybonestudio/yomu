using System;
using UnityEngine;





public class Jogo {

        int a  = 15;


        public static Jogo instancia;
        public static Jogo Pegar_instancia( bool _forcar = false  ){
                if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Jogo")) { instancia = new Jogo();instancia.Iniciar();} return instancia;}
                if(  instancia == null) { instancia = new Jogo(); instancia.Iniciar(); }
                return instancia;
        }

        public void Iniciar(){

            /*

                Iniciar os blocos 
            
            */

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