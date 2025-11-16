


using TMPro;
using UnityEngine;

public enum Skill_targt_type {

    single, 
    area, 
    close, // ** 1 right and left

}


public enum Skill_type {

    damage, 
    healing,

}

public struct Skill_data { 


    public void Update_uses(){

        
        if( number_casts == 0 )
            { text.color = Color.gray; }
        string uses = number_casts > 500 ? "∞" : number_casts.ToString() ;

        text.text = $"USES: { uses } \n FIX: { calculator.fix_damage } \n RANDON: { calculator.max_slot_damage } \n TYPE: { target_type }";

    }

    public TextMeshProUGUI text;

    public int life;

    public string visual_attack_name;
    public Skill skill_direction;

    public Skill_type skill_type;
    public int number_casts;

    public string name;
    public string description;

    
    public string image_name;
    public string special_image_name;


    public Skill_targt_type target_type;

    // ** damage
    public Damage_calculator calculator;

    // ** healing
    public int healing_quantity;


}