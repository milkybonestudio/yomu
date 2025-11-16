

using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// ** somente characters -> mobs 
// ** character dao dano rng mas mobs dao constante 
// ** variando somente a skill
public class Damage {


    public Damage_stage stage;
    public int slot_target; // ** default nao pega
    public Damage_calculator calculator;
    public string visual_attack_name;
    public Coroutine coroutine;
    public bool is_area;
    public Skill_targt_type target_type;

    // ** 
    public GameObject place_to_instanciate;
    public GameObject game_object;
    public TextMeshProUGUI text;

    public void Start_damage(){

        if( place_to_instanciate == null )
            { throw new System.Exception( "Did not define a place to instanciate" ); }


        game_object = new GameObject( "damage" );
        game_object.transform.SetParent( place_to_instanciate.transform, false );
        game_object.transform.localPosition += new Vector3( 0f, 100f, 0f );
        text = game_object.AddComponent<TextMeshProUGUI>();
        text.text = $"";
        text.fontSize = 35f;
        text.color = Color.green;
        text.alignment = TextAlignmentOptions.TopGeoAligned;
        RectTransform rect = text.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 50f );
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 150f );

        
        stage = Damage_stage.rolling_numbers;
        coroutine = Controllers.main.Start_coroutine( Update_damage() );

    }

    public void Update(){



    }

    private int _rng;
    private void Change_rng( int _fix_value, int _current_rng ){

        text.text = $" { _fix_value } + { _current_rng } ";

    }

    public void Destroy(){

        
        Controllers.main.Stop_coroutine( coroutine );
        GameObject.Destroy( game_object );


    }

    public System.Random random = new System.Random( ( int )( Time.deltaTime * 17_333f ) );

    public void Start_rng(){

         

        if( stage != Damage_stage.rolling_numbers )
            { throw new System.Exception(); }

        stage = Damage_stage.rng_calculation;


    }

    private IEnumerator Update_damage(){

        _rng = random.Next( calculator.max_slot_damage + 1 );
        float time = 0f;
        float ms_to_change = 50f;
        float current_acc = ms_to_change;
        float time_to_stop = 500f;

        // ** quem controla o damage tem que mudar a flag manuela
        
        while( stage == Damage_stage.rolling_numbers ){

            current_acc -= Time.deltaTime * 1_000f;
    
            if( current_acc <= 0f )
                { 
                    Change_rng( calculator.fix_damage, _rng++ % ( calculator.max_slot_damage + 1 )  );
                    current_acc = ms_to_change;
                    yield return null;
                }
            
        }

        float start_speed = 25f;
        ms_to_change = start_speed;

        
        while( ms_to_change <= time_to_stop  )
            {

                current_acc -= Time.deltaTime * 1_000f;            
                if( current_acc <= 0f )
                    {
                        _rng = ( ( 1 + ( ( calculator.max_slot_damage / 10 )  ) ) + _rng ) % ( calculator.max_slot_damage + 1 );
                        Change_rng( calculator.fix_damage, _rng ); 
                        ms_to_change += ( 2.5f - ( ms_to_change / 10f ) + ( ( ms_to_change * ms_to_change  ) / 600f ) ) + ( ( ms_to_change * ms_to_change * ms_to_change ) / ( 7 * start_speed * start_speed * start_speed ));
                        current_acc = ms_to_change;
                    }

                yield return null;

            }


        stage = Damage_stage.got_number;

        float time_to_wait_first_ms = 350f;

        while( ( time_to_wait_first_ms ) > 0f )
            {  time_to_wait_first_ms -= ( Time.deltaTime * 1_000f ); yield return null; }


        text.text = $"<b>{ calculator.fix_damage + _rng }<b>";
        text.color = new Color32( 245, 226, 15, 255 );
        text.fontSize += 5;
        game_object.transform.localPosition += new Vector3( 0f, 1f, 0f );
        


        float time_to_wait_second_ms = 350f;
        while( ( time_to_wait_second_ms  ) > 0f )
            { time_to_wait_second_ms -= ( Time.deltaTime * 1_000f ); yield return null; }




        stage = Damage_stage.animation;

        if( visual_attack_name == null )
            {
                visual_attack_name = "slash";
            }
        
        VISUAL_CONTAINER__visual_attacks.Add_visual_attack(
            CONTAINER__visual_attack.Get_visual_attakc( visual_attack_name )
        );

        yield return null;

        stage = Damage_stage.finished;
        Controllers.mobs.Add_damage( ( _rng + calculator.fix_damage ), slot_target, target_type  );
        
        

        // ** 

        yield break;

    }

}