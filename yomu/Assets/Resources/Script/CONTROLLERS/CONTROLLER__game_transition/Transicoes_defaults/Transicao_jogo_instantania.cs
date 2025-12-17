using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Transicao_jogo_instantania : INTERFACE__transition_request_visual {


        public string Get_name(){ return "Transicao_jogo_instantania"; }
        public void Set_transition_space(){}
        public Transition_plane transition_plane;
        public Transition_plane Get_transition_plane(){ return transition_plane; }


}