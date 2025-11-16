

using UnityEngine;
using UnityEngine.UI;

public enum Start_fase_stage{

    choosing_main_characters, 
    choosing_bench,
    finished,

}


public abstract class Player_action{ public abstract void Activate(); }
public class Player_pass_turn : Player_action{

    public override void Activate(){

        Controllers.combat.Start_mob_turn();
    }

}

public class Player_auto  : Player_action{

    public override void Activate(){

        for( int i = 0 ; i < 5 ; i++ ){

            if( !!!( Controllers.characters.characters_in_combat[ i ].die ) && ( Controllers.characters.characters_in_combat[ i ].data.can_cast ) )
                { Controllers.characters.characters_in_combat[ i ].skill_left.button.onClick.Invoke(); }

        }

    }

}


public class CONTROLLER__player {


    public CONTROLLER__player(){
        
        Controllers.player = this;
        new CONTROLLER__characters();

        player_inputs = new Player_inputs();

        pass_turn_button = GameObject.Find( "Canvas/Game/buttons/button_pass_turn" ).GetComponent<Button>();
        auto_button = GameObject.Find( "Canvas/Game/buttons/button_auto" ).GetComponent<Button>();

        block_player_input_game_object = GameObject.Find( "Canvas/Game/Block_player" );
        block_player_input_game_object.SetActive( false );

        pass_turn_button.onClick.AddListener(  ()=>{ current_player_action = new Player_pass_turn(); } );
        auto_button.onClick.AddListener(  ()=>{ current_player_action = new Player_auto(); } );

    }


    public Combat_character[] main_characters;
    public Combat_character[] bench; // ** max 6
    public Player_inputs player_inputs;
    public Player_action current_player_action;

    public GameObject block_player_input_game_object;

        public int current_index_used = -1;
        public Damage[] damages = new Damage[ 200 ];


        public Button pass_turn_button;
        public Button auto_button;



        public void Update(){

            Update_damage();

            current_player_action?.Activate();
            current_player_action = null;

        }



        public void Update_damage(){

            // Debug.Log( "veio update <Color=lightBlue>Player</Color>" );

            if( current_index_used == -1 )
                { return; }

            // Debug.Log( "Tem coisa " );

            bool can_start_rng = true;
            int damage_index = 0;

            // ** garante que todos iniciaram
            for( damage_index = 0; damage_index < ( current_index_used + 1 ) ; damage_index++ ){

                if( damages[ damage_index ].stage == Damage_stage.not_start )
                    { 
                        damages[ damage_index ].Start_damage(); 
                    } // ** inicia animation mas nao continua só gira as paradas e adiciona audio
            
            }


            // ** garante que pode iniciar a pegar o vaor
            for( damage_index = 0; damage_index < ( current_index_used + 1 ) ; damage_index++ ){
                
                if( damages[ damage_index ].stage == Damage_stage.rng_calculation )
                    { can_start_rng = false; break; } // ** tem que esperar acabar
            
            }

            if( can_start_rng )
                {                    
                    for( damage_index = 0; damage_index < ( current_index_used + 1 ) ; damage_index++ ){

                        if( damages[ damage_index ].stage == Damage_stage.rolling_numbers )
                            { damages[ damage_index ].Start_rng(); } // ** tem que esperar acabar
                    
                    }
                }
        }


    public void Add_damage( Damage _damage ){

        damages[ ++current_index_used ] = _damage;

        if( current_index_used == damages.Length )
            { throw new System.Exception( "chegou mais damage do que tinha espaço" ); }

        
        if( _damage == null )
            { throw new System.Exception( "fdamage veio null" ); }

    }




    public int current_mob_target;
    public int Get_current_target(){

        if( Controllers.main.stage != Stage.combat )
            { throw new System.Exception( "stage is not combat" ); }

        if( current_mob_target >= Controllers.mobs.current_mobs.Length || current_mob_target < 0 )
            { throw new System.Exception( $"Current target is <Color=lightBlue>{ current_mob_target }</Color> but the length is <Color=lightBlue>{ Controllers.mobs.current_mobs.Length }</Color>" ); }

        return current_mob_target;

    }


    public void Destroy(){

        Controllers.characters.Destroy();
        block_player_input_game_object.SetActive( false );
        
        // int line = 0;
        // for( line = 0 ; line < main_characters.Length ; line++ ){
        //     main_characters[ line ]?.Destroy();
        // }

        // for( line = 0 ; line < bench.Length ; line++ ){
        //     bench[ line ]?.Destroy();
        // }

    }


    public void Start_fase(){

        Controllers.characters.Start_fase( main_characters, bench );

    }



    // ** chamado no controller_combat
    public void Start_turn(){

        block_player_input_game_object.SetActive( false );
        Controllers.characters.Liberate_cast();

    }
    public void End_turn(){

        block_player_input_game_object.SetActive( true );
        Controllers.characters.Block_cast();

        for( int i = 0 ; i < (current_index_used + 1 ) ; i++ ){
            damages[ i ].Destroy();
        }

        current_index_used = -1;


    }

    public void End(){
        
    }

    
}
