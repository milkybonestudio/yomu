using System;
using UnityEngine;


public class CONTROLLER__UI {

        
        public static CONTROLLER__UI instancia;
        public static CONTROLLER__UI Pegar_instancia(){ return instancia; }



        public Localizador_UI[] localizadores;

        public GameObject container;


        public Action UI_objeto_update;

        public bool foi_ativado = false;

        public void Update(){


        }


}