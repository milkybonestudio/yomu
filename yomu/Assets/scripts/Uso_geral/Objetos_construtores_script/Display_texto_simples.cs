using UnityEngine;
using System;
using TMPro;



public class Display_texto_simples {

        public GameObject game_object;
        public TMP_Text text;



        public float[] min_max_rect = new float[ 4 ];
        public float height = 0f;
        public float width = 0f;

        public Display_texto_simples( string _nome  = "texto",    float _width = 100f , float _height = 100f , float _font_size = 20f ) {

                this.height = _height;
                this.width = _width;
                
                game_object = new GameObject( _nome );

                text = (TMP_Text ) (  game_object.AddComponent<TextMeshProUGUI>());
                TMP_FontAsset font_default = Resources.Load< TMP_FontAsset >( "fonts/Font_1" );
                text.font  = font_default;
                text.fontSize = _font_size;

                RectTransform rect = game_object.GetComponent<RectTransform>();
                rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical , _height  );
                rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal , _width  );

        }




        public void Setar_display( Transform _transform_pai, float _x_position = 0f, float _y_position = 0f){

            this.game_object.transform.SetParent(_transform_pai, false);
            this.game_object.transform.localPosition = new Vector3(_x_position, _y_position, 0f);


            
            min_max_rect[ 0 ] = _x_position - ( width  / 2f ) + 960f ;
            min_max_rect[ 1 ] = _x_position + ( width  / 2f ) + 960f ;
            min_max_rect[ 2 ] = _y_position - ( height / 2f ) + 540f ;
            min_max_rect[ 3 ] = _y_position + ( height / 2f ) + 540f ;

            return;

        }

        public void Mudar_tamanho(float _width, float _height ) {

                RectTransform text_rect = game_object.GetComponent<RectTransform>();

                text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal  ,  _width );
                text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical  ,  _height );


        }




        public void Colocar_texto(string _text, Color _cor){

            if( _cor != Color.clear ) { text.color = _cor; }
            text.text = _text;
            text.ForceMeshUpdate();

            return;

        }

        public void Mudar_cor( Color _cor ){

            text.color = _cor;
            
        }

        public string Pegar_texto(){
            return text.text;
        }

        public void Centralizar_texto(){

            text.alignment = TextAlignmentOptions.MidlineGeoAligned;
            return;


        }

}