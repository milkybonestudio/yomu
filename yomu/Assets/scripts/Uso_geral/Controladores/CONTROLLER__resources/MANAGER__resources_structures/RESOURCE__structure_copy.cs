

using UnityEngine;

public class RESOURCE__structure_copy {

    public RESOURCE__structure_copy( RESOURCE__structure _structure, Resource_structure_content _level_pre_allocation ){

        structure = _structure;
        level_pre_allocation = _level_pre_allocation;

    }


    public RESOURCE__structure structure;
    public Resource_structure_content level_pre_allocation;

    public Resource_structure_content actual_content;


    public GameObject structure_game_object; // proprio


}