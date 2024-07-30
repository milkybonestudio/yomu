using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;



public class Interativo_menu {


        // --- DADOS

        public GameObject game_object;
        public RectTransform rect;

        public GameObject text_game_object;
        public TextMeshProUGUI text_container;
        public Image image;
        public float[] x_points = new float[4];
        public float[] y_points= new float[4];

        public  Action On_click;
        public delegate void on_hover();
        public delegate void on_out();

        public float width;
        public float height;

        public void Colocar_texto( string _text){


                this.text_game_object = new GameObject("Text_" + _text);

                text_game_object.transform.SetParent(game_object.transform, false);

                text_container = text_game_object.AddComponent<TextMeshProUGUI>();
                text_container.alignment = TextAlignmentOptions.MidlineGeoAligned;

                RectTransform rect = text_game_object.GetComponent<RectTransform>();

                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 230f);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100f);
                text_container.text = _text;
                text_container.color = Color.black;
                text_container.fontSize = 35f;

                return;

        }

        public Interativo_menu(  string id , GameObject parent ,Sprite _sprite  , float position_x  , float position_y ){

            this.On_click = ()=>{};
            
            this.width = _sprite.rect.width;
            this.height = _sprite.rect.height;

            this.game_object = new GameObject( id );

            this.image  = this.game_object.AddComponent<Image>(); 
            this.rect = this.game_object.GetComponent<RectTransform>();

            this.image.color = Cores.Pegar_cor( Nome_cor.dark_2 );
            this.image.sprite = _sprite;

            this.rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical ,  height );
            this.rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal ,  width  );

                    

            


            if( parent != null ) 
                { this.game_object.transform.SetParent( parent.transform); }

            

            this.rect.localPosition = new Vector3(  position_x  , position_y  , 0f  );
            this.rect.localScale = new Vector3(1f,1f,1f);

            

            this.x_points[0] = position_x - (width/2);
            this.y_points[0] = position_y + (height/2);

            
            this.x_points[1] = position_x + (width/2);
            this.y_points[1] = position_y + (height/2);
            
            this.x_points[2] = position_x + (width/2);
            this.y_points[2] = position_y - (height/2);

            
            this.x_points[3] = position_x - (width/2);
            this.y_points[3] = position_y - (height/2);





        }


    }
