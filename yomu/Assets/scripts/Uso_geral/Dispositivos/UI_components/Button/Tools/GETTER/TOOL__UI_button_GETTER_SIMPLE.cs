using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class TOOL__UI_button_GETTER_SIMPLE {


        public static void Get( UI_button _button ){



                try
                    {

                        // ** containers 
                        _button.COLLIDERS_container       =  _button.botao_game_object.transform.GetChild( 0 ).gameObject;
                        _button.IMAGE_container           =  _button.botao_game_object.transform.GetChild( 1 ).gameObject;
                        _button.TRANSITION_container      =  _button.botao_game_object.transform.GetChild( 2 ).gameObject;

                        // ** colliders
                        _button.ON_collider_game_object   =  _button.COLLIDERS_container.transform.GetChild( 0 ).gameObject;
                        _button.ON_collider   =  _button.ON_collider_game_object.GetComponent<PolygonCollider2D>();
                        
                        _button.OFF_collider_game_object  =  _button.COLLIDERS_container.transform.GetChild( 1 ).gameObject;
                        _button.OFF_collider   =  _button.OFF_collider_game_object.GetComponent<PolygonCollider2D>();


                        // ** IMAGE
                        _button.IMAGE_simple_body.game_object = _button.IMAGE_container.transform.GetChild( 0 ).gameObject;
                        _button.IMAGE_simple_body.image       = _button.IMAGE_simple_body.game_object.GetComponent<Image>();


                        Console.Log( "VAI PEGAR" );
                        _button.IMAGE_simple_text.game_object    = _button.IMAGE_container.transform.GetChild( 1 ).gameObject;
                        Console.Log( _button.IMAGE_simple_text.game_object.name );
                        Console.Log( _button.IMAGE_simple_text.game_object.GetComponent<TMP_Text>() );
                        _button.IMAGE_simple_text.tmp_text       = _button.IMAGE_simple_text.game_object.GetComponent<TMP_Text>();

                        // check
                        _button.IMAGE_simple_text.tmp_text.text = _button.IMAGE_simple_text.tmp_text.text;

                        

                        // ** TRANSITION
                        _button.TRANSITION_simple_body.game_object = _button.TRANSITION_container.transform.GetChild( 0 ).gameObject;
                        _button.TRANSITION_simple_body.image       = _button.TRANSITION_simple_body.game_object.GetComponent<Image>();

                        _button.TRANSITION_simple_text.game_object = _button.TRANSITION_container.transform.GetChild( 1 ).gameObject;
                        _button.TRANSITION_simple_text.tmp_text    = _button.TRANSITION_simple_text.game_object.GetComponent<TMP_Text>();

                    }
                    catch( Exception e )
                    {
                        Console.LogError( $"Could not link to the game object for the button { _button.button_name }. <Color=lightBlue>PROBABLY THE PREFAB IS NOT RIGHT</Color>" );
                        CONTROLLER__errors.Throw_exception( e );

                    }
                        
                      
        }


}