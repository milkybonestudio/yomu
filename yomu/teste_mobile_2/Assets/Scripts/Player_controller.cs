using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using TMPro;
using Unity.Collections;
using UnityEngine;

public enum State {

    stop,
    running, 

}


public enum Jump_state {

        not, 
        jumped, 

}


public enum Player_state {

    normal, 
    sex,

}
public struct Stats {

    public int life_points;
    public int distance;
    public int sex_with_animals;
    public int sex_with_people;
    public int speed;

}


[StructLayout(LayoutKind.Sequential)]
public struct Save {

    public static Save Construct(){

        Save ret = default;

            ret.stats.life_points = 250;
            ret.stats.sex_with_animals = 0;
            ret.stats.sex_with_people = 0;
            ret.stats.speed = 5;
            ret.stats.distance = 0;

        return ret;

    }

    public Stats stats;

}


public unsafe class Player_controller : MonoBehaviour{


        public static Player_controller player;
        public Animator animator;
        public Rigidbody2D body;

        public AnimationClip albuin_sex;

        public GameObject terrno;
        
        public Stats* stats_pointer;

        public Player_state state;

        public Manager_save manager_save;

        public TextMeshPro life_points;
        public TextMeshPro sex_with_animals;
        public TextMeshPro sex_with_people;
        public TextMeshPro distance;
        

        public SpriteRenderer sprite_render;

        public Touch_manager touch_manager = new Touch_manager();


        public Jump_state jump_state;


        void Start(){

                player = this;
                animator = gameObject.GetComponent<Animator>();
                body = gameObject.GetComponent<Rigidbody2D>();

                animations_original = new AnimationClip[ animator.runtimeAnimatorController.animationClips.Length ];
                for( int animation_slot = 0 ; animation_slot < animations_original.Length ;animation_slot++ )
                    { animations_original[ animation_slot ] =  animator.runtimeAnimatorController.animationClips[ animation_slot ]; }
                    

                Application.targetFrameRate = 60;


                sprite_render = gameObject.transform.GetChild( 0 ).gameObject.GetComponent<SpriteRenderer>();
                
                Set_UI();
                posicao_anterior = gameObject.transform.localPosition;
                posicao_inicial = gameObject.transform.localPosition;
                posicao_zero = posicao_inicial - new Vector3( 3f/100f, 3f/100f, 3f/100f );

                // --- MANAGER
                    manager_save = new Manager_save();
                    stats_pointer = &(manager_save.save_pointer->stats);

                    gameObject.transform.localPosition = new Vector3( ( float ) stats_pointer->distance, -1f, 10f );

                    
        }

        private Vector3 posicao_inicial;
        private Vector3 posicao_zero;
        private Vector3 posicao_anterior;

        

        public void Increase_number_sex_animals( int _number ){ stats_pointer->sex_with_animals += _number; }
        public void Increase_number_sex_people( int _number ){ stats_pointer->sex_with_people += _number; }

        public void Hit_damage( int _damage ){

            int life = stats_pointer->life_points;
            life -= _damage;

            if( life < 0 )
                { life = 0; }
            
            stats_pointer->life_points = life;


        }



    
        
        Stats stats_value;

        public void Change_color_word( TextMeshPro _text, string _word, Color32 _color = new Color32(), int _index = -1 ){


                int index_word = -1;

                if( _index != -1 )
                    {  index_word = _index; }

                _text.ForceMeshUpdate();

                TMP_WordInfo info = _text.textInfo.wordInfo[ index_word ];

                for (int i = 0; i < info.characterCount; ++i)
                {
                    int charIndex = info.firstCharacterIndex + i;
                    int meshIndex = _text.textInfo.characterInfo[charIndex].materialReferenceIndex;
                    int vertexIndex = _text.textInfo.characterInfo[charIndex].vertexIndex;
                
                    Color32[] vertexColors = _text.textInfo.meshInfo[meshIndex].colors32;
                    vertexColors[vertexIndex + 0] = _color;
                    vertexColors[vertexIndex + 1] = _color;
                    vertexColors[vertexIndex + 2] = _color;
                    vertexColors[vertexIndex + 3] = _color;

                    
                }



                _text.UpdateVertexData( TMP_VertexDataUpdateFlags.Colors32 );
                

        }

        public Vector2 velocity_body;



// Animator animator (get component blablabla)
// AnimationClip anim (field in inspector)



