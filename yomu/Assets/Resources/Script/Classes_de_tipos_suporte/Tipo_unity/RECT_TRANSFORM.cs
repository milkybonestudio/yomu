using UnityEngine;


public static class RECT_TRANSFORM {


        
        public static void Resize( GameObject _game_object, float _width, float _height ){

                RectTransform rect = _game_object.GetComponent<RectTransform>();

                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _width );
                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _height );


        }
        
        public static void Add_dimensions( GameObject _game_object, float _width_to_add, float _height_to_add ){

                RectTransform rect = _game_object.GetComponent<RectTransform>();

                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, ( rect.rect.width + _width_to_add ) );
                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, ( rect.rect.height + _height_to_add ) );


        }

        



}