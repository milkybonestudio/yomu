using System;
using UnityEngine;


public class Login_START{


        public Login_START(string _nome = null){


                if(_nome == null) return;
                this.background_image = Resources.Load<Sprite>("images/login_images/" + _nome);
                if(this.background_image == null) throw new ArgumentException("nao veio nome aceitavel para pegar login background. Veio: " + _nome);


        }

        public string background_image_path;
        public Sprite background_image;
        public bool manter_dados = false;


}