        public int hit_to_unlock = 50;
        // Update is called once per frame
        void Update(){

            touch_manager.Update();


            // if( touch_manager.touches[ 0 ].state == Touch_state.used )
            //     { Stop_sex(); }


            stats_pointer->distance = ( int ) gameObject.transform.localPosition.x;
            
            
            life_points.text = ( "life points: " + ( stats_pointer->life_points ).ToString());

                if( stats_pointer->life_points < 25 )
                    {
                        Change_color_word( life_points, null, UnityEngine.Color.red, 2 );
                    }
            else if( stats_pointer->life_points < 50 )
                    {
                        Change_color_word( life_points, null, new UnityEngine.Color32( 235, 155, 52, 255 ), 2 );
                    }
            else if( stats_pointer->life_points < 75 )
                    {
                        Change_color_word( life_points, null, UnityEngine.Color.yellow , 2 );
                    }
            else if( true )
                    {
                        Change_color_word( life_points, null, UnityEngine.Color.green, 2 );
                    }


            
            
            sex_with_animals.text = ( "sex with animals: " + ( stats_pointer->sex_with_animals).ToString() );
            sex_with_people.text = ( "sex with people: " + ( stats_pointer->sex_with_people ).ToString() );
            distance.text = ( "distance: " + ( stats_pointer->distance ).ToString() );


            
            manager_save.Update();


            Vector3 terreno_location = terrno.transform.localPosition;
            Vector3 player_location = gameObject.transform.localPosition;

            float dif_x = ( terreno_location.x - player_location.x );

            terreno_location.x = ( -1f * player_location.x );

            terrno.transform.localPosition = terreno_location;


            // --- SET
                animator.SetBool( "is_falling", ( body.velocity.y ) > 0.1f );
                animator.SetBool( "is_running", ( gameObject.transform.localPosition - posicao_anterior ).x > 0.001f );
                animator.SetBool( "is_jumping", ( gameObject.transform.localPosition ).y > posicao_zero.y );

                posicao_anterior = gameObject.transform.localPosition;


            if( state == Player_state.sex )
                {
                    Camera_adjust.camera_final_position = gameObject.transform.position; 
                    Camera_adjust.camera_final_position -= new Vector3( 0f,0.3f,2f );
                    Hit_damage( 1 );

                    if( touch_manager.touches[ 0 ].state == Touch_state.used )
                        { hit_to_unlock--; }

                    if( hit_to_unlock == 0 )
                        { 
                            hit_to_unlock = 50; 
                            Stop_sex();   
                        }

                    


                    return;
                }


            
            
        }

        private float Base( float _f ){

            if( ( _f < 0.001f ) && ( _f > -0.001f )  )
                { return 0f; }

            return _f;

        }

        public void Jump(){

            if( jump_state == Jump_state.jumped )
                { return; }

            jump_state = Jump_state.jumped;

            body.velocity = new Vector2( body.velocity.x, 10f );
            animator.SetBool( "is_jumping", true );

        }


        public AnimationClip[] animations_original;


        public void Stop_sex(){

                Debug.Log( "Veio Stop_sex" );

                Camera_adjust.Set_normal_position();

                AnimatorOverrideController aoc = new AnimatorOverrideController( animator.runtimeAnimatorController );
                var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();

                for( int animation_slot = 0 ; animation_slot < animations_original.Length ;animation_slot++ )
                    {   anims.Add(new KeyValuePair<AnimationClip, AnimationClip>( animations_original[ animation_slot ], aoc.animationClips[ animation_slot ] ) ); }
                        
                
                aoc.ApplyOverrides( anims );
                animator.runtimeAnimatorController = aoc;

                state = Player_state.normal;
                


        }

        

        public void Start_sex( int _thing ){

            Debug.Log( "veio Start_sex" );

            AnimationClip clip = null;
            switch( _thing ){

                case 1: clip = albuin_sex; break;

            }

            Camera_adjust.camera_final_position = gameObject.transform.position; 
            Camera_adjust.camera_final_position -= new Vector3( 0f,0f,2f );
            new Vector3( 0f,0f, 2.5f );

            state = Player_state.sex;
            


            AnimatorOverrideController aoc = new AnimatorOverrideController( animator.runtimeAnimatorController );
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();

            foreach ( AnimationClip a in aoc.animationClips)
                anims.Add(new KeyValuePair<AnimationClip, AnimationClip>( a, clip ) );

            aoc.ApplyOverrides(anims);
            animator.runtimeAnimatorController = aoc;

        }


        public void Cast(){



            animator.SetBool( "is_casting", true );

        }

        void OnCollisionEnter2D( Collision2D _collision ){

            Debug.Log( _collision );

            if( _collision.rigidbody.bodyType == RigidbodyType2D.Static )
                { jump_state = Jump_state.not; }
                else
                {
                    // --- albuin 

                    Start_sex( 1 );
                    Destroy( _collision.gameObject );

                }

            
            

        }

        public bool run = false;

        public void Run(){


            gameObject.transform.localPosition +=  new Vector3( ( ( ( float ) stats_pointer->speed ) * Time.deltaTime), 0f, 0f );
            
        }



        public void Set_UI(){

            UI_actions.Add( "Jump", Jump );
            UI_actions.Add( "Cast", Cast );
            UI_actions.Add( "Run", Run );

        }

        public Dictionary<string,Action> UI_actions = new Dictionary<string, Action>();

        public void Activate_UI( string _nome_UI ){

            if( !!!( UI_actions.TryGetValue( _nome_UI, out Action a ) ) )  
                { Debug.Log( "dont ahve " + _nome_UI ); return; }

            a();

        }



        void OnApplicationQuit(){ OnApplicationPause( true ); } // ** no mobile onQuit não é chamado, mas é no editor }
        void OnApplicationPause( bool _is_paused ){

                if( _is_paused )
                    { manager_save.Save_data(); }
            
        }





}



