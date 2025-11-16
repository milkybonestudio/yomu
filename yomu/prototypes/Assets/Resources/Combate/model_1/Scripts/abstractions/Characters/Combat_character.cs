using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;




public class Combat_character{

        static Combat_character(){    

            a_lot_of_uses_ball = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/ball_3" ) );
            mid_uses_ball = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/ball_2" ) );
            low_uses_ball = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/ball_1" ) );
            no_uses_ball = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/ball_4" ) );

            base_image = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/base" ) );

        }

        

        public static Sprite a_lot_of_uses_ball;
        public static Sprite mid_uses_ball;
        public static Sprite low_uses_ball;
        public static Sprite no_uses_ball;

        public static Sprite base_image;

        public GameObject structure;

        public Button button;
        public GameObject BASE;
        public GameObject character_image_game_object;
        public Image character_image;


        public GameObject ball_up;
        public Image ball_up_image;

        public GameObject ball_down;
        public Image ball_down_image;

        public GameObject ball_left;
        public Image ball_left_image;

        public GameObject ball_right;
        public Image ball_right_image;

        public GameObject skills_container;




        public Button cancel_button;
        public Skill_container skill_up;
        public Skill_container skill_down;
        public Skill_container skill_left;
        public Skill_container skill_right;



        public GameObject life_points_game_object;
        public TextMeshProUGUI life;
        public float max_life;
        public float current_life;


        public bool die;


        
        public void Add_damage( int _damage ){

            current_life -= _damage;
            if( current_life <= 0 )
                {  
                    Die(); 
                    current_life = 0f;
                }

            Update_life();
            Controllers.characters.Verify_still_1_alive();

        }

        public void Die(){

            
            Debug.Log( "MORREU" );
            die = true;
            character_image.color = new Color( 0.2f,0.2f,0.2f, 1f );
            

        }

        public void Return_skills_container(){ skills_container.transform.SetParent( structure.transform, false ); }


        // ** logica 

        public void Liberat_cast(){ data.can_cast = true; }
        public void Block_cast(){ data.can_cast = true; }


        public void Destroy(){

            Return_skills_container();
            GameObject.Destroy( structure );
            
        }


        public Character_data data;



