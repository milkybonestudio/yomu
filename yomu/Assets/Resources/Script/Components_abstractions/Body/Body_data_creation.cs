using UnityEngine;


public struct Body_position_type_data{}
public struct Body_rotation_type_data{}
public struct Body_scale_type_data{}

public struct Body_data_creation {


        public bool put_in_container;
        
        // ** por hora nao esta usando
        public Vector3 initial_position_in_parent;
        public Vector3 initial_scale_in_parent;
        public Quaternion initial_rotation_in_parent;


        // ** TRANSFORM TYPES 

            // ** TYPES

            // ** NORMAL 
            public Body_position_type position_type;
            public Body_position_type_data position_type_data;

            public Body_rotation_type rotation_type;
            public Body_rotation_type_data rotation_type_data;
            
            public Body_scale_type scale_type;
            public Body_scale_type_data scale_type_data;

            // ** ANCHOUR
            public Body_position_type anchour_position_type;
            public Body_position_type_data anchour_position_type_data;

            public Body_rotation_type anchour_rotation_type;
            public Body_rotation_type_data anchour_rotation_type_data;

            public Body_scale_type anchour_scale_type;
            public Body_scale_type_data anchour_scale_type_data;


        // ** CHANGE PARENT

            public GameObject parent;


        // ** CHANGE TRANSFORM 

            // ** GENERIC
            // ** geralmente não vai ser usado
            // ** isso iria mudar oque estaria no prefab

            // public bool set_new_transform;
            public Transform_type NOT_force_transform;
            public Transform_data transform_in_parent;
            public Vector3 position_in_parent;
            public Vector3 scale_in_parent;
            public Quaternion rotation_in_parent;

            // ** ANCHOUR
            // ** anchour nao precisa verificar se tem novos pois é adicinada por script
            // ** se precisa de anchour os valores são validos 
            // ** se o normal precisar ele é a exceção
            public bool need_anchour; // ** 3 gameObjzcts
        
            public Transform_type NOT_force_transform_anchour;
            public Vector3 anchour_position;
            public Vector3 anchour_scale;
            public Quaternion anchour_rotation;

        // ** RENDER
            // ** ver depois
            public bool need_camera_render;
            public Dimensions_combined_images dimensions_render;


        public void Verify(){

            // ** GENERIC 
            if( ( scale_in_parent.x == 0f ) && ( scale_in_parent.y == 0f ) && ( scale_in_parent.z == 0f ) )
                { scale_in_parent = Vector3.one; }


            if( ( rotation_in_parent.x == 0 ) && ( rotation_in_parent.y == 0 ) && ( rotation_in_parent.z == 0 ) && ( rotation_in_parent.w == 0 ) )
                { rotation_in_parent = Quaternion.identity; }


            // ** OFF SET
            if( ( anchour_scale.x == 0f ) && ( anchour_scale.y == 0f ) && ( anchour_scale.z == 0f ) )
                { anchour_scale = Vector3.one; }


            if( ( anchour_rotation.x == 0 ) && ( anchour_rotation.y == 0 ) && ( anchour_rotation.z == 0 ) && ( anchour_rotation.w == 0 ) )
                { anchour_rotation = Quaternion.identity; }

            
        }


}

