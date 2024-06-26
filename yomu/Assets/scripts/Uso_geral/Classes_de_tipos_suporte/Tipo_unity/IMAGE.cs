using UnityEngine;
using UnityEngine.UI;
using System;


public static class IMAGE {


        public static Image Criar_imagem (  GameObject _game_object, GameObject _pai , float _width, float _height, string _path , Sprite _sprite, float _alpha ){


            // --- CHECK
            
            if( _path != null && _sprite != null )
                { throw new Exception( "Em criar imagem veio tanto o path quanto a sprite" ); }

            
            _game_object.transform.SetParent( _pai.transform , false);

            Image imagem = _game_object.AddComponent<Image>();
            imagem.color = new Color(1f,1f,1f, _alpha );

            if( _path != null )
                {
                
                    Sprite sprite = Resources.Load<Sprite>( _path );
                    imagem.sprite = sprite;

                    if( sprite == null )
                        { throw new Exception( $"nao foi achado imagem no path : { _path }" ) ;}

                }

            RectTransform rect = _game_object.GetComponent< RectTransform >();

            rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _width);
            rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _height);

            return imagem;


        }


    public static void Resize(GameObject _game_object, float _width = 1920f, float _height = 1080f){

        RectTransform rect = _game_object.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _width);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _height);


    }



}