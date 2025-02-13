using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public abstract class Story_text_display : Device {

        public string root;

        public abstract void Show();
        public virtual void Update( Control_flow _control_flow ){ base.Update( _control_flow ); }
        public abstract void Hide();

        public abstract void Put_text();
        public abstract void Put_effect();
        

}


