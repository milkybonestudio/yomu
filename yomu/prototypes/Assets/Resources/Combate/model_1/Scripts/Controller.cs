using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class Controller : MonoBehaviour{


        public Stage stage;

        public static Controller instance;


        Combat_character ruby;
        
        void Start(){


            Audios.Start_music();

            Controllers.main = this;

            // ** MATERIALS
            
            VISUAL_CONTAINER__visual_attacks.Construct();
            Character_giver.Start();
            
            instance = this;

            finalize_game_object = GameObject.Find( "Canvas/Finalize" );
            finalize_button = finalize_game_object.GetComponent<Button>();
            finalize_button.onClick.AddListener(()=>{

                finalize_game_object.SetActive( false );
                Change_stage( Stage.menu );

            });

            finalize_game_object.SetActive( false );


            // ** iniciar containers 
            new CONTROLLER__combat();
            new CONTROLLER__path();
            new Menu();

            Controllers.menu.Start();

        }


        public void Change_stage( Stage _stage ){

            Controllers.menu.container.SetActive( false );
            Controllers.path.container.SetActive( false );
            Controllers.combat.container.SetActive( false );

            switch( _stage ){

                case Stage.menu: Controllers.menu.container.SetActive( true ); break;
                case Stage.combat: Controllers.combat.container.SetActive( true ); break;
                case Stage.choosing_path: Controllers.path.container.SetActive( true ); break;

            }

            stage = _stage;
            // Debug.Log( "vai mudar para stage " + _stage );

        }




        void Update(){

            if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                { Character_giver.Start( new Combat_character( "Maki" ) ); }

            
            Mob.Touch();


            
            Audios.Update();
            VISUAL_CONTAINER__visual_attacks.Update();

            switch( stage ){
                case Stage.menu: Controllers.menu.Update(); break;
                case Stage.combat: Controllers.combat.Update(); break;
                case Stage.choosing_path: Controllers.path.Update(); break;
                case Stage.final: break;
                default: throw new System.Exception( $"Can not handle stage type { stage }" ); 
            }
            
        }

        // ** quem vai chamar geralmente é o menu
        public void Start_fase( Fase _fase ){

            _fase.map = Get_map( _fase.map_name );
            
            Controllers.path.Start_fase( _fase );
            Controllers.combat.Start_fase( _fase );

            Change_stage( Stage.combat );

        }

        private I_map Get_map( string _name ){

            switch( _name  ){

                case "map_1": return new MAP_1();
                default: throw new System.Exception( "Could no find map <Color=lightBlue>{ _name }</Color>" );

            };

        }


        public Button finalize_button;
        public GameObject finalize_game_object;
        public void Finalise(){

            Debug.Log( "veio finalize" );

            finalize_game_object.SetActive( true );
            finalize_game_object.GetComponent<Image>().sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( "end_win" ) );

            Controllers.path.Destroy();
            Controllers.mobs.Destroy();
            Controllers.characters.Destroy();
            Change_stage( Stage.final );
            

        }

        public void Finalise_lose(){

            Debug.Log( "veio finalize" );

            finalize_game_object.SetActive( true );
            finalize_game_object.GetComponent<Image>().sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( "end_lose" ) );

            Controllers.path.Destroy();
            Controllers.combat.Destroy();
            // Controllers.mobs.Destroy();
            // Controllers.characters.Destroy();
            Change_stage( Stage.final );

        }


        public Coroutine Start_coroutine( IEnumerator _num ){

            return StartCoroutine( _num );

        }

        
        public void Stop_coroutine( Coroutine _num ){

            if( _num == null )
                { return; }
            
            StopCoroutine( _num );

        }


}