        public Combat_character( string _name ){

            if( !!!( Combat_character_container.characters_data.TryGetValue( _name, out data ) ) )
                { throw new System.Exception( $"Tried to get the character <Color=lightBlue>{ _name }</Color> but it was NOT in the Characters_container" ); }

            // ** default

            data.name =_name;
            data.can_cast = true;


            structure = GameObject.Instantiate( Resources.Load<GameObject>( Paths_combate_modelo_1.Get_path( "Character_structure" ) ) );
            structure.name = $"Character_{ _name }";

            structure.transform.SetParent( GameObject.Find( "Canvas" ).transform, false );
            structure.transform.localPosition = Vector3.zero;


            BASE = structure.transform.GetChild( 0 ).gameObject;
            button = BASE.GetComponent<Button>();
            character_image_game_object = structure.transform.GetChild( 1 ).gameObject;
            character_image = character_image_game_object.GetComponent<Image>();
            character_image.sprite = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( $"Characters/{ data.name }/main" ) );
            RectTransform rect = character_image_game_object.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 150f );
            rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 150f );
            
            
            
            GameObject skills_balls = structure.transform.GetChild( 2 ).gameObject;

                ball_up    = skills_balls.transform.GetChild( 0 ).gameObject;
                ball_up_image = ball_up.GetComponent<Image>();
                ball_down  = skills_balls.transform.GetChild( 1 ).gameObject;
                ball_down_image = ball_down.GetComponent<Image>();
                ball_left  = skills_balls.transform.GetChild( 2 ).gameObject;
                ball_left_image = ball_left.GetComponent<Image>();
                ball_right = skills_balls.transform.GetChild( 3 ).gameObject;
                ball_right_image = ball_right.GetComponent<Image>();

            
            // button = structure.transform.GetChild( 3 ).GetComponent<Button>();



            skills_container = structure.transform.GetChild( 3 ).gameObject;

                cancel_button = skills_container.transform.GetChild( 0 ).gameObject.GetComponent<Button>();
                cancel_button.onClick.AddListener( ()=>{ skills_container.SetActive( false ); } );

                skill_up    = Get_skill_container( skills_container.transform.GetChild( 1 ).gameObject );
                skill_down  = Get_skill_container( skills_container.transform.GetChild( 2 ).gameObject );
                skill_right = Get_skill_container( skills_container.transform.GetChild( 3 ).gameObject );
                skill_left  = Get_skill_container( skills_container.transform.GetChild( 4 ).gameObject );


            // ** LOGICA

            Construct_skill( Skill.up, skill_up );
            Construct_skill( Skill.down, skill_down );
            Construct_skill( Skill.left, skill_left );
            Construct_skill( Skill.right, skill_right );



            skills_container.SetActive( false );


            current_life = ( data.life == 0 )? 30 : data.life;
            max_life = data.life;
            life_points_game_object = new GameObject( "life points" );
            life_points_game_object.transform.SetParent( structure.transform, false );
            life_points_game_object.transform.localPosition = new Vector3( 0f, -135f, 0f );
            life = life_points_game_object.AddComponent<TextMeshProUGUI>();
            life.text = $"{ data.life } LP/ { data.life } LP";
            life.fontSize = 25f;
            life.alignment = TextAlignmentOptions.TopGeoAligned;
            RectTransform rect_2 = life_points_game_object.GetComponent<RectTransform>();
            rect_2.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 100f );
            rect_2.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 200f );





            button.onClick.AddListener(()=>{  

                if( data.can_cast && !!!( die ) )
                    { skills_container.SetActive( true );}


            });

            
            



            Skill_container Get_skill_container( GameObject _main ){

                Skill_container ret = default;

                    ret.game_object = _main;
                    ret.button = _main.GetComponent<Button>();
                    ret.BASE = _main.GetComponent<Image>();
                    ret.icon = _main.transform.GetChild( 0 ).gameObject.GetComponent<Image>();
                    ret.text =  _main.transform.GetChild( 1 ).gameObject.GetComponent<TextMeshProUGUI>();
                    RectTransform rect = _main.transform.GetChild( 1 ).gameObject.GetComponent<RectTransform>();
                    rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 45f );
                    rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 75f );

                    
                    if( ret.button == null )
                        { throw new System.Exception( "Do not have the button" ); }

                    if( ret.icon == null )
                        { throw new System.Exception( "Do not have the image" ); }

                    if( ret.text == null )
                        { throw new System.Exception( "Do not have the text" ); }

                return ret;

            }

        }

        
        public void Update_life(){

            if( current_life > max_life )
                { life.color = Color.green; }

            life.text = $"{ current_life } LP/ { max_life } LP";


        }


        public void Change_balls( Skill _skill ){

            int number_left  = data.Get_skill( _skill ).number_casts;

            
            Sprite sprite_ball = null;

            if( ( number_left / 30 ) > 1 )
                {
                    // ** verde
                    sprite_ball = a_lot_of_uses_ball;
                    
                } else
            
            if( ( number_left / 10 ) > 1 )
                {
                    // ** amarelo
                    sprite_ball =  mid_uses_ball;

                } else{

                    sprite_ball = low_uses_ball;
                }
                

            if( number_left == 0 )
                {
                    // ** cinza
                    // ** block
                    sprite_ball = no_uses_ball;

                    switch( _skill ){

                        case Skill.up: skill_up.button.interactable = false;  skill_up.icon.color = new Color( 0.2f,0.2f,0.2f, 1f ); break;
                        case Skill.left: skill_left.button.interactable = false;  skill_left.icon.color = new Color( 0.2f,0.2f,0.2f, 1f ); break;
                        case Skill.right: skill_right.button.interactable = false;  skill_right.icon.color = new Color( 0.2f,0.2f,0.2f, 1f ); break;
                        case Skill.down: skill_down.button.interactable = false;  skill_down.icon.color = new Color( 0.2f,0.2f,0.2f, 1f ); break;
                    }

                }

            switch( _skill ){

                case Skill.up: ball_up_image.sprite = sprite_ball; break;
                case Skill.left: ball_left_image.sprite = sprite_ball; break;
                case Skill.right: ball_right_image.sprite = sprite_ball; break;
                case Skill.down: ball_down_image.sprite = sprite_ball; break;

            }

            




        }


        public static class Skill_creator {

            public static UnityEngine.Events.UnityAction Create( Skill _skill, Combat_character _character ){


                return ()=>{

                    
                    Skill_data _skill_data = _character.data.Get_skill( _skill );

                    _character.skills_container.SetActive( false );
                    _character.data.Reduce_count_skill( _skill );
                    _character.Change_balls( _skill );
                    


                    // ** talvez certos personagens possas usar mais de uma skill por turno
                    _character.data.can_cast = false;
                    _character.skills_container.SetActive( false );

                    // Debug.Log( "Vai ativar skill: " + _skill_data.name );

                    if( _skill_data.skill_type == Skill_type.damage )
                        {
                            
                            Damage damage = new Damage();
                                damage.slot_target = Controllers.player.Get_current_target();
                                damage.place_to_instanciate = _character.structure;
                                damage.calculator = _skill_data.calculator;
                                damage.target_type = _skill_data.target_type;
                                damage.is_area = ( _skill_data.target_type == Skill_targt_type.area );
                                damage.visual_attack_name = _skill_data.visual_attack_name;
                                
                            Controllers.player.Add_damage( damage );
                            return;
                            
                        }

                    throw new Exception( $"an not handle type { _skill_data.skill_type }" );

                };
                
            }

        }


        private void Construct_skill( Skill _skill, Skill_container _skill_container ){



            string image_path = null;

            Skill_data skill_data = data.Get_skill( _skill );
            
            Change_balls( _skill );

            if( skill_data.name == null )
                { 
                    _skill_container.game_object.SetActive( false );
                    return; 
                } // ** NO SKILL




            // ** SKILL FUNCTION
            _skill_container.button.onClick.AddListener( 

                Skill_creator.Create( _skill, this )

            );


            // ** DEFAULT
            _skill_container.BASE.sprite = Combat_character.base_image;
            _skill_container.icon.sprite = null;
            _skill_container.icon.color = Color.clear;


            if( skill_data.special_image_name != null )
                { 
                    image_path = Paths_combate_modelo_1.Get_path( $"Characters/{ data.name }/{ skill_data.name }_image" ); 
                }
                else
                { 
                    if( ( skill_data.image_name == null ) || ( skill_data.image_name == "" ) )
                        { throw new System.Exception( $"Did not put the image_name in the character <Color=lightBlue>{ data.name }</Color> in the skill <Color=lightBlue>{ _skill }</Color>" ); }
                    image_path = Paths_combate_modelo_1.Get_path( $"Characters/Support/Skills/{ skill_data.image_name }" ); 
                }

            _skill_container.icon.sprite = SPRITE.Get_sprite( image_path );
            _skill_container.icon.color = Color.clear;

            // ** substitue por texto


            GameObject text = new GameObject( "text" );
            text.transform.localPosition += new Vector3( 0f, 20f, 0f );
            TextMeshProUGUI text_thing = text.AddComponent<TextMeshProUGUI>();
            text_thing.fontSize = 17f;
            text_thing.alignment = TextAlignmentOptions.TopGeoAligned;

            string uses = skill_data.number_casts > 500 ? "∞" : skill_data.number_casts.ToString() ;


            text_thing.text = $"USES: { uses } \n\n FIX: { skill_data.calculator.fix_damage } \n RANDON: { skill_data.calculator.max_slot_damage } \n TYPE: { skill_data.target_type }";
            text_thing.color = Color.green;
            text.transform.SetParent( _skill_container.BASE.transform, false );

            switch( _skill ){
                case Skill.up:  data.skill_up.text = text_thing; break;
                case Skill.down:  data.skill_down.text = text_thing; break;
                case Skill.left:  data.skill_left.text = text_thing; break;
                case Skill.right:  data.skill_right.text = text_thing; break;
                default: throw new System.Exception( $"Can not handle skill <Color=lightBlue>{ _skill }</Color>" );
            }


        
            _skill_container.text.text =""; // skill_data.name;
            // ** DESCRIPTION GENERATE RUN TIME


        }


        


}
