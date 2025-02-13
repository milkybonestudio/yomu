



public class Text_constructor_TYPE_WRITE : Text_constructor {



        public override void Force_complete( UI_text_container _container ){ _container.text.tmp_text.maxVisibleCharacters = _container.text.tmp_text.textInfo.characterCount; }

  
        public override void Build( UI_text_container _container, string _pre_text , string _target_text ){


                _container.text.tmp_text.color = _container.text.tmp_text.color;
                _container.text.tmp_text.maxVisibleCharacters = 0;
                _container.text.tmp_text.text = _pre_text;


                if( _pre_text != ""){

                        _container.text.tmp_text.ForceMeshUpdate();
                        _container.text.tmp_text.maxVisibleCharacters = _container.text.tmp_text.textInfo.characterCount;
                        
                }

                _container.text.tmp_text.text += _target_text;
                _container.text.tmp_text.ForceMeshUpdate();

        }

        public override UI_text_container_writing_state Update_writing( UI_text_container _container ){ 

                _container.text.tmp_text.maxVisibleCharacters +=  _container.data.characters_per_frame;

                if( ( _container.text.tmp_text.maxVisibleCharacters >= _container.text.tmp_text.textInfo.characterCount ) )
                    { return UI_text_container_writing_state.finished; }

                return UI_text_container_writing_state.writing;
            
        }

        
}

