using System;
using UnityEngine;



public class Controlador_tela_geral {

        // 

        public static Controlador_tela_geral instancia;
        public static Controlador_tela_geral Pegar_instancia(){ return instancia; }

        public GameObject canvas;
        public GameObject canvas_3d;
        public GameObject canvas_sistema;
        public GameObject coberta;
        public GameObject ui;
        public GameObject protetor;

        public static Controlador_tela_geral Construir(){ 
            
            Controlador_tela_geral controlador = new Controlador_tela_geral(); 

                        
                    controlador.canvas = GameObject.Find( "Tela/Canvas" );
                    controlador.canvas_3d = GameObject.Find( "Canvas_3d" );
                    controlador.canvas_sistema = GameObject.Find( "Tela/Canvas_sistema" );
                    controlador.coberta = GameObject.Find( "Tela/Coberta" );
                    controlador.ui = GameObject.Find( "Tela/UI" );
                    controlador.protetor = GameObject.Find( "Tela/Protetor_background" );
            
            instancia = controlador;
            return controlador;
            
        }




}