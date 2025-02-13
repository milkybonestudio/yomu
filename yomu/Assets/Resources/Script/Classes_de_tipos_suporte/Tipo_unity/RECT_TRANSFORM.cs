using UnityEngine;


public static class RECT_TRANSFORM {


        
        public static void Resize( GameObject _game_object, float _width, float _height ){

                RectTransform rect = _game_object.GetComponent<RectTransform>();

                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _width );
                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _height );


        }


        public static void Resize( RectTransform _rect, float _width, float _height ){


                _rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _width );
                _rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _height );


        }


        public static void Resize( ref Unity_main_components _unity_components, float _width, float _height ){


                _unity_components.rect_transform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _width );
                _unity_components.rect_transform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _height );

                _unity_components.rect.width = _width;
                _unity_components.rect.height = _height;


        }


        public static void Add_dimensions( ref Unity_main_components _unity_components, float _width, float _height ){

                _unity_components.rect.width += _width;
                _unity_components.rect.height += _height;

                _unity_components.rect_transform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _unity_components.rect.width );
                _unity_components.rect_transform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _unity_components.rect.height );

        }



        
        public static void Add_dimensions( GameObject _game_object, float _width_to_add, float _height_to_add ){

                RectTransform rect = _game_object.GetComponent<RectTransform>();

                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, ( rect.rect.width + _width_to_add ) );
                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, ( rect.rect.height + _height_to_add ) );


        }

        public static void Add_dimensions( RectTransform _rect, float _width_to_add, float _height_to_add ){

                Rect rect = _rect.rect;
                
                _rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, ( rect.width + _width_to_add ) );
                _rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, ( rect.height + _height_to_add ) );


        }





}