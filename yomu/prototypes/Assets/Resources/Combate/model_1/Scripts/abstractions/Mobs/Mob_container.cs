
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public struct Mob_data {

    public string name;
    public Mob_type_taunt taunt;

    // ** fix position
    public int[] fix_positions;

    // ** very_specifics
    // ** in order of importance
    public Character_trait[] traits;

    public Combat_information combat_information;

}

public static class Mob_container {

    public static Dictionary<string, Mob_data> mobs_data = new Dictionary<string, Mob_data>();

    public static Mob_data Get_mob_data( string _name ){

        if( !!!( mobs_data.TryGetValue( _name, out Mob_data data ) ) )
            { throw new System.Exception( $"Did not find the mob <Color=lightBlue>{ _name }</Color>" ); }

        return data;

    }

    static Mob_container(){

        mobs_data.Add( "albuin", new(){
            taunt = Mob_type_taunt.random,
            combat_information = new(){
                damage_calculator = new(){
                    fix_damage = 2,
                    number_slots = 2,
                    max_slot_damage = 3, 
                },
            specific_modifier_attack = ( Combat_character _character, Damage_calculator _start_damage_calculator ) => {

                if( _character.data.name == "Ruby" )
                    { _start_damage_calculator.fix_damage += 1; }

                return _start_damage_calculator;

            }
            },


        });

    }

}