using System;
using UnityEngine;


public class Controlador_tela_cartas {

        public static Controlador_tela_cartas instancia;
        public static Controlador_tela_cartas Pegar_instancia(){ return instancia; }

        public static Controlador_tela_cartas Construir(){

            Controlador_tela_cartas controlador = new Controlador_tela_cartas();

                controlador.bloco_cartas = BLOCO_cartas.Pegar_instancia();


            instancia = controlador;
            return controlador; 

        }

        public void Criar_tela(){

                // --- CANVAS

                GameObject canvas_jogo = GameObject.Find( "Tela/Canvas/Jogo" );
                GameObject canvas_jogo_3d = GameObject.Find( "Canvas_3d" );

                canvas = new GameObject( "Cartas" );
                canvas.transform.SetParent( canvas_jogo.transform, false );

                canvas_3d = new GameObject( "Cartas_3d" );
                canvas_3d.transform.SetParent( canvas_jogo_3d.transform, false );
                return;
                

        }



        public GameObject canvas;
        public GameObject canvas_3d;
        public BLOCO_cartas bloco_cartas;

        public void Finalizar(){

            // ** transicao jogo só vai destruir o Canvas/UI
            GameObject.Destroy( canvas_3d );

        }





}