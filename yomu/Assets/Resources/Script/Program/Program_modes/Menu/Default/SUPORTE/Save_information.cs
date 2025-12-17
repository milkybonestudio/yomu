using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;




public class Save_information {


        public GameObject save_info_game_object;
        public Image x_image;

        public TextMeshProUGUI tempo_total_jogo;
        public TextMeshProUGUI progresso;


        public Save_information ( string id ,GameObject _parent , float _position_x , float _position_y ){

                this.save_info_game_object = new GameObject( id );
                this.save_info_game_object.transform.SetParent( _parent.transform, false );
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

