
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public struct Mob_data {

    public string name;
    public Mob_type_taunt taunt;
    // public Combat_information combat_information;
    public int damage;
    public int life;

}

public static class Mob_container {


    public static void Verify_mobs( string[][] _mobs ){

        foreach( string[] mobs_line in _mobs ){

            foreach( string mob in mobs_line ){

                Get_mob_data( mob );

            }

        }

    }

    public static Dictionary<string, Mob_data> mobs_data = new Dictionary<string, Mob_data>();

    public static Mob_data Get_mob_data( string _name ){

        if( !!!( mobs_data.TryGetValue( _name, out Mob_data data ) ) )
            { throw new System.Exception( $"Did not find the mob <Color=lightBlue>{ _name }</Color>" ); }

        return data;

    }

    static Mob_container(){


        mobs_data.Add( "Javali", new(){
            taunt = Mob_type_taunt.random,
            life = 35,
            damage = 3,
        });

        mobs_data.Add( "Mico", new(){
            taunt = Mob_type_taunt.less_life,
            life = 15,
            damage = 1,
        });

        mobs_data.Add( "Alce", new(){
            taunt = Mob_type_taunt.random,
            life = 125,
            damage = 5,
        });

        mobs_data.Add( "Bear", new(){
            taunt = Mob_type_taunt.less_life_chance,
            life = 250,
            damage = 8,

        });

        mobs_data.Add( "Tartaruga", new(){
            taunt = Mob_type_taunt.random,
            life = 100,
            damage = 1,

        });


    }

}