using UnityEngine;
using TMPro;

public static class TOOL__UI_text_container_CHANGE_TEXT_SIMPLE {



        public const byte alpha_threshold = 40;


        public static void Build( UI_text_container _container, string _target_text ,string _pre_texto  ){


            _container.writing_state = UI_text_container_writing_state.writing;

            switch( _container.data.tipo_texto ){
                
                    case Type_writing_construction.instant:  Build_instant( _container, _pre_texto ,  _target_text) ; break;
                    case Type_writing_construction.typewrite: Build_typewriter( _container, _pre_texto ,  _target_text);break;
                    case Type_writing_construction.fade: Build_fade( _container, _pre_texto ,  _target_text); break;

            }
            
        }


        public static void Update_writing( UI_text_container _container ){

                
                switch( _container.data.tipo_texto ){

                    case Type_writing_construction.instant: _container.writing_state = UI_text_container_writing_state.finished; break;
                    case Type_writing_construction.fade: _container.writing_state = Update_fade( _container ); break;
                    case Type_writing_construction.typewrite: _container.writing_state = Update_typewriter( _container ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type_writing { _container.data.tipo_texto }" ); break;
                }

        }






        public static void Force_complete( UI_text_container _container ){

            switch( _container.data.tipo_texto ){

                case Type_writing_construction.typewrite:  _container.text.tmp_text.maxVisibleCharacters = _container.text.tmp_text.textInfo.characterCount; break;
                case Type_writing_construction.fade:  _container.text.tmp_text.ForceMeshUpdate(); break;

            }

        }


        public static void Build_instant( UI_text_container _container, string _pre_text , string _target_text ){

                _container.text.tmp_text.color = _container.text.tmp_text.color;
                _container.text.tmp_text.text = ( _pre_text + _target_text );
                _container.text.tmp_text.ForceMeshUpdate();
                _container.text.tmp_text.maxVisibleCharacters = _container.text.tmp_text.textInfo.characterCount;
                return;
                
        }


        // --- TYPEWRITE

        public static void Build_typewriter( UI_text_container _container, string _pre_text , string _target_text){
                
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

        public static UI_text_container_writing_state Update_typewriter( UI_text_container _container ){
                
                
                _container.text.tmp_text.maxVisibleCharacters +=  _container.data.characters_per_frame;

                if( ( _container.text.tmp_text.maxVisibleCharacters >= _container.text.tmp_text.textInfo.characterCount ) )
                    { return UI_text_container_writing_state.finished; }

                return UI_text_container_writing_state.writing;

        }



        public static void Build_fade( UI_text_container _container, string _pre_text , string _target_text ){


                Color text_color = _container.text.tmp_text.color;

                _container.text.tmp_text.text = _pre_text;

                int pre_text_length = 0;

                if( _pre_text != "" )
                    {
                        _container.text.tmp_text.ForceMeshUpdate();
                        pre_text_length = _container.text.tmp_text.textInfo.characterCount;
                    }


                _container.text.tmp_text.text += _target_text;

                _container.text.tmp_text.maxVisibleCharacters = int.MaxValue;
                _container.text.tmp_text.ForceMeshUpdate();

                
                TMP_TextInfo text_info = _container.text.tmp_text.textInfo;
                _container.text_info = text_info;
                
                Color color_visible = new Color( text_color.r, text_color.g, text_color.b, 1f );
                Color color_hidden = new Color( text_color.r, text_color.g, text_color.b, 0f );


                _container.vertex_colors = text_info.meshInfo[ ( text_info.characterInfo[ 0 ].materialReferenceIndex ) ].colors32 ;

                Color32[] vertex_colors = _container.vertex_colors;
                    
                for( int i = 0 ; i< text_info.characterCount ; i++ ){


                        TMP_CharacterInfo char_info = text_info.characterInfo[ i ];

                        if( !!!( char_info.isVisible ) )
                            { continue; }

                        // ** esconde tudo de novo e força velho a ficar aparente
                        Color color_to_use = color_hidden;

                        if( i < pre_text_length )
                            { color_to_use = color_visible; } 

                        vertex_colors[ ( char_info.vertexIndex + 0 ) ] = color_to_use;
                        vertex_colors[ ( char_info.vertexIndex + 1 ) ] = color_to_use;
                        vertex_colors[ ( char_info.vertexIndex + 2 ) ] = color_to_use;
                        vertex_colors[ ( char_info.vertexIndex + 3 ) ] = color_to_use;
                        

                }
                
                _container.text.tmp_text.UpdateVertexData( TMP_VertexDataUpdateFlags.Colors32 );

                _container.minRange = pre_text_length;
                _container.maxRange = _container.minRange + 1 ;   

        }





        public static UI_text_container_writing_state Update_fade( UI_text_container _container ){

                
                int variante_frame = ( int )( Time.deltaTime * _container.data.characters_per_frame * 255f ) + 1;

                byte max_alpha = 0;

                Color32[] vertex_colors = _container.vertex_colors;
                TMP_TextInfo text_info = _container.text.tmp_text.textInfo;

                int max_range_loop = _container.maxRange;
                
                for( int i = _container.minRange; i < max_range_loop; i++ ){


                
                        TMP_CharacterInfo char_info = text_info.characterInfo[ i ];
            
                        if( !!!( char_info.isVisible ) )
                            { continue; }

                        byte new_alpha = ( byte ) Move( vertex_colors[ char_info.vertexIndex ].a, 255, variante_frame );
                        

                        vertex_colors[ char_info.vertexIndex + 0 ].a = new_alpha;
                        vertex_colors[ char_info.vertexIndex + 1 ].a = new_alpha;
                        vertex_colors[ char_info.vertexIndex + 2 ].a = new_alpha;
                        vertex_colors[ char_info.vertexIndex + 3 ].a = new_alpha;


                        //if(alphas[i]>=255) minRange++;
                        if( new_alpha == 255 )
                            { _container.minRange++; }
                        
                        max_alpha = new_alpha; // min -> max, vai sair do loop com max


                }


                _container.text.tmp_text.UpdateVertexData( TMP_VertexDataUpdateFlags.Colors32 );

                bool lastCharacterIsInvisible = !!!( text_info.characterInfo [ ( _container.maxRange - 1 ) ].isVisible );


                if( ( max_alpha > alpha_threshold ) || lastCharacterIsInvisible )
                    {
            
                        //   todo texto tem um character invisible no final, entao o padrao seria - 1 para descontar esse char. com isso maxRange => numero de elementos array => index do ultimo elemento maxRange -1  
                        if( _container.maxRange < text_info.characterCount )
                            { _container.maxRange += ( 2 - ( _container.maxRange / text_info.characterCount ) ); } 
                                                        
                    }

                if( max_alpha == 255 ) 
                    { return UI_text_container_writing_state.finished; }
                    else
                    { return UI_text_container_writing_state.writing; }
                    

        }

        
        private static int Move( int _current, int _final_value, int _move_frame ){

                unchecked {

                        int ret = ( _current + _move_frame );

                        if( ret > _final_value )
                            { return _final_value; }

                        return ret;

                }

        }







}
