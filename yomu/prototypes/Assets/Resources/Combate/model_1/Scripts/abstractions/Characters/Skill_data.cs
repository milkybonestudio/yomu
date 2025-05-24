


public enum Skill_targt_type {

    single, 
    area, 
    close, // ** 1 right and left

}


public struct Skill_data { 


    public string name;
    public string description;

    public bool special_image;
    public string image_name;

    public Skill_targt_type target_type;

    public Damage_calculator calculator;


}