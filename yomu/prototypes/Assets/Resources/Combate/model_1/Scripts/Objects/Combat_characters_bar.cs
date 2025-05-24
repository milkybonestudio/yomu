

using UnityEngine;
using UnityEngine.UI;


public class Characters_controller {

        public Characters_controller(){

            characters_bar = new Combat_characters_bar();
            support_character_bar = new Support_character_bar();

            characters_bar.Set_characters(new Combat_character[]{
                new Combat_character( "Ruby" ),
                new Combat_character( "Ruby" ),
                new Combat_character( "Ruby" ),
                new Combat_character( "Ruby" ),
                new Combat_character( "Ruby" )   
            });



        }

        public void Start_fase( string[] _names ){

        }

        private const int NUMBER_COMBAT_CHARACTERS = 5;

        public Combat_characters_bar characters_bar;
        public Support_character_bar support_character_bar;

        public Combat_character[] characters_in_combat = new Combat_character[ NUMBER_COMBAT_CHARACTERS ];






}

public class Combat_characters_bar {


        private const int NUMBER_COMBAT_CHARACTERS = 5;
        public Combat_character[] characters_in_combat = new Combat_character[ NUMBER_COMBAT_CHARACTERS ];
        public GameObject[] Combat_characters_skills_icons = new GameObject[ NUMBER_COMBAT_CHARACTERS ];
        public GameObject[] Combat_characters_slots = new GameObject[ NUMBER_COMBAT_CHARACTERS ];

        public GameObject container_slots_skills;



        public void Set_characters( Combat_character[] _characters ){

            if( _characters.Length != 5 )
                { throw new System.Exception( "veio menos que 5 personagens" ); }

            characters_in_combat = _characters;

            container_slots_skills = GameObject.Find( "Canvas/Skills_slots" );

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){

                Combat_characters_skills_icons[ i ] = _characters[ i ].skills_container;
                Combat_characters_slots[ i ] = GameObject.Find( "Canvas/character/Character_" + ( i + 1 ).ToString() );

                characters_in_combat[ i ].structure.transform.SetParent( Combat_characters_slots[ i ].transform, false );

                // ** fica na mesma posicao
                characters_in_combat[ i ].skills_container.transform.SetParent( container_slots_skills.transform );

            }


        
        }

        public Combat_character Change_character( int _index, Combat_character _combat_character ){

            if( _index < 0 || _index > 4 )
                { throw new System.Exception( "index nao permitido: <Color=lightBlue>{ _index }</Color>" ); }

            Combat_character retorno = characters_in_combat[ _index ];
            characters_in_combat[ _index ] = _combat_character;
            
            return retorno;

        }

        public void Activate_skill_options( int _index ){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                Combat_characters_skills_icons[ i ]?.SetActive( false );
            }

            if( Combat_characters_skills_icons[ _index ] == null )
                { throw new System.Exception( $"Tentou ativar skill options no index { _index }" ); }

            Combat_characters_skills_icons[ _index ].SetActive( false );

        }



}


public struct Support_character {

    public static Support_character Construct( string _path ){

        Support_character support = default;

            support.image = GameObject.Find( _path + "/character_image" ).GetComponent<Image>();
            support.skill_1 = GameObject.Find( _path + "/Base_skills/spell_1" ).GetComponent<Button>();
            support.skill_2 = GameObject.Find( _path + "/Base_skills/spell_2" ).GetComponent<Button>();
            support.skill_3 = GameObject.Find( _path + "/Base_skills/spell_3" ).GetComponent<Button>();
            
        return support;

    }

    
    public Image image;
    public Button skill_1;
    public Button skill_2;
    public Button skill_3;

}

public class Support_character_bar {


    public int a;
    public Support_character_bar(){
        Debug.Log( a++ );
        // container = GameObject.Find( "Canvas/support" );
    }

    public GameObject container;

    public Support_character megumin;
    public Support_character other;

    public void Start(){

        // megumin = Support_character.Construct( "Canvas/support/Support_example_1" );

        //     megumin.image.sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( "Characters_support/Megumin/icon" ) );
        //     megumin.skill_1.onClick.AddListener( ()=>{ Debug.Log( "EEEEEXPLOTIOON" ); } );
        //     megumin.skill_2.onClick.AddListener( ()=>{ Debug.Log( "nada" ); } );
        //     megumin.skill_3.onClick.AddListener( ()=>{ Debug.Log( "nada" ); } );

        // other = Support_character.Construct( "Canvas/support/Support_example_1" );

        //     other.image.sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( "Characters_support/other/icon" ) );
        //     other.skill_1.onClick.AddListener( ()=>{ Debug.Log( "nada" ); } );
        //     other.skill_2.onClick.AddListener( ()=>{ Debug.Log( "nada" ); } );
        //     other.skill_3.onClick.AddListener( ()=>{ Debug.Log( "nada" ); } );


    }

    





}