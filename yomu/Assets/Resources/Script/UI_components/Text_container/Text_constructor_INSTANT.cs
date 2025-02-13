


public class Text_constructor_INSTANT : Text_constructor {



        public override void Force_complete( UI_text_container _container ){}

  
        public override void Build( UI_text_container _container, string _pre_text , string _target_text ){


                _container.text.tmp_text.color = _container.text.tmp_text.color;
                _container.text.tmp_text.text = ( _pre_text + _target_text );
                _container.text.tmp_text.ForceMeshUpdate();
                _container.text.tmp_text.maxVisibleCharacters = _container.text.tmp_text.textInfo.characterCount;
                return;

        }

        public override UI_text_container_writing_state Update_writing( UI_text_container _container ){ _container.writing_state = UI_text_container_writing_state.finished; return UI_text_container_writing_state.finished; }

        
}

