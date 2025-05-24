

public delegate Damage_calculator Specific_mob_damage_calculator( Combat_character _character, Damage_calculator _start_calculator );
public struct Combat_information {

    public int life_points;
    public int life_regem; // ** each 5 turns 

    // ** damage:
    // ** fix + number_slots * base_slot
    public Damage_calculator damage_calculator;

    // ** specific mob  attack 
    // ** specific char defense
    // ** security 

    public Specific_mob_damage_calculator specific_modifier_attack; // ** sempre 
    public Specific_mob_damage_calculator specific_modifier_defense; // ** sempre 

}
