using UnityEngine;
using UnityEngine.UI;
using TMPro;


public static class TOOL__UI_text_container_GETTER_SIMPLE {


        public static void Link_to_game_object( UI_text_container _text_container, GameObject _game_object ){


                _text_container.container.game_object = _game_object;

                try
                    {
                        // --- GET GAME OBJECT
                        _text_container.simple_text.game_object =  _game_object.transform.GetChild( 0 ).gameObject;

                        // --- GET COMPONENTS
                        _text_container.simple_text.tmp_text = _text_container.simple_text.game_object.GetComponent<TMP_Text>();
                        
                    } 
                    catch( System.Exception e ) { CONTROLLER__errors.Throw_exception( e ); }

        }


}