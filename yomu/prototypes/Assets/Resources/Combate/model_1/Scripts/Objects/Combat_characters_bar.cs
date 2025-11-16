

using UnityEngine;
using UnityEngine.UI;


public class Combat_characters_bar {


        public Combat_characters_bar(){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                Combat_characters_slots[ i ] = GameObject.Find( "Canvas/Game/character/Character_" + ( i + 1 ).ToString() );
            }

            container_slots_skills = GameObject.Find( "Canvas/Game/Skills_slots" );

        }


        private const int NUMBER_COMBAT_CHARACTERS = 5;
        public Combat_character[] characters_in_combat = new Combat_character[ NUMBER_COMBAT_CHARACTERS ];
        public GameObject[] Combat_characters_skills_icons = new GameObject[ NUMBER_COMBAT_CHARACTERS ];
        public GameObject[] Combat_characters_slots = new GameObject[ NUMBER_COMBAT_CHARACTERS ];

        public GameObject container_slots_skills;


        public void Destroy(){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                
                if( characters_in_combat[ i ] == null )
                    { continue; }

                characters_in_combat[ i ].Return_skills_container();
                GameObject.Destroy( characters_in_combat[ i ].structure );

            }


        }


        public void Set_characters( Combat_character[] _characters ){

            if( _characters.Length != 5 )
                { throw new System.Exception( "veio menos que 5 personagens" ); }

            characters_in_combat = _characters;

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){

                Combat_characters_skills_icons[ i ] = _characters[ i ].skills_container;
                // Combat_characters_slots[ i ] = GameObject.Find( "Canvas/Game/character/Character_" + ( i + 1 ).ToString() );
                characters_in_combat[ i ].structure.transform.SetParent( Combat_characters_slots[ i ].transform, false );

                // ** fica na mesma posicao
                characters_in_combat[ i ].skills_container.transform.SetParent( container_slots_skills.transform );

            }


        
        }





        public void Change_character( Combat_character _combat_character, int _index  ){

            if( _index < 0 || _index > 4 )
                { throw new System.Exception( $"index nao permitido: <Color=lightBlue>{ _index }</Color>" ); }

            Combat_character retorno = characters_in_combat[ _index ];
            characters_in_combat[ _index ] = _combat_character;

            retorno.Return_skills_container();
            GameObject.Destroy( retorno.structure );

                Combat_characters_skills_icons[ _index ] = _combat_character.skills_container;

                characters_in_combat[ _index ].structure.transform.SetParent( Combat_characters_slots[ _index ].transform, false );

                // ** fica na mesma posicao
                characters_in_combat[ _index ].skills_container.transform.SetParent( container_slots_skills.transform );


            

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