using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;



public enum UI_text_container_writing_state {

        finished, 
        writing,


}

public class UI_text_container {

        // op 1 -> text_container tem somente o texto

        /*

                Text_container vai ser um pouco diferente de Button porque button vai dividir a complexidade em construção e updates visuais. 
                Text_container vai ter diferentes funçoes para diferentes tipos

                principais metodos: 

                    -> mostrar texto aos poucos ( 2 modos diferentes )
                    -> append text
                    -> mudar fonte
                    -> mudar cor
                    

                metodos no completo: 
                    -> transicionar textos completos
                    -> multiplos estados [ texto 1 ] ←→ [ texto 2 ] ←→ [ texto 3 ]
                    -> aplicar efeito texto
        
        */

        public static UI_text_container Get_text_container(){ return TOOL__UI_text_container_APPLY_DEFAULT.Apply( new UI_text_container() ); }


        public GameObject game_object;


        
        // --- SIMPLE

            public Unity_main_components simple_container; // mas?
            public Unity_main_components simple_text;
        

        public DATA__UI_text_container data;



        // --- update data

        public const byte alpha_threshold = 40;
        public int minRange;
        public int maxRange;   
        public Color32[] vertex_colors;
        public TMP_TextInfo text_info;



        public UI_text_container_writing_state writing_state;

        
        // --- METHODS UI
        public void Define(){

                TOOL__UI_text_container_VERIFICATIONS.verify( this );

                // ** data -> resources 
                switch( data.type ){

                    case Type_UI_text_container.simple: TOOL__UI_text_container_DEFINER_SIMPLE.Define( this ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type { data.type }" ); break;

                }

        }


        public void Link_to_game_object( GameObject _game_object ){ 

                if( _game_object == null )
                    { CONTROLLER__errors.Throw( $"Tried to link the text_container <Color=lightBlue>{ data.path_locator }</Color> to the game object, but it was null." ); }

                game_object = _game_object;

                switch( data.type ){

                    case Type_UI_text_container.simple: TOOL__UI_text_container_GETTER_SIMPLE.Link_to_game_object( this, _game_object ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type { data.type }" ); break;

                }

        }


        public void Activate_text_container(){

                //** se tem algum texto tem que


        }

        public void Deactivate_text_container(){}




        // --- METHODS FUNCTION



        public void Update(){

            if( writing_state == UI_text_container_writing_state.writing )
                { Update_writing(); }

        }



        public void Resize( float _width, float _height ){


                RECT_TRANSFORM.Resize( simple_container.game_object, _width, _height );
                RECT_TRANSFORM.Resize( simple_text.game_object, _width, _height );

        }


        public void Add_dimensions( float _width_to_add, float _height_to_add ){

                RECT_TRANSFORM.Add_dimensions( simple_container.game_object, _width_to_add, _height_to_add );
                RECT_TRANSFORM.Add_dimensions( simple_text.game_object, _width_to_add, _height_to_add );


        }

        public void Move( float _x_pixels, float _y_pixels ){ simple_container.game_object.transform.localPosition += new Vector3( _x_pixels, _y_pixels, 0f ); }
        public void Set_position( float _x_position, float _y_position ){ simple_container.game_object.transform.localPosition = new Vector3( _x_position, _y_position, simple_container.game_object.transform.localPosition.z ); }



        public void Clean_text(){

                if( data.texto_coroutine != null){
                
                    Mono_instancia.Stop_coroutine( data.texto_coroutine );
                    data.texto_coroutine = null;

                }

                simple_text.tmp_text.text = "";

        }




        public void Setar_display( Transform _transform_pai, float _x_position = 0f, float _y_position = 0f ){

    
                game_object.transform.SetParent( _transform_pai, false);
                game_object.transform.localPosition = new Vector3(_x_position, _y_position, 0f);
                return;

        }



        public void Change_type_construction(  Type_writing_construction _tipo_construcao  ){

                if( writing_state == UI_text_container_writing_state.writing )
                    { Force_complete(); }
            
                if( _tipo_construcao == Type_writing_construction.config_default )
                    { _tipo_construcao = CONTROLLER__configurations.Pegar_instancia().tipo_texto; }

                data.tipo_texto = _tipo_construcao;

        }
    
        public void Put_text( string _text , int _tipo_texto , Color _cor_texto ){


                simple_text.tmp_text.color = _cor_texto;


                string pre_text = "";
                string target_text = _text;
                
                switch( _tipo_texto ){
                
                        case 0 : pre_text = "  ";break; // reseta
                        case 1 : pre_text = simple_text.tmp_text.text + " "; break; // mesmo bloco
                        case 2 : pre_text = simple_text.tmp_text.text + "\n  " ;break;   // novo bloco
                    
                }

                Build(  target_text ,  pre_text  );
                return ;

        }


        public void Build( string _target_text ,string _pre_texto  ){


            writing_state = UI_text_container_writing_state.writing;

            Console.Log( data.tipo_texto );

            switch( data.tipo_texto ){
                
                    case Type_writing_construction.instant:  Build_instant( _pre_texto ,  _target_text) ; break;
                    case Type_writing_construction.typewrite: Build_typewriter( _pre_texto ,  _target_text);break;
                    case Type_writing_construction.fade: Build_fade( _pre_texto ,  _target_text); break;

            }
            
        }


        public void Update_writing(){

                
                switch( data.tipo_texto ){

                    case Type_writing_construction.instant: writing_state = UI_text_container_writing_state.finished; break;
                    case Type_writing_construction.fade: writing_state = Update_fade(); break;
                    case Type_writing_construction.typewrite: writing_state = Update_typewriter(); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type_writing { data.tipo_texto }" ); break;
                }

        }






        public void Force_complete (){

            switch( data.tipo_texto ){

                case Type_writing_construction.typewrite:  simple_text.tmp_text.maxVisibleCharacters = simple_text.tmp_text.textInfo.characterCount;break;
                case Type_writing_construction.fade:  simple_text.tmp_text.ForceMeshUpdate(); break;

            }

        }



        // public void Stop(){

        //         if( data.texto_coroutine == null )
        //             { return; }
            
        //         Mono_instancia.Stop_coroutine( data.texto_coroutine );
        //         data.texto_coroutine = null;
            
        // }




        public void Build_instant( string _pre_text , string _target_text ){

                simple_text.tmp_text.color = simple_text.tmp_text.color;
                simple_text.tmp_text.text = _pre_text + _target_text;
                simple_text.tmp_text.ForceMeshUpdate();
                simple_text.tmp_text.maxVisibleCharacters = simple_text.tmp_text.textInfo.characterCount;
                return;
                
        }


        // --- TYPEWRITE

        public void Build_typewriter(string _pre_text , string _target_text){
                
            simple_text.tmp_text.color = simple_text.tmp_text.color;
            simple_text.tmp_text.maxVisibleCharacters = 0;
            simple_text.tmp_text.text = _pre_text;


            if( _pre_text != ""){

                    simple_text.tmp_text.ForceMeshUpdate();
                    simple_text.tmp_text.maxVisibleCharacters = simple_text.tmp_text.textInfo.characterCount;
                    
            }

            simple_text.tmp_text.text += _target_text;
            simple_text.tmp_text.ForceMeshUpdate();


        }

        public UI_text_container_writing_state Update_typewriter(){
                
                
                simple_text.tmp_text.maxVisibleCharacters +=  data.characters_per_cycle();

                if( ( simple_text.tmp_text.maxVisibleCharacters >= simple_text.tmp_text.textInfo.characterCount ) )
                    { return UI_text_container_writing_state.finished; }

                return UI_text_container_writing_state.writing;

        }



        public void Build_fade( string _pre_text , string _target_text ){


                Color text_color = simple_text.tmp_text.color;

                simple_text.tmp_text.text = _pre_text;

                int pre_text_length = 0;

                if( _pre_text != "" )
                    {
                        simple_text.tmp_text.ForceMeshUpdate();
                        pre_text_length = simple_text.tmp_text.textInfo.characterCount;
                    }


                simple_text.tmp_text.text += _target_text;

                simple_text.tmp_text.maxVisibleCharacters = int.MaxValue;
                simple_text.tmp_text.ForceMeshUpdate();

                
                text_info = simple_text.tmp_text.textInfo;

                Color color_visible = new Color( text_color.r, text_color.g, text_color.b, 1 ); // ?? 
                Color color_hidden = new Color( text_color.r, text_color.g, text_color.b, 0 );



                vertex_colors = text_info.meshInfo[ ( text_info.characterInfo[ 0 ].materialReferenceIndex ) ].colors32 ;

                    
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
                
                simple_text.tmp_text.UpdateVertexData( TMP_VertexDataUpdateFlags.Colors32 );

                minRange = pre_text_length;
                maxRange = minRange + 1 ;   

        }





        public UI_text_container_writing_state Update_fade(){

                
                int variante_frame = ( int )( Time.deltaTime * data.characters_per_cycle() * 255f ) + 1;

                byte max_alpha = 0;

                for( int i = minRange; i < maxRange; i++ ){


                
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
                            { minRange++; }
                        
                        max_alpha = new_alpha; // min -> max, vai sair do loop com max


                }


                simple_text.tmp_text.UpdateVertexData( TMP_VertexDataUpdateFlags.Colors32 );

                bool lastCharacterIsInvisible = !!!( text_info.characterInfo [ ( maxRange - 1 ) ].isVisible );


                if( ( max_alpha > alpha_threshold ) || lastCharacterIsInvisible )
                    {
            
                        //   todo texto tem um character invisible no final, entao o padrao seria - 1 para descontar esse char. com isso maxRange => numero de elementos array => index do ultimo elemento maxRange -1  
                        if( maxRange < text_info.characterCount )
                            { maxRange += ( 2 - ( maxRange / text_info.characterCount ) ); } 
                                                        
                    }

                if( max_alpha == 255 ) 
                    { return UI_text_container_writing_state.finished; }
                    else
                    { return UI_text_container_writing_state.writing; }
                    

        }

        
        private int Move( int _current, int _final_value, int _move_frame ){

                unchecked {

                        int ret = ( _current + _move_frame );

                        if( ret > _final_value )
                            { return _final_value; }

                        return ret;

                }

        }





























}