

public struct Character_data {


    public string name;

    public float health;
    public bool can_cast;

    public Skill_data skill_up;
    public Skill_data skill_down;
    public Skill_data skill_left;
    public Skill_data skill_right;

    public Skill_data Get_skill( Skill _skill ){

        switch( _skill ){
            case Skill.up: return skill_up;
            case Skill.down: return skill_down;
            case Skill.left: return skill_left;
            case Skill.right: return skill_right;
            default: throw new System.Exception( $"Can not handle skill <Color=lightBlue>{ _skill }</Color>" );
        }

    }


}