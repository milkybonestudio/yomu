using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public enum Menu_type{

 transicao = 0,
 personagens = 1,
 galeria = 2,
 new_game = 3, 
 saves= 4,
 configurations = 5,

}





public class Menu_objects_generico{


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

           }

           public Menu_objects_generico(  string id , GameObject parent , string path , float position_x  , float position_y , float width = 150f, float height = 100f){

              this.On_click = ()=>{};
              
              this.width = width;
              this.height = height;

              this.game_object = new GameObject( id );

              if(path != ""){

                  this.image  = this.game_object.AddComponent<Image>(); 
                  this.rect = this.game_object.GetComponent<RectTransform>();

                  this.image.color = Cores.Pegar_cor( Nome_cor.dark_2 );
                  this.image.sprite = Resources.Load<Sprite>(path);

                  this.rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical ,  height );
                  this.rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal ,  width  );


              } else {

                  this.rect = this.game_object.AddComponent<RectTransform>();

              }


              


              if(parent != null ) this.game_object.transform.SetParent( parent.transform);

             

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


    public class Save_information{

        public GameObject save_info_game_object;

        public TextMeshProUGUI tempo_total_jogo;

        public TextMeshProUGUI progresso;

        public Image x_image;

        public Save_information ( string id ,GameObject _parent , float _position_x , float _position_y ){

          this.save_info_game_object = new GameObject(id);
          this.save_info_game_object.transform.SetParent(_parent.transform,false);
          this.save_info_game_object.transform.localPosition= new Vector3( _position_x  , _position_y  , 0f);

          x_image  =  this.save_info_game_object.AddComponent<Image>();
          x_image.sprite = Resources.Load<Sprite>("images/menu_images/sem_save_info");
          RectTransform save_info_rect =  this.save_info_game_object.GetComponent<RectTransform>();

          save_info_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal  ,  302f  );
          save_info_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical  ,  112f  );



          
          
          
          GameObject texto_tempo_total_obj = new GameObject("Texto_tempo_total");

          texto_tempo_total_obj.transform.SetParent(this.save_info_game_object.transform, false);
          texto_tempo_total_obj.transform.localPosition = new Vector3(  0f  , 100f , 0f );




          TextMeshProUGUI texto_tempo_total = texto_tempo_total_obj.AddComponent<TextMeshProUGUI>();
          this.tempo_total_jogo = texto_tempo_total;
          texto_tempo_total.color = new Color(0f,0f,0f,1f);
          texto_tempo_total.fontSize = 50f;


          GameObject texto_progresso_obj = new GameObject("Texto_progresso");

          texto_progresso_obj.transform.SetParent(this.save_info_game_object.transform,false);
          texto_tempo_total_obj.transform.localPosition = new Vector3(  0f  , -100f , 0f );

          TextMeshProUGUI texto_progresso = texto_progresso_obj.AddComponent<TextMeshProUGUI>();
          this.progresso = texto_progresso;
          texto_progresso.color = new Color(0f,0f,0f,1f);
          texto_progresso.fontSize = 50f;


        }


      }

