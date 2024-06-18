using System;
using UnityEngine;



public class Controlador_tela_geral {

        public static Controlador_tela_geral instancia;
        public static Controlador_tela_geral Pegar_instancia(){ return instancia; }

        public GameObject canvas;

        public static Controlador_tela_geral Construir(){ 
            
            Controlador_tela_geral controlador = new Controlador_tela_geral(); 
            
            intancia = controlador;
            return controlador;
            
        }




}