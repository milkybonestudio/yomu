using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public static class IMAGE {



        public static IEnumerator Get_IEn_change_alpha_image( Image _image, float _alpha_destino, float _tempo_ms ){

                if( _alpha_destino > 1f || _alpha_destino < 0f )
                    { throw new Exception("Tentou mudar o alpha de uma imagem mas o novo alpha veio copm valor não aceito"); }

                if( _alpha_destino == _image.color.a )
                    { yield break; }

                Debug.Log( $"_alpha_destino : { _alpha_destino }");
                Debug.Log( $"alpha atual:  : { _image.color.a }");

                float sign = 1;

                if( _alpha_destino > _image.color.a )
                    { sign = -1f; }

                float velocidade = ( ( _image.color.a - _alpha_destino  ) * 1000f )  / _tempo_ms ;

                Debug.Log( $"velocidade : { velocidade }");

                float valor_threshold = ( _alpha_destino - ( 0.01f * sign ) ) * sign;
                Debug.Log( $"valor_threshold : { valor_threshold }");

                float r = _image.color.r;
                float g = _image.color.g;
                float b = _image.color.r;

                // mudar formato mara DeltaTime
                while(  ( sign * _image.color.a ) < valor_threshold  ){



                        float novo_alpha = ( _image.color.a  + ( Time.deltaTime * velocidade ) );

                        Debug.Log( $"novo_alpha : { novo_alpha }");

                        Color nova_cor  =  new Color(
                                                        r,
                                                        g,
                                                        b,
                                                        novo_alpha
                                                    );
                        
                        _image.color = nova_cor;

                        yield return null;

                }



                _image.color = new Color(
                                            r,
                                            g,
                                            b,
                                            _alpha_destino
                                        );



                yield break;

        }


        public static Image Criar_imagem_filho( string _nome, out GameObject _objeto, GameObject _pai  ){

                _objeto = new GameObject( _nome );

                return Criar_imagem_somente_com_sprite( _objeto, _pai, null );

        }




        public static Image Criar_imagem_filho( string _nome, GameObject _pai, Sprite _sprite ){

                GameObject game_object = new GameObject( _nome );

                return Criar_imagem_somente_com_sprite( game_object, _pai, _sprite );

        }



        public static Image Criar_imagem_somente_com_sprite( GameObject _game_object, GameObject _pai , Sprite _sprite  ){

            
                _game_object.transform.SetParent( _pai.transform , false);

                Image imagem = _game_object.AddComponent<Image>();

                imagem.sprite = _sprite;

                RectTransform rect = _game_object.GetComponent< RectTransform >();

                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _sprite.rect.width);
                rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _sprite.rect.height);

                return imagem;




        }


        public static Image Criar_imagem_DEVELOPMENT( GameObject _game_object, GameObject _pai , float _width, float _height, string _path , Sprite _sprite, float _alpha ){


            return null;



        }


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