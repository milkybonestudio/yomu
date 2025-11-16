using UnityEngine;

public struct Transform_data {
    
    public Position position;
    public Scale scale;
    public Quaternion rotation;

}

public struct Body_transform_data{

    public bool not_use_normal;
    public Transform_data normal;
    public bool use_anchour_normal;
    public Transform_data anchour;

}