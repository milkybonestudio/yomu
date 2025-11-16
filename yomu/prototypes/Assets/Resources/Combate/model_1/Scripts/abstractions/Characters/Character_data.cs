

public struct Character_data {


    public string name;

    public int life;
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

    public int Reduce_count_skill( Skill _skill ){

        ref Skill_data skill_data_ref = ref skill_up;
        switch( _skill ){
            case Skill.up: skill_data_ref = ref skill_up; break;
            case Skill.down: skill_data_ref = ref skill_down; break;
            case Skill.left: skill_data_ref = ref skill_left; break;
            case Skill.right: skill_data_ref = ref skill_right; break;
            default: throw new System.Exception( $"Can not handle skill <Color=lightBlue>{ _skill }</Color>" );
        }


        skill_data_ref.skill_direction = _skill;

        if( skill_data_ref.number_casts == 0 )
            { throw new System.Exception( $"tried to cast the skill number_casts { skill_data_ref.name } but the count is 0" ); }

        skill_data_ref.number_casts -= 1;
    	skill_data_ref.Update_uses();
        return skill_data_ref.number_casts;


    }

}