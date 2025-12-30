using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Story_text_display : Device {

        public Story_text_display() : base( "Story_text_display" ){}

        public string root;

        public abstract void Show();
        protected override void Update_phase(){}
        public abstract void Hide();

        public abstract void Put_text();
        public abstract void Put_effect();
        

}

