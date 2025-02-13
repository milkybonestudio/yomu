using System;
using UnityEngine;


public class CONTROLLER__UI {

        
        public static CONTROLLER__UI instancia;
        public static CONTROLLER__UI Pegar_instancia(){ return instancia; }


        public Device[,][] UIs;
        public Device[,][] UIs_program; // ** only program can change

        public void Calculate_UIs( Transition_data _data, Transition _transition, Game_node _node_old, Game_node _node_new ){





        }

        public void Change_program_UIs( Device[] _new_UIs, Program_mode _mode ){

            // ** Program_UI do not have transitions

        }






        public Localizador_UI[] localizadores;

        public GameObject container;


        public Action UI_objeto_update;

        public bool foi_ativado = false;

        public void Update(){


        }


}