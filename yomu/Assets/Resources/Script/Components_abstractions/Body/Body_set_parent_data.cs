using UnityEngine;

public struct Body_set_parent_data {

    public GameObject parent;

    // ** normal 
    public bool set_new_transform;
    public Transform_data self_transform;
        // ** pode tirar depois(?)
        public Vector3 position;
    // public Vector3 scale;
    // public Quaternion rotation;

    // ** off set
    public bool set_new_transform_anchour;
    public Transform_data anchour_transform;
    // public Vector3 anchour_position;
    // public Vector3 anchour_scale;
    // public Quaternion anchour_rotation;
    

}
