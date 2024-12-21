using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;




public abstract class UI_text_container : UI_component {


        public UI_container container;

        public Type_UI_text_container type;

        

        
        // --- METHODS UI
        public abstract void Define();
        public abstract void Link_to_game_object( GameObject _game_object );
        public abstract void Update();


        public void Activate_text_container(){}
        public void Deactivate_text_container(){}


}