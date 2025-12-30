using UnityEngine;
using TMPro;







unsafe public class UI_text_container : UI_component {


        public static UI_text_container Get_text_container( string _name ){ 

            UI_text_container text_container = Containers.UI_text_container.Get(); 
            text_container.name = _name;

            DEFAULT_APPLICATOR__UI_text_container.Apply_default( text_container ); 

            return text_container; 
        }

            protected override void Destroy_abs(){

                resources_container.Delete_all_resources();
                Containers.UI_text_container.Return_object( this );
                
            }
            

        protected override void Update_material(){}

    public override void Force_active(){ /*Console.Log( "tem que fazer" );*/ }
    public override void Force_inactive(){ /*Console.Log( "tem que fazer" );*/ }
    public override void Force_nothing(){ /*Console.Log( "tem que fazer" );*/ }
        

        public Unity_main_components text;
        

        public DATA__UI_text_container data;
        public DATA_CREATION__UI_text_container creation_data;


        public static Text_constructor[] static_constructors;
        public Text_constructor[] constructors;


        protected override void Update_phase(){


            if( constructors == null )
                { 
                    constructors = new Text_constructor[ 10 ];
                    constructors[ ( int ) Type_writing_construction.fade ] = new Text_constructor_FADE();
                    constructors[ ( int ) Type_writing_construction.instant ] = new Text_constructor_INSTANT();
                    constructors[ ( int ) Type_writing_construction.typewrite ] = new Text_constructor_TYPE_WRITE();
                }


            if( writing_state != UI_text_container_writing_state.writing )
                { return; }

            writing_state = constructors[ ( int ) data.tipo_texto ].Update_writing( this );


        }

        //mark
        // ** trocar Put_text() depois
        public void Change_text( UI_text _new_text ){}



    // --- UPDATE DATA


        public int minRange;
        public int maxRange;
        public Color32[] vertex_colors;
        public TMP_TextInfo text_info;


        public UI_text_container_writing_state writing_state;




        // --- METHODS UI
        protected override void Create_data_FROM_creation_data(){

                
                data.tipo_texto = creation_data.tipo_texto;


                data.context = creation_data.context;
                data.main_folder = creation_data.main_folder;
                

                data.initial_text = creation_data.initial_text;

                data.characters_per_frame = creation_data.characters_per_frame;


        }


        protected override void Link_to_UI_game_object_in_structure( GameObject _UI_game_object ){ 
            
            
                // Debug.Log( "number child:  " + structure_container.transform.childCount );

                // --- GET GAME OBJECT
                // text.game_object =  structure_container.transform.GetChild( 0 ).gameObject;

                text.game_object = _UI_game_object;
                text.rect_transform = text.game_object.GetComponent<RectTransform>();
                text.rect = text.rect_transform.rect;

                // --- GET COMPONENTS
                text.tmp_text = text.game_object.GetComponent<TMP_Text>();


                // --- MATERIAL
                if( creation_data.material != null  )
                    { text.tmp_text.material = creation_data.material; }
    
                data.material = text.tmp_text.material;


                // --- FONT
                if( creation_data.font != null  )
                    { text.tmp_text.font = creation_data.font; }
    
                data.font = text.tmp_text.font;


                // --- FONT COLOR 
                if( creation_data.font_color != Color.clear  )
                    { text.tmp_text.color = creation_data.font_color; }
    
                data.font_color = text.tmp_text.color;
                
                // --- Aligmant
                if( creation_data.has_over_flow )
                    { text.tmp_text.alignment = creation_data.aligment; }
    
                data.aligment = text.tmp_text.alignment;


                // --- Overflow
                if( creation_data.has_over_flow )
                    { text.tmp_text.overflowMode = creation_data.over_flow; }
    
                data.over_flow = text.tmp_text.overflowMode;


                // --- Style
                if( creation_data.has_font_style )
                    { text.tmp_text.fontStyle = creation_data.font_style; }
    
                data.font_style = text.tmp_text.fontStyle;



                // --- FontSize
                if( creation_data.font_size != 0f )
                    { text.tmp_text.fontSize = creation_data.font_size; }
    
                data.font_size = text.tmp_text.fontSize;

                if( data.initial_text != null )
                    { text.tmp_text.text = data.initial_text; }

                data.initial_text = text.tmp_text.text;

                



        }


        public void Activate_text_container(){

                //** se tem algum texto tem que


        }

        public void Deactivate_text_container(){}


        // --- METHODS FUNCTION





        public void Resize( float _width, float _height ){ 

                _width  *= PPU.value_inverse;
                _height *= PPU.value_inverse;
                
                RECT_TRANSFORM.Resize(ref  text, _width, _height ); 

        }
        public void Add_dimensions( float _width_to_add, float _height_to_add ){ 

                _width_to_add  *= PPU.value;
                _height_to_add *= PPU.value;
            
                RECT_TRANSFORM.Add_dimensions( ref text, _width_to_add, _height_to_add ); 

        }

        public void Add_dimension_WIDTH( float _width_to_add ){ RECT_TRANSFORM.Add_dimensions( text.game_object, _width_to_add, 0f ); }
        public void Add_dimension_HEIGHT( float _height_to_add ){ RECT_TRANSFORM.Add_dimensions( text.game_object, 0f, _height_to_add ); }




        public void Clean_text(){

                // ** talvez fazer algo como modo de descontrução 
                text.tmp_text.text = "";

        }




        public void Setar_display( Transform _transform_pai, float _x_position, float _y_position ){

    
                text.game_object.transform.SetParent( _transform_pai, false);
                text.game_object.transform.localPosition = new Vector3(_x_position, _y_position, 0f);
                return;

        }



        public void Change_type_construction(  Type_writing_construction _tipo_construcao  ){

                if( writing_state == UI_text_container_writing_state.writing )
                    {  constructors[ ( int ) data.tipo_texto ].Force_complete( this ); }
            
                if( _tipo_construcao == Type_writing_construction.config_default )
                    { _tipo_construcao = CONTROLLER__configurations.Pegar_instancia().configurations-> tipo_texto; }

                data.tipo_texto = _tipo_construcao;

        }
    
        public void Put_text( string _text, int _tipo_texto, Color _cor_texto ){

                writing_state = UI_text_container_writing_state.writing;

                text.tmp_text.color = _cor_texto;


                string pre_text = "";
                string target_text = _text;
                
                switch( _tipo_texto ){
                
                        case 0 : pre_text = "  ";break; // reseta
                        case 1 : pre_text = text.tmp_text.text + " "; break; // mesmo bloco
                        case 2 : pre_text = text.tmp_text.text + "\n  " ;break;   // novo bloco
                    
                }

                Debug.Log( data.tipo_texto );

                constructors[ ( int ) data.tipo_texto ].Build( this, pre_text, target_text  );

                return ;

        }





}