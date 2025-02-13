using UnityEngine;


public struct Basic_transform {

        public Basic_transform Construct(){

            Basic_transform basic_transform = new Basic_transform();

                basic_transform.scale = Vector3.one;

            return basic_transform;

        }

        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

}