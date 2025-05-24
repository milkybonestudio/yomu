using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;


public class Combat_character{

        static Combat_character(){    

            a_lot_of_uses_ball = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/ball_1" ) );
            mid_uses_ball = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/ball_2" ) );
            low_uses_ball = SPRITE.Get_sprite( Paths_combate_modelo_1.Get_path( "Characters/Support/ball_3" ) );
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
        public GameObject ball_down;
        public GameObject ball_left;
        public GameObject ball_right;

        public GameObject skills_container;


        public Button cancel_button;
        public Skill_container skill_up;
        public Skill_container skill_down;
        public Skill_container skill_left;
        public Skill_container skill_right;


        public void Return_skills_container(){ skills_container.transform.SetParent( structure.transform, false ); }


        // ** logica 

        public void Liberat_cast(){ data.can_cast = true; }
        public void Block_cast(){ data.can_cast = true; }


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
            
            
            GameObject skills_balls = structure.transform.GetChild( 2 ).gameObject;

                ball_up    = skills_balls.transform.GetChild( 0 ).gameObject;
                ball_down  = skills_balls.transform.GetChild( 1 ).gameObject;
                ball_left  = skills_balls.transform.GetChild( 2 ).gameObject;
                ball_right = skills_balls.transform.GetChild( 3 ).gameObject;

            
            // button = structure.transform.GetChild( 3 ).GetComponent<Button>();



            skills_container = structure.transform.GetChild( 3 ).gameObject;

                cancel_button = skills_container.transform.GetChild( 0 ).gameObject.GetComponent<Button>();
                cancel_button.onClick.AddListener( ()=>{ skills_container.SetActive( false ); } );

                skill_up    = Get_skill_container( skills_container.transform.GetChild( 1 ).gameObject );
                skill_down  = Get_skill_container( skills_container.transform.GetChild( 2 ).gameObject );
                skill_left  = Get_skill_container( skills_container.transform.GetChild( 3 ).gameObject );
                skill_right = Get_skill_container( skills_container.transform.GetChild( 4 ).gameObject );


            // ** LOGICA

            Construct_skill( Skill.up, skill_up );
            Construct_skill( Skill.down, skill_down );
            Construct_skill( Skill.left, skill_left );
            Construct_skill( Skill.right, skill_right );
            

            skills_container.SetActive( false );


            button.onClick.AddListener(()=>{  

                if( data.can_cast )
                    { skills_container.SetActive( true );}


            });



        }

        


        private Skill_container Get_skill_container( GameObject _main ){

            Skill_container ret = default;

                ret.game_object = _main;
                ret.button = _main.GetComponent<Button>();
                ret.BASE = _main.GetComponent<Image>();
                ret.icon = _main.transform.GetChild( 0 ).gameObject.GetComponent<Image>();
                ret.text =  _main.transform.GetChild( 1 ).gameObject.GetComponent<TextMeshProUGUI>();

                
                if( ret.button == null )
                    { throw new System.Exception( "Do not have the button" ); }

                if( ret.icon == null )
                    { throw new System.Exception( "Do not have the image" ); }

                if( ret.text == null )
                    { throw new System.Exception( "Do not have the text" ); }
                

            return ret;

        }


        public void Update(){

            
        }

        public static class Skill_creator {

            public static UnityEngine.Events.UnityAction Create( Skill_data _skill_data, Combat_character _character ){

                if( _skill_data.target_type == Skill_targt_type.single )
                    {
                        return ()=>{

                           // Mob_controller.Get_current_target().Receive_damage( _skill_data.calculator );

                           _character.data.can_cast = false;
                           _character.skills_container.SetActive( false );
                            
                            

                        };
                    }
                return null;


            }

        }


        private void Construct_skill( Skill _skill, Skill_container _skill_container ){



            string image_path = null;

            Skill_data skill_data = data.Get_skill( _skill );

            // ** SKILL FUNCTION
            _skill_container.button.onClick.AddListener( Skill_creator.Create( skill_data, this ) );


            // ** DEFAULT
            _skill_container.BASE.sprite = Combat_character.base_image;
            _skill_container.icon.sprite = null;
            _skill_container.icon.color = Color.clear;

            if( skill_data.name == null )
                { return; } // ** NO SKILL


            if( skill_data.special_image )
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
            _skill_container.icon.color = Color.white;

            _skill_container.text.text = skill_data.name;
            // ** DESCRIPTION GENERATE RUN TIME


        }

        


}
