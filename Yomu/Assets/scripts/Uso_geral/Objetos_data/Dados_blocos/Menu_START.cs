using System;
using UnityEngine;


public class Menu_START {


        public Save_menu_info save_menu_info;

        public Sprite background_image;


          //   tem que tirar 
        public void Pegar_background(string _nome){
            
            this.background_image = Resources.Load<Sprite>("images/menu_images/" + _nome);
            
            if(this.background_image == null) throw new ArgumentException("nao veio nome aceitavel para pegar menu background. Veio: " + _nome);

        }


}
